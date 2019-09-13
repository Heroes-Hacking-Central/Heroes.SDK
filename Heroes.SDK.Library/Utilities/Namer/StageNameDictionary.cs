using System.Collections.Generic;
using Heroes.SDK.Definitions.Enums;

namespace Heroes.SDK.Utilities.Namer
{
    internal class StageNameDictionary
    {
        internal static Dictionary<Stage, string> Dictionary = new Dictionary<Stage, string>(128);
        static StageNameDictionary()
        {
            Dictionary[Stage.TestLevel]           = "Test Level";

            Dictionary[Stage.SeasideHill]         = "Seaside Hill";
            Dictionary[Stage.OceanPalace]         = "Ocean Palace";
            Dictionary[Stage.GrandMetropolis]     = "Grand Metropolis";
            Dictionary[Stage.PowerPlant]          = "Power Plant";
            Dictionary[Stage.CasinoPark]          = "Casino Park";
            Dictionary[Stage.BingoHighway]        = "Bingo Highway";
            Dictionary[Stage.RailCanyon]          = "Rail Canyon";
            Dictionary[Stage.BulletStation]       = "Bullet Station";
            Dictionary[Stage.FrogForest]          = "Frog Forest";
            Dictionary[Stage.LostJungle]          = "Lost Jungle";
            Dictionary[Stage.HangCastle]          = "Hang Castle";
            Dictionary[Stage.MysticMansion]       = "Mystic Mansion";
            Dictionary[Stage.EggFleet]            = "Egg Fleet";
            Dictionary[Stage.FinalFortress]       = "Final Fortress";

            Dictionary[Stage.EggHawk]             = "Egg Hawk";
            Dictionary[Stage.TeamBattle1]         = "Team Battle 1";
            Dictionary[Stage.TeamBattle2]         = "Team Battle 2";
            Dictionary[Stage.RobotStorm]          = "Robot Storm";
            Dictionary[Stage.EggEmperor]          = "Egg Emperor";
            Dictionary[Stage.MetalMadness]        = "Metal Madness";
            Dictionary[Stage.MetalOverlord]       = "Metal Overlord";

            Dictionary[Stage.SeaGate]             = "Sea Gate";

            Dictionary[Stage.SeasideCourse]       = "Seaside Course (2P)";
            Dictionary[Stage.CityCourse]          = "City Course (2P)";
            Dictionary[Stage.CasinoCourse]        = "Casino Course (2P)";

            Dictionary[Stage.BonusStage1]         = "Bonus Stage 1";
            Dictionary[Stage.BonusStage2]         = "Bonus Stage 2";
            Dictionary[Stage.BonusStage3]         = "Bonus Stage 3";
            Dictionary[Stage.BonusStage4]         = "Bonus Stage 4";
            Dictionary[Stage.BonusStage5]         = "Bonus Stage 5";
            Dictionary[Stage.BonusStage6]         = "Bonus Stage 6";
            Dictionary[Stage.BonusStage7]         = "Bonus Stage 7";

            Dictionary[Stage.SeasideHill2P]       = "Seaside Hill (2P)";
            Dictionary[Stage.GrandMetropolis2P]   = "Grand Metropolis (2P)";
            Dictionary[Stage.BingoHighway2P]      = "Bingo Highway (2P)";

            Dictionary[Stage.CityTopBattle]       = "City Top (2P)";
            Dictionary[Stage.CasinoRingBattle]    = "Casino Ring (2P)";
            Dictionary[Stage.TurtleShellBattle]   = "Turtle Shell (2P)";

            Dictionary[Stage.EggTreat]            = "Egg Treat (2P)";
            Dictionary[Stage.PinballMatch]        = "Pinball Match (2P)";
            Dictionary[Stage.HotElevator]         = "Hot Elevator (2P)";

            Dictionary[Stage.RoadRock]            = "Road Rock (2P)";
            Dictionary[Stage.MadExpress]          = "Mad Express (2P)";
            Dictionary[Stage.TerrorHall]          = "Terror Hall (2P)";

            Dictionary[Stage.RailCanyonExpert]    = "Rail Canyon (2P)";
            Dictionary[Stage.FrogForestExpert]    = "Frog Forest (2P)";
            Dictionary[Stage.EggFleetExpert]      = "Egg Fleet (2P)";

            Dictionary[Stage.EmeraldChallenge1]   = "Emerald Challenge 1";
            Dictionary[Stage.EmeraldChallenge2]   = "Emerald Challenge 2";
            Dictionary[Stage.EmeraldChallenge3]   = "Emerald Challenge 3";
            Dictionary[Stage.EmeraldChallenge4]   = "Emerald Challenge 4";
            Dictionary[Stage.EmeraldChallenge5]   = "Emerald Challenge 5";
            Dictionary[Stage.EmeraldChallenge6]   = "Emerald Challenge 6";
            Dictionary[Stage.EmeraldChallenge7]   = "Emerald Challenge 7";

            Dictionary[Stage.SpecialStageMultiplayer1] = "Special Stage 1 (2P)";
            Dictionary[Stage.SpecialStageMultiplayer2] = "Special Stage 2 (2P)";
            Dictionary[Stage.SpecialStageMultiplayer3] = "Special Stage 3 (2P)";
        }
    }
}
