namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the scores required for ranking for the Extra mission of an action stage, for teams Sonic and Chaotix.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct ExtraMissionScore
    {
        public Enums.Stage StageId { get; set; }
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