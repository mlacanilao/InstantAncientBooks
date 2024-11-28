using BepInEx.Configuration;

namespace InstantAncientBooks
{
    internal static class InstantAncientBooksConfig
    {
        internal static ConfigEntry<bool> EnableInstantAncientBooks;
        internal static ConfigEntry<int> DurationValue;

        /// <summary>
        /// Loads all configurations for the InstantAncientBooks mod.
        /// </summary>
        /// <param name="config">The BepInEx ConfigFile to bind configurations to.</param>
        internal static void LoadConfig(ConfigFile config)
        {
            EnableInstantAncientBooks = config.Bind(
                section: ModInfo.Name,
                key: "Enable Instant Ancient Books",
                defaultValue: true,
                description: "Enable or disable the Instant Ancient Books mod.\n" +
                             "インスタント古代の本MODを有効または無効にします。");

            DurationValue = config.Bind(
                section: ModInfo.Name,
                key: "Duration Value",
                defaultValue: 1,
                description: "Set the duration value for decoding ancient books.\n" +
                             "古代の本の解読時間を設定します。");
        }
    }
}