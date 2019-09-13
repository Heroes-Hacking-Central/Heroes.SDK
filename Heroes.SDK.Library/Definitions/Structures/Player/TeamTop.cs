using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Structures.Player.PlayerTopComponents;
using Heroes.SDK.Definitions.Structures.Player.TeamTopComponents;

namespace Heroes.SDK.Definitions.Structures.Player
{
    /// <summary>
    /// Stores the state of an individual team used by a player.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct TeamTop
    {
        /// <summary>
        /// Team which is currently in use by this player.
        /// </summary>
        [FieldOffset(0x34)]
        public Team Team;

        /// <summary>
        /// Character to warp to when changing formation.
        /// 2 = Warp to Self
        /// 1 = Warp to Power (from Speed Formation)
        /// 0 = Warp to Fly (from Speed Formation)
        /// </summary>
        [FieldOffset(0x102)]
        public FormationSwitchBehaviour FormationSwitchBehaviour;

        /// <summary>
        /// The current formation of the current player's partners.
        /// Note: Some formations may cause a character swap.
        /// </summary>
        [FieldOffset(0x140)]
        public PartnerFormation PartnerFormation;

        /// <summary>
        /// The last formation of the current player's partners.
        /// </summary>
        [FieldOffset(0x144)]
        public PartnerFormation LastPartnerFormation;

        /// <summary>
        /// The current formation of the team.
        /// </summary>
        [FieldOffset(0x148)]
        public Formation Formation;

        [FieldOffset(0x154)]
        public int SomethingToDoWithReturningToFormation;

        [FieldOffset(0x158)]
        public int LastSomethingToDoWithReturningToFormation;

        // 0x15C Some Angle in BAMS side character when character turns.
        // 0x160 Some Angle in BAMS side character when character turns.

        /// <summary>
        /// Current power level of the speed character. Range 0-3
        /// Set this to 22 I dare you.
        /// </summary>
        [FieldOffset(0x208)]
        public byte SpeedLevel;

        /// <summary>
        /// Current power level of the flight character. Range 0-3
        /// Set this to 22 I dare you.
        /// </summary>
        [FieldOffset(0x209)]
        public byte FlyLevel;

        /// <summary>
        /// Current power level of the power character. Range 0-3
        /// Set this to 22 I dare you.
        /// </summary>
        [FieldOffset(0x20A)]
        public byte PowerLevel;

        // Size somewhere around 0x300, did not check.
    }
}