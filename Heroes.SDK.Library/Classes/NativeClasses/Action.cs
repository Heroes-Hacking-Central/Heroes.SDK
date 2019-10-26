using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct Action
    {
        /* Function Declarations */
        public static Function<Exec> Fun_Exec { get; } = new Function<Exec>(0x00402CA0, Reloaded.ReloadedHooks);

        /* Function Definitions */
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(FunctionAttribute.Register.eax, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller)]
        public delegate void Exec(int* a1);
    }
}