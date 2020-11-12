namespace NoMissText.UI
{
    public class NoMissTextConfig
    {
        public static NoMissTextConfig Instance { get; set; }

        public bool HideMissText { get; set; } = true;

        public bool HideDumbFCBreakLines { get; set; } = true;
    }
}