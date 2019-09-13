using System.Drawing;

namespace Heroes.SDK.Definitions.Structures.Custom.Colours.Formats
{
    public interface IRgbaColor
    {

        /// <summary>
        /// Assigns a new color.
        /// </summary>
        unsafe void SetColor(RgbaColor color);

        /// <summary>
        /// Retrieves the colour.
        /// </summary>
        Color GetColor();
    }
}