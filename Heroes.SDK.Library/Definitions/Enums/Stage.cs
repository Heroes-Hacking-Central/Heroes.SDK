using Heroes.SDK.Custom;

namespace Heroes.SDK.Definitions.Enums
{
    /// <summary>
    /// All of the individual IDs used for each stage. Each is an [int]
    /// </summary>
    public enum Stage : int
    {
        Null = 0x00,

        // Stages

        [FileName("stg00")]
        TestLevel = 1,

        [FileName("s01")]
        SeasideHill = 2,

        [FileName("s02")]
        OceanPalace = 3,

        [FileName("s03")]
        GrandMetropolis = 4,

        [FileName("s04")]
        PowerPlant = 5,

        [FileName("stg05")]
        CasinoPark = 6,

        [FileName("stg06")]
        BingoHighway = 7,

        [FileName("stg07")]
        RailCanyon = 8,

        [FileName("stg08")]
        BulletStation = 9,

        [FileName("stg09")]
        FrogForest = 10,

        [FileName("stg10")]
        LostJungle = 11,

        [FileName("s11")]
        HangCastle = 12,

        [FileName("s12")]
        MysticMansion = 13,

        [FileName("s13")]
        EggFleet = 14,

        [FileName("s14")]
        FinalFortress = 15,

        // Battles
        [FileName("s20")]
        EggHawk = 16,

        [FileName("s21")]
        TeamBattle1 = 17,

        [FileName("s22")]
        RobotCarnival = 18,

        [FileName("s23")]
        EggAlbatross = 19,

        [FileName("stg24")]
        TeamBattle2 = 20,

        [FileName("s25")]
        RobotStorm = 21,

        [FileName("stg26")]
        EggEmperor = 22,

        [FileName("s27")]
        MetalMadness = 23,

        [FileName("s28")]
        MetalOverlord = 24,

        // Tutorial
        [FileName("s29")]
        SeaGate = 25,

        // Bobsled
        [FileName("s31")]
        SeasideCourse = 26,

        [FileName("s32")]
        CityCourse = 27,

        [FileName("s33")]
        CasinoCourse = 28,

        // Bonus
        [FileName("stg40")]
        BonusStage1 = 29,

        [FileName("stg41")]
        BonusStage2 = 30,

        [FileName("stg42")]
        BonusStage3 = 31,

        [FileName("stg43")]
        BonusStage4 = 32,

        [FileName("stg44")]
        BonusStage5 = 33,

        [FileName("stg45")]
        BonusStage6 = 34,

        [FileName("stg46")]
        BonusStage7 = 35,

        // Actually Special
        [FileName("stg50")]
        RailCanyonChaotix = 36,

        // 2P Action Race

        [FileName("s60")]
        SeasideHill2P = 37,

        [FileName("s61")]
        GrandMetropolis2P = 38,

        [FileName("stg62")]
        BingoHighway2P = 39,

        // 2P Battle

        [FileName("s63")]
        CityTopBattle = 40,

        [FileName("stg64")]
        CasinoRingBattle = 41,

        [FileName("s65")]
        TurtleShellBattle = 42,

        // 2P Ring Race

        [FileName("s66")]
        EggTreat = 43,

        [FileName("stg67")]
        PinballMatch = 44,

        [FileName("s68")]
        HotElevator = 45,

        // 2P Quick Race

        [FileName("s69")]
        RoadRock = 46,

        [FileName("stg70")]
        MadExpress = 47,

        [FileName("s71")]
        TerrorHall = 48,

        // 2P Expert Race

        [FileName("stg72")]
        RailCanyonExpert = 49,

        [FileName("stg73")]
        FrogForestExpert = 50,

        [FileName("s74")]
        EggFleetExpert = 51,

        // Emerald Challenge (Special Stage)

        [FileName("stg80")]
        EmeraldChallenge1 = 52,

        [FileName("stg81")]
        EmeraldChallenge2 = 53,

        [FileName("stg82")]
        EmeraldChallenge3 = 54,

        [FileName("stg83")]
        EmeraldChallenge4 = 55,

        [FileName("stg84")]
        EmeraldChallenge5 = 56,

        [FileName("stg85")]
        EmeraldChallenge6 = 57,

        [FileName("stg86")]
        EmeraldChallenge7 = 58,

        // 2P Special Stage

        [FileName("stg87")]
        SpecialStageMultiplayer1 = 59,

        [FileName("stg88")]
        SpecialStageMultiplayer2 = 60,

        [FileName("stg89")]
        SpecialStageMultiplayer3 = 61
    }
}
