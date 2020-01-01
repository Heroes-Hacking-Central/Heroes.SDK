using System;
using System.Collections.Generic;
using System.Text;
using Heroes.SDK.Definitions.Structures.RenderWare;
using static Heroes.SDK.SDK;

namespace Heroes.SDK.Definitions.Structures.Archive.OneFile.Custom
{
    public class ManagedOneFile
    {
        /// <summary>
        /// The name belonging to this file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns true if the data is compressed, else false.
        /// </summary>
        public bool IsDataCompressed { get; private set; }

        /// <summary>
        /// Data corresponding to this individual file.
        /// Can be compressed or uncompressed.
        /// Use <see cref="GetUncompressedData"/> to get uncompressed data.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// RenderWare version of the individual ONE file.
        /// Not really used for anything aside from blocking access if version is above game version
        /// </summary>
        public RwVersion RwVersion { get; set; }

        /// <summary>
        /// Creates a file given the data and RenderWare version.
        /// </summary>
        /// <param name="name">Name of this ONE file.</param>
        /// <param name="data">Uncompressed data belonging to the file</param>
        public ManagedOneFile(string name, byte[] data)
        {
            Name = name;
            IsDataCompressed = false;
            Data = data;
            RwVersion = new RwVersion(3,2,0,0);
        }

        /// <summary>
        /// Creates a file given data, whether it's compressed and the RW version.
        /// </summary>
        /// <param name="name">Name of this ONE file.</param>
        /// <param name="isDataCompressed">Whether the data is compressed.</param>
        /// <param name="data">Uncompressed data belonging to the file</param>
        public ManagedOneFile(string name, byte[] data, bool isDataCompressed)
        {
            Name = name;
            IsDataCompressed = isDataCompressed;
            Data = data;
            RwVersion = new RwVersion(3, 2, 0, 0);
        }

        /// <summary>
        /// Creates a file given the data and RenderWare version.
        /// </summary>
        /// <param name="name">Name of this ONE file.</param>
        /// <param name="data">Uncompressed data belonging to the file</param>
        /// <param name="rwVersion">RenderWare version corresponding to this file.</param>
        public ManagedOneFile(string name, byte[] data, RwVersion rwVersion)
        {
            Name = name;
            IsDataCompressed = false;
            Data = data;
            RwVersion = rwVersion;
        }

        /// <summary>
        /// Creates a file given data, whether it's compressed and the RW version.
        /// </summary>
        /// <param name="name">Name of this ONE file.</param>
        /// <param name="isDataCompressed">Whether the data is compressed.</param>
        /// <param name="data">Uncompressed data belonging to the file</param>
        /// <param name="rwVersion">RenderWare version corresponding to this file.</param>
        public ManagedOneFile(string name, byte[] data, bool isDataCompressed, RwVersion rwVersion)
        {
            Name = name;
            IsDataCompressed = isDataCompressed;
            Data = data;
            RwVersion = rwVersion;
        }

        /// <summary>
        /// Decompresses the file (if necessary), retrieving the data corresponding to this file.
        /// </summary>
        public byte[] GetUncompressedData()
        {
            return IsDataCompressed ? Prs.Decompress(Data) : Data;
        }

        /// <summary>
        /// Compresses the file (if necessary), retrieving the compressed data corresponding to this file.
        /// </summary>
        /// <param name="bufferSize">Size of the compressor search buffer, between 0 - 8191.</param>
        public byte[] GetCompressedData(int bufferSize = 255)
        {
            return IsDataCompressed ? Data : Prs.Compress(Data, bufferSize);
        }

        /// <summary>
        /// Sets the data corresponding to this ONE file.
        /// </summary>
        /// <param name="data">The data to obtain.</param>
        /// <param name="isCompressed">Whether the data is compressed or not.</param>
        public void SetData(byte[] data, bool isCompressed)
        {
            IsDataCompressed = isCompressed;
            Data = data;
        }
    }
}
