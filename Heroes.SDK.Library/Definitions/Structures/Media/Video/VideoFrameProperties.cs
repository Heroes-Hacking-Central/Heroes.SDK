using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Heroes.SDK.Definitions.Structures.Media.Video
{
    [StructLayout(LayoutKind.Explicit)]
    public struct VideoRenderProperties
    {
        [FieldOffset(0x4)]
        public int EasyMenuFlag;

        [FieldOffset(0x14)]
        public int SmallFrameMode;

        [FieldOffset(0x18)]
        public int FramesRendered;

        [FieldOffset(0x24)]
        public int FramesLeft;
    }
}
