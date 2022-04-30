using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute;

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct Action
    {
        /* Function Declarations */
        public static IFunction<Exec> Fun_Exec { get; } = SDK.ReloadedHooks.CreateFunction<Exec>(0x00402CA0);

        /* Function Definitions */
        [Function(Register.eax, Register.eax, StackCleanup.Caller)]
        public delegate void Exec(int* a1);
    }
}