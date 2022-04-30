namespace Heroes.SDK.Definitions.Structures.Stage.Spawn.Collections
{
    /// <summary>
    /// Individual array entry for action stage.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct SingleplayerEnd
    {
        /// <summary>
        /// The stage the following start/end position is for.
        /// </summary>
        public Enums.Stage StageId;

        /// <summary>
        /// Team Sonic's ending position.
        /// </summary>
        public PositionEnd SonicEnd;

        /// <summary>
        /// Team Dark's ending position.
        /// </summary>
        public PositionEnd DarkEnd;

        /// <summary>
        /// Team Rose ending position.
        /// </summary>
        public PositionEnd RoseEnd;

        /// <summary>
        /// Team Chaotix' ending position.
        /// </summary>
        public PositionEnd ChaotixEnd;

        /// <summary>
        /// Unused Team
        /// </summary>
        public PositionEnd ForeditEnd;
    }
}
