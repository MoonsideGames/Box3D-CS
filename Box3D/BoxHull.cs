namespace Box3D;

// TODO: lifecycle?
public struct BoxHull
{
    // TODO: how to not expose this?
    internal Interop.b3BoxHull Hull;

    public static BoxHull CreateBox(float hx, float hy, float hz)
    {
        return new BoxHull(Interop.b3MakeBoxHull(hx, hy, hz));
    }

    internal BoxHull(Interop.b3BoxHull hullData)
    {
        Hull = hullData;
    }
}
