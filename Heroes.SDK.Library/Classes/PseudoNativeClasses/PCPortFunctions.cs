using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    public unsafe struct PcPortFunctions
    {
        /* Function Declarations */
        public static IFunction<Native_ReadConfigfromINI> Fun_ReadConfigfromINI { get; } = SDK.ReloadedHooks.CreateFunction<Native_ReadConfigfromINI>(0x00629CE0);
        
        /* Function Definitions */

        /// <summary>
        /// Reads the default game configuration from an INI file and applies it to game memory.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(Register.eax, Register.eax, StackCleanup.Callee)]
        public delegate int Native_ReadConfigfromINI(char* configPath);
    }
}
