using Heroes.SDK.Definitions.Structures.RenderWare.Camera.Enum;
using System.Numerics;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Camera
{
    [Equals(DoNotAddEqualityOperators = true)]
    public unsafe struct RwCamera
    {
        public RwObjectHasFrame OnjectHasFrame;

        /// <summary>
        /// Parallel or perspective projection.
        /// </summary>
        public RwCameraProjection ProjectionType;

        /* Start/end update functions */

        /// <summary>
        /// RwCameraBeginUpdateFunc
        /// </summary>
        public void* BeginUpdate;  // RwCameraBeginUpdateFunc

        /// <summary>
        /// RwCameraEndUpdateFunc
        /// </summary>
        public void* EndUpdate;    // RwCameraEndUpdateFunc

        /* The view matrix */
        public RwMatrixTag ViewMatrix;

        /* The cameras image buffer */
        public void* FrameBuffer;

        /* The Z buffer */
        public void* ZBuffer;

        /* Camera's mathmatical characteristics */
        public Vector2 ViewWindow;
        public Vector2 RecipViewWindow;
        public Vector2 ViewOffset;
        public float NearPlane;
        public float FarPlane;
        public float FogPlane;

        /* Transformation to turn camera z or 1/z into a Z buffer z */
        public float ZScale;
        public float ZShift;

        /* The clip-planes making up the viewing frustum */
        public RwFrustumPlane FrustumPlane1;
        public RwFrustumPlane FrustumPlane2;
        public RwFrustumPlane FrustumPlane3;
        public RwFrustumPlane FrustumPlane4;
        public RwFrustumPlane FrustumPlane5;
        public RwFrustumPlane FrustumPlane6;
        public RwBBox FrustumBoundBox;

        /* Points on the tips of the view frustum */
        public Vector3 FrustumCorner1;
        public Vector3 FrustumCorner2;
        public Vector3 FrustumCorner3;
        public Vector3 FrustumCorner4;
        public Vector3 FrustumCorner5;
        public Vector3 FrustumCorner6;
        public Vector3 FrustumCorner7;
        public Vector3 FrustumCorner8;

        /* Custom functionality */

        /// <summary>
        /// Stretches the view window.
        /// </summary>
        /// <param name="actualAspect">The actual aspect ratio of the window.</param>
        /// <param name="relativeAspectRatio">The relative aspect compared to the game's intended aspect.</param>
        /// <param name="aspectLimit">Stretch X (width) if above this, else stretch Y.</param>
        public void StretchViewWindow(float actualAspect, float relativeAspectRatio, float aspectLimit)
        {
            if (actualAspect > aspectLimit)
                ViewWindow.X = ViewWindow.X * relativeAspectRatio; // Hor+
            else
                ViewWindow.Y = ViewWindow.Y / relativeAspectRatio; // Vert+
        }

        /// <summary>
        /// Stretches the recipient view window.
        /// What RenderWare (presumably) assumes as the view window that is visible by the user.
        /// </summary>
        /// <param name="actualAspect">The actual aspect ratio of the window.</param>
        /// <param name="relativeAspectRatio">The relative aspect compared to the game's intended aspect.</param>
        /// <param name="aspectLimit">Stretch X (width) if above this, else stretch Y.</param>
        public void StretchRecipViewWindow(float actualAspect, float relativeAspectRatio, float aspectLimit)
        {
            if (actualAspect > aspectLimit)
                RecipViewWindow.X = RecipViewWindow.X * relativeAspectRatio; // Hor+
            else
                RecipViewWindow.Y = RecipViewWindow.Y / relativeAspectRatio; // Vert+
        }

        /// <summary>
        /// Unstretches the view window.
        /// </summary>
        /// <param name="actualAspect">The actual aspect ratio of the window.</param>
        /// <param name="relativeAspectRatio">The relative aspect compared to the game's intended aspect.</param>
        /// <param name="aspectLimit">Unstretch X (width) if above this, else unstretch Y.</param>
        public void UnStretchViewWindow(float actualAspect, float relativeAspectRatio, float aspectLimit)
        {
            StretchViewWindow(actualAspect, 1 / relativeAspectRatio, aspectLimit);
        }

        /// <summary>
        /// Unstretches the recipient view window.
        /// What RenderWare (presumably) assumes as the view window that is visible by the user.
        /// </summary>
        /// <param name="actualAspect">The actual aspect ratio of the window.</param>
        /// <param name="relativeAspectRatio">The relative aspect compared to the game's intended aspect.</param>
        /// <param name="aspectLimit">Unstretch X (width) if above this, else unstretch Y.</param>
        public void UnStretchRecipViewWindow(float actualAspect, float relativeAspectRatio, float aspectLimit)
        {
            StretchRecipViewWindow(actualAspect, 1 / relativeAspectRatio, aspectLimit);
        }
    }
}
