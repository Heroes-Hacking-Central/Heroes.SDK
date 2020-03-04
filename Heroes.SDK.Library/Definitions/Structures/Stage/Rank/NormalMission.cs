namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the scores required for ranking for the Normal mission of an action stage, for all teams.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct NormalMission
    {
        /// <summary>
        /// Score required for Team Sonic to get a D rank, divided by 100.
        /// </summary>
        public ushort SonicD { get; set; }
        /// <summary>
        /// Score required for Team Sonic to get a C rank, divided by 100.
        /// </summary>
        public ushort SonicC { get; set; }
        /// <summary>
        /// Score required for Team Sonic to get a B rank, divided by 100.
        /// </summary>
        public ushort SonicB { get; set; }
        /// <summary>
        /// Score required for Team Sonic to get an A rank, divided by 100.
        /// </summary>
        public ushort SonicA { get; set; }
        /// <summary>
        /// Score required for Team Dark to get a D rank, divided by 100.
        /// </summary>
        public ushort DarkD { get; set; }
        /// <summary>
        /// Score required for Team Dark to get a C rank, divided by 100.
        /// </summary>
        public ushort DarkC { get; set; }
        /// <summary>
        /// Score required for Team Dark to get a B rank, divided by 100.
        /// </summary>
        public ushort DarkB { get; set; }
        /// <summary>
        /// Score required for Team Dark to get an A rank, divided by 100.
        /// </summary>
        public ushort DarkA { get; set; }
        /// <summary>
        /// Score required for Team Rose to get a D rank, divided by 100.
        /// </summary>
        public ushort RoseD { get; set; }
        /// <summary>
        /// Score required for Team Rose to get a C rank, divided by 100.
        /// </summary>
        public ushort RoseC { get; set; }
        /// <summary>
        /// Score required for Team Rose to get a B rank, divided by 100.
        /// </summary>
        public ushort RoseB { get; set; }
        /// <summary>
        /// Score required for Team Rose to get an A rank, divided by 100.
        /// </summary>
        public ushort RoseA { get; set; }
        /// <summary>
        /// Score required for Team Chaotix to get a D rank, divided by 100.
        /// </summary>
        public ushort ChaotixD { get; set; }
        /// <summary>
        /// Score required for Team Chaotix to get a C rank, divided by 100.
        /// </summary>
        public ushort ChaotixC { get; set; }
        /// <summary>
        /// Score required for Team Chaotix to get a B rank, divided by 100.
        /// </summary>
        public ushort ChaotixB { get; set; }
        /// <summary>
        /// Score required for Team Chaotix to get an A rank, divided by 100.
        /// </summary>
        public ushort ChaotixA { get; set; }
    }
}