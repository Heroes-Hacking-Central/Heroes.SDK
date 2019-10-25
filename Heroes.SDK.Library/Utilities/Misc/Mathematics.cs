namespace Heroes.SDK.Utilities.Misc
{
    public static class Mathematics
    {
        /// <summary>
        /// Checks whether a number lies between a certain range of numbers (inclusive).
        /// </summary>
        /// <param name="value">The number to compare.</param>
        /// <param name="minimum">The minimum value to check.</param>
        /// <param name="maximum">The maximum value to check.</param>
        /// <returns>The number</returns>
        public static bool IsBetween(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }
    }
}
