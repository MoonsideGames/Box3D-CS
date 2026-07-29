using System;
using System.Numerics;

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
}

public struct CollisionFilter
{
    public ulong CategoryBits;
    public ulong MaskBits;
    public int GroupIndex;
}

public struct ShapeDef
{
    public IntPtr UserData;
    public IntPtr Materials;
    public int MaterialCount;
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

    internal Interop.b3ShapeDef ToBox3D()
    {
        return new Interop.b3ShapeDef
        {
            userData = UserData,
            materials = Materials,
            materialCount = MaterialCount,
            baseMaterial = BaseMaterial,
            density = Density,
            explosionScale = ExplosionScale,
            filter = Filter,
            enableCustomFiltering = EnableCustomFiltering,
            isSensor = IsSensor,
            enableSensorEvents = EnableSensorEvents,
            enableContactEvents = EnableContactEvents,
            enableHitEvents = EnableHitEvents,
            enablePreSolveEvents = EnablePreSolveEvents,
            invokeContactCreation = InvokeContactCreation,
            updateBodyMass = UpdateBodyMass,
            enableSpeculativeContact = EnableSpeculativeContact,
            internalValue = InternalValue
        };
    }
}
