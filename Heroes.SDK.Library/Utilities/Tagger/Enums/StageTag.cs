using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.SDK.Utilities.Tagger.Enums
{
    /// <summary>
    /// Defines individual stage properties for each stage in question.
    /// These properties are our own, custom defined and exist to simply help us classify individual levels.
    /// </summary>
    [Flags]
    public enum StageTag
    {
        /// <summary>
        /// The stage is either a team battle stage, enemy rush or a boss stage.
        /// </summary>
        Battle = 1,

        /// <summary>
        /// The stage is a tutorial stage.
        /// </summary>
        Tutorial = 2,

        /// <summary>
        /// The stage is a bobsled race stage.
        /// </summary>
        Bobsled = 4,

        /// <summary>
        /// The stage is a bonus stage.
        /// </summary>
        Bonus = 8,

        /// <summary>
        /// This stage is a special stage.
        /// </summary>
        Special = 16,

        /// <summary>
        /// This stage is exclusive to an individual team.
        /// </summary>
        Exclusive = 32,

        /// <summary>
        /// This stage is a Two Player stage.
        /// </summary>
        TwoPlayer = 64,

        /// <summary>
        /// This stage is a ring race.
        /// </summary>
        RingRace = 128
    }
}
