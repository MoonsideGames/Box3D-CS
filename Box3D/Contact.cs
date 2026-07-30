using System;

namespace Box3D;

public readonly record struct ContactID(int Index, ushort World, short Padding, uint Generation)
{
    public static implicit operator Interop.b3ContactId(ContactID id) => new()
    {
        index1 = id.Index,
        world0 = id.World,
        padding = id.Padding,
        generation = id.Generation
    };

    public static implicit operator ContactID(Interop.b3ContactId id) => new()
    {
        Index = id.index1,
        World = id.world0,
        Padding = id.padding,
        Generation = id.generation
    };
}

public struct Contact : IEquatable<Contact>
{
    public ContactID ID { get; }

    public readonly bool IsValid => Interop.b3Contact_IsValid(ID);

    internal Contact(ContactID id)
    {
        ID = id;
    }

    public readonly override bool Equals(object obj) => obj is Contact other && Equals(other);
    public readonly bool Equals(Contact other) => ID.Equals(other.ID);
    public override readonly int GetHashCode() => ID.GetHashCode();

    public static bool operator ==(Contact left, Contact right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Contact left, Contact right)
    {
        return !left.Equals(right);
    }
}
