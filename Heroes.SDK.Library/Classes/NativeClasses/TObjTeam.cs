using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct TObjTeam
    {
        public static IFunction<Native_Exec> Fun_Exec { get; } = SDK.ReloadedHooks.CreateFunction<Native_Exec>(0x005B10E0);

        /* Bindings */
        public void* Exec()
        {
            return Fun_Exec.GetWrapper()(ref this);
        }

        /* Definitions */
        [Function(CallingConventions.MicrosoftThiscall)]
        public delegate void* Native_Exec(ref TObjTeam thisPointer);
    }
}
