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
    }
}