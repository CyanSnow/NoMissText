using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;
using BeatSaberMarkupLanguage.GameplaySetup;
using NoMissText.UI;

namespace NoMissText
{
    [Plugin(RuntimeOptions.DynamicInit)]
    internal class Plugin
    {
        internal static Harmony harmony;

        [Init]
        public Plugin(IPALogger pluginLogger, Config config)
        {
            Logger.logger = pluginLogger;
            NoMissTextConfig.Instance = config.Generated<NoMissTextConfig>();
        }

        [OnEnable]
        public void OnEnable()
        {
            harmony = new Harmony("com.CyanSnow.BeatSaber.NoMissText");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            GameplaySetup.instance.AddTab("No Miss Text", "NoMissText.UI.settings.bsml", NoMissTextUI.instance);
        }

        [OnDisable]
        public void OnDisable()
        {
            harmony.UnpatchAll("com.CyanSnow.BeatSaber.NoMissText");
            GameplaySetup.instance.RemoveTab("No Miss Text");
        }
    }
}