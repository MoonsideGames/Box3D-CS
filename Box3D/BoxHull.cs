namespace Box3D;

// TODO: lifecycle?
public struct BoxHull
{
    internal Interop.b3BoxHull Hull;

    // TODO: don't expose interop data
    public readonly Interop.b3HullData Data => Hull.@base;

    public static BoxHull CreateBox(float hx, float hy, float hz)
    {
        return new BoxHull(Interop.b3MakeBoxHull(hx, hy, hz));
    }

    internal BoxHull(Interop.b3BoxHull hullData)
    {
        Hull = hullData;
    }
}
