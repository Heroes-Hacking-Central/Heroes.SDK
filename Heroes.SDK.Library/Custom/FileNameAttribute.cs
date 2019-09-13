using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Heroes.SDK.Definitions.Enums;

namespace Heroes.SDK.Custom
{
    /// <summary>
    /// This attribute is used to mark <see cref="Heroes.SDK.Definitions.Enums.Stage"/> entries with a specific file name prefix.
    /// </summary>
    public class FileNameAttribute : Attribute
    {
        /// <summary>
        /// Prefix of the individual stage.
        /// </summary>
        public string FileNameWithoutExtension { get; protected set; }

        /// <param name="fileNameWithoutExtension">Prefix of the individual stage.</param>
        public FileNameAttribute(string fileNameWithoutExtension)
        {
            this.FileNameWithoutExtension = fileNameWithoutExtension;
        }

        /// <summary>
        /// Gets the file name without extension of a given <see cref="Stage"/> enumerable.
        /// </summary>
        public static string GetFileName(Stage value)
        {
            Type type           = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            FileNameAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(FileNameAttribute), false) as FileNameAttribute[];
            return attribs.Length > 0 ? attribs[0].FileNameWithoutExtension : "s01";
        }
    }
}
