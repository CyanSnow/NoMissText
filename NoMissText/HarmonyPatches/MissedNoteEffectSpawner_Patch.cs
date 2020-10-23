using HarmonyLib;
using NoMissText.UI;

namespace NoMissText
{
    [HarmonyPatch(typeof(FlyingSpriteSpawner))]
    [HarmonyPatch("SpawnFlyingSprite")]
    class MissedNoteEffectSpawner_Patch
    {
        private static bool Prefix()
        {
            if (NoMissTextConfig.Instance.HideMissText)
                return false;
            return true;
        }
    }
}