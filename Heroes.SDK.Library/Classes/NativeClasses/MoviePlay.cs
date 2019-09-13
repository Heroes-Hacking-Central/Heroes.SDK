using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;

// ReSharper disable InconsistentNaming

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct MoviePlay
    {
        public static Function<Native_Play> Fun_Play { get; } = new Function<Native_Play>(0x00643DE0, ReloadedHooks.Instance);
        public static Function<Native_Loop> Fun_Loop { get; } = new Function<Native_Loop>(0x00643E20, ReloadedHooks.Instance);
        public static Function<Native_End> Fun_End { get; } = new Function<Native_End>(0x00643E00, ReloadedHooks.Instance);

        /* Functions */
        public int Play() => Fun_Play.GetWrapper()(ref this);
        public int Loop() => Fun_Loop.GetWrapper()();
        public int End() => Fun_End.GetWrapper()();

        /* Function Mapping */
        [Function(CallingConventions.MicrosoftThiscall)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int Native_Play(ref MoviePlay thisPointer); // 00643DE0

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int Native_Loop(); // 00643E20

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int Native_End(); // 00643E00 

        // TODO: These remaining functions below are placed here by guess, I have not yet
    }
}
