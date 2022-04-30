using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Object
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RwLLLink
    {
        public RwLLLink* next;
        public RwLLLink* prev;
    }
}
