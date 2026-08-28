namespace GenerateBindings;

internal static class UserProvidedData
{
    internal enum PointerFunctionDataIntent
    {
        Unknown,
        IntPtr,
        Ref,
        Out,
        Array,
        OutArray,
        Pointer,
        In,
    }

    internal struct DelegateDefinition
    {
        public string ReturnType { get; set; }
        public (string, string)[] Parameters { get; set; }
    }

    internal static readonly Dictionary<(string, string), PointerFunctionDataIntent> PointerFunctionDataIntents = new()
    {
        { ("b3GetMillisecondsAndReset", "ticks"), PointerFunctionDataIntent.Ref }, // ../box3d/include/box3d/base.h:185:14
        { ("b3Hash", "data"), PointerFunctionDataIntent.Array }, // ../box3d/include/box3d/base.h:195:17
        { ("b3GetLengthAndNormalize", "length"), PointerFunctionDataIntent.Out }, // ../box3d/include/box3d/math_functions.h:292:18
        { ("b3GetAxisAngle", "radians"), PointerFunctionDataIntent.Out }, // ../box3d/include/box3d/math_functions.h:535:18
        { ("b3MakeQuatFromMatrix", "m"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/math_functions.h:557:15
        { ("b3MakeAABB", "points"), PointerFunctionDataIntent.Array }, // ../box3d/include/box3d/math_functions.h:953:18
        { ("b3DynamicTree_Destroy", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:22:13
        { ("b3DynamicTree_CreateProxy", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:25:12
        { ("b3DynamicTree_DestroyProxy", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:28:13
        { ("b3DynamicTree_MoveProxy", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:31:13
        { ("b3DynamicTree_EnlargeProxy", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:34:13
        { ("b3DynamicTree_SetCategoryBits", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:37:13
        { ("b3DynamicTree_GetCategoryBits", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:40:17
        { ("b3DynamicTree_Query", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:44:20
        { ("b3DynamicTree_QueryClosest", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:59:20
        { ("b3DynamicTree_QueryClosest", "minDistanceSqr"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:59:20
        { ("b3DynamicTree_RayCast", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:76:20
        { ("b3DynamicTree_RayCast", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:76:20
        { ("b3DynamicTree_BoxCast", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:82:20
        { ("b3DynamicTree_BoxCast", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:82:20
        { ("b3DynamicTree_GetHeight", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:86:12
        { ("b3DynamicTree_GetAreaRatio", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:89:14
        { ("b3DynamicTree_GetRootBounds", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:92:15
        { ("b3DynamicTree_GetProxyCount", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:95:12
        { ("b3DynamicTree_Rebuild", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:98:12
        { ("b3DynamicTree_GetByteCount", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:101:12
        { ("b3DynamicTree_Validate", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:104:13
        { ("b3DynamicTree_ValidateNoEnlarged", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:107:13
        { ("b3DynamicTree_Save", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:110:13
        { ("b3DynamicTree_GetUserData", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:116:20
        { ("b3DynamicTree_GetAABB", "tree"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:122:18
        { ("b3GetHullVertices", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:135:31
        { ("b3GetHullVertices", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:135:31
        { ("b3GetHullPoints", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:146:25
        { ("b3GetHullPoints", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:146:25
        { ("b3GetHullEdges", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:157:33
        { ("b3GetHullEdges", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:157:33
        { ("b3GetHullPlanes", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:168:26
        { ("b3GetHullPlanes", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:168:26
        { ("b3GetHullFaces", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:179:29
        { ("b3GetHullFaces", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:179:29
        { ("b3GetHullSoaVertices", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:192:24
        { ("b3GetHullSoaVertices", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:192:24
        { ("b3GetHullSoaNormals", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:205:24
        { ("b3GetHullSoaNormals", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:205:24
        { ("b3CreateCylinder", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:216:20
        { ("b3CreateCone", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:219:20
        { ("b3CreateRock", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:222:20
        { ("b3CreateHull", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:225:20
        { ("b3CreateHull", "points"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/collision.h:225:20
        { ("b3CloneHull", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:228:20
        { ("b3CloneHull", "hull"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/collision.h:228:20
        { ("b3CloneAndTransformHull", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:231:20
        { ("b3CloneAndTransformHull", "original"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:231:20
        { ("b3DestroyHull", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:234:13
        { ("b3ScaleBox", "halfWidths"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:266:13
        { ("b3ScaleBox", "transform"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:266:13
        { ("b3GetMeshNodes", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:276:29
        { ("b3GetMeshNodes", "mesh"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:276:29
        { ("b3GetMeshVertices", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:287:25
        { ("b3GetMeshVertices", "mesh"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:287:25
        { ("b3GetMeshTriangles", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:298:33
        { ("b3GetMeshTriangles", "mesh"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:298:33
        { ("b3GetMeshMaterialIndices", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:309:26
        { ("b3GetMeshMaterialIndices", "mesh"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:309:26
        { ("b3GetMeshFlags", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:320:26
        { ("b3GetMeshFlags", "mesh"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:320:26
        { ("b3CreateGridMesh", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:336:20
        { ("b3CreateWaveMesh", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:339:20
        { ("b3CreateTorusMesh", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:343:20
        { ("b3CreateBoxMesh", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:346:20
        { ("b3CreateHollowBoxMesh", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:349:20
        { ("b3CreatePlatformMesh", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:352:20
        { ("b3CreateMesh", "__return"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:355:20
        { ("b3CreateMesh", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/collision.h:355:20
        { ("b3CreateMesh", "degenerateTriangleIndices"), PointerFunctionDataIntent.OutArray }, // ../box3d/include/box3d/collision.h:355:20
        { ("b3DestroyMesh", "mesh"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:358:13
        { ("b3GetHeight", "mesh"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:361:12
        { ("b3GetHeightFieldCompressedHeights", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:371:27
        { ("b3GetHeightFieldCompressedHeights", "hf"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:371:27
        { ("b3GetHeightFieldMaterialIndices", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:382:26
        { ("b3GetHeightFieldMaterialIndices", "hf"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:382:26
        { ("b3GetHeightFieldFlags", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:393:26
        { ("b3GetHeightFieldFlags", "hf"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:393:26
        { ("b3CreateHeightField", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:404:27
        { ("b3CreateHeightField", "data"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:404:27
        { ("b3CreateGrid", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:407:27
        { ("b3CreateWave", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:410:27
        { ("b3DestroyHeightField", "heightField"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:414:13
        { ("b3DumpHeightData", "data"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:417:13
        { ("b3LoadHeightField", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:420:27
        { ("b3GetCompoundChild", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:430:21
        { ("b3QueryCompound", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:433:13
        { ("b3GetCompoundCapsule", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:436:26
        { ("b3GetCompoundHull", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:439:23
        { ("b3GetCompoundMesh", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:442:23
        { ("b3GetCompoundSphere", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:445:25
        { ("b3GetCompoundMaterials", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:448:33
        { ("b3GetCompoundMaterials", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:448:33
        { ("b3CreateCompound", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:451:24
        { ("b3CreateCompound", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:451:24
        { ("b3DestroyCompound", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:454:13
        { ("b3ConvertCompoundToBytes", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:458:17
        { ("b3ConvertCompoundToBytes", "compound"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:458:17
        { ("b3ConvertBytesToCompound", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:462:24
        { ("b3ConvertBytesToCompound", "bytes"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:462:24
        { ("b3ComputeSphereMass", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:472:19
        { ("b3ComputeCapsuleMass", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:475:19
        { ("b3ComputeHullMass", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:478:19
        { ("b3ComputeSphereAABB", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:481:15
        { ("b3ComputeCapsuleAABB", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:484:15
        { ("b3ComputeHullAABB", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:487:15
        { ("b3ComputeMeshAABB", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:490:15
        { ("b3ComputeHeightFieldAABB", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:493:15
        { ("b3ComputeCompoundAABB", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:496:15
        { ("b3IsValidRay", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:506:13
        { ("b3OverlapCapsule", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:509:13
        { ("b3OverlapCapsule", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:509:13
        { ("b3OverlapCompound", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:512:13
        { ("b3OverlapCompound", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:512:13
        { ("b3OverlapHeightField", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:515:13
        { ("b3OverlapHeightField", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:515:13
        { ("b3OverlapHull", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:518:13
        { ("b3OverlapHull", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:518:13
        { ("b3OverlapMesh", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:521:13
        { ("b3OverlapMesh", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:521:13
        { ("b3OverlapSphere", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:524:13
        { ("b3OverlapSphere", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:524:13
        { ("b3RayCastSphere", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:528:21
        { ("b3RayCastSphere", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:528:21
        { ("b3RayCastHollowSphere", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:532:21
        { ("b3RayCastHollowSphere", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:532:21
        { ("b3RayCastCapsule", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:536:21
        { ("b3RayCastCapsule", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:536:21
        { ("b3RayCastCompound", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:540:21
        { ("b3RayCastCompound", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:540:21
        { ("b3RayCastHull", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:544:21
        { ("b3RayCastHull", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:544:21
        { ("b3RayCastMesh", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:547:21
        { ("b3RayCastMesh", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:547:21
        { ("b3RayCastHeightField", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:550:21
        { ("b3RayCastHeightField", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:550:21
        { ("b3ShapeCastSphere", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:553:21
        { ("b3ShapeCastSphere", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:553:21
        { ("b3ShapeCastCapsule", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:556:21
        { ("b3ShapeCastCapsule", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:556:21
        { ("b3ShapeCastCompound", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:559:21
        { ("b3ShapeCastCompound", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:559:21
        { ("b3ShapeCastHull", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:562:21
        { ("b3ShapeCastHull", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:562:21
        { ("b3ShapeCastMesh", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:565:21
        { ("b3ShapeCastMesh", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:565:21
        { ("b3ShapeCastHeightField", "shape"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:568:21
        { ("b3ShapeCastHeightField", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:568:21
        { ("b3QueryMesh", "mesh"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:578:13
        { ("b3QueryHeightField", "heightField"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:585:13
        { ("b3ShapeDistance", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:591:25
        { ("b3ShapeDistance", "cache"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:591:25
        { ("b3ShapeDistance", "simplexes"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:591:25
        { ("b3ShapeCast", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:596:21
        { ("b3GetSweepTransform", "sweep"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:599:20
        { ("b3TimeOfImpact", "input"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:605:20
        { ("b3CollideSpheres", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:615:13
        { ("b3CollideSpheres", "sphereA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:615:13
        { ("b3CollideSpheres", "sphereB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:615:13
        { ("b3CollideCapsuleAndSphere", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:619:13
        { ("b3CollideCapsuleAndSphere", "capsuleA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:619:13
        { ("b3CollideCapsuleAndSphere", "sphereB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:619:13
        { ("b3CollideHullAndSphere", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:623:13
        { ("b3CollideHullAndSphere", "hullA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:623:13
        { ("b3CollideHullAndSphere", "sphereB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:623:13
        { ("b3CollideHullAndSphere", "cache"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:623:13
        { ("b3CollideCapsules", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:627:13
        { ("b3CollideCapsules", "capsuleA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:627:13
        { ("b3CollideCapsules", "capsuleB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:627:13
        { ("b3CollideHullAndCapsule", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:631:13
        { ("b3CollideHullAndCapsule", "hullA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:631:13
        { ("b3CollideHullAndCapsule", "capsuleB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:631:13
        { ("b3CollideHullAndCapsule", "cache"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:631:13
        { ("b3CollideHulls", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:635:13
        { ("b3CollideHulls", "hullA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:635:13
        { ("b3CollideHulls", "hullB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:635:13
        { ("b3CollideTriangleAndCapsule", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:639:13
        { ("b3CollideTriangleAndCapsule", "triangleA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:639:13
        { ("b3CollideTriangleAndCapsule", "capsuleB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:639:13
        { ("b3CollideTriangleAndCapsule", "cache"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:639:13
        { ("b3CollideTriangleAndHull", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:643:13
        { ("b3CollideTriangleAndHull", "hullB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:643:13
        { ("b3CollideTriangleAndSphere", "manifold"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:647:13
        { ("b3CollideTriangleAndSphere", "triangleA"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:647:13
        { ("b3CollideTriangleAndSphere", "sphereB"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/collision.h:647:13
        { ("b3SolvePlanes", "planes"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:661:28
        { ("b3ClipVector", "planes"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/collision.h:665:15
        { ("b3CreateWorld", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:35:18
        { ("b3World_Draw", "draw"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:56:13
        { ("b3World_OverlapShape", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:80:20
        { ("b3World_CastShape", "proxy"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:104:20
        { ("b3World_CastMover", "mover"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:118:14
        { ("b3World_CollideMover", "mover"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:123:13
        { ("b3World_Explode", "explosionDef"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:176:13
        { ("b3Recording_GetData", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:270:23
        { ("b3RecPlayer_DrawFrameQueries", "draw"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:424:13
        { ("b3CreateBody", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:487:17
        { ("b3Body_GetShapes", "shapeArray"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/box3d.h:743:12
        { ("b3Body_GetJoints", "jointArray"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:750:12
        { ("b3Body_GetContactData", "contactData"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:756:12
        { ("b3Body_GetClosestPoint", "result"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:763:14
        { ("b3Body_CastShape", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:770:25
        { ("b3Body_OverlapShape", "proxy"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:775:13
        { ("b3Body_CollideMover", "bodyPlanes"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:779:12
        { ("b3Body_CollideMover", "mover"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:779:12
        { ("b3CreateSphereShape", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:798:18
        { ("b3CreateSphereShape", "sphere"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:798:18
        { ("b3CreateCapsuleShape", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:803:18
        { ("b3CreateCapsuleShape", "capsule"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:803:18
        { ("b3CreateHullShape", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:808:18
        { ("b3CreateHullShape", "hull"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/box3d.h:808:18
        { ("b3CreateTransformedHullShape", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:814:18
        { ("b3CreateTransformedHullShape", "hull"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:814:18
        { ("b3CreateMeshShape", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:822:18
        { ("b3CreateMeshShape", "mesh"), PointerFunctionDataIntent.Pointer }, // ../box3d/include/box3d/box3d.h:822:18
        { ("b3CreateHeightFieldShape", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:829:18
        { ("b3CreateHeightFieldShape", "heightField"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:829:18
        { ("b3CreateBakedCompoundShape", "def"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:834:18
        { ("b3CreateBakedCompoundShape", "compound"), PointerFunctionDataIntent.In }, // ../box3d/include/box3d/box3d.h:834:18
        { ("b3Shape_GetHull", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:954:26
        { ("b3Shape_GetHeightField", "__return"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:960:33
        { ("b3Shape_SetSphere", "sphere"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:965:13
        { ("b3Shape_SetCapsule", "capsule"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:970:13
        { ("b3Shape_SetHull", "hull"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:975:13
        { ("b3Shape_SetMesh", "meshData"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:980:13
        { ("b3Shape_GetContactData", "contactData"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:989:12
        { ("b3Shape_GetSensorData", "visitorIds"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1004:12
        { ("b3Joint_GetConstraintTuning", "hertz"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1098:13
        { ("b3Joint_GetConstraintTuning", "dampingRatio"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1098:13
        { ("b3CreateParallelJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1120:18
        { ("b3CreateDistanceJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1150:18
        { ("b3DistanceJoint_GetSpringForceRange", "lowerForce"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1170:13
        { ("b3DistanceJoint_GetSpringForceRange", "upperForce"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1170:13
        { ("b3CreateMotorJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1240:18
        { ("b3CreateFilterJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1315:18
        { ("b3CreatePrismaticJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1330:18
        { ("b3CreateRevoluteJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1412:18
        { ("b3CreateSphericalJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1490:18
        { ("b3CreateWeldJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1585:18
        { ("b3CreateWheelJoint", "def"), PointerFunctionDataIntent.Unknown }, // ../box3d/include/box3d/box3d.h:1625:18
    };

    internal static readonly Dictionary<string, string> ReturnedArrayCountParamNames = new()
    {

    };

    // FIXME: In double-precision mode, these types won't be correct
    // FIXME: these are anonymous function pointers. what if multiple structs define field functions with the same name?
    internal static readonly Dictionary<string, DelegateDefinition> DelegateDefinitions = new()
    {
        {
            "DrawShapeFcn",
            new DelegateDefinition
            {
                   ReturnType = "void",
                   Parameters = [
                       ("IntPtr", "userShape"),
                       ("b3Transform", "transform"),
                       ("b3HexColor", "color"),
                       ("IntPtr", "context")
                   ]
            }
        },
        {
            "DrawSegmentFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3Vec3", "p1"),
                    ("b3Vec3", "p2"),
                    ("b3HexColor", "color"),
                    ("IntPtr", "context")
                ]
            }
        },
        {
            "DrawTransformFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3Transform", "transform"),
                    ("IntPtr", "context")
                ]
            }
        },
        {
            "DrawPointFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3Vec3", "p"),
                    ("float", "size"),
                    ("b3HexColor", "color"),
                    ("IntPtr", "context")
                ]
            }
        },
        {
            "DrawSphereFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3Vec3", "p"),
                    ("float", "radius"),
                    ("b3HexColor", "color"),
                    ("float", "alpha"),
                    ("IntPtr", "context")
                ]
            }
        },
        {
            "DrawCapsuleFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3Vec3", "p1"),
                    ("b3Vec3", "p2"),
                    ("float", "radius"),
                    ("b3HexColor", "color"),
                    ("float", "alpha"),
                    ("IntPtr", "context")
                ]
            }
        },
        {
            "DrawBoundsFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3AABB", "aabb"),
                    ("b3HexColor", "color"),
                    ("IntPtr", "context")
                ]
            }
        },
        {
            "DrawBoxFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3Vec3", "extents"),
                    ("b3Transform", "transform"),
                    ("b3HexColor", "color"),
                    ("IntPtr", "context")
                ]
            }
        },
        {
            "DrawStringFcn",
            new DelegateDefinition
            {
                ReturnType = "void",
                Parameters = [
                    ("b3Vec3", "p"),
                    ("byte*", "s"),
                    ("b3HexColor", "color"),
                    ("IntPtr", "context")
                ]
            }
        }
    };

    internal static readonly Dictionary<string, string[]> FlagEnumDefinitions = new()
    {
        {
            "b3TreeNodeFlags", [
                "b3_allocatedNode = 0x0001",
                "b3_enlargedNode = 0x0002",
                "b3_leafNode = 0x0004",
            ]
        }, // ../box3d/include/box3d/types.h:1681:3
        {
            "b3MeshEdgeFlags", [
                "b3_concaveEdge1 = 0x01",
                "b3_concaveEdge2 = 0x02",
                "b3_concaveEdge3 = 0x04",

                "b3_inverseConcaveEdge1 = 0x10",
                "b3_inverseConcaveEdge2 = 0x20",
                "b3_inverseConcaveEdge3 = 0x40",


	            "b3_allConcaveEdges = b3_concaveEdge1 | b3_concaveEdge2 | b3_concaveEdge3",

	            "b3_flatEdge1 = b3_concaveEdge1 | b3_inverseConcaveEdge1",
	            "b3_flatEdge2 = b3_concaveEdge2 | b3_inverseConcaveEdge2",
	            "b3_flatEdge3 = b3_concaveEdge3 | b3_inverseConcaveEdge3",

	            "b3_allFlatEdges = b3_flatEdge1 | b3_flatEdge2 | b3_flatEdge3",
            ]
        }, // ../box3d/include/box3d/types.h:2121:3
    };

    internal static readonly HashSet<string> FlagTypes =
    [
       "b3TreeNodeFlags",
       "b3MeshEdgeFlags"
    ];

    internal static readonly string[] DeniedTypes = [
        // These are declared as B3_INLINE, not in the public API
        "b3GetMeshNodes",
        "b3GetMeshVertices",
        "b3GetMeshTriangles",
        "b3GetMeshMaterialIndices",
        "b3GetMeshFlags"
    ];
}
