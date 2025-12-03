namespace Heroes.SDK.Definitions.Enums
{
    /// <summary>
    /// List of Sonic Heroes characters as stored in arrays in internal game code.
    /// </summary>
    public enum Character : byte
    {
        Sonic,
        Knuckles,
        Tails,
        Shadow,
        Omega,
        Rouge,
        Amy,
        Big,
        Cream,
        Espio,
        Vector,
        Charmy
    }

    public enum ENUM_CHAR_MODE : int
    {
        CHAR_MODE_UNDER_CONTROL = 0,
        CHAR_MODE_FORM_MOVE = 1,
        CHAR_MODE_FORM_FIX = 2,
        CHAR_MODE_FORM_PURSUIT = 3,
        CHAR_MODE_MOVE_TO_FORM_TARGET = 4,
        CHAR_MODE_MOVE_TO_FORM_PURSUIT_TARGET = 5,
        CHAR_MODE_MOVE_TO_FORM_FIX_TARGET = 6,
        CHAR_MODE_BULLET = 7,
        CHAR_MODE_BULLET_ON_HAND = 8,
        CHAR_MODE_BULLET_TO_HAND = 9,
        CHAR_MODE_BULLET_ON_SHOULDER = 10,
        CHAR_MODE_BULLET_TO_SHOULDER = 11,
        CHAR_MODE_BULLET_IN_MOUTH = 12,
        CHAR_MODE_BULLET_TO_MOUTH = 13,
        CHAR_MODE_SHOOT = 14,
        CHAR_MODE_JUMP_TO_TARGET = 15,
        CHAR_MODE_EVENT = 16,
        CHAR_MODE_WAIT = 17,
        CHAR_MODE_CAPTURED = 18,
        NUM_CHAR_MODE = 19,
        CHAR_MODE_NO_RESERVATION = -1,
    };
}