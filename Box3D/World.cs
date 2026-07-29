using System;
using System.Numerics;

namespace Box3D;

public struct Capacity
{
    public int StaticShapeCount;
    public int DynamicShapeCount;
    public int StaticBodyCount;
    public int DynamicBodyCount;
    public int ContactCount;

    internal Interop.b3Capacity ToBox3D()
    {
        return new Interop.b3Capacity
        {
            staticShapeCount = StaticShapeCount,
            dynamicShapeCount = DynamicShapeCount,
            staticBodyCount = StaticBodyCount,
            dynamicBodyCount = DynamicBodyCount,
            contactCount = ContactCount
        };
    }
}

public struct WorldDef
{
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

    internal Interop.b3WorldDef ToBox3D()
    {
        return new Interop.b3WorldDef
        {
            gravity = Utility.ToBox3DVector(Gravity),
            restitutionThreshold = RestitutionThreshold,
            hitEventThreshold = HitEventThreshold,
            contactHertz = ContactHertz,
            contactDampingRatio = ContactDampingRatio,
            contactSpeed = ContactSpeed,
            maximumLinearSpeed = MaximumLinearSpeed,
            frictionCallback = FrictionCallback,
            restitutionCallback = RestitutionCallback,
            enableSleep = EnableSleep,
            enableContinuous = EnableContinuous,
            workerCount = WorkerCount,
            enqueueTask = EnqueueTask,
            finishTask = FinishTask,
            userTaskContext = UserTaskContext,
            userData = UserData,
            createDebugShape = CreateDebugShape,
            destroyDebugShape = DestroyDebugShape,
            userDebugShapeContext = UserDebugShapeContext,
            capacity = Capacity.ToBox3D(),
            internalValue = InternalValue
        };
    }
}

public class World
{
    internal Interop.b3WorldId Handle { get; init; }

    public bool IsValid => Interop.b3World_IsValid(Handle);

    public static World Create(WorldDef def)
    {
        var interopDef = def.ToBox3D();
        var handle = Interop.b3CreateWorld(interopDef);

        return new World(handle);
    }

    private World(Interop.b3WorldId handle)
    {
        Handle = handle;
    }

    public bool TryGetBody(BodyID id, out Body body)
    {

    }
}
