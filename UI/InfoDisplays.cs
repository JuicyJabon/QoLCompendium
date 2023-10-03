using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Social.WeGame;

namespace QoLCompendium.UI
{
    public class RegenInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().regenerator && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().replenisher && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().metallicClover && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().headCounter && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().trackingDevice && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().battalionLog && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().wingTimer && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().reinforcedPanel && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().kettlebell && QoLCompendium.itemConfig.InformationAccessories;
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
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().harmInducer && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            DamageClass damageType = Main.LocalPlayer.HeldItem.DamageType;
            StatModifier totalDamage = Main.LocalPlayer.GetTotalDamage(damageType);

            if (damageType == DamageClass.Magic)
            {
                return Math.Round(totalDamage.Additive, 3).ToString() + "x Magic Damage";
            }
            else if (damageType == DamageClass.Melee)
            {
                return Math.Round(totalDamage.Additive, 3).ToString() + "x Melee Damage";
            }
            else if (damageType == DamageClass.MeleeNoSpeed)
            {
                return Math.Round(totalDamage.Additive, 3).ToString() + "x Melee Damage";
            }
            else if (damageType == DamageClass.Ranged)
            {
                return Math.Round(totalDamage.Additive, 3).ToString() + "x Ranged Damage";
            }
            else if (damageType == DamageClass.Summon)
            {
                return Math.Round(totalDamage.Additive, 3).ToString() + "x Summon Damage";
            }
            else if (damageType == DamageClass.SummonMeleeSpeed)
            {
                return Math.Round(totalDamage.Additive, 3).ToString() + "x Summon Damage";
            }
            else
            {
                
                return Math.Round(totalDamage.Additive, 3).ToString() + "x Damage";
            }
        }
    }

    public class CritInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().luckyDie && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return "+" +Main.LocalPlayer.GetCritChance(DamageClass.Generic).ToString() + "% Crit";
        }
    }

    public class ArmorPenetrationInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().plateCracker && QoLCompendium.itemConfig.InformationAccessories;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return Main.LocalPlayer.GetArmorPenetration(DamageClass.Generic).ToString() + " Armor Penetration";
        }
    }
}
