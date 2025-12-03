using System.Runtime.InteropServices;
using System.Numerics;

namespace Heroes.SDK.Classes.NativeClasses
{
    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public unsafe struct MOTIONWK
    {
        [FieldOffset(0x0)]
        public Vector3 spd; // offset 0x0, size 0xC
        [FieldOffset(0xC)]
        public Vector3 acc; // offset 0xC, size 0xC
        [FieldOffset(0x18)]
        public Vector3 ang_aim; // offset 0x18, size 0xC
        [FieldOffset(0x24)]
        public Vector3 ang_spd; // offset 0x24, size 0xC
        [FieldOffset(0x30)]
        float force;
        [FieldOffset(0x34)]
        float accel;
        [FieldOffset(0x38)]
        float frict;
    }

}