using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.Input.Custom;

namespace Heroes.SDK.Definitions.Structures.Input
{
    /// <summary>
    /// The internal structure consumed by the game logic which actually determines the behaviour of the game.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 0x4C)]
    public struct SkyPad
    {
        /// <summary>
        /// Defines which buttons are currently held during this frame.
        /// </summary>
        public ButtonFlags ButtonFlags;

        /// <summary>
        /// Purpose unknown: Value is `-1 - <see cref="ButtonFlags"/>`
        /// </summary>
        public int MinusOneMinusButtonFlags;

        /// <summary>
        /// Contains the buttons that were pressed this frame.
        /// </summary>
        public ButtonFlags OneFramePressButtonFlags;
        
        /// <summary>
        /// Contains the buttons that were released this frame.
        /// </summary>
        public ButtonFlags OneFrameReleaseButtonFlags;

        /// <summary>
        /// Pressure of the left trigger.
        /// </summary>
        public short TriggerPressureL;          // 0-255

        /// <summary>
        /// Pressure of the right trigger.
        /// </summary>
        public short TriggerPressureR;          // 0-255

        public int Field14;
        public int Field18;

        /// <summary>
        /// Properties of the left analog stick.
        /// </summary>
        public SkypadStick LeftStick;

        /// <summary>
        /// Properties of the right analog stick.
        /// </summary>
        public SkypadStick RightStick;

        // Repetition count for button presses. Ignored, we let the game handle this.
        public int Field2C;
        public int Field30;
        public int Field34;
        public int Field38;
        public int Field3C;
        public int Field40;
        public int Field44;
        public int Field48;
    }
}
