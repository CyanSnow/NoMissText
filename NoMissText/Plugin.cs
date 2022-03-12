using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;
using BeatSaberMarkupLanguage.GameplaySetup;
using NoMissText.UI;
using System;

namespace NoMissText
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        public const string HarmonyId = "com.CyanSnow.BeatSaber.NoMissText";
        internal static Harmony harmony = new Harmony(HarmonyId);

        internal static Plugin instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        public void Init(IPALogger logger, Config config)
        {
            instance = this;
            Log = logger;
            Log.Info("No Miss Text initialized.");
            NoMissTextConfig.Instance = config.Generated<NoMissTextConfig>();
            Log.Debug("Logger initialized.");
        }

        [OnEnable]
        public void OnEnable()
        {
            try
            {
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                Log.Debug("Applying Harmony pathces.");
            }
            catch (Exception ex)
            {
                Log.Critical("Error applying Harmony patches: " + ex.Message);
                Log.Debug(ex);
            }

            GameplaySetup.instance.AddTab("No Miss Text", "NoMissText.UI.settings.bsml", NoMissTextUI.instance);
        }

        [OnDisable]
        public void OnDisable()
        {
            //harmony.UnpatchAll("com.CyanSnow.BeatSaber.NoMissText");

            harmony.UnpatchSelf();
            GameplaySetup.instance.RemoveTab("No Miss Text");
        }
    }
}