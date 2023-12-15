using Heroes.SDK.Classes.PseudoNativeClasses;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Structures.Stage.Spawn;
using Heroes.SDK.Definitions.Structures.Stage.Spawn.Collections;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.API
{
    /// <summary>
    /// API for editing and/or making changes to stages.
    /// </summary>
    public static unsafe class Stage
    {
        /// <summary>
        /// Singleplayer start positions for each team.
        /// </summary>
        public static FixedArrayPtr<SingleplayerStart> SinglePlayerStart => StageFunctions.SinglePlayerStart;

        /// <summary>
        /// End positions for each team.
        /// </summary>
        public static FixedArrayPtr<SingleplayerEnd> BothPlayerEnd => StageFunctions.BothPlayerEnd;

        /// <summary>
        /// Multiplayer start positions for each team.
        /// </summary>
        public static FixedArrayPtr<MultiplayerStart> MultiplayerStart => StageFunctions.MultiplayerStart;

        /// <summary>
        /// Multiplayer end positions for each team.
        /// </summary>
        public static FixedArrayPtr<MultiplayerBrag> MultiPlayerBrag => StageFunctions.MultiPlayerBrag;

        /// <summary>
        /// Attempts to retrieve the end position for a given team.
        /// </summary>
        /// <param name="team">The team to get the position for.</param>
        /// <param name="goalPosition">Pointer to the end position for this team.</param>
        /// <returns>False if goal position for team not found, else true.</returns>
        public static bool TryGetGoalPosition(Team team, out Ptr<PositionEnd> goalPosition)
        {
            var spawnPtr = StageFunctions.GetEndPosition(team);
            goalPosition = new Ptr<PositionEnd>(spawnPtr);
            return goalPosition.Pointer != (void*)0;
        }

        /// <summary>
        /// Retrieves the start position for a given team.
        /// </summary>
        /// <param name="team">The team to get the position for.</param>
        /// <param name="startPosition">Pointer to the start position for this team.</param>
        /// <returns>False if start position for team not found, else true.</returns>
        public static bool TryGetStartPosition(Team team, out Ptr<PositionStart> startPosition)
        {
            var spawnPtr = StageFunctions.GetStartPosition(team);
            startPosition = new Ptr<PositionStart>(spawnPtr);
            return startPosition.Pointer != (void*)0;
        }

        /// <summary>
        /// Retrieves the start position for a given team.
        /// </summary>
        /// <param name="team">The team to get the position for.</param>
        /// <param name="introPosition">Pointer to the intro position for this team.</param>
        public static bool TryGetIntroPosition(Team team, out Ptr<PositionEnd> introPosition)
        {
            var spawnPtr = StageFunctions.GetIntroPosition(team);
            introPosition = new Ptr<PositionEnd>(spawnPtr);
            return introPosition.Pointer != (void*)0;
        }
    }
}
