using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Box3D;

public readonly record struct Transform(Vector3 Position, Quaternion Quaternion)
{
    public Matrix4x4 ToMatrix4x4()
    {
        return
            Matrix4x4.CreateFromQuaternion(Quaternion) *
            Matrix4x4.CreateTranslation(Position);
    }
}

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

    public static SurfaceMaterial Default => new()
    {
        Friction = 0.6f
    };

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

    public static CollisionFilter Default => new()
    {
        CategoryBits = ulong.MaxValue,
        MaskBits = ulong.MaxValue,
        GroupIndex = 0
    };

    public static implicit operator Interop.b3Filter(CollisionFilter filter) => new()
    {
        categoryBits = filter.CategoryBits,
        maskBits = filter.MaskBits,
        groupIndex = filter.GroupIndex
    };
}

public record struct QueryFilter(
    ulong CategoryBits,
    ulong MaskBits,
    ulong ID,
    IntPtr Name) // byte* string
{
    public static QueryFilter Default => Interop.b3DefaultQueryFilter();

    public unsafe static implicit operator Interop.b3QueryFilter(QueryFilter filter) => new()
    {
        categoryBits = filter.CategoryBits,
        maskBits = filter.MaskBits,
        id = filter.ID,
        name = (byte*)filter.Name
    };

    public unsafe static implicit operator QueryFilter(Interop.b3QueryFilter filter) => new()
    {
        CategoryBits = filter.categoryBits,
        MaskBits = filter.maskBits,
        ID = filter.id,
        Name = (IntPtr)filter.name
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
    const int SECRET_COOKIE = 1152023;

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

    // Just reimplement this to avoid the string allocation weirdness
    public static BodyDef Default => new BodyDef
    {
        Type = BodyType.Static,
        Rotation = Quaternion.Identity,
        SleepThreshold = 0.05f * Interop.b3GetLengthUnitsPerMeter(),
        GravityScale = 1f,
        EnableSleep = true,
        IsAwake = true,
        IsEnabled = true,
        EnableContactRecycling = true,
        InternalValue = SECRET_COOKIE
    };
}

public struct ShapeDef
{
    const int SECRET_COOKIE = 1152023;

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

    // Just reimplement this to avoid the string allocation weirdness
    public static ShapeDef Default => new()
    {
        BaseMaterial = SurfaceMaterial.Default,
        Materials = [],
        Density = 1000f / (Interop.b3GetLengthUnitsPerMeter() * Interop.b3GetLengthUnitsPerMeter() * Interop.b3GetLengthUnitsPerMeter()),
        ExplosionScale = 1f,
        Filter = CollisionFilter.Default,
        UpdateBodyMass = true,
        InvokeContactCreation = true,
        EnableSpeculativeContact = true,
        InternalValue = SECRET_COOKIE
    };
}

public record struct Sphere(Vector3 Center, float Radius)
{
    public static implicit operator Interop.b3Sphere(Sphere sphere) => new()
    {
        center = Utility.ToBox3DVector(sphere.Center),
        radius = sphere.Radius
    };
}

public record struct Capsule(Vector3 Center1, Vector3 Center2, float Radius)
{
    public static implicit operator Interop.b3Capsule(Capsule capsule) => new()
    {
        center1 = Utility.ToBox3DVector(capsule.Center1),
        center2 = Utility.ToBox3DVector(capsule.Center2),
        radius = capsule.Radius
    };
}

public record struct PlaneResult(
    Plane Plane,
    Vector3 Point,
    int TriangleIndex,
    int ChildIndex,
    int MaterialIndex)
{
    public static implicit operator Interop.b3PlaneResult(PlaneResult result) =>
        Unsafe.BitCast<PlaneResult, Interop.b3PlaneResult>(result);
}

public record struct CollisionPlane(
    Plane Plane,
    float PushLimit,
    float Push,
    bool ClipVelocity)
{
    public static implicit operator Interop.b3CollisionPlane(CollisionPlane plane) => new()
    {
        plane = Utility.ToBox3DPlane(plane.Plane),
        pushLimit = plane.PushLimit,
        push = plane.Push,
        clipVelocity = plane.ClipVelocity
    };
}

public record struct CollisionPlaneExtra(
    Vector3 Point,
    ShapeID ShapeID);

public record struct PlaneSolverResult(
    Vector3 Delta,
    int IterationCount)
{
    public static implicit operator PlaneSolverResult(Interop.b3PlaneSolverResult result) => new()
    {
        Delta = Utility.ToVector3(result.delta),
        IterationCount = result.iterationCount
    };
}

public record struct TreeStats(
    int NodeVisits,
    int LeafVisits)
{
    public static implicit operator TreeStats(Interop.b3TreeStats result) => new()
    {
        NodeVisits = result.nodeVisits,
        LeafVisits = result.leafVisits
    };
}

public readonly record struct RayHit(
    ShapeID ShapeID,
    Vector3 Point,
    Vector3 Normal,
    float Fraction,
    ulong UserMaterialID,
    int TriangleIndex,
    int ChildIndex);

public readonly record struct RayResult(
    ShapeID ShapeID,
    Vector3 Point,
    Vector3 Normal,
    ulong UserMaterialID,
    float Fraction,
    int TriangleIndex,
    int ChildIndex,
    int NodeVisits,
    int LeafVisits,
    bool Hit)
{
    public static implicit operator RayResult(Interop.b3RayResult result) => new()
    {
        ShapeID = result.shapeId,
        Point = Utility.ToVector3(result.point),
        Normal = Utility.ToVector3(result.normal),
        UserMaterialID = result.userMaterialId,
        Fraction = result.fraction,
        TriangleIndex = result.triangleIndex,
        ChildIndex = result.childIndex,
        NodeVisits = result.nodeVisits,
        LeafVisits = result.leafVisits,
        Hit = result.hit
    };
}

public readonly record struct Matrix3x3(
    Vector3 X,
    Vector3 Y,
    Vector3 Z)
{
    public static implicit operator Matrix3x3(Interop.b3Matrix3 matrix) =>
        Unsafe.BitCast<Interop.b3Matrix3, Matrix3x3>(matrix);

    public Vector3 Multiply(Vector3 a)
    {
        return new Vector3(
            X.X * a.X + Y.X * a.Y + Z.X * a.Z,
            X.Y * a.X + Y.Y * a.Y + Z.Y * a.Z,
            X.Z * a.X + Y.Z * a.Y + Z.Z * a.Z
        );
    }

    public static Vector3 operator *(Matrix3x3 m, Vector3 a) =>
        m.Multiply(a);
}
