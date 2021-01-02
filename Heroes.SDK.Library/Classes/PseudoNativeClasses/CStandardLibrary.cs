using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    public unsafe class CStandardLibrary
    {
        public static IFunction<Native_Free> Fun_Free = SDK.ReloadedHooks.CreateFunction<Native_Free>(0x0067B35D);
        public static Native_Free Free { get; } = Fun_Free.GetWrapper();

        /// <summary>
        /// Frees a given block of memory.
        /// </summary>
        /// <param name="memoryAddress">Address of the block of memory.</param>
        [Function(CallingConventions.Cdecl)]
        public delegate void Native_Free(void* memoryAddress);
    }
}
