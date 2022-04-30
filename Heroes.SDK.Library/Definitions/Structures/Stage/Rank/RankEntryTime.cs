namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    public struct RankEntryTime
    {
        /// <summary>
        /// Time required for the team to get a D rank.
        /// </summary>
        public RankReqTime RankD { get; set; }
        /// <summary>
        /// Time required for the team to get a C rank.
        /// </summary>
        public RankReqTime RankC { get; set; }
        /// <summary>
        /// Time required for the team to get a B rank.
        /// </summary>
        public RankReqTime RankB { get; set; }
        /// <summary>
        /// Time required for the team to get a A rank.
        /// </summary>
        public RankReqTime RankA { get; set; }

        /// <summary>
        /// Sets the time required for all ranks.
        /// </summary>
        /// <param name="minA">Rank A Minutes</param>
        /// <param name="secA">Rank A Seconds</param>
        /// <param name="minB">Rank B Minutes</param>
        /// <param name="secB">Rank B Seconds</param>
        /// <param name="minC">Rank C Minutes</param>
        /// <param name="secC">Rank C Seconds</param>
        /// <param name="minD">Rank D Minutes</param>
        /// <param name="secD">Rank D Seconds</param>
        public void SetAllRankReqTimes(byte minA, byte secA, byte minB, byte secB, byte minC, byte secC, byte minD, byte secD)
        {
            RankA.setTime(minA, secA);
            RankB.setTime(minB, secB);
            RankC.setTime(minC, secC);
            RankD.setTime(minD, secD);
        }
    }
}