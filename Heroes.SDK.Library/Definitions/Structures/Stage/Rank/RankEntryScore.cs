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

        /// <summary>
        /// Set all scores required for all ranks.
        /// </summary>
        /// <param name="A">Score required for the team to get a A rank, divided by 100.</param>
        /// <param name="B">Score required for the team to get a B rank, divided by 100.</param>
        /// <param name="C">Score required for the team to get a C rank, divided by 100.</param>
        /// <param name="D">Score required for the team to get a D rank, divided by 100.</param>
        public void SetAllRankScores(uint A, uint B, uint C, uint D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }
    }
}