using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct TObjCamera
    {
        /* Function Declarations */
        public static IFunction<Native_Init> Fun_Init { get; } = SDK.ReloadedHooks.CreateFunction<Native_Init>(0x0061D3B0);

        /* Function Definitions */

        /// <summary>
        /// Constructs/Initializes an instance of TObjCamera
        /// </summary>
        /// <param name="thisPointer">Pre-allocated memory for this camera instance.</param>
        /// <param name="camLimit">The amount of cameras to create.</param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(FunctionAttribute.Register.eax, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate int Native_Init(TObjCamera* thisPointer, int camLimit);
    }
}