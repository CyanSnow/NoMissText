using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace NoMissText
{
    [Plugin(RuntimeOptions.SingleStartInit)]
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

        [OnStart]
        public void OnStart()
        {
            harmony = new Harmony("com.CyanSnow.BeatSaber.NoMissText");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnExit]
        public void OnExit()
        {
            harmony.UnpatchAll("com.CyanSnow.BeatSaber.NoMissText");
        }
    }
}