using Heroes.SDK.Definitions.Structures.RenderWare;

namespace Heroes.SDK.Definitions.Structures.Archive.OneFile
{
    /// <summary>
    /// Contains the header for the ONE file.
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct OneArchiveHeader
    {
        /// <summary>
        /// Always 0
        /// </summary>
        public int Null;

        /// <summary>
        /// Contains the total filesize of the .ONE file, minus the 0xC header.
        /// </summary>
        public int FileSize;

        /// <summary>
        /// Stores the RenderWare version assigned to this .ONE file.
        /// </summary>
        public RwVersion RenderWareVersion;

        /// <summary>
        /// Creates a new Archive header.
        /// </summary>
        /// <param name="fileSize">Size of entire file, minus header</param>
        /// <param name="renderWareVersion">RenderWare version tag assigned to this archive</param>
        public OneArchiveHeader(int fileSize, RwVersion renderWareVersion) : this()
        {
            FileSize = fileSize;
            RenderWareVersion = renderWareVersion;
        }

        /// <summary>
        /// Creates a new Archive header.
        /// </summary>
        /// <param name="renderWareVersion">RenderWare version tag assigned to this archive</param>
        public OneArchiveHeader(RwVersion renderWareVersion) : this()
        {
            RenderWareVersion = renderWareVersion;
        }
    }
}
