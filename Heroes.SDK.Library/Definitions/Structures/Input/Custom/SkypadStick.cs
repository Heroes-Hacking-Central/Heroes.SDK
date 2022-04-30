namespace Heroes.SDK.Definitions.Structures.Input.Custom
{
    /// <summary>
    /// Defines an individual analog stick.
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct SkypadStick
    {
        /// <summary>
        /// Direction of the analog stick.
        /// 0 - 65535
        /// </summary>
        public int Direction;

        /// <summary>
        /// Force in the direction of the analog stick.
        /// 0 - 1F
        /// </summary>
        public float Force;
    }
}