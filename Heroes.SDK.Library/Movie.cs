using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Game
{
    public unsafe class Movie
    {
        [Function(CallingConventions.MicrosoftThiscall)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int MoviePlay(int* thisPointer); // 00643DE0

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int MovieEnd(); // 00643E00 
    }
}
