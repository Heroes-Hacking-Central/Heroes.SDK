using System.Numerics;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Stage.Spawn
{
    /// <summary>
    /// Describes the position and how the player starts off the stage.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PositionStart
    {
        /// <summary>
        /// The starting position of the player.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// BAMS 0 - 65535. Pitch is clockwise, i.e. rotating 90 degrees causes the characters' legs to point AWAY from the camera.
        /// </summary>
        public ushort Pitch { get; set; }

        /// <summary>
        /// BAMS 0 - 65535. Roll is anticlockwise, i.e. to the left.
        /// Values between 25% and 75% will cause the characters to land backwards on rails.
        /// </summary>
        public ushort Roll { get; set; }

        public int Unknown { get; set; }

        /// <summary>
        /// Describes how the player starts off the stage.
        /// </summary>
        public StartPositionMode Mode { get; set; }

        /// <summary>
        /// Time spent running in Running mode or without controller control, in frames.
        /// </summary>
        public int HoldTime { get; set; }
    }
}
