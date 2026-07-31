using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

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

    public static implicit operator BodyID(Interop.b3BodyId id)
    {
        return new BodyID(id.index1, id.world0, id.generation);
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

    public unsafe Shape CreateSphereShape(in ShapeDef shapeDef, in Sphere sphere)
    {
        var nativeShapeDef = AllocNativeShapeDef(shapeDef);

        var shapeID = Interop.b3CreateSphereShape(ID, nativeShapeDef, sphere);
        var shape = new Shape(shapeID);

        FreeNativeShapeDef(nativeShapeDef);

        return shape;
    }

    public unsafe Shape CreateMeshShape(in ShapeDef shapeDef, TriangleMesh mesh, Vector3 scale)
    {
        var nativeShapeDef = AllocNativeShapeDef(shapeDef);

        var shapeID = Interop.b3CreateMeshShape(ID, nativeShapeDef, mesh.MeshData, Utility.ToBox3DVector(scale));
        var shape = new Shape(shapeID);

        FreeNativeShapeDef(nativeShapeDef);

        return shape;
    }

    // FIXME: don't expose interop hull data
    public Shape CreateHullShape(in ShapeDef shapeDef, in Interop.b3HullData hullData)
    {
        var nativeShapeDef = AllocNativeShapeDef(shapeDef);

        var shapeID = Interop.b3CreateHullShape(ID, nativeShapeDef, hullData);
        var shape = new Shape(shapeID);

        FreeNativeShapeDef(nativeShapeDef);

        return shape;
    }

    private unsafe static Interop.b3ShapeDef AllocNativeShapeDef(in ShapeDef shapeDef)
    {
        var materials = (Interop.b3SurfaceMaterial*) NativeMemory.Alloc(
			(nuint) (shapeDef.Materials.Length * Marshal.SizeOf<Interop.b3SurfaceMaterial>())
		);

        for (var i = 0; i < shapeDef.Materials.Length; i += 1)
        {
            materials[i] = shapeDef.Materials[i];
        }

        var unmanagedString = Utf8StringMarshaller.ConvertToUnmanaged(shapeDef.Name);

        return new Interop.b3ShapeDef
        {
            name = unmanagedString,
            userData = shapeDef.UserData,
            materials = materials,
            materialCount = shapeDef.Materials.Length,
            baseMaterial = shapeDef.BaseMaterial,
            density = shapeDef.Density,
            explosionScale = shapeDef.ExplosionScale,
            filter = shapeDef.Filter,
            enableCustomFiltering = shapeDef.EnableCustomFiltering,
            isSensor = shapeDef.IsSensor,
            enableSensorEvents = shapeDef.EnableSensorEvents,
            enableContactEvents = shapeDef.EnableContactEvents,
            enableHitEvents = shapeDef.EnableHitEvents,
            enablePreSolveEvents = shapeDef.EnablePreSolveEvents,
            invokeContactCreation = shapeDef.InvokeContactCreation,
            updateBodyMass = shapeDef.UpdateBodyMass,
            enableSpeculativeContact = shapeDef.EnableSpeculativeContact,
            internalValue = shapeDef.InternalValue
        };
    }

    private unsafe static void FreeNativeShapeDef(in Interop.b3ShapeDef nativeShapeDef)
    {
        NativeMemory.Free(nativeShapeDef.materials);
        Utf8StringMarshaller.Free(nativeShapeDef.name);
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
