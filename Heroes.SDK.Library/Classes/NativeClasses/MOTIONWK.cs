using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.RenderWare;

namespace Heroes.SDK.Classes.NativeClasses
{
    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public unsafe struct MOTIONWK
    {
        [FieldOffset(0x0)]
        public RwV3d spd; // offset 0x0, size 0xC
        [FieldOffset(0xC)]
        public RwV3d acc; // offset 0xC, size 0xC
        [FieldOffset(0x18)]
        public sAngle ang_aim; // offset 0x18, size 0xC
        [FieldOffset(0x24)]
        public sAngle ang_spd; // offset 0x24, size 0xC
        [FieldOffset(0x30)]
        float force;
        [FieldOffset(0x34)]
        float accel;
        [FieldOffset(0x38)]
        float frict;
    }

}