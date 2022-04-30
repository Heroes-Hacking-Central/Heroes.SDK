using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Input
{
    /// <summary>
    /// Describes a controller structure used for storing controls obtained from the PC version of the game.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [Equals(DoNotAddEqualityOperators = true)]
    public struct HeroesController
    {
        /// <summary>
        /// Contains the currently pressed buttons at any point.
        /// </summary>
        public ButtonFlags ButtonFlags { get; set; }

        /// <summary>
        /// This value is (-1 - _buttonFlags).
        /// This value is also 0 when the window is not in focus.
        /// </summary>
        public int MinusOneMinusButtonFlags { get; set; }

        /// <summary>
        /// If a button is pressed and it was not pressed the last frame,
        /// set the <see cref="ButtonFlags"/> of said button.
        /// </summary>
        public ButtonFlags OneFramePressButtonFlag { get; set; }

        /// <summary>
        /// If a button is released and it was pressed the last frame,
        /// set the <see cref="ButtonFlags"/> of said button.
        /// </summary>
        public ButtonFlags OneFrameReleaseButtonFlag { get; set; }

        /// <summary>
        /// Range -1.0 to 1.0.
        /// </summary>
        public float LeftStickX { get; set; }

        /// <summary>
        /// Range -1.0 to 1.0.
        /// </summary>
        public float LeftStickY { get; set; }

        /// <summary>
        /// Range -1.0 to 1.0.
        /// </summary>
        public float RightStickX { get; set; }

        /// <summary>
        /// Range -1.0 to 1.0.
        /// </summary>
        public float RightStickY { get; set; }

        /// <summary>
        /// This value never seems to change. It does not have any effect on the game.
        /// </summary>
        public int ProbablyIsEnabled;

        /*
            ------------------
            Functions (Public)
            ------------------
        */

        /// <summary>
        /// Before submitting back to game, completes the remaining members of the struct
        /// that are dependent on knowing the inputs from the previous frame.
        /// </summary>
        /// <param name="before">The inputs that were pressed on the last frame.</param>
        public void Finalize(ButtonFlags before)
        {
            OneFrameReleaseButtonFlag = GetReleasedButtons(before, ButtonFlags);
            OneFramePressButtonFlag = GetPressedButtons(before, ButtonFlags);
            MinusOneMinusButtonFlags = GetMinusOneButtonFlags(ButtonFlags);
        }

        /*
            -------------------
            Functions (Private)
            -------------------
        */

        /// <summary>
        /// Returns the buttons that have been pressed <see cref="before"/> but not pressed <see cref="after"/>.
        /// </summary>
        public ButtonFlags GetReleasedButtons(ButtonFlags before, ButtonFlags after)
        {
            // Return B and NOT A
            // "Return those before without the ones after"
            return before & (~after);
        }

        /// <summary>
        /// Returns the buttons that have been pressed in <see cref="after"/> but not pressed <see cref="before"/>.
        /// </summary>
        public ButtonFlags GetPressedButtons(ButtonFlags before, ButtonFlags after)
        {
            // Return A and NOT B
            // "Return those after without the ones before"
            return after & (~before);
        }

        public int GetMinusOneButtonFlags(ButtonFlags buttonFlags)
        {
            return (-1 - (int)buttonFlags);
        }
    }
}
