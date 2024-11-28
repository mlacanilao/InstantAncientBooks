using BepInEx;
using HarmonyLib;

namespace InstantAncientBooks
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.instantancientbooks";
        internal const string Name = "Instant Ancient Books";
        internal const string Version = "1.0.0.0";
    }

    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class InstantAncientBooks : BaseUnityPlugin
    {
        internal static InstantAncientBooks Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            InstantAncientBooksConfig.LoadConfig(Config);
            var harmony = new Harmony(id: ModInfo.Guid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(TraitBaseSpellbook), nameof(TraitBaseSpellbook.GetActDuration))]
    internal static class InstantAncientBooksPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(TraitBaseSpellbook __instance, Chara c, ref int __result)
        {
            if (InstantAncientBooksConfig.EnableInstantAncientBooks?.Value == true &&
                __instance is TraitAncientbook &&
                __instance.BookType == TraitBaseSpellbook.Type.Ancient)
            {
                __result = InstantAncientBooksConfig.DurationValue?.Value ?? 1;
                return false;
            }

            return true;
        }
    }
}