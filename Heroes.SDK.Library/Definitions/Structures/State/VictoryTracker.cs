using System;
using Heroes.SDK.Definitions.Enums.Custom;

namespace Heroes.SDK.Definitions.Structures.State
{
    /// <summary>
    /// Structure that tracks the individual victories for each of the four players.
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct VictoryTracker
    {
        public byte PlayerOne;
        public byte PlayerTwo;
        public byte PlayerThree;
        public byte PlayerFour;

        /// <summary>
        /// Returns the number of victories for a specific player.
        /// </summary>
        /// <param name="player">The player to get victories for.</param>
        public byte GetNumberOfVictories(Players player)
        {
            switch (player)
            {
                case Players.One:
                    return PlayerOne;
                case Players.Two:
                    return PlayerTwo;
                case Players.Three:
                    return PlayerThree;
                case Players.Four:
                    return PlayerFour;
                default:
                    throw new ArgumentOutOfRangeException(nameof(player), player, null);
            }
        }
    }
}
