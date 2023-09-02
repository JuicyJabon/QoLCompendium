using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    public class LuckInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().metallicClover && ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor)
        {
            Player localPlayer = Main.LocalPlayer;
            return localPlayer.luck + " Luck";
        }
    }
}
