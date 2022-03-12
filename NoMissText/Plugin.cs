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
            harmony = new Harmony("com.CyanSnow.BeatSaber.NoMissText");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
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