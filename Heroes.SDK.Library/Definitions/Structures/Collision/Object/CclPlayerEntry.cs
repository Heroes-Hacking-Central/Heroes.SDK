using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Collision.Object
{
    /// <summary>
    /// Note: This is not one big struct but a series of smaller structs accessed via both pointer to this and structs inside.
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential, Size = 0x88)]
    public unsafe struct CclPlayerEntry
    {
        public int field_0;
        public int field_4;
        public int field_8;
        public int velocityXPlus10;
        public int field_10;

        public CclSomeArrayEntry SomeArrayEntry1;
        public CclSomeArrayEntry SomeArrayEntry2;
        public CclSomeArrayEntry SomeArrayEntry3;
        public CclSomeArrayEntry SomeArrayEntry4;
        public CclSomeArrayEntry SomeArrayEntry5;
        public CclSomeArrayEntry SomeArrayEntry6;
        public CclSomeArrayEntry SomeArrayEntry7;
        public CclSomeArrayEntry SomeArrayEntry8;

        public int field_58;
        public float PositionXCopy;
        public float PositionYCopy;
        public float PositionZCopy;
        public int field_68;

        public int field_6C;
        public int RotationXCopy;
        public int RotationYCopy;

        /// <summary>
        /// Index of the character in the playerTOp array.
        /// </summary>
        public int PlayerTopIndex;

        public float PositionXCopyAnother;
        public float PositionYCopyAnother;
        public float PositionZCopyAnother;
    }
}
