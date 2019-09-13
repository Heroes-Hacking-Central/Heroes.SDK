using System;
using System.Collections.Generic;
using System.Text;
using Heroes.SDK.Definitions.Enums;

namespace Heroes.SDK.Utilities.Namer
{
    /// <summary>
    /// Utility class that can obtain string representations for various items.
    /// </summary>
    public static class Namer
    {
        /// <summary>
        /// Retrieves the string name of a given stage.
        /// </summary>
        public static string GetStageName(Stage stage)
        {
            if (StageNameDictionary.Dictionary.TryGetValue(stage, out string stageName))
                return stageName;

            return "Unknown Stage";
        }

        /// <summary>
        /// Retrieves the string name of a given team.
        /// </summary>
        public static string GetTeamName(Team team)
        {
            if (TeamNameDictionary.Dictionary.TryGetValue(team, out string teamName))
                return teamName;

            return "Unknown Team";
        }
    }
}
