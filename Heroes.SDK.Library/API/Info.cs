using Heroes.SDK.Utilities.Tagger.Enums;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Obtains arbitrary information about the game that may be useful to know.
    /// This class does not allow to change game state.
    /// </summary>
    public static class Info
    {
        /// <summary>
        /// Obtains a string representation of the current stage name.
        /// </summary>
        public static string GetStageName() => State.GetStageName();

        /// <summary>
        /// Returns a set of arbitrary tags that categorize the currently played stage.
        /// </summary>
        public static StageTag GetStageTags() => State.GetStageTags();
    }
}
