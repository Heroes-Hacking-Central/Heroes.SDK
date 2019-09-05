using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Heroes.SDK.Game.Enums;

namespace Heroes.SDK.Game.Structures
{
    [StructLayout(LayoutKind.Sequential, Size = 0x44)]
    public unsafe struct ModeSwitch
    {
        // TODO: Document this struct.

        public fixed byte Gap0[4];

        public byte CommonTextureDataMaybe;
        public byte HideGui;
        public byte HideGui2;
        public byte HideGui3;
        public byte HideGuiAndGeometryMaybe;
        public byte HideGui4;
        public byte HideGui5;

        public fixed byte GapB[6];

        /// <summary>
        /// [Unused]
        /// </summary>
        public PalMode PalMode;

        /// <summary>
        /// [Unused]
        /// Toggles between different sound modes such as Mono, Stereo.
        /// </summary>
        public byte SoundMode;

        /// <summary>
        /// Current language set for text.
        /// </summary>
        public Language TextLanguage;

        /// <summary>
        /// [Unchecked]
        /// Enables speech if true.
        /// </summary>
        public bool LocalSpeech;

        /// <summary>
        /// True if playback of BGM is enabled, else false.
        /// </summary>
        public bool IsPlayBgm;

        /// <summary>
        /// True if currently executing demo mode, else false.
        /// </summary>
        public bool DemoMode;

        /// <summary>
        /// Shows the RenderWare Maestro UI elements during gameplay.
        /// </summary>
        public byte ShowGDisp;

        /// <summary>
        /// Shows the spinning ring RenderWare Maestro UI element.
        /// </summary>
        public byte ShowGDispRing;

        public fixed byte Gap1C[2];

        /// <summary>
        /// True if playing with a friend, else false.
        /// </summary>
        public bool Is2PMode;

        public bool TimeStop;
        public byte SfaScreen;
        public bool SetObjInteraction;
        public bool HideTextAndNumbers;

        /// <summary>
        /// If enabled, player does not die due to death collision.
        /// </summary>
        public bool NoDeathFromFall;

        /// <summary>
        /// Defines the current objective. e.g. Kill All Enemies
        /// </summary>
        public PlayMode PlayMode;

        /// <summary>
        /// The type of the currently played mission, e.g. Ring Collection, Destroy Robots.
        /// </summary>
        public MissionType MissionType;

        public byte DontMovegdispStack;

        /// <summary>
        /// True if currently in Story Mode, else false.
        /// </summary>
        public bool IsStoryMode;

        /// <summary>
        /// Current mission.
        /// </summary>
        public MissionMode Mission;

        /// <summary>
        /// Toggles between vertical and horizontal splitscreen modes.
        /// </summary>
        public Orientation SplitscreenOrientation;

        public byte ReturnToMenuId;

        /// <summary>
        /// Total number of "???" since the save was started.
        /// </summary>
        public int PlayTime;

        public int Frame;
        public int TimeStopframe;
        public int GameExecTypeMaybe;
        public fixed byte Gap3C[4];

        /// <summary>
        /// Current event number if playing Story Mode.
        /// </summary>
        public int EventNumber;
    }
}
