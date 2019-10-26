using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct TObjTeam
    {
        public static Function<Native_Exec> Fun_Exec { get; } = new Function<Native_Exec>(0x005B10E0, Reloaded.ReloadedHooks);

        /* Bindings */
        public void* Exec()
        {
            return Fun_Exec.GetWrapper()(ref this);
        }

        /* Definitions */
        [Function(CallingConventions.MicrosoftThiscall)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void* Native_Exec(ref TObjTeam thisPointer);
    }
}
