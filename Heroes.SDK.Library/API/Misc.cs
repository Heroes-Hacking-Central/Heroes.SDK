using Heroes.SDK.Definitions.Structures.Custom;
using Heroes.SDK.Definitions.Structures.Custom.Colours;
using Heroes.SDK.Definitions.Structures.Custom.Colours.Enums;
using Heroes.SDK.Definitions.Structures.Custom.Colours.Formats;

namespace Heroes.SDK.API
{
    public static class Misc
    {
        /// <summary>
        /// Contains the colours of the individual formation gate barriers.
        /// </summary>
        public static BarrierColours BarrierColours { get; } = new BarrierColours();

        /// <summary>
        /// Retrieves a structure allowing you to change the ball (jump aura colour) for a specified character.
        /// </summary>
        public static RgbaColorPtr BallColour(BallColourAddress ballColourAddress) => new RgbaColorPtr((long)ballColourAddress);

        /// <summary>
        /// Retrieves a structure allowing you to change the tornado colour for a specified character.
        /// </summary>
        public static RgbaColorPtr TornadoColour(TornadoColourAddress tornadoColourAddress) => new RgbaColorPtr((long)tornadoColourAddress);

        /// <summary>
        /// Retrieves a structure allowing you to change the homing attack trail colour for a specified character.
        /// </summary>
        public static RgbaColorPtr TornadoColour(TrailColourAddress trailColourAddress) => new RgbaColorPtr((long)trailColourAddress);

        /// <summary>
        /// Allows you to control the default settings of the game normally obtained from launcher.
        /// </summary>
        public static DefaultSettings DefaultSettings { get; } = new DefaultSettings();
    }
}
