using System.Runtime.InteropServices;
using System.Numerics;
using Heroes.SDK.Definitions.Structures.Player;
using Heroes.SDK.Definitions.Enums;

namespace Heroes.SDK.Classes.NativeClasses
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0xA40)]
    public unsafe struct TObjPlayer
    {
        [FieldOffset(0)]
        public TObject t;
        [FieldOffset(0x28)]
        public fixed byte gap28[4];
        [FieldOffset(0x2C)]
        public fixed byte colli[0x88];
        [FieldOffset(0xB4)]
        public fixed byte gapB4[6];
        [FieldOffset(0xBA)]
        public byte playerNo;
        [FieldOffset(0xBB)]
        public Character characterKind;
        [FieldOffset(0xBC)]
        public byte suitNo;
        [FieldOffset(0xBD)]
        public byte field_BD;
        [FieldOffset(0xBE)]
        public byte teamNo_HHC;
        [FieldOffset(0xBF)]
        public byte memberNo;
        [FieldOffset(0xC0)]
        public byte controllerNo;
        [FieldOffset(0xC1)]
        public byte role;
        [FieldOffset(0xC2)]
        public byte formationLeaderNo;
        [FieldOffset(0xC4)]
        public short item;
        [FieldOffset(0xC8)]
        public int equipment;
        [FieldOffset(0xCC)]
        public TObjTeam* pTObjTeam;
        [FieldOffset(0xD0)]
        public fixed byte gapD0[4];
        [FieldOffset(0xD4)]
        public short jumpBallTime;
        [FieldOffset(0xD6)]
        public short nocontimer;
        [FieldOffset(0xD8)]
        public short idleTime;
        [FieldOffset(0xDC)]
        public int nextAnimation_HHC;
        [FieldOffset(0xE0)]
        public float dotp;
        [FieldOffset(0xE4)]
        public int accel;
        [FieldOffset(0xE8)]
        public float frict;
        [FieldOffset(0xEC)]
        public float field_EC;
        [FieldOffset(0xF0)]
        public float field_F0;
        [FieldOffset(0xF4)]
        public short mode;
        [FieldOffset(0xF6)]
        public short stateCopy;
        [FieldOffset(0xF8)]
        public short smode;
        [FieldOffset(0xFA)]
        public short flashTimer;
        [FieldOffset(0xFC)]
        public Vector3 acc;
        [FieldOffset(0x108)]
        public Vector3 spd;
        [FieldOffset(0x114)]
        public Vector3 position;
        [FieldOffset(0x120)]
        public Vector3 ang;
        [FieldOffset(0x12C)]
        public Vector3 scale;
        [FieldOffset(0x138)]
        public MOTIONWK mwp;
        [FieldOffset(0x174)]
        public Vector3 field_174;
        [FieldOffset(0x180)]
        public Vector3 accelerationDirection;
        [FieldOffset(0x18C)]
        public Vector3 slopeCollisionAngleMaybe;
        [FieldOffset(0x198)]
        public int int0x198_wallJumpRotationMaybe;
        [FieldOffset(0x19C)]
        public int int0x19C_wallJumpRotationMaybe;
        [FieldOffset(0x1A0)]
        public int int0x1A0_wallJumpRotationMaybe;
        [FieldOffset(0x1A4)]
        public int attr;
        [FieldOffset(0x1A8)]
        public int last_attr;
        [FieldOffset(0x1AC)]
        public int playerStatus_0x1AC_PhysicsMaybe;
        [FieldOffset(0x1B0)]
        public fixed byte gap1B0[4];
        [FieldOffset(0x1B4)]
        public int field_1B4;
        [FieldOffset(0x1B8)]
        public int statusRelated0x1B8;
        [FieldOffset(0x1BC)]
        public short flag;
        [FieldOffset(0x1C0)]
        public byte playerStatus_0x1C0;
        [FieldOffset(0x1C4)]
        public Physics p;
        [FieldOffset(0x248)]
        public byte waterEffectIs2;
        [FieldOffset(0x250)]
        public int int_0x250;
        [FieldOffset(0x254)]
        public int int_0x254;
        [FieldOffset(0x258)]
        public float groundBelowFallMaybe;
        [FieldOffset(0x25C)]
        public float groundHeight;
        [FieldOffset(0x260)]
        public fixed byte gap260[12];
        [FieldOffset(0x26C)]
        public Vector3 flyFormationPosition;
        [FieldOffset(0x278)]
        public int targetPosGroundPolyGroupNo;
        [FieldOffset(0x27C)]
        public float field_27C;
        [FieldOffset(0x280)]
        public float notStartMovingRad;
        [FieldOffset(0x284)]
        public float distanceXZToTargetPosCopy;
        [FieldOffset(0x288)]
        public float distanceXZToTargetPos;
        [FieldOffset(0x28C)]
        public fixed byte gap28C[60];
        [FieldOffset(0x2C8)]
        public ENUM_CHAR_MODE charMode;
        [FieldOffset(0x2CA)]
        public ENUM_CHAR_MODE lastAIState;
        [FieldOffset(0x2CC)]
        public ENUM_CHAR_MODE charModeReserve;
        [FieldOffset(0x2CE)]
        public short relatedToSwitchingRails;
        [FieldOffset(0x2D0)]
        public float hpos;
        [FieldOffset(0x2D4)]
        public void* pathtag;
        [FieldOffset(0x2D8)]
        public fixed byte gap2D8[5];
        [FieldOffset(0x2DD)]
        public byte finaleFlipType;
        [FieldOffset(0x2DE)]
        public short airAttackTimer;
        [FieldOffset(0x2E0)]
        public short airAttackTimer2;
        [FieldOffset(0x2E4)]
        public void* cwp;
        [FieldOffset(0x2E8)]
        public int flyFormationYTilt;
        [FieldOffset(0x2F0)]
        public int flyFormationZTilt;
        [FieldOffset(0x2F4)]
        public int flyFormationBoostYTilt;
        [FieldOffset(0x2F8)]
        public fixed byte gap2F8[20];
        [FieldOffset(0x30C)]
        public short grindTimer;
        [FieldOffset(0x30E)]
        public fixed byte gap30E[6];
        [FieldOffset(0x314)]
        public short powerAirSpinTimer;
        [FieldOffset(0x318)]
        public float powerAirSpinPositionRelated;
        [FieldOffset(0x31C)]
        public short tornadoTimer;
        [FieldOffset(0x31E)]
        public fixed byte gap31E[6];
        [FieldOffset(0x324)]
        public Vector3 tornadoOrigin;
        [FieldOffset(0x330)]
        public float alphaAmount__;
        [FieldOffset(0x340)]
        public int someTimerMaybeFlashRelated;
        [FieldOffset(0x344)]
        public fixed byte holdingWorksMaybe[4];
        [FieldOffset(0x354)]
        public fixed byte gap354[64]; 
        [FieldOffset(0x394)]
        public byte field_394;
        [FieldOffset(0x395)]
        public byte field_395;
        [FieldOffset(0x398)]
        public short animationIndex;
        [FieldOffset(0x39A)]
        public short motion;
        [FieldOffset(0x39C)]
        public short animCopy;
        [FieldOffset(0x39E)]
        public short field_39E;
        [FieldOffset(0x3A0)]
        public short field_3A0;
        [FieldOffset(0x3A2)]
        public short field_3A2;
        [FieldOffset(0x3A4)]
        public byte animFlagMaybe;
        [FieldOffset(0x3A5)]
        public fixed byte gap3A5[7];
        [FieldOffset(0x3AC)]
        public float field_3AC;
        [FieldOffset(0x3B0)]
        public float field_3B0;
        [FieldOffset(0x3B4)]
        public fixed byte gap3B4[8];
        [FieldOffset(0x3BC)]
        public float field_3BC;
        [FieldOffset(0x3C0)]
        public fixed byte gap3C0[4];
        [FieldOffset(0x3C4)]
        public float* field_3C4;
        [FieldOffset(0x3C8)]
        public byte field_3C8;
        [FieldOffset(0x3CC)]
        public void* clump_3CC;
        [FieldOffset(0x3D0)]
        public void* field_3D0;
        [FieldOffset(0x3D4)]
        public void* field_3D4;
        [FieldOffset(0x3D8)]
        public void* field_3D8;
        [FieldOffset(0x3DC)]
        public fixed byte gap3DC[40];
        [FieldOffset(0x404)]
        public PL_NODE_PARAMETER field_404;
        [FieldOffset(0x460)]
        public fixed byte gap460[4];
        [FieldOffset(0x464)]
        public byte field_464;
        [FieldOffset(0x468)]
        public PL_NODE_PARAMETER field_468;
        [FieldOffset(0x4C4)]
        public fixed byte gap4C4[8];
        [FieldOffset(0x4CC)]
        public PL_NODE_PARAMETER field_4CC;
        [FieldOffset(0x530)]
        public PL_NODE_PARAMETER field_530;
        [FieldOffset(0x58C)]
        public fixed byte gap58C[8];
        [FieldOffset(0x594)]
        public PL_NODE_PARAMETER field_594;
        [FieldOffset(0x5F0)]
        public fixed byte gap5F0[108];
        [FieldOffset(0x65C)]
        public PL_NODE_PARAMETER field_65C;
        [FieldOffset(0x6B8)]
        public fixed byte gap6B8[4];
        [FieldOffset(0x6BC)]
        public fixed byte gap6BC[60];
        [FieldOffset(0x91C)]
        public void* pTexture;
        [FieldOffset(0x920)]
        public void* textureRelated;
        [FieldOffset(0x924)]
        public int muteCount;
        [FieldOffset(0x928)]
        public fixed byte EffShadow[0x40];
        [FieldOffset(0x968)]
        public fixed byte EffBall_HHC[0x1C];
        [FieldOffset(0x984)]
        public short lightDashStopCount_HHC;
        [FieldOffset(0x986)]
        public short lightDashCountSinceLastRing_HHC;
        [FieldOffset(0x988)]
        public fixed byte gap988[2];
        [FieldOffset(0x98A)]
        public short lightDashRingCount_HHC;
        [FieldOffset(0x98C)]
        public Vector3 lightDashLastRingPos_HHC;
        [FieldOffset(0x998)]
        public fixed byte gap998[12];
        [FieldOffset(0x9A4)]
        public float field_9A4;
        [FieldOffset(0x9A8)]
        public int field_9A8;
        [FieldOffset(0x9AC)]
        public int field_9AC;
        [FieldOffset(0x9B0)]
        public fixed byte pEffWink[0x24];
        [FieldOffset(0x9D8)]
        public int field_9D8;
        [FieldOffset(0x9DC)]
        public int field_9DC;
        [FieldOffset(0x9E0)]
        public int field_9E0;
        [FieldOffset(0x9E4)]
        public int field_9E4;
        [FieldOffset(0x9E8)]
        public int field_9E8;
        [FieldOffset(0x9EC)]
        public void* pClumpSuperAura_HHC;
        [FieldOffset(0x9F0)]
        public void* pSuperSonicAura;
        [FieldOffset(0x9F4)]
        public Vector3 field_9F4;
        [FieldOffset(0xA00)]
        public void* pSuperSonicSparkles;
        [FieldOffset(0xA04)]
        public fixed byte gapA04[56];
        [FieldOffset(0xA3C)]
        public byte field_0;

    }
}
