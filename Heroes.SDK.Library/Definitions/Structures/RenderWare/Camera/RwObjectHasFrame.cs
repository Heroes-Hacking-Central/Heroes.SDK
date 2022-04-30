using Heroes.SDK.Definitions.Structures.RenderWare.Object;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Camera
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RwObjectHasFrame
    {
        public RwObject RwObject;
        public RwLLLink LFrame;
        public void* Sync;
    }
}
