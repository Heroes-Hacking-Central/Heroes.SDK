namespace Heroes.SDK.Definitions.Structures.Stage.Rank
{
    public struct RankReqTime
    {
        /// <summary>
        /// Minutes of time required for the rank.
        /// </summary>
        public byte Min { get; set; }

        /// <summary>
        /// Seconds of time required for the rank.
        /// </summary>
        public byte Sec { get; set; }

        /// <summary>
        /// Sets the minutes and seconds required for the rank.
        /// </summary>
        /// <param name="minutes">Minutes required for rank</param>
        /// <param name="seconds">Seconds requiredfor rank</param>
        public void setTime(byte minutes, byte seconds)
        {
            Min = minutes;
            Sec = seconds;
        }
    }
}