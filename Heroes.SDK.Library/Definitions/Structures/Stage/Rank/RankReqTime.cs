namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    public struct RankReqTime
    {
        /// <summary>
        /// Minutes of time required for the rank.
        /// </summary>
        public byte Min { get; set; }
        /// <summary>
        /// Seconds of time required for the rank.
        /// </summary>
        public byte Sec { get; set; }
    }
}