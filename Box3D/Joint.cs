using System;

namespace Box3D;

public readonly record struct JointID(int Index, ushort World, ushort Generation)
{
    public static implicit operator Interop.b3JointId(JointID id) => new()
    {
        index1 = id.Index,
        world0 = id.World,
        generation = id.Generation
    };
}

public struct Joint : IEquatable<Joint>
{
    public JointID ID { get; }

    public readonly bool IsValid => Interop.b3Joint_IsValid(ID);

    internal Joint(JointID id)
    {
        ID = id;
    }

    public readonly override bool Equals(object obj) => obj is Joint other && Equals(other);
    public readonly bool Equals(Joint other) => ID.Equals(other.ID);
    public override readonly int GetHashCode() => ID.GetHashCode();

    public static bool operator ==(Joint left, Joint right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Joint left, Joint right)
    {
        return !left.Equals(right);
    }
}
