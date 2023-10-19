using QoLCompendium.Items.BossAndEventSummons;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
        }
    }

    public class DontConsumeFargosSoulsSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.fargosSoulsLoaded &&
                ModConditions.fargosSoulsMod.TryFind("SquirrelCoatofArms", out ModItem SquirrelCoatofArms)
                && ModConditions.fargosSoulsMod.TryFind("DevisCurse", out ModItem DevisCurse)
                && ModConditions.fargosSoulsMod.TryFind("FragilePixieLamp", out ModItem FragilePixieLamp)
                && ModConditions.fargosSoulsMod.TryFind("AbomsCurse", out ModItem AbomsCurse)
                && ModConditions.fargosSoulsMod.TryFind("MutantsCurse", out ModItem MutantsCurse)
                && (entity.type == SquirrelCoatofArms.Type
                || entity.type == DevisCurse.Type
                || entity.type == FragilePixieLamp.Type
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
        }
    }

    public class DontConsumeSupernovaSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModConditions.supernovaLoaded &&
                ModConditions.supernovaMod.TryFind("HorridChunk", out ModItem HorridChunk)
                && ModConditions.supernovaMod.TryFind("MantaFood", out ModItem MantaFood)
                && (entity.type == HorridChunk.Type
                || entity.type == MantaFood.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
                && ModConditions.vitalityMod.TryFind("SpiritBox", out ModItem SpiritBox)
                && (entity.type == CloudCore.Type
                || entity.type == AncientCrown.Type
                || entity.type == MultigemCluster.Type
                || entity.type == MoonlightLotusFlower.Type
                || entity.type == Dreadcandle.Type
                || entity.type == AnarchyCrystal.Type
                || entity.type == TotemofChaos.Type
                || entity.type == SpiritBox.Type) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
        }
    }

    public class DontConsumeCompendiumSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return QoLCompendium.itemConfig.BossSummoners && 
                (entity.type == ModContent.ItemType<ClamSummon>() || entity.type == ModContent.ItemType<CultistSummon>()
                || entity.type == ModContent.ItemType<DukeSummon>() || entity.type == ModContent.ItemType<EmpressSummon>()
                || entity.type == ModContent.ItemType<GolemSummon>() || entity.type == ModContent.ItemType<PlanteraSummon>()
                || entity.type == ModContent.ItemType<SkeletronSummon>() || entity.type == ModContent.ItemType<WallOfFleshSummon>()
                || entity.type == ModContent.ItemType<MartianSummon>() || entity.type == ModContent.ItemType<PartySummon>()
                || entity.type == ModContent.ItemType<RainSummon>() || entity.type == ModContent.ItemType<SandstormSummon>()
                || entity.type == ModContent.ItemType<SlimeRainSummon>() || entity.type == ModContent.ItemType<WindSummon>() 
                || entity.type == ModContent.ItemType<BetsySummon>() || entity.type == ModContent.ItemType<DarkMageSummon>() 
                || entity.type == ModContent.ItemType<DreadnautilusSummon>() || entity.type == ModContent.ItemType<DutchmanSummon>() 
                || entity.type == ModContent.ItemType<GoblinWarlockSummon>() || entity.type == ModContent.ItemType<IceGolemSummon>() 
                || entity.type == ModContent.ItemType<MartianSaucerSummon>() || entity.type == ModContent.ItemType<MothronSummon>() 
                || entity.type == ModContent.ItemType<OgreSummon>() || entity.type == ModContent.ItemType<SandElementalSummon>() 
                || entity.type == ModContent.ItemType<TravelerArriver>()) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
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
                || entity.type == ItemID.MechdusaSummon || entity.type == ItemID.LihzahrdPowerCell 
                || entity.type == ItemID.CelestialSigil || entity.type == ItemID.BloodMoonStarter 
                || entity.type == ItemID.GoblinBattleStandard || entity.type == ItemID.PirateMap
                || entity.type == ItemID.SolarTablet || entity.type == ItemID.SnowGlobe
                || entity.type == ItemID.PumpkinMoonMedallion || entity.type == ItemID.NaughtyPresent
                || entity.type == ItemID.DD2ElderCrystal) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "NotConsumable", "Not Consumable")
            {
                Text = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable")
            });
        }
    }

    public class DontConsumeVanillaRightClickSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return (entity.type == ItemID.DD2ElderCrystal || entity.type == ItemID.LihzahrdPowerCell) && QoLCompendium.mainConfig.EndlessBossSummons;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            return false;
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
            if (item.consumable == true && item.stack >= QoLCompendium.mainConfig.EndlessAmount && QoLCompendium.mainConfig.EndlessConsumables)
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
}
