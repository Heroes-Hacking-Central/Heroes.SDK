using System;
using System.Collections.Generic;
using System.Text;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Utilities.Tagger.Enums;
using static Heroes.SDK.Utilities.Misc.Mathematics;

namespace Heroes.SDK.Utilities.Tagger
{
    public static class Tagger
    {
        /// <summary>
        /// Converts an individual stage into a set of tags which categorize the individual stage.
        /// </summary>
        /// <param name="stage">The stage to categorize.</param>
        /// <returns>A list of individual tags (as flags) for a stage.</returns>
        public static StageTag GetStageTags(Stage stage)
        {
            // Set default tag.
            StageTag stageTag = 0;

            // Exclusive Stages
            if (stage == Stage.TestLevel || stage == Stage.RailCanyonChaotix)
                stageTag |= StageTag.Exclusive;

            // Battle Stages
            if (IsBetween((int) stage, (int)Stage.EggHawk, (int)Stage.MetalOverlord) ||
                IsBetween((int) stage, (int)Stage.CityTopBattle, (int)Stage.TurtleShellBattle))
                stageTag |= StageTag.Battle;

            // Tutorial Stage
            if (stage == Stage.SeaGate)
                stageTag |= StageTag.Tutorial;

            // Bobsled Stage
            if (IsBetween((int) stage, (int)Stage.SeasideCourse, (int)Stage.CasinoCourse))
                stageTag |= StageTag.Bobsled;

            // Bonus Stage
            if (IsBetween((int) stage, (int)Stage.BonusStage1, (int)Stage.BonusStage7))
                stageTag |= StageTag.Bonus;

            // Two Player
            if (IsBetween((int) stage, (int)Stage.SeasideHill2P, (int)Stage.EggFleetExpert) ||
                IsBetween((int) stage, (int)Stage.SeasideCourse, (int)Stage.CasinoCourse) ||
                IsBetween((int) stage, (int)Stage.SpecialStageMultiplayer1, (int)Stage.SpecialStageMultiplayer3))
                stageTag |= StageTag.TwoPlayer;

            // Special Stage
            if (IsBetween((int) stage, (int)Stage.EmeraldChallenge1, (int)Stage.EmeraldChallenge7) ||
                IsBetween((int) stage, (int)Stage.SpecialStageMultiplayer1, (int)Stage.SpecialStageMultiplayer3))
                stageTag |= StageTag.Special;

            return stageTag;
        }
    }
}
