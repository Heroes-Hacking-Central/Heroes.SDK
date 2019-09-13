namespace Heroes.SDK.Definitions.Structures.Stage.Splines
{
    /// <summary>
    /// Represents an address (pointer) to a function used to handle the current spline.
    /// </summary>
    public enum SplineType : int
    {
        Loop = 0x433970,
        Rail = 0x4343F0,
        Ball = 0x434480
    }
}