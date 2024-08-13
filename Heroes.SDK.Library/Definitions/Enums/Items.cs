using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.SDK.Definitions.Enums
{
    public enum ItemFlags : short
    {
        Powerups_Barrier = 0x1,
        ItemFlags_Magnetic = 0x2,
        Powerups_SpeedShoes = 0x4,
        ItemFlags_ResetFlyTime = 0x8,
        Powerups1_10 = 0x10,
        Powerups1_20 = 0x20,
        Powerups1_40 = 0x40,
        Powerups1_80 = 0x80,
        ItemFlags_KnockbackLaunch = 0x400,
        ItemFlags_NotPosted = 0x800,
        ItemFlags_TeamBattleIsCPU = 0x1000,
        ItemFlags_2000 = 0x2000,
        ItemFlags_Dead = 0x4000,
    };

}
