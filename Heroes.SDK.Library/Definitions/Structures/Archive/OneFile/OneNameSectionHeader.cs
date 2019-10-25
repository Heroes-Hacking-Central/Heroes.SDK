using Heroes.SDK.Definitions.Structures.RenderWare;

namespace Heroes.SDK.Definitions.Structures.Archive.OneFile
{
    [Equals(DoNotAddEqualityOperators =true)]
    public struct OneNameSectionHeader
    {
        /// <summary>
        /// Always 1
        /// Maybe compression flag?
        /// </summary>
        public int Unknown;

        /// <summary>
        /// Stores the total length of the file name section.
        /// Each file has maximum name length of 64 bytes/characters.
        /// Thus to get the entry count, divide this number by 64.
        /// </summary>
        public int FileNameSectionLength;

        /// <summary>
        /// Another instance of the RenderWare Version
        /// </summary>
        public RwVersion RenderWareVersion;

        /// <summary>
        /// Retrieves the amount of ArchiveFile Name entries following the header.
        /// </summary>
        public int GetNameCount()
        {
            return FileNameSectionLength / OneFileName.FileNameLength;
        }
    }
}
