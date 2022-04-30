using Heroes.SDK.Definitions.Structures.Object.Hint.Enum;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Heroes.SDK.Definitions.Structures.Object.Hint
{
    [Equals(DoNotAddEqualityOperators = true)]
    public class ManagedEntry : INotifyPropertyChanged
    {
        /// <summary>
        /// Number of the hint which matches the number in the object layout file.
        /// </summary>
        public short HintNumber { get; set; }

        /// <summary>
        /// The character which triggers this hint.
        /// </summary>
        public HintCharacter HintCharacter { get; set; }

        /// <summary>
        /// The text belonging to this hint. Inlined and ending in null terminator.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Amount of frames the hint is shown.
        /// </summary>
        public short ShowDuration { get; set; }

        /// <summary>
        /// Index of the next hint to play after this hint completes.
        /// The index is the order it appears in the final file.
        /// </summary>
        public short NextHint { get; set; }

        public ManagedEntry(short hintNumber, HintCharacter hintCharacter, string text, short showDuration, short nextHint) : this()
        {
            HintNumber = hintNumber;
            HintCharacter = hintCharacter;
            Text = text;
            ShowDuration = showDuration;
            NextHint = nextHint;
        }

        public ManagedEntry(Entry entry, string text) : this()
        {
            HintNumber = entry.HintNumber;
            HintCharacter = entry.HintCharacter;
            ShowDuration = entry.ShowDuration;
            NextHint = entry.NextHint;
            Text = text;
        }

        private ManagedEntry()
        {
            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(AsString) && (e.PropertyName == nameof(HintNumber) ||
                                                       e.PropertyName == nameof(HintCharacter) ||
                                                       e.PropertyName == nameof(Text)))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AsString)));
        }

        /* Overrides & PropertyChanged */

        /// <summary> Shortcut for ToString to use with Data Binding. </summary>
        public string AsString => ToString();
        public override string ToString()
        {
            return $"{HintNumber}-{HintCharacter}: {Text}";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
