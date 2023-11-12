using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    public class RegenInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().regenerator && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float lifeRegen = Main.LocalPlayer.lifeRegen;
            lifeRegen *= 0.5f;
            lifeRegen = (float)Math.Round(lifeRegen, 2);

            if (Main.LocalPlayer.statLife >= Main.LocalPlayer.statLifeMax2)
            {
                return "Full Health";
            }
            else
            {
                return lifeRegen + " Regen/Sec";
            }
        }
    }

    public class ManaRegenInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().replenisher && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            if (Main.LocalPlayer.statMana >= Main.LocalPlayer.statManaMax2)
            {
                return "Full Mana";
            }
            else
            {
                return (Main.LocalPlayer.manaRegen / 2f) + " Mana Regen/Sec";
            }
        }
    }

    public class LuckInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().metallicClover && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return Math.Round(Main.LocalPlayer.luck, 3) + " Luck";
        }
    }

    public class SpawnInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().headCounter && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
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

    public class MinionInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().trackingDevice && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return Math.Round(Main.LocalPlayer.slotsMinions, 2).ToString() + " / " + Main.LocalPlayer.maxMinions.ToString() + " Minion Slots";
        }
    }

    public class SentryInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().battalionLog && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            UIElementsAndLayers.GetSentryNameToCount(out int num, true);
            return num.ToString() + " / " + Main.LocalPlayer.maxTurrets.ToString() + " Sentry Slots";
        }
    }

    public class WingTimeInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().wingTimer && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float num = Main.LocalPlayer.wingTime / 60f;

            for (int i = 3; i < Main.LocalPlayer.armor.Length; i++)
            {
                if (Main.LocalPlayer.armor[i].netID == ItemID.EmpressFlightBooster && !ModConditions.calamityLoaded)
                {
                    if (i < 13)
                    {
                        return "Infinite Wing Time";
                    }
                }
            }

            return num.ToString("0.00") + "s Wing Time";
        }
    }

    public class EnduranceInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().reinforcedPanel && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return (100f * Main.LocalPlayer.endurance).ToString("N0") + "% Endurance";
        }
    }

    public class MiningSpeedInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().kettlebell && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return ((1f - Main.LocalPlayer.pickSpeed) * 100f).ToString("N0") + "% Mining Speed";
        }
    }

    public class DamageInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().harmInducer && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float damageStat = Main.LocalPlayer.GetModPlayer<InfoPlayer>().damageStat;
            return damageStat.ToString("N2") + "x Damage";
        }
    }

    public class CritInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().luckyDie && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float critChanceStat = Main.LocalPlayer.GetModPlayer<InfoPlayer>().critChanceStat;
            return $"{critChanceStat}% Critical Strike Chance";
        }
    }

    public class ArmorPenetrationInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().plateCracker && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float armorPenetrationStat = Main.LocalPlayer.GetModPlayer<InfoPlayer>().armorPenetrationStat;
            return $"{armorPenetrationStat} Armor Penetration";
        }
    }


    public class InfoPlayer : ModPlayer
    {
        public bool battalionLog = false;
        public bool harmInducer = false;
        public bool headCounter = false;
        public bool kettlebell = false;
        public bool luckyDie = false;
        public bool metallicClover = false;
        public bool plateCracker = false;
        public bool regenerator = false;
        public bool reinforcedPanel = false;
        public bool replenisher = false;
        public bool trackingDevice = false;
        public bool wingTimer = false;

        public float armorPenetrationStat;
        public float critChanceStat;
        public float damageStat;

        private List<string> classString = new() { "Automatic" };
        public int classIndex;

        public override void ResetEffects()
        {
            Reset();
        }

        public override void UpdateDead()
        {
            Reset();
        }

        public override void Initialize()
        {
            for (int i = 1; i < DamageClassLoader.DamageClassCount; i++)
            {
                string[] array = $"{DamageClassLoader.GetDamageClass(i)}".Split(".");
                classString.Add(array[^1].Replace("DamageClass", "") + ((array[0] != "Terraria") ? ("(" + array[0] + ")") : ""));
            }
        }

        public override void PostUpdate()
        {
            armorPenetrationStat = Player.GetArmorPenetration(DamageClass.Generic);
            critChanceStat = Player.GetCritChance(DamageClass.Generic);
            damageStat = Player.GetDamage(DamageClass.Generic).ApplyTo(1f);
            if (classIndex == 0 || classIndex != 1)
            {
                int num = ((classIndex == 0) ? Player.HeldItem.DamageType.Type : classIndex);
                num -= ((num == 3 || num == 7) ? 1 : 0);
                damageStat += Player.GetDamage(DamageClassLoader.GetDamageClass(num)).ApplyTo(1f) - 1f;
                critChanceStat += Player.GetCritChance(DamageClassLoader.GetDamageClass(num));
                armorPenetrationStat += Player.GetArmorPenetration(DamageClassLoader.GetDamageClass(num));
            }
        }

        public void Reset()
        {
            battalionLog = false;
            harmInducer = false;
            headCounter = false;
            kettlebell = false;
            luckyDie = false;
            metallicClover = false;
            plateCracker = false;
            regenerator = false;
            reinforcedPanel = false;
            replenisher = false;
            trackingDevice = false;
            wingTimer = false;
        }
    }
}
