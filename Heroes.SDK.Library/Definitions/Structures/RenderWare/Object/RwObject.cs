using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Object
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RwObject
    {
        public byte type;
        public byte subType;
        public byte flags;
        public byte privateFlags;
        public void* parent;
    }
}
