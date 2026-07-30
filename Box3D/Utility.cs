using System.Numerics;

namespace Box3D;

// TODO: if we require .NET 10, we can use extension operators for conversions.
public static class Utility
{
    public static Interop.b3Vec3 ToBox3DVector(Vector3 vector)
    {
        return new Interop.b3Vec3
        {
            x = vector.X,
            y = vector.Y,
            z = vector.Z
        };
    }

    public static Vector3 ToVector3(Interop.b3Vec3 vec3)
    {
        return new Vector3(vec3.x, vec3.y, vec3.z);
    }

    public static Interop.b3Quat ToBox3DQuaternion(Quaternion q)
    {
        return new Interop.b3Quat
        {
            v = new Interop.b3Vec3
            {
                x = q.X,
                y = q.Y,
                z = q.Z
            },
            s = q.W
        };
    }

    public static Quaternion ToQuaternion(Interop.b3Quat quat)
    {
        return new Quaternion(ToVector3(quat.v), quat.s);
    }

    public static Transform ToTransform(Interop.b3Transform transform)
    {
        return new Transform(ToVector3(transform.p), ToQuaternion(transform.q));
    }
}
