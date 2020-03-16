namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the scores required for ranking for the Normal mission of an action stage, for all teams.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct NormalMission
    {
        /// <summary>
        /// Score required for Team Sonic rankings.
        /// </summary>
        public RankEntryScore Sonic { get; set; }
        /// <summary>
        /// Score required for Team Dark rankings.
        /// </summary>
        public RankEntryScore Dark { get; set; }
        /// <summary>
        /// Score required for Team Rose rankings.
        /// </summary>
        public RankEntryScore Rose { get; set; }
        /// <summary>
        /// Score required for Team Chaotix rankings.
        /// </summary>
        public RankEntryScore Chaotix { get; set; }
    }
}