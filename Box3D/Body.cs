using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Box3D;

public readonly record struct BodyID(int Index, ushort World, ushort Generation)
{
    public static implicit operator Interop.b3BodyId(BodyID id)
    {
        return new Interop.b3BodyId
        {
            index1 = id.Index,
            world0 = id.World,
            generation = id.Generation
        };
    }
}

public struct Body : IEquatable<Body>
{
    public BodyID ID { get; }

    public readonly bool IsValid => Interop.b3Body_IsValid(ID);
    public readonly bool IsAwake => Interop.b3Body_IsAwake(ID);
    public readonly bool IsEnabled => Interop.b3Body_IsEnabled(ID);

    // TODO: what about double-precision mode?
    public readonly Vector3 Position => Utility.ToVector3(Interop.b3Body_GetPosition(ID));
    public readonly Quaternion Rotation => Utility.ToQuaternion(Interop.b3Body_GetRotation(ID));
    public readonly Transform Transform => Utility.ToTransform(Interop.b3Body_GetTransform(ID));

    public readonly Vector3 LinearVelocity
    {
        get => Utility.ToVector3(Interop.b3Body_GetLinearVelocity(ID));
        set => Interop.b3Body_SetLinearVelocity(ID, Utility.ToBox3DVector(value));
    }

    public readonly Vector3 AngularVelocity
    {
        get => Utility.ToVector3(Interop.b3Body_GetAngularVelocity(ID));
        set => Interop.b3Body_SetAngularVelocity(ID, Utility.ToBox3DVector(value));
    }

    public readonly BodyType Type => (BodyType)Interop.b3Body_GetType(ID);

    // TODO: userdata

    public readonly int ShapeCount => Interop.b3Body_GetShapeCount(ID);
    public readonly int JointCount => Interop.b3Body_GetJointCount(ID);

    internal Body(BodyID id) => ID = id;

    public unsafe int GetShapes(Span<ShapeID> buffer)
    {
        fixed (ShapeID* p = buffer)
        {
            return Interop.b3Body_GetShapes(ID, (Interop.b3ShapeId*)p, buffer.Length);
        }
    }

    // TODO: GetJoints
    // TODO: Destroy

    public unsafe Shape CreateMeshShape(in ShapeDef def, TriangleMesh mesh, Vector3 scale)
    {
        Interop.b3CreateMeshShape(ID, def, mesh.MeshData, Utility.ToBox3DVector(scale));
    }

    public readonly override bool Equals(object obj) => obj is Body other && Equals(other);
    public readonly bool Equals(Body other) => ID.Equals(other.ID);
    public override readonly int GetHashCode() => ID.GetHashCode();

    public static bool operator ==(Body left, Body right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Body left, Body right)
    {
        return !left.Equals(right);
    }
}
