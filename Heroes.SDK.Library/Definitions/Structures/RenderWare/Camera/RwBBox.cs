using System.Numerics;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Camera
{
    /// <summary>
    /// This type represents a 3D axis-aligned bounding-box
    /// specified by the positions of two corners which lie on a diagonal.
    /// Typically used to specify a world bounding-box when the world is created
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct RwBBox
    {
        /* Must be in this order */

        /// <summary>
        /// Supremum vertex. (contains largest values)
        /// </summary>
        Vector3 Supremum;

        /// <summary>
        /// Infimum vertex.  (contains smallest values)
        /// </summary>
        Vector3 Infimum;
    };
}
