using Reloaded.Memory;
using Reloaded.Memory.Utilities;
using IEndianConvertible = Heroes.SDK.Utilities.Misc.Interfaces.IEndianConvertible;

namespace Heroes.SDK.Definitions.Structures.Collision.Stage
{
    /// <summary>
    /// Note: Triangle vertices have no specific order.
    /// Note: Big Endian
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
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
            One = Endian.Reverse(One);
            Two = Endian.Reverse(Two);
            Three = Endian.Reverse(Three);
        }
    }
}
