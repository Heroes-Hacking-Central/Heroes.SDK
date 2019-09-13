using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Arbitrary
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct RwGraphicsInstance
    {
        [FieldOffset(0x60)]
        public RwViewport* ScreenViewport;

        [FieldOffset(0x64)]
        public RwViewportCollection* AllViewPorts;

        [FieldOffset(0x70)]
        public float MenuYScale;

        [FieldOffset(0x74)]
        public float MenuXScale;
    }
}