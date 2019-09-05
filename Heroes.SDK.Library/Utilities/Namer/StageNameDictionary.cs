using System.Collections.Generic;

namespace Heroes.SDK.Utilities.Namer
{
    internal class StageNameDictionary
    {
        internal static Dictionary<Game.Enums.Stage, string> Dictionary = new Dictionary<Game.Enums.Stage, string>(128);
        static StageNameDictionary()
        {
            Dictionary[Game.Enums.Stage.TestLevel]           = "Test Level";

            Dictionary[Game.Enums.Stage.SeasideHill]         = "Seaside Hill";
            Dictionary[Game.Enums.Stage.OceanPalace]         = "Ocean Palace";
            Dictionary[Game.Enums.Stage.GrandMetropolis]     = "Grand Metropolis";
            Dictionary[Game.Enums.Stage.PowerPlant]          = "Power Plant";
            Dictionary[Game.Enums.Stage.CasinoPark]          = "Casino Park";
            Dictionary[Game.Enums.Stage.BingoHighway]        = "Bingo Highway";
            Dictionary[Game.Enums.Stage.RailCanyon]          = "Rail Canyon";
            Dictionary[Game.Enums.Stage.BulletStation]       = "Bullet Station";
            Dictionary[Game.Enums.Stage.FrogForest]          = "Frog Forest";
            Dictionary[Game.Enums.Stage.LostJungle]          = "Lost Jungle";
            Dictionary[Game.Enums.Stage.HangCastle]          = "Hang Castle";
            Dictionary[Game.Enums.Stage.MysticMansion]       = "Mystic Mansion";
            Dictionary[Game.Enums.Stage.EggFleet]            = "Egg Fleet";
            Dictionary[Game.Enums.Stage.FinalFortress]       = "Final Fortress";

            Dictionary[Game.Enums.Stage.EggHawk]             = "Egg Hawk";
            Dictionary[Game.Enums.Stage.TeamBattle1]         = "Team Battle 1";
            Dictionary[Game.Enums.Stage.TeamBattle2]         = "Team Battle 2";
            Dictionary[Game.Enums.Stage.RobotStorm]          = "Robot Storm";
            Dictionary[Game.Enums.Stage.EggEmperor]          = "Egg Emperor";
            Dictionary[Game.Enums.Stage.MetalMadness]        = "Metal Madness";
            Dictionary[Game.Enums.Stage.MetalOverlord]       = "Metal Overlord";

            Dictionary[Game.Enums.Stage.SeaGate]             = "Sea Gate";

            Dictionary[Game.Enums.Stage.SeasideCourse]       = "Seaside Course (2P)";
            Dictionary[Game.Enums.Stage.CityCourse]          = "City Course (2P)";
            Dictionary[Game.Enums.Stage.CasinoCourse]        = "Casino Course (2P)";

            Dictionary[Game.Enums.Stage.BonusStage1]         = "Bonus Stage 1";
            Dictionary[Game.Enums.Stage.BonusStage2]         = "Bonus Stage 2";
            Dictionary[Game.Enums.Stage.BonusStage3]         = "Bonus Stage 3";
            Dictionary[Game.Enums.Stage.BonusStage4]         = "Bonus Stage 4";
            Dictionary[Game.Enums.Stage.BonusStage5]         = "Bonus Stage 5";
            Dictionary[Game.Enums.Stage.BonusStage6]         = "Bonus Stage 6";
            Dictionary[Game.Enums.Stage.BonusStage7]         = "Bonus Stage 7";

            Dictionary[Game.Enums.Stage.SeasideHill2P]       = "Seaside Hill (2P)";
            Dictionary[Game.Enums.Stage.GrandMetropolis2P]   = "Grand Metropolis (2P)";
            Dictionary[Game.Enums.Stage.BingoHighway2P]      = "Bingo Highway (2P)";

            Dictionary[Game.Enums.Stage.CityTopBattle]       = "City Top (2P)";
            Dictionary[Game.Enums.Stage.CasinoRingBattle]    = "Casino Ring (2P)";
            Dictionary[Game.Enums.Stage.TurtleShellBattle]   = "Turtle Shell (2P)";

            Dictionary[Game.Enums.Stage.EggTreat]            = "Egg Treat (2P)";
            Dictionary[Game.Enums.Stage.PinballMatch]        = "Pinball Match (2P)";
            Dictionary[Game.Enums.Stage.HotElevator]         = "Hot Elevator (2P)";

            Dictionary[Game.Enums.Stage.RoadRock]            = "Road Rock (2P)";
            Dictionary[Game.Enums.Stage.MadExpress]          = "Mad Express (2P)";
            Dictionary[Game.Enums.Stage.TerrorHall]          = "Terror Hall (2P)";

            Dictionary[Game.Enums.Stage.RailCanyonExpert]    = "Rail Canyon (2P)";
            Dictionary[Game.Enums.Stage.FrogForestExpert]    = "Frog Forest (2P)";
            Dictionary[Game.Enums.Stage.EggFleetExpert]      = "Egg Fleet (2P)";

            Dictionary[Game.Enums.Stage.EmeraldChallenge1]   = "Emerald Challenge 1";
            Dictionary[Game.Enums.Stage.EmeraldChallenge2]   = "Emerald Challenge 2";
            Dictionary[Game.Enums.Stage.EmeraldChallenge3]   = "Emerald Challenge 3";
            Dictionary[Game.Enums.Stage.EmeraldChallenge4]   = "Emerald Challenge 4";
            Dictionary[Game.Enums.Stage.EmeraldChallenge5]   = "Emerald Challenge 5";
            Dictionary[Game.Enums.Stage.EmeraldChallenge6]   = "Emerald Challenge 6";
            Dictionary[Game.Enums.Stage.EmeraldChallenge7]   = "Emerald Challenge 7";

            Dictionary[Game.Enums.Stage.SpecialStageMultiplayer1] = "Special Stage 1 (2P)";
            Dictionary[Game.Enums.Stage.SpecialStageMultiplayer2] = "Special Stage 2 (2P)";
            Dictionary[Game.Enums.Stage.SpecialStageMultiplayer3] = "Special Stage 3 (2P)";
        }
    }
}
