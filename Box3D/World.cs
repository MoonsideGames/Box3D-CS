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
    public int InternalValue;
}

public class World
{
    public uint Handle { get; init; }

    public static World Create(WorldDef def)
    {
        var handle = Interop.b3CreateWorld(def);

        return new World((uint) handle);
    }

    private World(uint handle)
    {
        Handle = handle;
    }
}
