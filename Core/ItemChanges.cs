using QoLCompendium.Content.Items.Dedicated;
using Terraria.GameContent.Creative;

namespace QoLCompendium.Core
{
    public class DontConsumeAequusSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.aequusLoaded &&
                ModConditions.aequusMod.TryFind("GalacticStarfruit", out ModItem GalacticStarfruit)
                && (entity.type == GalacticStarfruit.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeAFKPetsSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.afkpetsLoaded &&
                ModConditions.afkpetsMod.TryFind("AncientSand", out ModItem AncientSand)
                && ModConditions.afkpetsMod.TryFind("BlackenedHeart", out ModItem BlackenedHeart)
                && ModConditions.afkpetsMod.TryFind("BrokenDelftPlate", out ModItem BrokenDelftPlate)
                && ModConditions.afkpetsMod.TryFind("CookingBook", out ModItem CookingBook)
                && ModConditions.afkpetsMod.TryFind("CorruptedServer", out ModItem CorruptedServer)
                && ModConditions.afkpetsMod.TryFind("DemonicAnalysis", out ModItem DemonicAnalysis)
                && ModConditions.afkpetsMod.TryFind("DesertMirror", out ModItem DesertMirror)
                && ModConditions.afkpetsMod.TryFind("DuckWhistle", out ModItem DuckWhistle)
                && ModConditions.afkpetsMod.TryFind("FallingSlimeReplica", out ModItem FallingSlimeReplica)
                && ModConditions.afkpetsMod.TryFind("FrozenSkull", out ModItem FrozenSkull)
                && ModConditions.afkpetsMod.TryFind("GoldenKingSlimeIdol", out ModItem GoldenKingSlimeIdol)
                && ModConditions.afkpetsMod.TryFind("GoldenSkull", out ModItem GoldenSkull)
                && ModConditions.afkpetsMod.TryFind("HaniwaIdol", out ModItem HaniwaIdol)
                && ModConditions.afkpetsMod.TryFind("HolographicSlimeReplica", out ModItem HolographicSlimeReplica)
                && ModConditions.afkpetsMod.TryFind("IceBossCrystal", out ModItem IceBossCrystal)
                && ModConditions.afkpetsMod.TryFind("MagicWand", out ModItem MagicWand)
                && ModConditions.afkpetsMod.TryFind("NightmareFuel", out ModItem NightmareFuel)
                && ModConditions.afkpetsMod.TryFind("PinkDiamond", out ModItem PinkDiamond)
                && ModConditions.afkpetsMod.TryFind("PlantAshContainer", out ModItem PlantAshContainer)
                && ModConditions.afkpetsMod.TryFind("PreyTrackingChip", out ModItem PreyTrackingChip)
                && ModConditions.afkpetsMod.TryFind("RoastChickenPlate", out ModItem RoastChickenPlate)
                && ModConditions.afkpetsMod.TryFind("SeveredClothierHead", out ModItem SeveredClothierHead)
                && ModConditions.afkpetsMod.TryFind("SeveredDryadHead", out ModItem SeveredDryadHead)
                && ModConditions.afkpetsMod.TryFind("SeveredHarpyHead", out ModItem SeveredHarpyHead)
                && ModConditions.afkpetsMod.TryFind("ShogunSlimesHelmet", out ModItem ShogunSlimesHelmet)
                && ModConditions.afkpetsMod.TryFind("SlimeinaGlassCube", out ModItem SlimeinaGlassCube)
                && ModConditions.afkpetsMod.TryFind("SlimyWarBanner", out ModItem SlimyWarBanner)
                && ModConditions.afkpetsMod.TryFind("SoulofAgonyinaBottle", out ModItem SoulofAgonyinaBottle)
                && ModConditions.afkpetsMod.TryFind("SpineWormFood", out ModItem SpineWormFood)
                && ModConditions.afkpetsMod.TryFind("SpiritofFunPot", out ModItem SpiritofFunPot)
                && ModConditions.afkpetsMod.TryFind("SpiritualHeart", out ModItem SpiritualHeart)
                && ModConditions.afkpetsMod.TryFind("StoryBook", out ModItem StoryBook)
                && ModConditions.afkpetsMod.TryFind("SuspiciousLookingChest", out ModItem SuspiciousLookingChest)
                && ModConditions.afkpetsMod.TryFind("SwissChocolate", out ModItem SwissChocolate)
                && ModConditions.afkpetsMod.TryFind("TiedBunny", out ModItem TiedBunny)
                && ModConditions.afkpetsMod.TryFind("TinyMeatIdol", out ModItem TinyMeatIdol)
                && ModConditions.afkpetsMod.TryFind("TradeDeal", out ModItem TradeDeal)
                && ModConditions.afkpetsMod.TryFind("UnstableRainbowCookie", out ModItem UnstableRainbowCookie)
                && ModConditions.afkpetsMod.TryFind("UntoldBurial", out ModItem UntoldBurial)
                && (entity.type == AncientSand.Type
                || entity.type == BlackenedHeart.Type
                || entity.type == BrokenDelftPlate.Type
                || entity.type == CookingBook.Type
                || entity.type == CorruptedServer.Type
                || entity.type == DemonicAnalysis.Type
                || entity.type == DesertMirror.Type
                || entity.type == DuckWhistle.Type
                || entity.type == FallingSlimeReplica.Type
                || entity.type == FrozenSkull.Type
                || entity.type == GoldenKingSlimeIdol.Type
                || entity.type == GoldenSkull.Type
                || entity.type == HaniwaIdol.Type
                || entity.type == HolographicSlimeReplica.Type
                || entity.type == IceBossCrystal.Type
                || entity.type == MagicWand.Type
                || entity.type == NightmareFuel.Type
                || entity.type == PinkDiamond.Type
                || entity.type == PlantAshContainer.Type
                || entity.type == PreyTrackingChip.Type
                || entity.type == RoastChickenPlate.Type
                || entity.type == SeveredClothierHead.Type
                || entity.type == SeveredDryadHead.Type
                || entity.type == SeveredHarpyHead.Type
                || entity.type == ShogunSlimesHelmet.Type
                || entity.type == SlimeinaGlassCube.Type
                || entity.type == SlimyWarBanner.Type
                || entity.type == SoulofAgonyinaBottle.Type
                || entity.type == SpineWormFood.Type
                || entity.type == SpiritofFunPot.Type
                || entity.type == SpiritualHeart.Type
                || entity.type == StoryBook.Type
                || entity.type == SuspiciousLookingChest.Type
                || entity.type == SwissChocolate.Type
                || entity.type == TiedBunny.Type
                || entity.type == TinyMeatIdol.Type
                || entity.type == TradeDeal.Type
                || entity.type == UnstableRainbowCookie.Type
                || entity.type == UntoldBurial.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeAwfulGarbageSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.awfulGarbageLoaded &&
                ModConditions.awfulGarbageMod.TryFind("InsectOnAStick", out ModItem InsectOnAStick)
                && ModConditions.awfulGarbageMod.TryFind("PileOfFakeBones", out ModItem PileOfFakeBones)
                && (entity.type == InsectOnAStick.Type
                || entity.type == PileOfFakeBones.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeBlocksCoreBossSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.blocksCoreBossLoaded &&
                ModConditions.blocksCoreBossMod.TryFind("ChargedOrb", out ModItem ChargedOrb)
                && ModConditions.blocksCoreBossMod.TryFind("ChargedOrbCrim", out ModItem ChargedOrbCrim)
                && (entity.type == ChargedOrb.Type
                || entity.type == ChargedOrbCrim.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeConsolariaSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.consolariaLoaded &&
                ModConditions.consolariaMod.TryFind("SuspiciousLookingEgg", out ModItem SuspiciousLookingEgg)
                && ModConditions.consolariaMod.TryFind("CursedStuffing", out ModItem CursedStuffing)
                && ModConditions.consolariaMod.TryFind("SuspiciousLookingSkull", out ModItem SuspiciousLookingSkull)
                && ModConditions.consolariaMod.TryFind("Wishbone", out ModItem Wishbone)
                && (entity.type == SuspiciousLookingEgg.Type
                || entity.type == CursedStuffing.Type
                || entity.type == SuspiciousLookingSkull.Type
                || entity.type == Wishbone.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeEdorbisSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.edorbisLoaded &&
                ModConditions.edorbisMod.TryFind("BiomechanicalMatter", out ModItem BiomechanicalMatter)
                && ModConditions.edorbisMod.TryFind("CursedSoul", out ModItem CursedSoul)
                && ModConditions.edorbisMod.TryFind("KelviniteRadar", out ModItem KelviniteRadar)
                && ModConditions.edorbisMod.TryFind("SlayerTrophy", out ModItem SlayerTrophy)
                && ModConditions.edorbisMod.TryFind("ThePrettiestFlower", out ModItem ThePrettiestFlower)
                && (entity.type == BiomechanicalMatter.Type
                || entity.type == CursedSoul.Type
                || entity.type == KelviniteRadar.Type
                || entity.type == SlayerTrophy.Type
                || entity.type == ThePrettiestFlower.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeEnchantedMoonSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.enchantedMoonsLoaded &&
                ModConditions.enchantedMoonsMod.TryFind("BlueMedallion", out ModItem BlueMedallion)
                && ModConditions.enchantedMoonsMod.TryFind("CherryAmulet", out ModItem CherryAmulet)
                && ModConditions.enchantedMoonsMod.TryFind("HarvestLantern", out ModItem HarvestLantern)
                && ModConditions.enchantedMoonsMod.TryFind("MintRing", out ModItem MintRing)
                && (entity.type == BlueMedallion.Type
                || entity.type == CherryAmulet.Type
                || entity.type == HarvestLantern.Type
                || entity.type == MintRing.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeExxoAvalonOriginsSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.exxoAvalonOriginsLoaded &&
                ModConditions.exxoAvalonOriginsMod.TryFind("BloodyAmulet", out ModItem BloodyAmulet)
                && ModConditions.exxoAvalonOriginsMod.TryFind("InfestedCarcass", out ModItem InfestedCarcass)
                && ModConditions.exxoAvalonOriginsMod.TryFind("DesertHorn", out ModItem DesertHorn)
                && ModConditions.exxoAvalonOriginsMod.TryFind("GoblinRetreatOrder", out ModItem GoblinRetreatOrder)
                && ModConditions.exxoAvalonOriginsMod.TryFind("FalseTreasureMap", out ModItem FalseTreasureMap)
                && ModConditions.exxoAvalonOriginsMod.TryFind("OddFertilizer", out ModItem OddFertilizer)
                && (entity.type == BloodyAmulet.Type
                || entity.type == InfestedCarcass.Type
                || entity.type == DesertHorn.Type
                || entity.type == GoblinRetreatOrder.Type
                || entity.type == FalseTreasureMap.Type
                || entity.type == OddFertilizer.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeFargosMutantSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.fargosMutantLoaded &&
                ModConditions.fargosMutantMod.TryFind("Abeemination2", out ModItem Abeemination2)
                && ModConditions.fargosMutantMod.TryFind("CelestialSigil2", out ModItem CelestialSigil2)
                && ModConditions.fargosMutantMod.TryFind("DeerThing2", out ModItem DeerThing2)
                && ModConditions.fargosMutantMod.TryFind("GoreySpine", out ModItem GoreySpine)
                && ModConditions.fargosMutantMod.TryFind("MechEye", out ModItem MechEye)
                && ModConditions.fargosMutantMod.TryFind("MechSkull", out ModItem MechSkull)
                && ModConditions.fargosMutantMod.TryFind("MechWorm", out ModItem MechWorm)
                && ModConditions.fargosMutantMod.TryFind("SlimyCrown", out ModItem SlimyCrown)
                && ModConditions.fargosMutantMod.TryFind("SuspiciousEye", out ModItem SuspiciousEye)
                && ModConditions.fargosMutantMod.TryFind("TruffleWorm2", out ModItem TruffleWorm2)
                && ModConditions.fargosMutantMod.TryFind("WormyFood", out ModItem WormyFood)
                && ModConditions.fargosMutantMod.TryFind("Anemometer", out ModItem Anemometer)
                && ModConditions.fargosMutantMod.TryFind("BatteredClub", out ModItem BatteredClub)
                && ModConditions.fargosMutantMod.TryFind("BetsyEgg", out ModItem BetsyEgg)
                && ModConditions.fargosMutantMod.TryFind("FestiveOrnament", out ModItem FestiveOrnament)
                && ModConditions.fargosMutantMod.TryFind("ForbiddenScarab", out ModItem ForbiddenScarab)
                && ModConditions.fargosMutantMod.TryFind("ForbiddenTome", out ModItem ForbiddenTome)
                && ModConditions.fargosMutantMod.TryFind("HeadofMan", out ModItem HeadofMan)
                && ModConditions.fargosMutantMod.TryFind("IceKingsRemains", out ModItem IceKingsRemains)
                && ModConditions.fargosMutantMod.TryFind("MartianMemoryStick", out ModItem MartianMemoryStick)
                && ModConditions.fargosMutantMod.TryFind("MatsuriLantern", out ModItem MatsuriLantern)
                && ModConditions.fargosMutantMod.TryFind("NaughtyList", out ModItem NaughtyList)
                && ModConditions.fargosMutantMod.TryFind("PartyCone", out ModItem PartyCone)
                && ModConditions.fargosMutantMod.TryFind("PillarSummon", out ModItem PillarSummon)
                && ModConditions.fargosMutantMod.TryFind("RunawayProbe", out ModItem RunawayProbe)
                && ModConditions.fargosMutantMod.TryFind("SlimyBarometer", out ModItem SlimyBarometer)
                && ModConditions.fargosMutantMod.TryFind("SpentLantern", out ModItem SpentLantern)
                && ModConditions.fargosMutantMod.TryFind("SpookyBranch", out ModItem SpookyBranch)
                && ModConditions.fargosMutantMod.TryFind("SuspiciousLookingScythe", out ModItem SuspiciousLookingScythe)
                && ModConditions.fargosMutantMod.TryFind("WeatherBalloon", out ModItem WeatherBalloon)
                && ModConditions.fargosMutantMod.TryFind("AmalgamatedSkull", out ModItem AmalgamatedSkull)
                && ModConditions.fargosMutantMod.TryFind("AmalgamatedSpirit", out ModItem AmalgamatedSpirit)
                && ModConditions.fargosMutantMod.TryFind("AthenianIdol", out ModItem AthenianIdol)
                && ModConditions.fargosMutantMod.TryFind("AttractiveOre", out ModItem AttractiveOre)
                && ModConditions.fargosMutantMod.TryFind("BloodSushiPlatter", out ModItem BloodSushiPlatter)
                && ModConditions.fargosMutantMod.TryFind("BloodUrchin", out ModItem BloodUrchin)
                && ModConditions.fargosMutantMod.TryFind("CloudSnack", out ModItem CloudSnack)
                && ModConditions.fargosMutantMod.TryFind("ClownLicense", out ModItem ClownLicense)
                && ModConditions.fargosMutantMod.TryFind("CoreoftheFrostCore", out ModItem CoreoftheFrostCore)
                && ModConditions.fargosMutantMod.TryFind("CorruptChest", out ModItem CorruptChest)
                && ModConditions.fargosMutantMod.TryFind("CrimsonChest", out ModItem CrimsonChest)
                && ModConditions.fargosMutantMod.TryFind("DemonicPlushie", out ModItem DemonicPlushie)
                && ModConditions.fargosMutantMod.TryFind("DilutedRainbowMatter", out ModItem DilutedRainbowMatter)
                && ModConditions.fargosMutantMod.TryFind("Eggplant", out ModItem Eggplant)
                && ModConditions.fargosMutantMod.TryFind("ForbiddenForbiddenFragment", out ModItem ForbiddenForbiddenFragment)
                && ModConditions.fargosMutantMod.TryFind("GnomeHat", out ModItem GnomeHat)
                && ModConditions.fargosMutantMod.TryFind("GoblinScrap", out ModItem GoblinScrap)
                && ModConditions.fargosMutantMod.TryFind("GoldenSlimeCrown", out ModItem GoldenSlimeCrown)
                && ModConditions.fargosMutantMod.TryFind("GrandCross", out ModItem GrandCross)
                && ModConditions.fargosMutantMod.TryFind("HallowChest", out ModItem HallowChest)
                && ModConditions.fargosMutantMod.TryFind("HeartChocolate", out ModItem HeartChocolate)
                && ModConditions.fargosMutantMod.TryFind("HemoclawCrab", out ModItem HemoclawCrab)
                && ModConditions.fargosMutantMod.TryFind("HolyGrail", out ModItem HolyGrail)
                && ModConditions.fargosMutantMod.TryFind("JungleChest", out ModItem JungleChest)
                && ModConditions.fargosMutantMod.TryFind("LeesHeadband", out ModItem LeesHeadband)
                && ModConditions.fargosMutantMod.TryFind("MothLamp", out ModItem MothLamp)
                && ModConditions.fargosMutantMod.TryFind("MothronEgg", out ModItem MothronEgg)
                && ModConditions.fargosMutantMod.TryFind("Pincushion", out ModItem Pincushion)
                && ModConditions.fargosMutantMod.TryFind("PinkSlimeCrown", out ModItem PinkSlimeCrown)
                && ModConditions.fargosMutantMod.TryFind("PirateFlag", out ModItem PirateFlag)
                && ModConditions.fargosMutantMod.TryFind("PlunderedBooty", out ModItem PlunderedBooty)
                && ModConditions.fargosMutantMod.TryFind("RuneOrb", out ModItem RuneOrb)
                && ModConditions.fargosMutantMod.TryFind("ShadowflameIcon", out ModItem ShadowflameIcon)
                && ModConditions.fargosMutantMod.TryFind("SlimyLockBox", out ModItem SlimyLockBox)
                && ModConditions.fargosMutantMod.TryFind("SuspiciousLookingChest", out ModItem SuspiciousLookingChest)
                && ModConditions.fargosMutantMod.TryFind("SuspiciousLookingLure", out ModItem SuspiciousLookingLure)
                && ModConditions.fargosMutantMod.TryFind("WormSnack", out ModItem WormSnack)
                && ModConditions.fargosMutantMod.TryFind("AncientSeal", out ModItem AncientSeal)
                && ModConditions.fargosMutantMod.TryFind("CultistSummon", out ModItem CultistSummon)
                && ModConditions.fargosMutantMod.TryFind("DeathBringerFairy", out ModItem DeathBringerFairy)
                && ModConditions.fargosMutantMod.TryFind("FleshyDoll", out ModItem FleshyDoll)
                && ModConditions.fargosMutantMod.TryFind("JellyCrystal", out ModItem JellyCrystal)
                && ModConditions.fargosMutantMod.TryFind("MechanicalAmalgam", out ModItem MechanicalAmalgam)
                && ModConditions.fargosMutantMod.TryFind("MutantVoodoo", out ModItem MutantVoodoo)
                && ModConditions.fargosMutantMod.TryFind("PlanterasFruit", out ModItem PlanterasFruit)
                && ModConditions.fargosMutantMod.TryFind("PrismaticPrimrose", out ModItem PrismaticPrimrose)
                && ModConditions.fargosMutantMod.TryFind("SuspiciousSkull", out ModItem SuspiciousSkull)
                && (entity.type == Abeemination2.Type
                || entity.type == CelestialSigil2.Type
                || entity.type == DeerThing2.Type
                || entity.type == GoreySpine.Type
                || entity.type == MechEye.Type
                || entity.type == MechSkull.Type
                || entity.type == MechWorm.Type
                || entity.type == SlimyCrown.Type
                || entity.type == SuspiciousEye.Type
                || entity.type == TruffleWorm2.Type
                || entity.type == WormyFood.Type
                || entity.type == Anemometer.Type
                || entity.type == BatteredClub.Type
                || entity.type == BetsyEgg.Type
                || entity.type == FestiveOrnament.Type
                || entity.type == ForbiddenScarab.Type
                || entity.type == ForbiddenTome.Type
                || entity.type == HeadofMan.Type
                || entity.type == IceKingsRemains.Type
                || entity.type == MartianMemoryStick.Type
                || entity.type == MatsuriLantern.Type
                || entity.type == NaughtyList.Type
                || entity.type == PartyCone.Type
                || entity.type == PillarSummon.Type
                || entity.type == RunawayProbe.Type
                || entity.type == SlimyBarometer.Type
                || entity.type == SpentLantern.Type
                || entity.type == SpookyBranch.Type
                || entity.type == SuspiciousLookingScythe.Type
                || entity.type == WeatherBalloon.Type
                || entity.type == AmalgamatedSkull.Type
                || entity.type == AmalgamatedSpirit.Type
                || entity.type == AthenianIdol.Type
                || entity.type == AttractiveOre.Type
                || entity.type == BloodSushiPlatter.Type
                || entity.type == BloodUrchin.Type
                || entity.type == CloudSnack.Type
                || entity.type == ClownLicense.Type
                || entity.type == CoreoftheFrostCore.Type
                || entity.type == CorruptChest.Type
                || entity.type == CrimsonChest.Type
                || entity.type == DemonicPlushie.Type
                || entity.type == DilutedRainbowMatter.Type
                || entity.type == Eggplant.Type
                || entity.type == ForbiddenForbiddenFragment.Type
                || entity.type == GnomeHat.Type
                || entity.type == GoblinScrap.Type
                || entity.type == GoldenSlimeCrown.Type
                || entity.type == GrandCross.Type
                || entity.type == HallowChest.Type
                || entity.type == HeartChocolate.Type
                || entity.type == HemoclawCrab.Type
                || entity.type == HolyGrail.Type
                || entity.type == JungleChest.Type
                || entity.type == LeesHeadband.Type
                || entity.type == MothLamp.Type
                || entity.type == MothronEgg.Type
                || entity.type == Pincushion.Type
                || entity.type == PinkSlimeCrown.Type
                || entity.type == PirateFlag.Type
                || entity.type == PlunderedBooty.Type
                || entity.type == RuneOrb.Type
                || entity.type == ShadowflameIcon.Type
                || entity.type == SlimyLockBox.Type
                || entity.type == SuspiciousLookingChest.Type
                || entity.type == SuspiciousLookingLure.Type
                || entity.type == WormSnack.Type
                || entity.type == AncientSeal.Type
                || entity.type == CultistSummon.Type
                || entity.type == DeathBringerFairy.Type
                || entity.type == FleshyDoll.Type
                || entity.type == JellyCrystal.Type
                || entity.type == MechanicalAmalgam.Type
                || entity.type == MutantVoodoo.Type
                || entity.type == PlanterasFruit.Type
                || entity.type == PrismaticPrimrose.Type
                || entity.type == SuspiciousSkull.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeFargosSoulsSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.fargosSoulsLoaded &&
                ModConditions.fargosSoulsMod.TryFind("SquirrelCoatofArms", out ModItem SquirrelCoatofArms)
                && ModConditions.fargosSoulsMod.TryFind("DevisCurse", out ModItem DevisCurse)
                && ModConditions.fargosSoulsMod.TryFind("MechLure", out ModItem MechLure)
                && ModConditions.fargosSoulsMod.TryFind("FragilePixieLamp", out ModItem FragilePixieLamp)
                && ModConditions.fargosSoulsMod.TryFind("ChampionySigil", out ModItem ChampionySigil)
                && ModConditions.fargosSoulsMod.TryFind("AbomsCurse", out ModItem AbomsCurse)
                && ModConditions.fargosSoulsMod.TryFind("MutantsCurse", out ModItem MutantsCurse)
                && (entity.type == SquirrelCoatofArms.Type
                || entity.type == DevisCurse.Type
                || entity.type == MechLure.Type
                || entity.type == FragilePixieLamp.Type
                || entity.type == ChampionySigil.Type
                || entity.type == AbomsCurse.Type
                || entity.type == MutantsCurse.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeFargosSoulsDLCSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.fargosSoulsDLCLoaded &&
                ModConditions.fargosSoulsDLCMod.TryFind("PandorasBox", out ModItem PandorasBox)
                && entity.type == PandorasBox.Type && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeGensokyoSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.gensokyoLoaded &&
                ModConditions.gensokyoMod.TryFind("AliceMargatroidSpawner", out ModItem AliceMargatroidSpawner)
                && ModConditions.gensokyoMod.TryFind("CirnoSpawner", out ModItem CirnoSpawner)
                && ModConditions.gensokyoMod.TryFind("EternityLarvaSpawner", out ModItem EternityLarvaSpawner)
                && ModConditions.gensokyoMod.TryFind("HinaKagiyamaSpawner", out ModItem HinaKagiyamaSpawner)
                && ModConditions.gensokyoMod.TryFind("KaguyaHouraisanSpawner", out ModItem KaguyaHouraisanSpawner)
                && ModConditions.gensokyoMod.TryFind("LilyWhiteSpawner", out ModItem LilyWhiteSpawner)
                && ModConditions.gensokyoMod.TryFind("MayumiJoutouguuSpawner", out ModItem MayumiJoutouguuSpawner)
                && ModConditions.gensokyoMod.TryFind("MedicineMelancholySpawner", out ModItem MedicineMelancholySpawner)
                && ModConditions.gensokyoMod.TryFind("MinamitsuMurasaSpawner", out ModItem MinamitsuMurasaSpawner)
                && ModConditions.gensokyoMod.TryFind("NazrinSpawner", out ModItem NazrinSpawner)
                && ModConditions.gensokyoMod.TryFind("NitoriKawashiroSpawner", out ModItem NitoriKawashiroSpawner)
                && ModConditions.gensokyoMod.TryFind("RumiaSpawner", out ModItem RumiaSpawner)
                && ModConditions.gensokyoMod.TryFind("SakuyaIzayoiSpawner", out ModItem SakuyaIzayoiSpawner)
                && ModConditions.gensokyoMod.TryFind("SeijaKijinSpawner", out ModItem SeijaKijinSpawner)
                && ModConditions.gensokyoMod.TryFind("SeiranSpawner", out ModItem SeiranSpawner)
                && ModConditions.gensokyoMod.TryFind("SekibankiSpawner", out ModItem SekibankiSpawner)
                && ModConditions.gensokyoMod.TryFind("TenshiHinanawiSpawner", out ModItem TenshiHinanawiSpawner)
                && ModConditions.gensokyoMod.TryFind("ToyosatomimiNoMikoSpawner", out ModItem ToyosatomimiNoMikoSpawner)
                && ModConditions.gensokyoMod.TryFind("UtsuhoReiujiSpawner", out ModItem UtsuhoReiujiSpawner)
                && (entity.type == AliceMargatroidSpawner.Type
                || entity.type == CirnoSpawner.Type
                || entity.type == EternityLarvaSpawner.Type
                || entity.type == HinaKagiyamaSpawner.Type
                || entity.type == KaguyaHouraisanSpawner.Type
                || entity.type == LilyWhiteSpawner.Type
                || entity.type == MayumiJoutouguuSpawner.Type
                || entity.type == MedicineMelancholySpawner.Type
                || entity.type == MinamitsuMurasaSpawner.Type
                || entity.type == NazrinSpawner.Type
                || entity.type == NitoriKawashiroSpawner.Type
                || entity.type == RumiaSpawner.Type
                || entity.type == SakuyaIzayoiSpawner.Type
                || entity.type == SeijaKijinSpawner.Type
                || entity.type == SeiranSpawner.Type
                || entity.type == SekibankiSpawner.Type
                || entity.type == TenshiHinanawiSpawner.Type
                || entity.type == ToyosatomimiNoMikoSpawner.Type
                || entity.type == UtsuhoReiujiSpawner.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeGMRSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.gerdsLabLoaded &&
                ModConditions.gerdsLabMod.TryFind("JackDroneOld", out ModItem JackDroneOld)
                && entity.type == JackDroneOld.Type && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeHomewardSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.homewardJourneyLoaded &&
                ModConditions.homewardJourneyMod.TryFind("CannedSoulofFlight", out ModItem CannedSoulofFlight)
                && ModConditions.homewardJourneyMod.TryFind("SouthernPotting", out ModItem SouthernPotting)
                && ModConditions.homewardJourneyMod.TryFind("SunlightCrown", out ModItem SunlightCrown)
                && ModConditions.homewardJourneyMod.TryFind("MetalSpine", out ModItem MetalSpine)
                && ModConditions.homewardJourneyMod.TryFind("UnstableGlobe", out ModItem UnstableGlobe)
                && ModConditions.homewardJourneyMod.TryFind("UltimateTorch", out ModItem UltimateTorch)
                && (entity.type == CannedSoulofFlight.Type
                || entity.type == SouthernPotting.Type
                || entity.type == SunlightCrown.Type
                || entity.type == MetalSpine.Type
                || entity.type == UnstableGlobe.Type
                || entity.type == UltimateTorch.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeMartainsOrderSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.martainsOrderLoaded &&
                ModConditions.martainsOrderMod.TryFind("FrigidEgg", out ModItem FrigidEgg)
                && ModConditions.martainsOrderMod.TryFind("SuspiciousLookingCloud", out ModItem SuspiciousLookingCloud)
                && ModConditions.martainsOrderMod.TryFind("CarnageSuspiciousRazor", out ModItem CarnageSuspiciousRazor)
                && ModConditions.martainsOrderMod.TryFind("VoidWorm", out ModItem VoidWorm)
                && ModConditions.martainsOrderMod.TryFind("LuminiteSlimeCrown", out ModItem LuminiteSlimeCrown)
                && ModConditions.martainsOrderMod.TryFind("LuminiteEye", out ModItem LuminiteEye)
                && ModConditions.martainsOrderMod.TryFind("JunglesLastTreasure", out ModItem JunglesLastTreasure)
                && ModConditions.martainsOrderMod.TryFind("TeslaRemote", out ModItem TeslaRemote)
                && (entity.type == FrigidEgg.Type
                || entity.type == SuspiciousLookingCloud.Type
                || entity.type == CarnageSuspiciousRazor.Type
                || entity.type == VoidWorm.Type
                || entity.type == LuminiteSlimeCrown.Type
                || entity.type == LuminiteEye.Type
                || entity.type == JunglesLastTreasure.Type
                || entity.type == TeslaRemote.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeMetroidSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.metroidLoaded &&
                ModConditions.metroidMod.TryFind("GoldenTorizoSummon", out ModItem GoldenTorizoSummon)
                && ModConditions.metroidMod.TryFind("KraidSummon", out ModItem KraidSummon)
                && ModConditions.metroidMod.TryFind("NightmareSummon", out ModItem NightmareSummon)
                && ModConditions.metroidMod.TryFind("OmegaPirateSummon", out ModItem OmegaPirateSummon)
                && ModConditions.metroidMod.TryFind("PhantoonSummon", out ModItem PhantoonSummon)
                && ModConditions.metroidMod.TryFind("SerrisSummon", out ModItem SerrisSummon)
                && ModConditions.metroidMod.TryFind("TorizoSummon", out ModItem TorizoSummon)
                && (entity.type == GoldenTorizoSummon.Type
                || entity.type == KraidSummon.Type
                || entity.type == NightmareSummon.Type
                || entity.type == OmegaPirateSummon.Type
                || entity.type == PhantoonSummon.Type
                || entity.type == SerrisSummon.Type
                || entity.type == TorizoSummon.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeQwertySummons : GlobalItem
    {
        //ModConditions.qwertyMod.TryFind("FortressBossSummon", out ModItem FortressBossSummon)
        //ModConditions.qwertyMod.TryFind("GodSealKeycard", out ModItem GodSealKeycard)
        //entity.type == FortressBossSummon.Type
        //entity.type == GodSealKeycard.Type
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.qwertyLoaded &&
                ModConditions.qwertyMod.TryFind("AncientEmblem", out ModItem AncientEmblem)
                && ModConditions.qwertyMod.TryFind("B4Summon", out ModItem B4Summon)
                && ModConditions.qwertyMod.TryFind("BladeBossSummon", out ModItem BladeBossSummon)
                && ModConditions.qwertyMod.TryFind("DinoEgg", out ModItem DinoEgg)
                && ModConditions.qwertyMod.TryFind("HydraSummon", out ModItem HydraSummon)
                && ModConditions.qwertyMod.TryFind("RitualInterupter", out ModItem RitualInterupter)
                && ModConditions.qwertyMod.TryFind("SummoningRune", out ModItem SummoningRune)
                && (entity.type == AncientEmblem.Type
                || entity.type == B4Summon.Type
                || entity.type == BladeBossSummon.Type
                || entity.type == DinoEgg.Type
                || entity.type == HydraSummon.Type
                || entity.type == RitualInterupter.Type
                || entity.type == SummoningRune.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeRedemptionSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.redemptionLoaded &&
                ModConditions.redemptionMod.TryFind("EaglecrestSpelltome", out ModItem EaglecrestSpelltome)
                && ModConditions.redemptionMod.TryFind("EggCrown", out ModItem EggCrown)
                && ModConditions.redemptionMod.TryFind("FowlWarHorn", out ModItem FowlWarHorn)
                && (entity.type == EaglecrestSpelltome.Type
                || entity.type == EggCrown.Type
                || entity.type == FowlWarHorn.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeSOTSSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.secretsOfTheShadowsLoaded &&
                ModConditions.secretsOfTheShadowsMod.TryFind("ElectromagneticLure", out ModItem ElectromagneticLure)
                && ModConditions.secretsOfTheShadowsMod.TryFind("SuspiciousLookingCandle", out ModItem SuspiciousLookingCandle)
                && ModConditions.secretsOfTheShadowsMod.TryFind("JarOfPeanuts", out ModItem JarOfPeanuts)
                && ModConditions.secretsOfTheShadowsMod.TryFind("CatalystBomb", out ModItem CatalystBomb)
                && (entity.type == ElectromagneticLure.Type
                || entity.type == SuspiciousLookingCandle.Type
                || entity.type == JarOfPeanuts.Type
                || entity.type == CatalystBomb.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeSpiritSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.spiritLoaded &&
                ModConditions.spiritMod.TryFind("DistressJellyItem", out ModItem DistressJellyItem)
                && ModConditions.spiritMod.TryFind("GladeWreath", out ModItem GladeWreath)
                && ModConditions.spiritMod.TryFind("ReachBossSummon", out ModItem ReachBossSummon)
                && ModConditions.spiritMod.TryFind("JewelCrown", out ModItem JewelCrown)
                && ModConditions.spiritMod.TryFind("BlackPearl", out ModItem BlackPearl)
                && ModConditions.spiritMod.TryFind("BlueMoonSpawn", out ModItem BlueMoonSpawn)
                && ModConditions.spiritMod.TryFind("DuskCrown", out ModItem DuskCrown)
                && ModConditions.spiritMod.TryFind("CursedCloth", out ModItem CursedCloth)
                && ModConditions.spiritMod.TryFind("StoneSkin", out ModItem StoneSkin)
                && ModConditions.spiritMod.TryFind("MartianTransmitter", out ModItem MartianTransmitter)
                && (entity.type == DistressJellyItem.Type
                || entity.type == GladeWreath.Type
                || entity.type == ReachBossSummon.Type
                || entity.type == JewelCrown.Type
                || entity.type == BlackPearl.Type
                || entity.type == BlueMoonSpawn.Type
                || entity.type == DuskCrown.Type
                || entity.type == CursedCloth.Type
                || entity.type == StoneSkin.Type
                || entity.type == MartianTransmitter.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeSpookySummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.spookyLoaded &&
                ModConditions.spookyMod.TryFind("Fertilizer", out ModItem Fertilizer)
                && ModConditions.spookyMod.TryFind("RottenSeed", out ModItem RottenSeed)
                && (entity.type == Fertilizer.Type
                || entity.type == RottenSeed.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeStormSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.stormsAdditionsLoaded &&
                ModConditions.stormsAdditionsMod.TryFind("AridBossSummon", out ModItem AridBossSummon)
                && ModConditions.stormsAdditionsMod.TryFind("MoonlingSummoner", out ModItem MoonlingSummoner)
                && ModConditions.stormsAdditionsMod.TryFind("StormBossSummoner", out ModItem StormBossSummoner)
                && ModConditions.stormsAdditionsMod.TryFind("UltimateBossSummoner", out ModItem UltimateBossSummoner)
                && (entity.type == AridBossSummon.Type
                || entity.type == MoonlingSummoner.Type
                || entity.type == StormBossSummoner.Type
                || entity.type == UltimateBossSummoner.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeSupernovaSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.supernovaLoaded &&
                ModConditions.supernovaMod.TryFind("BugOnAStick", out ModItem BugOnAStick)
                && ModConditions.supernovaMod.TryFind("EerieCrystal", out ModItem EerieCrystal)
                && (entity.type == BugOnAStick.Type
                || entity.type == EerieCrystal.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeThoriumSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.thoriumLoaded &&
                ModConditions.thoriumMod.TryFind("StormFlare", out ModItem StormFlare)
                && ModConditions.thoriumMod.TryFind("JellyfishResonator", out ModItem JellyfishResonator)
                && ModConditions.thoriumMod.TryFind("UnstableCore", out ModItem UnstableCore)
                && ModConditions.thoriumMod.TryFind("AncientBlade", out ModItem AncientBlade)
                && ModConditions.thoriumMod.TryFind("StarCaller", out ModItem StarCaller)
                && ModConditions.thoriumMod.TryFind("StriderTear", out ModItem StriderTear)
                && ModConditions.thoriumMod.TryFind("VoidLens", out ModItem VoidLens)
                && ModConditions.thoriumMod.TryFind("AromaticBulb", out ModItem AromaticBulb)
                && ModConditions.thoriumMod.TryFind("AbyssalShadow2", out ModItem AbyssalShadow2)
                && ModConditions.thoriumMod.TryFind("DoomSayersCoin", out ModItem DoomSayersCoin)
                && (entity.type == StormFlare.Type
                || entity.type == JellyfishResonator.Type
                || entity.type == UnstableCore.Type
                || entity.type == AncientBlade.Type
                || entity.type == StarCaller.Type
                || entity.type == StriderTear.Type
                || entity.type == VoidLens.Type
                || entity.type == AromaticBulb.Type
                || entity.type == AbyssalShadow2.Type
                || entity.type == DoomSayersCoin.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeUhtricSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.uhtricLoaded &&
                ModConditions.uhtricMod.TryFind("RareGeode", out ModItem RareGeode)
                && ModConditions.uhtricMod.TryFind("SnowyCharcoal", out ModItem SnowyCharcoal)
                && ModConditions.uhtricMod.TryFind("CosmicLure", out ModItem CosmicLure)
                && (entity.type == RareGeode.Type
                || entity.type == SnowyCharcoal.Type
                || entity.type == CosmicLure.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeUniverseOfSwordsSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.universeOfSwordsLoaded &&
                ModConditions.universeOfSwordsMod.TryFind("SwordBossSummon", out ModItem SwordBossSummon)
                && (entity.type == SwordBossSummon.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeValhallaSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.valhallaLoaded &&
                ModConditions.valhallaMod.TryFind("HeavensSeal", out ModItem HeavensSeal)
                && ModConditions.valhallaMod.TryFind("HellishRadish", out ModItem HellishRadish)
                && (entity.type == HeavensSeal.Type
                || entity.type == HellishRadish.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeVitalitySummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.vitalityLoaded &&
                ModConditions.vitalityMod.TryFind("CloudCore", out ModItem CloudCore)
                && ModConditions.vitalityMod.TryFind("AncientCrown", out ModItem AncientCrown)
                && ModConditions.vitalityMod.TryFind("MultigemCluster", out ModItem MultigemCluster)
                && ModConditions.vitalityMod.TryFind("MoonlightLotusFlower", out ModItem MoonlightLotusFlower)
                && ModConditions.vitalityMod.TryFind("Dreadcandle", out ModItem Dreadcandle)
                && ModConditions.vitalityMod.TryFind("AnarchyCrystal", out ModItem AnarchyCrystal)
                && ModConditions.vitalityMod.TryFind("TotemofChaos", out ModItem TotemofChaos)
                && ModConditions.vitalityMod.TryFind("MartianRadio", out ModItem MartianRadio)
                && ModConditions.vitalityMod.TryFind("SpiritBox", out ModItem SpiritBox)
                && (entity.type == CloudCore.Type
                || entity.type == AncientCrown.Type
                || entity.type == MultigemCluster.Type
                || entity.type == MoonlightLotusFlower.Type
                || entity.type == Dreadcandle.Type
                || entity.type == AnarchyCrystal.Type
                || entity.type == TotemofChaos.Type
                || entity.type == MartianRadio.Type
                || entity.type == SpiritBox.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeWayfairSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.wayfairContentLoaded &&
                ModConditions.wayfairContentMod.TryFind("MagicFertilizer", out ModItem MagicFertilizer)
                && entity.type == MagicFertilizer.Type && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeVanillaSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return (entity.type == ItemID.SlimeCrown || entity.type == ItemID.SuspiciousLookingEye
                || entity.type == ItemID.WormFood || entity.type == ItemID.BloodySpine
                || entity.type == ItemID.Abeemination || entity.type == ItemID.DeerThing
                || entity.type == ItemID.QueenSlimeCrystal || entity.type == ItemID.MechanicalWorm
                || entity.type == ItemID.MechanicalEye || entity.type == ItemID.MechanicalSkull
                || entity.type == ItemID.MechdusaSummon || entity.type == ItemID.CelestialSigil
                || entity.type == ItemID.BloodMoonStarter || entity.type == ItemID.GoblinBattleStandard
                || entity.type == ItemID.PirateMap || entity.type == ItemID.SolarTablet
                || entity.type == ItemID.SnowGlobe || entity.type == ItemID.PumpkinMoonMedallion
                || entity.type == ItemID.NaughtyPresent) && QoLCompendium.mainConfig.EndlessBossSummons && !ModConditions.calamityLoaded;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeVanillaRightClickSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return (entity.type == ItemID.DD2ElderCrystal || entity.type == ItemID.LihzahrdPowerCell) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            return false;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class OtherItemStuff : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (QoLCompendium.mainConfig.NoDevs && ItemID.Sets.BossBag[item.type])
            {
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;
            }

            if (QoLCompendium.mainConfig.IncreaseMaxStack)
            {
                if (item.maxStack > 10 && (item.maxStack != 100) && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
                {
                    item.maxStack = 9999;
                }
            }

            if (QoLCompendium.mainConfig.SuperIncreaseMaxStack)
            {
                if (item.maxStack > 10 && (item.maxStack != 100) && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
                {
                    item.maxStack = 99999;
                }
            }

            if (QoLCompendium.mainConfig.StackableQuestItems)
            {
                if (item.maxStack == 1 && item.questItem == true)
                {
                    if (QoLCompendium.mainConfig.IncreaseMaxStack)
                    {
                        item.maxStack = 9999;
                    }

                    if (QoLCompendium.mainConfig.SuperIncreaseMaxStack)
                    {
                        item.maxStack = 99999;
                    }
                }
            }

            if (ModConditions.redemptionLoaded)
            {
                if (ModConditions.redemptionMod.TryFind("Keycard", out ModItem Card) && Card != null && ModConditions.redemptionMod.TryFind("Keycard2", out ModItem Card2) && Card2 != null)
                {
                    ItemID.Sets.ShimmerTransformToItem[Card2.Type] = Card.Type;
                }
            }

            if (QoLCompendium.itemConfig.DedicatedItems)
            {
                ItemID.Sets.ShimmerTransformToItem[ItemID.RottenEgg] = ModContent.ItemType<LittleEgg>();
            }

            if (QoLCompendium.mainConfig.BossItemTransmutation)
            {
                if (item.type == ItemID.NinjaHood)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 257;
                }
                if (item.type == ItemID.NinjaShirt)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 258;
                }
                if (item.type == ItemID.NinjaPants)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 256;
                }
                if (item.type == ItemID.BeeKeeper)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2888;
                }
                if (item.type == ItemID.BeesKnees)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1121;
                }
                if (item.type == ItemID.BeeGun)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1132;
                }
                if (item.type == ItemID.HoneyComb)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1123;
                }
                if (item.type == ItemID.LucyTheAxe)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 5117;
                }
                if (item.type == ItemID.PewMaticHorn)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 5118;
                }
                if (item.type == ItemID.WeatherPain)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 5119;
                }
                if (item.type == ItemID.HoundiusShootius)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 5095;
                }
                if (item.type == ItemID.BreakerBlade)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 434;
                }
                if (item.type == ItemID.ClockworkAssaultRifle)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 514;
                }
                if (item.type == ItemID.LaserRifle)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4912;
                }
                if (item.type == ItemID.FireWhip)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 426;
                }
                if (item.type == ItemID.CrystalNinjaHelmet)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4983;
                }
                if (item.type == ItemID.CrystalNinjaChestplate)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4984;
                }
                if (item.type == ItemID.CrystalNinjaLeggings)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4982;
                }
                if (item.type == ItemID.Seedler)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1259;
                }
                if (item.type == ItemID.FlowerPow)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 758;
                }
                if (item.type == ItemID.GrenadeLauncher)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1255;
                }
                if (item.type == ItemID.VenusMagnum)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 788;
                }
                if (item.type == ItemID.NettleBurst)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1178;
                }
                if (item.type == ItemID.LeafBlower)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1155;
                }
                if (item.type == ItemID.WaspGun)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3018;
                }
                if (item.type == ItemID.GolemFist)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1122;
                }
                if (item.type == ItemID.PossessedHatchet)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1258;
                }
                if (item.type == ItemID.Stynger)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1295;
                }
                if (item.type == ItemID.HeatRay)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1296;
                }
                if (item.type == ItemID.StaffofEarth)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 899;
                }
                if (item.type == ItemID.SunStone)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1248;
                }
                if (item.type == ItemID.EyeoftheGolem)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1297;
                }
                if (item.type == ItemID.Flairon)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2624;
                }
                if (item.type == ItemID.Tsunami)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2622;
                }
                if (item.type == ItemID.RazorbladeTyphoon)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2623;
                }
                if (item.type == ItemID.BubbleGun)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2621;
                }
                if (item.type == ItemID.TempestStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2611;
                }
                if (item.type == ItemID.PiercingStarlight)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4953;
                }
                if (item.type == ItemID.FairyQueenRangedItem)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4952;
                }
                if (item.type == ItemID.FairyQueenMagicItem)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4914;
                }
                if (item.type == ItemID.RainbowWhip)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4923;
                }
                if (item.type == ItemID.Terrarian)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3063;
                }
                if (item.type == ItemID.Meowmere)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3065;
                }
                if (item.type == ItemID.StarWrath)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3930;
                }
                if (item.type == ItemID.Celeb2)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1553;
                }
                if (item.type == ItemID.SDMG)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3541;
                }
                if (item.type == ItemID.LastPrism)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3570;
                }
                if (item.type == ItemID.LunarFlareBook)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3571;
                }
                if (item.type == ItemID.RainbowCrystalStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3569;
                }
                if (item.type == ItemID.MoonlordTurretStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3389;
                }
                if (item.type == ItemID.DD2SquireDemonSword)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3835;
                }
                if (item.type == ItemID.MonkStaffT1)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3836;
                }
                if (item.type == ItemID.MonkStaffT2)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3854;
                }
                if (item.type == ItemID.DD2PhoenixBow)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3852;
                }
                if (item.type == ItemID.BookStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3823;
                }
                if (item.type == ItemID.DD2SquireBetsySword)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3858;
                }
                if (item.type == ItemID.MonkStaffT3)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3859;
                }
                if (item.type == ItemID.DD2BetsyBow)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3870;
                }
                if (item.type == ItemID.ApprenticeStaffT3)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3827;
                }
                if (item.type == ItemID.StakeLauncher)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1845;
                }
                if (item.type == ItemID.NecromanticScroll)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1835;
                }
                if (item.type == ItemID.TheHorsemansBlade)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1782;
                }
                if (item.type == ItemID.CandyCornRifle)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1784;
                }
                if (item.type == ItemID.JackOLanternLauncher)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1801;
                }
                if (item.type == ItemID.BatScepter)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1802;
                }
                if (item.type == ItemID.RavenStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4680;
                }
                if (item.type == ItemID.ScytheWhip)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1826;
                }
                if (item.type == ItemID.ChristmasTreeSword)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1930;
                }
                if (item.type == ItemID.Razorpine)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1928;
                }
                if (item.type == ItemID.ElfMelter)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1929;
                }
                if (item.type == ItemID.ChainGun)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1910;
                }
                if (item.type == ItemID.NorthPole)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1946;
                }
                if (item.type == ItemID.SnowmanCannon)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1931;
                }
                if (item.type == ItemID.BlizzardStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1947;
                }
                if (item.type == ItemID.InfluxWaver)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2797;
                }
                if (item.type == ItemID.Xenopopper)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2796;
                }
                if (item.type == ItemID.ElectrosphereLauncher)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2795;
                }
                if (item.type == ItemID.LaserMachinegun)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2749;
                }
                if (item.type == ItemID.XenoStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2769;
                }
                if (item.type == ItemID.CosmicCarKey)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 2880;
                }
                if (item.type == ItemID.BloodRainBow)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4273;
                }
                if (item.type == ItemID.VampireFrogStaff)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4381;
                }
                if (item.type == ItemID.SharpTears)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4272;
                }
                if (item.type == ItemID.DripplerFlail)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 4270;
                }
                if (item.type == ItemID.ShadowFlameKnife)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3052;
                }
                if (item.type == ItemID.ShadowFlameBow)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3053;
                }
                if (item.type == ItemID.ShadowFlameHexDoll)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 3054;
                }
                if (item.type == ItemID.VampireKnives)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1571;
                }
                if (item.type == ItemID.ScourgeoftheCorruptor)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = 1569;
                }
            }
        }

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (QoLCompendium.mainConfig.FastExtractor)
            {
                Main.LocalPlayer.itemAnimation = 1;
                Main.LocalPlayer.itemTime = 1;
                Main.LocalPlayer.itemTimeMax = 1;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0)
                return 1f - QoLCompendium.mainConfig.FastTools;
            return 1f;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.consumable == true && item.damage == -1 && item.stack >= QoLCompendium.mainConfig.EndlessAmount && QoLCompendium.mainConfig.EndlessConsumables)
            {
                return false;
            }

            if (item.consumable == true && item.damage > 0 && item.stack >= QoLCompendium.mainConfig.EndlessAmount && QoLCompendium.mainConfig.EndlessWeapons)
            {
                return false;
            }

            return base.ConsumeItem(item, player);
        }

        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            if (ammo.ammo > 0 && ammo.stack >= QoLCompendium.mainConfig.EndlessAmount && QoLCompendium.mainConfig.EndlessAmmo)
            {
                return false;
            }
            return base.CanBeConsumedAsAmmo(ammo, weapon, player);
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= QoLCompendium.mainConfig.EndlessAmount && QoLCompendium.mainConfig.EndlessBait)
            {
                return false;
            }
            return base.CanConsumeBait(player, bait);
        }
    }

    public class MiningSpeedBenefits : GlobalItem
    {
        private int basedrillspeed;

        private int minetime;

        private int walltime;

        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item item)
        {
            if (QoLCompendium.mainConfig.MiningSpeedForHammersAndAxesAndDrills && (item.pick >= 1 || item.axe >= 1 || item.hammer >= 1) && item.channel)
            {
                basedrillspeed = item.useTime;
            }
            if (QoLCompendium.mainConfig.MiningSpeedForHammersAndAxesAndDrills && (item.axe >= 1 || item.hammer >= 1) && !item.channel)
            {
                basedrillspeed = item.useTime;
            }
        }

        public override void HoldItem(Item item, Player player)
        {
            int num3 = (int)(player.pickSpeed * 100f);
            if (QoLCompendium.mainConfig.MiningSpeedForHammersAndAxesAndDrills && (item.pick >= 1 || item.axe >= 1 || item.hammer >= 1) && item.channel)
            {
                item.useTime = basedrillspeed * num3 / 100;
                if (item.useTime == 0)
                {
                    item.useTime = 1;
                }
            }
            if (QoLCompendium.mainConfig.MiningSpeedForHammersAndAxesAndDrills && (item.axe >= 1 || item.hammer >= 1) && !item.channel && item.pick == 0)
            {
                item.useTime = basedrillspeed * num3 / 100;
                if (item.useTime == 0)
                {
                    item.useTime = 1;
                }
            }
        }
    }

    public class FavoriteToResearch : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            if (item.favorited && item.stack >= CreativeUI.GetSacrificeCount(item.type, out bool researched) && CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(item.type, out int numResearch) && !researched && player.difficulty == PlayerDifficultyID.Creative && item.stack >= numResearch && QoLCompendium.mainConfig.FavoriteResearching)
            {
                if (item.type == ItemID.ShellphoneDummy || item.type == ItemID.ShellphoneHell || item.type == ItemID.ShellphoneOcean || item.type == ItemID.ShellphoneSpawn || item.type == ItemID.Shellphone)
                {
                    return;
                }
                CreativeUI.ResearchItem(item.type);
                SoundEngine.PlaySound(SoundID.ResearchComplete, default, null);
                item.stack -= numResearch;
                if (item.stack <= 0)
                {
                    item.TurnToAir();
                }
            }
        }
    }
}