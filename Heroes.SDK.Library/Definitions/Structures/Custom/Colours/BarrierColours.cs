using Heroes.SDK.Definitions.Structures.Custom.Colours.Formats;

namespace Heroes.SDK.Definitions.Structures.Custom.Colours
{
    public unsafe class BarrierColours
    {
        /// <summary>
        /// The colour of the power formation barrier.
        /// </summary>
        public RgbaColorComponentPtrSet Power { get; } = new RgbaColorComponentPtrSet((byte*)0x47244D, (byte*)0x472452, (byte*)0x472457, (byte*)0x472443);

        /// <summary>
        /// The colour of the speed formation barrier.
        /// </summary>
        public RgbaColorComponentPtrSet SpeedBarrier { get; } = new RgbaColorComponentPtrSet((byte*)0x47245E, (byte*)0x472463, (byte*)0x472468, (byte*)0x472443);

        /// <summary>
        /// The colour of the fly formation barrier.
        /// </summary>
        public RgbaColorComponentPtrSet FlyBarrier { get; } = new RgbaColorComponentPtrSet((byte*)0x47246F, (byte*)0x472474, (byte*)0x472479, (byte*)0x472443);
    }
}
