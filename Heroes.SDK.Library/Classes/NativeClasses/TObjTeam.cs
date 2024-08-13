using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.RenderWare;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Structures.Input;

namespace Heroes.SDK.Classes.NativeClasses
{
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x27C)]
    public unsafe struct TObjTeam
    {
        [FieldOffset(0x0)]
        public TObject tobj;
        [FieldOffset(0x28)]
        public fixed byte gap0[4];
        [FieldOffset(0x2C)]
        public int pointer_0x2c;
        [FieldOffset(0x30)]
        public byte field_30;
        [FieldOffset(0x34)]
        public ENUM_TEAM_KIND teamKind;
        [FieldOffset(0x38)]
        public byte teamNo;
        [FieldOffset(0x39)]
        public byte numOfTeamMembersActive;
        [FieldOffset(0x3A)]
        public byte leaderPlayerNo;
        [FieldOffset(0x3B)]
        public byte nowLeaderPlayerNo;
        [FieldOffset(0x3C)]
        public byte cameraTarget;
        [FieldOffset(0x3D)]
        public byte field_3D;
        [FieldOffset(0x3E)]
        public short cameraTargetPositionHistoryCount;
        [FieldOffset(0x40)]
        public RwV3d camTargetPos;
        [FieldOffset(0x4C)]
        public fixed byte cameraTargetPositionHistory[16];
        [FieldOffset(0x10C)]
        public float flightVerticalCamSpeed;
        [FieldOffset(0x110)]
        public fixed byte playerNo[3];
        [FieldOffset(0x114)]
        public TObjPlayer* playerPtr0;
        [FieldOffset(0x118)]
        public TObjPlayer* playerPtr1;
        [FieldOffset(0x11C)]
        public TObjPlayer* playerPtr2;
        [FieldOffset(0x120)]
        public byte formationMemberNo;
        [FieldOffset(0x121)]
        public byte postedMemberNumber;
        [FieldOffset(0x122)]
        public fixed byte memberAvailableCopy_HHC[3];
        [FieldOffset(0x125)]
        public fixed byte memberAvailable_HHC[3];
        [FieldOffset(0x128)]
        public TObjPlayer* pFormationMember0;
        [FieldOffset(0x12C)]
        public TObjPlayer* pFormationMember1;
        [FieldOffset(0x130)]
        public TObjPlayer* pFormationMember2;
        [FieldOffset(0x134)]
        public TObjPlayer* pPostedMember0;
        [FieldOffset(0x138)]
        public TObjPlayer* pPostedMember1;
        [FieldOffset(0x13C)]
        public TObjPlayer* pPostedMember2;
        [FieldOffset(0x140)]
        public int formationNo;
        [FieldOffset(0x144)]
        public int oldFormationNo;
        [FieldOffset(0x148)]
        public int formationNoRelated;
        [FieldOffset(0x14C)]
        public byte controllerNo;
        [FieldOffset(0x14D)]
        public byte specialActionButtonStatus;
        [FieldOffset(0x14E)]
        public short SFACount;
        [FieldOffset(0x150)]
        public ENUM_TEAMPLAY_MODE teamPlayModeReserve;
        [FieldOffset(0x154)]
        public ENUM_TEAMPLAY_MODE teamplayMode;
        [FieldOffset(0x158)]
        public int lastTeamPlayMode;
        [FieldOffset(0x15C)]
        public fixed byte player_input_HHC[10];
        [FieldOffset(0x1FC)]
        public short autoMoveTime;
        [FieldOffset(0x1FE)]
        public short lightAttackTime;
        [FieldOffset(0x200)]
        public short speedShoesTimer;
        [FieldOffset(0x202)]
        public short MutekiTime;
        [FieldOffset(0x204)]
        public short prohibitionOfFormationChange;
        [FieldOffset(0x206)]
        public ItemFlags ItemFlags;
        [FieldOffset(0x208)]
        public fixed byte level[3];
        [FieldOffset(0x20B)]
        public byte railRideFlag;
        [FieldOffset(0x20C)]
        public byte gap20C;
        [FieldOffset(0x20D)]
        public fixed byte prohibitFormationChangeNo[3];
        [FieldOffset(0x210)]
        public byte field_210;
        [FieldOffset(0x211)]
        public fixed byte gap211[11];
        [FieldOffset(0x21C)]
        public byte SFADamageForEnemy;
        [FieldOffset(0x21D)]
        public byte neonScreen;
        [FieldOffset(0x21E)]
        public byte whiteScreen;
        [FieldOffset(0x220)]
        public RwV3d SFABasePos;
        [FieldOffset(0x22C)]
        public byte SFABaseAngleY;
        [FieldOffset(0x230)]
        public void* field_230;
        [FieldOffset(0x234)]
        public fixed byte gap234[8];
        [FieldOffset(0x23C)]
        public int chaotixClearItem;
        [FieldOffset(0x240)]
        public fixed byte gap240[12];
        [FieldOffset(0x24C)]
        public fixed byte techniquePoint[8];
        [FieldOffset(0x254)]
        public fixed byte techniquePoint2[8];
        [FieldOffset(0x25C)]
        public fixed byte techniquePoint3[8];
        [FieldOffset(0x264)]
        public byte suitNo;
        [FieldOffset(0x265)]
        public byte isCasinoBallLane;
        [FieldOffset(0x266)]
        public byte byte_0x266;
        [FieldOffset(0x267)]
        public byte dontUsePinballMode;
        [FieldOffset(0x268)]
        public int* cameraMotionGoal;
        [FieldOffset(0x26C)]
        public void* cameraMotionTB;
        [FieldOffset(0x270)]
        public void* cameraMotionTB2;
        [FieldOffset(0x274)]
        public fixed byte gap274[4];
        [FieldOffset(0x278)]
        public int field_278;


        public static IFunction<Native_Exec> Fun_Exec { get; } = SDK.ReloadedHooks.CreateFunction<Native_Exec>(0x005B10E0);

        /* Bindings */
        public void* Exec()
        {
            return Fun_Exec.GetWrapper()(ref this);
        }

        /* Definitions */
        [Function(CallingConventions.MicrosoftThiscall)]
        public delegate void* Native_Exec(ref TObjTeam thisPointer);
    }
}
