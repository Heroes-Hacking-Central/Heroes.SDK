using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    /// <summary>
    /// All functions related to drawing the HUD.
    /// </summary>
    public class HudFunctions
    {
        /* Function Declarations */
        public static IFunction<DispGDisp> Fun_DrawHud { get; } = SDK.ReloadedHooks.CreateFunction<DispGDisp>(0x0041DFD0);

        /* Function Definitions */

        /// <summary>
        /// Draws the heads up display over game content.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate int DispGDisp();
    }
}
