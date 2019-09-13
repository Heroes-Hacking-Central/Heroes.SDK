using System.Runtime.InteropServices;
using Heroes.SDK.Utility.Interfaces;
using Reloaded.Memory;

namespace Heroes.SDK.Definitions.Structures.Collision.Stage
{
    /// <summary>
    /// Defines an individual quadnode in the collision file.
    /// Note: Big Endian
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public struct Quadnode : IEndianConvertible
    {
        /// <summary>
        /// Contains the index of the self, parent and child nodes.
        /// </summary>
        public QuadnodeIndices Indices;

        /// <summary>
        /// Stores index of neighbouring nodes.
        /// </summary>
        public QuadnodeNeighbours Neighbours;

        /// <summary>
        /// Number of triangles in this quadnode.
        /// </summary>
        public ushort NumTriangles;

        /// <summary>
        /// Offset in triangle list relative to the end of the file header (<see cref="QuadtreeFileHeader"/>).
        /// </summary>
        public int OffsetTriangleList;

        /// <summary>
        /// The offset positioning value of the node in the horizontal direction.
        /// Calculated by: 2^(base power-depth level) + Parent's Offset Value, depending on the node. See SCHG!
        /// </summary>
        public ushort PositioningHorizontalOffset;

        /// <summary>
        /// The offset positioning value of the node in the vertical direction.
        /// Calculated by: 2^(base power-depth level) + Parent's Offset Value, depending on the node. See SCHG!
        /// </summary>
        public ushort PositioningVerticalOffset;

        /// <summary>
        /// The individual depth level of the QuadNode.
        /// </summary>
        public byte DepthLevel;

        public void SwapEndian()
        {
            Indices.SwapEndian();
            Neighbours.SwapEndian();

            Endian.Reverse(ref NumTriangles);
            Endian.Reverse(ref OffsetTriangleList);
            Endian.Reverse(ref PositioningHorizontalOffset);
            Endian.Reverse(ref PositioningVerticalOffset);
        }
    }
}
