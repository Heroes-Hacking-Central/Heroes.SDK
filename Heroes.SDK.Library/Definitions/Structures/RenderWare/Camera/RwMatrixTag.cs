using System.Numerics;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Camera
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RwMatrixTag
    {
        public Vector3 Right;
        public uint Flags;

        public Vector3 Up;
        public uint padding1;

        public Vector3 At;
        public uint padding2;

        public Vector3 Position;
        public uint padding3;
    };
}
