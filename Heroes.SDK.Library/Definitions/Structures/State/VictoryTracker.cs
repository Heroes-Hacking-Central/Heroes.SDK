namespace Heroes.SDK.Definitions.Structures.State
{
    /// <summary>
    /// Structure that tracks the individual victories for each of the four players.
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct VictoryTracker
    {
        public byte PlayerOne;
        public byte PlayerTwo;
        public byte PlayerThree;
        public byte PlayerFour;
    }
}
