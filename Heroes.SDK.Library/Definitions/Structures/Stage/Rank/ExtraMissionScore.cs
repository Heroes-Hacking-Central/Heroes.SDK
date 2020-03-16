namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the scores required for ranking for the Extra mission of an action stage, for teams Sonic and Chaotix.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct ExtraMissionScore
    {
        public Enums.Stage StageId { get; set; }
        /// <summary>
        /// Score required for Team Sonic rankings.
        /// </summary>
        public RankEntryScore Sonic { get; set; }
        /// <summary>
        /// Score required for Team Chaotix rankings.
        /// </summary>
        public RankEntryScore Chaotix { get; set; }
    }
}