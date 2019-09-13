namespace Heroes.SDK.Definitions.Enums
{
    public enum SystemMode : int
    {
        /// <summary>
        /// (Leftover from PS2) Allows to select 50/60Hz modes.
        /// </summary>
        PalSelect = 0,

        /// <summary>
        /// Runs the main menu code.
        /// </summary>
        MainMenu = 1,

        /// <summary>
        /// Player is in the middle of a level.
        /// </summary>
        InGame   = 2,

        /// <summary>
        /// The Easy Menu: Black and White Stage Select
        /// </summary>
        EasyMenu = 3,

        /// <summary>
        /// Executes the credits sequence. Needs initialization.
        /// </summary>
        Credits = 4,

        /// <summary>
        /// Movie selection menu from the Easy Menu
        /// </summary>
        EasyMenuMovie = 5
    }
}