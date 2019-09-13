using System;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Structures.Collision.Object;
using Heroes.SDK.Definitions.Structures.Player;
using Heroes.SDK.Definitions.Structures.State;
using Heroes.SDK.Utilities.Namer;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Houses everything necessary for obtaining and manipulating player info for any of the four players.
    /// </summary>
    public static unsafe class Player
    {
        public const int MaxNumberOfPlayers = 4;

        /// <summary>
        /// Contains the teams selected by P1, P2, P3, P4 respectively.
        /// </summary>
        public static RefFixedArrayPtr<Team> Teams { get; } = new RefFixedArrayPtr<Team>(0x8D6920, MaxNumberOfPlayers);

        /// <summary>
        /// Contains properties for P1, P2, P3 and P4 respectively.
        /// </summary>
        public static RefFixedArrayPtr<TeamTop> TeamTop { get; } = new RefFixedArrayPtr<TeamTop>(0x00A4C268, MaxNumberOfPlayers);

        /// <summary>
        /// Contains properties for each of the characters in order of Speed, Power, Flight.
        /// Size of this array is <see cref="GetCharacterCount"/>.
        /// </summary>
        public static RefFixedArrayPtr<PlayerTop> PlayerTop { get; } = new RefFixedArrayPtr<PlayerTop>(0x00A4B1B0, 8);

        /// <summary>
        /// Contains the individual physics entries for each of the characters.
        /// These entries are applied on stage load and character swap.
        /// To edit physics mid-level, see <see cref="PlayerTop"/>'s <see cref="PlayerTop.Physics"/> structure.
        /// </summary>
        public static RefFixedArrayPtr<Physics> Physics { get; } = new RefFixedArrayPtr<Physics>(0x008BE550, 12);

        /// <summary>
        /// Returns true if more than one player is spawned on the stage.
        /// Note: See <see cref="State.IsMultiplayerMode"/> to check if two player mode is currently being played.
        /// This will return true for 2P in 1P mode.
        /// </summary>
        public static bool IsMultiPlayer()
        {
            return Teams[1] != Team.Null;
        }

        /// <summary>
        /// Returns the number of currently playing teams.
        /// </summary>
        public static int GetPlayerCount()
        {
            if (Teams[3] != Team.Null)
                return 4;

            if (Teams[2] != Team.Null)
                return 3;

            if (Teams[1] != Team.Null)
                return 2;

            return 1;
        }

        /// <summary>
        /// Returns the number of characters spawned in based on the amount of participating teams.
        /// </summary>
        public static int GetCharacterCount()
        {
            return GetPlayerCount() * 3;
        }

        /// <summary>
        /// Obtains a string representation of the current team's name.
        /// </summary>
        public static string GetTeamName(Definitions.Enums.Custom.Player player)
        {
            Team currentTeam = Teams[(int)player];
            return Namer.GetTeamName(currentTeam);
        }
    }
}
