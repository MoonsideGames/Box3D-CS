// NOTE: This file is auto-generated.
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace box3d
{

public static unsafe class box
{
    private static byte* EncodeAsUTF8(string str)
    {
        if (str == null)
        {
            return (byte*) 0;
        }

        var size = (str.Length * 4) + 1;
        var buffer = (byte*) Marshal.AllocHGlobal((UIntPtr) size);
        fixed (char* strPtr = str)
        {
            Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, size);
        }

        return buffer;
    }

    private static string DecodeFromUTF8(IntPtr ptr, bool shouldFree = false)
    {
        if (ptr == IntPtr.Zero)
        {
            return null;
        }

        var end = (byte*) ptr;
        while (*end != 0)
        {
            end++;
        }

        var result = new string(
            (sbyte*) ptr,
            0,
            (int) (end - (byte*)ptr),
            System.Text.Encoding.UTF8
        );

        if (shouldFree)
        {
            SDL_free(ptr);
        }

        return result;
    }

    // Taken from https://github.com/ppy/SDL3-CS
    // C# bools are not blittable, so we need this workaround
    public struct box3dbool
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

        public override bool Equals(object rhs)
        {
            if (rhs is bool)
            {
                return Equals((box3dbool)(bool)rhs);
            }
            else if (rhs is box3dbool)
            {
                return Equals((box3dbool)rhs);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    private const string nativeLibName = "box3d";

    
}
}