// NOTE: This file is auto-generated.
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.CompilerServices;
using System.Text;

namespace box3d;

public static unsafe partial class Interop
{
    // Custom marshaller for library-owned strings returned by the library.
    [CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedOut, typeof(LibraryOwnedStringMarshaller))]
    public static unsafe class LibraryOwnedStringMarshaller
    {
        /// <summary>
        /// Converts an unmanaged string to a managed version.
        /// </summary>
        /// <returns>A managed string.</returns>
        public static string ConvertToManaged(byte* unmanaged)
            => Marshal.PtrToStringUTF8((IntPtr)unmanaged);
    }

    // Taken from https://github.com/ppy/SDL3-CS
    // C# bools are not blittable, so we need this workaround
    public readonly record struct box3dbool
    {
        private readonly byte value;

        internal const byte FALSE_VALUE = 0;
        internal const byte TRUE_VALUE = 1;

        internal box3dbool(byte value)
        {
            this.value = value;
        }

        public static implicit operator bool(box3dbool b)
        {
            return b.value != FALSE_VALUE;
        }

        public static implicit operator box3dbool(bool b)
        {
            return new box3dbool(b ? TRUE_VALUE : FALSE_VALUE);
        }

        public bool Equals(box3dbool other)
        {
            return other.value == value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    private const string nativeLibName = "box3d";

    // ../box3d/include/box3d/base.h

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SetAllocator(IntPtr allocFcn, IntPtr freeFcn);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3GetByteCount();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SetAssertFcn(IntPtr assertFcn);

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3InternalAssert(string condition, string fileName, int lineNumber);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SetLogFcn(IntPtr logFcn);

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Version
    {
        public int major;
        public int minor;
        public int revision;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Version b3GetVersion();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsDoublePrecision();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong b3GetTicks();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3GetMilliseconds(ulong ticks);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3GetMillisecondsAndReset(ref ulong ticks);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Yield();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Sleep(int milliseconds);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint b3Hash(uint hash, Span<byte> data, int count);

    // ../box3d/include/box3d/math_functions.h

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Vec2
    {
        public float x;
        public float y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Vec3
    {
        public float x;
        public float y;
        public float z;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CosSin
    {
        public float cosine;
        public float sine;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Quat
    {
        public b3Vec3 v;
        public float s;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Transform
    {
        public b3Vec3 p;
        public b3Quat q;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Matrix3
    {
        public b3Vec3 cx;
        public b3Vec3 cy;
        public b3Vec3 cz;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3AABB
    {
        public b3Vec3 lowerBound;
        public b3Vec3 upperBound;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Plane
    {
        public b3Vec3 normal;
        public float offset;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3MinInt(int a, int b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3MaxInt(int a, int b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3ClampInt(int a, int lower, int upper);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3AbsFloat(float a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MinFloat(float a, float b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MaxFloat(float a, float b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3ClampFloat(float a, float lower, float upper);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3LerpFloat(float a, float b, float alpha);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Atan2(float y, float x);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CosSin b3ComputeCosSin(float radians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Sin(float radians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Cos(float radians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3UnwindAngle(float radians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Add(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Sub(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Mul(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Neg(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Dot(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Length(b3Vec3 v);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3LengthSquared(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Distance(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceSquared(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Normalize(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3GetLengthAndNormalize(out float length, b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Perp(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsNormalized(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3MulAdd(b3Vec3 a, float s, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3MulSub(b3Vec3 a, float s, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3MulSV(float s, b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Cross(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Lerp(b3Vec3 a, b3Vec3 b, float alpha);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Blend2(float s, b3Vec3 a, float t, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Abs(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Sign(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Min(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Max(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Clamp(b3Vec3 a, b3Vec3 lower, b3Vec3 upper);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3SafeScale(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsNormalizedQuat(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3RotateVector(b3Quat q, b3Vec3 v);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3InvRotateVector(b3Quat q, b3Vec3 v);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DotQuat(b3Quat a, b3Quat b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3MulQuat(b3Quat q1, b3Quat q2);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3InvMulQuat(b3Quat q1, b3Quat q2);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3Conjugate(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3NegateQuat(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3NormalizeQuat(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3MakeQuatFromAxisAngle(b3Vec3 axis, float radians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3GetAxisAngle(out float radians, b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3GetQuatAngle(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3MakeQuatFromMatrix(in b3Matrix3 m);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3ComputeQuatBetweenUnitVectors(b3Vec3 v1, b3Vec3 v2);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3GetTwistAngle(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3GetSwingAngle(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3NLerp(b3Quat q1, b3Quat q2, float alpha);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3MulTransforms(b3Transform a, b3Transform b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3InvMulTransforms(b3Transform a, b3Transform b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3InvertTransform(b3Transform t);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3TransformPoint(b3Transform t, b3Vec3 v);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3InvTransformPoint(b3Transform t, b3Vec3 v);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3ToPos(b3Vec3 v);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3ToVec3(b3Vec3 p);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RoundDownFloat(double x);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RoundUpFloat(double x);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3SubPos(b3Vec3 a, b3Vec3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3OffsetPos(b3Vec3 p, b3Vec3 d);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3LerpPosition(b3Vec3 a, b3Vec3 b, float t);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3TransformWorldPoint(b3Transform t, b3Vec3 p);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3InvTransformWorldPoint(b3Transform t, b3Vec3 p);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3InvMulWorldTransforms(b3Transform A, b3Transform B);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3MulWorldTransforms(b3Transform A, b3Transform B);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3ToRelativeTransform(b3Transform t, b3Vec3 @base);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3MakeWorldTransform(b3Transform t);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3OffsetAABB(b3AABB localBox, b3Vec3 origin);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Det(b3Matrix3 m);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3MulMV(b3Matrix3 m, b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3NegateMat3(b3Matrix3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3AddMM(b3Matrix3 a, b3Matrix3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3SubMM(b3Matrix3 a, b3Matrix3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3MulSM(float s, b3Matrix3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3MulMM(b3Matrix3 a, b3Matrix3 b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3Transpose(b3Matrix3 m);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3InvertMatrix(b3Matrix3 m);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Solve3(b3Matrix3 m, b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3InvertT(b3Matrix3 m);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3AbsMatrix3(b3Matrix3 m);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3MakeMatrixFromQuat(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3Steiner(float mass, b3Vec3 origin);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3MakeAABB(Span<b3Vec3> points, int count, float radius);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3AABB_Contains(b3AABB a, b3AABB b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3AABB_Area(b3AABB a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3AABB_Center(b3AABB a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3AABB_Extents(b3AABB a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3AABB_Union(b3AABB a, b3AABB b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3AABB_Inflate(b3AABB a, float extension);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3AABB_Overlaps(b3AABB a, b3AABB b);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3AABB_Transform(b3Transform transform, b3AABB a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3ClosestPointToAABB(b3Vec3 point, b3AABB a);

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SegmentDistanceResult
    {
        public b3Vec3 point1;
        public float fraction1;
        public b3Vec3 point2;
        public float fraction2;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3PointToSegmentDistance(b3Vec3 a, b3Vec3 b, b3Vec3 q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3SegmentDistanceResult b3LineDistance(b3Vec3 p1, b3Vec3 d1, b3Vec3 p2, b3Vec3 d2);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3SegmentDistanceResult b3SegmentDistance(b3Vec3 p1, b3Vec3 q1, b3Vec3 p2, b3Vec3 q2);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidFloat(float a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidVec3(b3Vec3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidQuat(b3Quat q);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidTransform(b3Transform a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidMatrix3(b3Matrix3 a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidAABB(b3AABB a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsBoundedAABB(b3AABB a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsSaneAABB(b3AABB a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidPlane(b3Plane a);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidPosition(b3Vec3 p);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidWorldTransform(b3Transform t);

    // ../box3d/include/box3d/constants.h

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SetLengthUnitsPerMeter(float lengthUnits);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3GetLengthUnitsPerMeter();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SetStallThreshold(float seconds);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3GetStallThreshold();

    // ../box3d/include/box3d/id.h

    [StructLayout(LayoutKind.Sequential)]
    public struct b3WorldId
    {
        public ushort index1;
        public ushort generation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BodyId
    {
        public int index1;
        public ushort world0;
        public ushort generation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ShapeId
    {
        public int index1;
        public ushort world0;
        public ushort generation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3JointId
    {
        public int index1;
        public ushort world0;
        public ushort generation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ContactId
    {
        public int index1;
        public ushort world0;
        public short padding;
        public uint generation;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint b3StoreWorldId(b3WorldId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WorldId b3LoadWorldId(uint x);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong b3StoreBodyId(b3BodyId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyId b3LoadBodyId(ulong x);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong b3StoreShapeId(b3ShapeId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3LoadShapeId(ulong x);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong b3StoreJointId(b3JointId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3LoadJointId(ulong x);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3StoreContactId(b3ContactId id, [Out] uint[] values);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ContactId b3LoadContactId([Out] uint[] values);

    // ../box3d/include/box3d/types.h

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Capacity
    {
        public int staticShapeCount;
        public int dynamicShapeCount;
        public int staticBodyCount;
        public int dynamicBodyCount;
        public int contactCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3WorldDef
    {
        public b3Vec3 gravity;
        public float restitutionThreshold;
        public float hitEventThreshold;
        public float contactHertz;
        public float contactDampingRatio;
        public float contactSpeed;
        public float maximumLinearSpeed;
        public IntPtr frictionCallback; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr restitutionCallback; // WARN_ANONYMOUS_FUNCTION_POINTER
        public box3dbool enableSleep;
        public box3dbool enableContinuous;
        public uint workerCount;
        public IntPtr enqueueTask; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr finishTask; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr userTaskContext;
        public IntPtr userData;
        public IntPtr createDebugShape; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr destroyDebugShape; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr userDebugShapeContext;
        public b3Capacity capacity;
        public int internalValue;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WorldDef b3DefaultWorldDef();

    public enum b3BodyType
    {
        b3_staticBody = 0,
        b3_kinematicBody = 1,
        b3_dynamicBody = 2,
        b3_bodyTypeCount = 3,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3MotionLocks
    {
        public box3dbool linearX;
        public box3dbool linearY;
        public box3dbool linearZ;
        public box3dbool angularX;
        public box3dbool angularY;
        public box3dbool angularZ;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BodyDef
    {
        public b3BodyType type;
        public b3Vec3 position;
        public b3Quat rotation;
        public b3Vec3 linearVelocity;
        public b3Vec3 angularVelocity;
        public float linearDamping;
        public float angularDamping;
        public float gravityScale;
        public float sleepThreshold;
        public byte* name;
        public IntPtr userData;
        public b3MotionLocks motionLocks;
        public box3dbool enableSleep;
        public box3dbool isAwake;
        public box3dbool isBullet;
        public box3dbool isEnabled;
        public box3dbool allowFastRotation;
        public box3dbool enableContactRecycling;
        public int internalValue;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyDef b3DefaultBodyDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Filter
    {
        public ulong categoryBits;
        public ulong maskBits;
        public int groupIndex;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Filter b3DefaultFilter();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SurfaceMaterial
    {
        public float friction;
        public float restitution;
        public float rollingResistance;
        public b3Vec3 tangentVelocity;
        public ulong userMaterialId;
        public uint customColor;
        public uint padding;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3SurfaceMaterial b3DefaultSurfaceMaterial();

    public enum b3ShapeType
    {
        b3_capsuleShape = 0,
        b3_compoundShape = 1,
        b3_heightShape = 2,
        b3_hullShape = 3,
        b3_meshShape = 4,
        b3_sphereShape = 5,
        b3_shapeTypeCount = 6,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ShapeDef
    {
        public byte* name;
        public IntPtr userData;
        public b3SurfaceMaterial* materials;
        public int materialCount;
        public b3SurfaceMaterial baseMaterial;
        public float density;
        public float explosionScale;
        public b3Filter filter;
        public box3dbool enableCustomFiltering;
        public box3dbool isSensor;
        public box3dbool enableSensorEvents;
        public box3dbool enableContactEvents;
        public box3dbool enableHitEvents;
        public box3dbool enablePreSolveEvents;
        public box3dbool invokeContactCreation;
        public box3dbool updateBodyMass;
        public box3dbool enableSpeculativeContact;
        public int internalValue;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeDef b3DefaultShapeDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Profile
    {
        public float step;
        public float pairs;
        public float collide;
        public float solve;
        public float solverSetup;
        public float constraints;
        public float prepareConstraints;
        public float integrateVelocities;
        public float warmStart;
        public float solveImpulses;
        public float integratePositions;
        public float relaxImpulses;
        public float applyRestitution;
        public float storeImpulses;
        public float splitIslands;
        public float transforms;
        public float sensorHits;
        public float jointEvents;
        public float hitEvents;
        public float refit;
        public float bullets;
        public float sleepIslands;
        public float sensors;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Counters
    {
        public int bodyCount;
        public int shapeCount;
        public int contactCount;
        public int jointCount;
        public int islandCount;
        public int stackUsed;
        public int arenaCapacity;
        public int staticTreeHeight;
        public int treeHeight;
        public int satCallCount;
        public int satCacheHitCount;
        public int byteCount;
        public int taskCount;
        public fixed int colorCounts[24];
        public fixed int manifoldCounts[8];
        public int awakeContactCount;
        public int recycledContactCount;
        public int distanceIterations;
        public int pushBackIterations;
        public int rootIterations;
    }

    public enum b3JointType
    {
        b3_parallelJoint = 0,
        b3_distanceJoint = 1,
        b3_filterJoint = 2,
        b3_motorJoint = 3,
        b3_prismaticJoint = 4,
        b3_revoluteJoint = 5,
        b3_sphericalJoint = 6,
        b3_weldJoint = 7,
        b3_wheelJoint = 8,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3JointDef
    {
        public IntPtr userData;
        public b3BodyId bodyIdA;
        public b3BodyId bodyIdB;
        public b3Transform localFrameA;
        public b3Transform localFrameB;
        public float forceThreshold;
        public float torqueThreshold;
        public float constraintHertz;
        public float constraintDampingRatio;
        public float drawScale;
        public box3dbool collideConnected;
        public int internalValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3DistanceJointDef
    {
        public b3JointDef @base;
        public float length;
        public box3dbool enableSpring;
        public float lowerSpringForce;
        public float upperSpringForce;
        public float hertz;
        public float dampingRatio;
        public box3dbool enableLimit;
        public float minLength;
        public float maxLength;
        public box3dbool enableMotor;
        public float maxMotorForce;
        public float motorSpeed;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3DistanceJointDef b3DefaultDistanceJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3MotorJointDef
    {
        public b3JointDef @base;
        public b3Vec3 linearVelocity;
        public float maxVelocityForce;
        public b3Vec3 angularVelocity;
        public float maxVelocityTorque;
        public float linearHertz;
        public float linearDampingRatio;
        public float maxSpringForce;
        public float angularHertz;
        public float angularDampingRatio;
        public float maxSpringTorque;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3MotorJointDef b3DefaultMotorJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3FilterJointDef
    {
        public b3JointDef @base;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3FilterJointDef b3DefaultFilterJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ParallelJointDef
    {
        public b3JointDef @base;
        public float hertz;
        public float dampingRatio;
        public float maxTorque;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ParallelJointDef b3DefaultParallelJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3PrismaticJointDef
    {
        public b3JointDef @base;
        public box3dbool enableSpring;
        public float hertz;
        public float dampingRatio;
        public float targetTranslation;
        public box3dbool enableLimit;
        public float lowerTranslation;
        public float upperTranslation;
        public box3dbool enableMotor;
        public float maxMotorForce;
        public float motorSpeed;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3PrismaticJointDef b3DefaultPrismaticJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3RevoluteJointDef
    {
        public b3JointDef @base;
        public float targetAngle;
        public box3dbool enableSpring;
        public float hertz;
        public float dampingRatio;
        public box3dbool enableLimit;
        public float lowerAngle;
        public float upperAngle;
        public box3dbool enableMotor;
        public float maxMotorTorque;
        public float motorSpeed;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3RevoluteJointDef b3DefaultRevoluteJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SphericalJointDef
    {
        public b3JointDef @base;
        public box3dbool enableSpring;
        public float hertz;
        public float dampingRatio;
        public b3Quat targetRotation;
        public box3dbool enableConeLimit;
        public float coneAngle;
        public box3dbool enableTwistLimit;
        public float lowerTwistAngle;
        public float upperTwistAngle;
        public box3dbool enableMotor;
        public float maxMotorTorque;
        public b3Vec3 motorVelocity;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3SphericalJointDef b3DefaultSphericalJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3WeldJointDef
    {
        public b3JointDef @base;
        public float linearHertz;
        public float angularHertz;
        public float linearDampingRatio;
        public float angularDampingRatio;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WeldJointDef b3DefaultWeldJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3WheelJointDef
    {
        public b3JointDef @base;
        public box3dbool enableSuspensionSpring;
        public float suspensionHertz;
        public float suspensionDampingRatio;
        public box3dbool enableSuspensionLimit;
        public float lowerSuspensionLimit;
        public float upperSuspensionLimit;
        public box3dbool enableSpinMotor;
        public float maxSpinTorque;
        public float spinSpeed;
        public box3dbool enableSteering;
        public float steeringHertz;
        public float steeringDampingRatio;
        public float targetSteeringAngle;
        public float maxSteeringTorque;
        public box3dbool enableSteeringLimit;
        public float lowerSteeringLimit;
        public float upperSteeringLimit;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WheelJointDef b3DefaultWheelJointDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ExplosionDef
    {
        public ulong maskBits;
        public b3Vec3 position;
        public float radius;
        public float falloff;
        public float impulsePerArea;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ExplosionDef b3DefaultExplosionDef();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SensorBeginTouchEvent
    {
        public b3ShapeId sensorShapeId;
        public b3ShapeId visitorShapeId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SensorEndTouchEvent
    {
        public b3ShapeId sensorShapeId;
        public b3ShapeId visitorShapeId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SensorEvents
    {
        public b3SensorBeginTouchEvent* beginEvents;
        public b3SensorEndTouchEvent* endEvents;
        public int beginCount;
        public int endCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ContactBeginTouchEvent
    {
        public b3ShapeId shapeIdA;
        public b3ShapeId shapeIdB;
        public b3ContactId contactId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ContactEndTouchEvent
    {
        public b3ShapeId shapeIdA;
        public b3ShapeId shapeIdB;
        public b3ContactId contactId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ContactHitEvent
    {
        public b3ShapeId shapeIdA;
        public b3ShapeId shapeIdB;
        public b3ContactId contactId;
        public b3Vec3 point;
        public b3Vec3 normal;
        public float approachSpeed;
        public ulong userMaterialIdA;
        public ulong userMaterialIdB;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ContactEvents
    {
        public b3ContactBeginTouchEvent* beginEvents;
        public b3ContactEndTouchEvent* endEvents;
        public b3ContactHitEvent* hitEvents;
        public int beginCount;
        public int endCount;
        public int hitCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BodyMoveEvent
    {
        public IntPtr userData;
        public b3Transform transform;
        public b3BodyId bodyId;
        public box3dbool fellAsleep;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BodyEvents
    {
        public b3BodyMoveEvent* moveEvents;
        public int moveCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3JointEvent
    {
        public b3JointId jointId;
        public IntPtr userData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3JointEvents
    {
        public b3JointEvent* jointEvents;
        public int count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ContactData
    {
        public b3ContactId contactId;
        public b3ShapeId shapeIdA;
        public b3ShapeId shapeIdB;
        public b3Manifold* manifolds;
        public int manifoldCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3QueryFilter
    {
        public ulong categoryBits;
        public ulong maskBits;
        public ulong id;
        public byte* name;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3QueryFilter b3DefaultQueryFilter();

    [StructLayout(LayoutKind.Sequential)]
    public struct b3RayCastInput
    {
        public b3Vec3 origin;
        public b3Vec3 translation;
        public float maxFraction;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3RayResult
    {
        public b3ShapeId shapeId;
        public b3Vec3 point;
        public b3Vec3 normal;
        public ulong userMaterialId;
        public float fraction;
        public int triangleIndex;
        public int childIndex;
        public int nodeVisits;
        public int leafVisits;
        public box3dbool hit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ShapeProxy
    {
        public b3Vec3* points;
        public int count;
        public float radius;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ShapeCastInput
    {
        public b3ShapeProxy proxy;
        public b3Vec3 translation;
        public float maxFraction;
        public box3dbool canEncroach;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BoxCastInput
    {
        public b3AABB box;
        public b3Vec3 translation;
        public float maxFraction;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CastOutput
    {
        public b3Vec3 normal;
        public b3Vec3 point;
        public float fraction;
        public int iterations;
        public int triangleIndex;
        public int childIndex;
        public int materialIndex;
        public box3dbool hit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BodyCastResult
    {
        public b3ShapeId shapeId;
        public b3Vec3 point;
        public b3Vec3 normal;
        public float fraction;
        public int triangleIndex;
        public ulong userMaterialId;
        public int iterations;
        public box3dbool hit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SimplexCache
    {
        public float metric;
        public ushort count;
        public fixed byte indexA[4];
        public fixed byte indexB[4];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ShapeCastPairInput
    {
        public b3ShapeProxy proxyA;
        public b3ShapeProxy proxyB;
        public b3Transform transform;
        public b3Vec3 translationB;
        public float maxFraction;
        public box3dbool canEncroach;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3DistanceInput
    {
        public b3ShapeProxy proxyA;
        public b3ShapeProxy proxyB;
        public b3Transform transform;
        public box3dbool useRadii;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3DistanceOutput
    {
        public b3Vec3 pointA;
        public b3Vec3 pointB;
        public b3Vec3 normal;
        public float distance;
        public int iterations;
        public int simplexCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3SimplexVertex
    {
        public b3Vec3 wA;
        public b3Vec3 wB;
        public b3Vec3 w;
        public float a;
        public int indexA;
        public int indexB;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Simplex
    {
        public b3SimplexVertex vertices0;
        public b3SimplexVertex vertices1;
        public b3SimplexVertex vertices2;
        public b3SimplexVertex vertices3;
        public int count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Sweep
    {
        public b3Vec3 localCenter;
        public b3Vec3 c1;
        public b3Vec3 c2;
        public b3Quat q1;
        public b3Quat q2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3TOIInput
    {
        public b3ShapeProxy proxyA;
        public b3ShapeProxy proxyB;
        public b3Sweep sweepA;
        public b3Sweep sweepB;
        public float maxFraction;
    }

    public enum b3TOIState
    {
        b3_toiStateUnknown = 0,
        b3_toiStateFailed = 1,
        b3_toiStateOverlapped = 2,
        b3_toiStateHit = 3,
        b3_toiStateSeparated = 4,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3TOIOutput
    {
        public b3TOIState state;
        public b3Vec3 point;
        public b3Vec3 normal;
        public float fraction;
        public float distance;
        public int distanceIterations;
        public int pushBackIterations;
        public int rootIterations;
        public box3dbool usedFallback;
    }

    public enum b3TreeNodeFlags
    {
        b3_allocatedNode = 1,
        b3_enlargedNode = 2,
        b3_leafNode = 4,
    }

    [Flags]
    public enum b3TreeNodeFlags : b3TreeNodeFlags
    {
        b3_allocatedNode = 0x0001,
        b3_enlargedNode = 0x0002,
        b3_leafNode = 0x0004,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3TreeNodeChildren
    {
        public int child1;
        public int child2;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct b3TreeNode
    {
        [FieldOffset(0)]
        public b3AABB aabb;
        [FieldOffset(24)]
        public ulong categoryBits;
        [FieldOffset(32)]
        public b3TreeNodeChildren __children;
        [FieldOffset(32)]
        public ulong __userData;
        [FieldOffset(40)]
        public int __parent;
        [FieldOffset(40)]
        public int __next;
        [FieldOffset(44)]
        public ushort height;
        [FieldOffset(46)]
        public ushort flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3DynamicTree
    {
        public ulong version;
        public b3TreeNode* nodes;
        public int root;
        public int nodeCount;
        public int nodeCapacity;
        public int proxyCount;
        public int freeList;
        public int* leafIndices;
        public b3AABB* leafBoxes;
        public b3Vec3* leafCenters;
        public int* binIndices;
        public int rebuildCapacity;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3TreeStats
    {
        public int nodeVisits;
        public int leafVisits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3PlaneResult
    {
        public b3Plane plane;
        public b3Vec3 point;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CollisionPlane
    {
        public b3Plane plane;
        public float pushLimit;
        public float push;
        public box3dbool clipVelocity;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3PlaneSolverResult
    {
        public b3Vec3 delta;
        public int iterationCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BodyPlaneResult
    {
        public b3ShapeId shapeId;
        public b3PlaneResult result;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3MassData
    {
        public float mass;
        public b3Vec3 center;
        public b3Matrix3 inertia;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Sphere
    {
        public b3Vec3 center;
        public float radius;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Capsule
    {
        public b3Vec3 center1;
        public b3Vec3 center2;
        public float radius;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3HullVertex
    {
        public byte edge;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3HullHalfEdge
    {
        public byte next;
        public byte twin;
        public byte origin;
        public byte face;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3HullFace
    {
        public byte edge;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3HullData
    {
        public ulong version;
        public int byteCount;
        public uint hash;
        public b3AABB aabb;
        public float surfaceArea;
        public float volume;
        public float innerRadius;
        public b3Vec3 center;
        public b3Matrix3 centralInertia;
        public int vertexCount;
        public int vertexOffset;
        public int pointOffset;
        public int edgeCount;
        public int edgeOffset;
        public int faceCount;
        public int planeOffset;
        public int faceOffset;
        public int soaVertexOffset;
        public int soaNormalOffset;
        public int padding;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3BoxHull
    {
        public b3HullData @base;
        public b3HullVertex boxVertices0;
        public b3HullVertex boxVertices1;
        public b3HullVertex boxVertices2;
        public b3HullVertex boxVertices3;
        public b3HullVertex boxVertices4;
        public b3HullVertex boxVertices5;
        public b3HullVertex boxVertices6;
        public b3HullVertex boxVertices7;
        public b3Vec3 boxPoints0;
        public b3Vec3 boxPoints1;
        public b3Vec3 boxPoints2;
        public b3Vec3 boxPoints3;
        public b3Vec3 boxPoints4;
        public b3Vec3 boxPoints5;
        public b3Vec3 boxPoints6;
        public b3Vec3 boxPoints7;
        public b3HullHalfEdge boxEdges0;
        public b3HullHalfEdge boxEdges1;
        public b3HullHalfEdge boxEdges2;
        public b3HullHalfEdge boxEdges3;
        public b3HullHalfEdge boxEdges4;
        public b3HullHalfEdge boxEdges5;
        public b3HullHalfEdge boxEdges6;
        public b3HullHalfEdge boxEdges7;
        public b3HullHalfEdge boxEdges8;
        public b3HullHalfEdge boxEdges9;
        public b3HullHalfEdge boxEdges10;
        public b3HullHalfEdge boxEdges11;
        public b3HullHalfEdge boxEdges12;
        public b3HullHalfEdge boxEdges13;
        public b3HullHalfEdge boxEdges14;
        public b3HullHalfEdge boxEdges15;
        public b3HullHalfEdge boxEdges16;
        public b3HullHalfEdge boxEdges17;
        public b3HullHalfEdge boxEdges18;
        public b3HullHalfEdge boxEdges19;
        public b3HullHalfEdge boxEdges20;
        public b3HullHalfEdge boxEdges21;
        public b3HullHalfEdge boxEdges22;
        public b3HullHalfEdge boxEdges23;
        public b3Plane boxPlanes0;
        public b3Plane boxPlanes1;
        public b3Plane boxPlanes2;
        public b3Plane boxPlanes3;
        public b3Plane boxPlanes4;
        public b3Plane boxPlanes5;
        public b3HullFace boxFaces0;
        public b3HullFace boxFaces1;
        public b3HullFace boxFaces2;
        public b3HullFace boxFaces3;
        public b3HullFace boxFaces4;
        public b3HullFace boxFaces5;
        public fixed byte padding[10];
        public fixed float vx[8];
        public fixed float vy[8];
        public fixed float vz[8];
        public fixed float nx[8];
        public fixed float ny[8];
        public fixed float nz[8];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3MeshDef
    {
        public b3Vec3* vertices;
        public int* indices;
        public byte* materialIndices;
        public float weldTolerance;
        public int vertexCount;
        public int triangleCount;
        public box3dbool weldVertices;
        public box3dbool useMedianSplit;
        public box3dbool identifyEdges;
    }

    public enum b3MeshEdgeFlags
    {
        b3_concaveEdge1 = 1,
        b3_concaveEdge2 = 2,
        b3_concaveEdge3 = 4,
        b3_inverseConcaveEdge1 = 16,
        b3_inverseConcaveEdge2 = 32,
        b3_inverseConcaveEdge3 = 64,
        b3_allConcaveEdges = 7,
        b3_flatEdge1 = 17,
        b3_flatEdge2 = 34,
        b3_flatEdge3 = 68,
        b3_allFlatEdges = 119,
    }

    [Flags]
    public enum b3MeshEdgeFlags : b3MeshEdgeFlags
    {
        b3_concaveEdge1 = 0x01,
        b3_concaveEdge2 = 0x02,
        b3_concaveEdge3 = 0x04,
        b3_inverseConcaveEdge1 = 0x10,
        b3_inverseConcaveEdge2 = 0x20,
        b3_inverseConcaveEdge3 = 0x40,
        b3_allConcaveEdges = b3_concaveEdge1 | b3_concaveEdge2 | b3_concaveEdge3,
        b3_flatEdge1 = b3_concaveEdge1 | b3_inverseConcaveEdge1,
        b3_flatEdge2 = b3_concaveEdge2 | b3_inverseConcaveEdge2,
        b3_flatEdge3 = b3_concaveEdge3 | b3_inverseConcaveEdge3,
        b3_allFlatEdges = b3_flatEdge1 | b3_flatEdge2 | b3_flatEdge3,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3MeshTriangle
    {
        public int index1;
        public int index2;
        public int index3;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct b3MeshNode
    {
        [FieldOffset(0)]
        public b3Vec3 lowerBound;
        [FieldOffset(12)]
        public INTERNAL_b3MeshNode_data_asNode data_asNode;
        [FieldOffset(12)]
        public INTERNAL_b3MeshNode_data_asLeaf data_asLeaf;
        [FieldOffset(16)]
        public b3Vec3 upperBound;
        [FieldOffset(28)]
        public uint triangleOffset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_b3MeshNode_data_asNode
    {
        public uint bitfield;

        public readonly uint axis { get { return bitfield & 0b11u; } }
        public readonly uint childOffset { get { return (bitfield >> 2) & 0b111111111111111111111111111111u; } }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_b3MeshNode_data_asLeaf
    {
        public uint bitfield;

        public readonly uint type { get { return bitfield & 0b11u; } }
        public readonly uint triangleCount { get { return (bitfield >> 2) & 0b111111111111111111111111111111u; } }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3MeshData
    {
        public ulong version;
        public int byteCount;
        public uint hash;
        public b3AABB bounds;
        public float surfaceArea;
        public int treeHeight;
        public int degenerateCount;
        public int nodeOffset;
        public int nodeCount;
        public int vertexOffset;
        public int vertexCount;
        public int triangleOffset;
        public int triangleCount;
        public int materialOffset;
        public int materialCount;
        public int flagsOffset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Mesh
    {
        public b3MeshData* data;
        public b3Vec3 scale;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3HeightFieldDef
    {
        public float* heights;
        public byte* materialIndices;
        public b3Vec3 scale;
        public int countX;
        public int countZ;
        public float globalMinimumHeight;
        public float globalMaximumHeight;
        public box3dbool clockwiseWinding;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3HeightFieldData
    {
        public ulong version;
        public int byteCount;
        public uint hash;
        public b3AABB aabb;
        public float minHeight;
        public float maxHeight;
        public float heightScale;
        public b3Vec3 scale;
        public int columnCount;
        public int rowCount;
        public int heightsOffset;
        public int materialOffset;
        public int flagsOffset;
        public box3dbool clockwise;
        public fixed byte padding[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundCapsuleDef
    {
        public b3Capsule capsule;
        public b3SurfaceMaterial material;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundHullDef
    {
        public b3HullData* hull;
        public b3Transform transform;
        public b3SurfaceMaterial material;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundMeshDef
    {
        public b3MeshData* meshData;
        public b3Transform transform;
        public b3Vec3 scale;
        public b3SurfaceMaterial* materials;
        public int materialCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundSphereDef
    {
        public b3Sphere sphere;
        public b3SurfaceMaterial material;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundDef
    {
        public b3CompoundCapsuleDef* capsules;
        public int capsuleCount;
        public b3CompoundHullDef* hulls;
        public int hullCount;
        public b3CompoundMeshDef* meshes;
        public int meshCount;
        public b3CompoundSphereDef* spheres;
        public int sphereCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundData
    {
        public ulong version;
        public int byteCount;
        public int nodeOffset;
        public b3DynamicTree tree;
        public int materialOffset;
        public int materialCount;
        public int capsuleOffset;
        public int capsuleCount;
        public int hullOffset;
        public int hullCount;
        public int sharedHullCount;
        public int meshOffset;
        public int meshCount;
        public int sharedMeshCount;
        public int sphereOffset;
        public int sphereCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundCapsule
    {
        public b3Capsule capsule;
        public int materialIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundHull
    {
        public b3HullData* hull;
        public b3Transform transform;
        public int materialIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundMesh
    {
        public b3MeshData* meshData;
        public b3Transform transform;
        public b3Vec3 scale;
        public fixed int materialIndices[4];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3CompoundSphere
    {
        public b3Sphere sphere;
        public int materialIndex;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct b3ChildShape
    {
        [FieldOffset(0)]
        public b3Capsule __capsule;
        [FieldOffset(0)]
        public b3HullData* __hull;
        [FieldOffset(0)]
        public b3Mesh __mesh;
        [FieldOffset(0)]
        public b3Sphere __sphere;
        [FieldOffset(32)]
        public b3Transform transform;
        [FieldOffset(60)]
        public fixed int materialIndices[4];
        [FieldOffset(76)]
        public b3ShapeType type;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3ManifoldPoint
    {
        public b3Vec3 anchorA;
        public b3Vec3 anchorB;
        public float separation;
        public float baseSeparation;
        public float normalImpulse;
        public float totalNormalImpulse;
        public float normalVelocity;
        public uint featureId;
        public int triangleIndex;
        public box3dbool persisted;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3Manifold
    {
        public b3ManifoldPoint points0;
        public b3ManifoldPoint points1;
        public b3ManifoldPoint points2;
        public b3ManifoldPoint points3;
        public b3Vec3 normal;
        public float twistImpulse;
        public b3Vec3 frictionImpulse;
        public b3Vec3 rollingImpulse;
        public int pointCount;
    }

    public enum b3SeparatingFeature
    {
        b3_invalidAxis = 0,
        b3_backsideAxis = 1,
        b3_faceAxisA = 2,
        b3_faceAxisB = 3,
        b3_edgePairAxis = 4,
        b3_closestPointsAxis = 5,
        b3_manualFaceAxisA = 6,
        b3_manualFaceAxisB = 7,
        b3_manualEdgePairAxis = 8,
    }

    public enum b3TriangleFeature
    {
        b3_featureNone = 0,
        b3_featureTriangleFace = 1,
        b3_featureHullFace = 2,
        b3_featureEdge1 = 3,
        b3_featureEdge2 = 4,
        b3_featureEdge3 = 5,
        b3_featureVertex1 = 6,
        b3_featureVertex2 = 7,
        b3_featureVertex3 = 8,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3FeaturePair
    {
        public byte owner1;
        public byte index1;
        public byte owner2;
        public byte index2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3LocalManifoldPoint
    {
        public b3Vec3 point;
        public float separation;
        public b3FeaturePair pair;
        public int triangleIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3LocalManifold
    {
        public b3Vec3 normal;
        public b3Vec3 triangleNormal;
        public b3LocalManifoldPoint* points;
        public int pointCount;
        public int triangleIndex;
        public int i1;
        public int i2;
        public int i3;
        public float squaredDistance;
        public b3TriangleFeature feature;
        public int triangleFlags;
    }

    public enum b3HexColor
    {
        b3_colorAliceBlue = 15792383,
        b3_colorAntiqueWhite = 16444375,
        b3_colorAqua = 65535,
        b3_colorAquamarine = 8388564,
        b3_colorAzure = 15794175,
        b3_colorBeige = 16119260,
        b3_colorBisque = 16770244,
        b3_colorBlack = 0,
        b3_colorBlanchedAlmond = 16772045,
        b3_colorBlue = 255,
        b3_colorBlueViolet = 9055202,
        b3_colorBrown = 10824234,
        b3_colorBurlywood = 14596231,
        b3_colorCadetBlue = 6266528,
        b3_colorChartreuse = 8388352,
        b3_colorChocolate = 13789470,
        b3_colorCoral = 16744272,
        b3_colorCornflowerBlue = 6591981,
        b3_colorCornsilk = 16775388,
        b3_colorCrimson = 14423100,
        b3_colorCyan = 65535,
        b3_colorDarkBlue = 139,
        b3_colorDarkCyan = 35723,
        b3_colorDarkGoldenRod = 12092939,
        b3_colorDarkGray = 11119017,
        b3_colorDarkGreen = 25600,
        b3_colorDarkKhaki = 12433259,
        b3_colorDarkMagenta = 9109643,
        b3_colorDarkOliveGreen = 5597999,
        b3_colorDarkOrange = 16747520,
        b3_colorDarkOrchid = 10040012,
        b3_colorDarkRed = 9109504,
        b3_colorDarkSalmon = 15308410,
        b3_colorDarkSeaGreen = 9419919,
        b3_colorDarkSlateBlue = 4734347,
        b3_colorDarkSlateGray = 3100495,
        b3_colorDarkTurquoise = 52945,
        b3_colorDarkViolet = 9699539,
        b3_colorDeepPink = 16716947,
        b3_colorDeepSkyBlue = 49151,
        b3_colorDimGray = 6908265,
        b3_colorDodgerBlue = 2003199,
        b3_colorFireBrick = 11674146,
        b3_colorFloralWhite = 16775920,
        b3_colorForestGreen = 2263842,
        b3_colorFuchsia = 16711935,
        b3_colorGainsboro = 14474460,
        b3_colorGhostWhite = 16316671,
        b3_colorGold = 16766720,
        b3_colorGoldenRod = 14329120,
        b3_colorGray = 8421504,
        b3_colorGreen = 32768,
        b3_colorGreenYellow = 11403055,
        b3_colorHoneyDew = 15794160,
        b3_colorHotPink = 16738740,
        b3_colorIndianRed = 13458524,
        b3_colorIndigo = 4915330,
        b3_colorIvory = 16777200,
        b3_colorKhaki = 15787660,
        b3_colorLavender = 15132410,
        b3_colorLavenderBlush = 16773365,
        b3_colorLawnGreen = 8190976,
        b3_colorLemonChiffon = 16775885,
        b3_colorLightBlue = 11393254,
        b3_colorLightCoral = 15761536,
        b3_colorLightCyan = 14745599,
        b3_colorLightGoldenRodYellow = 16448210,
        b3_colorLightGray = 13882323,
        b3_colorLightGreen = 9498256,
        b3_colorLightPink = 16758465,
        b3_colorLightSalmon = 16752762,
        b3_colorLightSeaGreen = 2142890,
        b3_colorLightSkyBlue = 8900346,
        b3_colorLightSlateGray = 7833753,
        b3_colorLightSteelBlue = 11584734,
        b3_colorLightYellow = 16777184,
        b3_colorLime = 65280,
        b3_colorLimeGreen = 3329330,
        b3_colorLinen = 16445670,
        b3_colorMagenta = 16711935,
        b3_colorMaroon = 8388608,
        b3_colorMediumAquaMarine = 6737322,
        b3_colorMediumBlue = 205,
        b3_colorMediumOrchid = 12211667,
        b3_colorMediumPurple = 9662683,
        b3_colorMediumSeaGreen = 3978097,
        b3_colorMediumSlateBlue = 8087790,
        b3_colorMediumSpringGreen = 64154,
        b3_colorMediumTurquoise = 4772300,
        b3_colorMediumVioletRed = 13047173,
        b3_colorMidnightBlue = 1644912,
        b3_colorMintCream = 16121850,
        b3_colorMistyRose = 16770273,
        b3_colorMoccasin = 16770229,
        b3_colorNavajoWhite = 16768685,
        b3_colorNavy = 128,
        b3_colorOldLace = 16643558,
        b3_colorOlive = 8421376,
        b3_colorOliveDrab = 7048739,
        b3_colorOrange = 16753920,
        b3_colorOrangeRed = 16729344,
        b3_colorOrchid = 14315734,
        b3_colorPaleGoldenRod = 15657130,
        b3_colorPaleGreen = 10025880,
        b3_colorPaleTurquoise = 11529966,
        b3_colorPaleVioletRed = 14381203,
        b3_colorPapayaWhip = 16773077,
        b3_colorPeachPuff = 16767673,
        b3_colorPeru = 13468991,
        b3_colorPink = 16761035,
        b3_colorPlum = 14524637,
        b3_colorPowderBlue = 11591910,
        b3_colorPurple = 8388736,
        b3_colorRebeccaPurple = 6697881,
        b3_colorRed = 16711680,
        b3_colorRosyBrown = 12357519,
        b3_colorRoyalBlue = 4286945,
        b3_colorSaddleBrown = 9127187,
        b3_colorSalmon = 16416882,
        b3_colorSandyBrown = 16032864,
        b3_colorSeaGreen = 3050327,
        b3_colorSeaShell = 16774638,
        b3_colorSienna = 10506797,
        b3_colorSilver = 12632256,
        b3_colorSkyBlue = 8900331,
        b3_colorSlateBlue = 6970061,
        b3_colorSlateGray = 7372944,
        b3_colorSnow = 16775930,
        b3_colorSpringGreen = 65407,
        b3_colorSteelBlue = 4620980,
        b3_colorTan = 13808780,
        b3_colorTeal = 32896,
        b3_colorThistle = 14204888,
        b3_colorTomato = 16737095,
        b3_colorTurquoise = 4251856,
        b3_colorViolet = 15631086,
        b3_colorWheat = 16113331,
        b3_colorWhite = 16777215,
        b3_colorWhiteSmoke = 16119285,
        b3_colorYellow = 16776960,
        b3_colorYellowGreen = 10145074,
        b3_colorBox2DRed = 14430514,
        b3_colorBox2DBlue = 3190463,
        b3_colorBox2DGreen = 9226532,
        b3_colorBox2DYellow = 16772748,
    }

    public enum b3DebugMaterial
    {
        b3_debugMaterialDefault = 0,
        b3_debugMaterialMatte = 1,
        b3_debugMaterialSoft = 2,
        b3_debugMaterialDead = 3,
        b3_debugMaterialGlossy = 4,
        b3_debugMaterialMetallic = 5,
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint b3MakeDebugColor(b3HexColor rgb, b3DebugMaterial material);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3HexColor b3GetGraphColor(int index);

    [StructLayout(LayoutKind.Explicit)]
    public struct b3DebugShape
    {
        [FieldOffset(0)]
        public b3ShapeId shapeId;
        [FieldOffset(8)]
        public b3ShapeType type;
        [FieldOffset(16)]
        public b3Capsule* __capsule;
        [FieldOffset(16)]
        public b3CompoundData* __compound;
        [FieldOffset(16)]
        public b3HeightFieldData* __heightField;
        [FieldOffset(16)]
        public b3HullData* __hull;
        [FieldOffset(16)]
        public b3Mesh* __mesh;
        [FieldOffset(16)]
        public b3Sphere* __sphere;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3DebugDraw
    {
        public IntPtr DrawShapeFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawSegmentFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawTransformFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawPointFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawSphereFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawCapsuleFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawBoundsFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawBoxFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr DrawStringFcn; // WARN_ANONYMOUS_FUNCTION_POINTER
        public b3AABB drawingBounds;
        public float forceScale;
        public float jointScale;
        public box3dbool drawShapes;
        public box3dbool drawJoints;
        public box3dbool drawJointExtras;
        public box3dbool drawBounds;
        public box3dbool drawMass;
        public box3dbool drawSleep;
        public box3dbool drawBodyNames;
        public box3dbool drawContacts;
        public box3dbool drawAnchorA;
        public box3dbool drawGraphColors;
        public box3dbool drawContactFeatures;
        public box3dbool drawContactNormals;
        public box3dbool drawContactForces;
        public box3dbool drawIslands;
        public IntPtr context;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3DebugDraw b3DefaultDebugDraw();

    // ../box3d/include/box3d/collision.h

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3DynamicTree b3DynamicTree_Create(int proxyCapacity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_Destroy(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3DynamicTree_CreateProxy(IntPtr tree, b3AABB aabb, ulong categoryBits, ulong userData); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_DestroyProxy(IntPtr tree, int proxyId); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_MoveProxy(IntPtr tree, int proxyId, b3AABB aabb); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_EnlargeProxy(IntPtr tree, int proxyId, b3AABB aabb); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_SetCategoryBits(IntPtr tree, int proxyId, ulong categoryBits); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong b3DynamicTree_GetCategoryBits(IntPtr tree, int proxyId); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3DynamicTree_Query(IntPtr tree, b3AABB aabb, ulong maskBits, box3dbool requireAllBits, IntPtr callback, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3DynamicTree_QueryClosest(IntPtr tree, b3Vec3 point, ulong maskBits, box3dbool requireAllBits, IntPtr callback, IntPtr context, IntPtr minDistanceSqr); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3DynamicTree_RayCast(IntPtr tree, IntPtr input, ulong maskBits, box3dbool requireAllBits, IntPtr callback, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3DynamicTree_BoxCast(IntPtr tree, IntPtr input, ulong maskBits, box3dbool requireAllBits, IntPtr callback, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3DynamicTree_GetHeight(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DynamicTree_GetAreaRatio(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3DynamicTree_GetRootBounds(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3DynamicTree_GetProxyCount(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3DynamicTree_Rebuild(IntPtr tree, box3dbool fullBuild); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3DynamicTree_GetByteCount(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_Validate(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_ValidateNoEnlarged(IntPtr tree); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DynamicTree_Save(IntPtr tree, string fileName); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3DynamicTree b3DynamicTree_Load(string fileName, float scale);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong b3DynamicTree_GetUserData(IntPtr tree, int proxyId); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3DynamicTree_GetAABB(IntPtr tree, int proxyId); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHullVertices(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHullPoints(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHullEdges(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHullPlanes(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHullFaces(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHullSoaVertices(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHullSoaNormals(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateCylinder(float height, float radius, float yOffset, int sides); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateCone(float height, float radius1, float radius2, int slices); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateRock(float radius); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateHull(IntPtr points, int pointCount, int maxVertexCount); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CloneHull(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CloneAndTransformHull(IntPtr original, b3Transform transform, b3Vec3 scale); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyHull(IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BoxHull b3MakeCubeHull(float halfWidth);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BoxHull b3MakeBoxHull(float hx, float hy, float hz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BoxHull b3MakeOffsetBoxHull(float hx, float hy, float hz, b3Vec3 offset);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BoxHull b3MakeTransformedBoxHull(float hx, float hy, float hz, b3Transform transform);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BoxHull b3MakeScaledBoxHull(b3Vec3 halfWidths, b3Transform transform, b3Vec3 postScale);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3ScaleBox(IntPtr halfWidths, IntPtr transform, b3Vec3 postScale, float minHalfWidth); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetMeshNodes(IntPtr mesh); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetMeshVertices(IntPtr mesh); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetMeshTriangles(IntPtr mesh); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetMeshMaterialIndices(IntPtr mesh); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetMeshFlags(IntPtr mesh); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateGridMesh(int xCount, int zCount, float cellWidth, int materialCount, box3dbool identifyEdges); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateWaveMesh(int xCount, int zCount, float cellWidth, float amplitude, float rowFrequency, float columnFrequency); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateTorusMesh(int radialResolution, int tubularResolution, float radius, float thickness); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateBoxMesh(b3Vec3 center, b3Vec3 extent, box3dbool identifyEdges); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateHollowBoxMesh(b3Vec3 center, b3Vec3 extent); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreatePlatformMesh(b3Vec3 center, float height, float topWidth, float bottomWidth); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateMesh(IntPtr def, IntPtr degenerateTriangleIndices, int degenerateCapacity); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyMesh(IntPtr mesh); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3GetHeight(IntPtr mesh); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHeightFieldCompressedHeights(IntPtr hf); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHeightFieldMaterialIndices(IntPtr hf); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetHeightFieldFlags(IntPtr hf); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateHeightField(IntPtr data); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateGrid(int rowCount, int columnCount, b3Vec3 scale, box3dbool makeHoles); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateWave(int rowCount, int columnCount, b3Vec3 scale, float rowFrequency, float columnFrequency, box3dbool makeHoles); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyHeightField(IntPtr heightField); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DumpHeightData(IntPtr data, string fileName); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3LoadHeightField(string fileName); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ChildShape b3GetCompoundChild(IntPtr compound, int childIndex); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3QueryCompound(IntPtr compound, b3AABB aabb, IntPtr fcn, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CompoundCapsule b3GetCompoundCapsule(IntPtr compound, int index); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CompoundHull b3GetCompoundHull(IntPtr compound, int index); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CompoundMesh b3GetCompoundMesh(IntPtr compound, int index); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CompoundSphere b3GetCompoundSphere(IntPtr compound, int index); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3GetCompoundMaterials(IntPtr compound); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateCompound(IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyCompound(IntPtr compound); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3ConvertCompoundToBytes(IntPtr compound); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3ConvertBytesToCompound(IntPtr bytes, int byteCount); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3MassData b3ComputeSphereMass(IntPtr shape, float density); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3MassData b3ComputeCapsuleMass(IntPtr shape, float density); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3MassData b3ComputeHullMass(IntPtr shape, float density); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3ComputeSphereAABB(IntPtr shape, b3Transform transform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3ComputeCapsuleAABB(IntPtr shape, b3Transform transform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3ComputeHullAABB(IntPtr shape, b3Transform transform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3ComputeMeshAABB(IntPtr shape, b3Transform transform, b3Vec3 scale); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3ComputeHeightFieldAABB(IntPtr shape, b3Transform transform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3ComputeCompoundAABB(IntPtr shape, b3Transform transform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3IsValidRay(IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3OverlapCapsule(IntPtr shape, b3Transform shapeTransform, IntPtr proxy); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3OverlapCompound(IntPtr shape, b3Transform shapeTransform, IntPtr proxy); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3OverlapHeightField(IntPtr shape, b3Transform shapeTransform, IntPtr proxy); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3OverlapHull(IntPtr shape, b3Transform shapeTransform, IntPtr proxy); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3OverlapMesh(IntPtr shape, b3Transform shapeTransform, IntPtr proxy); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3OverlapSphere(IntPtr shape, b3Transform shapeTransform, IntPtr proxy); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3RayCastSphere(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3RayCastHollowSphere(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3RayCastCapsule(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3RayCastCompound(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3RayCastHull(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3RayCastMesh(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3RayCastHeightField(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3ShapeCastSphere(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3ShapeCastCapsule(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3ShapeCastCompound(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3ShapeCastHull(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3ShapeCastMesh(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3ShapeCastHeightField(IntPtr shape, IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3QueryMesh(IntPtr mesh, b3AABB bounds, IntPtr fcn, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3QueryHeightField(IntPtr heightField, b3AABB bounds, IntPtr fcn, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3DistanceOutput b3ShapeDistance(IntPtr input, IntPtr cache, IntPtr simplexes, int simplexCapacity); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3ShapeCast(IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3GetSweepTransform(IntPtr sweep, float time); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TOIOutput b3TimeOfImpact(IntPtr input); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideSpheres(IntPtr manifold, int capacity, IntPtr sphereA, IntPtr sphereB, b3Transform transformBtoA); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideCapsuleAndSphere(IntPtr manifold, int capacity, IntPtr capsuleA, IntPtr sphereB, b3Transform transformBtoA); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideHullAndSphere(IntPtr manifold, int capacity, IntPtr hullA, IntPtr sphereB, b3Transform transformBtoA, IntPtr cache); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideCapsules(IntPtr manifold, int capacity, IntPtr capsuleA, IntPtr capsuleB, b3Transform transformBtoA); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideHullAndCapsule(IntPtr manifold, int capacity, IntPtr hullA, IntPtr capsuleB, b3Transform transformBtoA, IntPtr cache); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideHulls(IntPtr manifold, int capacity, IntPtr hullA, IntPtr hullB, b3Transform transformBtoA, IntPtr cache); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideTriangleAndCapsule(IntPtr manifold, int capacity, IntPtr triangleA, IntPtr capsuleB, IntPtr cache); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideTriangleAndHull(IntPtr manifold, int capacity, b3Vec3 v1, b3Vec3 v2, b3Vec3 v3, int triangleFlags, IntPtr hullB, IntPtr cache, box3dbool enableSpeculative); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3CollideTriangleAndSphere(IntPtr manifold, int capacity, IntPtr triangleA, IntPtr sphereB); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3PlaneSolverResult b3SolvePlanes(b3Vec3 targetDelta, IntPtr planes, int count); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3ClipVector(b3Vec3 vector, IntPtr planes, int count); // WARN_UNKNOWN_POINTER_PARAMETER

    // ../box3d/include/box3d/box3d.h

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WorldId b3CreateWorld(IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyWorld(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3GetWorldCount();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3GetMaxWorldCount();

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3World_IsValid(b3WorldId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_Step(b3WorldId worldId, float timeStep, int subStepCount);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_Draw(b3WorldId worldId, IntPtr draw, ulong maskBits); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3World_GetBounds(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyEvents b3World_GetBodyEvents(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3SensorEvents b3World_GetSensorEvents(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ContactEvents b3World_GetContactEvents(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointEvents b3World_GetJointEvents(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3World_OverlapAABB(b3WorldId worldId, b3AABB aabb, b3QueryFilter filter, IntPtr fcn, IntPtr context);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3World_OverlapShape(b3WorldId worldId, b3Vec3 origin, IntPtr proxy, b3QueryFilter filter, IntPtr fcn, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3World_CastRay(b3WorldId worldId, b3Vec3 origin, b3Vec3 translation, b3QueryFilter filter, IntPtr fcn, IntPtr context);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3RayResult b3World_CastRayClosest(b3WorldId worldId, b3Vec3 origin, b3Vec3 translation, b3QueryFilter filter);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3TreeStats b3World_CastShape(b3WorldId worldId, b3Vec3 origin, IntPtr proxy, b3Vec3 translation, b3QueryFilter filter, IntPtr fcn, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3World_CastMover(b3WorldId worldId, b3Vec3 origin, IntPtr mover, b3Vec3 translation, b3QueryFilter filter, IntPtr fcn, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_CollideMover(b3WorldId worldId, b3Vec3 origin, IntPtr mover, b3QueryFilter filter, IntPtr fcn, IntPtr context); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_EnableSleeping(b3WorldId worldId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3World_IsSleepingEnabled(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_EnableContinuous(b3WorldId worldId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3World_IsContinuousEnabled(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetRestitutionThreshold(b3WorldId worldId, float value);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3World_GetRestitutionThreshold(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetHitEventThreshold(b3WorldId worldId, float value);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3World_GetHitEventThreshold(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetCustomFilterCallback(b3WorldId worldId, IntPtr fcn, IntPtr context);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetPreSolveCallback(b3WorldId worldId, IntPtr fcn, IntPtr context);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetGravity(b3WorldId worldId, b3Vec3 gravity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3World_GetGravity(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_Explode(b3WorldId worldId, IntPtr explosionDef); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetContactTuning(b3WorldId worldId, float hertz, float dampingRatio, float contactSpeed);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetContactRecycleDistance(b3WorldId worldId, float recycleDistance);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3World_GetContactRecycleDistance(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetMaximumLinearSpeed(b3WorldId worldId, float maximumLinearSpeed);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3World_GetMaximumLinearSpeed(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_EnableWarmStarting(b3WorldId worldId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3World_IsWarmStartingEnabled(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3World_GetAwakeBodyCount(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Profile b3World_GetProfile(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Counters b3World_GetCounters(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Capacity b3World_GetMaxCapacity(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetUserData(b3WorldId worldId, IntPtr userData);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3World_GetUserData(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetFrictionCallback(b3WorldId worldId, IntPtr callback);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetRestitutionCallback(b3WorldId worldId, IntPtr callback);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_SetWorkerCount(b3WorldId worldId, int count);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3World_GetWorkerCount(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_DumpMemoryStats(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_DumpShapeBounds(b3WorldId worldId, b3BodyType type);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_RebuildStaticTree(b3WorldId worldId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_EnableSpeculative(b3WorldId worldId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3CreateRecording(int byteCapacity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyRecording(IntPtr recording);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3Recording_GetData(IntPtr recording); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Recording_GetSize(IntPtr recording);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_StartRecording(b3WorldId worldId, IntPtr recording);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3World_StopRecording(b3WorldId worldId);

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3SaveRecordingToFile(IntPtr recording, string path);

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3LoadRecordingFromFile(string path);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3ValidateReplay(IntPtr data, int size, int workerCount);

    [StructLayout(LayoutKind.Sequential)]
    public struct b3RecPlayerInfo
    {
        public int frameCount;
        public int workerCount;
        public float timeStep;
        public int subStepCount;
        public float lengthScale;
        public b3AABB bounds;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3RecPlayer_Create(IntPtr data, int size, int workerCount);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_Destroy(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3RecPlayer_StepFrame(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_SubStepFrame(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_Restart(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_SeekFrame(IntPtr player, int targetFrame);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WorldId b3RecPlayer_GetWorldId(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3RecPlayer_GetFrame(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3RecPlayer_GetFrameCount(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3RecPlayer_IsAtEnd(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3RecPlayer_IsAtPreStep(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3RecPlayer_HasDiverged(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3RecPlayerInfo b3RecPlayer_GetInfo(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3RecPlayer_GetDivergeFrame(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_SetWorkerCount(IntPtr player, int count);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_SetKeyframePolicy(IntPtr player, UIntPtr budgetBytes, int minIntervalFrames);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr b3RecPlayer_GetKeyframeBudget(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3RecPlayer_GetKeyframeMinInterval(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3RecPlayer_GetKeyframeInterval(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr b3RecPlayer_GetKeyframeBytes(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3RecPlayer_GetBodyCount(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyId b3RecPlayer_GetBodyId(IntPtr player, int index);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_SetDebugShapeCallbacks(IntPtr player, IntPtr createDebugShape, IntPtr destroyDebugShape, IntPtr context);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RecPlayer_DrawFrameQueries(IntPtr player, IntPtr draw, int queryIndex, int selectedIndex); // WARN_UNKNOWN_POINTER_PARAMETER

    public enum b3RecQueryType
    {
        b3_recQueryOverlapAABB = 0,
        b3_recQueryOverlapShape = 1,
        b3_recQueryCastRay = 2,
        b3_recQueryCastShape = 3,
        b3_recQueryCastRayClosest = 4,
        b3_recQueryCastMover = 5,
        b3_recQueryCollideMover = 6,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3RecQueryInfo
    {
        public b3RecQueryType type;
        public b3QueryFilter filter;
        public b3AABB aabb;
        public b3Vec3 origin;
        public b3Vec3 translation;
        public int hitCount;
        public ulong key;
        public ulong id;
        public byte* name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b3RecQueryHit
    {
        public b3ShapeId shape;
        public b3Vec3 point;
        public b3Vec3 normal;
        public float fraction;
    }

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3RecPlayer_GetFrameQueryCount(IntPtr player);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3RecQueryInfo b3RecPlayer_GetFrameQuery(IntPtr player, int index);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3RecQueryHit b3RecPlayer_GetFrameQueryHit(IntPtr player, int queryIndex, int hitIndex);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyId b3CreateBody(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyBody(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_IsValid(b3BodyId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyType b3Body_GetType(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetType(b3BodyId bodyId, b3BodyType type);

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetName(b3BodyId bodyId, string name);

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalUsing(typeof(LibraryOwnedStringMarshaller))]
    public static partial string b3Body_GetName(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetUserData(b3BodyId bodyId, IntPtr userData);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3Body_GetUserData(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetPosition(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3Body_GetRotation(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3Body_GetTransform(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetTransform(b3BodyId bodyId, b3Vec3 position, b3Quat rotation);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetLocalPoint(b3BodyId bodyId, b3Vec3 worldPoint);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetWorldPoint(b3BodyId bodyId, b3Vec3 localPoint);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetLocalVector(b3BodyId bodyId, b3Vec3 worldVector);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetWorldVector(b3BodyId bodyId, b3Vec3 localVector);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetLinearVelocity(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetAngularVelocity(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetLinearVelocity(b3BodyId bodyId, b3Vec3 linearVelocity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetAngularVelocity(b3BodyId bodyId, b3Vec3 angularVelocity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetTargetTransform(b3BodyId bodyId, b3Transform target, float timeStep, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetLocalPointVelocity(b3BodyId bodyId, b3Vec3 localPoint);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetWorldPointVelocity(b3BodyId bodyId, b3Vec3 worldPoint);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_ApplyForce(b3BodyId bodyId, b3Vec3 force, b3Vec3 point, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_ApplyForceToCenter(b3BodyId bodyId, b3Vec3 force, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_ApplyTorque(b3BodyId bodyId, b3Vec3 torque, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_ApplyLinearImpulse(b3BodyId bodyId, b3Vec3 impulse, b3Vec3 point, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_ApplyLinearImpulseToCenter(b3BodyId bodyId, b3Vec3 impulse, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_ApplyAngularImpulse(b3BodyId bodyId, b3Vec3 impulse, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Body_GetMass(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3Body_GetLocalRotationalInertia(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Body_GetInverseMass(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Matrix3 b3Body_GetWorldInverseRotationalInertia(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetLocalCenter(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Body_GetWorldCenter(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetMassData(b3BodyId bodyId, b3MassData massData);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3MassData b3Body_GetMassData(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_ApplyMassFromShapes(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetLinearDamping(b3BodyId bodyId, float linearDamping);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Body_GetLinearDamping(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetAngularDamping(b3BodyId bodyId, float angularDamping);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Body_GetAngularDamping(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetGravityScale(b3BodyId bodyId, float gravityScale);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Body_GetGravityScale(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_IsAwake(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetAwake(b3BodyId bodyId, box3dbool awake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_EnableSleep(b3BodyId bodyId, box3dbool enableSleep);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_IsSleepEnabled(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetSleepThreshold(b3BodyId bodyId, float sleepThreshold);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Body_GetSleepThreshold(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_IsEnabled(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_Disable(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_Enable(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetMotionLocks(b3BodyId bodyId, b3MotionLocks locks);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3MotionLocks b3Body_GetMotionLocks(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_SetBullet(b3BodyId bodyId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_IsBullet(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_AllowFastRotation(b3BodyId bodyId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_IsFastRotationAllowed(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_EnableContactRecycling(b3BodyId bodyId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_IsContactRecyclingEnabled(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Body_EnableHitEvents(b3BodyId bodyId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WorldId b3Body_GetWorld(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Body_GetShapeCount(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Body_GetShapes(b3BodyId bodyId, IntPtr shapeArray, int capacity); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Body_GetJointCount(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Body_GetJoints(b3BodyId bodyId, IntPtr jointArray, int capacity); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Body_GetContactCapacity(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Body_GetContactData(b3BodyId bodyId, IntPtr contactData, int capacity); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3Body_ComputeAABB(b3BodyId bodyId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Body_GetClosestPoint(b3BodyId bodyId, IntPtr result, b3Vec3 target); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyCastResult b3Body_CastRay(b3BodyId bodyId, b3Vec3 origin, b3Vec3 translation, b3QueryFilter filter, float maxFraction, b3Transform bodyTransform);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyCastResult b3Body_CastShape(b3BodyId bodyId, b3Vec3 origin, IntPtr proxy, b3Vec3 translation, b3QueryFilter filter, float maxFraction, box3dbool canEncroach, b3Transform bodyTransform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Body_OverlapShape(b3BodyId bodyId, b3Vec3 origin, IntPtr proxy, b3QueryFilter filter, b3Transform bodyTransform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Body_CollideMover(b3BodyId bodyId, IntPtr bodyPlanes, int planeCapacity, b3Vec3 origin, IntPtr mover, b3QueryFilter filter, b3Transform bodyTransform); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3CreateSphereShape(b3BodyId bodyId, IntPtr def, IntPtr sphere); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3CreateCapsuleShape(b3BodyId bodyId, IntPtr def, IntPtr capsule); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3CreateHullShape(b3BodyId bodyId, IntPtr def, IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3CreateTransformedHullShape(b3BodyId bodyId, IntPtr def, IntPtr hull, b3Transform transform, b3Vec3 scale); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3CreateMeshShape(b3BodyId bodyId, IntPtr def, IntPtr mesh, b3Vec3 scale); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3CreateHeightFieldShape(b3BodyId bodyId, IntPtr def, IntPtr heightField); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeId b3CreateBakedCompoundShape(b3BodyId bodyId, IntPtr def, IntPtr compound); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyShape(b3ShapeId shapeId, box3dbool updateBodyMass);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Shape_IsValid(b3ShapeId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ShapeType b3Shape_GetType(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyId b3Shape_GetBody(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WorldId b3Shape_GetWorld(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Shape_IsSensor(b3ShapeId shapeId);

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetName(b3ShapeId shapeId, string name);

    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalUsing(typeof(LibraryOwnedStringMarshaller))]
    public static partial string b3Shape_GetName(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetUserData(b3ShapeId shapeId, IntPtr userData);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3Shape_GetUserData(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetDensity(b3ShapeId shapeId, float density, box3dbool updateBodyMass);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Shape_GetDensity(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetFriction(b3ShapeId shapeId, float friction);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Shape_GetFriction(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetRestitution(b3ShapeId shapeId, float restitution);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Shape_GetRestitution(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetSurfaceMaterial(b3ShapeId shapeId, b3SurfaceMaterial surfaceMaterial);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3SurfaceMaterial b3Shape_GetSurfaceMaterial(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Shape_GetMeshMaterialCount(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetMeshMaterial(b3ShapeId shapeId, b3SurfaceMaterial surfaceMaterial, int index);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3SurfaceMaterial b3Shape_GetMeshSurfaceMaterial(b3ShapeId shapeId, int index);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Filter b3Shape_GetFilter(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetFilter(b3ShapeId shapeId, b3Filter filter, box3dbool invokeContacts);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_EnableSensorEvents(b3ShapeId shapeId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Shape_AreSensorEventsEnabled(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_EnableContactEvents(b3ShapeId shapeId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Shape_AreContactEventsEnabled(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_EnablePreSolveEvents(b3ShapeId shapeId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Shape_ArePreSolveEventsEnabled(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_EnableHitEvents(b3ShapeId shapeId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Shape_AreHitEventsEnabled(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3CastOutput b3Shape_RayCast(b3ShapeId shapeId, b3Vec3 origin, b3Vec3 translation);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Sphere b3Shape_GetSphere(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Capsule b3Shape_GetCapsule(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3Shape_GetHull(b3ShapeId shapeId); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Mesh b3Shape_GetMesh(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3Shape_GetHeightField(b3ShapeId shapeId); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetSphere(b3ShapeId shapeId, IntPtr sphere); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetCapsule(b3ShapeId shapeId, IntPtr capsule); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetHull(b3ShapeId shapeId, IntPtr hull); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_SetMesh(b3ShapeId shapeId, IntPtr meshData, b3Vec3 scale); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Shape_GetContactCapacity(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Shape_GetContactData(b3ShapeId shapeId, IntPtr contactData, int capacity); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Shape_GetSensorCapacity(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int b3Shape_GetSensorData(b3ShapeId shapeId, IntPtr visitorIds, int capacity); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3AABB b3Shape_GetAABB(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3MassData b3Shape_ComputeMassData(b3ShapeId shapeId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Shape_GetClosestPoint(b3ShapeId shapeId, b3Vec3 target);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Shape_ApplyWind(b3ShapeId shapeId, b3Vec3 wind, float drag, float lift, float maxSpeed, box3dbool wake);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DestroyJoint(b3JointId jointId, box3dbool wakeAttached);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Joint_IsValid(b3JointId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointType b3Joint_GetType(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyId b3Joint_GetBodyA(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3BodyId b3Joint_GetBodyB(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3WorldId b3Joint_GetWorld(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_SetLocalFrameA(b3JointId jointId, b3Transform localFrame);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3Joint_GetLocalFrameA(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_SetLocalFrameB(b3JointId jointId, b3Transform localFrame);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Transform b3Joint_GetLocalFrameB(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_SetCollideConnected(b3JointId jointId, box3dbool shouldCollide);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Joint_GetCollideConnected(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_SetUserData(b3JointId jointId, IntPtr userData);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr b3Joint_GetUserData(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_WakeBodies(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Joint_GetConstraintForce(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3Joint_GetConstraintTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Joint_GetLinearSeparation(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Joint_GetAngularSeparation(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_SetConstraintTuning(b3JointId jointId, float hertz, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_GetConstraintTuning(b3JointId jointId, IntPtr hertz, IntPtr dampingRatio); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_SetForceThreshold(b3JointId jointId, float threshold);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Joint_GetForceThreshold(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3Joint_SetTorqueThreshold(b3JointId jointId, float threshold);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3Joint_GetTorqueThreshold(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateParallelJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3ParallelJoint_SetSpringHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3ParallelJoint_SetSpringDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3ParallelJoint_GetSpringHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3ParallelJoint_GetSpringDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3ParallelJoint_SetMaxTorque(b3JointId jointId, float force);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3ParallelJoint_GetMaxTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateDistanceJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_SetLength(b3JointId jointId, float length);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetLength(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_EnableSpring(b3JointId jointId, box3dbool enableSpring);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3DistanceJoint_IsSpringEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_SetSpringForceRange(b3JointId jointId, float lowerForce, float upperForce);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_GetSpringForceRange(b3JointId jointId, IntPtr lowerForce, IntPtr upperForce); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_SetSpringHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_SetSpringDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetSpringHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetSpringDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_EnableLimit(b3JointId jointId, box3dbool enableLimit);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3DistanceJoint_IsLimitEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_SetLengthRange(b3JointId jointId, float minLength, float maxLength);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetMinLength(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetMaxLength(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetCurrentLength(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_EnableMotor(b3JointId jointId, box3dbool enableMotor);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3DistanceJoint_IsMotorEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_SetMotorSpeed(b3JointId jointId, float motorSpeed);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetMotorSpeed(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3DistanceJoint_SetMaxMotorForce(b3JointId jointId, float force);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetMaxMotorForce(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3DistanceJoint_GetMotorForce(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateMotorJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetLinearVelocity(b3JointId jointId, b3Vec3 velocity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3MotorJoint_GetLinearVelocity(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetAngularVelocity(b3JointId jointId, b3Vec3 velocity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3MotorJoint_GetAngularVelocity(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetMaxVelocityForce(b3JointId jointId, float maxForce);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetMaxVelocityForce(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetMaxVelocityTorque(b3JointId jointId, float maxTorque);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetMaxVelocityTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetLinearHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetLinearHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetLinearDampingRatio(b3JointId jointId, float damping);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetLinearDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetAngularHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetAngularHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetAngularDampingRatio(b3JointId jointId, float damping);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetAngularDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetMaxSpringForce(b3JointId jointId, float maxForce);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetMaxSpringForce(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3MotorJoint_SetMaxSpringTorque(b3JointId jointId, float maxTorque);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3MotorJoint_GetMaxSpringTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateFilterJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreatePrismaticJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_EnableSpring(b3JointId jointId, box3dbool enableSpring);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3PrismaticJoint_IsSpringEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_SetSpringHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetSpringHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_SetSpringDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetSpringDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_SetTargetTranslation(b3JointId jointId, float targetTranslation);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetTargetTranslation(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_EnableLimit(b3JointId jointId, box3dbool enableLimit);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3PrismaticJoint_IsLimitEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetLowerLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetUpperLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_SetLimits(b3JointId jointId, float lower, float upper);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_EnableMotor(b3JointId jointId, box3dbool enableMotor);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3PrismaticJoint_IsMotorEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_SetMotorSpeed(b3JointId jointId, float motorSpeed);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetMotorSpeed(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3PrismaticJoint_SetMaxMotorForce(b3JointId jointId, float force);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetMaxMotorForce(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetMotorForce(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetTranslation(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3PrismaticJoint_GetSpeed(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateRevoluteJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_EnableSpring(b3JointId jointId, box3dbool enableSpring);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3RevoluteJoint_IsSpringEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_SetSpringHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetSpringHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_SetSpringDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetSpringDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_SetTargetAngle(b3JointId jointId, float targetRadians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetTargetAngle(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetAngle(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_EnableLimit(b3JointId jointId, box3dbool enableLimit);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3RevoluteJoint_IsLimitEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetLowerLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetUpperLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_SetLimits(b3JointId jointId, float lowerLimitRadians, float upperLimitRadians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_EnableMotor(b3JointId jointId, box3dbool enableMotor);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3RevoluteJoint_IsMotorEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_SetMotorSpeed(b3JointId jointId, float motorSpeed);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetMotorSpeed(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetMotorTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3RevoluteJoint_SetMaxMotorTorque(b3JointId jointId, float torque);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3RevoluteJoint_GetMaxMotorTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateSphericalJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_EnableConeLimit(b3JointId jointId, box3dbool enableLimit);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3SphericalJoint_IsConeLimitEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetConeLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_SetConeLimit(b3JointId jointId, float angleRadians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetConeAngle(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_EnableTwistLimit(b3JointId jointId, box3dbool enableLimit);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3SphericalJoint_IsTwistLimitEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetLowerTwistLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetUpperTwistLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_SetTwistLimits(b3JointId jointId, float lowerLimitRadians, float upperLimitRadians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetTwistAngle(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_EnableSpring(b3JointId jointId, box3dbool enableSpring);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3SphericalJoint_IsSpringEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_SetSpringHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetSpringHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_SetSpringDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetSpringDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_SetTargetRotation(b3JointId jointId, b3Quat targetRotation);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Quat b3SphericalJoint_GetTargetRotation(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_EnableMotor(b3JointId jointId, box3dbool enableMotor);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3SphericalJoint_IsMotorEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_SetMotorVelocity(b3JointId jointId, b3Vec3 motorVelocity);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3SphericalJoint_GetMotorVelocity(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3Vec3 b3SphericalJoint_GetMotorTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3SphericalJoint_SetMaxMotorTorque(b3JointId jointId, float torque);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3SphericalJoint_GetMaxMotorTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateWeldJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WeldJoint_SetLinearHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WeldJoint_GetLinearHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WeldJoint_SetLinearDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WeldJoint_GetLinearDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WeldJoint_SetAngularHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WeldJoint_GetAngularHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WeldJoint_SetAngularDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WeldJoint_GetAngularDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3JointId b3CreateWheelJoint(b3WorldId worldId, IntPtr def); // WARN_UNKNOWN_POINTER_PARAMETER

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_EnableSuspension(b3JointId jointId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3WheelJoint_IsSuspensionEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetSuspensionHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSuspensionHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetSuspensionDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSuspensionDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_EnableSuspensionLimit(b3JointId jointId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3WheelJoint_IsSuspensionLimitEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetLowerSuspensionLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetUpperSuspensionLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetSuspensionLimits(b3JointId jointId, float lower, float upper);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_EnableSpinMotor(b3JointId jointId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3WheelJoint_IsSpinMotorEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetSpinMotorSpeed(b3JointId jointId, float speed);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSpinMotorSpeed(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetMaxSpinTorque(b3JointId jointId, float torque);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetMaxSpinTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSpinSpeed(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSpinTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_EnableSteering(b3JointId jointId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3WheelJoint_IsSteeringEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetSteeringHertz(b3JointId jointId, float hertz);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSteeringHertz(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetSteeringDampingRatio(b3JointId jointId, float dampingRatio);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSteeringDampingRatio(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetMaxSteeringTorque(b3JointId jointId, float torque);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetMaxSteeringTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_EnableSteeringLimit(b3JointId jointId, box3dbool flag);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3WheelJoint_IsSteeringLimitEnabled(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetLowerSteeringLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetUpperSteeringLimit(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetSteeringLimits(b3JointId jointId, float lowerRadians, float upperRadians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void b3WheelJoint_SetTargetSteeringAngle(b3JointId jointId, float radians);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetTargetSteeringAngle(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSteeringAngle(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float b3WheelJoint_GetSteeringTorque(b3JointId jointId);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial box3dbool b3Contact_IsValid(b3ContactId id);

    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial b3ContactData b3Contact_GetData(b3ContactId contactId);


}
