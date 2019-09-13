using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Reloaded.Memory.Kernel32;
using Reloaded.Memory.Sources;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Controls the window in which the game is drawn.
    /// </summary>
    public static class Window
    {
        /// <summary>
        /// The class associated with the Sonic Heroes window.
        /// </summary>
        public const string WindowClass = "SonicHeroesPC-RW3.5";

        private static IntPtr _cachedWindowHandle;
        private static Process _currentProcess = Process.GetCurrentProcess();

        /// <summary>
        /// Retrieves the handle of the game window based off of the class of the window.
        /// </summary>
        public static IntPtr WindowHandle
        {
            get
            {
                if (IsWindow(_cachedWindowHandle))
                    return _cachedWindowHandle;

                _cachedWindowHandle = FindWindow(WindowClass, null);
                return _cachedWindowHandle;
            }
        }

        /// <summary>
        /// Returns true if any of the windows belonging to the game process are in focus.
        /// </summary>
        public static bool IsAnyWindowActivated()
        {
            IntPtr activatedHandle = GetForegroundWindow();

            if (activatedHandle == IntPtr.Zero)
                return false;

            GetWindowThreadProcessId(activatedHandle, out int activeProcessId);
            return activeProcessId == _currentProcess.Id;
        }

        /* Windows API Imports */
        #region MyRegion
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        #endregion
    }
}
