using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using System;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    public class SpawnInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().headCounter && ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor)
        {
            int spawnRateRaw = Main.LocalPlayer.GetModPlayer<QoLCPlayer>().spawnRate;

            if (spawnRateRaw == 0)
            {
                return "Spawns Disabled";
            }

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().enemyEraser)
            {
                return "Spawns Disabled";
            }

            float spawnRateAdapted = 60f / spawnRateRaw;
            spawnRateAdapted = (float)Math.Round(spawnRateAdapted, 2);

            return spawnRateAdapted + " Spawns/Sec";
        }
    }

    public class LuckInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().metallicClover && ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor)
        {
            Player localPlayer = Main.LocalPlayer;
            return Math.Round(localPlayer.luck, 3)  + " Luck";
        }
    }

    public class MinionInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().trackingDevice && ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor)
        {
            Player localPlayer = Main.LocalPlayer;
            return Math.Round(localPlayer.slotsMinions, 2).ToString() + " / " + localPlayer.maxMinions.ToString() + " Minion Slots";
        }
    }

    public class SentryInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().battalionLog && ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor)
        {
            Player localPlayer = Main.LocalPlayer;
            UIElementsAndLayers.GetSentryNameToCount(out int num, true);
            return num.ToString() + " / " + localPlayer.maxTurrets.ToString() + " Sentry Slots";
        }
    }
}
