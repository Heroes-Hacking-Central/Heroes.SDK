using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Heroes.SDK.Classes.NativeClasses;
using Heroes.SDK.Definitions.Structures.Archive.OneFile;
using Heroes.SDK.Definitions.Structures.Archive.OneFile.Custom;
using Heroes.SDK.Definitions.Structures.RenderWare;
using Heroes.SDK.Utilities;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.Parsers
{
    /// <summary>
    /// A managed class that encapsulates a native .ONE Archive.
    /// (ONE Archive Parser)
    ///
    /// If you are looking for the ONEFILE class used by the game, consider <see cref="OneFile"/>
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public unsafe class OneArchive : IDisposable
    {
        /// <summary>
        /// Address of the ONE archive header.
        /// </summary>
        public OneArchiveHeader*        Header { get; private set; }

        /// <summary>
        /// Address of the file name section header.
        /// </summary>
        public OneNameSectionHeader*    NameSectionHeader { get; private set; }

        /// <summary>
        /// Address of the array of file names.
        /// Note: The first two file names are unused.
        /// Names[2] => Files[0]
        /// </summary>
        public FixedArrayPtr<OneFileName> Names { get; private set; }

        /// <summary>
        /// Address of the first file entry.
        /// Note: This is provided for convenience only, it should not be used.
        /// These entries are tuples of file data and file headers and thus are not fixed in length.
        /// To get the individual files use <see cref="GetFileEntryEnumerator"/>
        /// </summary>
        public OneFileEntry*            Files { get; private set; }

        private GCHandle? _handle;
        private int _fileLength;

        /* Setup/Teardown */

        /// <summary>
        /// Creates a ONE archive given the bytes of a Heroes ONE file.
        /// </summary>
        public OneArchive(byte[] data)
        {
            _handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            var dataPointer = (byte*) _handle?.AddrOfPinnedObject();
            SetupPointers(dataPointer);
        }

        /// <summary>
        /// Creates a ONE archive given the memory address of a Heroes ONE file and its length.
        /// </summary>
        public OneArchive(byte* data)
        {
            SetupPointers(data);
        }

        private void SetupPointers(byte* oneFileStart)
        {
            Header            = (OneArchiveHeader*)      oneFileStart;
            NameSectionHeader = (OneNameSectionHeader*) ((byte*)Header   + sizeof(OneArchiveHeader));
            Names             = new FixedArrayPtr<OneFileName>((ulong)((byte*)NameSectionHeader + sizeof(OneNameSectionHeader)), NameSectionHeader->GetNameCount());
            Files             = (OneFileEntry*) ((byte*)Names.Pointer + NameSectionHeader->FileNameSectionLength);

            _fileLength = Header->FileSize + sizeof(OneArchiveHeader);
        }

        ~OneArchive()
        {
            Dispose();
        }

        public void Dispose()
        {
            _handle?.Free();
            GC.SuppressFinalize(this);
        }

        /* Class Implementation */

        /// <summary>
        /// Creates a ONE archive from a set of files.
        /// </summary>
        /// <param name="files">The files to create an archive from.</param>
        /// <param name="bufferSize">Size of the search buffer used in compression between 0-8191.</param>
        public static byte[] FromFiles(IList<ManagedOneFile> files, int bufferSize = 255) => FromFiles(files, new RwVersion(3, 3, 0, 0));

        /// <summary>
        /// Creates a ONE archive from a set of files.
        /// </summary>
        /// <param name="files">The files to create an archive from.</param>
        /// <param name="version">The version of the archive. Heroes' default is 3.5.0.0. Consider using 3.3.0.0 to support all available prototypes.</param>
        /// <param name="bufferSize">Size of the search buffer used in compression between 0-8191.</param>
        public static byte[] FromFiles(IList<ManagedOneFile> files, RwVersion version, int bufferSize = 255)
        {
            // Compress all files.
            files = files.Select(x => new ManagedOneFile(x.Name, x.GetCompressedData(bufferSize), true)).ToArray();

            // Calculate sizes.
            var numberOfFiles = files.Count + 2; // Two dummy entries.
            var sizeOfHeaders = sizeof(OneArchiveHeader) + sizeof(OneNameSectionHeader);
            var sizeOfNameSection = sizeof(OneFileName) * numberOfFiles;
            var sizeOfFileSection = files.Sum(x => x.GetCompressedData().Length + sizeof(OneFileEntry));

            var totalSize = sizeOfHeaders + sizeOfNameSection + sizeOfFileSection;

            // Make file.
            using var memStream = new ExtendedMemoryStream(totalSize);
            memStream.Append(new OneArchiveHeader(totalSize - sizeof(OneArchiveHeader), version));
            memStream.Append(new OneNameSectionHeader(sizeOfNameSection, version));
            memStream.Append(new OneFileName("")); // Dummy entries
            memStream.Append(new OneFileName(""));

            foreach (var file in files)
                memStream.Append(new OneFileName(file.Name));

            int nameSectionIndex = 2;
            foreach (var file in files)
            {
                memStream.Append(new OneFileEntry(nameSectionIndex++, file.GetCompressedData().Length, file.RwVersion));
                memStream.Append(file.GetCompressedData());
            }

            return memStream.ToArray();
        }

        /// <summary>
        /// Returns all of the files belonging to this class in user editable format.
        /// </summary>
        public List<ManagedOneFile> GetFiles()
        {
            var files          = new List<ManagedOneFile>(NameSectionHeader->GetNameCount());
            var fileEnumerator = GetFileEntryEnumerator();
            while (fileEnumerator.MoveNext())
            {
                files.Add(fileEnumerator.Current->ToManaged((OneFileName*) Names.Pointer));
            }

            return files;
        }

        /// <summary>
        /// Calculates the number of files assigned to this ONE archive.
        /// </summary>
        public int GetNumberOfFiles()
        {
            int number = 0;
            var enumerator = GetFileEntryEnumerator();
            while (enumerator.MoveNext())
            {
                number += 1;
            }

            return number;
        }

        /// <summary>
        /// Retrieves the enumerator that can be used with ONE archives.
        /// </summary>
        public OneArchiveEntryEnumerator GetFileEntryEnumerator()
        {
            return new OneArchiveEntryEnumerator(Files, ((byte*)Header) + _fileLength);
        }

        public ref struct OneArchiveEntryEnumerator
        {
            public  OneFileEntry* Current { get; private set; }
            private OneFileEntry* _initial;

            private void* _maxPointer;

            public OneArchiveEntryEnumerator(OneFileEntry* initial, void* maxPointer)
            {
                Current        = null;
                _initial       = initial;
                _maxPointer    = maxPointer;
            }

            public bool MoveNext()
            {
                // First item
                if (Current == null)
                {
                    Current = _initial;
                    return true;
                }

                // Every item thereafter.
                Current = (OneFileEntry*) Unsafe.Add<byte>(Current, Current->FileSize);
                Current += 1;
                return (void*)Current < _maxPointer;
            }

            public void Reset()   => Current = null;
            public void Dispose() { }
        }
    }
}
