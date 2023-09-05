using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class DontConsumeConsolariaSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.consolariaLoaded && 
                CheckDowned.consolariaMod.TryFind("SuspiciousLookingEgg", out ModItem SuspiciousLookingEgg)
                && CheckDowned.consolariaMod.TryFind("CursedStuffing", out ModItem CursedStuffing)
                && CheckDowned.consolariaMod.TryFind("SuspiciousLookingSkull", out ModItem SuspiciousLookingSkull)
                && CheckDowned.consolariaMod.TryFind("Wishbone", out ModItem Wishbone) 
                && (entity.type == SuspiciousLookingEgg.Type 
                || entity.type == CursedStuffing.Type 
                || entity.type == SuspiciousLookingSkull.Type 
                || entity.type == Wishbone.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeFargosSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.fargosSoulsLoaded &&
                CheckDowned.fargosSoulsMod.TryFind("SquirrelCoatofArms", out ModItem SquirrelCoatofArms)
                && CheckDowned.fargosSoulsMod.TryFind("DevisCurse", out ModItem DevisCurse)
                && CheckDowned.fargosSoulsMod.TryFind("FragilePixieLamp", out ModItem FragilePixieLamp)
                && CheckDowned.fargosSoulsMod.TryFind("AbomsCurse", out ModItem AbomsCurse)
                && CheckDowned.fargosSoulsMod.TryFind("MutantsCurse", out ModItem MutantsCurse)
                && (entity.type == SquirrelCoatofArms.Type
                || entity.type == DevisCurse.Type
                || entity.type == FragilePixieLamp.Type
                || entity.type == AbomsCurse.Type
                || entity.type == MutantsCurse.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeGMRSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.gmrLoaded &&
                CheckDowned.gmrMod.TryFind("JackDroneOld", out ModItem JackDroneOld)
                && entity.type == JackDroneOld.Type && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeHomewardSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.homewardLoaded &&
                CheckDowned.homewardMod.TryFind("CannedSoulofFlight", out ModItem CannedSoulofFlight)
                && CheckDowned.homewardMod.TryFind("SouthernPotting", out ModItem SouthernPotting)
                && CheckDowned.homewardMod.TryFind("SunlightCrown", out ModItem SunlightCrown)
                && CheckDowned.homewardMod.TryFind("MetalSpine", out ModItem MetalSpine)
                && CheckDowned.homewardMod.TryFind("UnstableGlobe", out ModItem UnstableGlobe)
                && CheckDowned.homewardMod.TryFind("UltimateTorch", out ModItem UltimateTorch)
                && (entity.type == CannedSoulofFlight.Type
                || entity.type == SouthernPotting.Type
                || entity.type == SunlightCrown.Type
                || entity.type == MetalSpine.Type
                || entity.type == UnstableGlobe.Type
                || entity.type == UltimateTorch.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeQwertySummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.qwertyLoaded &&
                CheckDowned.qwertyMod.TryFind("AncientEmblem", out ModItem AncientEmblem)
                && CheckDowned.qwertyMod.TryFind("B4Summon", out ModItem B4Summon)
                && CheckDowned.qwertyMod.TryFind("BladeBossSummon", out ModItem BladeBossSummon)
                && CheckDowned.qwertyMod.TryFind("DinoEgg", out ModItem DinoEgg)
                && CheckDowned.qwertyMod.TryFind("FortressBossSummon", out ModItem FortressBossSummon)
                && CheckDowned.qwertyMod.TryFind("GodSealKeycard", out ModItem GodSealKeycard)
                && CheckDowned.qwertyMod.TryFind("HydraSummon", out ModItem HydraSummon)
                && CheckDowned.qwertyMod.TryFind("RitualInterupter", out ModItem RitualInterupter)
                && CheckDowned.qwertyMod.TryFind("SummoningRune", out ModItem SummoningRune)
                && (entity.type == AncientEmblem.Type
                || entity.type == B4Summon.Type
                || entity.type == BladeBossSummon.Type
                || entity.type == DinoEgg.Type
                || entity.type == FortressBossSummon.Type
                || entity.type == GodSealKeycard.Type
                || entity.type == HydraSummon.Type
                || entity.type == RitualInterupter.Type
                || entity.type == SummoningRune.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeSOTSSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.sotsLoaded &&
                CheckDowned.sotsMod.TryFind("ElectromagneticLure", out ModItem ElectromagneticLure)
                && CheckDowned.sotsMod.TryFind("SuspiciousLookingCandle", out ModItem SuspiciousLookingCandle)
                && CheckDowned.sotsMod.TryFind("JarOfPeanuts", out ModItem JarOfPeanuts)
                && CheckDowned.sotsMod.TryFind("CatalystBomb", out ModItem CatalystBomb)
                && (entity.type == ElectromagneticLure.Type
                || entity.type == SuspiciousLookingCandle.Type
                || entity.type == JarOfPeanuts.Type
                || entity.type == CatalystBomb.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeSpiritSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.spiritLoaded &&
                CheckDowned.spiritMod.TryFind("DistressJellyItem", out ModItem DistressJellyItem)
                && CheckDowned.spiritMod.TryFind("GladeWreath", out ModItem GladeWreath)
                && CheckDowned.spiritMod.TryFind("ReachBossSummon", out ModItem ReachBossSummon)
                && CheckDowned.spiritMod.TryFind("JewelCrown", out ModItem JewelCrown)
                && CheckDowned.spiritMod.TryFind("BlackPearl", out ModItem BlackPearl)
                && CheckDowned.spiritMod.TryFind("BlueMoonSpawn", out ModItem BlueMoonSpawn)
                && CheckDowned.spiritMod.TryFind("DuskCrown", out ModItem DuskCrown)
                && CheckDowned.spiritMod.TryFind("CursedCloth", out ModItem CursedCloth)
                && CheckDowned.spiritMod.TryFind("StoneSkin", out ModItem StoneSkin)
                && CheckDowned.spiritMod.TryFind("MartianTransmitter", out ModItem MartianTransmitter)
                && (entity.type == DistressJellyItem.Type
                || entity.type == GladeWreath.Type
                || entity.type == ReachBossSummon.Type
                || entity.type == JewelCrown.Type
                || entity.type == BlackPearl.Type
                || entity.type == BlueMoonSpawn.Type
                || entity.type == DuskCrown.Type
                || entity.type == CursedCloth.Type
                || entity.type == StoneSkin.Type
                || entity.type == MartianTransmitter.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeSpookySummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.spookyLoaded &&
                CheckDowned.spookyMod.TryFind("RottenSeed", out ModItem RottenSeed)
                && CheckDowned.spookyMod.TryFind("Fertalizer", out ModItem Fertalizer)
                && (entity.type == RottenSeed.Type
                || entity.type == Fertalizer.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeStormSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.stormLoaded &&
                CheckDowned.stormMod.TryFind("AridBossSummon", out ModItem AridBossSummon)
                && CheckDowned.stormMod.TryFind("MoonlingSummoner", out ModItem MoonlingSummoner)
                && CheckDowned.stormMod.TryFind("StormBossSummoner", out ModItem StormBossSummoner)
                && CheckDowned.stormMod.TryFind("UltimateBossSummoner", out ModItem UltimateBossSummoner)
                && (entity.type == AridBossSummon.Type
                || entity.type == MoonlingSummoner.Type
                || entity.type == StormBossSummoner.Type
                || entity.type == UltimateBossSummoner.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeThoriumSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.thoriumLoaded &&
                CheckDowned.thoriumMod.TryFind("StormFlare", out ModItem StormFlare)
                && CheckDowned.thoriumMod.TryFind("JellyfishResonator", out ModItem JellyfishResonator)
                && CheckDowned.thoriumMod.TryFind("UnstableCore", out ModItem UnstableCore)
                && CheckDowned.thoriumMod.TryFind("AncientBlade", out ModItem AncientBlade)
                && CheckDowned.thoriumMod.TryFind("StarCaller", out ModItem StarCaller)
                && CheckDowned.thoriumMod.TryFind("StriderTear", out ModItem StriderTear)
                && CheckDowned.thoriumMod.TryFind("VoidLens", out ModItem VoidLens)
                && CheckDowned.thoriumMod.TryFind("AromaticBulb", out ModItem AromaticBulb)
                && CheckDowned.thoriumMod.TryFind("AbyssalShadow2", out ModItem AbyssalShadow2)
                && CheckDowned.thoriumMod.TryFind("DoomSayersCoin", out ModItem DoomSayersCoin)
                && (entity.type == StormFlare.Type
                || entity.type == JellyfishResonator.Type
                || entity.type == UnstableCore.Type
                || entity.type == AncientBlade.Type
                || entity.type == StarCaller.Type
                || entity.type == StriderTear.Type
                || entity.type == VoidLens.Type
                || entity.type == AromaticBulb.Type
                || entity.type == AbyssalShadow2.Type
                || entity.type == DoomSayersCoin.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeVitalitySummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return CheckDowned.vitalityLoaded &&
                CheckDowned.vitalityMod.TryFind("CloudCore", out ModItem CloudCore)
                && CheckDowned.vitalityMod.TryFind("AncientCrown", out ModItem AncientCrown)
                && CheckDowned.vitalityMod.TryFind("MultigemCluster", out ModItem MultigemCluster)
                && CheckDowned.vitalityMod.TryFind("MoonlightLotusFlower", out ModItem MoonlightLotusFlower)
                && CheckDowned.vitalityMod.TryFind("Dreadcandle", out ModItem Dreadcandle)
                && CheckDowned.vitalityMod.TryFind("AnarchyCrystal", out ModItem AnarchyCrystal)
                && CheckDowned.vitalityMod.TryFind("TotemofChaos", out ModItem TotemofChaos)
                && CheckDowned.vitalityMod.TryFind("SpiritBox", out ModItem SpiritBox)
                && (entity.type == CloudCore.Type
                || entity.type == AncientCrown.Type
                || entity.type == MultigemCluster.Type
                || entity.type == MoonlightLotusFlower.Type
                || entity.type == Dreadcandle.Type
                || entity.type == AnarchyCrystal.Type
                || entity.type == TotemofChaos.Type
                || entity.type == SpiritBox.Type) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class DontConsumeBossSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return (entity.type == ItemID.SlimeCrown || entity.type == ItemID.SuspiciousLookingEye 
                || entity.type == ItemID.WormFood || entity.type == ItemID.BloodySpine
                || entity.type == ItemID.Abeemination || entity.type == ItemID.DeerThing
                || entity.type == ItemID.QueenSlimeCrystal || entity.type == ItemID.MechanicalWorm
                || entity.type == ItemID.MechanicalEye || entity.type == ItemID.MechanicalSkull
                || entity.type == ItemID.LihzahrdPowerCell || entity.type == ItemID.CelestialSigil 
                || entity.type == ItemID.BloodMoonStarter || entity.type == ItemID.GoblinBattleStandard
                || entity.type == ItemID.PirateMap || entity.type == ItemID.SolarTablet
                || entity.type == ItemID.SnowGlobe || entity.type == ItemID.PumpkinMoonMedallion
                || entity.type == ItemID.NaughtyPresent) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips[1].Text != "Equipped in social slot")
            {
                tooltips[1].Text = tooltips[1].Text + "\nNot Consumable";
            }
        }
    }

    public class OtherItemStuff : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<QoLCConfig>().NoDevs && ItemID.Sets.BossBag[item.type])
            {
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;
            }

            if (ModContent.GetInstance<QoLCConfig>().IncreaseMaxStack)
            {
                if (item.maxStack > 10 && (item.maxStack != 100) && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
                {
                    item.maxStack = 9999;
                }
            }
        }

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (ModContent.GetInstance<QoLCConfig>().FastExtractor)
            {
                Main.LocalPlayer.itemAnimation = 1;
                Main.LocalPlayer.itemTime = 1;
                Main.LocalPlayer.itemTimeMax = 1;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0)
                return 1f - ModContent.GetInstance<QoLCConfig>().FastTools;
            return 1f;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.consumable == true && item.stack >= ModContent.GetInstance<QoLCConfig>().EndlessAmount && ModContent.GetInstance<QoLCConfig>().EndlessConsumables)
            {
                return false;
            }

            return base.ConsumeItem(item, player);
        }

        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            if (ammo.ammo > 0 && ammo.stack >= ModContent.GetInstance<QoLCConfig>().EndlessAmount && ModContent.GetInstance<QoLCConfig>().EndlessAmmo)
            {
                return false;
            }
            return base.CanBeConsumedAsAmmo(ammo, weapon, player);
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= ModContent.GetInstance<QoLCConfig>().EndlessAmount && ModContent.GetInstance<QoLCConfig>().EndlessBait)
            {
                return false;
            }
            return base.CanConsumeBait(player, bait);
        }
    }
}
