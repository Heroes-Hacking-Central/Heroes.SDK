using System;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Criware.FileSystem
{
    [Equals(DoNotAddEqualityOperators =true)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct FileEntry
    {
        /// <summary>
        /// Handle of the file, obtained from a call to CreateFile.
        /// </summary>
        public IntPtr FileHandle;

        /// <summary>
        /// Size of the file, obtained from a call to GetFileSize with <see cref="FileHandle"/>.
        /// </summary>
        public uint FileSize;

        public int Gap8;

        /// <summary>
        /// Address of the next file entry.
        /// </summary>
        public FileEntry* NextEntry;

        /// <summary>
        /// Full path to the file.
        /// </summary>
        public char* FileName;
    }
}