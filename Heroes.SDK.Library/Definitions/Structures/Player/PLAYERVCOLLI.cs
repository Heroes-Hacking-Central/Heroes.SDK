using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Heroes.SDK.Definitions.Structures.Player
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)] //0x70
    public unsafe struct PLAYER_VCOLLI
    {
        public uint Attr_top; // offset 0x0, size 0x4
        public uint _Attr_top; // offset 0x4, size 0x4
        public uint Attr_bottom; // offset 0x8, size 0x4
        public uint _Attr_bottom; // offset 0xC, size 0x4
        public float y_top; // offset 0x10, size 0x4
        public float y_bottom; // offset 0x14, size 0x4
        public int angx; // offset 0x18, size 0x4
        public int angz; // offset 0x1C, size 0x4
        public float scl; // offset 0x20, size 0x4
    };
}
