using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Box3D;

public readonly record struct Transform(Vector3 Position, Quaternion Quaternion);

public enum BodyType
{
    Static = 0,
    Kinematic = 1,
    Dynamic = 2,
}

public struct SurfaceMaterial
{
    public float Friction;
    public float Restitution;
    public float RollingResistance;
    public Vector3 TangentVelocity;
    public ulong UserMaterialId;
    public uint CustomColor;
    public uint Padding;

    public static implicit operator Interop.b3SurfaceMaterial(SurfaceMaterial material) => new()
    {
        friction = material.Friction,
        restitution = material.Restitution,
        rollingResistance = material.RollingResistance,
        tangentVelocity = Utility.ToBox3DVector(material.TangentVelocity),
        userMaterialId = material.UserMaterialId,
        customColor = material.CustomColor
    };
}

public struct CollisionFilter
{
    public ulong CategoryBits;
    public ulong MaskBits;
    public int GroupIndex;

    public static implicit operator Interop.b3Filter(CollisionFilter filter) => new()
    {
        categoryBits = filter.CategoryBits,
        maskBits = filter.MaskBits,
        groupIndex = filter.GroupIndex
    };
}

public struct MotionLocks
{
    public bool LinearX;
    public bool LinearY;
    public bool LinearZ;
    public bool AngularX;
    public bool AngularY;
    public bool AngularZ;

    public static implicit operator Interop.b3MotionLocks(MotionLocks motionLocks) => new()
    {
        linearX = motionLocks.LinearX,
        linearY = motionLocks.LinearY,
        linearZ = motionLocks.LinearZ,
        angularX = motionLocks.AngularX,
        angularY = motionLocks.AngularY,
        angularZ = motionLocks.AngularZ
    };
}

public struct BodyDef
{
    public BodyType Type;
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 LinearVelocity;
    public Vector3 AngularVelocity;
    public float LinearDamping;
    public float AngularDamping;
    public float GravityScale;
    public float SleepThreshold;
    public string Name;
    public IntPtr UserData;
    public MotionLocks MotionLocks;
    public bool EnableSleep;
    public bool IsAwake;
    public bool IsBullet;
    public bool IsEnabled;
    public bool AllowFastRotation;
    public bool EnableContactRecycling;
    internal int InternalValue;
}

public struct ShapeDef
{
    public string Name;
    public IntPtr UserData;
    public SurfaceMaterial[] Materials;
    public SurfaceMaterial BaseMaterial;
    public float Density;
    public float ExplosionScale;
    public CollisionFilter Filter;
    public bool EnableCustomFiltering;
    public bool IsSensor;
    public bool EnableSensorEvents;
    public bool EnableContactEvents;
    public bool EnableHitEvents;
    public bool EnablePreSolveEvents;
    public bool InvokeContactCreation;
    public bool UpdateBodyMass;
    public bool EnableSpeculativeContact;
    internal int InternalValue;
}

public struct Sphere
{
    public Vector3 Center;
    public float Radius;

    public static implicit operator Interop.b3Sphere(Sphere sphere) => new()
    {
        center = Utility.ToBox3DVector(sphere.Center),
        radius = sphere.Radius
    };
}
