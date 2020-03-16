namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the times required for ranking for the boss stage, for all teams.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct BossTime
    {
        public Enums.Stage StageId { get; set; }
        /// <summary>
        /// Team Sonic ranking requirements.
        /// </summary>
        public RankEntryTime Sonic { get; set; }
        /// <summary>
        /// Team Dark ranking requirements.
        /// </summary>
        public RankEntryTime Dark { get; set; }
        /// <summary>
        /// Team Rose ranking requirements.
        /// </summary>
        public RankEntryTime Rose { get; set; }
        /// <summary>
        /// Team Chaotix ranking requirements.
        /// </summary>
        public RankEntryTime Chaotix { get; set; }
    }
}