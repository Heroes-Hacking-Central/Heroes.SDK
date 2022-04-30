using Vector3 = Heroes.SDK.Utilities.Math.Structs.Vector3;

namespace Heroes.SDK.Definitions.Structures.Stage.Spawn
{
    /// <summary>
    /// Represents a coordinate whereby an individual team performs their ending poses after finishing a stage.
    /// Disassembly/Internal Name: ???
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct PositionEnd
    {
        /// <summary>
        /// Use to edit the <see cref="Position"/> directly without making copies if necessary.
        /// </summary>
        public Vector3 _position;

        /// <summary>
        /// Position where the animation is performed.
        /// </summary>
        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }

        /// <summary>
        /// BAMS 0 - 65535. Pitch is clockwise, i.e. rotating 90 degrees causes the characters' legs to point AWAY from the camera.
        /// </summary>
        public ushort Pitch { get; set; }
        public ushort Unknown { get; set; }

        public int Null { get; set; }
    }
}