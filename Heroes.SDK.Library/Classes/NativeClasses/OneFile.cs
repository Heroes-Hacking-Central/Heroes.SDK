using Heroes.SDK.Definitions.Structures.Archive.OneFile;
using Heroes.SDK.Parsers;
using Heroes.SDK.Utilities.Misc;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System.Runtime.InteropServices;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute;
using Strings = Heroes.SDK.Utilities.Misc.Strings;

namespace Heroes.SDK.Classes.NativeClasses
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x5C)]
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

        /* Function Listing */

        public static IFunction<Native_CheckFileID> Fun_CheckFileId { get; } = SDK.ReloadedHooks.CreateFunction<Native_CheckFileID>(0x0042F280);
        public static IFunction<Native_LoadHAnimationEx> Fun_LoadHAnimationEx { get; } = SDK.ReloadedHooks.CreateFunction<Native_LoadHAnimationEx>(0x0042F7C0);
        public static IFunction<Native_LoadOneFile> Fun_LoadOneFile { get; } = SDK.ReloadedHooks.CreateFunction<Native_LoadOneFile>(0x0042F100);
        public static IFunction<Native_OnefileConstructor> Fun_Constructor { get; } = SDK.ReloadedHooks.CreateFunction<Native_OnefileConstructor>(0x0042F0D0);
        public static IFunction<Native_OneFileLoadCameraTmb> Fun_LoadCameraTmb { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadCameraTmb>(0x0042F770);
        public static IFunction<Native_OneFileLoadClump> Fun_LoadClump { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadClump>(0x0042F440);
        public static IFunction<Native_OneFileLoadDeltaMorph> Fun_LoadDeltaMorph { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadDeltaMorph>(0x0042F520);
        public static IFunction<Native_OneFileLoadHAnimation> Fun_LoadHAnimation { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadHAnimation>(0x0042F600);
        public static IFunction<Native_OneFileLoadMaestro> Fun_LoadMaestro { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadMaestro>(0x0042F6F0);
        public static IFunction<Native_OneFileLoadSpline> Fun_LoadSpline { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadSpline>(0x0042F4B0);
        public static IFunction<Native_OneFileLoadTextureDictionary> Fun_LoadTextureDictionary { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadTextureDictionary>(0x0042F3C0);
        public static IFunction<Native_OneFileLoadUVAnim> Fun_LoadUVAnim { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadUVAnim>(0x0042F670);
        public static IFunction<Native_OneFileLoadWorld> Fun_LoadWorld { get; } = SDK.ReloadedHooks.CreateFunction<Native_OneFileLoadWorld>(0x0042F590);
        public static IFunction<Native_OpenData> Fun_OpenData { get; } = SDK.ReloadedHooks.CreateFunction<Native_OpenData>(0x0042F340);
        public static IFunction<Native_ReleaseOneFile> Fun_ReleaseOneFile { get; } = SDK.ReloadedHooks.CreateFunction<Native_ReleaseOneFile>(0x0042F210);
        public static IFunction<Native_SetOneFileOneTime> Fun_SetOneFileOneTime { get; } = SDK.ReloadedHooks.CreateFunction<Native_SetOneFileOneTime>(0x0042F7F0);

        /*
            Original Function Calls 
        */

        /// <summary>
        /// Initializes a .ONE file into a pre-allocated memory location.
        /// </summary>
        /// <param name="fileName">The name of the ONE File to load from.</param>
        /// <param name="allocatedMemoryPtr">Malloc'd Memory Struct to write ONE file to.</param>
        /// <param name="boolLoadOneFile">Informs the ONEFile class instance whether the .ONE file should be loaded on instantiation. Set 1 to true, 0 to false.</param>
        /// <returns>The "This" pointer with ONEFILE class written to it.</returns>
        public void* Constructor(string fileName, void* allocatedMemoryPtr, int boolLoadOneFile) => Fun_Constructor.GetWrapper()(fileName, allocatedMemoryPtr, ref this, boolLoadOneFile);

        /// <summary>
        /// Gets the index of the file with a specified passed in name.
        /// </summary>
        /// <param name="fileNamePtr">The name of the ONE file to load. Up to 64 characters.</param>
        /// <returns>he index of the file with specified file name (or -1). Up to 255</returns>
        public int CheckFileId(string fileNamePtr) => Fun_CheckFileId.GetWrapper()(ref this, fileNamePtr);

        /// <summary>
        /// Opens a .ONE file, reads and returns the address of a specified decompressed .anm HAnim file.
        /// </summary>
        /// <param name="fileNamePtr">Pointer to the file name to load the HAnimation (ANM) from.</param>
        /// <param name="allocatedMemoryPtr">Malloc'd Memory Struct To Write ONE File to.</param>
        /// <param name="animationFileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <returns>The address containing the read in ANM (H Anim - Character Animation) stream.</returns>
        public void* LoadHAnimationEx(string fileNamePtr, void* allocatedMemoryPtr, int animationFileIndex) => Fun_LoadHAnimationEx.GetWrapper()(fileNamePtr, allocatedMemoryPtr, ref this, animationFileIndex);

        /// <summary>
        /// Loads a .ONE file from the hard drive into memory;
        /// </summary>
        /// <param name="allocatedMemoryPtr">Malloc'd Memory Struct To Write ONE File to.</param>
        /// <param name="fileNamePtr">The name of the ONE file to load.</param>
        /// <returns>1 if the operation succeeded, else 0.</returns>
        public void* LoadOneFile(void* allocatedMemoryPtr, string fileNamePtr) => Fun_LoadOneFile.GetWrapper()(ref this, allocatedMemoryPtr, fileNamePtr);

        /// <summary>
        /// Reads a Camera TMB (NJS_MOTION) from a specified file index in the archive.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in Camera TMB (NJS_MOTION *) stream.</returns>
        public void* LoadCameraTmb(int fileIndex, void* addressToDecompressTo) => Fun_LoadCameraTmb.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Reads a DFF/Clump stream from a .ONE archive. Returns address of a decompressed DFF file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in DFF (Clump) stream.</returns>
        public void* LoadClump(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer) => Fun_LoadClump.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Reads a DMA/Delta Morph stream from a .ONE archive. Returns address of a decompressed DMA file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in DMA (Delta Morph) stream.</returns>
        public void* LoadDeltaMorph(int fileIndex, void* addressToDecompressTo) => Fun_LoadDeltaMorph.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Reads a ANM/HAnim stream from a .ONE archive. Returns address of a decompressed ANM file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in ANM (H Anim - Character Animation) stream.</returns>
        public void* LoadHAnimation(int fileIndex, void* addressToDecompressTo) => Fun_LoadHAnimation.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Reads a ANM/Maestro stream from a .ONE archive. Returns address of a decompressed ANM file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in ANM (RW Maestro) stream.</returns>
        public void* LoadMaestro(void* addressToDecompressTo, int fileIndex) => Fun_LoadMaestro.GetWrapper()(addressToDecompressTo, ref this, fileIndex);

        /// <summary>
        /// Reads a SPL/RW Spline stream from a .ONE archive. Returns address of a decompressed SPL file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in SPL (Spline) stream.</returns>
        public void* LoadSpline(int fileIndex, void* addressToDecompressTo) => Fun_LoadSpline.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Reads a TXD/RW Texture Dictionary stream from a .ONE archive. Returns address of a decompressed TXD file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in TXD (Texture Dictionary) stream.</returns>
        public void* LoadTextureDictionary(int fileIndex, void* addressToDecompressTo) => Fun_LoadTextureDictionary.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Reads a UVA/RW UV Animation stream from a .ONE archive. Returns address of a decompressed UVA file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in UVA (UV Anim) stream.</returns>
        public void* LoadUVAnim(int fileIndex, void* addressToDecompressTo) => Fun_LoadUVAnim.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Reads a UVA/RW UV Animation stream from a .ONE archive. Returns address of a decompressed UVA file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The address containing the read in BSP (World) stream.</returns>
        public void* LoadWorld(int fileIndex, void* addressToDecompressTo) => Fun_LoadWorld.GetWrapper()(fileIndex, addressToDecompressTo, ref this);

        /// <summary>
        /// Decompresses a file from the ONE archive with a specified index, into a set pointer.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2).</param>
        /// <param name="pointerToWriteTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The amount of decompressed bytes (the data is at the supplied pointer to write to address).</returns>
        public int OpenData(int fileIndex, void* pointerToWriteTo) => Fun_OpenData.GetWrapper()(ref this, fileIndex, pointerToWriteTo);

        /// <summary>
        /// Unloads a ONE file from a specific ONEFILE instance.
        /// </summary>
        /// <returns>1 if the operation succeeded, else 0.</returns>
        public int ReleaseOneFile() => Fun_ReleaseOneFile.GetWrapper()(ref this);

        /// <summary>
        /// Presumably an alternate "constructor" of sorts, for creating ONE Files for single time use. 
        /// Presumed to be released by calling ReleaseOneFile explicitly rather constructor.
        /// A file loaded by this method assumes the name of memoryOneFileNoRel.xxx.
        /// </summary>
        /// <param name="addressContainingONEFile">The Memory address containing an already loaded .ONE file in memory.</param>
        /// <param name="oneFileSize">The size of the .ONE file to load.</param>
        /// <returns>1 if the operation is successful, else 0.</returns>
        public int SetOneFileOneTime(void* addressContainingONEFile, int oneFileSize) => Fun_SetOneFileOneTime.GetWrapper()(addressContainingONEFile, ref this, oneFileSize);

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
                return Strings.Windows1252Encoder.FromCharPtr(fileNamePtr);
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
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Caller, 0x40)]
        public delegate int Native_CheckFileID(ref OneFile thisPointer, string fileNamePtr);

        /// <summary>
        /// Opens a .ONE file, reads and returns the address of a specified decompressed .anm HAnim file.
        /// </summary>
        /// <param name="fileNamePtr">[EAX] Pointer to the file name to load the HAnimation (ANM) from.</param>
        /// <param name="allocatedMemoryPtr">[EDI] Malloc'd Memory Struct To Write ONE File to.</param>
        /// <param name="thisPointer">[ESI] "This" pointer for the ONEFILE class instance.</param>
        /// <param name="animationFileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <returns>The address containing the read in ANM (H Anim - Character Animation) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.edi, Register.esi }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_LoadHAnimationEx(string fileNamePtr, void* allocatedMemoryPtr, ref OneFile thisPointer, int animationFileIndex);

        /// <summary>
        /// Loads a .ONE file from the hard drive into memory;
        /// </summary>
        /// <param name="thisPointer">[EAX] "This" pointer for the ONEFILE class instance.</param>
        /// <param name="allocatedMemoryPtr">[EDI] Malloc'd Memory Struct To Write ONE File to.</param>
        /// <param name="fileNamePtr">The name of the ONE file to load.</param>
        /// <returns>1 if the operation succeeded, else 0.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.edi }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_LoadOneFile(ref OneFile thisPointer, void* allocatedMemoryPtr, string fileNamePtr);

        /// <summary>
        /// Initializes a .ONE file into a pre-allocated memory location.
        /// </summary>
        /// <param name="fileName">[EAX] The name of the ONE File to load from.</param>
        /// <param name="allocatedMemoryPtr">[EDI] Malloc'd Memory Struct to write ONE file to.</param>
        /// <param name="thisPointer">[ESI] "This" pointer to write ONEFILE class to.</param>
        /// <param name="boolLoadOneFile">Informs the ONEFile class instance whether the .ONE file should be loaded on instantiation. Set 1 to true, 0 to false.</param>
        /// <returns>The "This" pointer with ONEFILE class written to it.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.edi, Register.esi }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OnefileConstructor(string fileName, void* allocatedMemoryPtr, ref OneFile thisPointer, int boolLoadOneFile);

        /// <summary>
        /// Reads a Camera TMB (NJS_MOTION) from a specified file index in the archive.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in Camera TMB (NJS_MOTION *) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadCameraTmb(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Reads a DFF/Clump stream from a .ONE archive. Returns address of a decompressed DFF file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in DFF (Clump) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadClump(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Reads a DMA/Delta Morph stream from a .ONE archive. Returns address of a decompressed DMA file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in DMA (Delta Morph) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadDeltaMorph(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Reads a ANM/HAnim stream from a .ONE archive. Returns address of a decompressed ANM file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in ANM (H Anim - Character Animation) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadHAnimation(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Reads a ANM/Maestro stream from a .ONE archive. Returns address of a decompressed ANM file.
        /// </summary>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[EAX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in ANM (RW Maestro) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadMaestro(void* addressToDecompressTo, ref OneFile thisPointer, int fileIndex);

        /// <summary>
        /// Reads a SPL/RW Spline stream from a .ONE archive. Returns address of a decompressed SPL file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in SPL (Spline) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadSpline(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Reads a TXD/RW Texture Dictionary stream from a .ONE archive. Returns address of a decompressed TXD file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in TXD (Texture Dictionary) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadTextureDictionary(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Reads a UVA/RW UV Animation stream from a .ONE archive. Returns address of a decompressed UVA file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in UVA (UV Anim) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadUVAnim(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Reads a UVA/RW UV Animation stream from a .ONE archive. Returns address of a decompressed UVA file.
        /// </summary>
        /// <param name="fileIndex">[EAX] The index of the file inside the .ONE archive (starting with 2)</param>
        /// <param name="addressToDecompressTo">[ECX] The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <param name="thisPointer">"This" pointer for the ONEFILE class instance.</param>
        /// <returns>The address containing the read in BSP (World) stream.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.ecx }, Register.eax, StackCleanup.Callee)]
        public delegate void* Native_OneFileLoadWorld(int fileIndex, void* addressToDecompressTo, ref OneFile thisPointer);

        /// <summary>
        /// Decompresses a file from the ONE archive with a specified index, into a set pointer.
        /// </summary>
        /// <param name="thisPointer">[EAX] "This" pointer for the ONEFILE class instance.</param>
        /// <param name="fileIndex">The index of the file inside the .ONE archive (starting with 2).</param>
        /// <param name="pointerToWriteTo">The address to which the file inside the ONE archive will be decompressed to.</param>
        /// <returns>The amount of decompressed bytes (the data is at the supplied pointer to write to address).</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax }, Register.eax, StackCleanup.Callee, 0x68)] // Reserved stack space needed probably 54h but I added extra for safety.
        public delegate int Native_OpenData(ref OneFile thisPointer, int fileIndex, void* pointerToWriteTo);

        /// <summary>
        /// Unloads a ONE file from a specific ONEFILE instance.
        /// </summary>
        /// <param name="thisPointer">[EBX] "This" pointer for the ONEFILE class instance.</param>
        /// <returns>1 if the operation succeeded, else 0.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.ebx }, Register.eax, StackCleanup.Caller)]
        public delegate int Native_ReleaseOneFile(ref OneFile thisPointer);

        /// <summary>
        /// Presumably an alternate "constructor" of sorts, for creating ONE Files for single time use. 
        /// Presumed to be released by calling ReleaseOneFile explicitly rather constructor.
        /// A file loaded by this method assumes the name of memoryOneFileNoRel.xxx.
        /// </summary>
        /// <param name="addressContainingONEFile">[EAX] The Memory address containing an already loaded .ONE file in memory.</param>
        /// <param name="thisPointer">[EDX] This pointer to a ONEFile class.</param>
        /// <param name="oneFileSize">[ECX] The size of the .ONE file to load.</param>
        /// <returns>1 if the operation is successful, else 0.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [Function(new[] { Register.eax, Register.edx, Register.ecx }, Register.eax, StackCleanup.Caller, 0x100)]
        public delegate int Native_SetOneFileOneTime(void* addressContainingONEFile, ref OneFile thisPointer, int oneFileSize);
    }
}
