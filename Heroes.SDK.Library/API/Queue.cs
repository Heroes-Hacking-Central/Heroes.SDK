using System;
using System.Collections.Concurrent;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Queue of arbitrary code, <see cref="Action"/>(s) to execute.
    /// All action(s) are executed synchronously at the end of each frame, before sleeping to wait for the next frame.
    /// This function should be used when you run modify data at risk of being
    /// accessed the same time as it is modified, e.g. reloading a file/asset used every frame.
    ///
    /// Note: All action(s) are executed only once. For actions that are executed every time, consider <see cref="Event"/>.
    /// </summary>
    public static class Queue
    {
        /// <summary>
        /// The to be executed.
        /// </summary>
        private static ConcurrentQueue<Action> Actions { get; } = new ConcurrentQueue<Action>();

        static Queue()
        {
            Event.OnSleep += OnSleep;
        }

        /// <summary>
        /// Adds a function to be executed the next time the game proceeds to sleep before next frame.
        /// </summary>
        /// <param name="action">The code to be executed in the queue.</param>
        public static void Add(Action action)
        {
            Actions.Enqueue(action);
        }

        private static void OnSleep()
        {
            while (Actions.TryDequeue(out Action item))
                item();
        }
    }
}
