using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.Input;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.NativeClasses
{
    /// <summary>
    /// Disasm name: sGamePeri
    /// </summary>
    public unsafe struct GamePeri
    {
        /* Function Definitions */

        public static Function<Native_MakeRepeatCount> Fun_MakeRepeatCount { get; } = new Function<Native_MakeRepeatCount>(0x00434FF0, Reloaded.ReloadedHooks);
        public static Function<Native_ConvertPadData>  Fun_ConvertPadData  { get; } = new Function<Native_ConvertPadData>(0x004351A0, Reloaded.ReloadedHooks);

        /* Function Declarations */

        /// <summary>
        /// Increments the repetition count (how many frames the buttons are held) for all buttons.
        /// </summary>
        /// <param name="skyPad">Input structure used to control the game. Can be for any player 1 - player 4.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { FunctionAttribute.Register.eax, }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller)]
        public delegate SkyPad* Native_MakeRepeatCount(SkyPad* skyPad); // 00434FF0

        /// <summary>
        /// Note: Has hooking problems.
        /// Converts the <see cref="HeroesController"/> structure provided by pointer into the <see cref="SkyPad"/> structure
        /// provided by pointer.
        /// </summary>
        /// <param name="heroesController">Input structure used to gather controls from DInput. Can be for any player 1 - player 4.</param>
        /// <param name="skyPad">Input structure used to control the game. Can be for any player 1 - player 4.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { FunctionAttribute.Register.edi, FunctionAttribute.Register.esi }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller)]
        public delegate SkyPad* Native_ConvertPadData(HeroesController* heroesController, SkyPad* skyPad); // 004351A0
    }
}
