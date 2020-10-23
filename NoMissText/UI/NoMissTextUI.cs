namespace NoMissText.UI
{
    using BeatSaberMarkupLanguage.Attributes;
    internal class NoMissTextUI : PersistentSingleton<NoMissTextUI>
    {
        [UIValue("hidemisstext")]
        public bool HideMissText
        {
            get => NoMissTextConfig.Instance.HideMissText;
            set => NoMissTextConfig.Instance.HideMissText = value;
        }
    }
}