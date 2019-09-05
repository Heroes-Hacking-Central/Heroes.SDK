namespace Heroes.SDK.Game.Enums
{
    public enum MissionType
    {
        Normal = 0,

        /// <summary>
        /// Cannot be detected by enemies.
        /// </summary>
        NoDetect = 1,

        /// <summary>
        /// Cannot be detected by frogs.
        /// </summary>
        NoFrogDetect = 2,

        /// <summary>
        /// Limited time.
        /// </summary>
        Time = 3,

        /// <summary>
        /// <see cref="Time"/> and <see cref="NoDetect"/>.
        /// </summary>
        TimeNoDetect = 4,

        /// <summary>
        /// <see cref="Time"/> and <see cref="NoFrogDetect"/>.
        /// </summary>
        TimeNoFrogDetect = 5,
    }
}