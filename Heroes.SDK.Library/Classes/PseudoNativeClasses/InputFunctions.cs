using System.Runtime.InteropServices;
using Heroes.SDK.Classes.NativeClasses;
using Heroes.SDK.Definitions.Structures.Input;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    public unsafe class InputFunctions
    {
        private const int NumberOfControllers = 4;

        /// <summary>
        /// Platform specific of inputs from DInput read by the game at the end of the last frame.
        /// Note: Game does not use these inputs directly. They are converted into the structure at <see cref="GamePeri.FinalInputs"/>.
        /// </summary>
        public static RefFixedArrayPtr<HeroesController> Inputs { get; } = new RefFixedArrayPtr<HeroesController>(0x00A2F948, NumberOfControllers);

        /// <summary>
        /// Platform independent array of inputs used by the game code to control everything.
        /// These inputs are used to control the actual game.
        /// </summary>
        public static RefFixedArrayPtr<SkyPad> FinalInputs { get; } = new RefFixedArrayPtr<SkyPad>(0x00A23A68, NumberOfControllers);

        // Function Declarations
        public static IFunction<psPADServerPC> Fun_psPADServerPC { get; } = SDK.ReloadedHooks.CreateFunction<psPADServerPC>(0x00444F30);

        // Function Definitions 

        /// <summary>
        /// (Named after PS2 SDK Internal name/PS2 disasm)
        /// Obtains the inputs from connected directinput devices and writes them to the <see cref="InputFunctions.Inputs"/>.
        /// </summary>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate int psPADServerPC(); // 00444F30
    }
}
