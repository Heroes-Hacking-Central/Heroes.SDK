namespace Heroes.SDK.Definitions.Structures.Stage.Spawn.Collections
{
    /// <summary>
    /// Individual array entry for action stage.
    /// Disassembly/Internal Name: ???
    /// </summary>
    public struct MultiplayerStart
    {
        /// <summary>
        /// The stage the following start position is for.
        /// </summary>
        public Enums.Stage StageId;

        /// <summary>
        /// Player 1 starting position.
        /// </summary>
        public PositionStart Player1Start;

        /// <summary>
        /// Player 2 starting position.
        /// </summary>
        public PositionStart Player2Start;
    }
}
