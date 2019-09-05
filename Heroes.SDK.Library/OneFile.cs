using System.Runtime.InteropServices;
using Heroes.SDK.Archive;
using Heroes.SDK.Archive.Structures.ArchiveStructures;
using Reloaded.Hooks.Definitions.X86;

namespace Heroes.SDK.Game
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct OneFile
    {
        /// <summary>
        /// Contains the name of the ONE file.
        /// If it was temporarily loaded with ONEFILE::SetOneFileOneTime, the name
        /// is assumed as "memoryOneFileNoRel.xxx".
        /// </summary>
        [FieldOffset(0)]
        private fixed byte _FileName[0x40];

        /// <summary>
        /// Contains an address/pointer to which a file from the current archive may be decompressed to.
        /// </summary>
        [FieldOffset(0x40)]
        public void* AddressToDecompressFileTo;

        /// <summary>
        /// Contains the pointer to the file name section of the file.
        /// ONE Archive File Offset: 0x18
        /// </summary>
        [FieldOffset(0x44)]
        public OneFileName* NameSectionPointer;

        /// <summary>
        /// Contains a pointer to the ONE file data.
        /// Note: This field isn't always initialized. If not initialized it has the value -1 (0xFFFFFFFF).
        /// </summary>
        [FieldOffset(0x48)]
        public OneArchiveHeader* StartOfFilePointer;

        /// <summary>
        /// Contains a pointer to the ONE file data.
        /// Note: This field isn't always initialized. If not initialized it has the value 0.
        /// </summary>
        [FieldOffset(0x4C)]
        public OneArchiveHeader* Unknown;

        /// <summary>
        /// Set to 1 if a file is currently loaded into the ONEFile instance, else 0.
        /// This one is set in the constructor - it may or may not be re-used much after.
        /// </summary>
        [FieldOffset(0x50)]
        public int Initialized;

        /// <summary>
        /// Contains a pointer to the ONE file data after the 0xC header.
        /// ONE Archive File Offset: 0xC
        /// </summary>
        [FieldOffset(0x54)]
        public OneNameSectionHeader* NameSectionHeaderPointer;

        /// <summary>
        /// Contains the size of the .ONE file.
        /// </summary>
        [FieldOffset(0x58)]
        public int FileLength;

        /*
            Helper Methods 
        */

        /// <summary>
        /// Obtains the archive parser given the instance of the current native class.
        /// </summary>
        public OneArchive GetArchive()
        {
            var startOfFile = ((byte*)NameSectionHeaderPointer) - sizeof(OneArchiveHeader);
            return new OneArchive(startOfFile);
        }

        /*
            Overrides
        */

        /// <summary>
        /// Returns the current file name as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            fixed (byte* fileNamePtr = _FileName)
                return new string((char*) fileNamePtr);
        }

        /*
            The delegates are sorted in alphabetical order as found in IDA
            Not all of them have been tested.
        */

        /// <summary>
        /// Gets the index of the file with a specified passed in name.
        /// </summary>
        /// <param name="thisPointer">[EAX] Pointer To 'This' Variable</param>
        /// <param name="fileNamePtr">[ECX] The name of the ONE file to load. Up to 64 characters.</param>
        /// <returns>he index of the file with specified file name (or -1). Up to 255</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller, 0x40)]
        public delegate int CheckFileID(OneFile* thisPointer, string fileNamePtr);

        /// <summary>
        /// Opens a .ONE file, reads and returns the address of a specified decompressed .anm HAnim file.
        /// </summary>
        /// <param name="fileNamePtr">[EAX] Pointer to the file name to load the HAnimation (ANM) from.</param>
        /// <param name="allocatedMemoryPtr">[EDI] Malloc'd Memory Struct To Write ONE File to.</param>
        /// <param name="thisPointer">[ESI] "This" pointer for the ONEFILE class instance.</param>
        /// <param name="animationFileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <returns>The address containing the read in ANM (H Anim - Character Animation) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.edi, FunctionAttribute.Register.esi }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* LoadHAnimationEx(string fileNamePtr, void* allocatedMemoryPtr, OneFile* thisPointer, int animationFileIndex);

        /// <summary>
        /// Loads a .ONE file from the hard drive into memory;
        /// </summary>
        /// <param name="thisPointer">[EAX] "This" pointer for the ONEFILE class instance.</param>
        /// <param name="allocatedMemoryPtr">[EDI] Malloc'd Memory Struct To Write ONE File to.</param>
        /// <param name="fileNamePtr">The name of the ONE file to load.</param>
        /// <returns>1 if the operation succeeded, else 0.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.edi }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* LoadOneFile(OneFile* thisPointer, void* allocatedMemoryPtr, string fileNamePtr);

        /// <summary>
        /// Initializes a .ONE file into a pre-allocated memory location.
        /// </summary>
        /// <param name="fileName">[EAX] The name of the ONE File to load from.</param>
        /// <param name="allocatedMemoryPtr">[EDI] Malloc'd Memory Struct to write ONE file to.</param>
        /// <param name="thisPointer">[ESI] "This" pointer to write ONEFILE class to.</param>
        /// <param name="boolLoadOneFile">Informs the ONEFile class instance whether the .ONE file should be loaded on instantiation. Set 1 to true, 0 to false.</param>
        /// <returns>The "This" pointer with ONEFILE class written to it.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.edi, FunctionAttribute.Register.esi }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OnefileConstructor(string fileName, void* allocatedMemoryPtr, OneFile* thisPointer, int boolLoadOneFile);

        /// <summary>
        /// Reads a Camera TMB (NJS_MOTION) from a specified file index in the archive.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in Camera TMB (NJS_MOTION *) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadCameraTmb(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Reads a DFF/Clump stream from a .ONE archive. Returns address of a decompressed DFF file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in DFF (Clump) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadClump(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Reads a DMA/Delta Morph stream from a .ONE archive. Returns address of a decompressed DMA file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in DMA (Delta Morph) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadDeltaMorph(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Reads a ANM/HAnim stream from a .ONE archive. Returns address of a decompressed ANM file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in ANM (H Anim - Character Animation) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadHAnimation(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Reads a ANM/Maestro stream from a .ONE archive. Returns address of a decompressed ANM file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[EAX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in ANM (RW Maestro) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadMaestro(void* addressToDecompressTo, OneFile* thisPointer, int fileIndex);

        /// <summary>
        /// Reads a SPL/RW Spline stream from a .ONE archive. Returns address of a decompressed SPL file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in SPL (Spline) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadSpline(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Reads a TXD/RW Texture Dictionary stream from a .ONE archive. Returns address of a decompressed TXD file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in TXD (Texture Dictionary) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadTextureDictionary(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Reads a UVA/RW UV Animation stream from a .ONE archive. Returns address of a decompressed UVA file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in UVA (UV Anim) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadUVAnim(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Reads a UVA/RW UV Animation stream from a .ONE archive. Returns address of a decompressed UVA file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in BSP (World) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee)]
        public delegate void* OneFileLoadWorld(int fileIndex, void* addressToDecompressTo, OneFile* thisPointer);

        /// <summary>
        /// Decompresses a file from the ONE archive with a specified index, into a set pointer.
        /// </summary>
        /// <param name="thisPointer">[EAX] "This" pointer for the ONEFILE class instance.</param>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2).</param>
        /// <param name="pointerToWriteTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The amount of decompressed bytes (the data is at the supplied pointer to write to address).</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Callee, 0x68)] // Reserved stack space needed probably 54h but I added extra for safety.
        public delegate int OpenData(OneFile* thisPointer, int fileIndex, void* pointerToWriteTo);

        /// <summary>
        /// Unloads a ONE file from a specific ONEFILE instance.
        /// </summary>
        /// <param name="thisPointer">[EBX] "This" pointer for the ONEFILE class instance.</param>
        /// <returns>1 if the operation succeeded, else 0.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.ebx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller)]
        public delegate int ReleaseOneFile(OneFile* thisPointer);

        /// <summary>
        /// Presumably an alternate "constructor" of sorts, for creating ONE Files for single time use. 
        /// Presumed to be released by calling ReleaseOneFile explicitly rather constructor.
        /// A file loaded by this method assumes the name of memoryOneFileNoRel.xxx.
        /// </summary>
        /// <param name="addressContainingONEFile">[EAX] The Memory address containing an already loaded .ONE file in memory.</param>
        /// <param name="thisPointer">[EDX] This pointer to a ONEFile class.</param>
        /// <param name="oneFileSize">[ECX] The size of the .ONE file to load.</param>
        /// <returns>1 if the operation is successful, else 0.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [Function(new[] { FunctionAttribute.Register.eax, FunctionAttribute.Register.edx, FunctionAttribute.Register.ecx }, FunctionAttribute.Register.eax, FunctionAttribute.StackCleanup.Caller, 0x100)]
        public delegate int SetOneFileOneTime(void* addressContainingONEFile, OneFile* thisPointer, int oneFileSize);
    }
}
