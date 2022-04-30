using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Structures.Stage.Spawn;
using SonicHeroes.Utils.StageInjector.Common.Utilities;

namespace Heroes.SDK.Parsers.Custom
{
    /// <summary>
    /// Represents an individual serializable level entry.
    /// </summary>
    public class StageConfig : JsonSerializable<StageConfig>
    {
        /// <summary>
        /// The individual stage ID for the current stage. You can find the list of Stage IDs on SCHG.
        /// </summary>
        public Stage StageId { get; set; }

        /// <summary>
        /// Contains a set of 5 entries for each of the four teams and one unused team.
        /// For multiplayer stages, this is treated as a set of 2 entries for P1 and P2.
        /// Note: Use <see cref="Team"/> as an indexer for reading/writing 1P stuff.
        /// </summary>
        public PositionStart[] StartPositions { get; set; }

        /// <summary>
        /// Contains a set of 5 entries for each of the four teams and one unused team.
        /// For multiplayer stages, this is treated as set of 2 entries for P1 and P2.
        /// Note: Use <see cref="Team"/> both as the order of reading and writing of this list.
        /// </summary>
        public PositionEnd[] EndPositions { get; set; }

        /// <summary>
        /// Contains a set of 4 entries for each of the individual teams.
        /// Note: Ignored for 1P Stages.
        /// </summary>
        public PositionEnd[] BragPositions { get; set; }

    }
}
