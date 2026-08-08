using System.Numerics;
using System.Runtime.CompilerServices;

namespace Box3D;

// TODO: if we require .NET 10, we can use extension operators for conversions.
public static class Utility
{
    public const float QuakeUnitsToMetersConstant = 0.0265625f;

    public static Interop.b3Vec3 ToBox3DVector(Vector3 vector) => Unsafe.BitCast<Vector3, Interop.b3Vec3>(vector);
    public static Vector3 ToVector3(Interop.b3Vec3 vec3) => Unsafe.BitCast<Interop.b3Vec3, Vector3>(vec3);
    public static Interop.b3Quat ToBox3DQuaternion(Quaternion q) => Unsafe.BitCast<Quaternion, Interop.b3Quat>(q);
    public static Quaternion ToQuaternion(Interop.b3Quat quat) => Unsafe.BitCast<Interop.b3Quat, Quaternion>(quat);
    public static Transform ToTransform(Interop.b3Transform transform) => Unsafe.BitCast<Interop.b3Transform, Transform>(transform);
    public static Interop.b3Plane ToBox3DPlane(Plane plane) => Unsafe.BitCast<Plane, Interop.b3Plane>(plane);
    public static Plane ToPlane(Interop.b3Plane plane) => Unsafe.BitCast<Interop.b3Plane, Plane>(plane);
}
