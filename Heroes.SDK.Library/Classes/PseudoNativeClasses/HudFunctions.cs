using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    /// <summary>
    /// All functions related to drawing the HUD.
    /// </summary>
    public class HudFunctions
    {
        /* Function Declarations */
        public static Function<DispGDisp> Fun_DrawHud { get; } = new Function<DispGDisp>(0x0041DFD0, ReloadedHooks.Instance);

        /* Function Definitions */

        /// <summary>
        /// Draws the heads up display over game content.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate int DispGDisp();
    }
}
