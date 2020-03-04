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
        /// Minutes of time required for Team Dark to get a D rank.
        /// </summary>
        public byte DarkDMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Dark to get a D rank.
        /// </summary>
        public byte DarkDSec { get; set; }
        /// <summary>
        /// Minutes of time required for Team Dark to get a C rank.
        /// </summary>
        public byte DarkCMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Dark to get a C rank.
        /// </summary>
        public byte DarkCSec { get; set; }
        /// <summary>
        /// Minutes of time required for Team Dark to get a B rank.
        /// </summary>
        public byte DarkBMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Dark to get a B rank.
        /// </summary>
        public byte DarkBSec { get; set; }
        /// <summary>
        /// Minutes of time required for Team Dark to get a A rank.
        /// </summary>
        public byte DarkAMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Dark to get a A rank.
        /// </summary>
        public byte DarkASec { get; set; }
        /// <summary>
        /// Minutes of time required for Team Rose to get a D rank.
        /// </summary>
        public byte RoseDMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Rose to get a D rank.
        /// </summary>
        public byte RoseDSec { get; set; }
        /// <summary>
        /// Minutes of time required for Team Rose to get a C rank.
        /// </summary>
        public byte RoseCMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Rose to get a C rank.
        /// </summary>
        public byte RoseCSec { get; set; }
        /// <summary>
        /// Minutes of time required for Team Rose to get a B rank.
        /// </summary>
        public byte RoseBMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Rose to get a B rank.
        /// </summary>
        public byte RoseBSec { get; set; }
        /// <summary>
        /// Minutes of time required for Team Rose to get a A rank.
        /// </summary>
        public byte RoseAMin { get; set; }
        /// <summary>
        /// Seconds of time required for Team Rose to get a A rank.
        /// </summary>
        public byte RoseASec { get; set; }
    }
}