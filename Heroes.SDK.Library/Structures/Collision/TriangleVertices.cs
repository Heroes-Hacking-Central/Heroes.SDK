using Heroes.SDK.Utility.Interfaces;
using Reloaded.Memory;

namespace Heroes.SDK.Stage.Collision.Structures
{
    /// <summary>
    /// Note: Triangle vertices have no specific order.
    /// Note: Big Endian
    /// </summary>
    public struct TriangleVertices : IEndianConvertible
    {
        /// <summary>
        /// Index of the first vertex of the triangle.
        /// </summary>
        public ushort One;

        /// <summary>
        /// Index of the second vertex of the triangle.
        /// </summary>
        public ushort Two;

        /// <summary>
        /// Index of the third vertex of the triangle.
        /// </summary>
        public ushort Three;

        public void SwapEndian()
        {
            Endian.Reverse(ref One);
            Endian.Reverse(ref Two);
            Endian.Reverse(ref Three);
        }
    }
}
