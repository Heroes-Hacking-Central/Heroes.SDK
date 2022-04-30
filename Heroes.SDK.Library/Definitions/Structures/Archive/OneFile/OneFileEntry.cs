using Heroes.SDK.Definitions.Structures.Archive.OneFile.Custom;
using Heroes.SDK.Definitions.Structures.RenderWare;
using System;
using System.Runtime.CompilerServices;
using static Heroes.SDK.SDK;

namespace Heroes.SDK.Definitions.Structures.Archive.OneFile
{
    [Equals(DoNotAddEqualityOperators = true)]
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
        /// Creates a ONE file entry given an index, size and version/
        /// </summary>
        /// <param name="fileNameIndex">Index in the name section.</param>
        /// <param name="fileSize">Size of the file.</param>
        /// <param name="rwVersion">Version of the file.</param>
        public OneFileEntry(int fileNameIndex, int fileSize, RwVersion rwVersion)
        {
            FileNameIndex = fileNameIndex;
            FileSize = fileSize;
            RwVersion = rwVersion;
        }

        /// <summary>
        /// Returns the pointer to the compressed data.
        /// </summary>
        public byte* GetCompressedDataPtr()
        {
            // Note: Unsafe.AsPointer(ref FileNameIndex) is a fancy way to say &this.
            // For this to reliably work, this structure should be pinned.
            // If accessed from the ONE parser, this will be pinned.
            var dataPtr = ((byte*)Unsafe.AsPointer(ref FileNameIndex)) + sizeof(OneFileEntry);
            return dataPtr;
        }

        /// <summary>
        /// Returns the compressed data as a fixed array of bytes.
        /// </summary>
        public byte[] GetCompressedData()
        {
            var span = new Span<byte>(GetCompressedDataPtr(), FileSize);
            return span.ToArray();
        }

        /// <summary>
        /// Decompresses the data to a fixed array of bytes.
        /// </summary>
        public byte[] DecompressData()
        {
            return Prs.Decompress(GetCompressedDataPtr(), FileSize);
        }

        /// <summary>
        /// Makes a "dry" run of the PRS decompressor without copying/actual decompressor.
        /// Gets the size of the decompressed file.
        /// </summary>
        public int GetDecompressedDataSize()
        {
            return Prs.Estimate(GetCompressedDataPtr(), FileSize);
        }

        /// <summary>
        /// Returns the name of the file.
        /// </summary>
        /// <param name="fileNameSection">The address of the first entry of the file name section.</param>
        public string GetFileName(OneFileName* fileNameSection)
        {
            return fileNameSection[FileNameIndex].ToString();
        }

        /// <summary>
        /// Converts the <see cref="OneFileEntry"/> to a fully fledged managed class.
        /// </summary>
        /// <param name="fileNameSection">The address of the first entry of the file name section.</param>
        public ManagedOneFile ToManaged(OneFileName* fileNameSection)
        {
            return new ManagedOneFile(GetFileName(fileNameSection), GetCompressedData(), true, RwVersion);
        }
    }
}
