namespace Heroes.SDK.Definitions.Structures.Player.TeamTopComponents
{
    public enum FormationSwitchBehaviour : short
    {
        /// <summary>
        /// Wraps to the position of the fly character. (Assuming speed formation)
        /// </summary>
        WarpToFly,

        /// <summary>
        /// Wraps to the position of the power character. (Assuming speed formation)
        /// </summary>
        WarpToPower,

        /// <summary>
        /// Wraps to the position of the speed character. (Assuming speed formation)
        /// </summary>
        WarpToSelf
    }
}