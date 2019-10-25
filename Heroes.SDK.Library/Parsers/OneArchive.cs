using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Heroes.SDK.Classes.NativeClasses;
using Heroes.SDK.Definitions.Structures.Archive.OneFile;

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
        public OneFileName*             Names { get; private set; }

        /// <summary>
        /// Address of the first file entry.
        /// Note: This is provided for convenience only, it should not be used.
        /// These entries are tuples of file data and file headers and thus are not fixed in length.
        /// To get the individual files use <see cref="GetFileEntryEnumerator"/>
        /// </summary>
        public OneFileEntry*            Files { get; private set; }

        private GCHandle? _handle;

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
        /// Creates a ONE archive given the memory address of a Heroes ONE file.
        /// </summary>
        public OneArchive(byte* data)
        {
            SetupPointers(data);
        }

        private void SetupPointers(byte* oneFileStart)
        {
            Header            = (OneArchiveHeader*)      oneFileStart;
            NameSectionHeader = (OneNameSectionHeader*) ((byte*)Header   + sizeof(OneArchiveHeader));
            Names             = (OneFileName*)  ((byte*)NameSectionHeader + sizeof(OneNameSectionHeader));
            Files             = (OneFileEntry*) ((byte*)Names + NameSectionHeader->FileNameSectionLength);
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
        /// Retrieves the enumerator that can be used with ONE archives.
        /// </summary>
        public OneArchiveEntryEnumerator GetFileEntryEnumerator()
        {
            return new OneArchiveEntryEnumerator(Files, NameSectionHeader->GetNameCount());
        }

        public ref struct OneArchiveEntryEnumerator
        {
            public  OneFileEntry* Current { get; private set; }
            private OneFileEntry* _initial;

            private int _numberOfFiles;
            private int _index;

            public OneArchiveEntryEnumerator(OneFileEntry* initial, int numberOfFiles)
            {
                _index         = -1;
                Current        = null;
                _initial       = initial;
                _numberOfFiles = numberOfFiles;
            }

            public bool MoveNext()
            {
                // First item
                if (Current == null)
                {
                    _index  = 0;
                    Current = _initial;
                    return true;
                }

                // Every item thereafter.
                if (_index >= _numberOfFiles)
                    return false;

                Current = (OneFileEntry*) Unsafe.Add<byte>(Current, Current->FileSize);
                Current += 1;
                _index += 1;
                return true;
            }

            public void Reset()   => Current = null;
            public void Dispose() { }
        }
    }
}
