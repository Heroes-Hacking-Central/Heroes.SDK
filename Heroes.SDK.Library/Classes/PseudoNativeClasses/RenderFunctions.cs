﻿using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    /// <summary>
    /// Contains all non-RenderWare functions used for drawing screen elements.
    /// </summary>
    public class RenderFunctions
    {
        /* Function Definitions */
        public static Function<EndFrame> Fun_EndFrame { get; } = new Function<EndFrame>(0x00443110, Reloaded.ReloadedHooks);

        /// <summary>
        /// Obtains inputs, runs some code and sleeps for the remainder of the frame.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate int EndFrame(); // 00443110
    }
}