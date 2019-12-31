using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Reloaded.Memory;

namespace Heroes.SDK.Utilities
{
    public class ExtendedMemoryStream : MemoryStream
    {
        public ExtendedMemoryStream() { }
        public ExtendedMemoryStream(byte[] buffer) : base(buffer) { }
        public ExtendedMemoryStream(byte[] buffer, bool writable) : base(buffer, writable) { }
        public ExtendedMemoryStream(byte[] buffer, int index, int count) : base(buffer, index, count) { }
        public ExtendedMemoryStream(byte[] buffer, int index, int count, bool writable) : base(buffer, index, count, writable) { }
        public ExtendedMemoryStream(byte[] buffer, int index, int count, bool writable, bool publiclyVisible) : base(buffer, index, count, writable, publiclyVisible) { }
        public ExtendedMemoryStream(int capacity) : base(capacity) { }

        /// <summary>
        /// Pads a list of bytes until it is aligned.
        /// </summary>
        public void AddPadding(int alignment = 2048)
        {
            var padding = RoundUp((int)Length, alignment) - Length;
            if (padding <= 0)
                return;

            Write(new byte[padding], 0, (int)padding);
        }

        /// <summary>
        /// Appends an unmanaged structure onto the <see cref="MemoryStream"/> and advances the position.
        /// </summary>
        public void Append<T>(T[] structure) where T : unmanaged => Append(StructArray.GetBytes(structure));

        /// <summary>
        /// Appends an managed/marshalled structure onto the <see cref="MemoryStream"/> and advances the position.
        /// </summary>
        public void Append<T>(T[] structure, bool marshalStructure = true) => Append(StructArray.GetBytes(structure, marshalStructure));

        /// <summary>
        /// Appends an unmanaged structure onto the <see cref="MemoryStream"/> and advances the position.
        /// </summary>
        public void Append<T>(T structure) where T : unmanaged => Append(Struct.GetBytes(structure));

        /// <summary>
        /// Appends a managed/marshalled structure onto the given <see cref="MemoryStream"/> and advances the position.
        /// </summary>
        public void Append<T>(T structure, bool marshalStructure = true) => Append(Struct.GetBytes(structure, marshalStructure));

        /// <summary>
        /// Appends bytes onto the given <see cref="MemoryStream"/> and advances the position.
        /// </summary>
        public void Append(byte[] data) => Write(data, 0, data.Length);

        /// <summary>
        /// Rounds up a specified number to the next multiple of X.
        /// </summary>
        /// <param name="number">The number to round up.</param>
        /// <param name="multiple">The multiple the number should be rounded to.</param>
        /// <returns></returns>
        private static int RoundUp(int number, int multiple)
        {
            if (multiple == 0)
                return number;

            int remainder = number % multiple;
            if (remainder == 0)
                return number;

            return number + multiple - remainder;
        }
    }
}
