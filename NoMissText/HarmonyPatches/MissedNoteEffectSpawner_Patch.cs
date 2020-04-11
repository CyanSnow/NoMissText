using HarmonyLib;
using System.Linq;

namespace NoMissText
{
    [HarmonyPatch(typeof(FlyingSpriteSpawner))]
    [HarmonyPatch("SpawnFlyingSprite")]
    class MissedNoteEffectSpawner_Patch
    {
        private static bool Prefix()
        {
            if (PluginConfig.Instance.NoTextAnywhere)
                return false;
            else
            {
                PlayerDataModel dataModel = UnityEngine.Resources.FindObjectsOfTypeAll<PlayerDataModel>().FirstOrDefault();
                if ((dataModel?.playerData.playerSpecificSettings.noTextsAndHuds ?? false))
                {
                    return false;
                }
            }
            return true;
        }
    }
}