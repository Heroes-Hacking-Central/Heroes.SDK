using Heroes.SDK.Definitions.Structures.Object.Hint.Enum;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Object.Hint
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential, Size = 12)]
    public struct Entry
    {
        public static Entry Null = new Entry(0, HintCharacter.Sonic, 0, 0, 0);

        /// <summary>
        /// Number of the hint which matches the number in the object layout file.
        /// </summary>
        public short HintNumber { get; set; }

        /// <summary>
        /// The character which triggers this hint.
        /// </summary>
        public HintCharacter HintCharacter { get; set; }

        /// <summary>
        /// Offset of the hint relative to the end of the hint section.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Amount of frames the hint is shown.
        /// </summary>
        public short ShowDuration { get; set; }

        /// <summary>
        /// Index of the next hint to play after this hint completes.
        /// The index is the order it appears in the final file.
        /// </summary>
        public short NextHint { get; set; }

        public Entry(short hintNumber, HintCharacter hintCharacter, int offset, short showDuration, short nextHint)
        {
            HintNumber = hintNumber;
            HintCharacter = hintCharacter;
            Offset = offset;
            ShowDuration = showDuration;
            NextHint = nextHint;
        }

        /// <summary>
        /// Creates an entry from a managed entry.
        /// Note: Offset field is not calculated, will need to be calculated at time to writing to file.
        /// </summary>
        public Entry(ManagedEntry entry)
        {
            HintNumber = entry.HintNumber;
            HintCharacter = entry.HintCharacter;
            ShowDuration = entry.ShowDuration;
            NextHint = entry.NextHint;
            Offset = 0;
        }
    }
}
