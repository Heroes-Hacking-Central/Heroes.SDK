﻿using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.RenderWare.Arbitrary;
using Heroes.SDK.Definitions.Structures.RenderWare.Camera;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    /// <summary>
    /// Contains the RenderWare Graphics C API.
    /// </summary>
    public unsafe struct RenderWareFunctions
    {
        /* Function Declarations */
        public static Function<Native_RwCameraSetViewWindow> Fun_RwCameraSetViewWindow { get; } = new Function<Native_RwCameraSetViewWindow>(0x0064AC80, Reloaded.ReloadedHooks);
        public static Function<Native_CameraBuildPerspClipPlanes> Fun_CameraBuildPerspClipPlanes { get; } = new Function<Native_CameraBuildPerspClipPlanes>(0x0064AF80, Reloaded.ReloadedHooks);
        public static Function<Native_GetVertexBufferSubmission> Fun_GetVertexBufferSubmission { get; } = new Function<Native_GetVertexBufferSubmission>(0x651E20, Reloaded.ReloadedHooks);
        public static Function<Native_rwD3D8Im2DRenderPrimitive> Fun_D3D8Im2DRenderPrimitive { get; } = new Function<Native_rwD3D8Im2DRenderPrimitive>(0x00662B00, Reloaded.ReloadedHooks);

        /* Function Definitions */

        /// <summary>
        /// Sets the "view window (coordinates visible by the user)" of the current screen view.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate void Native_RwCameraSetViewWindow(RwCamera* rwCamera, RwView* view);

        /// <summary>
        /// Builds the clip planes for the perspective projection which declare which objects should be rendered and which should not.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate int Native_CameraBuildPerspClipPlanes(RwCamera* rwCamera);

        /* Definitions with Unknown Names */

        /// <summary>
        /// Retrieves the details of a RenderWare vertex buffer submission.
        /// </summary>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate VertexBufferSubmission* Native_GetVertexBufferSubmission(); // Gets vertex buffer submission ptr

        /// <summary>
        /// Renders a 2D primitive to the front of the screen using an orthogonal projection.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate bool Native_rwD3D8Im2DRenderPrimitive(int a1, char* a2, int a3);
    }
}