using System;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Camera.Enum
{
    public enum RwCameraProjection : int
    {
        /// <summary>
        /// Invalid Projection
        /// </summary>
        RwNacameraprojection = 0,

        /// <summary>
        /// Perspecfive projection.
        /// </summary>
        RwPerspective = 1,

        /// <summary>
        /// Parallel projection.
        /// </summary>
        RwParallel = 2,
        RwCameraprojectionforceenumsizeint = Int32.MaxValue
    };
}
