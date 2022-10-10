using System.Runtime.CompilerServices;
using csharp_prs_interfaces;
using Reloaded.Hooks.Definitions;

#if NET5_0_OR_GREATER
    [module: SkipLocalsInit]
#endif

namespace Heroes.SDK
{
    public static class SDK
    {
        /// <summary>
        /// Singular source of Reloaded.Hooks library.
        /// Can be replaced with shared library at runtime.
        /// </summary>
        public static IReloadedHooks ReloadedHooks { get; private set; }

        /// <summary>
        /// Singular source of csharp-prs library.
        /// Can be replaced with shared library at runtime.
        /// </summary>
        public static IPrsInstance Prs { get; private set; }

        /// <summary>
        /// Initializes the Heroes SDK as a Reloaded II mod, setting the shared library to be used.
        /// </summary>
        public static void Init(IReloadedHooks hooks, IPrsInstance prs)
        {
            ReloadedHooks = hooks;
            Prs = prs;
        }
    }
}
