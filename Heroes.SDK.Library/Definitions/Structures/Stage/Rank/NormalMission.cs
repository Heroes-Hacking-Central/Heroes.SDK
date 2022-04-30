namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the scores required for ranking for the Normal mission of an action stage, for all teams.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
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

        /// <summary>
        /// Set the rank scores for all teams.
        /// </summary>
        /// <param name="sonicA">Team Sonic Rank A Score</param>
        /// <param name="sonicB">Team Sonic Rank B Score</param>
        /// <param name="sonicC">Team Sonic Rank C Score</param>
        /// <param name="sonicD">Team Sonic Rank D Score</param>
        /// <param name="darkA">Team Dark Rank A Score</param>
        /// <param name="darkB">Team Dark Rank B Score</param>
        /// <param name="darkC">Team Dark Rank C Score</param>
        /// <param name="darkD">Team Dark Rank D Score</param>
        /// <param name="roseA">Team Rose Rank A Score</param>
        /// <param name="roseB">Team Rose Rank B Score</param>
        /// <param name="roseC">Team Rose Rank C Score</param>
        /// <param name="roseD">Team Rose Rank D Score</param>
        /// <param name="chaotixA">Team Chaotix Rank A Score</param>
        /// <param name="chaotixB">Team Chaotix Rank B Score</param>
        /// <param name="chaotixC">Team Chaotix Rank C Score</param>
        /// <param name="chaotixD">Team Chaotix Rank D Score</param>
        public void SetAllTeamRankScores(uint sonicA, uint sonicB, uint sonicC, uint sonicD,
            uint darkA, uint darkB, uint darkC, uint darkD,
            uint roseA, uint roseB, uint roseC, uint roseD,
            uint chaotixA, uint chaotixB, uint chaotixC, uint chaotixD)
        {
            Sonic.SetAllRankScores(sonicA, sonicB, sonicC, sonicD);
            Dark.SetAllRankScores(darkA, darkB, darkC, darkD);
            Rose.SetAllRankScores(roseA, roseB, roseC, roseD);
            Chaotix.SetAllRankScores(chaotixA, chaotixB, chaotixC, chaotixD);
        }
    }
}