using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Criware.FileSystem
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NewFileInfoTuple
    {
        public char* FileName;
        public int NFileSizeLow;
        public int NFileSizeHigh;
    }
}