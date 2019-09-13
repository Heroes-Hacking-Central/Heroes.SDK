using System.Numerics;

namespace Heroes.SDK.Definitions.Structures.Player.PlayerTopComponents
{
    public unsafe struct PlayerTopAt0xB4
    {
        // Start at 0xD4

        /// <summary>
        /// Amount of frames in the air as a ball.
        /// </summary>
        public short FramesInAirAsBall;

        /// <summary>
        /// Remaining amount of frames during which the player has no control (in mid air).
        /// Used by dash ramps, etc.
        /// Preserves airborne momentum and resets on landing.
        /// </summary>
        public short RemainingFramesNoControl;

        /// <summary>
        /// Amount of frames the character is stationery on the ground.
        /// </summary>
        public short FramesIdle;

        public short field_DA;
        public int field_DC;
        public int field_E0;
        public int field_E4;
        public int field_E8;
        public int field_EC;
        public int field_F0;

        /// <summary>
        /// The current action character is performing, e.g. on rail, jumping, being thundershot etc.
        /// </summary>
        public Action Action;

        /// <summary>
        /// Same as <see cref="Action"/>. Purpose unknown.
        /// </summary>
        public Action CopyOfAction;

        public int field_F8;
        public int field_FC;
        public int field_100;
        public int field_104;

        /// <summary>
        /// Velocity in the X, Y, Z direction (forward, upward, sideways).
        /// </summary>
        public Vector3 Velocity;

        /// <summary>
        /// The X, Y, Z position of the character.
        /// </summary>
        public Vector3 Position;

        public int field_120;

        /// <summary>
        /// BAMS 0 - 65535. Yaw is clockwise, turning 90 degrees makes the character face right.
        /// </summary>
        public int RotationYaw;

        /// <summary>
        /// BAMS 0 - 65535. Pitch is clockwise, i.e. rotating 90 degrees causes the characters' legs to point AWAY from the camera.
        /// </summary>
        public int RotationPitch;

        /// <summary>
        /// Size of the character in the X, Y, Z directions.
        /// </summary>
        public Vector3 Size;

        /* End: 0x138 */
    }
}
