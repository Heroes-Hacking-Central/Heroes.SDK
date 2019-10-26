using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;

// ReSharper disable InconsistentNaming

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct MoviePlay
    {
        public static IFunction<Native_Play> Fun_Play { get; } = SDK.ReloadedHooks.CreateFunction<Native_Play>(0x00643DE0);
        public static IFunction<Native_Loop> Fun_Loop { get; } = SDK.ReloadedHooks.CreateFunction<Native_Loop>(0x00643E20);
        public static IFunction<Native_End> Fun_End { get; } = SDK.ReloadedHooks.CreateFunction<Native_End>(0x00643E00);

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
