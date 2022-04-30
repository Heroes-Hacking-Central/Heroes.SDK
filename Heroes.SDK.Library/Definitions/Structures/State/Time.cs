using System;

namespace Heroes.SDK.Definitions.Structures.State
{
    /// <summary>
    /// This struct contains the in-game timer.
    /// The timer you see when playing a level.
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public struct Time
    {
        private const float Framerate = 60F;
        private const float SecondInMilliseconds = 1000F;

        public byte Frames;
        public byte Seconds;
        public byte Minutes;

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> based on the current instance.
        /// </summary>
        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(0, 0, Minutes, Seconds, (int)FramesAsMilliseconds());
        }

        /// <summary>
        /// Sets the current time to a given <see cref="TimeSpan"/>.
        /// </summary>
        public void FromTimeSpan(TimeSpan timeSpan)
        {
            Minutes = (byte)timeSpan.Minutes;
            Seconds = (byte)timeSpan.Seconds;
            Frames = (byte)MillisecondsAsFrames(timeSpan.Milliseconds);
        }

        private float FramesAsMilliseconds() => ((Frames / Framerate) * SecondInMilliseconds);
        private float MillisecondsAsFrames(float milliseconds) => ((milliseconds / SecondInMilliseconds) * Framerate);
    }
}
