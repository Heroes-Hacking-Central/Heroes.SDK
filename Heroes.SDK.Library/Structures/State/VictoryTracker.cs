using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.SDK.Game.Structures
{
    /// <summary>
    /// Structure that tracks the individual victories for each of the four players.
    /// </summary>
    public struct VictoryTracker
    {
        public byte PlayerOne;
        public byte PlayerTwo;
        public byte PlayerThree;
        public byte PlayerFour;
    }
}
