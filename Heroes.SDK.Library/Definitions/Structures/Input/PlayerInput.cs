using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Heroes.SDK.Definitions.Enums;

namespace Heroes.SDK.Definitions.Structures.Input
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential, Size = 0x1)]
    public unsafe struct PL_BUTTON_STATUS
    {
        public BTN_STATUS status; // offset 0x0, size 0x1
    };

    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct PLAYER_INPUT
    {
        [FieldOffset(0x0)]
        public float stroke; // offset 0x0, size 0x4
        [FieldOffset(0x4)]
        public int angle; // offset 0x4, size 0x4
        [FieldOffset(0x8)]
        public byte lever_gotcha; // offset 0x8, size 0x1
        [FieldOffset(0x9)]
        public PL_BUTTON_STATUS jump; // offset 0x9, size 0x1
        [FieldOffset(0xA)]
        public PL_BUTTON_STATUS action; // offset 0xA, size 0x1
        [FieldOffset(0xB)]
        public PL_BUTTON_STATUS sfa; // offset 0xB, size 0x1
        [FieldOffset(0xC)]
        public PL_BUTTON_STATUS change_leader; // offset 0xC, size 0x1
        [FieldOffset(0xD)]
        public PL_BUTTON_STATUS change_leaderR; // offset 0xD, size 0x1
    };
}
