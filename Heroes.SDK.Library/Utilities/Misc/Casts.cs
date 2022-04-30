using System.Runtime.CompilerServices;

namespace Heroes.SDK.Utilities.Misc
{
    public static class Casts
    {
        /// <summary>
        /// Reinterprets a certain unmanaged type as another unmanaged type.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TResult ReinterpretCast<TOriginal, TResult>(this TOriginal original)
            where TOriginal : unmanaged
            where TResult : unmanaged
        {
            return *(TResult*)(void*)&original;
        }
    }
}
