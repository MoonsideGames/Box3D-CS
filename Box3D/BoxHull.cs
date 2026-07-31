using System.Numerics;

namespace Box3D;

// TODO: lifecycle?
public struct BoxHull
{
    // TODO: how to not expose this?
    internal Interop.b3BoxHull Hull;

    public static BoxHull Create(float hx, float hy, float hz)
    {
        return new BoxHull(Interop.b3MakeBoxHull(hx, hy, hz));
    }

    public static BoxHull Create(float hx, float hy, float hz, Vector3 offset)
    {
        return new BoxHull(Interop.b3MakeOffsetBoxHull(hx, hy, hz, Utility.ToBox3DVector(offset)));
    }

    internal BoxHull(Interop.b3BoxHull hullData)
    {
        Hull = hullData;
    }
}
