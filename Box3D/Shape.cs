using System;

namespace Box3D;

public readonly record struct ShapeID(int Index, ushort World, ushort Generation)
{
    public static implicit operator Interop.b3ShapeId(ShapeID id)
    {
        return new Interop.b3ShapeId
        {
            index1 = id.Index,
            world0 = id.World,
            generation = id.Generation
        };
    }
}

public struct Shape : IEquatable<Shape>
{
    public ShapeID ID { get; }

    public readonly bool IsValid => Interop.b3Shape_IsValid(ID);

    public readonly override bool Equals(object obj) => obj is Shape other && Equals(other);
    public readonly bool Equals(Shape other) => ID.Equals(other.ID);
    public override readonly int GetHashCode() => ID.GetHashCode();

    public static bool operator ==(Shape left, Shape right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Shape left, Shape right)
    {
        return !left.Equals(right);
    }
}
