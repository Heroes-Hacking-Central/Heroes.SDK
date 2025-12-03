namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the times required for ranking for the boss stage, for all teams.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct BossTime
    {
        // TODO: Check if this can be removed
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

        /// <summary>
        /// Sets the rank time of all ranks for all teams.
        /// </summary>
        /// <param name="minSonicA">Team Sonic Rank A Minutes</param>
        /// <param name="secSonicA">Team Sonic Rank A Seconds</param>
        /// <param name="minSonicB">Team Sonic Rank B Minutes</param>
        /// <param name="secSonicB">Team Sonic Rank B Seconds</param>
        /// <param name="minSonicC">Team Sonic Rank C Minutes</param>
        /// <param name="secSonicC">Team Sonic Rank C Seconds</param>
        /// <param name="minSonicD">Team Sonic Rank D Minutes</param>
        /// <param name="secSonicD">Team Sonic Rank D Seconds</param>
        /// <param name="minDarkA">Team Dark Rank A Minutes</param>
        /// <param name="secDarkA">Team Dark Rank A Seconds</param>
        /// <param name="minDarkB">Team Dark Rank B Minutes</param>
        /// <param name="secDarkB">Team Dark Rank B Seconds</param>
        /// <param name="minDarkC">Team Dark Rank C Minutes</param>
        /// <param name="secDarkC">Team Dark Rank C Seconds</param>
        /// <param name="minDarkD">Team Dark Rank D Minutes</param>
        /// <param name="secDarkD">Team Dark Rank D Seconds</param>
        /// <param name="minRoseA">Team Rose Rank A Minutes</param>
        /// <param name="secRoseA">Team Rose Rank A Seconds</param>
        /// <param name="minRoseB">Team Rose Rank B Minutes</param>
        /// <param name="secRoseB">Team Rose Rank B Seconds</param>
        /// <param name="minRoseC">Team Rose Rank C Minutes</param>
        /// <param name="secRoseC">Team Rose Rank C Seconds</param>
        /// <param name="minRoseD">Team Rose Rank D Minutes</param>
        /// <param name="secRoseD">Team Rose Rank D Seconds</param>
        /// <param name="minChaotixA">Team Chaotix Rank A Minutes</param>
        /// <param name="secChaotixA">Team Chaotix Rank A Seconds</param>
        /// <param name="minChaotixB">Team Chaotix Rank B Minutes</param>
        /// <param name="secChaotixB">Team Chaotix Rank B Seconds</param>
        /// <param name="minChaotixC">Team Chaotix Rank C Minutes</param>
        /// <param name="secChaotixC">Team Chaotix Rank C Seconds</param>
        /// <param name="minChaotixD">Team Chaotix Rank D Minutes</param>
        /// <param name="secChaotixD">Team Chaotix Rank D Seconds</param>
        public void SetAllTeamRankTimes(byte minSonicA, byte secSonicA, byte minSonicB, byte secSonicB,
            byte minSonicC, byte secSonicC, byte minSonicD, byte secSonicD,
            byte minDarkA, byte secDarkA, byte minDarkB, byte secDarkB,
            byte minDarkC, byte secDarkC, byte minDarkD, byte secDarkD,
            byte minRoseA, byte secRoseA, byte minRoseB, byte secRoseB,
            byte minRoseC, byte secRoseC, byte minRoseD, byte secRoseD,
            byte minChaotixA, byte secChaotixA, byte minChaotixB, byte secChaotixB,
            byte minChaotixC, byte secChaotixC, byte minChaotixD, byte secChaotixD)
        {
            Sonic.SetAllRankReqTimes(minSonicA, secSonicA, minSonicB, secSonicB,
            minSonicC, secSonicC, minSonicD, secSonicD);

            Dark.SetAllRankReqTimes(minDarkA, secDarkA, minDarkB, secDarkB,
            minDarkC, secDarkC, minDarkD, secDarkD);

            Rose.SetAllRankReqTimes(minRoseA, secRoseA, minRoseB, secRoseB,
                minRoseC, secRoseC, minRoseD, secRoseD);

            Chaotix.SetAllRankReqTimes(minChaotixA, secChaotixA, minChaotixB, secChaotixB,
            minChaotixC, secChaotixC, minChaotixD, secChaotixD);
        }
    }
}