using System;

namespace Heroes.SDK.Definitions.Structures.Input
{
    [Flags]
    public enum ButtonFlags
    {
        Jump = 0x00000001,
        FormationR = 0x00000002,
        Action = 0x00000004,
        FormationL = 0x00000008,

        DpadUp = 0x00000010,
        DpadDown = 0x00000020,
        DpadLeft = 0x00000040,
        DpadRight = 0x00000080,

        CameraR = 0x00000100,
        CameraL = 0x00000200,
        Start = 0x00004000,

        TeamBlast = 0x00030000
    }
}
