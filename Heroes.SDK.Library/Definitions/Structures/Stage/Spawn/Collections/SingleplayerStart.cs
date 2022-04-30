using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Stage.Spawn.Collections
{
    /// <summary>
    /// Individual array entry for action stage.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct SingleplayerStart
    {
        /// <summary>
        /// The stage the following start position is for.
        /// </summary>
        public Enums.Stage StageId;

        /// <summary>
        /// Team Sonic's starting position.
        /// </summary>
        public PositionStart SonicStart;

        /// <summary>
        /// Team Dark's starting position.
        /// </summary>
        public PositionStart DarkStart;

        /// <summary>
        /// Team Rose starting position.
        /// </summary>
        public PositionStart RoseStart;

        /// <summary>
        /// Team Chaotix' starting position.
        /// </summary>
        public PositionStart ChaotixStart;

        /// <summary>
        /// Unused Team
        /// </summary>
        public PositionStart ForeditStart;
    }
}
