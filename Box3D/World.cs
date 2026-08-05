using System;
using System.Numerics;
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
}
