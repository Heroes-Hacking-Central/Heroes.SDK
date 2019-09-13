using System.Collections.Generic;
using Heroes.SDK.Definitions.Enums;

namespace Heroes.SDK.Utilities.Namer
{
    internal class TeamNameDictionary
    {
        internal static Dictionary<Team, string> Dictionary = new Dictionary<Team, string>(16);
        static TeamNameDictionary()
        {
            Dictionary[Team.Sonic]      = "Sonic";
            Dictionary[Team.Dark]       = "Dark";
            Dictionary[Team.Chaotix]    = "Chaotix";
            Dictionary[Team.Rose]       = "Rose";
            Dictionary[Team.ForEDIT]    = "Foredit";
        }
    }
}
