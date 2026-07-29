using System;
using System.Numerics;

namespace Box3D;

// Owns triangle mesh data.
// If a shape references this, the mesh must outlive it.
public unsafe class TriangleMesh
{
    public Interop.b3MeshData* MeshData;

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
}
