using Reloaded.Memory.Utilities;
using IEndianConvertible = Heroes.SDK.Utilities.Misc.Interfaces.IEndianConvertible;

namespace Heroes.SDK.Definitions.Structures.Collision.Stage
{
    /// <summary>
    /// Note: Big Endian
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct QuadnodeIndices : IEndianConvertible
    {
        /// <summary>
        /// Unique index of the current node.
        /// </summary>
        public ushort Self;

        /// <summary>
        /// Index of the parent node.
        /// </summary>
        public ushort Parent;

        /// <summary>
        /// The index of the first out of four children of the node, 0 if no child. 
        /// </summary>
        public ushort Child;

        public void SwapEndian()
        {
            Self = Endian.Reverse(Self);
            Parent = Endian.Reverse(Parent);
            Child = Endian.Reverse(Child);
        }
    }
}
