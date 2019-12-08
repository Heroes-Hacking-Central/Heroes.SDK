using System.Runtime.InteropServices;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory.Pointers;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute;

namespace Heroes.SDK.Classes.NativeClasses
{
    public unsafe struct TObjLand
    {
        private const int LandManager = 0x00A792D0; // Default address of LandManager Object

        /* Variables */

        /// <summary>
        /// Points to the main collision file loaded, e.g. s03.cl
        /// </summary>
        public static RefPointer<Octree> CollisionFile      { get; } = new RefPointer<Octree>((Octree*) 0x00A77684, 2);

        /// <summary>
        /// Points to the water collision file loaded, e.g. s03_wt.cl
        /// Water collision leaves splashes as the characters run on it.
        /// </summary>
        public static RefPointer<Octree> WaterCollisionFile { get; } = new RefPointer<Octree>((Octree*) 0x00A77688, 2);

        /// <summary>
        /// Points to the death collision file loaded, e.g. s03_xx.cl
        /// Death collision kills a character that touches it.
        /// </summary>
        public static RefPointer<Octree> DeathCollisionFile { get; } = new RefPointer<Octree>((Octree*) 0x00A7768C, 2);

        /* Function Declarations */
        public static IFunction<Native_InitCollision> Fun_InitCollision { get; } = SDK.ReloadedHooks.CreateFunction<Native_InitCollision>(0x00425500);

        /* Functions */

        /// <summary>
        /// Loads a given set of collision files (Regular, Water [wt] and Death Plane [xx] ).
        /// </summary>
        /// <param name="landManagerPtr">Address of a pointer to the land manager object.</param>
        /// <param name="fileNameWithoutExtension">Name of the file in the collisions folder minus the name of the extension.</param>
        public int InitCollision(string fileNameWithoutExtension, int landManagerPtr = LandManager)
        {
            return Fun_InitCollision.GetWrapper()(fileNameWithoutExtension, landManagerPtr);
        }

        /* Function Definitions */

        /// <summary>
        /// Loads a given set of collision files (Regular, Water [wt] and Death Plane [xx] ).
        /// </summary>
        /// <param name="landManagerPtr">Address of a pointer to the land manager object.</param>
        /// <param name="fileNameWithoutExtension">Name of the file in the collisions folder minus the name of the extension.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.esi, Register.edi}, Register.eax, StackCleanup.None)]
        public delegate int Native_InitCollision(string fileNameWithoutExtension, int landManagerPtr = LandManager);
    }
}
