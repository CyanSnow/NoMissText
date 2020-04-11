using HarmonyLib;

namespace NoMissText
{
    [HarmonyPatch(typeof(FlyingSpriteSpawner))]
    [HarmonyPatch("SpawnFlyingSprite")]
    class MissedNoteEffectSpawner_Patch
    {
        private static bool Prefix()
        {
            bool dataModel = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.playerSpecificSettings.noTextsAndHuds;
            if (PluginConfig.Instance.NoTextAnywhere || dataModel)
                return false;
            return true;
        }
    }
}