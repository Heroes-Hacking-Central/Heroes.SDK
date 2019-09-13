namespace Heroes.SDK.Definitions.Structures.World.Camera
{
    public enum Transform
    {
        /// <summary>
        /// Moves or rotates the camera relative with respect to the current rotation of the camera.
        /// i.e. If the camera is pointing up and you move forward, the camera moves upward.
        /// </summary>
        Relative,

        /// <summary>
        /// Moves or rotates the camera ignoring the current rotation of the camera.
        /// i.e. If the camera is pointing up and you move forward, the camera moves forward.
        /// </summary>
        Absolute
    }
}