namespace Heroes.SDK.Definitions.Enums
{
    /// <summary>
    /// Describes the state of the game at a given moment in time.
    /// These values are valid for when the player is inside a stage.
    /// Relevant: <see cref="SystemMode"/>
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Game state is not set.
        /// </summary>
        Null = 0,

        /// <summary>
        /// Browsing the main menu. This state essentially has no effect.
        /// </summary>
        Menu = 1,

        /// <summary>
        /// The level is starting to load/is being initialized.
        /// </summary>
        StartLevelLoad = 2,

        /// <summary>
        /// Level has loaded. Animate the titlecard fadeout.
        /// </summary>
        EndLevelLoad = 3,

        Unknown4 = 4,

        /// <summary>
        /// Player
        /// </summary>
        InGame = 5,

        /// <summary>
        /// Displays the main pause menu.
        /// </summary>
        InGamePaused = 6,

        /// <summary>
        /// Displays the controller rebinding menu.
        /// </summary>
        InGamePausedSettings = 7,

        /// <summary>
        /// Displays the Auto/Free Camera menu.
        /// </summary>
        InGamePausedSettingsCamera = 8,

        /// <summary>
        /// Displays the controller rebinding menu.
        /// </summary>
        InGamePausedSettingsRebinding = 9,

        /// <summary>
        /// Executes ACTION::FreezeExec.
        /// Freezes all gameplay while keeping camera active.
        /// </summary>
        InGameSceneFrozen = 10,

        /// <summary>
        /// Used to exit the level and save game.
        /// </summary>
        InGameExitWithSave = 11,

        /// <summary>
        /// Used for exit: ???
        /// </summary>
        Unknown13Exit = 13,

        /// <summary>
        /// Executed when the character wins the stage.
        /// </summary>
        InGameLevelWin = 15,

        /// <summary>
        /// Used for exit: ???
        /// </summary>
        InGameExit2 = 16,
    }
}
