using Heroes.SDK.Definitions.Structures.Criware.FileSystem;
using Reloaded.Hooks.Definitions;
using System;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Classes.NativeClasses
{
    /// <summary>
    /// Note: The CRI Filesystem is actually C code, but it was built in an object oriented-like way.
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
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
        public static IFunction<Native_AddFileToFileTable> Fun_AddFileToFileTable { get; } = SDK.ReloadedHooks.CreateFunction<Native_AddFileToFileTable>(0x006CFF40);
        public static IFunction<Native_CreateFromDirectory> Fun_CreateFromDirectory { get; } = SDK.ReloadedHooks.CreateFunction<Native_CreateFromDirectory>(0x006C8000);
        public static IFunction<Native_SetFileTablePointer> Fun_SetFileTablePointer { get; } = SDK.ReloadedHooks.CreateFunction<Native_SetFileTablePointer>(0x006D6310);
        public static IFunction<Native_SetTablePointersAndBuild> Fun_SetTablePointersAndBuild { get; } = SDK.ReloadedHooks.CreateFunction<Native_SetTablePointersAndBuild>(0x006CFE70);
        public static IFunction<Native_BuildFileTable> Fun_BuildFileTable { get; } = SDK.ReloadedHooks.CreateFunction<Native_BuildFileTable>(0x006D63B0);
        public static IFunction<Native_CallsBuildFileTable> Fun_CallsBuildFileTable { get; } = SDK.ReloadedHooks.CreateFunction<Native_CallsBuildFileTable>(0x006D6330);
        public static IFunction<Native_GetDvdrootFullPath> Fun_GetDvdrootFullPath { get; } = SDK.ReloadedHooks.CreateFunction<Native_GetDvdrootFullPath>(0x006B4040);
        public static IFunction<Native_GetFileEntryCount> Fun_GetFileEntryCount { get; } = SDK.ReloadedHooks.CreateFunction<Native_GetFileEntryCount>(0x006CEFE0);
        public static IFunction<Native_GetFileEntryFromFilePath> Fun_GetFileEntryFromFilePath { get; } = SDK.ReloadedHooks.CreateFunction<Native_GetFileEntryFromFilePath>(0x006D00F0);
        public static IFunction<Native_GetNextFileEntry> Fun_GetNextFileEntry { get; } = SDK.ReloadedHooks.CreateFunction<Native_GetNextFileEntry>(0x006D01D0);
        public static IFunction<Native_LoadADXFromFileTable> Fun_LoadADXFromFileTable { get; } = SDK.ReloadedHooks.CreateFunction<Native_LoadADXFromFileTable>(0x006D00D0);
        public static IFunction<Native_MaybeConstructor> Fun_MaybeConstructor { get; } = SDK.ReloadedHooks.CreateFunction<Native_MaybeConstructor>(0x006CFBA0);
        public static IFunction<Native_ProbablyResetFileTable> Fun_ProbablyResetFileTable { get; } = SDK.ReloadedHooks.CreateFunction<Native_ProbablyResetFileTable>(0x006CF9D0);

        /* Method Definitions */

        /// <summary>
        /// 0x006C8000
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate CriFileSystem* Native_CreateFromDirectory(char* directoryPath, int a2NormallyMinusOne, int a3NormallyZero, int a4NormallyZero);

        /// <summary>
        /// 0x006D6310
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int Native_SetFileTablePointer(IntPtr newFunctionPointer, CriFileSystem* fileTablePointer);

        /// <summary>
        /// 0x006CFE70
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate CriFileSystem* Native_SetTablePointersAndBuild(CriFileSystem* fileTablePointer);

        /// <summary>
        /// 006CFF40
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int Native_AddFileToFileTable(NewFileInfoTuple* filePath, CriFileSystem* fileTable);

        /// <summary>
        /// 006D63B0
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int Native_BuildFileTable(string folderPath, int decrementsOnNewDirectory, int* a3);

        /// <summary>
        /// 006D6330
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int Native_CallsBuildFileTable(char* a1, int a2, int* a3);

        /// <summary>
        /// 006B4040
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate char* Native_GetDvdrootFullPath(CriFileSystem* fileTable);

        /// <summary>
        /// 006CEFE0
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int Native_GetFileEntryCount(CriFileSystem* fileTable);

        /// <summary>
        /// 006D00F0
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate FileEntry* Native_GetFileEntryFromFilePath(string fullFilePath);

        /// <summary>
        /// 006D01D0
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate FileEntry* Native_GetNextFileEntry(CriFileSystem* fileTable);

        /// <summary>
        /// 006D00D0
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate FileEntry* Native_LoadADXFromFileTable(string fullFilePath);

        /// <summary>
        /// 006CFBA0
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate CriFileSystem* Native_MaybeConstructor(string directoryPath, int a2NormallyMinusOne, char* a3NormallyZero, int a4NormallyZero);

        /// <summary>
        /// 006CF9D0
        /// </summary>
        [global::Reloaded.Hooks.Definitions.X64.Function(global::Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [global::Reloaded.Hooks.Definitions.X86.Function(global::Reloaded.Hooks.Definitions.X86.CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int Native_ProbablyResetFileTable();
    }
}