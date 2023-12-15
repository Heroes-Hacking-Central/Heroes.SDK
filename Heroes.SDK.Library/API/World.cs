using Heroes.SDK.Classes.NativeClasses;
using Heroes.SDK.Classes.PseudoNativeClasses;
using Heroes.SDK.Custom;
using Heroes.SDK.Definitions.Structures.State;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Controls anything in the active game world (in-level) that isn't the player.
    /// Spawning items, enemies, controlling loaded world etc.
    /// For level editing APIs, see <see cref="Stage"/>.
    /// </summary>
    public static unsafe class World
    {
        /// <summary>
        /// Contains the elapsed time for the current stage.
        /// </summary>
        public static ref Time Time => ref new Ptr<Time>((Time*)0x009DD708).AsRef();

        /// <summary>
        /// Points to the main collision file loaded, e.g. s03.cl
        /// </summary>
        public static Octree** CollisionFile => TObjLand.CollisionFile;

        /// <summary>
        /// Points to the water collision file loaded, e.g. s03_wt.cl
        /// Water collision leaves splashes as the characters run on it.
        /// </summary>
        public static Octree** WaterCollisionFile => TObjLand.WaterCollisionFile;

        /// <summary>
        /// Points to the death collision file loaded, e.g. s03_xx.cl
        /// Death collision kills a character that touches it.
        /// </summary>
        public static Octree** DeathCollisionFile => TObjLand.DeathCollisionFile;

        /// <summary>
        /// Unloads any existing collision and loads a new collision flle.
        /// Warning: Calling this asynchronously (outside of main thread) is dangerous.
        /// If calling asynchronously, recommend using <see cref="Queue"/> to call this function.
        /// </summary>
        /// <param name="stageName">Name of the collision file without extension in the `collisions` folder.</param>
        public static void LoadCollision(string stageName)
        {
            if (*CollisionFile != null)
            {
                (*CollisionFile)->Destructor();
                CStandardLibrary.Free(*CollisionFile);
            }

            if (*WaterCollisionFile != null)
            {
                (*WaterCollisionFile)->Destructor();
                CStandardLibrary.Free(*WaterCollisionFile);
            }

            if (*DeathCollisionFile != null)
            {
                (*DeathCollisionFile)->Destructor();
                CStandardLibrary.Free(*DeathCollisionFile);
            }
            
            TObjLand.Fun_InitCollision.GetWrapper()(stageName);
        }

        /// <summary>
        /// Unloads any existing collision and loads a new collision flle.
        /// Warning: Calling this asynchronously (outside of main thread) is dangerous.
        /// If calling asynchronously, recommend using <see cref="Queue"/> to call this function.
        /// </summary>
        /// <param name="stage">Stage to load the collision for.</param>
        public static void LoadCollision(Definitions.Enums.Stage stage)
        {
            LoadCollision(FileNameAttribute.GetFileName(stage));
        }
    }
}
