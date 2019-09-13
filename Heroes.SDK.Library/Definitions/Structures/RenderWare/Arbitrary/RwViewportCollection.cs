using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Arbitrary
{
    /// <summary>
    /// This is technically a possibly endless array of viewports. The struct is for convenience only.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct RwViewportCollection
    {
        /* Hidden Viewport? */
        [FieldOffset(0x0)]
        public RwViewport UnknownViewPort; // ?

        [FieldOffset(0x5C)]
        public RwViewport P1Viewport;  // Used by player one

        [FieldOffset(0xB8)]
        public RwViewport P1UnknownViewport;  // Unused

        [FieldOffset(0x114)]
        public RwViewport P2Viewport; // Used by player two

        [FieldOffset(0x170)]
        public RwViewport P2UnknownViewport; // Unused

        [FieldOffset(0x1CC)]
        public RwViewport P3Viewport; // Used by player three

        [FieldOffset(0x228)]
        public RwViewport P3UnknownViewport; // Unused

        [FieldOffset(0x284)]
        public RwViewport P4Viewport; // Used by player four

        [FieldOffset(0x2E0)]
        public RwViewport P4UnknownViewport; // Unused

    }
}