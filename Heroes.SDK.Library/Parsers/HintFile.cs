using Heroes.SDK.Definitions.Structures.Object.Hint;
using Reloaded.Memory;
using Reloaded.Memory.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Reloaded.Memory.Extensions;

namespace Heroes.SDK.Parsers
{
    /// <summary>
    /// Parses a hint file for any of the western languages.
    /// e.g. hint001e.bin, hint001f.bin
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public class HintFile
    {
        // Approximate length of a long string, used for file size estimations.
        private const int LongStringLength = 80;
        private static Encoding _encoder;

        static HintFile()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _encoder = Encoding.GetEncoding(1252);
        }

        public ManagedEntry[] Entries;

        /// <summary>
        /// Creates a <see cref="HintFile"/> given a set of hint entries.
        /// </summary>
        public HintFile(ManagedEntry[] entries)
        {
            Entries = entries;
        }

        /// <summary>
        /// Creates a <see cref="HintFile"/> from a pointer to the first byte of the file.
        /// </summary>
        /// <param name="fileData">Address of the first byte of the hint file to parse.</param>
        /// <param name="fileLength">The size of the hint file.</param>
        public static unsafe HintFile FromArray(byte* fileData, int fileLength)
        {
            using UnmanagedMemoryStream fileDataStream = new UnmanagedMemoryStream(fileData, fileLength);
            var reader = new BufferedStreamReader<UnmanagedMemoryStream>(fileDataStream, 4096);

            // Get all entries.
            var entries = new List<Entry>((fileLength / 2) / sizeof(Entry));
            Entry entry;

            do
            {
                reader.Read(out entry);
                entries.Add(entry);
            }
            while (!entry.Equals(Entry.Null));
            entries.RemoveAt(entries.Count - 1);

            // Convert all entries to managed.
            byte* stringDataPtr = &fileData[reader.Position];
            var managedEntries = new ManagedEntry[entries.Count];
            for (int i = 0; i < managedEntries.Length; i++)
            {
                var textPtr = &stringDataPtr[entries[i].Offset];
                var text = _encoder.GetString(textPtr, Strlen(textPtr));
                managedEntries[i] = new ManagedEntry(entries[i], text);
            }

            return new HintFile(managedEntries);
        }

        /// <summary>
        /// Creates a <see cref="HintFile"/> from a byte array.
        /// </summary>
        /// <param name="fileData">The hint file to parse.</param>
        public static unsafe HintFile FromArray(byte[] fileData)
        {
            fixed (byte* fileDataPtr = fileData)
                return FromArray(fileDataPtr, fileData.Length);
        }

        /// <summary>
        /// Creates a byte array to be read by the game from a <see cref="HintFile"/>.
        /// </summary>
        public unsafe byte[] ToArray()
        {
            // Make native entries.
            var entries = new Entry[Entries.Length];
            for (int x = 0; x < entries.Length; x++)
                entries[x] = new Entry(Entries[x]);

            // Write strings from managed entries to a byte region.
            var stringData = new List<byte>(entries.Length * LongStringLength);
            byte[] bytes;

            for (int x = 0; x < entries.Length; x++)
            {
                entries[x].Offset = stringData.Count;
                bytes = _encoder.GetBytes(Entries[x].Text);
                stringData.AddRange(bytes);
                stringData.Add(0);
            }

            var nullEntry = Entry.Null;
            var nullEntryPtr = &nullEntry;
            var nullEntryBytes = new Span<byte>(nullEntryPtr, sizeof(Entry));
            var stringDataBytes = stringData.ToArray();

            fixed (Entry* entry = &entries[0])
            {
                var entryData = new Span<byte>(entry, sizeof(Entry) * entries.Length);
                var allData = new byte[entryData.Length + nullEntryBytes.Length + stringData.Count];
                var allDataSpan = allData.AsSpanFast();
                entryData.CopyTo(allData);
                nullEntryBytes.CopyTo(allDataSpan.SliceFast(entryData.Length));
                stringDataBytes.CopyTo(allDataSpan.SliceFast(entryData.Length + nullEntryBytes.Length));
                return allData;
            }
        }

        /// <summary>
        /// Gets the length of a null terminated string pointer.
        /// </summary>
        private static unsafe int Strlen(byte* stringPtr)
        {
            int length = 0;
            while (stringPtr[length] != 0x00)
            {
                length++;
            }

            return length;
        }
    }
}
