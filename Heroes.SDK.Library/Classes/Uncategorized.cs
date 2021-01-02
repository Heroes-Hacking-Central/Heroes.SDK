using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Heroes.SDK.Definitions.Structures.Media.Video;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute;

namespace Heroes.SDK.Classes
{
    public unsafe struct Uncategorized
    {
        /* Function Declarations */
        public static IFunction<DrawSpecialStageGauge> Fun_DrawSpecialStageGauge { get; } = SDK.ReloadedHooks.CreateFunction<DrawSpecialStageGauge>(0x5263C0);
        public static IFunction<DrawSpecialStageBar> Fun_DrawSpecialStageBar { get; } = SDK.ReloadedHooks.CreateFunction<DrawSpecialStageBar>(0x526280);
        public static IFunction<DrawTwoPlayerStatusBar> Fun_DrawTwoPlayerStatusBar { get; } = SDK.ReloadedHooks.CreateFunction<DrawTwoPlayerStatusBar>(0x422A70);
        public static IFunction<RenderVideoFrame> Fun_RenderVideoFrame { get; } = SDK.ReloadedHooks.CreateFunction<RenderVideoFrame>(0x644450);
        public static IFunction<DrawFullVideoFrame> Fun_DrawFullVideoFrame { get; } = SDK.ReloadedHooks.CreateFunction<DrawFullVideoFrame>(0x0042A100);
        public static IFunction<DrawSmallFrame> Fun_DrawSmallFrame { get; } = SDK.ReloadedHooks.CreateFunction<DrawSmallFrame>(0x00429F80);
        public static IFunction<Calls_DrawSpecialStageLinkText> Fun_DrawSpecialStageLinkText { get; } = SDK.ReloadedHooks.CreateFunction<Calls_DrawSpecialStageLinkText>(0x526F60);
        public static IFunction<DrawNowLoading> Fun_DrawNowLoading { get; } = SDK.ReloadedHooks.CreateFunction<DrawNowLoading>(0x44EAC0);
        public static IFunction<DrawViewPorts> Fun_DrawViewPorts { get; } = SDK.ReloadedHooks.CreateFunction<DrawViewPorts>(0x422AF0);
        public static IFunction<DrawTitlecardElements> Fun_DrawTitlecardElements { get; } = SDK.ReloadedHooks.CreateFunction<DrawTitlecardElements>(0x442850);
        public static IFunction<TObjCreditsExecute> Fun_TObjCreditsExecute { get; } = SDK.ReloadedHooks.CreateFunction<TObjCreditsExecute>(0x4545F0);
        public static IFunction<DrawSpecialStageEmeraldAndResultScreenGauge> Fun_DrawSpecialStageEmeraldAndResultScreenGauge { get; } = SDK.ReloadedHooks.CreateFunction<DrawSpecialStageEmeraldAndResultScreenGauge>(0x458920);
        public static IFunction<DrawResultScreenLevelupDotsAndSomeOtherElements> Fun_DrawResultScreenLevelupDotsAndSomeOtherElements { get; } = SDK.ReloadedHooks.CreateFunction<DrawResultScreenLevelupDotsAndSomeOtherElements>(0x438A90);
        public static IFunction<DrawPowerupBox> Fun_DrawPowerupBox { get; } = SDK.ReloadedHooks.CreateFunction<DrawPowerupBox>(0x479AB0);

        /* Function Definitions */

        /// <summary>
        /// Draws the special stage gauge, which contains the internal bar.
        /// </summary>
        [Function(Register.eax, Register.eax, StackCleanup.Caller)]
        public delegate int DrawSpecialStageGauge(int preserveEax, float x, float y, float width, float height, int a5, int a6, int a7, float a8, float a9);

        /// <summary>
        /// Draws the special stage bar inside the <see cref="DrawSpecialStageGauge"/>
        /// </summary>
        [Function(Register.eax, Register.eax, StackCleanup.Caller)]
        public delegate int DrawSpecialStageBar(int preserveEax, float x, float y, float width, float height);

        /// <summary>
        /// Draws the status bar at the bottom of the screen in 2P mode, showing relative position of teams to goal ring.
        /// </summary>
        [Function(Register.eax, Register.eax, StackCleanup.Caller)]
        public delegate int DrawTwoPlayerStatusBar(int preserveEax, float x, float y, float width, float height);

        /// <summary>
        /// Renders a single frame of a SofDec video.
        /// This is not a CRI function but a game one.
        /// </summary>
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee)]
        public delegate int RenderVideoFrame(VideoRenderProperties* properties, int a2);

        /// <summary>
        /// Renders a single frame of a SofDec video which covers the whole screen.
        /// </summary>
        [Function(new[] { Register.ebx }, Register.eax, StackCleanup.Caller)]
        public delegate int DrawFullVideoFrame(int ebx, float x, float y, float width, float height, int a5, float a6, float a7); // sub_42A100

        /// <summary>
        /// Renders a single frame of a SofDec video which is displayed in a corner of the screen.
        /// Used in the credits sequence.
        /// </summary>
        [Function(new[] { Register.ebx }, Register.eax, StackCleanup.Caller)]
        public delegate int DrawSmallFrame(int ebx, float x, float y, float width, float height, int a5);

        /// <summary>
        /// Special stage link text is drawn inside this function.
        /// </summary>
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee)]
        public delegate int Calls_DrawSpecialStageLinkText(int preserveEax, int a1, float a2, float a3, float a4, float a5, int a6, int a7,
            int a8, int a9, int a10);

        /// <summary>
        /// Renders the "Now Loading" text.
        /// </summary>
        [Function(new[] { Register.eax, Register.ecx, Register.ebx }, Register.eax, StackCleanup.Caller)]
        public delegate int* DrawNowLoading(int a1, char* a2, float* a3);

        /// <summary>
        /// Renders the viewports of the game.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate int DrawViewPorts();

        /// <summary>
        /// Draws individual titlecard elements such as the mission text.
        /// </summary>
        [Function(CallingConventions.MicrosoftThiscall)]
        public delegate int DrawTitlecardElements(int thisPtr);

        /// <summary>
        /// Executes the credits sequence.
        /// TObjCredits is added here as placeholder.
        /// </summary>
        [Function(CallingConventions.MicrosoftThiscall)]
        public delegate int TObjCreditsExecute(int thisPtr);

        /// <summary>
        /// Draws the special stage emerald indicator and the emerald gauge on results screen.
        /// Note: Does not hook well. Expects data up the stack.
        /// </summary>
        [Function(new[] { Register.eax, Register.esi }, Register.eax, StackCleanup.Callee)]
        public delegate void* DrawSpecialStageEmeraldAndResultScreenGauge(void* preserveEax, void* preserveEsi, float x, float y, float width, float height);

        /// <summary>
        /// Draws the level up dots on the result screen.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate void* DrawResultScreenLevelupDotsAndSomeOtherElements();

        /// <summary>
        /// Draws a powerup box onto the screen projection.
        /// </summary>
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee)]
        public delegate void* DrawPowerupBox(void* preseveEax, float probablyX, float probablyY, float size); // 479AB0
    }
}
