using System;
using System.Runtime.CompilerServices;
using Heroes.SDK.RenderWare;

namespace Heroes.SDK.Game.Structures.OneFile
{
    public unsafe struct OneFileEntry
    {
        /// <summary>
        /// Contains an index into the array of individual file names for files.
        /// </summary>
        public int FileNameIndex;

        /// <summary>
        /// Contains the size of the file.
        /// </summary>
        public int FileSize;

        /// <summary>
        /// Stores the RenderWare version of the individual file inside the ONE.
        /// </summary>
        public RwVersion RwVersion;

        /// <summary>
        /// Returns the pointer to the compressed data.
        /// </summary>
        public byte* GetCompressedDataPtr()
        {
            var dataPtr = ((byte*)Unsafe.AsPointer(ref FileNameIndex)) + sizeof(OneFileEntry);
            return dataPtr;
        }

        /// <summary>
        /// Returns the compressed data as a fixed array of bytes.
        /// </summary>
        /// <returns></returns>
        public byte[] GetCompressedData()
        {
            var span    = new Span<byte>(GetCompressedDataPtr(), FileSize);
            return span.ToArray();
        }
    }
}
