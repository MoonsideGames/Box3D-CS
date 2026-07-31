using System;
using System.Numerics;

namespace Box3D;

// If a shape references this, the mesh must outlive it.
public unsafe class TriangleMesh
{
    // TODO: is it weird for this to be a pointer?
    // Box3D allocs the memory but it feels odd in C# semantics
    // to have to access the data through a pointer.
    internal Interop.b3MeshData* MeshData { get; private set; }

    public static TriangleMesh Create(
        ReadOnlySpan<Vector3> vertices,
        ReadOnlySpan<int> indices,
        bool identifyEdges = true,
        bool weldVertices = true,
        float weldTolerance = 0.005f)
    {
        fixed (Vector3* v = vertices)
        fixed (int* i = indices)
        {
            var def = new Interop.b3MeshDef
            {
                vertices = (Interop.b3Vec3*)v,
                indices = i,
                vertexCount = vertices.Length,
                triangleCount = indices.Length / 3,
                identifyEdges = identifyEdges,
                weldVertices = weldVertices,
                weldTolerance = weldTolerance
            };

            var mesh = Interop.b3CreateMesh(def, null, 0);
            return new TriangleMesh(mesh);
        }
    }

    internal TriangleMesh(Interop.b3MeshData* meshData)
    {
        MeshData = meshData;
    }

    public void Destroy()
    {
        if (MeshData == null)
        {
            return;
        }

        Interop.b3DestroyMesh((IntPtr) MeshData);

        MeshData = null;
    }
}
