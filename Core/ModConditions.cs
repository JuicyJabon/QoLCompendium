using Terraria.ModLoader.IO;

namespace QoLCompendium.Core
{
    public class ModConditions : ModSystem
    {
        #pragma warning disable
        #region Conditions

        //RECIPE CONDITIONS
        public static Condition ItemToggled(string displayText, Func<bool> toggle)
        {
            return new Condition(Language.GetTextValue(displayText), toggle);
        }

        public static Recipe GetItemRecipe(Func<bool> toggle, int itemType, int amount = 1, string displayText = "")
        {
            Recipe obj = Recipe.Create(itemType, amount);
            obj.AddCondition(ItemToggled(displayText, toggle));
            return obj;
        }

        //VANILLA
        //EXPERT/MASTER
        public static Condition expertOrMaster = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.inExpertOrMaster"), () => Main.expertMode || Main.masterMode);
        //BOSSES
        public static Condition DownedDreadnautilus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDreadnautilus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dreadnautilus]);
        public static Condition DownedMartianSaucer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMartianSaucer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MartianSaucer]);
        public static Condition NotDownedMechBossAll = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.notDownedMechBossAll"), () => !(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3));
        //EVENTS
        public bool waitForBloodMoon;
        public static Condition DownedBloodMoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBloodMoon"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.BloodMoon]);
        public bool waitForEclipse;
        public static Condition DownedEclipse = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEclipse"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Eclipse]);
        public static Condition DownedLunarEvent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLunarEvent"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.LunarTowers]);
        public static Condition DownedLunarPillarAny = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLunarPillarAny"), () => NPC.downedTowerNebula || NPC.downedTowerSolar || NPC.downedTowerStardust || NPC.downedTowerVortex);
        public bool waitForNight;
        public static Condition HasBeenThroughNight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenThroughNight"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Night]);
        //BIOMES
        public static Condition HasBeenToPurity = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToPurity"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Forest]);
        public static Condition HasBeenToCavernsOrUnderground = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCavernsOrUnderground"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Underground] || ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Caverns]);
        public static Condition HasBeenToUnderworld = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToUnderworld"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Underworld]);
        public static Condition HasBeenToSky = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSky"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Sky]);
        public static Condition HasBeenToSnow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSnow"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Tundra]);
        public static Condition HasBeenToDesert = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDesert"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Desert]);
        public static Condition HasBeenToOcean = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToOcean"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Ocean]);
        public static Condition HasBeenToJungle = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToJungle"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Jungle]);
        public static Condition HasBeenToMushroom = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToMushroom"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.GlowingMushroom]);
        public static Condition HasBeenToCorruption = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCorruption"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Corruption]);
        public static Condition HasBeenToCrimson = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCrimson"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Crimson]);
        public static Condition HasBeenToEvil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToEvil"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Corruption] || ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Crimson]);
        public static Condition HasBeenToHallow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToHallow"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Hallow]);
        public static Condition HasBeenToTemple = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToTemple"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Temple]);
        public static Condition HasBeenToDungeon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDungeon"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Dungeon]);
        public static Condition HasBeenToAether = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAether"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Aether]);
        //OTHER
        public static bool talkedToSkeletonMerchant;
        public static Condition HasTalkedToSkeletonMerchant = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.talkedToSkeletonMerchant"), () => talkedToSkeletonMerchant);
        public static bool talkedToTravelingMerchant;
        public static Condition HasTalkedToTravelingMerchant = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.talkedToTravelingMerchant"), () => talkedToTravelingMerchant);


        //AEQUUS
        public static bool aequusLoaded;
        public static Mod aequusMod;
        //BOSSES
        public static Condition DownedCrabson = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCrabson"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Crabson]);
        public static Condition DownedOmegaStarite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaStarite"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaStarite]);
        public static Condition DownedDustDevil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDustDevil"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DustDevil]);
        //MINIBOSSES
        public static Condition DownedHyperStarite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHyperStarite"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HyperStarite]);
        public static Condition DownedUltraStarite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUltraStarite"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.UltraStarite]);
        public static Condition DownedRedSprite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRedSprite"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.RedSprite]);
        public static Condition DownedSpaceSquid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSpaceSquid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SpaceSquid]);
        //EVENTS
        public static Condition DownedDemonSiege = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDemonSiege"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.DemonSiege]);
        public static Condition DownedGlimmer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlimmer"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Glimmer]);
        public static Condition DownedGaleStreams = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGaleStreams"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.GaleStreams]);
        //BIOMES
        public static Condition HasBeenToCrabCrevice = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCrabCrevice"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CrabCrevice]);


        //AFKPETS
        public static bool afkpetsLoaded;
        public static Mod afkpetsMod;
        //BOSSES
        public static Condition DownedSlayerOfEvil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlayerOfEvil"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SlayerOfEvil]);
        public static Condition DownedSATLA = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSATLA"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SATLA]);
        public static Condition DownedDrFetus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDrFetus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DrFetus]);
        public static Condition DownedSlimesHope = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlimesHope"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SlimesHope]);
        public static Condition DownedPoliticianSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPoliticianSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PoliticianSlime]);
        public static Condition DownedAncientTrio = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientTrio"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientTrio]);
        public static Condition DownedLavalGolem = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLavalGolem"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LavalGolem]);
        //MINIBOSSES
        public static Condition DownedAntony = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAntony"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Antony]);
        public static Condition DownedBunnyZeppelin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBunnyZeppelin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BunnyZeppelin]);
        public static Condition DownedOkiku = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOkiku"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Okiku]);
        public static Condition DownedHarpyAirforce = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHarpyAirforce"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyAirforce]);
        public static Condition DownedIsaac = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIsaac"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Isaac]);
        public static Condition DownedAncientGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientGuardian]);
        public static Condition DownedHeroicSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHeroicSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HeroicSlime]);
        public static Condition DownedHoloSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHoloSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HoloSlime]);
        public static Condition DownedSecurityBot = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSecurityBot"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SecurityBot]);
        public static Condition DownedUndeadChef = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUndeadChef"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.UndeadChef]);
        public static Condition DownedNekoSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNekoSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NekoSlime]);
        public static Condition DownedNightmareAmplifierSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNightmareAmplifierSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NightmareAmplifierSlime]);
        public static Condition DownedGuardianOfFrost = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGuardianOfFrost"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GuardianOfFrost]);


        //AMULET OF MANY MINIONS
        public static bool amuletOfManyMinionsLoaded;
        public static Mod amuletOfManyMinionsMod;


        //ARBOUR
        public static bool arbourLoaded;
        public static Mod arbourMod;


        //ASSORTED CRAZY THINGS
        public static bool assortedCrazyThingsLoaded;
        public static Mod assortedCrazyThingsMod;
        //BOSSES
        public static Condition DownedSoulHarvester = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSoulHarvester"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SoulHarvester]);


        //AWFUL GARBAGE
        public static bool awfulGarbageLoaded;
        public static Mod awfulGarbageMod;
        //BOSSES
        public static Condition DownedTreeToad = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTreeToad"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TreeToad]);
        public static Condition DownedSeseKitsugai = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeseKitsugai"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SeseKitsugai]);
        public static Condition DownedEyeOfTheStorm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEyeOfTheStorm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EyeOfTheStorm]);
        public static Condition DownedFrigidius = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFrigidius"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Frigidius]);


        //BLOCK'S ARSENAL
        public static bool blocksArsenalLoaded;
        public static Mod blocksArsenalMod;


        //BLOCK'S ARTIFICER
        public static bool blocksArtificerLoaded;
        public static Mod blocksArtificerMod;


        //BLOCK'S CORE BOSS
        public static bool blocksCoreBossLoaded;
        public static Mod blocksCoreBossMod;
        //BOSSES
        public static Condition DownedCoreBoss = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCoreBoss"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CoreBoss]);


        //BLOCK'S INFO ACCESSORIES
        public static bool blocksInfoAccessoriesLoaded;
        public static Mod blocksInfoAccessoriesMod;


        //BLOCK'S THROWER
        public static bool blocksThrowerLoaded;
        public static Mod blocksThrowerMod;


        //BOMBUS APIS
        public static bool bombusApisLoaded;
        public static Mod bombusApisMod;


        //BUFFARIA
        public static bool buffariaLoaded;
        public static Mod buffariaMod;


        //CALAMITY
        public static bool calamityLoaded;
        public static Mod calamityMod;
        //BOSSES
        public static Condition DownedDesertScourge = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDesertScourge"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DesertScourge]);
        public static Condition DownedCrabulon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCrabulon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Crabulon]);
        public static Condition DownedHiveMind = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHiveMind"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HiveMind]);
        public static Condition DownedPerforators = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPerforators"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Perforators]);
        public static Condition DownedPerforatorsOrHiveMind = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPerfOrHive"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Perforators] || ModConditions.DownedBoss[(int)ModConditions.Downed.HiveMind]);
        public static Condition DownedSlimeGod = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlimeGod"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SlimeGod]);
        public static Condition DownedCryogen = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCryogen"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cryogen]);
        public static Condition DownedAquaticScourge = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAquaticScourge"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AquaticScourge]);
        public static Condition DownedBrimstoneElemental = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBrimstoneElemental"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BrimstoneElemental]);
        public static Condition DownedCalamitasClone = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCalamitasClone"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CalamitasClone]);
        public static Condition DownedLeviathanAndAnahita = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLeviathanAndAnahita"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LeviathanAndAnahita]);
        public static Condition DownedAstrumAureus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAstrumAureus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AstrumAureus]);
        public static Condition DownedPlaguebringerGoliath = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPlaguebringerGoliath"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PlaguebringerGoliath]);
        public static Condition DownedRavager = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRavager"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ravager]);
        public static Condition DownedAstrumDeus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAstrumDeus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AstrumDeus]);
        public static Condition DownedProfanedGuardians = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProfanedGuardians"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ProfanedGuardians]);
        public static Condition DownedDragonfolly = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDragonfolly"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dragonfolly]);
        public static Condition DownedProvidence = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProvidence"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Providence]);
        public static Condition DownedStormWeaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStormWeaver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StormWeaver]);
        public static Condition DownedCeaselessVoid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCeaselessVoid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CeaselessVoid]);
        public static Condition DownedSignus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSignus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Signus]);
        public static Condition DownedPolterghast = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPolterghast"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Polterghast]);
        public static Condition DownedOldDuke = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOldDuke"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OldDuke]);
        public static Condition DownedDevourerOfGods = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDevourerOfGods"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DevourerOfGods]);
        public static Condition DownedYharon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedYharon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Yharon]);
        public static Condition DownedExoMechs = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedExoMechs"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ExoMechs]);
        public static Condition DownedSupremeCalamitas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSupremeCalamitas"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SupremeCalamitas]);
        //MINIBOSSES
        public static Condition DownedGiantClam = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGiantClam"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GiantClam]);
        public static Condition DownedCragmawMire = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCragmawMire"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CragmawMire]);
        public static Condition DownedGreatSandShark = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGreatSandShark"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GreatSandShark]);
        public static Condition DownedNuclearTerror = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNuclearTerror"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NuclearTerror]);
        public static Condition DownedMauler = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMauler"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Mauler]);
        public static Condition DownedPrimordialWyrm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrimordialWyrm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PrimordialWyrm]);
        //EVENTS
        public static Condition DownedAcidRain1 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAcidRain1"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.AcidRainTier1]);
        public static Condition DownedAcidRain2 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAcidRain2"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.AcidRainTier2]);
        public static Condition DownedBossRush = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBossRush"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.BossRush]);
        //BIOMES
        public static Condition HasBeenToCrags = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCrags"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.BrimstoneCrags]);
        public static Condition HasBeenToAstral = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAstral"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AstralInfection]);
        public static Condition HasBeenToSunkenSea = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSunkenSea"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SunkenSea]);
        public static Condition HasBeenToSulphurSea = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSulphurSea"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SulphurSea]);
        public static Condition HasBeenToAbyss = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyss"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyss]);
        public static Condition HasBeenToAbyssLayer1 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer1"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer1]);
        public static Condition HasBeenToAbyssLayer2 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer2"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer2]);
        public static Condition HasBeenToAbyssLayer3 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer3"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer3]);
        public static Condition HasBeenToAbyssLayer4 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer4"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer4]);
        //POST SUPREME CALAMITAS SHIMMER
        public static Condition ShimmerableAfterMoonLordOrSupremeCalamitas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.shimmerableAfterMoonLordOrSupremeCalamitas"), () => (calamityLoaded && ModConditions.DownedBoss[(int)ModConditions.Downed.SupremeCalamitas] && NPC.downedMoonlord) || (!calamityLoaded && NPC.downedMoonlord));


        //CALAMITY COMMUNITY REMIX
        public static bool calamityCommunityRemixLoaded;
        public static Mod calamityCommunityRemixMod;
        //BOSSES
        public static Condition DownedWulfrumExcavator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWulfrumExcavator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WulfrumExcavator]);


        //CALAMITY ENTROPY
        public static bool calamityEntropyLoaded;
        public static Mod calamityEntropyMod;
        //BOSSES
        public static Condition DownedLuminaris = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLuminaris"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Luminaris]);
        public static Condition DownedProphet = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProphet"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Prophet]);
        public static Condition DownedNihilityTwin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNihilityTwin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NihilityTwin]);
        public static Condition DownedCruiser = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCruiser"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cruiser]);


        //CALAMITY OVERHAUL
        public static bool calamityOverhaulLoaded;
        public static Mod calamityOverhaulMod;


        //CALAMITY VANITIES
        public static bool calamityVanitiesLoaded;
        public static Mod calamityVanitiesMod;
        //BIOMES
        public static Condition HasBeenToAstralBlight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAstralBlight"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AstralBlight]);


        //CAPTURE DISCS CLASS
        public static bool captureDiscsClassLoaded;
        public static Mod captureDiscsClassMod;


        //CATALYST
        public static bool catalystLoaded;
        public static Mod catalystMod;
        //BOSSES
        public static Condition DownedAstrageldon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAstrageldon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Astrageldon]);


        //CEREBRAL
        public static bool cerebralLoaded;
        public static Mod cerebralMod;


        //CLAMITY
        public static bool clamityAddonLoaded;
        public static Mod clamityAddonMod;
        //BOSSES
        public static Condition DownedClamitas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedClamitas"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Clamitas]);
        public static Condition DownedPyrogen = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPyrogen"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Pyrogen]);
        public static Condition DownedWallOfBronze = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWallOfBronze"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfBronze]);
        //BIOMES
        public static Condition HasBeenToFrozenHell = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToFrozenHell"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.FrozenHell]);



        //CLICKER CLASS
        public static bool clickerClassLoaded;
        public static Mod clickerClassMod;


        //CONFECTION
        public static bool confectionRebakedLoaded;
        public static Mod confectionRebakedMod;
        //BIOMES
        public static Condition HasBeenToConfection = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToConfection"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Confection]);
        public static Condition HasBeenToConfectionOrHallow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToConfectionOrHallow"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Confection] || ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Hallow]);


        //CONSOLARIA
        public static bool consolariaLoaded;
        public static Mod consolariaMod;
        //BOSSES
        public static Condition DownedLepus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLepus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lepus]);
        public static Condition DownedTurkor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTurkor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Turkor]);
        public static Condition DownedOcram = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOcram"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ocram]);


        //CORALITE
        public static bool coraliteLoaded;
        public static Mod coraliteMod;
        //BOSSES
        public static Condition DownedRediancie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRediancie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Rediancie]);
        public static Condition DownedBabyIceDragon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBabyIceDragon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BabyIceDragon]);
        public static Condition DownedSlimeEmperor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlimeEmperor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SlimeEmperor]);
        public static Condition DownedBloodiancie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBloodiancie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodiancie]);
        public static Condition DownedThunderveinDragon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedThunderveinDragon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ThunderveinDragon]);
        public static Condition DownedNightmarePlantera = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNightmarePlantera"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NightmarePlantera]);


        //DEPTHS
        public static bool crystalDragonsLoaded;
        public static Mod crystalDragonsMod;


        //DEPTHS
        public static bool depthsLoaded;
        public static Mod depthsMod;
        //BOSSES
        public static Condition DownedChasme = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChasme"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Chasme]);
        //BIOMES
        public static Condition HasBeenToDepths = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDepths"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Depths]);
        public static Condition HasBeenToDepthsOrUnderworld = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDepthsOrUnderworld"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Depths] || ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Underworld]);


        //DORMANT DAWN
        public static bool dormantDawnLoaded;
        public static Mod dormantDawnMod;
        //BOSSES
        public static Condition DownedLifeGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLifeGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LifeGuardian]);
        public static Condition DownedManaGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedManaGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ManaGuardian]);
        public static Condition DownedMeteorExcavator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMeteorExcavator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MeteorExcavator]);
        public static Condition DownedMeteorAnnihilator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMeteorAnnihilator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MeteorAnnihilator]);
        public static Condition DownedHellfireSerpent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHellfireSerpent"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HellfireSerpent]);
        //MINIBOSSES
        public static Condition DownedWitheredAcornSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWitheredAcornSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WitheredAcornSpirit]);
        public static Condition DownedGoblinSorcererChieftain = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGoblinSorcererChieftain"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GoblinSorcererChieftain]);


        //DRAEDON EXPANSION
        public static bool draedonExpansionLoaded;
        public static Mod draedonExpansionMod;


        //DBZMOD
        public static bool dragonBallTerrariaLoaded;
        public static Mod dragonBallTerrariaMod;


        //ECHOES OF THE ANCIENTS
        public static bool echoesOfTheAncientsLoaded;
        public static Mod echoesOfTheAncientsMod;
        //BOSSES
        public static Condition DownedGalahis = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGalahis"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Galahis]);
        public static Condition DownedCreation = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCreation"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Creation]);
        public static Condition DownedDestruction = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDestruction"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Destruction]);


        //EDORBIS
        public static bool edorbisLoaded;
        public static Mod edorbisMod;
        //BOSSES
        public static Condition DownedBlightKing = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlightKing"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BlightKing]);
        public static Condition DownedGardener = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGardener"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Gardener]);
        public static Condition DownedGlaciation = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlaciation"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Glaciation]);
        public static Condition DownedHandOfCthulhu = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHandOfCthulhu"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HandOfCthulhu]);
        public static Condition DownedCursePreacher = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCursePreacher"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CursePreacher]);


        //ENCHANTED MOONS
        public static bool enchantedMoonsLoaded;
        public static Mod enchantedMoonsMod;


        //EVERJADE
        public static bool everjadeLoaded;
        public static Mod everjadeMod;
        //BIOMES
        public static Condition HasBeenToJadeLake = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToJadeLake"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.JadeLake]);


        //EXALT
        public static bool exaltLoaded;
        public static Mod exaltMod;
        //BOSSES
        public static Condition DownedEffulgence = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEffulgence"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Effulgence]);
        public static Condition DownedIceLich = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIceLich"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.IceLich]);


        //EXCELSIOR
        public static bool excelsiorLoaded;
        public static Mod excelsiorMod;
        //BOSSES
        public static Condition DownedNiflheim = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNiflheim"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Niflheim]);
        public static Condition DownedStellarStarship = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStellarStarship"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StellarStarship]);


        //EXXO AVALON
        public static bool exxoAvalonOriginsLoaded;
        public static Mod exxoAvalonOriginsMod;
        //BOSSES
        public static Condition DownedBacteriumPrime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBacteriumPrime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BacteriumPrime]);
        public static Condition DownedAvalonEvilBosses = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAvalonEvilBosses"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BacteriumPrime] || NPC.downedBoss2);
        public static Condition DownedDesertBeak = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDesertBeak"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DesertBeak]);
        public static Condition DownedKingSting = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKingSting"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.KingSting]);
        public static Condition DownedMechasting = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMechasting"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Mechasting]);
        public static Condition DownedPhantasm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPhantasm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Phantasm]);
        //BIOMES
        public static Condition HasBeenToContagion = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToContagion"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Contagion]);
        public static Condition HasBeenToAvalonEvilBiomes = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAvalonEvilBiomes"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Contagion] || ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Corruption] || ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Crimson]);


        //FARGOS
        public static bool fargosMutantLoaded;
        public static Mod fargosMutantMod;


        //FARGOS SOULS
        public static bool fargosSoulsLoaded;
        public static Mod fargosSoulsMod;
        //BOSSES
        public static Condition DownedTrojanSquirrel = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTrojanSquirrel"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TrojanSquirrel]);
        public static Condition DownedCursedCoffin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCursedCoffin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CursedCoffin]);
        public static Condition DownedDeviantt = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDeviantt"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Deviantt]);
        public static Condition DownedLifelight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLifelight"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lifelight]);
        public static Condition DownedBanishedBaron = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBanishedBaron"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BanishedBaron]);
        public static Condition DownedEridanus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEridanus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Eridanus]);
        public static Condition DownedAbominationn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAbominationn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Abominationn]);
        public static Condition DownedMutant = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMutant"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Mutant]);


        //FARGOS SOULS DLC
        public static bool fargosSoulsDLCLoaded;
        public static Mod fargosSoulsDLCMod;


        //FARGOS SOULS EXTRAS
        public static bool fargosSoulsExtrasLoaded;
        public static Mod fargosSoulsExtrasMod;


        //FRACTURES OF PENUMBRA
        public static bool fracturesOfPenumbraLoaded;
        public static Mod fracturesOfPenumbraMod;
        //BOSSES
        public static Condition DownedAlphaFrostjaw = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAlphaFrostjaw"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AlphaFrostjaw]);
        public static Condition DownedSanguineElemental = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSanguineElemental"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SanguineElemental]);
        //BIOMES
        public static Condition HasBeenToDread = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDread"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Dread]);


        //FURNITURE FOOD & FUN
        public static bool furnitureFoodAndFunLoaded;
        public static Mod furnitureFoodAndFunMod;


        //GAMETERRARIA
        public static bool gameTerrariaLoaded;
        public static Mod gameTerrariaMod;
        //BOSSES
        public static Condition DownedLad = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLad"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lad]);
        public static Condition DownedHornlitz = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHornlitz"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Hornlitz]);
        public static Condition DownedSnowDon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSnowDon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SnowDon]);
        public static Condition DownedStoffie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStoffie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Stoffie]);


        //GENSOKYO
        public static bool gensokyoLoaded;
        public static Mod gensokyoMod;
        //BOSSES
        public static Condition DownedLilyWhite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLilyWhite"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LilyWhite]);
        public static Condition DownedRumia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRumia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Rumia]);
        public static Condition DownedEternityLarva = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEternityLarva"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EternityLarva]);
        public static Condition DownedNazrin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNazrin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nazrin]);
        public static Condition DownedHinaKagiyama = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHinaKagiyama"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HinaKagiyama]);
        public static Condition DownedSekibanki = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSekibanki"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Sekibanki]);
        public static Condition DownedSeiran = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeiran"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Seiran]);
        public static Condition DownedNitoriKawashiro = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNitoriKawashiro"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NitoriKawashiro]);
        public static Condition DownedMedicineMelancholy = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMedicineMelancholy"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MedicineMelancholy]);
        public static Condition DownedCirno = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCirno"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cirno]);
        public static Condition DownedMinamitsuMurasa = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMinamitsuMurasa"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MinamitsuMurasa]);
        public static Condition DownedAliceMargatroid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAliceMargatroid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AliceMargatroid]);
        public static Condition DownedSakuyaIzayoi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSakuyaIzayoi"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SakuyaIzayoi]);
        public static Condition DownedSeijaKijin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeijaKijin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SeijaKijin]);
        public static Condition DownedMayumiJoutouguu = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMayumiJoutouguu"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MayumiJoutouguu]);
        public static Condition DownedToyosatomimiNoMiko = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedToyosatomimiNoMiko"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ToyosatomimiNoMiko]);
        public static Condition DownedKaguyaHouraisan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKaguyaHouraisan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.KaguyaHouraisan]);
        public static Condition DownedUtsuhoReiuji = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUtsuhoReiuji"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.UtsuhoReiuji]);
        public static Condition DownedTenshiHinanawi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTenshiHinanawi"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TenshiHinanawi]);
        //MINIBOSSES
        public static Condition DownedKisume = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKisume"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Kisume]);


        //GMR
        public static bool gerdsLabLoaded;
        public static Mod gerdsLabMod;
        //BOSSES
        public static Condition DownedTrerios = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTrerios"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Trerios]);
        public static Condition DownedMagmaEye = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMagmaEye"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MagmaEye]);
        public static Condition DownedJack = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJack"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Jack]);
        public static Condition DownedAcheron = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAcheron"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Acheron]);


        //HEARTBEATARIA
        public static bool heartbeatariaLoaded;
        public static Mod heartbeatariaMod;


        //HOMEWARD JOURNEY
        public static bool homewardJourneyLoaded;
        public static Mod homewardJourneyMod;
        //BOSSES
        public static Condition DownedGoblinChariot = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGoblinChariot"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GoblinChariot]);
        public static Condition DownedBigDipper = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBigDipper"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BigDipper]);
        public static Condition DownedPuppetOpera = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPuppetOpera"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PuppetOpera]);
        public static Condition DownedMarquisMoonsquid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMarquisMoonsquid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MarquisMoonsquid]);
        public static Condition DownedPriestessRod = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPriestessRod"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PriestessRod]);
        public static Condition DownedDiver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDiver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Diver]);
        public static Condition DownedMotherbrain = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMotherbrain"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Motherbrain]);
        public static Condition DownedWallOfShadow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWallOfShadow"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfShadow]);
        public static Condition DownedSunSlimeGod = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSunSlimeGod"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SunSlimeGod]);
        public static Condition DownedOverwatcher = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOverwatcher"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Overwatcher]);
        public static Condition DownedLifebringer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLifebringer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lifebringer]);
        public static Condition DownedMaterealizer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMaterealizer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Materealizer]);
        public static Condition DownedScarabBelief = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedScarabBelief"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ScarabBelief]);
        public static Condition DownedWorldsEndWhale = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWorldsEndWhale"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WorldsEndWhale]);
        public static Condition DownedSon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Son]);
        //EVENTS
        public static Condition DownedCaveOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCaveOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CaveOrdeal]);
        public static Condition DownedCorruptOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCorruptOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CorruptOrdeal]);
        public static Condition DownedCrimsonOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCrimsonOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CrimsonOrdeal]);
        public static Condition DownedDesertOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDesertOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DesertOrdeal]);
        public static Condition DownedForestOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForestOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ForestOrdeal]);
        public static Condition DownedHallowOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHallowOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HallowOrdeal]);
        public static Condition DownedJungleOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJungleOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.JungleOrdeal]);
        public static Condition DownedSkyOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSkyOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SkyOrdeal]);
        public static Condition DownedSnowOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSnowOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SnowOrdeal]);
        public static Condition DownedUnderworldOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUnderworldOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.UnderworldOrdeal]);
        public static Condition DownedOrdealAny = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOrdealAny"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CaveOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.CorruptOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.CrimsonOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.DesertOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.ForestOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.HallowOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.JungleOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.SkyOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.SnowOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.UnderworldOrdeal]);
        //BIOMES
        public static Condition HasBeenToHomewardAbyss = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToHomewardAbyss"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.HomewardJourneyAbyss]);
        public static Condition HasBeenToMaze = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToMaze"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Maze]);


        //HUNT OF THE OLD GOD
        public static bool huntOfTheOldGodLoaded;
        public static Mod huntOfTheOldGodMod;
        //BOSSES
        public static Condition DownedGoozma = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGoozma"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Goozma]);


        //INFECTED QUALITIES
        public static bool infectedQualitiesLoaded;
        public static Mod infectedQualitiesMod;


        //INFERNUM
        public static bool infernumLoaded;
        public static Mod infernumMod;
        //BOSSES
        public static Condition DownedBereftVassal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBereftVassal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal]);
        //BIOMES
        public static Condition HasBeenToProfanedGardens = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToProfanedGardens"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.ProfanedGardens]);


        //LUIAFK
        public static bool luiAFKLoaded;
        public static Mod luiAFKMod;


        //LUIAFK DLC
        public static bool luiAFKDLCLoaded;
        public static Mod luiAFKDLCMod;


        //LUNAR VEIL
        public static bool lunarVeilLoaded;
        public static Mod lunarVeilMod;
        //BOSSES
        public static Condition DownedStoneGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStoneGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StoneGuardian]);
        public static Condition DownedCommanderGintzia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCommanderGintzia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CommanderGintzia]);
        public static Condition DownedSunStalker = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSunStalker"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SunStalker]);
        public static Condition DownedPumpkinJack = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPumpkinJack"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PumpkinJack]);
        public static Condition DownedForgottenPuppetDaedus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForgottenPuppetDaedus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ForgottenPuppetDaedus]);
        public static Condition DownedDreadMire = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDreadMire"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DreadMire]);
        public static Condition DownedSingularityFragment = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSingularityFragment"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SingularityFragment]);
        public static Condition DownedVerlia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVerlia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Verlia]);
        public static Condition DownedIrradia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIrradia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Irradia]);
        public static Condition DownedSylia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSylia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Sylia]);
        public static Condition DownedFenix = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFenix"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Fenix]);
        //MINIBOSSES
        public static Condition DownedBlazingSerpent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlazingSerpent"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BlazingSerpent]);
        public static Condition DownedCogwork = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCogwork"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cogwork]);
        public static Condition DownedWaterCogwork = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWaterCogwork"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WaterCogwork]);
        public static Condition DownedWaterJellyfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWaterJellyfish"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WaterJellyfish]);
        public static Condition DownedSparn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSparn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Sparn]);
        public static Condition DownedPandorasFlamebox = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPandorasFlamebox"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PandorasFlamebox]);
        public static Condition DownedSTARBOMBER = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSTARBOMBER"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.STARBOMBER]);
        public static Condition DownedWaterJellyfishOrWaterCogwork = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWaterJellyfishOrWaterCogwork"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WaterCogwork] || ModConditions.DownedBoss[(int)ModConditions.Downed.WaterJellyfish]);
        public static Condition DownedCogworkOrSparn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCogworkOrSparn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cogwork] || ModConditions.DownedBoss[(int)ModConditions.Downed.Sparn]);
        public static Condition DownedBlazingSerpentOrPandorasFlamebox = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlazingSerpentOrPandorasFlamebox"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BlazingSerpent] || ModConditions.DownedBoss[(int)ModConditions.Downed.PandorasFlamebox]);
        //EVENTS
        public static Condition DownedGintzeArmy = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGintzeArmy"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.GintzeArmy]);
        //BIOMES
        public static Condition HasBeenToLunarVeilAbyss = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToLunarVeilAbyss"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Abysm]);


        //MAGIC STORAGE
        public static bool magicStorageLoaded;
        public static Mod magicStorageMod;


        //MARTAINS ORDER
        public static bool martainsOrderLoaded;
        public static Mod martainsOrderMod;
        //BOSSES
        public static Condition DownedBritzz = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBritzz"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Britzz]);
        public static Condition DownedCactusCat = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCactusCat"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CactusCat]);
        public static Condition DownedTheAlchemist = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTheAlchemist"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TheAlchemist]);
        public static Condition DownedCarnagePillar = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCarnagePillar"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CarnagePillar]);
        public static Condition DownedVoidDigger = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVoidDigger"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.VoidDigger]);
        public static Condition DownedPrinceSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrinceSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PrinceSlime]);
        public static Condition DownedTriplets = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTriplets"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets]);
        public static Condition DownedJungleDefenders = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJungleDefenders"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.JungleDefenders]);
        //EVENTS
        public static Condition DownedHauntedRainforest = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHauntedRainforest"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.HauntedRainforest]);


        //MECH REWORK
        public static bool mechReworkLoaded;
        public static Mod mechReworkMod;
        //BOSSES
        public static Condition DownedSt4sys = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSt4sys"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.St4sys]);
        public static Condition DownedTerminator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTerminator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Terminator]);
        public static Condition DownedCaretaker = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCaretaker"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Caretaker]);
        public static Condition DownedSiegeEngine = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSiegeEngine"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SiegeEngine]);


        //MEDIAL RIFT
        public static bool medialRiftLoaded;
        public static Mod medialRiftMod;
        //BOSSES
        public static Condition DownedSuperVoltaicMotherSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSuperVoltaicMotherSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SuperVMS]);


        //METROID MOD
        public static bool metroidLoaded;
        public static Mod metroidMod;
        //BOSSES
        public static Condition DownedTorizo = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTorizo"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Torizo]);
        public static Condition DownedSerris = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSerris"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Serris]);
        public static Condition DownedKraid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKraid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Kraid]);
        public static Condition DownedPhantoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPhantoon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Phantoon]);
        public static Condition DownedOmegaPirate = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaPirate"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaPirate]);
        public static Condition DownedNightmare = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNightmare"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nightmare]);
        public static Condition DownedGoldenTorizo = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGoldenTorizo"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GoldenTorizo]);


        //MOOMOO'S ULTIMATE YOYO REVAMP
        public static bool moomoosUltimateYoyoRevampLoaded;
        public static Mod moomoosUltimateYoyoRevampMod;


        //MR PLAGUE'S RACES
        public static bool mrPlagueRacesLoaded;
        public static Mod mrPlagueRacesMod;


        //ORCHID MOD
        public static bool orchidLoaded;
        public static Mod orchidMod;


        //OPHIOID MOD
        public static bool ophioidLoaded;
        public static Mod ophioidMod;
        //BOSSES
        public static Condition DownedOphiopede = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOphiopede"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiopede]);
        public static Condition DownedOphiocoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOphiocoon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiocoon]);
        public static Condition DownedOphiofly = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOphiofly"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiofly]);


        //POLARITIES
        public static bool polaritiesLoaded;
        public static Mod polaritiesMod;
        //BOSSES
        public static Condition DownedStormCloudfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStormCloudfish"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloudfish]);
        public static Condition DownedStarConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StarConstruct]);
        public static Condition DownedGigabat = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGigabat"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Gigabat]);
        public static Condition DownedSunPixie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSunPixie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SunPixie]);
        public static Condition DownedEsophage = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEsophage"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Esophage]);
        public static Condition DownedConvectiveWanderer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedConvectiveWanderer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ConvectiveWanderer]);


        //PROJECT ZERO
        public static bool projectZeroLoaded;
        public static Mod projectZeroMod;
        //BOSSES
        public static Condition DownedForestGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForestGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ForestGuardian]);
        public static Condition DownedCryoGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCryoGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CryoGuardian]);
        public static Condition DownedPrimordialWorm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrimordialWorm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PrimordialWorm]);
        public static Condition DownedTheGuardianOfHell = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTheGuardianOfHell"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TheGuardianOfHell]);
        public static Condition DownedVoid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVoid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Void]);
        public static Condition DownedArmagem = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedArmagem"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Armagem]);


        //QWERTY
        public static bool qwertyLoaded;
        public static Mod qwertyMod;
        //BOSSES
        public static Condition DownedPolarExterminator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPolarExterminator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PolarExterminator]);
        public static Condition DownedDivineLight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDivineLight"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DivineLight]);
        public static Condition DownedAncientMachine = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientMachine"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientMachine]);
        public static Condition DownedNoehtnap = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNoehtnap"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Noehtnap]);
        public static Condition DownedHydra = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHydra"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Hydra]);
        public static Condition DownedImperious = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedImperious"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Imperious]);
        public static Condition DownedRuneGhost = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRuneGhost"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.RuneGhost]);
        public static Condition DownedInvaderBattleship = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInvaderBattleship"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderBattleship]);
        public static Condition DownedInvaderNoehtnap = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInvaderNoehtnap"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderNoehtnap]);
        public static Condition DownedOLORD = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOLORD"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OLORD]);
        //MINIBOSSES
        public static Condition DownedGreatTyrannosaurus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGreatTyrannosaurus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GreatTyrannosaurus]);
        //EVENTS
        public static Condition DownedDinoMilitia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDinoMilitia"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.DinoMilitia]);
        public static Condition DownedInvaders = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInvaders"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.SpaceInvaders]);
        //BIOMES
        public static Condition HasBeenToSkyFortress = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSkyFortress"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SkyFortress]);


        //RAGNAROK
        public static bool ragnarokLoaded;
        public static Mod ragnarokMod;


        //REDEMPTION
        public static bool redemptionLoaded;
        public static Mod redemptionMod;
        //BOSSES
        public static Condition DownedThorn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedThorn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Thorn]);
        public static Condition DownedErhan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedErhan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Erhan]);
        public static Condition DownedKeeper = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKeeper"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Keeper]);
        public static Condition DownedSeedOfInfection = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeedOfInfection"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SeedOfInfection]);
        public static Condition DownedKingSlayerIII = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKingSlayerIII"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.KingSlayerIII]);
        public static Condition DownedOmegaCleaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaCleaver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaCleaver]);
        public static Condition DownedOmegaGigapora = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaGigapora"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaGigapora]);
        public static Condition DownedOmegaObliterator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaObliterator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaObliterator]);
        public static Condition DownedPatientZero = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPatientZero"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PatientZero]);
        public static Condition DownedAkka = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAkka"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Akka]);
        public static Condition DownedUkko = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUkko"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ukko]);
        public static Condition DownedAncientDeityDuo = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientDeityDuo"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientDeityDuo]);
        public static bool downedNebuleus;
        public static Condition DownedNebuleus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNebuleus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nebuleus]);
        //MINIBOSSES
        public static Condition DownedFowlEmperor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFowlEmperor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FowlEmperor]);
        public static Condition DownedCockatrice = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCockatrice"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cockatrice]);
        public static Condition DownedBasan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBasan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Basan]);
        public static Condition DownedSkullDigger = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSkullDigger"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SkullDigger]);
        public static Condition DownedEaglecrestGolem = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEaglecrestGolem"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EaglecrestGolem]);
        public static Condition DownedCalavia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCalavia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Calavia]);
        public static Condition DownedTheJanitor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTheJanitor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TheJanitor]);
        public static Condition DownedIrradiatedBehemoth = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIrradiatedBehemoth"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.IrradiatedBehemoth]);
        public static Condition DownedBlisterface = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlisterface"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Blisterface]);
        public static Condition DownedProtectorVolt = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProtectorVolt"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ProtectorVolt]);
        public static Condition DownedMACEProject = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMACEProject"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MACEProject]);
        //EVENTS
        public static Condition DownedFowlMorning = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFowlMorning"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.FowlMorning]);
        public static Condition DownedRaveyard = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRaveyard"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Raveyard]);
        //BIOMES
        public static Condition HasBeenToLab = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToLab"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AbandonedLab]);
        public static Condition HasBeenToWasteland = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToWasteland"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Wasteland]);


        //REFORGED - DURABILITY MOD
        public static bool reforgedLoaded;
        public static Mod reforgedMod;


        //REMNANTS
        public static bool remnantsLoaded;
        public static Mod remnantsMod;


        //RUPTURE
        public static bool ruptureLoaded;
        public static Mod ruptureMod;


        //SECRETS OF THE SHADOWS
        public static bool secretsOfTheShadowsLoaded;
        public static Mod secretsOfTheShadowsMod;
        //BOSSES
        public static Condition DownedPutridPinky = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPutridPinky"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PutridPinky]);
        public static Condition DownedGlowmoth = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlowmoth"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Glowmoth]);
        public static Condition DownedPharaohsCurse = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPharaohsCurse"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PharaohsCurse]);
        public static Condition DownedExcavator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedExcavator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Excavator]);
        public static Condition DownedAdvisor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAdvisor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Advisor]);
        public static Condition DownedPolaris = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPolaris"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Polaris]);
        public static Condition DownedLux = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLux"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lux]);
        public static Condition DownedSubspaceSerpent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSubspaceSerpent"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SubspaceSerpent]);
        //MINIBOSSES
        public static Condition DownedNatureConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNatureConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NatureConstruct]);
        public static Condition DownedEarthenConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEarthenConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenConstruct]);
        public static Condition DownedPermafrostConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPermafrostConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostConstruct]);
        public static Condition DownedTidalConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTidalConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TidalConstruct]);
        public static Condition DownedOtherworldlyConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOtherworldlyConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlyConstruct]);
        public static Condition DownedEvilConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEvilConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EvilConstruct]);
        public static Condition DownedInfernoConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfernoConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoConstruct]);
        public static Condition DownedChaosConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChaosConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosConstruct]);
        public static Condition DownedNatureSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNatureSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NatureSpirit]);
        public static Condition DownedEarthenSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEarthenSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenSpirit]);
        public static Condition DownedPermafrostSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPermafrostSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostSpirit]);
        public static Condition DownedTidalSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTidalSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TidalSpirit]);
        public static Condition DownedOtherworldlySpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOtherworldlySpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlySpirit]);
        public static Condition DownedEvilSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEvilSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EvilSpirit]);
        public static Condition DownedInfernoSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfernoSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoSpirit]);
        public static Condition DownedChaosSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChaosSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosSpirit]);
        //BIOMES
        public static Condition HasBeenToPyramid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToPyramid"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CursedPyramid]);
        public static Condition HasBeenToPlanetarium = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToPlanetarium"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Planetarium]);


        //SHADOWS OF ABADDON
        public static bool shadowsOfAbaddonLoaded;
        public static Mod shadowsOfAbaddonMod;
        //BOSSES
        public static Condition DownedDecree = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDecree"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Decree]);
        public static Condition DownedFlamingPumpkin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFlamingPumpkin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FlamingPumpkin]);
        public static Condition DownedZombiePiglinBrute = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedZombiePiglinBrute"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ZombiePiglinBrute]);
        public static Condition DownedJensenTheGrandHarpy = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJensenTheGrandHarpy"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.JensenTheGrandHarpy]);
        public static Condition DownedAraneas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAraneas"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Araneas]);
        public static Condition DownedHarpyQueenRaynare = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHarpyQueenRaynare"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyQueenRaynare]);
        public static Condition DownedPrimordia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrimordia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Primordia]);
        public static Condition DownedAbaddon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAbaddon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Abaddon]);
        public static Condition DownedAraghur = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAraghur"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Araghur]);
        public static Condition DownedLostSiblings = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLostSiblings"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LostSiblings]);
        public static Condition DownedErazor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedErazor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Erazor]);
        public static Condition DownedNihilus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNihilus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nihilus]);
        //BIOMES
        public static Condition HasBeenToCinderForest = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCinderForest"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CinderForest]);
        public static Condition HasBeenToInfernalDepths = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToInfernalDepths"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.InfernalDepths]);


        //SLOOME
        public static bool sloomeLoaded;
        public static Mod sloomeMod;
        //BOSSES
        public static Condition DownedExodygen = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedExodygen"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Exodygen]);


        //SPIRIT
        public static bool spiritLoaded;
        public static Mod spiritMod;
        //BOSSES
        public static Condition DownedScarabeus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedScarabeus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Scarabeus]);
        public static Condition DownedMoonJellyWizard = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMoonJellyWizard"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MoonJellyWizard]);
        public static Condition DownedVinewrathBane = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVinewrathBane"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.VinewrathBane]);
        public static Condition DownedAncientAvian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientAvian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientAvian]);
        public static Condition DownedStarplateVoyager = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarplateVoyager"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StarplateVoyager]);
        public static Condition DownedInfernon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfernon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Infernon]);
        public static Condition DownedDusking = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDusking"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dusking]);
        public static Condition DownedAtlas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAtlas"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Atlas]);
        //EVENTS
        public bool waitForJellyDeluge;
        public static Condition DownedJellyDeluge = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJellyDeluge"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.JellyDeluge]);
        public static Condition DownedTide = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTide"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.TheTide]);
        public bool waitForMysticMoon;
        public static Condition DownedMysticMoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMysticMoon"), () => ModConditions.DownedEvents[(int)ModConditions.DownedEvent.MysticMoon]);
        //BIOMES
        public static Condition HasBeenToBriar = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToBriar"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Briar]);
        public static Condition HasBeenToSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpirit"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpiritSurface]);
        public static Condition HasBeenToSpiritUnderground = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpiritUnderground"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpiritUnderground]);


        //SPOOKY
        public static bool spookyLoaded;
        public static Mod spookyMod;
        //BOSSES
        public static Condition DownedSpookySpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSpookySpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SpookySpirit]);
        public static Condition DownedRotGourd = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRotGourd"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.RotGourd]);
        public static Condition DownedMoco = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMoco"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Moco]);
        public static Condition DownedDaffodil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDaffodil"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Daffodil]);
        public static Condition DownedOrroBoro = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOrroBoro"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OrroBoro]);
        public static Condition DownedBigBone = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBigBone"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BigBone]);
        //BIOMES
        public static Condition HasBeenToSpookyForest = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpookyForest"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpookyForest]);
        public static Condition HasBeenToSpookyUnderground = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpookyUnderground"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpookyUnderground]);
        public static Condition HasBeenToEyeValley = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToEyeValley"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.ValleyOfEyes]);
        public static Condition HasBeenToSpiderCave = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpiderCave"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpiderGrotto]);
        public static Condition HasBeenToCatacombs = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCatacombs"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CreepyCatacombs]);
        public static Condition HasBeenToCemetery = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCemetery"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SwampyCemetery]);


        //STARLIGHT RIVER
        public static bool starlightRiverLoaded;
        public static Mod starlightRiverMod;
        //BOSSES
        public static Condition DownedAuroracle = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAuroracle"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Auroracle]);
        public static Condition DownedCeiros = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCeiros"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ceiros]);
        //MINIBOSSES
        public static Condition DownedGlassweaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlassweaver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Glassweaver]);
        //BIOMES
        public static Condition HasBeenToAuroracleTemple = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAuroracleTemple"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AuroraTemple]);
        public static Condition HasBeenToVitricDesert = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToVitricDesert"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.VitricDesert]);
        public static Condition HasBeenToVitricTemple = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToVitricTemple"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.VitricTemple]);


        //STARS ABOVE
        public static bool starsAboveLoaded;
        public static Mod starsAboveMod;
        //BOSSES
        public static Condition DownedVagrantofSpace = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVagrantofSpace"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.VagrantofSpace]);
        public static Condition DownedThespian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedThespian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Thespian]);
        public static Condition DownedDioskouroi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDioskouroi"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dioskouroi]);
        public static Condition DownedNalhaun = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNalhaun"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nalhaun]);
        public static Condition DownedStarfarers = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarfarers"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Starfarers]);
        public static Condition DownedPenthesilea = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPenthesilea"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Penthesilea]);
        public static Condition DownedArbitration = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedArbitration"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Arbitration]);
        public static Condition DownedWarriorOfLight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWarriorOfLight"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WarriorOfLight]);
        public static Condition DownedTsukiyomi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTsukiyomi"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Tsukiyomi]);


        //STORM DIVERS MOD
        public static bool stormsAdditionsLoaded;
        public static Mod stormsAdditionsMod;
        //BOSSES
        public static Condition DownedAncientHusk = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientHusk"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientHusk]);
        public static Condition DownedOverloadedScandrone = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOverloadedScandrone"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OverloadedScandrone]);
        public static Condition DownedPainbringer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPainbringer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Painbringer]);


        //STRAMS CLASSES
        public static bool stramsClassesLoaded;
        public static Mod stramsClassesMod;


        //STRAMS SURVIVAL
        public static bool stramsSurvivalLoaded;
        public static Mod stramsSurvivalMod;


        //SUPERNOVA
        public static bool supernovaLoaded;
        public static Mod supernovaMod;
        //BOSSES
        public static Condition DownedHarbingerOfAnnihilation = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHarbingerOfAnnihilation"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HarbingerOfAnnihilation]);
        public static Condition DownedFlyingTerror = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFlyingTerror"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FlyingTerror]);
        public static Condition DownedStoneMantaRay = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStoneMantaRay"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StoneMantaRay]);
        //MINIBOSSES
        public static Condition DownedBloodweaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBloodweaver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodweaver]);


        //TERRORBORN
        public static bool terrorbornLoaded;
        public static Mod terrorbornMod;
        //BOSSES
        public static Condition DownedInfectedIncarnate = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfectedIncarnate"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InfectedIncarnate]);
        public static Condition DownedTidalTitan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTidalTitan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TidalTitan]);
        public static Condition DownedDunestock = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDunestock"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dunestock]);
        public static Condition DownedHexedConstructor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHexedConstructor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HexedConstructor]);
        public static Condition DownedShadowcrawler = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedShadowcrawler"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Shadowcrawler]);
        public static Condition DownedPrototypeI = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrototypeI"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PrototypeI]);


        //THORIUM
        public static bool thoriumLoaded;
        public static Mod thoriumMod;
        //BOSSES
        public static Condition DownedGrandThunderBird = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGrandThunderBird"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GrandThunderBird]);
        public static Condition DownedQueenJellyfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedQueenJellyfish"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.QueenJellyfish]);
        public static Condition DownedViscount = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedViscount"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Viscount]);
        public static Condition DownedGraniteEnergyStorm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGraniteEnergyStorm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GraniteEnergyStorm]);
        public static Condition DownedBuriedChampion = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBuriedChampion"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BuriedChampion]);
        public static Condition DownedStarScouter = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarScouter"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StarScouter]);
        public static Condition DownedBoreanStrider = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBoreanStrider"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BoreanStrider]);
        public static Condition DownedFallenBeholder = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFallenBeholder"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FallenBeholder]);
        public static Condition DownedLich = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLich"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lich]);
        public static Condition DownedForgottenOne = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForgottenOne"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ForgottenOne]);
        public static Condition DownedPrimordials = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrimordials"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Primordials]);
        //MINIBOSSES
        public static Condition DownedPatchWerk = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPatchWerk"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PatchWerk]);
        public static Condition DownedCorpseBloom = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCorpseBloom"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CorpseBloom]);
        public static Condition DownedIllusionist = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIllusionist"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Illusionist]);
        //BIOMES
        public static Condition HasBeenToAquaticDepths = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAquaticDepths"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AquaticDepths]);


        //THORIUM BOSSES REWORK
        public static bool thoriumBossReworkLoaded;
        public static Mod thoriumBossReworkMod;


        //THORIUM EXHAUSTION DISABLER
        public static bool exhaustionDisablerLoaded;
        public static Mod exhaustionDisablerMod;


        //THROWER UNIFICATION
        public static bool throwerUnificationLoaded;
        public static Mod throwerUnificationMod;


        //TRAE
        public static bool traeLoaded;
        public static Mod traeMod;
        //MINIBOSSES
        public static Condition DownedGraniteOvergrowth = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGraniteOvergrowth"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GraniteOvergrowth]);
        public static Condition DownedBeholder = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBeholder"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Beholder]);


        //UHTRIC
        public static bool uhtricLoaded;
        public static Mod uhtricMod;
        //BOSSES
        public static Condition DownedDredger = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDredger"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dredger]);
        public static Condition DownedCharcoolSnowman = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCharcoolSnowman"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CharcoolSnowman]);
        public static Condition DownedCosmicMenace = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCosmicMenace"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CosmicMenace]);


        //UNIVERSE OF SWORDS
        public static bool universeOfSwordsLoaded;
        public static Mod universeOfSwordsMod;
        //BOSSES
        public static Condition DownedEvilFlyingBlade = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEvilFlyingBlade"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EvilFlyingBlade]);


        //VALHALLA
        public static bool valhallaLoaded;
        public static Mod valhallaMod;
        //BOSSES
        public static Condition DownedColossalCarnage = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedColossalCarnage"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ColossalCarnage]);
        public static Condition DownedYurnero = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedYurnero"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Yurnero]);


        //VERDANT
        public static bool verdantLoaded;
        public static Mod verdantMod;
        //BIOMES
        public static Condition HasBeenToVerdant = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToVerdant"), () => ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Verdant]);


        //VITALITY
        public static bool vitalityLoaded;
        public static Mod vitalityMod;
        //BOSSES
        public static Condition DownedStormCloud = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStormCloud"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloud]);
        public static Condition DownedGrandAntlion = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGrandAntlion"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GrandAntlion]);
        public static Condition DownedGemstoneElemental = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGemstoneElemental"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GemstoneElemental]);
        public static Condition DownedMoonlightDragonfly = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMoonlightDragonfly"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MoonlightDragonfly]);
        public static Condition DownedDreadnaught = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDreadnaught"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dreadnaught]);
        public static Condition DownedMosquitoMonarch = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMosquitoMonarch"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MosquitoMonarch]);
        public static Condition DownedAnarchulesBeetle = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAnarchulesBeetle"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AnarchulesBeetle]);
        public static Condition DownedChaosbringer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChaosbringer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Chaosbringer]);
        public static Condition DownedPaladinSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPaladinSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PaladinSpirit]);


        //WAYFAIR CONTENT
        public static bool wayfairContentLoaded;
        public static Mod wayfairContentMod;
        //BOSSES
        public static Condition DownedManaflora = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedManaflora"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Manaflora]);


        //WRATH OF THE GODS
        public static bool wrathOfTheGodsLoaded;
        public static Mod wrathOfTheGodsMod;
        //BOSSES
        public static Condition DownedXG07Mars = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.DownedXG07Mars"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.XG07Mars]);
        public static Condition DownedAvatarOfEmptiness = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAvatarOfEmptiness"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AvatarOfEmptiness]);
        public static Condition DownedNamelessDeityOfLight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNamelessDeityOfLight"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NamelessDeityOfLight]);


        //ZYLON
        public static bool zylonLoaded;
        public static Mod zylonMod;
        //BOSSES
        public static Condition DownedDirtball = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDirtball"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dirtball]);
        public static Condition DownedMetelord = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMetelord"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Metelord]);
        public static Condition DownedAdeneb = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAdeneb"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Adeneb]);
        public static Condition DownedEldritchJellyfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEldritchJellyfish"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EldritchJellyfish]);
        public static Condition DownedSaburRex = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSaburRex"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SaburRex]);


        public enum Downed
        {
            //vanilla
            Dreadnautilus,
            MartianSaucer,
            //Aequus
            Crabson,
            OmegaStarite,
            DustDevil,
            HyperStarite,
            UltraStarite,
            RedSprite,
            SpaceSquid,
            //afkpets
            SlayerOfEvil,
            SATLA,
            DrFetus,
            SlimesHope,
            PoliticianSlime,
            AncientTrio,
            LavalGolem,
            Antony,
            BunnyZeppelin,
            Okiku,
            HarpyAirforce,
            Isaac,
            AncientGuardian,
            HeroicSlime,
            HoloSlime,
            SecurityBot,
            UndeadChef,
            NekoSlime,
            NightmareAmplifierSlime,
            GuardianOfFrost,
            //assorted crazy things
            SoulHarvester,
            //awful garbage
            TreeToad,
            SeseKitsugai,
            EyeOfTheStorm,
            Frigidius,
            //blocks core boss
            CoreBoss,
            //calamity
            DesertScourge,
            Crabulon,
            HiveMind,
            Perforators,
            SlimeGod,
            Cryogen,
            AquaticScourge,
            BrimstoneElemental,
            CalamitasClone,
            LeviathanAndAnahita,
            AstrumAureus,
            PlaguebringerGoliath,
            Ravager,
            AstrumDeus,
            ProfanedGuardians,
            Dragonfolly,
            Providence,
            StormWeaver,
            CeaselessVoid,
            Signus,
            Polterghast,
            OldDuke,
            DevourerOfGods,
            Yharon,
            ExoMechs,
            SupremeCalamitas,
            GiantClam,
            CragmawMire,
            GreatSandShark,
            NuclearTerror,
            Mauler,
            PrimordialWyrm,
            //calamity community remix
            WulfrumExcavator,
            //calamity entropy
            Luminaris,
            Prophet,
            NihilityTwin,
            Cruiser,
            //catalyst
            Astrageldon,
            //clamity
            Clamitas,
            Pyrogen,
            WallOfBronze,
            //consolaria
            Lepus,
            Turkor,
            Ocram,
            //coralite
            Rediancie,
            BabyIceDragon,
            SlimeEmperor,
            Bloodiancie,
            ThunderveinDragon,
            NightmarePlantera,
            //depths
            Chasme,
            //dormant dawn
            LifeGuardian,
            ManaGuardian,
            MeteorExcavator,
            MeteorAnnihilator,
            HellfireSerpent,
            WitheredAcornSpirit,
            GoblinSorcererChieftain,
            //echoes of the ancients
            Galahis,
            Creation,
            Destruction,
            //edorbis
            BlightKing,
            Gardener,
            Glaciation,
            HandOfCthulhu,
            CursePreacher,
            //exalt
            Effulgence,
            IceLich,
            //excelsior
            Niflheim,
            StellarStarship,
            //exxo avalon origins
            BacteriumPrime,
            DesertBeak,
            KingSting,
            Mechasting,
            Phantasm,
            //fargos
            TrojanSquirrel,
            CursedCoffin,
            Deviantt,
            Lifelight,
            BanishedBaron,
            Eridanus,
            Abominationn,
            Mutant,
            //fractures of penumbra
            AlphaFrostjaw,
            SanguineElemental,
            //gameterraria
            Lad,
            Hornlitz,
            SnowDon,
            Stoffie,
            //gensokyo
            LilyWhite,
            Rumia,
            EternityLarva,
            Nazrin,
            HinaKagiyama,
            Sekibanki,
            Seiran,
            NitoriKawashiro,
            MedicineMelancholy,
            Cirno,
            MinamitsuMurasa,
            AliceMargatroid,
            SakuyaIzayoi,
            SeijaKijin,
            MayumiJoutouguu,
            ToyosatomimiNoMiko,
            KaguyaHouraisan,
            UtsuhoReiuji,
            TenshiHinanawi,
            Kisume,
            //gerds lab
            Trerios,
            MagmaEye,
            Jack,
            Acheron,
            //homeward journey
            GoblinChariot,
            BigDipper,
            PuppetOpera,
            MarquisMoonsquid,
            PriestessRod,
            Diver,
            Motherbrain,
            WallOfShadow,
            SunSlimeGod,
            Overwatcher,
            Lifebringer,
            Materealizer,
            ScarabBelief,
            WorldsEndWhale,
            Son,
            CaveOrdeal,
            CorruptOrdeal,
            CrimsonOrdeal,
            DesertOrdeal,
            ForestOrdeal,
            HallowOrdeal,
            JungleOrdeal,
            SkyOrdeal,
            SnowOrdeal,
            UnderworldOrdeal,
            //hunt of the old god
            Goozma,
            //infernum
            BereftVassal,
            //lunar veil
            StoneGuardian,
            CommanderGintzia,
            SunStalker,
            PumpkinJack,
            ForgottenPuppetDaedus,
            DreadMire,
            SingularityFragment,
            Verlia,
            Irradia,
            Sylia,
            Fenix,
            BlazingSerpent,
            Cogwork,
            WaterCogwork,
            WaterJellyfish,
            Sparn,
            PandorasFlamebox,
            STARBOMBER,
            //martains order
            Britzz,
            CactusCat,
            TheAlchemist,
            CarnagePillar,
            VoidDigger,
            PrinceSlime,
            Triplets,
            JungleDefenders,
            //mech rework
            St4sys,
            Terminator,
            Caretaker,
            SiegeEngine,
            //medial rift
            SuperVMS,
            //metroid
            Torizo,
            Serris,
            Kraid,
            Phantoon,
            OmegaPirate,
            Nightmare,
            GoldenTorizo,
            //ophioid
            Ophiopede,
            Ophiocoon,
            Ophiofly,
            //polarities
            StormCloudfish,
            StarConstruct,
            Gigabat,
            SunPixie,
            Esophage,
            ConvectiveWanderer,
            //project zero
            ForestGuardian,
            CryoGuardian,
            PrimordialWorm,
            TheGuardianOfHell,
            Void,
            Armagem,
            //qwerty
            PolarExterminator,
            DivineLight,
            AncientMachine,
            Noehtnap,
            Hydra,
            Imperious,
            RuneGhost,
            InvaderBattleship,
            InvaderNoehtnap,
            OLORD,
            GreatTyrannosaurus,
            //redemption
            Thorn,
            Erhan,
            Keeper,
            SeedOfInfection,
            KingSlayerIII,
            OmegaCleaver,
            OmegaGigapora,
            OmegaObliterator,
            PatientZero,
            Akka,
            Ukko,
            AncientDeityDuo,
            Nebuleus,
            FowlEmperor,
            Cockatrice,
            Basan,
            SkullDigger,
            EaglecrestGolem,
            Calavia,
            TheJanitor,
            IrradiatedBehemoth,
            Blisterface,
            ProtectorVolt,
            MACEProject,
            //secrets of the shadows
            PutridPinky,
            Glowmoth,
            PharaohsCurse,
            Excavator,
            Advisor,
            Polaris,
            Lux,
            SubspaceSerpent,
            NatureConstruct,
            EarthenConstruct,
            PermafrostConstruct,
            TidalConstruct,
            OtherworldlyConstruct,
            EvilConstruct,
            InfernoConstruct,
            ChaosConstruct,
            NatureSpirit,
            EarthenSpirit,
            PermafrostSpirit,
            TidalSpirit,
            OtherworldlySpirit,
            EvilSpirit,
            InfernoSpirit,
            ChaosSpirit,
            //shadows of abaddon
            Decree,
            FlamingPumpkin,
            ZombiePiglinBrute,
            JensenTheGrandHarpy,
            Araneas,
            HarpyQueenRaynare,
            Primordia,
            Abaddon,
            Araghur,
            LostSiblings,
            Erazor,
            Nihilus,
            //sloome
            Exodygen,
            //spirit
            Scarabeus,
            MoonJellyWizard,
            VinewrathBane,
            AncientAvian,
            StarplateVoyager,
            Infernon,
            Dusking,
            Atlas,
            //spooky
            SpookySpirit,
            RotGourd,
            Moco,
            Daffodil,
            OrroBoro,
            BigBone,
            //starlight river
            Auroracle,
            Ceiros,
            Glassweaver,
            //stars above
            VagrantofSpace,
            Thespian,
            Dioskouroi,
            Nalhaun,
            Starfarers,
            Penthesilea,
            Arbitration,
            WarriorOfLight,
            Tsukiyomi,
            //storms additions
            AncientHusk,
            OverloadedScandrone,
            Painbringer,
            //supernova
            HarbingerOfAnnihilation,
            FlyingTerror,
            StoneMantaRay,
            Bloodweaver,
            //terrorborn
            InfectedIncarnate,
            TidalTitan,
            Dunestock,
            HexedConstructor,
            Shadowcrawler,
            PrototypeI,
            //thorium
            GrandThunderBird,
            QueenJellyfish,
            Viscount,
            GraniteEnergyStorm,
            BuriedChampion,
            StarScouter,
            BoreanStrider,
            FallenBeholder,
            Lich,
            ForgottenOne,
            Primordials,
            PatchWerk,
            CorpseBloom,
            Illusionist,
            //trae
            GraniteOvergrowth,
            Beholder,
            //uhtric
            Dredger,
            CharcoolSnowman,
            CosmicMenace,
            //universe of swords
            EvilFlyingBlade,
            //valhalla
            ColossalCarnage,
            Yurnero,
            //vitality
            StormCloud,
            GrandAntlion,
            GemstoneElemental,
            MoonlightDragonfly,
            Dreadnaught,
            MosquitoMonarch,
            AnarchulesBeetle,
            Chaosbringer,
            PaladinSpirit,
            //wayfair
            Manaflora,
            //wrath of the gods
            XG07Mars,
            AvatarOfEmptiness,
            NamelessDeityOfLight,
            //zylon
            Dirtball,
            Metelord,
            Adeneb,
            EldritchJellyfish,
            SaburRex
        }

        public static bool[] DownedBoss = new bool[Enum.GetValues(typeof(Downed)).Length];

        public enum DownedEvent
        {
            //Vanilla
            BloodMoon,
            Eclipse,
            LunarTowers,
            Night,
            //Aequus
            DemonSiege,
            Glimmer,
            GaleStreams,
            //Calamity
            AcidRainAny,
            AcidRainTier1,
            AcidRainTier2,
            BossRush,
            //Lunar Veil
            GintzeArmy,
            //Martin's Order
            HauntedRainforest,
            //Qwerty
            DinoMilitia,
            SpaceInvaders,
            //Redemption
            FowlMorning,
            Raveyard,
            //Spirit Classic
            JellyDeluge,
            TheTide,
            MysticMoon,
            //Spooky
            EggIncursion,
            PandorasBox
        };

        public static bool[] DownedEvents = new bool[Enum.GetValues(typeof(DownedEvent)).Length];

        public enum Biomes
        {
            //Vanilla
            Forest,
            Underground,
            Caverns,
            Sky,
            Tundra,
            Desert,
            Jungle,
            Ocean,
            GlowingMushroom,
            Corruption,
            Crimson,
            Hallow,
            Underworld,
            Aether,
            Dungeon,
            Temple,
            //Aequus
            CrabCrevice,
            //Calamity
            BrimstoneCrags,
            AstralInfection,
            SunkenSea,
            SulphurSea,
            CalamityAbyss,
            CalamityAbyssLayer1,
            CalamityAbyssLayer2,
            CalamityAbyssLayer3,
            CalamityAbyssLayer4,
            //Calamity Vanities
            AstralBlight,
            //Clamity
            FrozenHell,
            //Confection REBAKED
            Confection,
            //Depths
            Depths,
            //Everjade
            JadeLake,
            //Exxo Avalon Origins
            Contagion,
            //Fractures of Penumbra
            Dread,
            //Homeward Journey
            HomewardJourneyAbyss,
            Maze,
            //Infernum
            ProfanedGardens,
            //Lunar Veil
            Abysm,
            Cinderspark,
            Fable,
            Ishtar,
            RoyalCapital,
            Veil,
            Virulent,
            //Martin's Order
            Rainforest,
            DeepCaves,
            ColdDesert,
            Void,
            //Qwerty
            SkyFortress,
            //Redemption
            AbandonedLab,
            Wasteland,
            //Secrets of the Shadows
            CursedPyramid,
            Planetarium,
            Sanctuary,
            AbandonedVillage,
            //Shadows of Abaddon
            EmpressDen,
            CinderForest,
            InfernalDepths,
            //Spirit Classic
            Briar,
            SpiritSurface,
            SpiritUnderground,
            //Spooky
            SpookyForest,
            SpookyUnderground,
            SpiderGrotto,
            CreepyCatacombs,
            LowerCatacombs,
            SwampyCemetery,
            TempleOfMoco,
            ValleyOfEyes,
            //StarlightRiver
            AuroraTemple,
            VitricDesert,
            VitricTemple,
            //Stars Above
            NeonVeil,
            //Thorium
            AquaticDepths,
            //Verdant
            Verdant
        };

        public static bool[] VisitedBiomes = new bool[Enum.GetValues(typeof(Biomes)).Length];
        #endregion

        public override void Unload()
        {
            DownedBoss = null;
            DownedEvents = null;
            VisitedBiomes = null;
        }

        public override void OnWorldLoad() => ResetDowned();

        public override void OnWorldUnload() => ResetDowned();

        public override void PreUpdatePlayers()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || Main.netMode == NetmodeID.Server || QoLCompendium.mainConfig.RemoveBiomeShopRequirements)
            {
                for (int i = 0; i < VisitedBiomes.Length; i++)
                    VisitedBiomes[i] = true;
            }

            #region Vanilla Events
            //BLOOD MOON
            if (Main.bloodMoon && !waitForBloodMoon)
                waitForBloodMoon = true;
            if (waitForBloodMoon && !Main.bloodMoon && Main.dayTime)
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.BloodMoon] = true;
            if (waitForBloodMoon && !Main.bloodMoon && !Main.dayTime)
                waitForBloodMoon = false;

            //ECLIPSE
            if (Main.eclipse && !waitForEclipse)
                waitForEclipse = true;
            if (waitForEclipse && !Main.eclipse && !Main.dayTime)
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Eclipse] = true;
            if (waitForEclipse && !Main.eclipse && Main.dayTime)
                waitForEclipse = false;

            //LUNAR TOWERS
            if (NPC.downedTowerNebula && NPC.downedTowerSolar && NPC.downedTowerStardust && NPC.downedTowerVortex)
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.LunarTowers] = true;

            //NIGHT
            if (!Main.dayTime)
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Night] = true;
            #endregion

            #region Vanilla Biomes
            if (Main.LocalPlayer.ZoneForest)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Forest] = true;
            }
            if (Main.LocalPlayer.ZoneNormalUnderground)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Underground] = true;
            }
            if (Main.LocalPlayer.ZoneNormalCaverns)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Caverns] = true;
            }
            if (Main.LocalPlayer.ZoneUnderworldHeight)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Underworld] = true;
            }
            if (Main.LocalPlayer.ZoneSkyHeight)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Sky] = true;
            }
            if (Main.LocalPlayer.ZoneSnow)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Tundra] = true;
            }
            if (Main.LocalPlayer.ZoneDesert || Main.LocalPlayer.ZoneUndergroundDesert)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Desert] = true;
            }
            if (Main.LocalPlayer.ZoneBeach)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Ocean] = true;
            }
            if (Main.LocalPlayer.ZoneJungle)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Jungle] = true;
            }
            if (Main.LocalPlayer.ZoneGlowshroom)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.GlowingMushroom] = true;
            }
            if (Main.LocalPlayer.ZoneCorrupt)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Corruption] = true;
            }
            if (Main.LocalPlayer.ZoneCrimson)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Crimson] = true;
            }
            if (Main.LocalPlayer.ZoneHallow)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Hallow] = true;
            }
            if (Main.LocalPlayer.ZoneLihzhardTemple)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Temple] = true;
            }
            if (Main.LocalPlayer.ZoneDungeon)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Dungeon] = true;
            }
            if (Main.LocalPlayer.ZoneShimmer)
            {
                ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Aether] = true;
            }
            #endregion

            if (aequusLoaded)
            {
                #region Bosses & Events
                ModConditions.DownedBoss[(int)ModConditions.Downed.Crabson] = (bool)aequusMod.Call("downedCrabson");
                ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaStarite] = (bool)aequusMod.Call("downedOmegaStarite");
                ModConditions.DownedBoss[(int)ModConditions.Downed.DustDevil] = (bool)aequusMod.Call("downedDustDevil");
                ModConditions.DownedBoss[(int)ModConditions.Downed.RedSprite] = (bool)aequusMod.Call("downedRedSprite");
                ModConditions.DownedBoss[(int)ModConditions.Downed.SpaceSquid] = (bool)aequusMod.Call("downedSpaceSquid");
                ModConditions.DownedBoss[(int)ModConditions.Downed.HyperStarite] = (bool)aequusMod.Call("downedHyperStarite");
                ModConditions.DownedBoss[(int)ModConditions.Downed.UltraStarite] = (bool)aequusMod.Call("downedUltraStarite");
                //Events
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.DemonSiege] = (bool)aequusMod.Call("downedEventDemon");
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Glimmer] = (bool)aequusMod.Call("downedEventCosmic");
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.GaleStreams] = (bool)aequusMod.Call("downedEventAtmosphere");
                #endregion

                #region Biomes
                if (aequusMod.TryFind("CrabCreviceBiome", out ModBiome CrabCreviceBiome) && Main.LocalPlayer.InModBiome(CrabCreviceBiome))
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CrabCrevice] = true;
                #endregion
            }

            if (calamityLoaded)
            {
                #region Bosses & Events
                //Bosses
                ModConditions.DownedBoss[(int)ModConditions.Downed.DesertScourge] = (bool)calamityMod.Call("GetBossDowned", "DesertScourge");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Crabulon] = (bool)calamityMod.Call("GetBossDowned", "Crabulon");
                ModConditions.DownedBoss[(int)ModConditions.Downed.HiveMind] = (bool)calamityMod.Call("GetBossDowned", "HiveMind");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Perforators] = (bool)calamityMod.Call("GetBossDowned", "Perforator");
                ModConditions.DownedBoss[(int)ModConditions.Downed.SlimeGod] = (bool)calamityMod.Call("GetBossDowned", "SlimeGod");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Cryogen] = (bool)calamityMod.Call("GetBossDowned", "Cryogen");
                ModConditions.DownedBoss[(int)ModConditions.Downed.AquaticScourge] = (bool)calamityMod.Call("GetBossDowned", "AquaticScourge");
                ModConditions.DownedBoss[(int)ModConditions.Downed.BrimstoneElemental] = (bool)calamityMod.Call("GetBossDowned", "BrimstoneElemental");
                ModConditions.DownedBoss[(int)ModConditions.Downed.CalamitasClone] = (bool)calamityMod.Call("GetBossDowned", "CalamitasClone");
                ModConditions.DownedBoss[(int)ModConditions.Downed.LeviathanAndAnahita] = (bool)calamityMod.Call("GetBossDowned", "AnahitaLeviathan");
                ModConditions.DownedBoss[(int)ModConditions.Downed.AstrumAureus] = (bool)calamityMod.Call("GetBossDowned", "AstrumAureus");
                ModConditions.DownedBoss[(int)ModConditions.Downed.PlaguebringerGoliath] = (bool)calamityMod.Call("GetBossDowned", "PlaguebringerGoliath");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Ravager] = (bool)calamityMod.Call("GetBossDowned", "Ravager");
                ModConditions.DownedBoss[(int)ModConditions.Downed.AstrumDeus] = (bool)calamityMod.Call("GetBossDowned", "AstrumDeus");
                ModConditions.DownedBoss[(int)ModConditions.Downed.ProfanedGuardians] = (bool)calamityMod.Call("GetBossDowned", "Guardians");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Dragonfolly] = (bool)calamityMod.Call("GetBossDowned", "Dragonfolly");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Providence] = (bool)calamityMod.Call("GetBossDowned", "Providence");
                ModConditions.DownedBoss[(int)ModConditions.Downed.StormWeaver] = (bool)calamityMod.Call("GetBossDowned", "StormWeaver");
                ModConditions.DownedBoss[(int)ModConditions.Downed.CeaselessVoid] = (bool)calamityMod.Call("GetBossDowned", "CeaselessVoid");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Signus] = (bool)calamityMod.Call("GetBossDowned", "Signus");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Polterghast] = (bool)calamityMod.Call("GetBossDowned", "Polterghast");
                ModConditions.DownedBoss[(int)ModConditions.Downed.OldDuke] = (bool)calamityMod.Call("GetBossDowned", "OldDuke");
                ModConditions.DownedBoss[(int)ModConditions.Downed.DevourerOfGods] = (bool)calamityMod.Call("GetBossDowned", "DevourerOfGods");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Yharon] = (bool)calamityMod.Call("GetBossDowned", "Yharon");
                ModConditions.DownedBoss[(int)ModConditions.Downed.ExoMechs] = (bool)calamityMod.Call("GetBossDowned", "ExoMechs");
                ModConditions.DownedBoss[(int)ModConditions.Downed.SupremeCalamitas] = (bool)calamityMod.Call("GetBossDowned", "SupremeCalamitas");
                //Minibosses
                ModConditions.DownedBoss[(int)ModConditions.Downed.GiantClam] = (bool)calamityMod.Call("GetBossDowned", "GiantClam");
                ModConditions.DownedBoss[(int)ModConditions.Downed.CragmawMire] = (bool)calamityMod.Call("GetBossDowned", "cragmawmire");
                ModConditions.DownedBoss[(int)ModConditions.Downed.GreatSandShark] = (bool)calamityMod.Call("GetBossDowned", "GreatSandShark");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Mauler] = (bool)calamityMod.Call("GetBossDowned", "mauler");
                ModConditions.DownedBoss[(int)ModConditions.Downed.NuclearTerror] = (bool)calamityMod.Call("GetBossDowned", "nuclearterror");
                ModConditions.DownedBoss[(int)ModConditions.Downed.PrimordialWyrm] = (bool)calamityMod.Call("GetBossDowned", "primordialwyrm");
                //Events
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.AcidRainTier1] = (bool)calamityMod.Call("GetBossDowned", "acidraineoc");
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.AcidRainTier2] = (bool)calamityMod.Call("GetBossDowned", "acidrainscourge");
                ModConditions.DownedEvents[(int)ModConditions.DownedEvent.BossRush] = (bool)calamityMod.Call("GetBossDowned", "bossrush");
                #endregion

                #region Biomes
                if (calamityMod.TryFind("AstralInfectionBiome", out ModBiome AstralInfectionBiome) && Main.LocalPlayer.InModBiome(AstralInfectionBiome))
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AstralInfection] = true;

                if (calamityMod.TryFind("AbyssLayer1Biome", out ModBiome AbyssLayer1Biome) && Main.LocalPlayer.InModBiome(AbyssLayer1Biome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyss] = true;
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer1] = true;
                }
                if (calamityMod.TryFind("AbyssLayer2Biome", out ModBiome AbyssLayer2Biome) && Main.LocalPlayer.InModBiome(AbyssLayer2Biome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyss] = true;
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer2] = true;
                }

                if (calamityMod.TryFind("AbyssLayer3Biome", out ModBiome AbyssLayer3Biome) && Main.LocalPlayer.InModBiome(AbyssLayer3Biome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyss] = true;
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer3] = true;
                }
                if (calamityMod.TryFind("AbyssLayer4Biome", out ModBiome AbyssLayer4Biome) && Main.LocalPlayer.InModBiome(AbyssLayer4Biome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyss] = true;
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CalamityAbyssLayer4] = true;
                }

                if (calamityMod.TryFind("BrimstoneCragsBiome", out ModBiome BrimstoneCragsBiome) && Main.LocalPlayer.InModBiome(BrimstoneCragsBiome))
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.BrimstoneCrags] = true;

                if (calamityMod.TryFind("SulphurousSeaBiome", out ModBiome SulphurousSeaBiome) && Main.LocalPlayer.InModBiome(SulphurousSeaBiome))
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SulphurSea] = true;

                if (calamityMod.TryFind("SunkenSeaBiome", out ModBiome SunkenSeaBiome) && Main.LocalPlayer.InModBiome(SunkenSeaBiome))
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SunkenSea] = true;
                #endregion
            }

            if (calamityVanitiesLoaded)
            {
                if (calamityVanitiesMod.TryFind("AstralBlight", out ModBiome AstralBlight) && Main.LocalPlayer.InModBiome(AstralBlight))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AstralBlight] = true;
                }
            }

            if (confectionRebakedLoaded)
            {
                if ((confectionRebakedMod.TryFind("ConfectionBiome", out ModBiome ConfectionBiome) && Main.LocalPlayer.InModBiome(ConfectionBiome))
                    || (confectionRebakedMod.TryFind("ConfectionUndergroundBiome", out ModBiome ConfectionUndergroundBiome) && Main.LocalPlayer.InModBiome(ConfectionUndergroundBiome))
                    || (confectionRebakedMod.TryFind("IceConfectionSurfaceBiome", out ModBiome IceConfectionSurfaceBiome) && Main.LocalPlayer.InModBiome(IceConfectionSurfaceBiome))
                    || (confectionRebakedMod.TryFind("IceConfectionUndergroundBiome", out ModBiome IceConfectionUndergroundBiome) && Main.LocalPlayer.InModBiome(IceConfectionUndergroundBiome))
                    || (confectionRebakedMod.TryFind("SandConfectionSurfaceBiome", out ModBiome SandConfectionSurfaceBiome) && Main.LocalPlayer.InModBiome(SandConfectionSurfaceBiome))
                    || (confectionRebakedMod.TryFind("SandConfectionUndergroundBiome", out ModBiome SandConfectionUndergroundBiome) && Main.LocalPlayer.InModBiome(SandConfectionUndergroundBiome)))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Confection] = true;
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Hallow] = true;
                }
            }

            if (depthsLoaded)
            {
                if (depthsMod.TryFind("DepthsBiome", out ModBiome DepthsBiome) && Main.LocalPlayer.InModBiome(DepthsBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Depths] = true;
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Underworld] = true;
                }
            }

            if (everjadeLoaded)
            {
                if (everjadeMod.TryFind("JadeLakeBiome", out ModBiome JadeLakeBiome) && Main.LocalPlayer.InModBiome(JadeLakeBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.JadeLake] = true;
                }
            }

            if (exxoAvalonOriginsLoaded)
            {
                if ((exxoAvalonOriginsMod.TryFind("Contagion", out ModBiome Contagion) && Main.LocalPlayer.InModBiome(Contagion))
                    || (exxoAvalonOriginsMod.TryFind("UndergroundContagion", out ModBiome UndergroundContagion) && Main.LocalPlayer.InModBiome(UndergroundContagion))
                    || (exxoAvalonOriginsMod.TryFind("ContagionDesert", out ModBiome ContagionDesert) && Main.LocalPlayer.InModBiome(ContagionDesert))
                    || (exxoAvalonOriginsMod.TryFind("ContagionCaveDesert", out ModBiome ContagionCaveDesert) && Main.LocalPlayer.InModBiome(ContagionCaveDesert)))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Contagion] = true;
                }
            }

            if (fracturesOfPenumbraLoaded)
            {
                if ((fracturesOfPenumbraMod.TryFind("DreadSurfaceBiome", out ModBiome DreadSurfaceBiome) && Main.LocalPlayer.InModBiome(DreadSurfaceBiome))
                    || (fracturesOfPenumbraMod.TryFind("DreadUndergroundBiome", out ModBiome DreadUndergroundBiome) && Main.LocalPlayer.InModBiome(DreadUndergroundBiome)))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Dread] = true;
                }
            }

            if (homewardJourneyLoaded)
            {
                if (homewardJourneyMod.TryFind("AbyssUndergroundBiome", out ModBiome AbyssUndergroundBiome) && Main.LocalPlayer.InModBiome(AbyssUndergroundBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.HomewardJourneyAbyss] = true;
                }
                if (homewardJourneyMod.TryFind("MazeBiome", out ModBiome MazeBiome) && Main.LocalPlayer.InModBiome(MazeBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Maze] = true;
                }
            }

            if (infernumLoaded)
            {
                if (infernumMod.TryFind("ProfanedTempleBiome", out ModBiome ProfanedTempleBiome) && Main.LocalPlayer.InModBiome(ProfanedTempleBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.ProfanedGardens] = true;
                }
            }

            if (lunarVeilLoaded)
            {
                if (lunarVeilMod.TryFind("AbyssBiome", out ModBiome AbyssBiome) && Main.LocalPlayer.InModBiome(AbyssBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Abysm] = true;
                }
            }

            if (martainsOrderLoaded)
            {
                if (martainsOrderMod.TryFind("RainforestBiome", out ModBiome RainforestBiome) && Main.LocalPlayer.InModBiome(RainforestBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Rainforest] = true;
                }
                if (martainsOrderMod.TryFind("DepthsBiome", out ModBiome DepthsBiome) && Main.LocalPlayer.InModBiome(DepthsBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.DeepCaves] = true;
                }
                if (martainsOrderMod.TryFind("ColdDesertBiome", out ModBiome ColdDesertBiome) && Main.LocalPlayer.InModBiome(ColdDesertBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.ColdDesert] = true;
                }
                if ((martainsOrderMod.TryFind("VoidBiome", out ModBiome VoidBiome) && Main.LocalPlayer.InModBiome(VoidBiome)) || (martainsOrderMod.TryFind("VoidDBiome", out ModBiome VoidDBiome) && Main.LocalPlayer.InModBiome(VoidDBiome)) || (martainsOrderMod.TryFind("VoidIceBiome", out ModBiome VoidIceBiome) && Main.LocalPlayer.InModBiome(VoidIceBiome)) || (martainsOrderMod.TryFind("VoidUGBiome", out ModBiome VoidUGBiome) && Main.LocalPlayer.InModBiome(VoidUGBiome)) || (martainsOrderMod.TryFind("VoidUGDBiome", out ModBiome VoidUGDBiome) && Main.LocalPlayer.InModBiome(VoidUGDBiome)))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Void] = true;
                }
            }

            if (qwertyLoaded)
            {
                if (qwertyMod.TryFind("FortressBiome", out ModBiome FortressBiome) && Main.LocalPlayer.InModBiome(FortressBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SkyFortress] = true;
                }
            }

            if (redemptionLoaded)
            {
                if (redemptionMod.TryFind("LabBiome", out ModBiome LabBiome) && Main.LocalPlayer.InModBiome(LabBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AbandonedLab] = true;
                }
                if (redemptionMod.TryFind("WastelandPurityBiome", out ModBiome WastelandPurityBiome) && Main.LocalPlayer.InModBiome(WastelandPurityBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Wasteland] = true;
                }
            }

            if (secretsOfTheShadowsLoaded)
            {
                if (secretsOfTheShadowsMod.TryFind("PyramidBiome", out ModBiome PyramidBiome) && Main.LocalPlayer.InModBiome(PyramidBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CursedPyramid] = true;
                }
                if (secretsOfTheShadowsMod.TryFind("PlanetariumBiome", out ModBiome PlanetariumBiome) && Main.LocalPlayer.InModBiome(PlanetariumBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Planetarium] = true;
                }
                if (secretsOfTheShadowsMod.TryFind("AbandonedVillageBiome", out ModBiome AbandonedVillageBiome) && Main.LocalPlayer.InModBiome(AbandonedVillageBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AbandonedVillage] = true;
                }
                if (secretsOfTheShadowsMod.TryFind("SanctuaryBiome", out ModBiome SanctuaryBiome) && Main.LocalPlayer.InModBiome(SanctuaryBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Sanctuary] = true;
                }
            }

            if (shadowsOfAbaddonLoaded)
            {
                if ((shadowsOfAbaddonMod.TryFind("CinderDesertBiome", out ModBiome CinderDesertBiome) && Main.LocalPlayer.InModBiome(CinderDesertBiome)) || (shadowsOfAbaddonMod.TryFind("CinderForestBiome", out ModBiome CinderForestBiome) && Main.LocalPlayer.InModBiome(CinderForestBiome)))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CinderForest] = true;
                }

                if ((shadowsOfAbaddonMod.TryFind("CinderForestUndergroundBiome", out ModBiome CinderForestUndergroundBiome) && Main.LocalPlayer.InModBiome(CinderForestUndergroundBiome)))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.InfernalDepths] = true;
                }
            }

            if (spiritLoaded)
            {
                if ((spiritMod.TryFind("BriarSurfaceBiome", out ModBiome BriarSurfaceBiome) && Main.LocalPlayer.InModBiome(BriarSurfaceBiome))
                    || (spiritMod.TryFind("BriarUndergroundBiome", out ModBiome BriarUndergroundBiome) && Main.LocalPlayer.InModBiome(BriarUndergroundBiome)))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Briar] = true;
                }
                if (spiritMod.TryFind("SpiritSurfaceBiome", out ModBiome SpiritSurfaceBiome) && Main.LocalPlayer.InModBiome(SpiritSurfaceBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpiritSurface] = true;
                }
                if (spiritMod.TryFind("SpiritUndergroundBiome", out ModBiome SpiritUndergroundBiome) && Main.LocalPlayer.InModBiome(SpiritUndergroundBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpiritUnderground] = true;
                }
            }

            if (spookyLoaded)
            {
                if (spookyMod.TryFind("SpookyBiome", out ModBiome SpookyBiome) && Main.LocalPlayer.InModBiome(SpookyBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpookyForest] = true;
                }
                if (spookyMod.TryFind("SpookyBiomeUg", out ModBiome SpookyBiomeUg) && Main.LocalPlayer.InModBiome(SpookyBiomeUg))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpookyUnderground] = true;
                }
                if (spookyMod.TryFind("SpookyHellBiome", out ModBiome SpookyHellBiome) && Main.LocalPlayer.InModBiome(SpookyHellBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.ValleyOfEyes] = true;
                }
                if (spookyMod.TryFind("SpiderCaveBiome", out ModBiome SpiderCaveBiome) && Main.LocalPlayer.InModBiome(SpiderCaveBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SpiderGrotto] = true;
                }
                if (spookyMod.TryFind("CatacombBiome", out ModBiome CatacombBiome) && Main.LocalPlayer.InModBiome(CatacombBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.CreepyCatacombs] = true;
                }
                if (spookyMod.TryFind("CatacombBiome2", out ModBiome CatacombBiome2) && Main.LocalPlayer.InModBiome(CatacombBiome2))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.LowerCatacombs] = true;
                }
                if (spookyMod.TryFind("CemeteryBiome", out ModBiome CemeteryBiome) && Main.LocalPlayer.InModBiome(CemeteryBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.SwampyCemetery] = true;
                }
                if (spookyMod.TryFind("NoseTempleBiome", out ModBiome NoseTempleBiome) && Main.LocalPlayer.InModBiome(NoseTempleBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.TempleOfMoco] = true;
                }
            }

            if (starlightRiverLoaded)
            {
                if (starlightRiverMod.TryFind("PermafrostTempleBiome", out ModBiome PermafrostTempleBiome) && Main.LocalPlayer.InModBiome(PermafrostTempleBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AuroraTemple] = true;
                }
                if (starlightRiverMod.TryFind("VitricDesertBiome", out ModBiome VitricDesertBiome) && Main.LocalPlayer.InModBiome(VitricDesertBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.VitricDesert] = true;
                }
                if (starlightRiverMod.TryFind("VitricTempleBiome", out ModBiome VitricTempleBiome) && Main.LocalPlayer.InModBiome(VitricTempleBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.VitricTemple] = true;
                }
            }

            if (starsAboveLoaded)
            {
                ModConditions.DownedBoss[(int)ModConditions.Downed.VagrantofSpace] = (bool)starsAboveMod.Call("downedVagrant", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.Thespian] = (bool)starsAboveMod.Call("downedThespian", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.Dioskouroi] = (bool)starsAboveMod.Call("downedDioskouroi", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.Nalhaun] = (bool)starsAboveMod.Call("downedNalhaun", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.Starfarers] = (bool)starsAboveMod.Call("downedStarfarers", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.Penthesilea] = (bool)starsAboveMod.Call("downedPenthesilea", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.Arbitration] = (bool)starsAboveMod.Call("downedArbitration", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.WarriorOfLight] = (bool)starsAboveMod.Call("downedWarriorOfLight", Mod);
                ModConditions.DownedBoss[(int)ModConditions.Downed.Tsukiyomi] = (bool)starsAboveMod.Call("downedTsukiyomi", Mod);
            }

            if (thoriumLoaded)
            {
                #region Bosses
                ModConditions.DownedBoss[(int)ModConditions.Downed.GrandThunderBird] = (bool)thoriumMod.Call("GetDownedBoss", "TheGrandThunderBird");
                ModConditions.DownedBoss[(int)ModConditions.Downed.QueenJellyfish] = (bool)thoriumMod.Call("GetDownedBoss", "QueenJellyfish");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Viscount] = (bool)thoriumMod.Call("GetDownedBoss", "Viscount");
                ModConditions.DownedBoss[(int)ModConditions.Downed.GraniteEnergyStorm] = (bool)thoriumMod.Call("GetDownedBoss", "GraniteEnergyStorm");
                ModConditions.DownedBoss[(int)ModConditions.Downed.BuriedChampion] = (bool)thoriumMod.Call("GetDownedBoss", "BuriedChampion");
                ModConditions.DownedBoss[(int)ModConditions.Downed.StarScouter] = (bool)thoriumMod.Call("GetDownedBoss", "StarScouter");
                ModConditions.DownedBoss[(int)ModConditions.Downed.BoreanStrider] = (bool)thoriumMod.Call("GetDownedBoss", "BoreanStrider");
                ModConditions.DownedBoss[(int)ModConditions.Downed.FallenBeholder] = (bool)thoriumMod.Call("GetDownedBoss", "FallenBeholder");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Lich] = (bool)thoriumMod.Call("GetDownedBoss", "Lich");
                ModConditions.DownedBoss[(int)ModConditions.Downed.ForgottenOne] = (bool)thoriumMod.Call("GetDownedBoss", "ForgottenOne");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Primordials] = (bool)thoriumMod.Call("GetDownedBoss", "ThePrimordials");
                ModConditions.DownedBoss[(int)ModConditions.Downed.PatchWerk] = (bool)thoriumMod.Call("GetDownedBoss", "PatchWerk");
                ModConditions.DownedBoss[(int)ModConditions.Downed.CorpseBloom] = (bool)thoriumMod.Call("GetDownedBoss", "CorpseBloom");
                ModConditions.DownedBoss[(int)ModConditions.Downed.Illusionist] = (bool)thoriumMod.Call("GetDownedBoss", "Illusionist");
                #endregion

                #region Biomes
                if (thoriumMod.TryFind("DepthsBiome", out ModBiome DepthsBiome) && Main.LocalPlayer.InModBiome(DepthsBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.AquaticDepths] = true;
                }
                #endregion
            }

            if (verdantLoaded)
            {
                if (verdantMod.TryFind("VerdantBiome", out ModBiome VerdantBiome) && Main.LocalPlayer.InModBiome(VerdantBiome))
                {
                    ModConditions.VisitedBiomes[(int)ModConditions.Biomes.Verdant] = true;
                }
            }

            if (wrathOfTheGodsLoaded)
            {
                ModConditions.DownedBoss[(int)ModConditions.Downed.XG07Mars] = (bool)wrathOfTheGodsMod.Call("GetBossDefeated", "mars");
                ModConditions.DownedBoss[(int)ModConditions.Downed.AvatarOfEmptiness] = (bool)wrathOfTheGodsMod.Call("GetBossDefeated", "avatarofemptiness");
                ModConditions.DownedBoss[(int)ModConditions.Downed.NamelessDeityOfLight] = (bool)wrathOfTheGodsMod.Call("GetBossDefeated", "namelessdeity");
            }
        }

        public override void SaveWorldData(TagCompound tag)
        {
            //BOSSES
            tag.Add("QoLCDownedBosses", DownedBoss);
            //EVENTS
            tag.Add("QoLCDownedEvents", DownedEvents);
            //BIOMES
            tag.Add("QoLCVisitedBiomes", VisitedBiomes);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            //BOSSES
            DownedBoss = tag.Get<bool[]>("QoLCDownedBosses");
            if (DownedBoss.Length < Enum.GetValues(typeof(Downed)).Length)
                Array.Resize(ref DownedBoss, Enum.GetValues(typeof(Downed)).Length);

            //EVENTS
            DownedEvents = tag.Get<bool[]>("QoLCDownedEvents");
            if (DownedEvents.Length < Enum.GetValues(typeof(DownedEvent)).Length)
                Array.Resize(ref DownedEvents, Enum.GetValues(typeof(DownedEvent)).Length);

            //BIOMES
            VisitedBiomes = tag.Get<bool[]>("QoLCVisitedBiomes");
            if (VisitedBiomes.Length < Enum.GetValues(typeof(Biomes)).Length)
                Array.Resize(ref VisitedBiomes, Enum.GetValues(typeof(Biomes)).Length);
        }

        public override void NetSend(BinaryWriter writer)
        {
            //BOSSES
            BitsByte downedBoss = new();
            for (int i = 0; i < DownedBoss.Length; i++)
            {
                int bit = i % 8;

                if (bit == 0 && i != 0)
                {
                    writer.Write(downedBoss);
                    downedBoss = new BitsByte();
                }

                downedBoss[bit] = DownedBoss[i];
            }
            writer.Write(downedBoss);

            //EVENTS
            BitsByte downedEvent = new();
            for (int i = 0; i < DownedEvents.Length; i++)
            {
                int bit = i % 8;

                if (bit == 0 && i != 0)
                {
                    writer.Write(downedEvent);
                    downedEvent = new BitsByte();
                }

                downedEvent[bit] = DownedEvents[i];
            }
            writer.Write(downedEvent);

            //BIOMES
            BitsByte vistedBiome = new();
            for (int i = 0; i < VisitedBiomes.Length; i++)
            {
                int bit = i % 8;

                if (bit == 0 && i != 0)
                {
                    writer.Write(vistedBiome);
                    vistedBiome = new BitsByte();
                }

                vistedBiome[bit] = VisitedBiomes[i];
            }
            writer.Write(vistedBiome);
        }

        public override void NetReceive(BinaryReader reader)
        {
            //BOSSES
            BitsByte downedBoss = reader.ReadByte();
            for (int i = 0; i < DownedBoss.Length; i++)
            {
                int bits = i % 8;
                if (bits == 0)
                    downedBoss = reader.ReadByte();

                DownedBoss[i] = downedBoss[bits];
            }

            //EVENTS
            BitsByte downedEvent = reader.ReadByte();
            for (int i = 0; i < DownedEvents.Length; i++)
            {
                int bits = i % 8;
                if (bits == 0)
                    downedEvent = reader.ReadByte();

                DownedEvents[i] = downedEvent[bits];
            }

            //BIOMES
            BitsByte vistedBiome = reader.ReadByte();
            for (int i = 0; i < VisitedBiomes.Length; i++)
            {
                int bits = i % 8;
                if (bits == 0)
                    vistedBiome = reader.ReadByte();

                VisitedBiomes[i] = vistedBiome[bits];
            }
        }

        public static void ResetDowned()
        {
            for (int i = 0; i < DownedBoss.Length; i++)
                DownedBoss[i] = false;

            for (int i = 0; i < DownedEvents.Length; i++)
                DownedEvents[i] = false;

            for (int i = 0; i < VisitedBiomes.Length; i++)
                VisitedBiomes[i] = false;
        }

        public static void LoadSupportedMods()
        {
            aequusLoaded = ModLoader.TryGetMod("Aequus", out Mod Aequus);
            aequusMod = Aequus;

            afkpetsLoaded = ModLoader.TryGetMod("AFKPETS", out Mod AFKPETS);
            afkpetsMod = AFKPETS;

            amuletOfManyMinionsLoaded = ModLoader.TryGetMod("AmuletOfManyMinions", out Mod AmuletOfManyMinions);
            amuletOfManyMinionsMod = AmuletOfManyMinions;

            arbourLoaded = ModLoader.TryGetMod("Arbour", out Mod Arbour);
            arbourMod = Arbour;

            assortedCrazyThingsLoaded = ModLoader.TryGetMod("AssortedCrazyThings", out Mod AssortedCrazyThings);
            assortedCrazyThingsMod = AssortedCrazyThings;

            awfulGarbageLoaded = ModLoader.TryGetMod("AwfulGarbageMod", out Mod AwfulGarbageMod);
            awfulGarbageMod = AwfulGarbageMod;

            blocksArsenalLoaded = ModLoader.TryGetMod("Arsenal_Mod", out Mod Arsenal_Mod);
            blocksArsenalMod = Arsenal_Mod;

            blocksArtificerLoaded = ModLoader.TryGetMod("ArtificerMod", out Mod ArtificerMod);
            blocksArtificerMod = ArtificerMod;

            blocksCoreBossLoaded = ModLoader.TryGetMod("CorruptionBoss", out Mod CorruptionBoss);
            blocksCoreBossMod = CorruptionBoss;

            blocksInfoAccessoriesLoaded = ModLoader.TryGetMod("BInfoAcc", out Mod BInfoAcc);
            blocksInfoAccessoriesMod = BInfoAcc;

            blocksThrowerLoaded = ModLoader.TryGetMod("BCThrower", out Mod BCThrower);
            blocksThrowerMod = BCThrower;

            bombusApisLoaded = ModLoader.TryGetMod("BombusApisBee", out Mod BombusApisBee);
            bombusApisMod = BombusApisBee;

            buffariaLoaded = ModLoader.TryGetMod("Buffaria", out Mod Buffaria);
            buffariaMod = Buffaria;

            calamityLoaded = ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod);
            calamityMod = CalamityMod;

            calamityCommunityRemixLoaded = ModLoader.TryGetMod("CalRemix", out Mod CalRemix);
            calamityCommunityRemixMod = CalRemix;

            calamityEntropyLoaded = ModLoader.TryGetMod("CalamityEntropy", out Mod CalamityEntropy);
            calamityEntropyMod = CalamityEntropy;

            calamityOverhaulLoaded = ModLoader.TryGetMod("CalamityOverhaul", out Mod CalamityOverhaul);
            calamityOverhaulMod = CalamityOverhaul;

            calamityVanitiesLoaded = ModLoader.TryGetMod("CalValEX", out Mod CalValEX);
            calamityVanitiesMod = CalValEX;

            captureDiscsClassLoaded = ModLoader.TryGetMod("CaptureDiscClass", out Mod CaptureDiscClass);
            captureDiscsClassMod = CaptureDiscClass;

            catalystLoaded = ModLoader.TryGetMod("CatalystMod", out Mod CatalystMod);
            catalystMod = CatalystMod;

            cerebralLoaded = ModLoader.TryGetMod("CerebralMod", out Mod CerebralMod);
            cerebralMod = CerebralMod;

            clamityAddonLoaded = ModLoader.TryGetMod("Clamity", out Mod Clamity);
            clamityAddonMod = Clamity;

            clickerClassLoaded = ModLoader.TryGetMod("ClickerClass", out Mod ClickerClass);
            clickerClassMod = ClickerClass;

            confectionRebakedLoaded = ModLoader.TryGetMod("TheConfectionRebirth", out Mod TheConfectionRebirth);
            confectionRebakedMod = TheConfectionRebirth;

            consolariaLoaded = ModLoader.TryGetMod("Consolaria", out Mod Consolaria);
            consolariaMod = Consolaria;

            coraliteLoaded = ModLoader.TryGetMod("Coralite", out Mod Coralite);
            coraliteMod = Coralite;

            crystalDragonsLoaded = ModLoader.TryGetMod("CrystalDragons", out Mod CrystalDragons);
            crystalDragonsMod = CrystalDragons;

            depthsLoaded = ModLoader.TryGetMod("TheDepths", out Mod TheDepths);
            depthsMod = TheDepths;

            dormantDawnLoaded = ModLoader.TryGetMod("DDmod", out Mod DDmod);
            dormantDawnMod = DDmod;

            draedonExpansionLoaded = ModLoader.TryGetMod("DraedonExpansion", out Mod DraedonExpansion);
            draedonExpansionMod = DraedonExpansion;

            dragonBallTerrariaLoaded = ModLoader.TryGetMod("DBZMODPORT", out Mod DBZMODPORT);
            dragonBallTerrariaMod = DBZMODPORT;

            echoesOfTheAncientsLoaded = ModLoader.TryGetMod("EchoesoftheAncients", out Mod EchoesoftheAncients);
            echoesOfTheAncientsMod = EchoesoftheAncients;

            edorbisLoaded = ModLoader.TryGetMod("Edorbis", out Mod Edorbis);
            edorbisMod = Edorbis;

            enchantedMoonsLoaded = ModLoader.TryGetMod("BlueMoon", out Mod BlueMoon);
            enchantedMoonsMod = BlueMoon;

            everjadeLoaded = ModLoader.TryGetMod("JadeFables", out Mod JadeFables);
            everjadeMod = JadeFables;

            exaltLoaded = ModLoader.TryGetMod("ExaltMod", out Mod ExaltMod);
            exaltMod = ExaltMod;

            excelsiorLoaded = ModLoader.TryGetMod("excels", out Mod excels);
            excelsiorMod = excels;

            exxoAvalonOriginsLoaded = ModLoader.TryGetMod("Avalon", out Mod Avalon);
            exxoAvalonOriginsMod = Avalon;

            fargosMutantLoaded = ModLoader.TryGetMod("Fargowiltas", out Mod Fargowiltas);
            fargosMutantMod = Fargowiltas;

            fargosSoulsLoaded = ModLoader.TryGetMod("FargowiltasSouls", out Mod FargowiltasSouls);
            fargosSoulsMod = FargowiltasSouls;

            fargosSoulsDLCLoaded = ModLoader.TryGetMod("FargowiltasCrossmod", out Mod FargowiltasCrossmod);
            fargosSoulsDLCMod = FargowiltasCrossmod;

            fargosSoulsExtrasLoaded = ModLoader.TryGetMod("FargowiltasSoulsDLC", out Mod FargowiltasSoulsDLC);
            fargosSoulsExtrasMod = FargowiltasSoulsDLC;

            fracturesOfPenumbraLoaded = ModLoader.TryGetMod("FPenumbra", out Mod FPenumbra);
            fracturesOfPenumbraMod = FPenumbra;

            furnitureFoodAndFunLoaded = ModLoader.TryGetMod("CosmeticVariety", out Mod CosmeticVariety);
            furnitureFoodAndFunMod = CosmeticVariety;

            gameTerrariaLoaded = ModLoader.TryGetMod("GMT", out Mod GMT);
            gameTerrariaMod = GMT;

            gensokyoLoaded = ModLoader.TryGetMod("Gensokyo", out Mod Gensokyo);
            gensokyoMod = Gensokyo;

            gerdsLabLoaded = ModLoader.TryGetMod("GMR", out Mod GMR);
            gerdsLabMod = GMR;

            heartbeatariaLoaded = ModLoader.TryGetMod("XDContentMod", out Mod XDContentMod);
            heartbeatariaMod = XDContentMod;

            homewardJourneyLoaded = ModLoader.TryGetMod("ContinentOfJourney", out Mod ContinentOfJourney);
            homewardJourneyMod = ContinentOfJourney;

            huntOfTheOldGodLoaded = ModLoader.TryGetMod("CalamityHunt", out Mod CalamityHunt);
            huntOfTheOldGodMod = CalamityHunt;

            infectedQualitiesLoaded = ModLoader.TryGetMod("InfectedQualities", out Mod InfectedQualities);
            infectedQualitiesMod = InfectedQualities;

            infernumLoaded = ModLoader.TryGetMod("InfernumMode", out Mod InfernumMode);
            infernumMod = InfernumMode;

            luiAFKLoaded = ModLoader.TryGetMod("miningcracks_take_on_luiafk", out Mod miningcracks_take_on_luiafk);
            luiAFKMod = miningcracks_take_on_luiafk;

            luiAFKDLCLoaded = ModLoader.TryGetMod("UnofficialLuiAFKDLC", out Mod UnofficialLuiAFKDLC);
            luiAFKDLCMod = UnofficialLuiAFKDLC;

            lunarVeilLoaded = ModLoader.TryGetMod("Stellamod", out Mod Stellamod);
            lunarVeilMod = Stellamod;

            magicStorageLoaded = ModLoader.TryGetMod("MagicStorage", out Mod MagicStorage);
            magicStorageMod = MagicStorage;

            martainsOrderLoaded = ModLoader.TryGetMod("MartainsOrder", out Mod MartainsOrder);
            martainsOrderMod = MartainsOrder;

            mechReworkLoaded = ModLoader.TryGetMod("PrimeRework", out Mod PrimeRework);
            mechReworkMod = PrimeRework;

            medialRiftLoaded = ModLoader.TryGetMod("MedRift", out Mod MedRift);
            medialRiftMod = MedRift;

            metroidLoaded = ModLoader.TryGetMod("MetroidMod", out Mod MetroidMod);
            metroidMod = MetroidMod;

            moomoosUltimateYoyoRevampLoaded = ModLoader.TryGetMod("CombinationsMod", out Mod CombinationsMod);
            moomoosUltimateYoyoRevampMod = CombinationsMod;

            mrPlagueRacesLoaded = ModLoader.TryGetMod("MrPlagueRaces", out Mod MrPlagueRaces);
            mrPlagueRacesMod = MrPlagueRaces;

            orchidLoaded = ModLoader.TryGetMod("OrchidMod", out Mod OrchidMod);
            orchidMod = OrchidMod;

            ophioidLoaded = ModLoader.TryGetMod("OphioidMod", out Mod OphioidMod);
            ophioidMod = OphioidMod;

            polaritiesLoaded = ModLoader.TryGetMod("Polarities", out Mod Polarities);
            polaritiesMod = Polarities;

            projectZeroLoaded = ModLoader.TryGetMod("FM", out Mod FM);
            projectZeroMod = FM;

            qwertyLoaded = ModLoader.TryGetMod("QwertyMod", out Mod QwertyMod);
            qwertyMod = QwertyMod;

            ragnarokLoaded = ModLoader.TryGetMod("RagnarokMod", out Mod RagnarokMod);
            ragnarokMod = RagnarokMod;

            redemptionLoaded = ModLoader.TryGetMod("Redemption", out Mod Redemption);
            redemptionMod = Redemption;

            reforgedLoaded = ModLoader.TryGetMod("ReforgeOverhaul", out Mod ReforgeOverhaul);
            reforgedMod = ReforgeOverhaul;

            remnantsLoaded = ModLoader.TryGetMod("Remnants", out Mod Remnants);
            remnantsMod = Remnants;

            ruptureLoaded = ModLoader.TryGetMod("Rupture", out Mod Rupture);
            ruptureMod = Rupture;

            secretsOfTheShadowsLoaded = ModLoader.TryGetMod("SOTS", out Mod SOTS);
            secretsOfTheShadowsMod = SOTS;

            shadowsOfAbaddonLoaded = ModLoader.TryGetMod("SacredTools", out Mod SacredTools);
            shadowsOfAbaddonMod = SacredTools;

            sloomeLoaded = ModLoader.TryGetMod("Bloopsitems", out Mod Bloopsitems);
            sloomeMod = Bloopsitems;

            spiritLoaded = ModLoader.TryGetMod("SpiritMod", out Mod SpiritMod);
            spiritMod = SpiritMod;

            spookyLoaded = ModLoader.TryGetMod("Spooky", out Mod Spooky);
            spookyMod = Spooky;

            starlightRiverLoaded = ModLoader.TryGetMod("StarlightRiver", out Mod StarlightRiver);
            starlightRiverMod = StarlightRiver;

            starsAboveLoaded = ModLoader.TryGetMod("StarsAbove", out Mod StarsAbove);
            starsAboveMod = StarsAbove;

            stormsAdditionsLoaded = ModLoader.TryGetMod("StormDiversMod", out Mod StormDiversMod);
            stormsAdditionsMod = StormDiversMod;

            stramsClassesLoaded = ModLoader.TryGetMod("StramClasses", out Mod StramClasses);
            stramsClassesMod = StramClasses;

            stramsSurvivalLoaded = ModLoader.TryGetMod("StramsSurvival", out Mod StramsSurvival);
            stramsSurvivalMod = StramsSurvival;

            supernovaLoaded = ModLoader.TryGetMod("SupernovaMod", out Mod SupernovaMod);
            supernovaMod = SupernovaMod;

            terrorbornLoaded = ModLoader.TryGetMod("TerrorbornMod", out Mod TerrorbornMod);
            terrorbornMod = TerrorbornMod;

            thoriumLoaded = ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            thoriumMod = ThoriumMod;

            thoriumBossReworkLoaded = ModLoader.TryGetMod("ThoriumRework", out Mod ThoriumRework);
            thoriumBossReworkMod = ThoriumRework;

            exhaustionDisablerLoaded = ModLoader.TryGetMod("ExhaustionDisabler", out Mod ExhaustionDisabler);
            exhaustionDisablerMod = ExhaustionDisabler;

            throwerUnificationLoaded = ModLoader.TryGetMod("ThrowerUnification", out Mod ThrowerUnification);
            throwerUnificationMod = ThrowerUnification;

            traeLoaded = ModLoader.TryGetMod("TRAEProject", out Mod TRAEProject);
            traeMod = TRAEProject;

            uhtricLoaded = ModLoader.TryGetMod("Uhtric", out Mod Uhtric);
            uhtricMod = Uhtric;

            universeOfSwordsLoaded = ModLoader.TryGetMod("UniverseOfSwordsMod", out Mod UniverseOfSwordsMod);
            universeOfSwordsMod = UniverseOfSwordsMod;

            valhallaLoaded = ModLoader.TryGetMod("ValhallaMod", out Mod ValhallaMod);
            valhallaMod = ValhallaMod;

            verdantLoaded = ModLoader.TryGetMod("Verdant", out Mod Verdant);
            verdantMod = Verdant;

            vitalityLoaded = ModLoader.TryGetMod("VitalityMod", out Mod VitalityMod);
            vitalityMod = VitalityMod;

            wayfairContentLoaded = ModLoader.TryGetMod("WAYFAIRContent", out Mod WAYFAIRContent);
            wayfairContentMod = WAYFAIRContent;

            wrathOfTheGodsLoaded = ModLoader.TryGetMod("NoxusBoss", out Mod NoxusBoss);
            wrathOfTheGodsMod = NoxusBoss;

            zylonLoaded = ModLoader.TryGetMod("Zylon", out Mod Zylon);
            zylonMod = Zylon;
        }
    }
}