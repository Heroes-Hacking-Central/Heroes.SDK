using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Criware.FileSystem
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NewFileInfoTuple
    {
        public char* FileName;
        public int NFileSizeLow;
        public int NFileSizeHigh;
    }
}