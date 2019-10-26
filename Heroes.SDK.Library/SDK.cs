using System;
using System.Collections.Generic;
using System.Text;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;

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
        /// Initializes the Heroes SDK as a Reloaded II mod, setting the shared library to be used.
        /// </summary>
        public static void Init(IReloadedHooks hooks)
        {
            ReloadedHooks = hooks;
        }
    }
}
