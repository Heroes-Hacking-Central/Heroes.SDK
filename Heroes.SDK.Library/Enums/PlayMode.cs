namespace Heroes.SDK.Game.Enums
{
    public enum PlayMode : byte
    {
        /// <summary>
        /// Regular mode.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Quick race from 2P mode.
        /// </summary>
        QuickRace = 1,

        /// <summary>
        /// Collect 200 rings.
        /// </summary>
        RingCount = 3,

        /// <summary>
        /// Kill all enemies.
        /// </summary>
        AllEnemyCount = 4,

        /// <summary>
        /// Kill 100 enemies.
        /// </summary>
        EnemyCount = 5,

        /// <summary>
        /// Single screen battle mode. Used in 2P.
        /// </summary>
        BattleMode = 6,

        /// <summary>
        /// Collect X of item.
        /// </summary>
        Collectables = 8
    }
}