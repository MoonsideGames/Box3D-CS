using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Box3D;

public struct Capacity
{
    public int StaticShapeCount;
    public int DynamicShapeCount;
    public int StaticBodyCount;
    public int DynamicBodyCount;
    public int ContactCount;

    public static implicit operator Interop.b3Capacity(Capacity capacity) => new()
    {
        staticShapeCount = capacity.StaticShapeCount,
        dynamicShapeCount = capacity.DynamicShapeCount,
        staticBodyCount = capacity.StaticBodyCount,
        dynamicBodyCount = capacity.DynamicBodyCount,
        contactCount = capacity.ContactCount
    };

    public static implicit operator Capacity(Interop.b3Capacity capacity) => new()
    {
        StaticShapeCount = capacity.staticShapeCount,
        DynamicShapeCount = capacity.dynamicShapeCount,
        StaticBodyCount = capacity.staticBodyCount,
        DynamicBodyCount = capacity.dynamicBodyCount,
        ContactCount = capacity.contactCount
    };
}

public struct WorldDef
{
    public const int SECRET_COOKIE = 1152023;

    public Vector3 Gravity;
    public float RestitutionThreshold;
    public float HitEventThreshold;
    public float ContactHertz;
    public float ContactDampingRatio;
    public float ContactSpeed;
    public float MaximumLinearSpeed;

    // TODO: how to implement callbacks?
    public IntPtr FrictionCallback;
    public IntPtr RestitutionCallback;
    public bool EnableSleep;
    public bool EnableContinuous;
    public uint WorkerCount;
    public IntPtr EnqueueTask;
    public IntPtr FinishTask;
    public IntPtr UserTaskContext;
    public IntPtr UserData;
    public IntPtr CreateDebugShape;
    public IntPtr DestroyDebugShape;
    public IntPtr UserDebugShapeContext;
    public Capacity Capacity;
    internal int InternalValue;

    public static WorldDef Default => Interop.b3DefaultWorldDef();

    public static implicit operator Interop.b3WorldDef(WorldDef def) => new()
    {
        gravity = Utility.ToBox3DVector(def.Gravity),
        restitutionThreshold = def.RestitutionThreshold,
        hitEventThreshold = def.HitEventThreshold,
        contactHertz = def.ContactHertz,
        contactDampingRatio = def.ContactDampingRatio,
        contactSpeed = def.ContactSpeed,
        maximumLinearSpeed = def.MaximumLinearSpeed,
        frictionCallback = def.FrictionCallback,
        restitutionCallback = def.RestitutionCallback,
        enableSleep = def.EnableSleep,
        enableContinuous = def.EnableContinuous,
        workerCount = def.WorkerCount,
        enqueueTask = def.EnqueueTask,
        finishTask = def.FinishTask,
        userTaskContext = def.UserTaskContext,
        userData = def.UserData,
        createDebugShape = def.CreateDebugShape,
        destroyDebugShape = def.DestroyDebugShape,
        userDebugShapeContext = def.UserDebugShapeContext,
        capacity = def.Capacity,
        internalValue = def.InternalValue
    };

    public static implicit operator WorldDef(Interop.b3WorldDef def) => new()
    {
        Gravity = Utility.ToVector3(def.gravity),
        RestitutionThreshold = def.restitutionThreshold,
        HitEventThreshold = def.hitEventThreshold,
        ContactHertz = def.contactHertz,
        ContactDampingRatio = def.contactDampingRatio,
        ContactSpeed = def.contactSpeed,
        MaximumLinearSpeed = def.maximumLinearSpeed,
        FrictionCallback = def.frictionCallback,
        RestitutionCallback = def.restitutionCallback,
        EnableSleep = def.enableSleep,
        EnableContinuous = def.enableContinuous,
        WorkerCount = def.workerCount,
        EnqueueTask = def.enqueueTask,
        FinishTask = def.finishTask,
        UserTaskContext = def.userTaskContext,
        UserData = def.userData,
        CreateDebugShape = def.createDebugShape,
        DestroyDebugShape = def.destroyDebugShape,
        UserDebugShapeContext = def.userDebugShapeContext,
        Capacity = def.capacity,
        InternalValue = def.internalValue
    };
}

public class World
{
    public Interop.b3WorldId ID { get; private init; }

