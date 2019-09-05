using System;
using System.Collections.Generic;
using System.Text;
using Heroes.SDK.Game.Enums;

namespace Heroes.SDK.Utilities.Namer
{
    /// <summary>
    /// Utility class that can obtain string representations for various items.
    /// </summary>
    public class Namer
    {
        /// <summary>
        /// Retrieves the string name of a given stage.
        /// </summary>
        public string GetStageName(Game.Enums.Stage stage) => StageNameDictionary.Dictionary[stage];

        /// <summary>
        /// Retrieves the string name of a given team.
        /// </summary>
        public string GetTeamName(Team team) => TeamNameDictionary.Dictionary[team];
    }
}
