using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Object
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RwLLLink
    {
        public RwLLLink* next;
        public RwLLLink* prev;
    }
}
