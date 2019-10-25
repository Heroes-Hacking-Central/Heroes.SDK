using System;
using System.Text;
using Reloaded.Memory.Sources;

namespace Heroes.SDK.Utilities.Misc
{
    public static class Strings
    {
        public static Encoding Windows1252Encoder;

        static Strings()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Windows1252Encoder = Encoding.GetEncoding(1252);
        }

        /// <summary>
        /// Converts a sequence of null terminated characters into a string instance.
        /// </summary>
        public static unsafe string FromCharPtr(this Encoding encoding, byte* textPtr)
        {
            return encoding.GetString(textPtr, Strlen(textPtr));
        }

        /// <summary>
        /// Writes a string to a specified char pointer in the desired encoding.
        /// </summary>
        /// <param name="encoding">The encoding to use.</param>
        /// <param name="text">The text to write to the pointer.</param>
        /// <param name="pointer">The pointer to write to.</param>
        public static unsafe void ToCharPtr(this Encoding encoding, string text, byte* pointer)
        {
            Memory.CurrentProcess.WriteRaw((IntPtr) pointer, encoding.GetBytes(text));
        }

        /// <summary>
        /// Gets the length of a null terminated string pointer.
        /// </summary>
        public static unsafe int Strlen(byte* stringPtr)
        {
            int length = 0;
            while (stringPtr[length] != 0x00)
                length++;

            return length;
        }
    }
}
