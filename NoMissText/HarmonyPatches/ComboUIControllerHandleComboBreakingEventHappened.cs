using HarmonyLib;
using IPA.Utilities;
using NoMissText.UI;

namespace NoMissText
{
    [HarmonyPatch(typeof(ComboUIController), "HandleComboBreakingEventHappened")]
    class HandleComboBreakingEventHappened
    {
        static bool Prefix(ComboUIController __instance)
        {
            if (NoMissTextConfig.Instance.HideDumbFCBreakLines)
            {
                if (!__instance.GetField<bool, ComboUIController>("_fullComboLost"))
                {
                    __instance.SetField("_fullComboLost", true);
                    __instance.transform.Find("Line0").gameObject.SetActive(false);
                    __instance.transform.Find("Line1").gameObject.SetActive(false);
                }
                return false;
            }
            return true;
        }
    }
}