    public bool IsValid => Interop.b3World_IsValid(ID);

    // Various callback helpers

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate bool PlaneResultDelegate(ShapeID shapeID, PlaneResult* plane, int planeCount, void* context);
    private unsafe static readonly PlaneResultDelegate PlaneCollectorInstance = PlaneCollector;
    private readonly IntPtr PlaneCollectorPtr = Marshal.GetFunctionPointerForDelegate(PlaneCollectorInstance);

    private unsafe struct PlaneCollectorContext
    {
        public CollisionPlane* Buffer;
        public int Capacity;
        public int Count;
        public float PushLimit;
    }

    private unsafe static bool PlaneCollector(ShapeID shapeID, PlaneResult* planes, int planeCount, void* context)
    {
        var collectorContext = (PlaneCollectorContext*)context;
        for (var i = 0; i < planeCount; i += 1)
        {
            if (collectorContext->Count == collectorContext->Capacity)
            {
                return false;
            }

            collectorContext->Buffer[collectorContext->Count] = new CollisionPlane(
                planes[i].Plane,
                collectorContext->PushLimit,
                0f,
                true);
            collectorContext->Count += 1;
        }
        return true;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate float CastCollectorDelegate(ShapeID shapeID, Vector3 point, Vector3 normal, float fraction, ulong userMaterialID, int triangleIndex, int childIndex, void* context);
    private unsafe static readonly CastCollectorDelegate CastCollectorInstance = CastCollector;
    private readonly IntPtr CastCollectorPtr = Marshal.GetFunctionPointerForDelegate(CastCollectorInstance);

    private unsafe static readonly CastCollectorDelegate ClosestShapeCastInstance = ClosestShapeCast;
    private readonly IntPtr ClosestShapeCastPtr = Marshal.GetFunctionPointerForDelegate(ClosestShapeCastInstance);

    private unsafe struct RayCollectorContext
    {
        public RayHit* Buffer;
        public int Capacity;
        public int Count;
    }

    private unsafe static float CastCollector(ShapeID shapeID, Vector3 point, Vector3 normal, float fraction, ulong userMaterialID, int triangleIndex, int childIndex, void* context)
    {
        var collectorContext = (RayCollectorContext*)context;

        // Terminate if buffer is full
        if (collectorContext->Count == collectorContext->Capacity) { return 0f; }

        collectorContext->Buffer[collectorContext->Count] = new RayHit(
            shapeID,
            point,
            normal,
            fraction,
            userMaterialID,
            triangleIndex,
            childIndex
        );
        collectorContext->Count += 1;

        return 1; // Collect every hit
    }

    [InlineArray(16)]
    private struct IgnoreShapesArray
    {
        private Interop.b3ShapeId ignoreShape;
    }

    private struct ClosestShapeCastContext
    {
        public IgnoreShapesArray IgnoreShapes;
        public int IgnoreCount;
        public float ClosestFraction;
        public Vector3 ClosestNormal;
        public Vector3 ClosestPoint;
        public Interop.b3ShapeId ClosestShape;
        public bool Hit;
        public bool StartedSolid;
    }

    public struct ClosestShapeCastResult
    {
        public float ClosestFraction;
        public Vector3 ClosestNormal;
        public Vector3 ClosestPoint;
        public ShapeID ClosestShape;
        public bool Hit;
        public bool StartedSolid;
    }

    private unsafe static float ClosestShapeCast(ShapeID shapeID, Vector3 point, Vector3 normal, float fraction, ulong userMaterialID, int triangleIndex, int childIndex, void* context)
    {
        var closestShapeContext = (ClosestShapeCastContext*)context;

        for (var i = 0; i < closestShapeContext->IgnoreCount; i += 1)
        {
            if (shapeID == closestShapeContext->IgnoreShapes[i])
            {
                return -1f;
            }
        }

        if (fraction == 0f)
        {
            closestShapeContext->StartedSolid = true;
            return -1f;
        }

        if (fraction < closestShapeContext->ClosestFraction)
        {
            closestShapeContext->ClosestFraction = fraction;
            closestShapeContext->ClosestNormal = normal;
            closestShapeContext->ClosestPoint = point;
            closestShapeContext->ClosestShape = shapeID;
            closestShapeContext->Hit = true;
        }

        return closestShapeContext->ClosestFraction;
    }

    public static World Create(WorldDef def)
    {
        var handle = Interop.b3CreateWorld(def);
        return new World(handle);
    }

    private World(Interop.b3WorldId handle)
    {
        ID = handle;
    }

    public void Step(float timestep, int subStepCount = 4)
    {
        Interop.b3World_Step(ID, timestep, subStepCount);
    }

    public unsafe Body CreateBody(in BodyDef def)
    {
        var unmanagedString = Utf8StringMarshaller.ConvertToUnmanaged(def.Name);

        var interopDef = new Interop.b3BodyDef
        {
            type = (Interop.b3BodyType)def.Type,
            position = Utility.ToBox3DVector(def.Position),
            rotation = Utility.ToBox3DQuaternion(def.Rotation),
            linearVelocity = Utility.ToBox3DVector(def.LinearVelocity),
            angularVelocity = Utility.ToBox3DVector(def.AngularVelocity),
            linearDamping = def.LinearDamping,
            angularDamping = def.AngularDamping,
            gravityScale = def.GravityScale,
            sleepThreshold = def.SleepThreshold,
            name = unmanagedString,
            userData = def.UserData,
            motionLocks = def.MotionLocks,
            enableSleep = def.EnableSleep,
            isAwake = def.IsAwake,
            isBullet = def.IsBullet,
            isEnabled = def.IsEnabled,
            allowFastRotation = def.AllowFastRotation,
            enableContactRecycling = def.EnableContactRecycling,
            internalValue = def.InternalValue
        };

        var bodyID = Interop.b3CreateBody(ID, interopDef);
        var body = new Body(bodyID);

        Utf8StringMarshaller.Free(unmanagedString);

        return body;
    }

    /// <summary>
    /// Events are valid only until the next Step or world mutation.
    /// </summary>
    public unsafe ReadOnlySpan<BodyMoveEvent> GetBodyMoveEvents()
    {
        var events = Interop.b3World_GetBodyEvents(ID);
        return new ReadOnlySpan<BodyMoveEvent>(events.moveEvents, events.moveCount);
    }

    /// <summary>
    /// Events are valid only until the next Step or world mutation.
    /// Shapes must opt in to contact events by setting ShapeDef.EnableContactEvents and/or ShapeDef.EnableHitEvents.
    /// </summary>
    public unsafe ContactEvents GetContactEvents()
    {
        var events = Interop.b3World_GetContactEvents(ID);
        return new ContactEvents(
            new ReadOnlySpan<ContactBeginTouchEvent>(events.beginEvents, events.beginCount),
            new ReadOnlySpan<ContactEndTouchEvent>(events.endEvents, events.endCount),
            new ReadOnlySpan<ContactHitEvent>(events.hitEvents, events.hitCount)
        );
    }

    /// <summary>
    /// Events are valid only until the next Step or world mutation.
    /// Sensor and visitor shapes must opt in to sensor events by setting ShapeDef.EnableSensorEvents.
    /// </summary>
    /// <returns></returns>
    public unsafe SensorEvents GetSensorEvents()
    {
        var events = Interop.b3World_GetSensorEvents(ID);
        return new SensorEvents(
            new ReadOnlySpan<SensorBeginTouchEvent>(events.beginEvents, events.beginCount),
            new ReadOnlySpan<SensorEndTouchEvent>(events.endEvents, events.endCount)
        );
    }

    public unsafe ReadOnlySpan<JointEvent> GetJointEvents()
    {
        var events = Interop.b3World_GetJointEvents(ID);
        return new ReadOnlySpan<JointEvent>(events.jointEvents, events.count);
    }

    public float CastMover(in Vector3 origin, in Capsule mover, in Vector3 translation, QueryFilter filter)
    {
        return Interop.b3World_CastMover(
            ID,
            Utility.ToBox3DVector(origin),
            mover,
            Utility.ToBox3DVector(translation),
            filter,
            IntPtr.Zero,
            IntPtr.Zero);
    }

    public unsafe int CastShape(in Vector3 origin, ReadOnlySpan<Vector3> proxyPoints, float proxyRadius, in Vector3 translation, QueryFilter filter, Span<RayHit> hits, out TreeStats stats)
    {
        if (proxyPoints.IsEmpty)
        {
            stats = new TreeStats();
            return 0;
        }

        fixed (Vector3* points = proxyPoints)
        fixed (RayHit* buffer = hits)
        {
            var proxy = new Interop.b3ShapeProxy
            {
                points = (Interop.b3Vec3*)points,
                count = proxyPoints.Length,
                radius = proxyRadius
            };

            var collectorContext = new RayCollectorContext
            {
                Buffer = buffer,
                Capacity = hits.Length
            };

            stats = Interop.b3World_CastShape(
                ID,
                Utility.ToBox3DVector(origin),
                proxy,
                Utility.ToBox3DVector(translation),
                filter,
                CastCollectorPtr,
                (nint)(&collectorContext)
            );

            return collectorContext.Count;
        }
    }

    public int CastShape(in Vector3 origin, ReadOnlySpan<Vector3> proxyPoints, float proxyRadius, in Vector3 translation, QueryFilter filter, Span<RayHit> hits) =>
        CastShape(origin, proxyPoints, proxyRadius, translation, filter, hits, out _);

    // FIXME: this will silently fail if the ignore shapes is longer than 16, how do we warn?
    public unsafe ClosestShapeCastResult CastShapeClosest(in Vector3 origin, ReadOnlySpan<Vector3> proxyPoints, float proxyRadius, in Vector3 translation, QueryFilter filter, Span<ShapeID> ignoreShapes)
    {
        if (proxyPoints.IsEmpty)
        {
            return new ClosestShapeCastResult();
        }

        fixed (Vector3* points = proxyPoints)
        {
            var proxy = new Interop.b3ShapeProxy
            {
                points = (Interop.b3Vec3*)points,
                count = proxyPoints.Length,
                radius = proxyRadius
            };

            var closestShapeContext = new ClosestShapeCastContext();
            for (var i = 0; i < int.Min(ignoreShapes.Length, 16); i += 1)
            {
                closestShapeContext.IgnoreShapes[i] = ignoreShapes[i];
            }
            closestShapeContext.IgnoreCount = ignoreShapes.Length;
            closestShapeContext.ClosestFraction = 1f;
            closestShapeContext.Hit = false;
            closestShapeContext.StartedSolid = false;
            closestShapeContext.ClosestShape = new Interop.b3ShapeId(); // null shape id

            Interop.b3World_CastShape(
                ID,
                Utility.ToBox3DVector(origin),
                proxy,
                Utility.ToBox3DVector(translation),
                filter,
                ClosestShapeCastPtr,
                (nint)(&closestShapeContext)
            );

            return new ClosestShapeCastResult
            {
                ClosestFraction = closestShapeContext.ClosestFraction,
                ClosestNormal = closestShapeContext.ClosestNormal,
                ClosestPoint = closestShapeContext.ClosestPoint,
                ClosestShape = closestShapeContext.ClosestShape,
                Hit = closestShapeContext.Hit,
                StartedSolid = closestShapeContext.StartedSolid
            };
        }
    }

    public unsafe int CollideMover(in Vector3 origin, in Capsule mover, QueryFilter filter, Span<CollisionPlane> planes, float pushLimit = float.MaxValue)
    {
        fixed (CollisionPlane* p = planes)
        {
            var context = new PlaneCollectorContext
            {
                Buffer = p,
                Capacity = planes.Length,
                PushLimit = pushLimit
            };
            Interop.b3World_CollideMover(ID, Utility.ToBox3DVector(origin), mover, filter, PlaneCollectorPtr, (nint)(&context));
            return context.Count;
        }
    }

    public unsafe static PlaneSolverResult SolvePlanes(in Vector3 targetDelta, Span<CollisionPlane> planes)
    {
        fixed (CollisionPlane* p = planes)
        {
            // TODO: can the interop function just take a span somehow?
            return Interop.b3SolvePlanes(Utility.ToBox3DVector(targetDelta), (Interop.b3CollisionPlane*)p, planes.Length);
        }
    }

    public unsafe static Vector3 ClipVector(in Vector3 vector, Span<CollisionPlane> planes)
    {
        fixed (CollisionPlane* p = planes)
        {
            return Utility.ToVector3(Interop.b3ClipVector(Utility.ToBox3DVector(vector), (Interop.b3CollisionPlane*)p, planes.Length));
        }
    }
}
