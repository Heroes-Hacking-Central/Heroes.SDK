using Reloaded.Memory.Utilities;
using IEndianConvertible = Heroes.SDK.Utilities.Misc.Interfaces.IEndianConvertible;

namespace Heroes.SDK.Definitions.Structures.Collision.Stage
{
    /// <summary>
    /// Note: Big Endian
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct QuadnodeNeighbours : IEndianConvertible
    {
        /// <summary>
        /// Index of the right neighbour to the current node. 0 if edge/none.
        /// It can be either at the at the same or at another depth level.
        /// </summary>
        public ushort RightNeightbour;

        /// <summary>
        /// Index of the left neighbour to the current node. 0 if edge/none.
        /// It can be either at the at the same or at another depth level.
        /// </summary>
        public ushort LeftNeightbourIndex;

        /// <summary>
        /// Index of the bottom neighbour to the current node. 0 if edge/none.
        /// It can be either at the at the same or at another depth level.
        /// </summary>
        public ushort BottomNeighbourIndex;

        /// <summary>
        /// Index of the top neighbour to the current node.0 if edge/none.
        /// It can be either at the at the same or at another depth level.
        /// </summary>
        public ushort TopNeighbourIndex;

        public void SwapEndian()
        {
            RightNeightbour = Endian.Reverse(RightNeightbour);
            LeftNeightbourIndex = Endian.Reverse(LeftNeightbourIndex);
            BottomNeighbourIndex = Endian.Reverse(BottomNeighbourIndex);
            TopNeighbourIndex = Endian.Reverse(TopNeighbourIndex);
        }
    }
}
