using Reloaded.Memory;
using System.Numerics;
using System.Runtime.InteropServices;
using Reloaded.Memory.Extensions;
using Reloaded.Memory.Utilities;
using IEndianConvertible = Heroes.SDK.Utilities.Misc.Interfaces.IEndianConvertible;

namespace Heroes.SDK.Definitions.Structures.Collision.Stage
{
    /// <summary>
    /// Disassembly/Internal Name: OCTREE_FILE_HEADER
    /// Note: Big Endian
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct QuadtreeFileHeader : IEndianConvertible
    {
        /// <summary>
        /// The length of the file in bytes.
        /// </summary>
        public uint NumberOfBytes;

        /// <summary>
        /// The offset at which the quadtree section starts in the file.
        /// </summary>
        public uint QuadtreeOffset;

        /// <summary>
        /// Offset to the triangle section defining the triangles and their vertices.
        /// </summary>
        public uint TriangleOffset;

        /// <summary>
        /// Offset to the vertex section containing <see cref="Vector3"/>s.
        /// </summary>
        public uint VertexOffset;

        /// <summary>
        /// Defines the center position of this quadtree.
        /// </summary>
        public Vector3 QuadtreeCenter;

        /// <summary>
        /// Defines the size of the quadtree, equal to the two most displaced vertices in any axis.
        /// </summary>
        public float QuadtreeSize;

        /// <summary>
        /// The base Offset Power Level for the quadnode structure.
        /// See: SCHG Sonic Heroes
        /// </summary>
        public ushort BasePower;

        /// <summary>
        /// The amount of entries in the triangle <see cref="TriangleOffset"/> section.
        /// </summary>
        public ushort NumTriangles;

        /// <summary>
        /// The amount of entries in the vertex <see cref="VertexOffset"/> section.
        /// </summary>
        public ushort NumVertices;

        /// <summary>
        /// The amount of entries in the quadnode <see cref="QuadtreeOffset"/> section.
        /// </summary>
        public ushort NumNodes;

        public void SwapEndian()
        {
            NumberOfBytes = Endian.Reverse(NumberOfBytes);

            QuadtreeOffset = Endian.Reverse(QuadtreeOffset);
            TriangleOffset = Endian.Reverse(TriangleOffset);
            VertexOffset = Endian.Reverse(VertexOffset);

            QuadtreeCenter.X = Endian.Reverse(QuadtreeCenter.X);
            QuadtreeCenter.Y = Endian.Reverse(QuadtreeCenter.Y);
            QuadtreeCenter.Z = Endian.Reverse(QuadtreeCenter.Z);
            QuadtreeSize = Endian.Reverse(QuadtreeSize);

            BasePower = Endian.Reverse(BasePower);
            NumTriangles = Endian.Reverse(NumTriangles);
            NumVertices = Endian.Reverse(NumVertices);
            NumNodes = Endian.Reverse(NumNodes);
        }
    }
}
