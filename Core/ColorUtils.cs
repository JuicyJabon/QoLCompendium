namespace QoLCompendium.Core
{
    public static class ColorUtils
    {
        public static Color ColorSwap(Color firstColor, Color secondColor, float seconds)
        {
            float num = (float)((Math.Sin(Math.PI * 2.0 / (double)seconds * Main.GlobalTimeWrappedHourly) + 1.0) * 0.5);
            return Color.Lerp(firstColor, secondColor, num);
        }
    }
}
