namespace QoLCompendium.Core.UI.Other
{
    public class RegenInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/RegenInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().regenerator;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float lifeRegen = Main.LocalPlayer.lifeRegen;
            lifeRegen *= 0.5f;
            lifeRegen = (float)Math.Round(lifeRegen, 2);

            if (Main.LocalPlayer.statLife >= Main.LocalPlayer.statLifeMax2)
                return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.FullHealth");
            else
                return lifeRegen + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.Regeneration");
        }
    }

    public class ManaRegenInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/ManaRegenInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().replenisher;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            if (Main.LocalPlayer.statMana >= Main.LocalPlayer.statManaMax2)
                return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.FullMana");
            else
                return Main.LocalPlayer.manaRegen / 2f + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.ManaRegeneration");
        }
    }

    public class LuckInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/LuckInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().metallicClover;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return Math.Round(Main.LocalPlayer.luck, 3) + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.Luck");
        }
    }

    public class SpawnInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/SpawnInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().headCounter;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            int spawnRateRaw = Main.LocalPlayer.GetModPlayer<QoLCPlayer>().spawnRate;

            if (spawnRateRaw == 0)
                return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.SpawnsDisabled");
            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().noSpawns)
                return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.SpawnsDisabled");

            float spawnRateAdapted = 60f / spawnRateRaw;
            spawnRateAdapted = (float)Math.Round(spawnRateAdapted, 2);

            return spawnRateAdapted + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.SpawnRate");
        }
    }

    public class MinionInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/MinionInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().trackingDevice;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return Math.Round(Main.LocalPlayer.slotsMinions, 2).ToString() + "/" + Main.LocalPlayer.maxMinions.ToString() + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.MinionSlots");
        }
    }

    public class SentryInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/SentryInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().battalionLog;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            UIElementsAndLayers.GetSentryNameToCount(out int num, true);
            return num.ToString() + "/" + Main.LocalPlayer.maxTurrets.ToString() + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.SentrySlots");
        }
    }

    public class WingTimeInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/WingTimeInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().wingTimer;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float num = Main.LocalPlayer.wingTime / 60f;

            /*
            for (int i = 3; i < Main.LocalPlayer.armor.Length; i++)
            {
                if (Main.LocalPlayer.armor[i].netID == ItemID.EmpressFlightBooster && !CrossModSupport.Calamity.Loaded)
                {
                    if (i < 13)
                    {
                        return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.InfiniteWingTime");
                    }
                }
            }
            */

            if (Main.LocalPlayer.empressBrooch && !CrossModSupport.Calamity.Loaded)
                return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.InfiniteWingTime");

            return num.ToString("0.00") + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.WingTime");
        }
    }

    public class EnduranceInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/EnduranceInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().reinforcedPanel;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return (100f * Main.LocalPlayer.endurance).ToString("N0") + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.Endurance");
        }
    }

    public class MiningSpeedInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/MiningSpeedInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().kettlebell;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return ((1f - Main.LocalPlayer.pickSpeed) * 100f).ToString("N0") + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.MiningSpeed");
        }
    }

    public class DamageInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/DamageInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().harmInducer;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float damageStat = Main.LocalPlayer.GetModPlayer<InfoPlayer>().damageStat;
            return damageStat.ToString("N2") + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.DamageMultiplier");
        }
    }

    public class CritInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/CritInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().luckyDie;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float critChanceStat = Main.LocalPlayer.GetModPlayer<InfoPlayer>().critChanceStat;
            return critChanceStat + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.CriticalStrikeChance");
        }
    }

    public class ArmorPenetrationInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/ArmorPenetrationInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().plateCracker;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            float armorPenetrationStat = Main.LocalPlayer.GetModPlayer<InfoPlayer>().armorPenetrationStat;
            return armorPenetrationStat + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.ArmorPenetration");
        }
    }

    public class DeathsInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/DeathsInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().skullWatch;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            return Main.LocalPlayer.numberOfDeathsPVE + Main.LocalPlayer.numberOfDeathsPVP + " " + Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.DeathCount");
        }
    }

    public class DebuffDamageInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/DebuffDamageInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().deteriorationDisplay;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            int dps = GetDPS(Main.myPlayer);

            if (dps > 0)
            {
                return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.DDPS", dps);
            }

            displayColor = InactiveInfoTextColor;
            return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.NoDPS");
        }

        private static int GetDPS(int player)
        {
            double dps = 0.0;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.lifeRegen < 0 && npc.playerInteraction[player])
                {
                    dps -= npc.lifeRegen / 2.0;
                }
            }
            return (int)dps;
        }
    }

    public class QuestFishInfoDisplay : InfoDisplay
    {
        public override string Texture => "QoLCompendium/Assets/InfoDisplayIcons/QuestFishInfoDisplay";

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<InfoPlayer>().anglerRadar;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            if (Main.anglerQuestFinished || Main.anglerQuest == -1 || Main.anglerQuest >= Main.anglerQuestItemNetIDs.Length || !NPC.AnyNPCs(NPCID.Angler))
            {
                displayColor = InactiveInfoTextColor;
                return Language.GetTextValue("Mods.QoLCompendium.InfoDisplayText.QuestFinished");
            }
            return Lang.GetItemNameValue(Main.anglerQuestItemNetIDs[Main.anglerQuest]);
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

        //EXTRA
        public bool anglerRadar = false;
        public bool deteriorationDisplay = false;
        public bool skullWatch = false;

        public float armorPenetrationStat;
        public float critChanceStat;
        public float damageStat;

        private List<string> classString = new() { "Automatic" };
        public int classIndex;

        public override void ResetEffects() => Reset();

        public override void UpdateDead() => Reset();

        public override void Initialize()
        {
            for (int i = 1; i < DamageClassLoader.DamageClassCount; i++)
            {
                string[] array = $"{DamageClassLoader.GetDamageClass(i)}".Split(".");
                classString.Add(array[^1].Replace("DamageClass", "") + (array[0] != "Terraria" ? "(" + array[0] + ")" : ""));
            }
        }

        public override void PostUpdate()
        {
            armorPenetrationStat = Player.GetArmorPenetration(DamageClass.Generic);
            critChanceStat = Player.GetCritChance(DamageClass.Generic);
            damageStat = Player.GetDamage(DamageClass.Generic).ApplyTo(1f);
            if (classIndex == 0 || classIndex != 1)
            {
                int num = classIndex == 0 ? Player.HeldItem.DamageType.Type : classIndex;
                num -= num == 3 || num == 7 ? 1 : 0;
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

            //EXTRA
            anglerRadar = false;
            deteriorationDisplay = false;
            skullWatch = false;
        }
    }
}
