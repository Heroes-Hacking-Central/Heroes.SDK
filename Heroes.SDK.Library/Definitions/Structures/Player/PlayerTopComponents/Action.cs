﻿namespace Heroes.SDK.Definitions.Structures.Player.PlayerTopComponents
{
    public enum Action : short
    {
        Standing = 0x0,
        RocketAccelCharge = 0x1,
        Jumping = 0x2,
        Fall = 0x4,
        Tripping = 0x5,
        SpringLaunched = 0x6,
        PoleLaunched = 0x7,
        PushingSwitch = 0x9,
        Hurt = 0xA,
        Running = 0xE,
        JumpDash = 0xF,
        RidingPinballRail = 0x12,
        MovingTowardsPowerCharacter = 0x13,
        SpinningOnPowerCharacter = 0x14,
        AiTooFar = 0x1A,
        AiMaybeReturning = 0x1B,
        CanonFired = 0x1C,
        Grinding = 0x1D,
        RainbowRingTrick = 0x1E,
        Grabbing = 0x1F,
        ObjectControlSpinning = 0x21,
        StandingWithSwitch = 0x22,
        GrabbingOntoSwitch = 0x23,
        SwitchReleaseMaybe = 0x24,
        PullingSwitch = 0x25,
        Captured = 0x26,
        Vanished = 0x27,
        PinballMode = 0x28,
        SpeedFlyGliding = 0x29,
        Event = 0x2B,
        Dead = 0x2C,
        Fly = 0x34,
        RocketAccelRelease = 0x36,
        PowerAttack1 = 0x38,
        PowerAttack2 = 0x39,
        ThunderShootSpinning = 0x3B,
        PinballRelated = 0x3D,
        AirPowerAttackSpinMode = 0x3E,
        AirPowerAttackInPosition = 0x3F,
        PinballRelatedApparently = 0x3F,
        AirPowerAttackShot = 0x40,
        Tornado = 0x42,
        PowerGliding = 0x43,
        WallStand = 0x44,
        WallJump = 0x45,
        TailsRingThrow = 0x4B,
        HammerSwing = 0x4C,
        HammerFloat = 0x4D,
        LightSpeedDash = 0x53,
        Kick = 0x54,
    }
}