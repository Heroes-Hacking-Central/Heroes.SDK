using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Arbitrary
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct VertexBufferSubmissionDetails
    {
        [FieldOffset(0x8)]
        public short Width;

        [FieldOffset(0xC)]
        public short Height;

        [FieldOffset(0x1C)]
        public short X;

        [FieldOffset(0x1E)]
        public short Y;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct VertexBufferSubmission
    {
        [FieldOffset(0x60)]
        public VertexBufferSubmissionDetails* SubmissionThing;
    }
}
