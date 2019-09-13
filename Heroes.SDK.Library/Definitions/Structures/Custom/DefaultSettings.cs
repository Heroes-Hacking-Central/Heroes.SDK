using Heroes.SDK.Definitions.Enums;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.Definitions.Structures.Custom
{
    public unsafe struct DefaultSettings
    {
        public ref bool Fog => ref RefPointer<bool>.Create((bool*) 0x008CAEB8);
        public ref bool FullScreen => ref RefPointer<bool>.Create((bool*) 0x008CAEDC);

        /// <summary>
        /// Note: Language is overwritten by the language stored in the game save.
        /// This only affects language until a save file is loaded.
        /// </summary>
        public ref Language Language => ref RefPointer<Language>.Create((Language*) 0x008CAEE1);

        /// <summary>
        /// Range 0 - 100.
        /// </summary>
        public ref byte SfxVolume => ref RefPointer<byte>.Create((byte*) 0x008CAEE2);

        /// <summary>
        /// Range 0 - 100.
        /// </summary>
        public ref byte BgmVolume => ref RefPointer<byte>.Create((byte*) 0x008CAEE3);

        public ref bool SurroundSound => ref RefPointer<bool>.Create((bool*) 0x008CAEE4);
        public ref bool SfxOn => ref RefPointer<bool>.Create((bool*) 0x008CAEE8);
        public ref bool BgmOn => ref RefPointer<bool>.Create((bool*) 0x008CAEEC);
        
        /// <summary>
        /// If enabled, all shadows become circles as opposed to more complex silhouettes of the characters.
        /// </summary>
        public ref bool CheapShadow => ref RefPointer<bool>.Create((bool*) 0x008CAEF0);

        /// <summary>
        /// Toggles the different mouse control modes from the original launcher.
        /// </summary>
        public ref int  MouseControl => ref RefPointer<int>.Create((int*) 0x008CAEF4);

        /// <summary>
        /// Disables character speech.
        /// </summary>
        public ref bool CharmyShutup => ref RefPointer<bool>.Create((bool*) 0x008CAEF8);
    }
}