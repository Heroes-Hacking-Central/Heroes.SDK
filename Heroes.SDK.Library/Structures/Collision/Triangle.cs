using System.Numerics;
using Heroes.SDK.Utility.Interfaces;
using Reloaded.Memory;

namespace Heroes.SDK.Stage.Collision.Structures
{
    /// <summary>
    /// Note: Big Endian
    /// </summary>
    public struct Triangle : IEndianConvertible
    {
        /// <summary>
        /// The indexes of vertices used to define this triangle.
        /// </summary>
        public TriangleVertices Indices;

        /// <summary>
        /// Indexes of triangles that are adjacent to this triangle.
        /// Adjacent triangles share 2 vertices with the current triangle.
        /// Default value is 0xFFFF.
        /// </summary>
        public TriangleAdjacentIndices Adjacents;

        /// <summary>
        /// Contains a normalized unit vector, perpendicular in direction to the surface of the triangle.
        /// </summary>
        public Vector3 NormalUnitVector;

        /// <summary>
        /// The primary collision flags for the object.
        /// These are believed to override the secondary flags.
        /// </summary>
        public TriangleCollisionProperties FlagsPrimary;

        /// <summary>
        /// The secondary flags for the object.
        /// </summary>
        public TriangleCollisionProperties FlagsSecondary;

        public void SwapEndian()
        {
            Indices.SwapEndian();
            Adjacents.SwapEndian();

            Endian.Reverse(ref NormalUnitVector.X);
            Endian.Reverse(ref NormalUnitVector.Y);
            Endian.Reverse(ref NormalUnitVector.Z);
        }
    }
}
