using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Arbitrary
{
    [Equals(DoNotAddEqualityOperators =true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x5C)]
    public unsafe struct RwViewport
    {
        [FieldOffset(0x0)]
        public RwViewport* Parent;

        [FieldOffset(0x4)]
        public int unk_4;

        [FieldOffset(0x8)]
        public int unk_8;

        [FieldOffset(0xC)]
        public int Width; // Used by player one

        [FieldOffset(0x10)]
        public int Height; // Used by player one

        [FieldOffset(0x14)]
        public int Unknown; // Default: 32

        [FieldOffset(0x18)]
        public int Unknown2; // Default: 32

        [FieldOffset(0x1C)]
        public short OffsetX;  // X offset of viewport relative to screen.

        [FieldOffset(0x1E)]
        public short OffsetY;  // Y offset of viewport relative to screen.
    }
}