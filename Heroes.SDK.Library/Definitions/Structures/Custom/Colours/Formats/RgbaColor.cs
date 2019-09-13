using System.Drawing;

namespace Heroes.SDK.Definitions.Structures.Custom.Colours.Formats
{
    /// <summary>
    /// Represents a colour formed using the R,G,B,A components.
    /// </summary>
    public struct RgbaColor
    {
        /// <summary>
        /// Range 0 - 255.
        /// </summary>
        public byte R;

        /// <summary>
        /// Range 0 - 255.
        /// </summary>
        public byte G;

        /// <summary>
        /// Range 0 - 255.
        /// </summary>
        public byte B;

        /// <summary>
        /// Range 0 - 255.
        /// </summary>
        public byte A;

        /// <summary>
        /// Creates an RGBA colour.
        /// </summary>
        /// <param name="r">Range 0 - 255.</param>
        /// <param name="g">Range 0 - 255.</param>
        /// <param name="b">Range 0 - 255.</param>
        /// <param name="a">Range 0 - 255.</param>
        public RgbaColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static RgbaColor FromColor(Color color) => new RgbaColor(color.R, color.G, color.B, color.A);
        public static Color ToColor(RgbaColor color)   => Color.FromArgb(color.A, color.R, color.G, color.B);
        public static implicit operator Color(RgbaColor color) => ToColor(color);
        public static implicit operator RgbaColor(Color color) => FromColor(color);
    }
}
