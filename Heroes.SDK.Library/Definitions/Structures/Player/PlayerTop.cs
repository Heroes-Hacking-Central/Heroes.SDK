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
        /// Known object properties at offset 0xB4.
        /// </summary>
        [FieldOffset(0xD4)]
        public PlayerTopAt0xD4 OffsetD4;

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
