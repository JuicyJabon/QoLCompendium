using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using System;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    public class MinionInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().headCounter;
        }

        public override string DisplayValue(ref Color displayColor)
        {
            Player localPlayer = Main.LocalPlayer;
            return Math.Round((double)localPlayer.slotsMinions, 2).ToString() + " / " + localPlayer.maxMinions.ToString() + " Minion Slots";
        }
    }
}
