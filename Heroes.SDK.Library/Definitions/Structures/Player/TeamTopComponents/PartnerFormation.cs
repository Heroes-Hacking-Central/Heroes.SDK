namespace Heroes.SDK.Definitions.Structures.Player.TeamTopComponents
{
    public enum PartnerFormation : int
    {
        /// <summary>
        /// Normal formation of partners when Sonic is standing.
        /// </summary>
        Speed,

        /// <summary>
        /// Normal formation of partners when Knuckles is standing.
        /// </summary>
        Power,

        /// <summary>
        /// Normal formation of partners when Tails is standing.
        /// </summary>
        Fly,

        /// <summary>
        /// Formation when Tails is flying.
        /// </summary>
        FlyFlying,

        /// <summary>
        /// Formation when Knuckles is gliding.
        /// </summary>
        PowerGlide,

        /// <summary>
        /// Power glide but all partners stay in same position.
        /// </summary>
        PowerGlideAlternate,

        /// <summary>
        /// Falling (out of flight) in fly formation.
        /// </summary>
        FlightFalling,

        FlightUnknown,
        FlightUnknown2,
        FlightUnknown3,

    }
}