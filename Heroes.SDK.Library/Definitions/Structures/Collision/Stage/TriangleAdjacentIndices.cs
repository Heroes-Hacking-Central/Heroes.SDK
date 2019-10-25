using Reloaded.Memory;
using IEndianConvertible = Heroes.SDK.Utilities.Misc.Interfaces.IEndianConvertible;

namespace Heroes.SDK.Definitions.Structures.Collision.Stage
{
    /// <summary>
    /// Contains the indices of the triangles adjacent to this triangle.
    /// If none, specify 65535.
    /// Note: Big Endian
    /// </summary>
    public struct TriangleAdjacentIndices : IEndianConvertible
    {
        /// <summary>
        /// The default value if no index is specified.
        /// </summary>
        public const ushort None = 65535;

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

        public TriangleAdjacentIndices(ushort one, ushort two, ushort three)
        {
            One = one;
            Two = two;
            Three = three;
        }

        public void SwapEndian()
        {
            Endian.Reverse(ref One);
            Endian.Reverse(ref Two);
            Endian.Reverse(ref Three);
        }
    }
}
