using System;
using System.Drawing;
using Reloaded.Memory;
using Reloaded.Memory.Enums;
using Reloaded.Memory.Interfaces;
using Reloaded.Memory.Native.Windows;

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
            Memory.Instance.ChangeProtection((nuint)Color, sizeof(RgbaColor), MemoryProtection.ReadWriteExecute);
        }

        public void SetColor(RgbaColor color) => *Color = color;
        public Color GetColor() => *Color;
    }
}
