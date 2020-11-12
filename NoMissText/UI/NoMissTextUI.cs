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
        [UIValue("hidedumbfcbreaklines")]
        public bool HideDumbFCBreakLines
        {
            get => NoMissTextConfig.Instance.HideDumbFCBreakLines;
            set => NoMissTextConfig.Instance.HideDumbFCBreakLines = value;
        }
    }
}