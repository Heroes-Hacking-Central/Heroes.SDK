namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    /// <summary>
    /// Represents the times required for ranking for the Extra mission in action stages, for teams Dark and Rose.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct ExtraMissionTime
    {
        public Enums.Stage StageId { get; set; }
        /// <summary>
        /// Team Dark ranking requirements.
        /// </summary>
        public RankEntryTime Dark { get; set; }
        /// <summary>
        /// Team Rose ranking requirements.
        /// </summary>
        public RankEntryTime Rose { get; set; }
    }
}