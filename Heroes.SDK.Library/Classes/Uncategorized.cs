using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Heroes.SDK.Definitions.Structures.Media.Video;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions.X86;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute;

namespace Heroes.SDK.Classes
{
    public unsafe struct Uncategorized
    {
        /* Function Declarations */
        public static Function<DrawSpecialStageGauge> Fun_DrawSpecialStageGauge { get; } = new Function<DrawSpecialStageGauge>(0x5263C0, ReloadedHooks.Instance);
        public static Function<DrawSpecialStageBar> Fun_DrawSpecialStageBar { get; } = new Function<DrawSpecialStageBar>(0x526280, ReloadedHooks.Instance);
        public static Function<DrawTwoPlayerStatusBar> Fun_DrawTwoPlayerStatusBar { get; } = new Function<DrawTwoPlayerStatusBar>(0x422A70, ReloadedHooks.Instance);
        public static Function<RenderVideoFrame> Fun_RenderVideoFrame { get; } = new Function<RenderVideoFrame>(0x644450, ReloadedHooks.Instance);
        public static Function<DrawFullVideoFrame> Fun_DrawFullVideoFrame { get; } = new Function<DrawFullVideoFrame>(0x0042A100, ReloadedHooks.Instance);
        public static Function<DrawSmallFrame> Fun_DrawSmallFrame { get; } = new Function<DrawSmallFrame>(0x00429F80, ReloadedHooks.Instance);
        public static Function<Calls_DrawSpecialStageLinkText> Fun_DrawSpecialStageLinkText { get; } = new Function<Calls_DrawSpecialStageLinkText>(0x526F60, ReloadedHooks.Instance);
        public static Function<DrawNowLoading> Fun_DrawNowLoading { get; } = new Function<DrawNowLoading>(0x44EAC0, ReloadedHooks.Instance);
        public static Function<DrawViewPorts> Fun_DrawViewPorts { get; } = new Function<DrawViewPorts>(0x422AF0, ReloadedHooks.Instance);
        public static Function<DrawTitlecardElements> Fun_DrawTitlecardElements { get; } = new Function<DrawTitlecardElements>(0x442850, ReloadedHooks.Instance);
        public static Function<TObjCreditsExecute> Fun_TObjCreditsExecute { get; } = new Function<TObjCreditsExecute>(0x4545F0, ReloadedHooks.Instance);
        public static Function<DrawSpecialStageEmeraldAndResultScreenGauge> Fun_DrawSpecialStageEmeraldAndResultScreenGauge { get; } = new Function<DrawSpecialStageEmeraldAndResultScreenGauge>(0x458920, ReloadedHooks.Instance);
        public static Function<DrawResultScreenLevelupDotsAndSomeOtherElements> Fun_DrawResultScreenLevelupDotsAndSomeOtherElements { get; } = new Function<DrawResultScreenLevelupDotsAndSomeOtherElements>(0x438A90, ReloadedHooks.Instance);
        public static Function<DrawPowerupBox> Fun_DrawPowerupBox { get; } = new Function<DrawPowerupBox>(0x479AB0, ReloadedHooks.Instance);

        /* Function Definitions */

        /// <summary>
        /// Draws the special stage gauge, which contains the internal bar.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(Register.eax, Register.eax, StackCleanup.Caller)]
        public delegate int DrawSpecialStageGauge(int preserveEax, float x, float y, float width, float height, int a5, int a6, int a7, float a8, float a9);

        /// <summary>
        /// Draws the special stage bar inside the <see cref="DrawSpecialStageGauge"/>
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(Register.eax, Register.eax, StackCleanup.Caller)]
        public delegate int DrawSpecialStageBar(int preserveEax, float x, float y, float width, float height);

        /// <summary>
        /// Draws the status bar at the bottom of the screen in 2P mode, showing relative position of teams to goal ring.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(Register.eax, Register.eax, StackCleanup.Caller)]
        public delegate int DrawTwoPlayerStatusBar(int preserveEax, float x, float y, float width, float height);

        /// <summary>
        /// Renders a single frame of a SofDec video.
        /// This is not a CRI function but a game one.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee)]
        public delegate int RenderVideoFrame(VideoRenderProperties* properties, int a2);

        /// <summary>
        /// Renders a single frame of a SofDec video which covers the whole screen.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { Register.ebx }, Register.eax, StackCleanup.Caller)]
        public delegate int DrawFullVideoFrame(int ebx, float x, float y, float width, float height, int a5, float a6, float a7); // sub_42A100

        /// <summary>
        /// Renders a single frame of a SofDec video which is displayed in a corner of the screen.
        /// Used in the credits sequence.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { Register.ebx }, Register.eax, StackCleanup.Caller)]
        public delegate int DrawSmallFrame(int ebx, float x, float y, float width, float height, int a5);

        /// <summary>
        /// Special stage link text is drawn inside this function.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee)]
        public delegate int Calls_DrawSpecialStageLinkText(int preserveEax, int a1, float a2, float a3, float a4, float a5, int a6, int a7,
            int a8, int a9, int a10);

        /// <summary>
        /// Renders the "Now Loading" text.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { Register.eax, Register.ecx, Register.ebx }, Register.eax, StackCleanup.Caller)]
        public delegate int* DrawNowLoading(int a1, char* a2, float* a3);

        /// <summary>
        /// Renders the viewports of the game.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate int DrawViewPorts();

        /// <summary>
        /// Draws individual titlecard elements such as the mission text.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.MicrosoftThiscall)]
        public delegate int DrawTitlecardElements(int thisPtr);

        /// <summary>
        /// Executes the credits sequence.
        /// TObjCredits is added here as placeholder.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.MicrosoftThiscall)]
        public delegate int TObjCreditsExecute(int thisPtr);

        /// <summary>
        /// Draws the special stage emerald indicator and the emerald gauge on results screen.
        /// Note: Does not hook well. Expects data up the stack.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { Register.eax, Register.esi }, Register.eax, StackCleanup.Callee)]
        public delegate void* DrawSpecialStageEmeraldAndResultScreenGauge(void* preserveEax, void* preserveEsi, float x, float y, float width, float height);

        /// <summary>
        /// Draws the level up dots on the result screen.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(CallingConventions.Cdecl)]
        public delegate void* DrawResultScreenLevelupDotsAndSomeOtherElements();

        /// <summary>
        /// Draws a powerup box onto the screen projection.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee)]
        public delegate void* DrawPowerupBox(void* preseveEax, float probablyX, float probablyY, float size); // 479AB0
    }
}
