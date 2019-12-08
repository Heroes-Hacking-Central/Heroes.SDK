using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Heroes.SDK.Definitions.Structures.Player.TeamTopComponents;

namespace Heroes.SDK.Utilities.Misc
{
    public static class Player
    {
        /// <summary>
        /// Swaps fly with power or power with fly formation.
        /// This is done because some game code has characters in Speed, Fly, Power order while others in Speed, Power, Fly.
        /// </summary>
        /// <param name="formation">The current formation.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Formation SwapFlyPower(Formation formation)
        {
            if (formation == Formation.Power)
                formation = Formation.Fly;
            else if (formation == Formation.Fly)
                formation = Formation.Power;

            return formation;
        }
    }
}
