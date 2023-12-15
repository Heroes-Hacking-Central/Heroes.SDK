using Heroes.SDK.Definitions.Structures.World.Camera;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Stores everything concerned with cameras and how the game world is drawn.
    /// </summary>
    public static unsafe class Camera
    {
        /// <summary>
        /// Stores the current number of cameras being displayed.
        /// </summary>
        public static ref int NumberOfCameras => ref new Ptr<int>((int*)0x009DD6BC).AsRef();

        /// <summary>
        /// Contains the individual cameras for each of the four players.
        /// </summary>
        public static FixedArrayPtr<HeroesCamera> Cameras => new((HeroesCamera*)0x00A60C30, NumberOfCameras);

        /// <summary>
        /// If set to false, you can take manual control of the <see cref="Cameras"/>.
        /// If set to true, camera will be controlled by the game.
        /// </summary>
        public static ref bool IsCameraEnabled => ref new Ptr<bool>((bool*)0x00A69880).AsRef();
    }
}
