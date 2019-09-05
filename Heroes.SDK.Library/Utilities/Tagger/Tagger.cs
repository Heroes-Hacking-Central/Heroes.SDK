using System;
using System.Collections.Generic;
using System.Text;
using Heroes.SDK.Game.Enums;
using Heroes.SDK.Utilities.Tagger.Enums;
using static Heroes.SDK.Utility.Mathematics;

namespace Heroes.SDK.Utilities.Tagger
{
    public static class Tagger
    {
        /// <summary>
        /// Converts an individual stage into a set of tags which categorize the individual stage.
        /// </summary>
        /// <param name="stage">The stage to categorize.</param>
        /// <returns>A list of individual tags (as flags) for a stage.</returns>
        public static StageTag GetStageTags(Game.Enums.Stage stage)
        {
            // Set default tag.
            StageTag stageTag = 0;

            // Exclusive Stages
            if (stage == Game.Enums.Stage.TestLevel || stage == Game.Enums.Stage.RailCanyonChaotix)
                stageTag |= StageTag.Exclusive;

            // Battle Stages
            if (IsBetween((int) stage, (int)Game.Enums.Stage.EggHawk, (int)Game.Enums.Stage.MetalOverlord) ||
                IsBetween((int) stage, (int)Game.Enums.Stage.CityTopBattle, (int)Game.Enums.Stage.TurtleShellBattle))
                stageTag |= StageTag.Battle;

            // Tutorial Stage
            if (stage == Game.Enums.Stage.SeaGate)
                stageTag |= StageTag.Tutorial;

            // Bobsled Stage
            if (IsBetween((int) stage, (int)Game.Enums.Stage.SeasideCourse, (int)Game.Enums.Stage.CasinoCourse))
                stageTag |= StageTag.Bobsled;

            // Bonus Stage
            if (IsBetween((int) stage, (int)Game.Enums.Stage.BonusStage1, (int)Game.Enums.Stage.BonusStage7))
                stageTag |= StageTag.Bonus;

            // Two Player
            if (IsBetween((int) stage, (int)Game.Enums.Stage.SeasideHill2P, (int)Game.Enums.Stage.EggFleetExpert) ||
                IsBetween((int) stage, (int)Game.Enums.Stage.SeasideCourse, (int)Game.Enums.Stage.CasinoCourse) ||
                IsBetween((int) stage, (int)Game.Enums.Stage.SpecialStageMultiplayer1, (int)Game.Enums.Stage.SpecialStageMultiplayer3))
                stageTag |= StageTag.TwoPlayer;

            // Special Stage
            if (IsBetween((int) stage, (int)Game.Enums.Stage.EmeraldChallenge1, (int)Game.Enums.Stage.EmeraldChallenge7) ||
                IsBetween((int) stage, (int)Game.Enums.Stage.SpecialStageMultiplayer1, (int)Game.Enums.Stage.SpecialStageMultiplayer3))
                stageTag |= StageTag.Special;

            return stageTag;
        }
    }
}
