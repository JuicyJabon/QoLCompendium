using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    public class SentryInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().headCounter && ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor)
        {
            Player localPlayer = Main.LocalPlayer;
            UIElementsAndLayers.GetSentryNameToCount(out int num, true);
            return num.ToString() + " / " + localPlayer.maxTurrets.ToString() + " Sentry Slots";
        }
    }
}
