using System;
using System.Collections.Generic;
using System.Text;
using Heroes.SDK.Game.Enums;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.Game
{
    public static unsafe class State
    {
        private const int MaxNumberOfPlayers = 4;

        /// <summary>
        /// The stage that is currently being played.
        /// </summary>
        public static Enums.Stage* CurrentStage { get; } = (Enums.Stage*) 0x008D6720;

        /// <summary>
        /// Describes the state of the game at a given moment in time when the player is inside a stage.
        /// </summary>
        public static GameState* GameState { get; } = (GameState*) 0x008D66F0;

        /// <summary>
        /// Contains the teams selected by P1, P2, P3, P4 respectively.
        /// </summary>
        public static FixedArrayPtr<Team> Teams = new FixedArrayPtr<Team>(0x8D6920, MaxNumberOfPlayers);

        /// <summary>
        /// Returns true if in main menu, else false.
        /// </summary>
        public static bool IsInMainMenu()
        {
            return *GameState == Enums.GameState.Menu || *GameState == Enums.GameState.Null;
        }
    }
}
