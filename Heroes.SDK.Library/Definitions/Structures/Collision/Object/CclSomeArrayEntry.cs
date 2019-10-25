using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Heroes.SDK.Definitions.Structures.Collision.Object
{
    [Equals(DoNotAddEqualityOperators =true)]
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct CclSomeArrayEntry
    {
        public byte unknown1;
        public byte unknown2;
        public ushort unknown3;
        public int unknown4;
    }
}
