using System;
using System.Runtime.InteropServices;
using Heroes.SDK.Definitions.Structures.Criware.FileSystem;
using Reloaded.Hooks;

namespace Heroes.SDK.Classes.NativeClasses
{
    /// <summary>
    /// Note: The CRI Filesystem is actually C code, but it was built in an object oriented-like way.
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CriFileSystem
    {
        public bool IsEnabled;
        public int SixIfInvalidFileHandleOrBeyondMaxListSize;
        public int OneIfInvalidFileHandleOrBeyondMaxListSize;
        public int field_C;
        public int field_10;
        public int field_14;
        public char* AlsoDvdrootFullPath;
        public int MaxFileEntryArraySizeInBytes;
        public int FileEntryArraySizeInBytes;
        public char* DvdrootFullPath;
        public int DvdrootFullPathStringLength;
        public int field_2C;
        public int FileEntryCount;
        public int FirstFileEntryPtr;
        public int CurrentFileEntryIteratorPtr;
        public int field_3C;
        public int field_40;

        // TODO: Document the functions, should be mostly self explainable. Sorry for not doing it right now, just too much on my hands. - Sewer

        /* Method Declarations */
        public static Function<Native_AddFileToFileTable> Fun_AddFileToFileTable { get; } = new Function<Native_AddFileToFileTable>(0x006CFF40, ReloadedHooks.Instance);
        public static Function<Native_CreateFromDirectory> Fun_CreateFromDirectory { get; } = new Function<Native_CreateFromDirectory>(0x006C8000, ReloadedHooks.Instance);
        public static Function<Native_SetFileTablePointer> Fun_SetFileTablePointer { get; } = new Function<Native_SetFileTablePointer>(0x006D6310, ReloadedHooks.Instance);
        public static Function<Native_SetTablePointersAndBuild> Fun_SetTablePointersAndBuild { get; } = new Function<Native_SetTablePointersAndBuild>(0x006CFE70, ReloadedHooks.Instance);
        public static Function<Native_BuildFileTable> Fun_BuildFileTable { get; } = new Function<Native_BuildFileTable>(0x006D63B0, ReloadedHooks.Instance);
        public static Function<Native_CallsBuildFileTable> Fun_CallsBuildFileTable { get; } = new Function<Native_CallsBuildFileTable>(0x006D6330, ReloadedHooks.Instance);
        public static Function<Native_GetDvdrootFullPath> Fun_GetDvdrootFullPath { get; } = new Function<Native_GetDvdrootFullPath>(0x006B4040, ReloadedHooks.Instance);
        public static Function<Native_GetFileEntryCount> Fun_GetFileEntryCount { get; } = new Function<Native_GetFileEntryCount>(0x006CEFE0, ReloadedHooks.Instance);
        public static Function<Native_GetFileEntryFromFilePath> Fun_GetFileEntryFromFilePath { get; } = new Function<Native_GetFileEntryFromFilePath>(0x006D00F0, ReloadedHooks.Instance);
        public static Function<Native_GetNextFileEntry> Fun_GetNextFileEntry { get; } = new Function<Native_GetNextFileEntry>(0x006D01D0, ReloadedHooks.Instance);
        public static Function<Native_LoadADXFromFileTable> Fun_LoadADXFromFileTable { get; } = new Function<Native_LoadADXFromFileTable>(0x006D00D0, ReloadedHooks.Instance);
        public static Function<Native_MaybeConstructor> Fun_MaybeConstructor { get; } = new Function<Native_MaybeConstructor>(0x006CFBA0, ReloadedHooks.Instance);
        public static Function<Native_ProbablyResetFileTable> Fun_ProbablyResetFileTable { get; } = new Function<Native_ProbablyResetFileTable>(0x006CF9D0, ReloadedHooks.Instance);

        /* Method Definitions */

        /// <summary>
        /// 0x006C8000
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate CriFileSystem* Native_CreateFromDirectory(char* directoryPath, int a2NormallyMinusOne, int a3NormallyZero, int a4NormallyZero);

        /// <summary>
        /// 0x006D6310
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int Native_SetFileTablePointer(IntPtr newFunctionPointer, CriFileSystem* fileTablePointer);

        /// <summary>
        /// 0x006CFE70
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate CriFileSystem* Native_SetTablePointersAndBuild(CriFileSystem* fileTablePointer);

        /// <summary>
        /// 006CFF40
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int Native_AddFileToFileTable(NewFileInfoTuple* filePath, CriFileSystem* fileTable);

        /// <summary>
        /// 006D63B0
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int Native_BuildFileTable(string folderPath, int decrementsOnNewDirectory, int* a3);

        /// <summary>
        /// 006D6330
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int Native_CallsBuildFileTable(char* a1, int a2, int* a3);

        /// <summary>
        /// 006B4040
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate char* Native_GetDvdrootFullPath(CriFileSystem* fileTable);

        /// <summary>
        /// 006CEFE0
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int Native_GetFileEntryCount(CriFileSystem* fileTable);

        /// <summary>
        /// 006D00F0
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate FileEntry* Native_GetFileEntryFromFilePath(string fullFilePath);

        /// <summary>
        /// 006D01D0
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate FileEntry* Native_GetNextFileEntry(CriFileSystem* fileTable);

        /// <summary>
        /// 006D00D0
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate FileEntry* Native_LoadADXFromFileTable(string fullFilePath);

        /// <summary>
        /// 006CFBA0
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate CriFileSystem* Native_MaybeConstructor(string directoryPath, int a2NormallyMinusOne, char* a3NormallyZero, int a4NormallyZero);

        /// <summary>
        /// 006CF9D0
        /// </summary>
        [Reloaded.Hooks.Definitions.X64.Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int Native_ProbablyResetFileTable();
    }
}