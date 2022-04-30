using Heroes.SDK.Classes.PseudoNativeClasses;
using Reloaded.Hooks.Definitions;
using System;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Allows for receiving events, either from in-game or arbitrary ones like keyboard presses.
    /// </summary>
    public static class Event
    {
        private static event Action _onSleep;
        private static event Action _afterSleep;


        /// <summary>
        /// Executed after rendering a frame right before the game is about to sleep for frame pacing purposes.
        /// </summary>
        public static event Action OnSleep
        {
            add
            {
                if (_endFrameHook == null)
                    _endFrameHook = RenderFunctions.Fun_EndFrame.Hook(OnEndFrame).Activate();

                _onSleep += value;
            }
            remove => _onSleep -= value;
        }

        /// <summary>
        /// Executed after rendering a frame and sleeping for frame pacing purposes.
        /// </summary>
        public static event Action AfterSleep
        {
            add
            {
                if (_endFrameHook == null)
                    _endFrameHook = RenderFunctions.Fun_EndFrame.Hook(OnEndFrame).Activate();

                _afterSleep += value;
            }
            remove => _afterSleep -= value;
        }

        /* Hooks */
        private static IHook<RenderFunctions.EndFrame> _endFrameHook;

        /* Hook Bodies */
        private static int OnEndFrame()
        {
            _onSleep?.Invoke();
            var returnValue = _endFrameHook.OriginalFunction();
            _afterSleep?.Invoke();

            return returnValue;
        }
    }
}
