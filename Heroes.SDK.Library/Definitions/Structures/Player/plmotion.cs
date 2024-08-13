using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Heroes.SDK.Definitions.Structures.Player
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)] //0x70
    public unsafe struct PL_MOTION
    {
        public short thismotdat; // offset 0x0, size 0x2
        public short mtnmode; // offset 0x2, size 0x2
        public short next; // offset 0x4, size 0x2
        public short dummy; // offset 0x6, size 0x2
        public float start; // offset 0x8, size 0x4
        public float end; // offset 0xC, size 0x4
        public float interpolate_delta; // offset 0x10, size 0x4
        public float speed; // offset 0x14, size 0x4
    }
}
