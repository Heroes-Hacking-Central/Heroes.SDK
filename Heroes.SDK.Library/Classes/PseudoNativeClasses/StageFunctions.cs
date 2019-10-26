﻿using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Structures.Stage.Spawn;
using Heroes.SDK.Definitions.Structures.Stage.Spawn.Collections;
using Heroes.SDK.Definitions.Structures.Stage.Splines;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.Classes.PseudoNativeClasses
{
    public static unsafe class StageFunctions
    {
        private const int SinglePlayerStartEntryLength  = 27;
        private const int BothPlayerEndEntryLength      = 60;
        private const int MultiPlayerStartEntryLength   = 23;
        private const int MultiPlayerBragEntryLength    = 21;

        /// <summary> Singleplayer start positions for each team. </summary>
        public static RefFixedArrayPtr<SingleplayerStart> SinglePlayerStart { get; } = new RefFixedArrayPtr<SingleplayerStart>(0x7C2FC8, SinglePlayerStartEntryLength);

        /// <summary> End positions for each team. </summary>
        public static RefFixedArrayPtr<SingleplayerEnd> BothPlayerEnd { get; } = new RefFixedArrayPtr<SingleplayerEnd>(0x7C45B8, BothPlayerEndEntryLength);

        /// <summary> Multiplayer start positions for each team. </summary>
        public static RefFixedArrayPtr<MultiplayerStart> MultiplayerStart { get; } = new RefFixedArrayPtr<MultiplayerStart>(0x7C5E18, MultiPlayerStartEntryLength);

        /// <summary> Multiplayer end positions for each team. </summary>
        public static RefFixedArrayPtr<MultiplayerBrag> MultiPlayerBrag { get; } = new RefFixedArrayPtr<MultiplayerBrag>(0x7C6380, MultiPlayerBragEntryLength);


        /* Function Declarations */
        public static Function<SearchGoalStageLocator>  Fun_GetEndPosition { get; } = new Function<SearchGoalStageLocator>(0x00426FD0, Reloaded.ReloadedHooks);
        public static Function<SearchStartStageLocator> Fun_GetStartPosition { get; } = new Function<SearchStartStageLocator>(0x00426F10, Reloaded.ReloadedHooks);
        public static Function<SearchIntroStageLocator>  Fun_GetIntroPosition { get; } = new Function<SearchIntroStageLocator>(0x00427010, Reloaded.ReloadedHooks);
        public static Function<InitPath>  Fun_InitializeSplines { get; } = new Function<InitPath>(0x00439020, Reloaded.ReloadedHooks);

        /* Functions */
        public static SearchGoalStageLocator GetEndPosition     { get; } = Fun_GetEndPosition.GetWrapper();
        public static SearchStartStageLocator GetStartPosition  { get; } = Fun_GetStartPosition.GetWrapper();
        public static SearchIntroStageLocator GetIntroPosition  { get; } = Fun_GetIntroPosition.GetWrapper();
        public static InitPath InitializeSplines                { get; } = Fun_InitializeSplines.GetWrapper();

        /* Function Definitions */

        /// <summary>
        /// Retrieves the end position for a given team.
        /// </summary>
        /// <param name="team">The team to get the position for.</param>
        /// <returns>0 if no end position found, else address of position.</returns>
        [Function(FunctionAttribute.Register.esi, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate PositionEnd* SearchGoalStageLocator(Team team); // 00426FD0

        /// <summary>
        /// Retrieves the start position for a given team.
        /// </summary>
        /// <param name="team">The team to get the position for.</param>
        /// <returns>0 if no end position found, else address of position.</returns>
        [Function(FunctionAttribute.Register.eax, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate PositionStart* SearchStartStageLocator(Team team); // 00426F10

        /// <summary>
        /// Retrieves the start position for a given team.
        /// </summary>
        /// <param name="team">The team to get the position for.</param>
        [Function(FunctionAttribute.Register.eax, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate PositionEnd* SearchIntroStageLocator(Team team); // 00427010

        /// <summary>
        /// Loads a spline given the address of the first element of an array of pointers to splines.
        /// </summary>
        /// <param name="splinePointerArray">Address of array of pointers to splines.</param>
        /// <returns>A value of 1 or 0 for success/failure.</returns>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool InitPath(Spline** splinePointerArray); // 0x00439020

    }
}
