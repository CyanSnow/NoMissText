using HarmonyLib;
using NoMissText.UI;

namespace NoMissText
{
    [HarmonyPatch(typeof(FlyingSpriteSpawner), "SpawnFlyingSprite")]
    class MissedNoteEffectSpawnerSpawnFlyingSprite
    {
        private static bool Prefix()
        {
            if (NoMissTextConfig.Instance.HideMissText)
                return false;
            return true;
        }
    }
}