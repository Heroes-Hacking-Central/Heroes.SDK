namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    public struct RankEntryScore
    {
        /// <summary>
        /// Score required for the team to get a D rank, divided by 100.
        /// </summary>
        public uint D { get; set; }
        /// <summary>
        /// Score required for the team to get a C rank, divided by 100.
        /// </summary>
        public uint C { get; set; }
        /// <summary>
        /// Score required for the team to get a B rank, divided by 100.
        /// </summary>
        public uint B { get; set; }
        /// <summary>
        /// Score required for the team to get a A rank, divided by 100.
        /// </summary>
        public uint A { get; set; }
    }
}