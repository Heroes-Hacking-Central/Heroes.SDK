using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.RenderWare.Arbitrary;

namespace Heroes.SDK.Definitions.Structures.RenderWare
{
    // TODO: Snoop around RW SDK and find real names here.
    // Also add everything else.

    /// <summary>
    /// Disassembly name: Utilfns_t
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    [StructLayout(LayoutKind.Sequential, Size = 0x158)]
    public unsafe struct RwEngineInstance
    {
        public RwGraphicsInstance* Graphics;
    }
}