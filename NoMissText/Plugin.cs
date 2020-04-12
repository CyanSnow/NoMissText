using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

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
            PluginConfig.Instance = config.Generated<PluginConfig>();
            Logger.Log("Config loaded");
        }

        [OnEnable]
        public void OnEnable()
        {
            harmony = new Harmony("com.CyanSnow.BeatSaber.NoMissText");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            harmony.UnpatchAll("com.CyanSnow.BeatSaber.NoMissText");
        }
    }
}