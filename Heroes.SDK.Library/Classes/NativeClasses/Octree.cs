using System.Runtime.InteropServices;
using Heroes.SDK.Classes.PseudoNativeClasses;
using Heroes.SDK.Definitions.Structures.Collision.Stage;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Classes.NativeClasses
{
    /// <summary>
    /// Note: This is actually a quadtree.
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct Octree
    {
        // TODO: In-memory parser of Collision Files, just like there is a parser of ONE files.

        /* Class Members */
        public QuadtreeFileHeader Header;

        /* Function Declarations */
        public static IFunction<Native_Destructor> Fun_Destructor = SDK.ReloadedHooks.CreateFunction<Native_Destructor>(0x0042D1E0);

        /// <summary>
        /// Destructor for the current class.
        /// After destroying the class, you should call <see cref="CStandardLibrary.Free"/> with the address of this struct.
        /// </summary>
        public int Destructor()
        {
            return Fun_Destructor.GetWrapper()(ref this);
        }

        /// <summary>
        /// Unloads a given collision file.
        /// </summary>*
        /// <param name="octreeFilePtr">Address of the Octree file in memory.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(new[] { FunctionAttribute.Register.esi }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.None)]
        public delegate int Native_Destructor(ref Octree octreeFilePtr);
    }
}
