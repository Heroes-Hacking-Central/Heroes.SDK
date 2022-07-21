using Reloaded.Memory.Kernel32;
using Reloaded.Memory.Sources;
using System;
using System.Drawing;

namespace Heroes.SDK.Definitions.Structures.Custom.Colours.Formats
{
    /// <summary>
    /// Represents a colour formed using the R,G,B,A components.
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public unsafe struct RgbaColorPtr : IRgbaColor
    {
        /// <summary>
        /// Range 0 - 255.
        /// </summary>
        public RgbaColor* Color;

        /// <summary>
        /// Creates an RGBA colour.
        /// </summary>
        public RgbaColorPtr(RgbaColor* color)
        {
            Color = color;
            ChangePermissions();
        }

        /// <summary>
        /// Creates an RGBA colour.
        /// </summary>
        public RgbaColorPtr(long colorPtr)
        {
            Color = (RgbaColor*)colorPtr;
            ChangePermissions();
        }

        private void ChangePermissions()
        {
            // Ideally this shouldn't be in constructor but I feel like end users wouldn't call an explicit method if
            // I made one.
            Memory.Instance.ChangePermission((nuint)Color, sizeof(RgbaColor), Kernel32.MEM_PROTECTION.PAGE_EXECUTE_READWRITE);
        }

        public void SetColor(RgbaColor color) => *Color = color;
        public Color GetColor() => *Color;
    }
}
