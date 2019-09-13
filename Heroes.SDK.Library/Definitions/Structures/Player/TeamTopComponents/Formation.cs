namespace Heroes.SDK.Definitions.Structures.Player.TeamTopComponents
{
    public enum Formation
    {
        /// <summary>
        /// Team is in an undefined formation.
        /// Note: Allows to change <see cref="PartnerFormation"/> without force switch characters.
        /// </summary>
        Null,

        /// <summary>
        /// Team is in speed formation.
        /// </summary>
        Speed,

        /// <summary>
        /// Team is in power formation.
        /// </summary>
        Power,

        /// <summary>
        /// Team is in flight formation.
        /// </summary>
        Fly
    }
}