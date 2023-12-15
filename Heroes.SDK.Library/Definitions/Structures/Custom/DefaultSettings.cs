using Heroes.SDK.Definitions.Enums;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.Definitions.Structures.Custom
{
    public unsafe struct DefaultSettings
    {
        public ref bool Fog => ref new Ptr<bool>((bool*)0x008CAEB8).AsRef();
        public ref bool FullScreen => ref new Ptr<bool>((bool*)0x008CAEDC).AsRef();
        
        /// <summary>
        /// Hardcoded resolution.
        /// </summary>
        public ref byte ScreenSize => ref new Ptr<byte>((byte*)0x008CAEE0).AsRef();
        
        /// <summary>
        /// Note: Language is overwritten by the language stored in the game save.
        /// This only affects language until a save file is loaded.
        /// </summary>
        public ref Language Language => ref new Ptr<Language>((Language*)0x008CAEE1).AsRef();

        /// <summary>
        /// Range 0 - 100.
        /// </summary>
        public ref byte SfxVolume => ref new Ptr<byte>((byte*)0x008CAEE2).AsRef();

        /// <summary>
        /// Range 0 - 100.
        /// </summary>
        public ref byte BgmVolume => ref new Ptr<byte>((byte*)0x008CAEE3).AsRef();

        public ref bool SurroundSound => ref new Ptr<bool>((bool*)0x008CAEE4).AsRef();
        public ref bool SfxOn => ref new Ptr<bool>((bool*)0x008CAEE8).AsRef();
        public ref bool BgmOn => ref new Ptr<bool>((bool*)0x008CAEEC).AsRef();

        /// <summary>
        /// If enabled, all shadows become circles as opposed to more complex silhouettes of the characters.
        /// </summary>
        public ref bool CheapShadow => ref new Ptr<bool>((bool*)0x008CAEF0).AsRef();

        /// <summary>
        /// Toggles the different mouse control modes from the original launcher.
        /// </summary>
        public ref int MouseControl => ref new Ptr<int>((int*)0x008CAEF4).AsRef();

        /// <summary>
        /// Disables character speech.
        /// </summary>
        public ref bool CharmyShutup => ref new Ptr<bool>((bool*)0x008CAEF8).AsRef();
    }
}