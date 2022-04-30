using System.Numerics;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Camera
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct RwPlane
    {
        /// <summary>
        /// Normal to the plane.
        /// </summary>
        public Vector3 Normal;

        /// <summary>
        /// Distance to plane from origin in normal direction.
        /// </summary>
        public float Distance;
    };
}
