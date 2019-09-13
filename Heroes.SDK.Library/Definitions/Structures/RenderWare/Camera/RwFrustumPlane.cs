using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Camera
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RwFrustumPlane
    {
        public RwPlane Plane;
        public byte ClosestX;
        public byte ClosestY;
        public byte ClosestZ;
        public byte Padding;
    };
}
