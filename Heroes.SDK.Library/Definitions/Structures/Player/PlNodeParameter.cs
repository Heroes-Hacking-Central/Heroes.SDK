using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.RenderWare;
using Heroes.SDK.Definitions.Structures.RenderWare.Camera;
using Heroes.SDK.Definitions.Structures.RenderWare.Object;

namespace Heroes.SDK.Definitions.Structures.Player
{

    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PL_NODE_PARAMETER
    {
        public int field_0;
        public RwFrame* rootFrame;
        public byte field_8;
        public fixed byte gap9[7];
        public RwMatrixTag matrix;
        public RwV3d pos;
    };
}
