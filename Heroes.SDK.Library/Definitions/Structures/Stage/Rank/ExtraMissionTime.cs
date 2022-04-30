namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the times required for ranking for the Extra mission in action stages, for teams Dark and Rose.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct ExtraMissionTime
    {
        // TODO: Check if this can be removed
        public Enums.Stage StageId { get; set; }

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
        public RankEntryScore Chaotix { get; set; }

        /// <summary>
        /// Sets the rank time of all ranks for Team Dark.
        /// </summary>
        /// <param name="minDarkA">Rank A Minutes</param>
        /// <param name="secDarkA">Rank A Seconds</param>
        /// <param name="minDarkB">Rank B Minutes</param>
        /// <param name="secDarkB">Rank B Seconds</param>
        /// <param name="minDarkC">Rank C Minutes</param>
        /// <param name="secDarkC">Rank C Seconds</param>
        /// <param name="minDarkD">Rank D Minutes</param>
        /// <param name="secDarkD">Rank D Seconds</param>
        public void SetDarkRankTime(byte minDarkA, byte secDarkA, byte minDarkB, byte secDarkB,
            byte minDarkC, byte secDarkC, byte minDarkD, byte secDarkD)
        {
            Dark.SetAllRankReqTimes(minDarkA, secDarkA, minDarkB, secDarkB,
                minDarkC, secDarkC, minDarkD, secDarkD);
        }

        /// <summary>
        /// Sets the rank time of all ranks for Team Rose.
        /// </summary>
        /// <param name="minRoseA">Rank A Minutes</param>
        /// <param name="secRoseA">Rank A Seconds</param>
        /// <param name="minRoseB">Rank B Minutes</param>
        /// <param name="secRoseB">Rank B Seconds</param>
        /// <param name="minRoseC">Rank C Minutes</param>
        /// <param name="secRoseC">Rank C Seconds</param>
        /// <param name="minRoseD">Rank D Minutes</param>
        /// <param name="secRoseD">Rank D Seconds</param>
        public void SetRoseRankTime(byte minRoseA, byte secRoseA, byte minRoseB, byte secRoseB,
            byte minRoseC, byte secRoseC, byte minRoseD, byte secRoseD)
        {
            Rose.SetAllRankReqTimes(minRoseA, secRoseA, minRoseB, secRoseB,
                minRoseC, secRoseC, minRoseD, secRoseD);
        }

        /// <summary>
        /// Set all scores for each rank required for Team Chaotix.
        /// </summary>
        /// <param name="A">Score required for the team to get a A rank, divided by 100.</param>
        /// <param name="B">Score required for the team to get a B rank, divided by 100.</param>
        /// <param name="C">Score required for the team to get a C rank, divided by 100.</param>
        /// <param name="D">Score required for the team to get a D rank, divided by 100.</param>
        public void SetChaotixRankScore(uint A, uint B, uint C, uint D)
        {
            Chaotix.SetAllRankScores(A, B, C, D);
        }
    }
}