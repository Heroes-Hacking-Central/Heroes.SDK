using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Enums;

namespace Heroes.SDK.Definitions.Structures.State
{
    [Equals(DoNotAddEqualityOperators =true)]
    [StructLayout(LayoutKind.Sequential, Size = 0x44)]
    public unsafe struct ModeSwitch
    {
        // TODO: Document this struct.

        public fixed byte Gap0[4];

        public byte CommonTextureDataMaybe;
        public byte HideGui;
        public byte HideGui2;
        public byte HideGui3;

        /* Offset: 8 */

        public byte HideGuiAndGeometryMaybe;
        public byte HideGui4;
        public byte HideGui5;

        public fixed byte GapB[5];

        /* Offset: 16 */
        public fixed byte Gap10[1];

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

        public byte field_15;

        /// <summary>
        /// True if playback of BGM is enabled, else false.
        /// </summary>
        public bool IsPlayBgm;

        public byte field_17;

        /* Offset: 24 */

        /// <summary>
        /// True if currently executing demo mode, else false.
        /// </summary>
        public bool DemoMode;

        public byte field_19;

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

        /* Offset: 32 */
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

        /* Offset: 40 */

        /// <summary>
        /// Current mission.
        /// </summary>
        public MissionMode Mission;

        /// <summary>
        /// Toggles between vertical and horizontal splitscreen modes.
        /// </summary>
        public Orientation SplitscreenOrientation;

        public byte ReturnToMenuId;
        public byte field_2B;

        /// <summary>
        /// Total number of "???" since the save was started.
        /// </summary>
        public int PlayTime;

        /* Offset: 48 */
        public int Frame;
        public int TimeStopframe;

        /* Offset: 56 */

        /// <summary>
        /// Current mode of the game.
        /// </summary>
        public SystemMode SystemMode;

        public int Gap3C;

        /// <summary>
        /// Current event number if playing Story Mode.
        /// </summary>
        public int EventNumber;
    }
}
