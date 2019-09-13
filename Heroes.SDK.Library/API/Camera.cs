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
        public static ref int NumberOfCameras => ref RefPointer<int>.Create((int*)0x009DD6BC);

        /// <summary>
        /// Contains the individual cameras for each of the four players.
        /// </summary>
        public static RefFixedArrayPtr<HeroesCamera> Cameras => new RefFixedArrayPtr<HeroesCamera>(0x00A60C30, NumberOfCameras);

        /// <summary>
        /// If set to false, you can take manual control of the <see cref="Cameras"/>.
        /// If set to true, camera will be controlled by the game.
        /// </summary>
        public static ref bool IsCameraEnabled => ref RefPointer<bool>.Create((bool*)0x00A69880);
    }
}
