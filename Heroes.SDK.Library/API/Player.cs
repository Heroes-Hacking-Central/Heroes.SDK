using System;
using System.Runtime.CompilerServices;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Enums.Custom;
using Heroes.SDK.Definitions.Structures.Collision.Object;
using Heroes.SDK.Definitions.Structures.Player;
using Heroes.SDK.Definitions.Structures.Player.TeamTopComponents;
using Heroes.SDK.Definitions.Structures.State;
using Heroes.SDK.Utilities.Namer;
using Reloaded.Memory.Pointers;
using static Heroes.SDK.Utilities.Misc.Player;
using Action = Heroes.SDK.Definitions.Structures.Player.PlayerTopComponents.Action;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Houses everything necessary for obtaining and manipulating player info for any of the four players.
    /// </summary>
    public static unsafe class Player
    {
        public const int MaxNumberOfPlayers = 4;
        public const int NumberOfPlayersInTeam = 3;

        /// <summary>
        /// Contains the teams selected by P1, P2, P3, P4 respectively.
        /// </summary>
        public static RefFixedArrayPtr<Team> Teams { get; } = new RefFixedArrayPtr<Team>(0x8D6920, MaxNumberOfPlayers);

        /// <summary>
        /// Contains properties for P1, P2, P3 and P4 respectively.
        /// </summary>
        public static RefFixedArrayPtr<BlittablePointer<TeamTop>> TeamTop { get; } = new RefFixedArrayPtr<BlittablePointer<TeamTop>>(0x00A4C268, MaxNumberOfPlayers);

        /// <summary>
        /// Contains properties for each of the characters in order of Speed, Flight, Power
        /// Size of this array is <see cref="GetCharacterCount"/>.
        /// </summary>
        public static RefFixedArrayPtr<BlittablePointer<PlayerTop>> PlayerTop { get; } = new RefFixedArrayPtr<BlittablePointer<PlayerTop>>(0x00A4B1B0, 8);

        /// <summary>
        /// Contains the individual physics entries for each of the characters.
        /// These entries are applied on stage load and character swap.
        /// To edit physics mid-level, see <see cref="PlayerTop"/>'s <see cref="Definitions.Structures.Player.Physics"/> structure.
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
        /// Retrieves the character of the formation which is currently in control by the player.
        /// </summary>
        public static BlittablePointer<PlayerTop> GetCurrentCharacter(Players players)
        {
            var formation = TeamTop[(int) players].AsReference().Formation;
            formation     = SwapFlyPower(formation);
            return PlayerTop[((int)players * NumberOfPlayersInTeam) + (int)formation];
        }
        
        /// <summary>
        /// Retrieves the character of the formation which is currently in control by the player.
        /// This one differs from <see cref="GetCurrentCharacter"/> in the fact that it accounts for the Flight formation.
        /// In flight formation, the player who dictates the position of the whole formation is not actually always the flight character.
        /// For example, when on the floor it is the power character.
        ///
        /// This method returns the character in control of the position of the characters when in fly formation.
        /// </summary>
        public static BlittablePointer<PlayerTop> GetCurrentCharacterFly(Players players)
        {
            var formation = TeamTop[(int)players].AsReference().Formation;
            
            if (formation == Formation.Fly)
            {
                var characters = GetCharactersForPlayer(players);
                for (int x = 0; x < characters.Count; x++)
                {
                    if (characters[x].AsReference().Action != Action.FlyFormationDefault)
                        return characters[x];
                }
            }

            formation = SwapFlyPower(formation);
            return PlayerTop[((int)players * NumberOfPlayersInTeam) + (int)formation];
        }

        /// <summary>
        /// Retrieves an array of all characters controlled by a given player.
        /// </summary>
        public static RefFixedArrayPtr<BlittablePointer<PlayerTop>> GetCharactersForPlayer(Players players)
        {
            return new RefFixedArrayPtr<BlittablePointer<PlayerTop>>(&PlayerTop.Pointer[(int)players * NumberOfPlayersInTeam], NumberOfPlayersInTeam);
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
            return GetPlayerCount() * NumberOfPlayersInTeam;
        }

        /// <summary>
        /// Obtains a string representation of the current team's name.
        /// </summary>
        public static string GetTeamName(Players players)
        {
            Team currentTeam = Teams[(int)players];
            return Namer.GetTeamName(currentTeam);
        }
    }
}
