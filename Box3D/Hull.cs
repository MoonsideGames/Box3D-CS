using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Box3D;

public unsafe struct Hull
{
    internal Interop.b3HullData* Data;

    public static Hull Create(ReadOnlySpan<Vector3> points, int maxVertices = 64)
    {
        return new Hull
        {
            Data = Interop.b3CreateHull(MemoryMarshal.Cast<Vector3, Interop.b3Vec3>(points), points.Length, maxVertices)
        };
    }

    public void Destroy()
    {
        if (Data == null) 
        {
            return;
        }

        Interop.b3DestroyHull((nint)Data);
        Data = null;
    }
}
