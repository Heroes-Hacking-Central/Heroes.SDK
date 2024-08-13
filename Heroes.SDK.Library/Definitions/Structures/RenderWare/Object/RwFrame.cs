using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Heroes.SDK.Definitions.Structures.RenderWare;
using Heroes.SDK.Definitions.Structures.RenderWare.Camera;

namespace Heroes.SDK.Definitions.Structures.RenderWare.Object
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RwFrame
    {   
        public RwObject obj;
        public RwLLLink inDirtyListLink;
        public RwMatrixTag modelling;
        public RwMatrixTag ltm;
        public RwLinkList objectList;
        public RwFrame *child;
        public RwFrame *next;
        public RwFrame *root;
};

}
