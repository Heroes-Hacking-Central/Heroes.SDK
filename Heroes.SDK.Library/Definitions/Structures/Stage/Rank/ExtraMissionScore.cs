namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the scores required for ranking for the Extra mission of an action stage, for teams Sonic and Chaotix.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct ExtraMissionScore
    {
        // TODO: Check if this can be removed
        public Enums.Stage StageId { get; set; }

        /// <summary>
        /// Score required for Team Sonic rankings.
        /// </summary>
        public RankEntryScore Sonic { get; set; }

        /// <summary>
        /// Score required for Team Chaotix rankings.
        /// </summary>
        public RankEntryScore Chaotix { get; set; }

        /// <summary>
        /// Set the rank scores for Team Sonic.
        /// </summary>
        /// <param name="sonicA">Team Sonic Rank A Score</param>
        /// <param name="sonicB">Team Sonic Rank B Score</param>
        /// <param name="sonicC">Team Sonic Rank C Score</param>
        /// <param name="sonicD">Team Sonic Rank D Score</param>
        public void SetTeamSonicRankScores(uint sonicA, uint sonicB, uint sonicC, uint sonicD)
        {
            Sonic.SetAllRankScores(sonicA, sonicB, sonicC, sonicD);
        }

        /// <summary>
        /// Set the rank scores for Team Chaotix.
        /// </summary>
        /// <param name="chaotixA">Team Chaotix Rank A Score</param>
        /// <param name="chaotixB">Team Chaotix Rank B Score</param>
        /// <param name="chaotixC">Team Chaotix Rank C Score</param>
        /// <param name="chaotixD">Team Chaotix Rank D Score</param>
        public void SetTeamChaotixRankScores(uint chaotixA, uint chaotixB, uint chaotixC, uint chaotixD)
        {
            Chaotix.SetAllRankScores(chaotixA, chaotixB, chaotixC, chaotixD);
        }
    }
}