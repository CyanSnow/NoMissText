using HarmonyLib;
using NoMissText.UI;

namespace NoMissText
{
    [HarmonyPatch(typeof(ComboUIController), "HandleComboBreakingEventHappened")]
    class ComboUIControllerHandleComboBreakingEventHappened
    {
        static bool Prefix()
        {
            if (NoMissTextConfig.Instance.HideDumbFCBreakLines)
                return false;
            return true;
        }
    }
}