using System.Numerics;
using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.Collision.Object;
using Heroes.SDK.Definitions.Structures.Player.PlayerTopComponents;

namespace Heroes.SDK.Definitions.Structures.Player
{
    [StructLayout(LayoutKind.Explicit)]
    public struct PlayerTop
    {
        /// <summary>
        /// Contains various properties relating to the player's collision with objects in the game world.
        /// </summary>
        [FieldOffset(0x2C)]
        public CclPlayerEntry ObjectCollisionProperties;

        /// <summary>
        /// Amount of frames in the air as a ball.
        /// </summary>
        [FieldOffset(0xD4)]
        public short FramesInAirAsBall;

        /// <summary>
        /// Remaining amount of frames during which the player has no control (in mid air).
        /// Used by dash ramps, etc.
        /// Preserves airborne momentum and resets on landing.
        /// </summary>
        [FieldOffset(0xD6)]
        public short RemainingFramesNoControl;

        /// <summary>
        /// Amount of frames the character is stationery on the ground.
        /// </summary>
        [FieldOffset(0xD8)]
        public short FramesIdle;

        [FieldOffset(0xDA)]
        public short field_DA;

        [FieldOffset(0xDC)]
        public int field_DC;

        [FieldOffset(0xE0)]
        public int field_E0;

        [FieldOffset(0xE4)]
        public int field_E4;

        [FieldOffset(0xE8)]
        public int field_E8;

        [FieldOffset(0xEC)]
        public int field_EC;

        [FieldOffset(0xF0)]
        public int field_F0;

        /// <summary>
        /// The current action character is performing, e.g. on rail, jumping, being thundershot etc.
        /// </summary>
        [FieldOffset(0xF4)]
        public Action Action;

        /// <summary>
        /// Same as <see cref="Action"/>. Purpose unknown.
        /// </summary>
        [FieldOffset(0xF6)]
        public Action CopyOfAction;

        [FieldOffset(0xF8)]
        public int field_F8;

        [FieldOffset(0xFC)]
        public int field_FC;

        [FieldOffset(0x100)]
        public int field_100;

        [FieldOffset(0x104)]
        public int field_104;

        /// <summary>
        /// Velocity in the X, Y, Z direction (forward, upward, sideways).
        /// </summary>
        [FieldOffset(0x108)]
        public Vector3 Velocity;

        /// <summary>
        /// The X, Y, Z position of the character.
        /// </summary>
        [FieldOffset(0x114)]
        public Vector3 Position;

        [FieldOffset(0x120)]
        public int field_120;

        /// <summary>
        /// BAMS 0 - 65535. Yaw is clockwise, turning 90 degrees makes the character face right.
        /// </summary>
        [FieldOffset(0x124)]
        public int RotationYaw;

        /// <summary>
        /// BAMS 0 - 65535. Pitch is clockwise, i.e. rotating 90 degrees causes the characters' legs to point AWAY from the camera.
        /// </summary>

        [FieldOffset(0x128)]
        public int RotationPitch;

        /// <summary>
        /// Size of the character in the X, Y, Z directions.
        /// </summary>
        [FieldOffset(0x12C)]
        public Vector3 Size;

        /*
        // /// <summary>
        // /// BAMS 0 - 65535: The yaw angle which the teammates follow the character if this character is the leader.
        // /// </summary>
        // [FieldOffset(0xB4)]
        // public int TeammateFollowingYaw; // Forgot the offset.
        */

        /// <summary>
        /// Contains the actively used physics constants for this character.
        /// The physics constants are copied here from on every character switch and
        /// when performing certain actions that implicitly switch characters e.g. Rocket Accel.
        /// </summary>
        [FieldOffset(0x1C4)]
        public Physics Physics;
    }
}
