namespace Heroes.SDK.Definitions.Enums
{
    public enum Team : int
    {
        Null = -1,
        Sonic,
        Dark,
        Rose,
        Chaotix,

        /// <summary>
        /// Unused Team. Consists of Espio, Charmy and Big.
        /// Likely a remnant of initial Hard Mode implementation.
        /// </summary>
        ForEDIT
    }

   public enum ENUM_TEAM_KIND
    {
        TEAM_SONIC = 0,
        TEAM_DARK = 1,
        TEAM_ROSES = 2,
        TEAM_CHAOTIX = 3,
        NUM_TEAM_KINDS = 4,
    };

    public enum ENUM_FORMATION
    {
        FORMATION_SPEED = 0,
        FORMATION_POWER = 1,
        FORMATION_FLY = 2,
        FORMATION_FLY_FLYING = 3,
        FORMATION_ROCKET_ACCEL = 4,
        FORMATION_TRIANGLE_DIVE = 5,
        FORMATION_LINE_DIVE = 6,
        FORMATION_SPEED_HANG = 7,
        FORMATION_POWER_HANG = 8,
        FORMATION_FLY_HANG = 9,
        FORMATION_SPEED_PINBALL = 10,
        FORMATION_POWER_PINBALL = 11,
        FORMATION_FLY_PINBALL = 12,
        NUM_FORMATIONS = 13,
    };

   public enum ENUM_TEAMPLAY_MODE
    {
        TEAM_MODE_IDLE = 0,
        TEAM_MODE_STAGE_START = 1,
        TEAM_MODE_STAGE_CLEAR = 2,
        TEAM_MODE_STAGE_GAMEOVER = 3,
        TEAM_MODE_FORMATION = 4,
        TEAM_MODE_FORMATION_START = 5,
        TEAM_MODE_FORMATION_LEADER_CHANGE = 6,
        TEAM_MODE_FORMATION_LEADER_CHANGE_R = 7,
        TEAM_MODE_FORMATION_RESET = 8,
        TEAM_MODE_SUPER_FORMATION_ATTACK = 9,
        TEAM_MODE_EVENT = 10,
        TEAM_MODE_SPEED_ROCKET_READY = 11,
        TEAM_MODE_SPEED_ROCKET_ACCEL1 = 12,
        TEAM_MODE_SPEED_ROCKET_ACCEL2 = 13,
        TEAM_MODE_FLY = 14,
        TEAM_MODE_BUSTER = 15,
        TEAM_MODE_TRIANGLE_DIVE = 16,
        TEAM_MODE_PLACEON = 17,
        TEAM_MODE_HANG = 18,
        TEAM_MODE_PINBALL = 19,
        TEAM_MODE_FORMATION_CHANGE_TO_SPEED = 20,
        TEAM_MODE_FORMATION_CHANGE_TO_FLY = 21,
        TEAM_MODE_FORMATION_CHANGE_TO_POWER = 22,
        TEAM_MODE_BOBSLEIGH = 23,
        NUM_TEAMPLAY_MODE = 24,
        TEAM_MODE_NO_RESERVATION = -1,
    };

    public enum ENUM_TEAM_OP
    {
        TEAM_OP_PLACEON = 0,
        TEAM_OP_LETITGO = 1,
        NUM_TEAM_OP = 2,
    };

    public enum ENUM_TEAM_ROLE
    {
        TEAM_ROLE_LEADER = 0,
        TEAM_ROLE_NPC_0 = 1,
        TEAM_ROLE_NPC_1 = 2,
        TEAM_ROLE_NPC_2 = 3,
    };
}
