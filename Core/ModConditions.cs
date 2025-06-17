using Terraria.ModLoader.IO;

namespace QoLCompendium.Core
{
    public class ModConditions : ModSystem
    {
#pragma warning disable
        #region Bools & Conditions

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
        public static bool downedDreadnautilus;
        public static Condition DownedDreadnautilus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDreadnautilus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dreadnautilus]);
        public static bool downedMartianSaucer;
        public static Condition DownedMartianSaucer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMartianSaucer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MartianSaucer]);
        public static Condition NotDownedMechBossAll = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.notDownedMechBossAll"), () => !(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3));
        //EVENTS
        public bool waitForBloodMoon;
        public static bool downedBloodMoon;
        public static Condition DownedBloodMoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBloodMoon"), () => downedBloodMoon);
        public bool waitForEclipse;
        public static bool downedEclipse;
        public static Condition DownedEclipse = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEclipse"), () => downedEclipse);
        public static bool downedLunarEvent;
        public static Condition DownedLunarEvent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLunarEvent"), () => downedLunarEvent);
        public static Condition DownedLunarPillarAny = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLunarPillarAny"), () => NPC.downedTowerNebula || NPC.downedTowerSolar || NPC.downedTowerStardust || NPC.downedTowerVortex);
        public bool waitForNight;
        public static bool beenThroughNight;
        public static Condition HasBeenThroughNight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenThroughNight"), () => beenThroughNight);
        //BIOMES
        public static bool beenToPurity;
        public static Condition HasBeenToPurity = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToPurity"), () => beenToPurity);
        public static bool beenToCavernsOrUnderground;
        public static Condition HasBeenToCavernsOrUnderground = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCavernsOrUnderground"), () => beenToCavernsOrUnderground);
        public static bool beenToUnderworld;
        public static Condition HasBeenToUnderworld = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToUnderworld"), () => beenToUnderworld);
        public static bool beenToSky;
        public static Condition HasBeenToSky = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSky"), () => beenToSky);
        public static bool beenToSnow;
        public static Condition HasBeenToSnow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSnow"), () => beenToSnow);
        public static bool beenToDesert;
        public static Condition HasBeenToDesert = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDesert"), () => beenToDesert);
        public static bool beenToOcean;
        public static Condition HasBeenToOcean = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToOcean"), () => beenToOcean);
        public static bool beenToJungle;
        public static Condition HasBeenToJungle = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToJungle"), () => beenToJungle);
        public static bool beenToMushroom;
        public static Condition HasBeenToMushroom = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToMushroom"), () => beenToMushroom);
        public static bool beenToCorruption;
        public static Condition HasBeenToCorruption = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCorruption"), () => beenToCorruption);
        public static bool beenToCrimson;
        public static Condition HasBeenToCrimson = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCrimson"), () => beenToCrimson);
        public static Condition HasBeenToEvil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToEvil"), () => beenToCorruption || beenToCrimson);
        public static bool beenToHallow;
        public static Condition HasBeenToHallow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToHallow"), () => beenToHallow);
        public static bool beenToTemple;
        public static Condition HasBeenToTemple = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToTemple"), () => beenToTemple);
        public static bool beenToDungeon;
        public static Condition HasBeenToDungeon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDungeon"), () => beenToDungeon);
        public static bool beenToAether;
        public static Condition HasBeenToAether = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAether"), () => beenToAether);
        //OTHER
        public static bool talkedToSkeletonMerchant;
        public static Condition HasTalkedToSkeletonMerchant = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.talkedToSkeletonMerchant"), () => talkedToSkeletonMerchant);
        public static bool talkedToTravelingMerchant;
        public static Condition HasTalkedToTravelingMerchant = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.talkedToTravelingMerchant"), () => talkedToTravelingMerchant);


        //AEQUUS
        public static bool aequusLoaded;
        public static Mod aequusMod;
        //BOSSES
        public static bool downedCrabson;
        public static Condition DownedCrabson = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCrabson"), () => downedCrabson);
        public static bool downedOmegaStarite;
        public static Condition DownedOmegaStarite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaStarite"), () => downedOmegaStarite);
        public static bool downedDustDevil;
        public static Condition DownedDustDevil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDustDevil"), () => downedDustDevil);
        //MINIBOSSES
        public static bool downedHyperStarite;
        public static Condition DownedHyperStarite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHyperStarite"), () => downedHyperStarite);
        public static bool downedUltraStarite;
        public static Condition DownedUltraStarite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUltraStarite"), () => downedUltraStarite);
        public static bool downedRedSprite;
        public static Condition DownedRedSprite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRedSprite"), () => downedRedSprite);
        public static bool downedSpaceSquid;
        public static Condition DownedSpaceSquid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSpaceSquid"), () => downedSpaceSquid);
        //EVENTS
        public static bool downedDemonSiege;
        public static Condition DownedDemonSiege = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDemonSiege"), () => downedDemonSiege);
        public static bool downedGlimmer;
        public static Condition DownedGlimmer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlimmer"), () => downedGlimmer);
        public static bool downedGaleStreams;
        public static Condition DownedGaleStreams = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGaleStreams"), () => downedGaleStreams);
        //BIOMES
        public static bool beenToCrabCrevice;
        public static Condition HasBeenToCrabCrevice = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCrabCrevice"), () => beenToCrabCrevice);


        //AFKPETS
        public static bool afkpetsLoaded;
        public static Mod afkpetsMod;
        //BOSSES
        public static bool downedSlayerOfEvil;
        public static Condition DownedSlayerOfEvil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlayerOfEvil"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SlayerOfEvil]);
        public static bool downedSATLA;
        public static Condition DownedSATLA = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSATLA"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SATLA]);
        public static bool downedDrFetus;
        public static Condition DownedDrFetus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDrFetus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DrFetus]);
        public static bool downedSlimesHope;
        public static Condition DownedSlimesHope = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlimesHope"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SlimesHope]);
        public static bool downedPoliticianSlime;
        public static Condition DownedPoliticianSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPoliticianSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PoliticianSlime]);
        public static bool downedAncientTrio;
        public static Condition DownedAncientTrio = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientTrio"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientTrio]);
        public static bool downedLavalGolem;
        public static Condition DownedLavalGolem = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLavalGolem"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LavalGolem]);
        //MINIBOSSES
        public static bool downedAntony;
        public static Condition DownedAntony = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAntony"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Antony]);
        public static bool downedBunnyZeppelin;
        public static Condition DownedBunnyZeppelin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBunnyZeppelin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BunnyZeppelin]);
        public static bool downedOkiku;
        public static Condition DownedOkiku = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOkiku"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Okiku]);
        public static bool downedHarpyAirforce;
        public static Condition DownedHarpyAirforce = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHarpyAirforce"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyAirforce]);
        public static bool downedIsaac;
        public static Condition DownedIsaac = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIsaac"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Isaac]);
        public static bool downedAncientGuardian;
        public static Condition DownedAncientGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientGuardian]);
        public static bool downedHeroicSlime;
        public static Condition DownedHeroicSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHeroicSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HeroicSlime]);
        public static bool downedHoloSlime;
        public static Condition DownedHoloSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHoloSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HoloSlime]);
        public static bool downedSecurityBot;
        public static Condition DownedSecurityBot = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSecurityBot"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SecurityBot]);
        public static bool downedUndeadChef;
        public static Condition DownedUndeadChef = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUndeadChef"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.UndeadChef]);
        public static bool downedGuardianOfFrost;
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
        public static bool downedSoulHarvester;
        public static Condition DownedSoulHarvester = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSoulHarvester"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SoulHarvester]);


        //AWFUL GARBAGE
        public static bool awfulGarbageLoaded;
        public static Mod awfulGarbageMod;
        //BOSSES
        public static bool downedTreeToad;
        public static Condition DownedTreeToad = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTreeToad"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TreeToad]);
        public static bool downedSeseKitsugai;
        public static Condition DownedSeseKitsugai = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeseKitsugai"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SeseKitsugai]);
        public static bool downedEyeOfTheStorm;
        public static Condition DownedEyeOfTheStorm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEyeOfTheStorm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EyeOfTheStorm]);
        public static bool downedFrigidius;
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
        public static bool downedCoreBoss;
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
        public static bool downedDesertScourge;
        public static Condition DownedDesertScourge = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDesertScourge"), () => downedDesertScourge);
        public static bool downedCrabulon;
        public static Condition DownedCrabulon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCrabulon"), () => downedCrabulon);
        public static bool downedHiveMind;
        public static Condition DownedHiveMind = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHiveMind"), () => downedHiveMind);
        public static bool downedPerforators;
        public static Condition DownedPerforators = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPerforators"), () => downedPerforators);
        public static Condition DownedPerforatorsOrHiveMind = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPerfOrHive"), () => downedPerforators || downedHiveMind);
        public static bool downedSlimeGod;
        public static Condition DownedSlimeGod = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlimeGod"), () => downedSlimeGod);
        public static bool downedCryogen;
        public static Condition DownedCryogen = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCryogen"), () => downedCryogen);
        public static bool downedAquaticScourge;
        public static Condition DownedAquaticScourge = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAquaticScourge"), () => downedAquaticScourge);
        public static bool downedBrimstoneElemental;
        public static Condition DownedBrimstoneElemental = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBrimstoneElemental"), () => downedBrimstoneElemental);
        public static bool downedCalamitasClone;
        public static Condition DownedCalamitasClone = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCalamitasClone"), () => downedCalamitasClone);
        public static bool downedLeviathanAndAnahita;
        public static Condition DownedLeviathanAndAnahita = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLeviathanAndAnahita"), () => downedLeviathanAndAnahita);
        public static bool downedAstrumAureus;
        public static Condition DownedAstrumAureus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAstrumAureus"), () => downedAstrumAureus);
        public static bool downedPlaguebringerGoliath;
        public static Condition DownedPlaguebringerGoliath = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPlaguebringerGoliath"), () => downedPlaguebringerGoliath);
        public static bool downedRavager;
        public static Condition DownedRavager = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRavager"), () => downedRavager);
        public static bool downedAstrumDeus;
        public static Condition DownedAstrumDeus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAstrumDeus"), () => downedAstrumDeus);
        public static bool downedProfanedGuardians;
        public static Condition DownedProfanedGuardians = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProfanedGuardians"), () => downedProfanedGuardians);
        public static bool downedDragonfolly;
        public static Condition DownedDragonfolly = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDragonfolly"), () => downedDragonfolly);
        public static bool downedProvidence;
        public static Condition DownedProvidence = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProvidence"), () => downedProvidence);
        public static bool downedStormWeaver;
        public static Condition DownedStormWeaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStormWeaver"), () => downedStormWeaver);
        public static bool downedCeaselessVoid;
        public static Condition DownedCeaselessVoid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCeaselessVoid"), () => downedCeaselessVoid);
        public static bool downedSignus;
        public static Condition DownedSignus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSignus"), () => downedSignus);
        public static bool downedPolterghast;
        public static Condition DownedPolterghast = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPolterghast"), () => downedPolterghast);
        public static bool downedOldDuke;
        public static Condition DownedOldDuke = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOldDuke"), () => downedOldDuke);
        public static bool downedDevourerOfGods;
        public static Condition DownedDevourerOfGods = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDevourerOfGods"), () => downedDevourerOfGods);
        public static bool downedYharon;
        public static Condition DownedYharon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedYharon"), () => downedYharon);
        public static bool downedExoMechs;
        public static Condition DownedExoMechs = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedExoMechs"), () => downedExoMechs);
        public static bool downedSupremeCalamitas;
        public static Condition DownedSupremeCalamitas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSupremeCalamitas"), () => downedSupremeCalamitas);
        //MINIBOSSES
        public static bool downedGiantClam;
        public static Condition DownedGiantClam = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGiantClam"), () => downedGiantClam);
        public static bool downedCragmawMire;
        public static Condition DownedCragmawMire = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCragmawMire"), () => downedCragmawMire);
        public static bool downedGreatSandShark;
        public static Condition DownedGreatSandShark = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGreatSandShark"), () => downedGreatSandShark);
        public static bool downedNuclearTerror;
        public static Condition DownedNuclearTerror = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNuclearTerror"), () => downedNuclearTerror);
        public static bool downedMauler;
        public static Condition DownedMauler = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMauler"), () => downedMauler);
        public static bool downedEidolonWyrm;
        public static Condition DownedEidolonWyrm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEidolonWyrm"), () => downedEidolonWyrm);
        //EVENTS
        public static bool downedAcidRain1;
        public static Condition DownedAcidRain1 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAcidRain1"), () => downedAcidRain1);
        public static bool downedAcidRain2;
        public static Condition DownedAcidRain2 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAcidRain2"), () => downedAcidRain2);
        public static bool downedBossRush;
        public static Condition DownedBossRush = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBossRush"), () => downedBossRush);
        //BIOMES
        public static bool beenToCrags;
        public static Condition HasBeenToCrags = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCrags"), () => beenToCrags);
        public static bool beenToAstral;
        public static Condition HasBeenToAstral = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAstral"), () => beenToAstral);
        public static bool beenToSunkenSea;
        public static Condition HasBeenToSunkenSea = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSunkenSea"), () => beenToSunkenSea);
        public static bool beenToSulphurSea;
        public static Condition HasBeenToSulphurSea = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSulphurSea"), () => beenToSulphurSea);
        public static bool beenToAbyss;
        public static Condition HasBeenToAbyss = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyss"), () => beenToAbyss);
        public static bool beenToAbyssLayer1;
        public static Condition HasBeenToAbyssLayer1 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer1"), () => beenToAbyssLayer1);
        public static bool beenToAbyssLayer2;
        public static Condition HasBeenToAbyssLayer2 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer2"), () => beenToAbyssLayer2);
        public static bool beenToAbyssLayer3;
        public static Condition HasBeenToAbyssLayer3 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer3"), () => beenToAbyssLayer3);
        public static bool beenToAbyssLayer4;
        public static Condition HasBeenToAbyssLayer4 = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAbyssLayer4"), () => beenToAbyssLayer4);
        //POST SUPREME CALAMITAS SHIMMER
        public static Condition ShimmerableAfterMoonLordOrSupremeCalamitas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.shimmerableAfterMoonLordOrSupremeCalamitas"), () => (calamityLoaded && downedSupremeCalamitas && NPC.downedMoonlord) || (!calamityLoaded && NPC.downedMoonlord));


        //CALAMITY COMMUNITY REMIX
        public static bool calamityCommunityRemixLoaded;
        public static Mod calamityCommunityRemixMod;
        //BOSSES
        public static bool downedWulfrumExcavator;
        public static Condition DownedWulfrumExcavator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWulfrumExcavator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WulfrumExcavator]);


        //CALAMITY ENTROPY
        public static bool calamityEntropyLoaded;
        public static Mod calamityEntropyMod;
        //BOSSES
        public static bool downedProphet;
        public static Condition DownedProphet = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProphet"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Prophet]);
        public static bool downedNihilityTwin;
        public static Condition DownedNihilityTwin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNihilityTwin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NihilityTwin]);
        public static bool downedCruiser;
        public static Condition DownedCruiser = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCruiser"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cruiser]);


        //CALAMITY OVERHAUL
        public static bool calamityOverhaulLoaded;
        public static Mod calamityOverhaulMod;


        //CALAMITY VANITIES
        public static bool calamityVanitiesLoaded;
        public static Mod calamityVanitiesMod;
        //BIOMES
        public static bool beenToAstralBlight;
        public static Condition HasBeenToAstralBlight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAstralBlight"), () => beenToAstralBlight);


        //CAPTURE DISCS CLASS
        public static bool captureDiscsClassLoaded;
        public static Mod captureDiscsClassMod;


        //CATALYST
        public static bool catalystLoaded;
        public static Mod catalystMod;
        //BOSSES
        public static bool downedAstrageldon;
        public static Condition DownedAstrageldon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAstrageldon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Astrageldon]);


        //CEREBRAL
        public static bool cerebralLoaded;
        public static Mod cerebralMod;


        //CLAMITY
        public static bool clamityAddonLoaded;
        public static Mod clamityAddonMod;
        //BOSSES
        public static bool downedClamitas;
        public static Condition DownedClamitas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedClamitas"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Clamitas]);
        public static bool downedPyrogen;
        public static Condition DownedPyrogen = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPyrogen"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Pyrogen]);
        public static bool downedWallOfBronze;
        public static Condition DownedWallOfBronze = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWallOfBronze"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfBronze]);


        //CLICKER CLASS
        public static bool clickerClassLoaded;
        public static Mod clickerClassMod;


        //CONFECTION
        public static bool confectionRebakedLoaded;
        public static Mod confectionRebakedMod;
        //BIOMES
        public static bool beenToConfection;
        public static Condition HasBeenToConfection = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToConfection"), () => beenToConfection);
        public static Condition HasBeenToConfectionOrHallow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToConfectionOrHallow"), () => beenToConfection || beenToHallow);


        //CONSOLARIA
        public static bool consolariaLoaded;
        public static Mod consolariaMod;
        //BOSSES
        public static bool downedLepus;
        public static Condition DownedLepus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLepus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lepus]);
        public static bool downedTurkor;
        public static Condition DownedTurkor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTurkor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Turkor]);
        public static bool downedOcram;
        public static Condition DownedOcram = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOcram"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ocram]);


        //CORALITE
        public static bool coraliteLoaded;
        public static Mod coraliteMod;
        //BOSSES
        public static bool downedRediancie;
        public static Condition DownedRediancie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRediancie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Rediancie]);
        public static bool downedBabyIceDragon;
        public static Condition DownedBabyIceDragon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBabyIceDragon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BabyIceDragon]);
        public static bool downedSlimeEmperor;
        public static Condition DownedSlimeEmperor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSlimeEmperor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SlimeEmperor]);
        public static bool downedBloodiancie;
        public static Condition DownedBloodiancie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBloodiancie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodiancie]);
        public static bool downedThunderveinDragon;
        public static Condition DownedThunderveinDragon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedThunderveinDragon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ThunderveinDragon]);
        public static bool downedNightmarePlantera;
        public static Condition DownedNightmarePlantera = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNightmarePlantera"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NightmarePlantera]);


        //DEPTHS
        public static bool crystalDragonsLoaded;
        public static Mod crystalDragonsMod;


        //DEPTHS
        public static bool depthsLoaded;
        public static Mod depthsMod;
        //BOSSES
        public static bool downedChasme;
        public static Condition DownedChasme = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChasme"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Chasme]);
        //BIOMES
        public static bool beenToDepths;
        public static Condition HasBeenToDepths = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDepths"), () => beenToDepths);
        public static Condition HasBeenToDepthsOrUnderworld = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDepthsOrUnderworld"), () => beenToDepths || beenToUnderworld);


        //DORMANT DAWN
        public static bool dormantDawnLoaded;
        public static Mod dormantDawnMod;
        //BOSSES
        public static bool downedLifeGuardian;
        public static Condition DownedLifeGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLifeGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LifeGuardian]);
        public static bool downedManaGuardian;
        public static Condition DownedManaGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedManaGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ManaGuardian]);
        public static bool downedMeteorExcavator;
        public static Condition DownedMeteorExcavator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMeteorExcavator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MeteorExcavator]);
        public static bool downedMeteorAnnihilator;
        public static Condition DownedMeteorAnnihilator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMeteorAnnihilator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MeteorAnnihilator]);
        public static bool downedHellfireSerpent;
        public static Condition DownedHellfireSerpent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHellfireSerpent"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HellfireSerpent]);
        //MINIBOSSES
        public static bool downedWitheredAcornSpirit;
        public static Condition DownedWitheredAcornSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWitheredAcornSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WitheredAcornSpirit]);
        public static bool downedGoblinSorcererChieftain;
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
        public static bool downedGalahis;
        public static Condition DownedGalahis = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGalahis"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Galahis]);
        public static bool downedCreation;
        public static Condition DownedCreation = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCreation"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Creation]);
        public static bool downedDestruction;
        public static Condition DownedDestruction = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDestruction"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Destruction]);


        //EDORBIS
        public static bool edorbisLoaded;
        public static Mod edorbisMod;
        //BOSSES
        public static bool downedBlightKing;
        public static Condition DownedBlightKing = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlightKing"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BlightKing]);
        public static bool downedGardener;
        public static Condition DownedGardener = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGardener"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Gardener]);
        public static bool downedGlaciation;
        public static Condition DownedGlaciation = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlaciation"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Glaciation]);
        public static bool downedHandOfCthulhu;
        public static Condition DownedHandOfCthulhu = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHandOfCthulhu"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HandOfCthulhu]);
        public static bool downedCursePreacher;
        public static Condition DownedCursePreacher = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCursePreacher"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CursePreacher]);


        //ENCHANTED MOONS
        public static bool enchantedMoonsLoaded;
        public static Mod enchantedMoonsMod;


        //EVERJADE
        public static bool everjadeLoaded;
        public static Mod everjadeMod;
        //BIOMES
        public static bool beenToJadeLake;
        public static Condition HasBeenToJadeLake = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToJadeLake"), () => beenToJadeLake);


        //EXALT
        public static bool exaltLoaded;
        public static Mod exaltMod;
        //BOSSES
        public static bool downedEffulgence;
        public static Condition DownedEffulgence = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEffulgence"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Effulgence]);
        public static bool downedIceLich;
        public static Condition DownedIceLich = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIceLich"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.IceLich]);


        //EXCELSIOR
        public static bool excelsiorLoaded;
        public static Mod excelsiorMod;
        //BOSSES
        public static bool downedNiflheim;
        public static Condition DownedNiflheim = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNiflheim"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Niflheim]);
        public static bool downedStellarStarship;
        public static Condition DownedStellarStarship = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStellarStarship"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StellarStarship]);


        //EXXO AVALON
        public static bool exxoAvalonOriginsLoaded;
        public static Mod exxoAvalonOriginsMod;
        //BOSSES
        public static bool downedBacteriumPrime;
        public static Condition DownedBacteriumPrime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBacteriumPrime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BacteriumPrime]);
        public static Condition DownedAvalonEvilBosses = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAvalonEvilBosses"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BacteriumPrime] || NPC.downedBoss2);
        public static bool downedDesertBeak;
        public static Condition DownedDesertBeak = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDesertBeak"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DesertBeak]);
        public static bool downedKingSting;
        public static Condition DownedKingSting = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKingSting"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.KingSting]);
        public static bool downedMechasting;
        public static Condition DownedMechasting = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMechasting"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Mechasting]);
        public static bool downedPhantasm;
        public static Condition DownedPhantasm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPhantasm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Phantasm]);
        //BIOMES
        public static bool beenToContagion;
        public static Condition HasBeenToContagion = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToContagion"), () => beenToContagion);
        public static Condition HasBeenToAvalonEvilBiomes = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAvalonEvilBiomes"), () => beenToContagion || beenToCorruption || beenToCrimson);


        //FARGOS
        public static bool fargosMutantLoaded;
        public static Mod fargosMutantMod;


        //FARGOS SOULS
        public static bool fargosSoulsLoaded;
        public static Mod fargosSoulsMod;
        //BOSSES
        public static bool downedTrojanSquirrel;
        public static Condition DownedTrojanSquirrel = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTrojanSquirrel"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TrojanSquirrel]);
        public static bool downedCursedCoffin;
        public static Condition DownedCursedCoffin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCursedCoffin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CursedCoffin]);
        public static bool downedDeviantt;
        public static Condition DownedDeviantt = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDeviantt"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Deviantt]);
        public static bool downedLifelight;
        public static Condition DownedLifelight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLifelight"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lifelight]);
        public static bool downedBanishedBaron;
        public static Condition DownedBanishedBaron = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBanishedBaron"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BanishedBaron]);
        public static bool downedEridanus;
        public static Condition DownedEridanus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEridanus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Eridanus]);
        public static bool downedAbominationn;
        public static Condition DownedAbominationn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAbominationn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Abominationn]);
        public static bool downedMutant;
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
        public static bool downedAlphaFrostjaw;
        public static Condition DownedAlphaFrostjaw = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAlphaFrostjaw"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AlphaFrostjaw]);
        public static bool downedSanguineElemental;
        public static Condition DownedSanguineElemental = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSanguineElemental"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SanguineElemental]);
        //BIOMES
        public static bool beenToDread;
        public static Condition HasBeenToDread = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToDread"), () => beenToDread);


        //FURNITURE FOOD & FUN
        public static bool furnitureFoodAndFunLoaded;
        public static Mod furnitureFoodAndFunMod;


        //GAMETERRARIA
        public static bool gameTerrariaLoaded;
        public static Mod gameTerrariaMod;
        //BOSSES
        public static bool downedLad;
        public static Condition DownedLad = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLad"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lad]);
        public static bool downedHornlitz;
        public static Condition DownedHornlitz = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHornlitz"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Hornlitz]);
        public static bool downedSnowDon;
        public static Condition DownedSnowDon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSnowDon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SnowDon]);
        public static bool downedStoffie;
        public static Condition DownedStoffie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStoffie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Stoffie]);


        //GENSOKYO
        public static bool gensokyoLoaded;
        public static Mod gensokyoMod;
        //BOSSES
        public static bool downedLilyWhite;
        public static Condition DownedLilyWhite = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLilyWhite"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LilyWhite]);
        public static bool downedRumia;
        public static Condition DownedRumia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRumia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Rumia]);
        public static bool downedEternityLarva;
        public static Condition DownedEternityLarva = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEternityLarva"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EternityLarva]);
        public static bool downedNazrin;
        public static Condition DownedNazrin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNazrin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nazrin]);
        public static bool downedHinaKagiyama;
        public static Condition DownedHinaKagiyama = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHinaKagiyama"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HinaKagiyama]);
        public static bool downedSekibanki;
        public static Condition DownedSekibanki = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSekibanki"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Sekibanki]);
        public static bool downedSeiran;
        public static Condition DownedSeiran = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeiran"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Seiran]);
        public static bool downedNitoriKawashiro;
        public static Condition DownedNitoriKawashiro = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNitoriKawashiro"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NitoriKawashiro]);
        public static bool downedMedicineMelancholy;
        public static Condition DownedMedicineMelancholy = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMedicineMelancholy"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MedicineMelancholy]);
        public static bool downedCirno;
        public static Condition DownedCirno = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCirno"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cirno]);
        public static bool downedMinamitsuMurasa;
        public static Condition DownedMinamitsuMurasa = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMinamitsuMurasa"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MinamitsuMurasa]);
        public static bool downedAliceMargatroid;
        public static Condition DownedAliceMargatroid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAliceMargatroid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AliceMargatroid]);
        public static bool downedSakuyaIzayoi;
        public static Condition DownedSakuyaIzayoi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSakuyaIzayoi"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SakuyaIzayoi]);
        public static bool downedSeijaKijin;
        public static Condition DownedSeijaKijin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeijaKijin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SeijaKijin]);
        public static bool downedMayumiJoutouguu;
        public static Condition DownedMayumiJoutouguu = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMayumiJoutouguu"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MayumiJoutouguu]);
        public static bool downedToyosatomimiNoMiko;
        public static Condition DownedToyosatomimiNoMiko = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedToyosatomimiNoMiko"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ToyosatomimiNoMiko]);
        public static bool downedKaguyaHouraisan;
        public static Condition DownedKaguyaHouraisan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKaguyaHouraisan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.KaguyaHouraisan]);
        public static bool downedUtsuhoReiuji;
        public static Condition DownedUtsuhoReiuji = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUtsuhoReiuji"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.UtsuhoReiuji]);
        public static bool downedTenshiHinanawi;
        public static Condition DownedTenshiHinanawi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTenshiHinanawi"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TenshiHinanawi]);
        //MINIBOSSES
        public static bool downedKisume;
        public static Condition DownedKisume = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKisume"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Kisume]);


        //GMR
        public static bool gerdsLabLoaded;
        public static Mod gerdsLabMod;
        //BOSSES
        public static bool downedTrerios;
        public static Condition DownedTrerios = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTrerios"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Trerios]);
        public static bool downedMagmaEye;
        public static Condition DownedMagmaEye = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMagmaEye"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MagmaEye]);
        public static bool downedJack;
        public static Condition DownedJack = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJack"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Jack]);
        public static bool downedAcheron;
        public static Condition DownedAcheron = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAcheron"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Acheron]);


        //HEARTBEATARIA
        public static bool heartbeatariaLoaded;
        public static Mod heartbeatariaMod;


        //HOMEWARD JOURNEY
        public static bool homewardJourneyLoaded;
        public static Mod homewardJourneyMod;
        //BOSSES
        public static bool downedMarquisMoonsquid;
        public static Condition DownedMarquisMoonsquid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMarquisMoonsquid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MarquisMoonsquid]);
        public static bool downedPriestessRod;
        public static Condition DownedPriestessRod = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPriestessRod"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PriestessRod]);
        public static bool downedDiver;
        public static Condition DownedDiver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDiver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Diver]);
        public static bool downedMotherbrain;
        public static Condition DownedMotherbrain = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMotherbrain"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Motherbrain]);
        public static bool downedWallOfShadow;
        public static Condition DownedWallOfShadow = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWallOfShadow"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfShadow]);
        public static bool downedSunSlimeGod;
        public static Condition DownedSunSlimeGod = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSunSlimeGod"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SunSlimeGod]);
        public static bool downedOverwatcher;
        public static Condition DownedOverwatcher = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOverwatcher"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Overwatcher]);
        public static bool downedLifebringer;
        public static Condition DownedLifebringer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLifebringer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lifebringer]);
        public static bool downedMaterealizer;
        public static Condition DownedMaterealizer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMaterealizer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Materealizer]);
        public static bool downedScarabBelief;
        public static Condition DownedScarabBelief = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedScarabBelief"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ScarabBelief]);
        public static bool downedWorldsEndWhale;
        public static Condition DownedWorldsEndWhale = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWorldsEndWhale"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WorldsEndWhale]);
        public static bool downedSon;
        public static Condition DownedSon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Son]);
        //EVENTS
        public static bool downedCaveOrdeal;
        public static Condition DownedCaveOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCaveOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CaveOrdeal]);
        public static bool downedCorruptOrdeal;
        public static Condition DownedCorruptOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCorruptOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CorruptOrdeal]);
        public static bool downedCrimsonOrdeal;
        public static Condition DownedCrimsonOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCrimsonOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CrimsonOrdeal]);
        public static bool downedDesertOrdeal;
        public static Condition DownedDesertOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDesertOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DesertOrdeal]);
        public static bool downedForestOrdeal;
        public static Condition DownedForestOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForestOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ForestOrdeal]);
        public static bool downedHallowOrdeal;
        public static Condition DownedHallowOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHallowOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HallowOrdeal]);
        public static bool downedJungleOrdeal;
        public static Condition DownedJungleOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJungleOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.JungleOrdeal]);
        public static bool downedSkyOrdeal;
        public static Condition DownedSkyOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSkyOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SkyOrdeal]);
        public static bool downedSnowOrdeal;
        public static Condition DownedSnowOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSnowOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SnowOrdeal]);
        public static bool downedUnderworldOrdeal;
        public static Condition DownedUnderworldOrdeal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUnderworldOrdeal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.UnderworldOrdeal]);
        public static Condition DownedOrdealAny = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOrdealAny"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CaveOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.CorruptOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.CrimsonOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.DesertOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.ForestOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.HallowOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.JungleOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.SkyOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.SnowOrdeal] || ModConditions.DownedBoss[(int)ModConditions.Downed.UnderworldOrdeal]);
        //BIOMES
        public static bool beenToHomewardAbyss;
        public static Condition HasBeenToHomewardAbyss = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToHomewardAbyss"), () => beenToHomewardAbyss);


        //HUNT OF THE OLD GOD
        public static bool huntOfTheOldGodLoaded;
        public static Mod huntOfTheOldGodMod;
        //BOSSES
        public static bool downedGoozma;
        public static Condition DownedGoozma = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGoozma"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Goozma]);


        //INFECTED QUALITIES
        public static bool infectedQualitiesLoaded;
        public static Mod infectedQualitiesMod;


        //INFERNUM
        public static bool infernumLoaded;
        public static Mod infernumMod;
        //BOSSES
        public static bool downedBereftVassal;
        public static Condition DownedBereftVassal = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBereftVassal"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal]);
        //BIOMES
        public static bool beenToProfanedGardens;
        public static Condition HasBeenToProfanedGardens = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToProfanedGardens"), () => beenToProfanedGardens);


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
        public static bool downedStoneGuardian;
        public static Condition DownedStoneGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStoneGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StoneGuardian]);
        public static bool downedCommanderGintzia;
        public static Condition DownedCommanderGintzia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCommanderGintzia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CommanderGintzia]);
        public static bool downedSunStalker;
        public static Condition DownedSunStalker = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSunStalker"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SunStalker]);
        public static bool downedPumpkinJack;
        public static Condition DownedPumpkinJack = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPumpkinJack"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PumpkinJack]);
        public static bool downedForgottenPuppetDaedus;
        public static Condition DownedForgottenPuppetDaedus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForgottenPuppetDaedus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ForgottenPuppetDaedus]);
        public static bool downedDreadMire;
        public static Condition DownedDreadMire = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDreadMire"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DreadMire]);
        public static bool downedSingularityFragment;
        public static Condition DownedSingularityFragment = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSingularityFragment"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SingularityFragment]);
        public static bool downedVerlia;
        public static Condition DownedVerlia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVerlia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Verlia]);
        public static bool downedIrradia;
        public static Condition DownedIrradia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIrradia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Irradia]);
        public static bool downedSylia;
        public static Condition DownedSylia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSylia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Sylia]);
        public static bool downedFenix;
        public static Condition DownedFenix = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFenix"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Fenix]);
        //MINIBOSSES
        public static bool downedBlazingSerpent;
        public static Condition DownedBlazingSerpent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlazingSerpent"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BlazingSerpent]);
        public static bool downedCogwork;
        public static Condition DownedCogwork = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCogwork"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cogwork]);
        public static bool downedWaterCogwork;
        public static Condition DownedWaterCogwork = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWaterCogwork"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WaterCogwork]);
        public static bool downedWaterJellyfish;
        public static Condition DownedWaterJellyfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWaterJellyfish"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WaterJellyfish]);
        public static bool downedSparn;
        public static Condition DownedSparn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSparn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Sparn]);
        public static bool downedPandorasFlamebox;
        public static Condition DownedPandorasFlamebox = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPandorasFlamebox"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PandorasFlamebox]);
        public static bool downedSTARBOMBER;
        public static Condition DownedSTARBOMBER = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSTARBOMBER"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.STARBOMBER]);
        public static Condition DownedWaterJellyfishOrWaterCogwork = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWaterJellyfishOrWaterCogwork"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.WaterCogwork] || ModConditions.DownedBoss[(int)ModConditions.Downed.WaterJellyfish]);
        public static Condition DownedCogworkOrSparn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCogworkOrSparn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cogwork] || ModConditions.DownedBoss[(int)ModConditions.Downed.Sparn]);
        public static Condition DownedBlazingSerpentOrPandorasFlamebox = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlazingSerpentOrPandorasFlamebox"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BlazingSerpent] || ModConditions.DownedBoss[(int)ModConditions.Downed.PandorasFlamebox]);
        //EVENTS
        public static bool downedGintzeArmy;
        public static Condition DownedGintzeArmy = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGintzeArmy"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GintzeArmy]);
        //BIOMES
        public static bool beenToLunarVeilAbyss;
        public static Condition HasBeenToLunarVeilAbyss = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToLunarVeilAbyss"), () => beenToLunarVeilAbyss);
        public static bool beenToAcid;
        public static Condition HasBeenToAcid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAcid"), () => beenToAcid);
        public static bool beenToAurelus;
        public static Condition HasBeenToAurelus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAurelus"), () => beenToAurelus);
        public static bool beenToFable;
        public static Condition HasBeenToFable = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToFable"), () => beenToFable);
        public static bool beenToGovheilCastle;
        public static Condition HasBeenToGovheilCastle = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToGovheilCastle"), () => beenToGovheilCastle);
        public static bool beenToCathedral;
        public static Condition HasBeenToCathedral = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCathedral"), () => beenToCathedral);
        public static bool beenToMarrowSurface;
        public static Condition HasBeenToMarrowSurface = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToMarrowSurface"), () => beenToMarrowSurface);
        public static bool beenToMorrowUnderground;
        public static Condition HasBeenToMorrowUnderground = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToMorrowUnderground"), () => beenToMorrowUnderground);


        //MAGIC STORAGE
        public static bool magicStorageLoaded;
        public static Mod magicStorageMod;


        //MARTAINS ORDER
        public static bool martainsOrderLoaded;
        public static Mod martainsOrderMod;
        public static bool downedBritzz;
        public static Condition DownedBritzz = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBritzz"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Britzz]);
        public static bool downedTheAlchemist;
        public static Condition DownedTheAlchemist = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTheAlchemist"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TheAlchemist]);
        public static bool downedCarnagePillar;
        public static Condition DownedCarnagePillar = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCarnagePillar"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CarnagePillar]);
        public static bool downedVoidDigger;
        public static Condition DownedVoidDigger = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVoidDigger"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.VoidDigger]);
        public static bool downedPrinceSlime;
        public static Condition DownedPrinceSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrinceSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PrinceSlime]);
        public static bool downedTriplets;
        public static Condition DownedTriplets = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTriplets"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets]);
        public static bool downedJungleDefenders;
        public static Condition DownedJungleDefenders = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJungleDefenders"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.JungleDefenders]);


        //MECH REWORK
        public static bool mechReworkLoaded;
        public static Mod mechReworkMod;
        //BOSSES
        public static bool downedSt4sys;
        public static Condition DownedSt4sys = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSt4sys"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.St4sys]);
        public static bool downedTerminator;
        public static Condition DownedTerminator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTerminator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Terminator]);
        public static bool downedCaretaker;
        public static Condition DownedCaretaker = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCaretaker"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Caretaker]);
        public static bool downedSiegeEngine;
        public static Condition DownedSiegeEngine = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSiegeEngine"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SiegeEngine]);


        //MEDIAL RIFT
        public static bool medialRiftLoaded;
        public static Mod medialRiftMod;
        //BOSSES
        public static bool downedSuperVoltaicMotherSlime;
        public static Condition DownedSuperVoltaicMotherSlime = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSuperVoltaicMotherSlime"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SuperVMS]);


        //METROID MOD
        public static bool metroidLoaded;
        public static Mod metroidMod;
        //BOSSES
        public static bool downedTorizo;
        public static Condition DownedTorizo = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTorizo"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Torizo]);
        public static bool downedSerris;
        public static Condition DownedSerris = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSerris"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Serris]);
        public static bool downedKraid;
        public static Condition DownedKraid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKraid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Kraid]);
        public static bool downedPhantoon;
        public static Condition DownedPhantoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPhantoon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Phantoon]);
        public static bool downedOmegaPirate;
        public static Condition DownedOmegaPirate = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaPirate"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaPirate]);
        public static bool downedNightmare;
        public static Condition DownedNightmare = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNightmare"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nightmare]);
        public static bool downedGoldenTorizo;
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
        public static bool downedOphiopede;
        public static Condition DownedOphiopede = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOphiopede"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiopede]);
        public static bool downedOphiocoon;
        public static Condition DownedOphiocoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOphiocoon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiocoon]);
        public static bool downedOphiofly;
        public static Condition DownedOphiofly = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOphiofly"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiofly]);


        //POLARITIES
        public static bool polaritiesLoaded;
        public static Mod polaritiesMod;
        //BOSSES
        public static bool downedStormCloudfish;
        public static Condition DownedStormCloudfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStormCloudfish"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloudfish]);
        public static bool downedStarConstruct;
        public static Condition DownedStarConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StarConstruct]);
        public static bool downedGigabat;
        public static Condition DownedGigabat = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGigabat"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Gigabat]);
        public static bool downedSunPixie;
        public static Condition DownedSunPixie = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSunPixie"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SunPixie]);
        public static bool downedEsophage;
        public static Condition DownedEsophage = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEsophage"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Esophage]);
        public static bool downedConvectiveWanderer;
        public static Condition DownedConvectiveWanderer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedConvectiveWanderer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ConvectiveWanderer]);


        //PROJECT ZERO
        public static bool projectZeroLoaded;
        public static Mod projectZeroMod;
        //BOSSES
        public static bool downedForestGuardian;
        public static Condition DownedForestGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForestGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ForestGuardian]);
        public static bool downedCryoGuardian;
        public static Condition DownedCryoGuardian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCryoGuardian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CryoGuardian]);
        public static bool downedPrimordialWorm;
        public static Condition DownedPrimordialWorm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrimordialWorm"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PrimordialWorm]);
        public static bool downedTheGuardianOfHell;
        public static Condition DownedTheGuardianOfHell = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTheGuardianOfHell"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TheGuardianOfHell]);
        public static bool downedVoid;
        public static Condition DownedVoid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVoid"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Void]);
        public static bool downedArmagem;
        public static Condition DownedArmagem = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedArmagem"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Armagem]);


        //QWERTY
        public static bool qwertyLoaded;
        public static Mod qwertyMod;
        //BOSSES
        public static bool downedPolarExterminator;
        public static Condition DownedPolarExterminator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPolarExterminator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PolarExterminator]);
        public static bool downedDivineLight;
        public static Condition DownedDivineLight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDivineLight"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DivineLight]);
        public static bool downedAncientMachine;
        public static Condition DownedAncientMachine = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientMachine"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientMachine]);
        public static bool downedNoehtnap;
        public static Condition DownedNoehtnap = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNoehtnap"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Noehtnap]);
        public static bool downedHydra;
        public static Condition DownedHydra = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHydra"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Hydra]);
        public static bool downedImperious;
        public static Condition DownedImperious = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedImperious"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Imperious]);
        public static bool downedRuneGhost;
        public static Condition DownedRuneGhost = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRuneGhost"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.RuneGhost]);
        public static bool downedInvaderBattleship;
        public static Condition DownedInvaderBattleship = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInvaderBattleship"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderBattleship]);
        public static bool downedInvaderNoehtnap;
        public static Condition DownedInvaderNoehtnap = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInvaderNoehtnap"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderNoehtnap]);
        public static bool downedOLORD;
        public static Condition DownedOLORD = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOLORD"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OLORD]);
        //MINIBOSSES
        public static bool downedGreatTyrannosaurus;
        public static Condition DownedGreatTyrannosaurus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGreatTyrannosaurus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GreatTyrannosaurus]);
        //EVENTS
        public static bool downedDinoMilitia;
        public static Condition DownedDinoMilitia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDinoMilitia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.DinoMilitia]);
        public static bool downedInvaders;
        public static Condition DownedInvaders = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInvaders"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Invaders]);
        //BIOMES
        public static bool beenToSkyFortress;
        public static Condition HasBeenToSkyFortress = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSkyFortress"), () => beenToSkyFortress);


        //RAGNAROK
        public static bool ragnarokLoaded;
        public static Mod ragnarokMod;


        //REDEMPTION
        public static bool redemptionLoaded;
        public static Mod redemptionMod;
        //BOSSES
        public static bool downedThorn;
        public static Condition DownedThorn = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedThorn"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Thorn]);
        public static bool downedErhan;
        public static Condition DownedErhan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedErhan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Erhan]);
        public static bool downedKeeper;
        public static Condition DownedKeeper = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKeeper"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Keeper]);
        public static bool downedSeedOfInfection;
        public static Condition DownedSeedOfInfection = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSeedOfInfection"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SeedOfInfection]);
        public static bool downedKingSlayerIII;
        public static Condition DownedKingSlayerIII = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedKingSlayerIII"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.KingSlayerIII]);
        public static bool downedOmegaCleaver;
        public static Condition DownedOmegaCleaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaCleaver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaCleaver]);
        public static bool downedOmegaGigapora;
        public static Condition DownedOmegaGigapora = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaGigapora"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaGigapora]);
        public static bool downedOmegaObliterator;
        public static Condition DownedOmegaObliterator = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOmegaObliterator"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaObliterator]);
        public static bool downedPatientZero;
        public static Condition DownedPatientZero = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPatientZero"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PatientZero]);
        public static bool downedAkka;
        public static Condition DownedAkka = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAkka"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Akka]);
        public static bool downedUkko;
        public static Condition DownedUkko = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedUkko"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ukko]);
        public static bool downedAncientDeityDuo;
        public static Condition DownedAncientDeityDuo = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientDeityDuo"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientDeityDuo]);
        public static bool downedNebuleus;
        public static Condition DownedNebuleus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNebuleus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nebuleus]);
        //MINIBOSSES
        public static bool downedFowlEmperor;
        public static Condition DownedFowlEmperor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFowlEmperor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FowlEmperor]);
        public static bool downedCockatrice;
        public static Condition DownedCockatrice = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCockatrice"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Cockatrice]);
        public static bool downedBasan;
        public static Condition DownedBasan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBasan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Basan]);
        public static bool downedSkullDigger;
        public static Condition DownedSkullDigger = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSkullDigger"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SkullDigger]);
        public static bool downedEaglecrestGolem;
        public static Condition DownedEaglecrestGolem = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEaglecrestGolem"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EaglecrestGolem]);
        public static bool downedCalavia;
        public static Condition DownedCalavia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCalavia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Calavia]);
        public static bool downedTheJanitor;
        public static Condition DownedTheJanitor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTheJanitor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TheJanitor]);
        public static bool downedIrradiatedBehemoth;
        public static Condition DownedIrradiatedBehemoth = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIrradiatedBehemoth"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.IrradiatedBehemoth]);
        public static bool downedBlisterface;
        public static Condition DownedBlisterface = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBlisterface"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Blisterface]);
        public static bool downedProtectorVolt;
        public static Condition DownedProtectorVolt = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedProtectorVolt"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ProtectorVolt]);
        public static bool downedMACEProject;
        public static Condition DownedMACEProject = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMACEProject"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MACEProject]);
        //EVENTS
        public static bool downedFowlMorning;
        public static Condition DownedFowlMorning = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFowlMorning"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FowlMorning]);
        public static bool downedRaveyard;
        public static Condition DownedRaveyard = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRaveyard"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Raveyard]);
        //BIOMES
        public static bool beenToLab;
        public static Condition HasBeenToLab = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToLab"), () => beenToLab);
        public static bool beenToWasteland;
        public static Condition HasBeenToWasteland = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToWasteland"), () => beenToWasteland);


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
        public static bool downedPutridPinky;
        public static Condition DownedPutridPinky = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPutridPinky"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PutridPinky]);
        public static bool downedGlowmoth;
        public static Condition DownedGlowmoth = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlowmoth"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Glowmoth]);
        public static bool downedPharaohsCurse;
        public static Condition DownedPharaohsCurse = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPharaohsCurse"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PharaohsCurse]);
        public static bool downedAdvisor;
        public static Condition DownedAdvisor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAdvisor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Advisor]);
        public static bool downedPolaris;
        public static Condition DownedPolaris = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPolaris"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Polaris]);
        public static bool downedLux;
        public static Condition DownedLux = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLux"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Lux]);
        public static bool downedSubspaceSerpent;
        public static Condition DownedSubspaceSerpent = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSubspaceSerpent"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SubspaceSerpent]);
        //MINIBOSSES
        public static bool downedNatureConstruct;
        public static Condition DownedNatureConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNatureConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NatureConstruct]);
        public static bool downedEarthenConstruct;
        public static Condition DownedEarthenConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEarthenConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenConstruct]);
        public static bool downedPermafrostConstruct;
        public static Condition DownedPermafrostConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPermafrostConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostConstruct]);
        public static bool downedTidalConstruct;
        public static Condition DownedTidalConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTidalConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TidalConstruct]);
        public static bool downedOtherworldlyConstruct;
        public static Condition DownedOtherworldlyConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOtherworldlyConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlyConstruct]);
        public static bool downedEvilConstruct;
        public static Condition DownedEvilConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEvilConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EvilConstruct]);
        public static bool downedInfernoConstruct;
        public static Condition DownedInfernoConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfernoConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoConstruct]);
        public static bool downedChaosConstruct;
        public static Condition DownedChaosConstruct = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChaosConstruct"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosConstruct]);
        public static bool downedNatureSpirit;
        public static Condition DownedNatureSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNatureSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NatureSpirit]);
        public static bool downedEarthenSpirit;
        public static Condition DownedEarthenSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEarthenSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenSpirit]);
        public static bool downedPermafrostSpirit;
        public static Condition DownedPermafrostSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPermafrostSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostSpirit]);
        public static bool downedTidalSpirit;
        public static Condition DownedTidalSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTidalSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TidalSpirit]);
        public static bool downedOtherworldlySpirit;
        public static Condition DownedOtherworldlySpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOtherworldlySpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlySpirit]);
        public static bool downedEvilSpirit;
        public static Condition DownedEvilSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEvilSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EvilSpirit]);
        public static bool downedInfernoSpirit;
        public static Condition DownedInfernoSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfernoSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoSpirit]);
        public static bool downedChaosSpirit;
        public static Condition DownedChaosSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChaosSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosSpirit]);
        //BIOMES
        public static bool beenToPyramid;
        public static Condition HasBeenToPyramid = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToPyramid"), () => beenToPyramid);
        public static bool beenToPlanetarium;
        public static Condition HasBeenToPlanetarium = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToPlanetarium"), () => beenToPlanetarium);


        //SHADOWS OF ABADDON
        public static bool shadowsOfAbaddonLoaded;
        public static Mod shadowsOfAbaddonMod;
        //BOSSES
        public static bool downedDecree;
        public static Condition DownedDecree = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDecree"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Decree]);
        public static bool downedFlamingPumpkin;
        public static Condition DownedFlamingPumpkin = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFlamingPumpkin"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FlamingPumpkin]);
        public static bool downedZombiePiglinBrute;
        public static Condition DownedZombiePiglinBrute = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedZombiePiglinBrute"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ZombiePiglinBrute]);
        public static bool downedJensenTheGrandHarpy;
        public static Condition DownedJensenTheGrandHarpy = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJensenTheGrandHarpy"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.JensenTheGrandHarpy]);
        public static bool downedAraneas;
        public static Condition DownedAraneas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAraneas"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Araneas]);
        public static bool downedHarpyQueenRaynare;
        public static Condition DownedHarpyQueenRaynare = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHarpyQueenRaynare"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyQueenRaynare]);
        public static bool downedPrimordia;
        public static Condition DownedPrimordia = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrimordia"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Primordia]);
        public static bool downedAbaddon;
        public static Condition DownedAbaddon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAbaddon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Abaddon]);
        public static bool downedAraghur;
        public static Condition DownedAraghur = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAraghur"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Araghur]);
        public static bool downedLostSiblings;
        public static Condition DownedLostSiblings = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLostSiblings"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.LostSiblings]);
        public static bool downedErazor;
        public static Condition DownedErazor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedErazor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Erazor]);
        public static bool downedNihilus;
        public static Condition DownedNihilus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNihilus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Nihilus]);
        //BIOMES
        public static bool beenToCinderForest;
        public static Condition HasBeenToCinderForest = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCinderForest"), () => beenToCinderForest);


        //SLOOME
        public static bool sloomeLoaded;
        public static Mod sloomeMod;
        //BOSSES
        public static bool downedExodygen;
        public static Condition DownedExodygen = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedExodygen"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Exodygen]);


        //SPIRIT
        public static bool spiritLoaded;
        public static Mod spiritMod;
        //BOSSES
        public static bool downedScarabeus;
        public static Condition DownedScarabeus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedScarabeus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Scarabeus]);
        public static bool downedMoonJellyWizard;
        public static Condition DownedMoonJellyWizard = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMoonJellyWizard"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MoonJellyWizard]);
        public static bool downedVinewrathBane;
        public static Condition DownedVinewrathBane = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVinewrathBane"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.VinewrathBane]);
        public static bool downedAncientAvian;
        public static Condition DownedAncientAvian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientAvian"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientAvian]);
        public static bool downedStarplateVoyager;
        public static Condition DownedStarplateVoyager = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarplateVoyager"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StarplateVoyager]);
        public static bool downedInfernon;
        public static Condition DownedInfernon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfernon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Infernon]);
        public static bool downedDusking;
        public static Condition DownedDusking = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDusking"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dusking]);
        public static bool downedAtlas;
        public static Condition DownedAtlas = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAtlas"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Atlas]);
        //EVENTS
        public bool waitForJellyDeluge;
        public static bool downedJellyDeluge;
        public static Condition DownedJellyDeluge = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedJellyDeluge"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.JellyDeluge]);
        public static bool downedTide;
        public static Condition DownedTide = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTide"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Tide]);
        public bool waitForMysticMoon;
        public static bool downedMysticMoon;
        public static Condition DownedMysticMoon = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMysticMoon"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MysticMoon]);
        //BIOMES
        public static bool beenToBriar;
        public static Condition HasBeenToBriar = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToBriar"), () => beenToBriar);
        public static bool beenToSpirit;
        public static Condition HasBeenToSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpirit"), () => beenToSpirit);


        //SPOOKY
        public static bool spookyLoaded;
        public static Mod spookyMod;
        //BOSSES
        public static bool downedSpookySpirit;
        public static Condition DownedSpookySpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSpookySpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SpookySpirit]);
        public static bool downedRotGourd;
        public static Condition DownedRotGourd = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedRotGourd"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.RotGourd]);
        public static bool downedMoco;
        public static Condition DownedMoco = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMoco"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Moco]);
        public static bool downedDaffodil;
        public static Condition DownedDaffodil = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDaffodil"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Daffodil]);
        public static bool downedOrroBoro;
        public static bool downedOrro;
        public static bool downedBoro;
        public static Condition DownedOrroBoro = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOrroBoro"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OrroBoro]);
        public static bool downedBigBone;
        public static Condition DownedBigBone = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBigBone"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.BigBone]);
        //BIOMES
        public static bool beenToSpookyForest;
        public static Condition HasBeenToSpookyForest = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpookyForest"), () => beenToSpookyForest);
        public static bool beenToSpookyUnderground;
        public static Condition HasBeenToSpookyUnderground = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpookyUnderground"), () => beenToSpookyUnderground);
        public static bool beenToEyeValley;
        public static Condition HasBeenToEyeValley = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToEyeValley"), () => beenToEyeValley);
        public static bool beenToSpiderCave;
        public static Condition HasBeenToSpiderCave = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToSpiderCave"), () => beenToSpiderCave);
        public static bool beenToCatacombs;
        public static Condition HasBeenToCatacombs = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCatacombs"), () => beenToCatacombs);
        public static bool beenToCemetery;
        public static Condition HasBeenToCemetery = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToCemetery"), () => beenToCemetery);


        //STARLIGHT RIVER
        public static bool starlightRiverLoaded;
        public static Mod starlightRiverMod;
        //BOSSES
        public static bool downedAuroracle;
        public static Condition DownedAuroracle = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAuroracle"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Auroracle]);
        public static bool downedCeiros;
        public static Condition DownedCeiros = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCeiros"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Ceiros]);
        //MINIBOSSES
        public static bool downedGlassweaver;
        public static Condition DownedGlassweaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGlassweaver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Glassweaver]);
        //BIOMES
        public static bool beenToAuroracleTemple;
        public static Condition HasBeenToAuroracleTemple = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAuroracleTemple"), () => beenToAuroracleTemple);
        public static bool beenToVitricDesert;
        public static Condition HasBeenToVitricDesert = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToVitricDesert"), () => beenToVitricDesert);
        public static bool beenToVitricTemple;
        public static Condition HasBeenToVitricTemple = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToVitricTemple"), () => beenToVitricTemple);


        //STARS ABOVE
        public static bool starsAboveLoaded;
        public static Mod starsAboveMod;
        //BOSSES
        public static bool downedVagrantofSpace;
        public static Condition DownedVagrantofSpace = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedVagrantofSpace"), () => downedVagrantofSpace);
        public static bool downedThespian;
        public static Condition DownedThespian = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedThespian"), () => downedThespian);
        public static bool downedCastor;
        public static bool downedPollux;
        public static bool downedDioskouroi;
        public static Condition DownedDioskouroi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDioskouroi"), () => downedDioskouroi);
        public static bool downedNalhaun;
        public static Condition DownedNalhaun = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNalhaun"), () => downedNalhaun);
        public static bool downedStarfarers;
        public static Condition DownedStarfarers = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarfarers"), () => downedStarfarers);
        public static bool downedPenthesilea;
        public static Condition DownedPenthesilea = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPenthesilea"), () => downedPenthesilea);
        public static bool downedArbitration;
        public static Condition DownedArbitration = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedArbitration"), () => downedArbitration);
        public static bool downedWarriorOfLight;
        public static Condition DownedWarriorOfLight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedWarriorOfLight"), () => downedWarriorOfLight);
        public static bool downedTsukiyomi;
        public static Condition DownedTsukiyomi = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTsukiyomi"), () => downedTsukiyomi);


        //STORM DIVERS MOD
        public static bool stormsAdditionsLoaded;
        public static Mod stormsAdditionsMod;
        //BOSSES
        public static bool downedAncientHusk;
        public static Condition DownedAncientHusk = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAncientHusk"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AncientHusk]);
        public static bool downedOverloadedScandrone;
        public static Condition DownedOverloadedScandrone = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedOverloadedScandrone"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.OverloadedScandrone]);
        public static bool downedPainbringer;
        public static Condition DownedPainbringer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPainbringer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Painbringer]);


        //STRAMS CLASSES
        public static bool stramsClassesLoaded;
        public static Mod stramsClassesMod;


        //SUPERNOVA
        public static bool supernovaLoaded;
        public static Mod supernovaMod;
        //BOSSES
        public static bool downedHarbingerOfAnnihilation;
        public static Condition DownedHarbingerOfAnnihilation = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHarbingerOfAnnihilation"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HarbingerOfAnnihilation]);
        public static bool downedFlyingTerror;
        public static Condition DownedFlyingTerror = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFlyingTerror"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.FlyingTerror]);
        public static bool downedStoneMantaRay;
        public static Condition DownedStoneMantaRay = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStoneMantaRay"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StoneMantaRay]);
        //MINIBOSSES
        public static bool downedBloodweaver;
        public static Condition DownedBloodweaver = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBloodweaver"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodweaver]);


        //TERRORBORN
        public static bool terrorbornLoaded;
        public static Mod terrorbornMod;
        //BOSSES
        public static bool downedInfectedIncarnate;
        public static Condition DownedInfectedIncarnate = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedInfectedIncarnate"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.InfectedIncarnate]);
        public static bool downedTidalTitan;
        public static Condition DownedTidalTitan = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedTidalTitan"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.TidalTitan]);
        public static bool downedDunestock;
        public static Condition DownedDunestock = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDunestock"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dunestock]);
        public static bool downedHexedConstructor;
        public static Condition DownedHexedConstructor = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedHexedConstructor"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.HexedConstructor]);
        public static bool downedShadowcrawler;
        public static Condition DownedShadowcrawler = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedShadowcrawler"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Shadowcrawler]);
        public static bool downedPrototypeI;
        public static Condition DownedPrototypeI = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrototypeI"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PrototypeI]);


        //THORIUM
        public static bool thoriumLoaded;
        public static Mod thoriumMod;
        //BOSSES
        public static bool downedGrandThunderBird;
        public static Condition DownedGrandThunderBird = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGrandThunderBird"), () => downedGrandThunderBird);
        public static bool downedQueenJellyfish;
        public static Condition DownedQueenJellyfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedQueenJellyfish"), () => downedQueenJellyfish);
        public static bool downedViscount;
        public static Condition DownedViscount = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedViscount"), () => downedViscount);
        public static bool downedGraniteEnergyStorm;
        public static Condition DownedGraniteEnergyStorm = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGraniteEnergyStorm"), () => downedGraniteEnergyStorm);
        public static bool downedBuriedChampion;
        public static Condition DownedBuriedChampion = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBuriedChampion"), () => downedBuriedChampion);
        public static bool downedStarScouter;
        public static Condition DownedStarScouter = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStarScouter"), () => downedStarScouter);
        public static bool downedBoreanStrider;
        public static Condition DownedBoreanStrider = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBoreanStrider"), () => downedBoreanStrider);
        public static bool downedFallenBeholder;
        public static Condition DownedFallenBeholder = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedFallenBeholder"), () => downedFallenBeholder);
        public static bool downedLich;
        public static Condition DownedLich = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedLich"), () => downedLich);
        public static bool downedForgottenOne;
        public static Condition DownedForgottenOne = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedForgottenOne"), () => downedForgottenOne);
        public static bool downedPrimordials;
        public static Condition DownedPrimordials = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPrimordials"), () => downedPrimordials);
        //MINIBOSSES
        public static bool downedPatchWerk;
        public static Condition DownedPatchWerk = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPatchWerk"), () => downedPatchWerk);
        public static bool downedCorpseBloom;
        public static Condition DownedCorpseBloom = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCorpseBloom"), () => downedCorpseBloom);
        public static bool downedIllusionist;
        public static Condition DownedIllusionist = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedIllusionist"), () => downedIllusionist);
        //BIOMES
        public static bool beenToAquaticDepths;
        public static Condition HasBeenToAquaticDepths = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToAquaticDepths"), () => beenToAquaticDepths);


        //THORIUM BOSSES REWORK
        public static bool thoriumBossReworkLoaded;
        public static Mod thoriumBossReworkMod;


        //THORIUM EXHAUSTION DISABLER
        public static bool exhaustionDisablerLoaded;
        public static Mod exhaustionDisablerMod;


        //TRAE
        public static bool traeLoaded;
        public static Mod traeMod;
        public static bool downedGraniteOvergrowth;
        public static Condition DownedGraniteOvergrowth = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGraniteOvergrowth"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GraniteOvergrowth]);
        public static bool downedBeholder;
        public static Condition DownedBeholder = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedBeholder"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Beholder]);


        //UHTRIC
        public static bool uhtricLoaded;
        public static Mod uhtricMod;
        public static bool downedDredger;
        public static Condition DownedDredger = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDredger"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dredger]);
        public static bool downedCharcoolSnowman;
        public static Condition DownedCharcoolSnowman = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCharcoolSnowman"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CharcoolSnowman]);
        public static bool downedCosmicMenace;
        public static Condition DownedCosmicMenace = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedCosmicMenace"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.CosmicMenace]);


        //UNIVERSE OF SWORDS
        public static bool universeOfSwordsLoaded;
        public static Mod universeOfSwordsMod;
        public static bool downedEvilFlyingBlade;
        public static Condition DownedEvilFlyingBlade = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEvilFlyingBlade"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EvilFlyingBlade]);


        //VALHALLA
        public static bool valhallaLoaded;
        public static Mod valhallaMod;
        //BOSSES
        public static bool downedColossalCarnage;
        public static Condition DownedColossalCarnage = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedColossalCarnage"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.ColossalCarnage]);
        public static bool downedYurnero;
        public static Condition DownedYurnero = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedYurnero"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Yurnero]);


        //VERDANT
        public static bool verdantLoaded;
        public static Mod verdantMod;
        //BIOMES
        public static bool beenToVerdant;
        public static Condition HasBeenToVerdant = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.beenToVerdant"), () => beenToVerdant);


        //VITALITY
        public static bool vitalityLoaded;
        public static Mod vitalityMod;
        //BOSSES
        public static bool downedStormCloud;
        public static Condition DownedStormCloud = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedStormCloud"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloud]);
        public static bool downedGrandAntlion;
        public static Condition DownedGrandAntlion = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGrandAntlion"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GrandAntlion]);
        public static bool downedGemstoneElemental;
        public static Condition DownedGemstoneElemental = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedGemstoneElemental"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.GemstoneElemental]);
        public static bool downedMoonlightDragonfly;
        public static Condition DownedMoonlightDragonfly = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMoonlightDragonfly"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MoonlightDragonfly]);
        public static bool downedDreadnaught;
        public static Condition DownedDreadnaught = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDreadnaught"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dreadnaught]);
        public static bool downedMosquitoMonarch;
        public static Condition DownedMosquitoMonarch = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMosquitoMonarch"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.MosquitoMonarch]);
        public static bool downedAnarchulesBeetle;
        public static Condition DownedAnarchulesBeetle = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAnarchulesBeetle"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.AnarchulesBeetle]);
        public static bool downedChaosbringer;
        public static Condition DownedChaosbringer = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedChaosbringer"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Chaosbringer]);
        public static bool downedPaladinSpirit;
        public static Condition DownedPaladinSpirit = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedPaladinSpirit"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.PaladinSpirit]);


        //WAYFAIR CONTENT
        public static bool wayfairContentLoaded;
        public static Mod wayfairContentMod;
        //BOSSES
        public static bool downedManaflora;
        public static Condition DownedManaflora = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedManaflora"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Manaflora]);


        //WRATH OF THE GODS
        public static bool wrathOfTheGodsLoaded;
        public static Mod wrathOfTheGodsMod;
        //BOSSES
        public static bool downedNoxus;
        public static Condition DownedNoxus = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNoxus"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Noxus]);
        public static bool downedNamelessDeityOfLight;
        public static Condition DownedNamelessDeityOfLight = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedNamelessDeityOfLight"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.NamelessDeityOfLight]);


        //ZYLON
        public static bool zylonLoaded;
        public static Mod zylonMod;
        //BOSSES
        public static bool downedDirtball;
        public static Condition DownedDirtball = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedDirtball"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Dirtball]);
        public static bool downedMetelord;
        public static Condition DownedMetelord = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedMetelord"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Metelord]);
        public static bool downedAdeneb;
        public static Condition DownedAdeneb = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedAdeneb"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.Adeneb]);
        public static bool downedEldritchJellyfish;
        public static Condition DownedEldritchJellyfish = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedEldritchJellyfish"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.EldritchJellyfish]);
        public static bool downedSaburRex;
        public static Condition DownedSaburRex = new(Language.GetTextValue("Mods.QoLCompendium.ModConditions.downedSaburRex"), () => ModConditions.DownedBoss[(int)ModConditions.Downed.SaburRex]);


        public enum Downed
        {
            //vanilla
            Dreadnautilus,
            MartianSaucer,
            BloodMoon,
            Eclipse,
            LunarEvent,
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
            CragmawMire,
            NuclearTerror,
            Mauler,
            //calamity community remix
            WulfrumExcavator,
            //calamity entropy
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
            GintzeArmy,
            //martains order
            Britzz,
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
            DinoMilitia,
            Invaders,
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
            FowlMorning,
            Raveyard,
            //secrets of the shadows
            PutridPinky,
            Glowmoth,
            PharaohsCurse,
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
            JellyDeluge,
            Tide,
            MysticMoon,
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
            Noxus,
            NamelessDeityOfLight,
            //zylon
            Dirtball,
            Metelord,
            Adeneb,
            EldritchJellyfish,
            SaburRex
        }

        public static bool[] downedBoss = new bool[Enum.GetValues(typeof(Downed)).Length];

        public static bool[] DownedBoss { get => downedBoss; set => downedBoss = value; }
        #endregion

        public override void Unload() => DownedBoss = null;

        public override void OnWorldLoad() => ResetDowned();

        public override void OnWorldUnload() => ResetDowned();

        public override void PostUpdateEverything()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || Main.netMode == NetmodeID.Server || QoLCompendium.mainConfig.RemoveBiomeShopRequirements)
            {
                //VANILLA
                //EVENTS
                beenThroughNight = true;
                //BIOMES
                beenToPurity = true;
                beenToCavernsOrUnderground = true;
                beenToUnderworld = true;
                beenToSky = true;
                beenToSnow = true;
                beenToDesert = true;
                beenToOcean = true;
                beenToJungle = true;
                beenToMushroom = true;
                beenToCorruption = true;
                beenToCrimson = true;
                beenToHallow = true;
                beenToTemple = true;
                beenToDungeon = true;
                beenToAether = true;

                //AEQUUS
                //BIOMES
                beenToCrabCrevice = true;

                //CAlAMITY
                //BIOMES
                beenToCrags = true;
                beenToAstral = true;
                beenToSunkenSea = true;
                beenToSulphurSea = true;
                beenToAbyss = true;
                beenToAbyssLayer1 = true;
                beenToAbyssLayer2 = true;
                beenToAbyssLayer3 = true;
                beenToAbyssLayer4 = true;

                //CALAMITY VANITIES
                //BIOMES
                beenToAstralBlight = true;

                //CONFECTION
                //BIOMES
                beenToConfection = true;

                //DEPTHS
                //BIOMES
                beenToDepths = true;

                //EVERJADE
                //BIOMES
                beenToJadeLake = true;

                //EXXO AVALON ORIGINS
                //BIOMES
                beenToContagion = true;

                //FRACTURES OF PENUMBRA
                //BIOMES
                beenToDread = true;

                //HOMEWARD JOURNEY
                //BIOMES
                beenToHomewardAbyss = true;

                //INFERNUM
                //BIOMES
                beenToProfanedGardens = true;

                //LUNAR VEIL
                //BIOMES
                beenToLunarVeilAbyss = true;
                beenToAcid = true;
                beenToAurelus = true;
                beenToFable = true;
                beenToGovheilCastle = true;
                beenToCathedral = true;
                beenToMarrowSurface = true;
                beenToMorrowUnderground = true;

                //QWERTY
                //BIOMES
                beenToSkyFortress = true;

                //REDEMPTION
                //BIOMES
                beenToLab = true;
                beenToWasteland = true;

                //SOTS
                //BIOMES
                beenToPyramid = true;
                beenToPlanetarium = true;

                //SHADOWS OF ABADDON
                //BIOMES
                beenToCinderForest = true;

                //SPIRIT
                //BIOMES
                beenToBriar = true;
                beenToSpirit = true;

                //SPOOKY
                //BIOMES
                beenToSpookyForest = true;
                beenToSpookyUnderground = true;
                beenToEyeValley = true;
                beenToSpiderCave = true;
                beenToCatacombs = true;
                beenToCemetery = true;

                //STARLIGHT RIVER
                //BIOMES
                beenToAuroracleTemple = true;
                beenToVitricDesert = true;
                beenToVitricTemple = true;

                //THORIUM
                //BIOMES
                beenToAquaticDepths = true;

                //VERDANT
                //BIOMES
                beenToVerdant = true;
            }
        }

        public override void PreUpdatePlayers()
        {
            #region Vanilla Events
            if (Main.bloodMoon && !waitForBloodMoon)
            {
                waitForBloodMoon = true;
            }
            if (waitForBloodMoon && !Main.bloodMoon && Main.dayTime)
            {
                downedBloodMoon = true;
            }
            if (waitForBloodMoon && !Main.bloodMoon && !Main.dayTime)
            {
                waitForBloodMoon = false;
            }
            if (Main.eclipse && !waitForEclipse)
            {
                waitForEclipse = true;
            }
            if (waitForEclipse && !Main.eclipse && !Main.dayTime)
            {
                downedEclipse = true;
            }
            if (waitForEclipse && !Main.eclipse && Main.dayTime)
            {
                waitForEclipse = false;
            }
            if (NPC.downedTowerNebula && NPC.downedTowerSolar && NPC.downedTowerStardust && NPC.downedTowerVortex)
            {
                downedLunarEvent = true;
            }
            if (!Main.dayTime)
            {
                beenThroughNight = true;
            }
            #endregion

            #region Vanilla Biomes
            if (Main.LocalPlayer.ZoneForest)
            {
                beenToPurity = true;
            }
            if (Main.LocalPlayer.ZoneNormalCaverns || Main.LocalPlayer.ZoneNormalUnderground)
            {
                beenToCavernsOrUnderground = true;
            }
            if (Main.LocalPlayer.ZoneUnderworldHeight)
            {
                beenToUnderworld = true;
            }
            if (Main.LocalPlayer.ZoneSkyHeight)
            {
                beenToSky = true;
            }
            if (Main.LocalPlayer.ZoneSnow)
            {
                beenToSnow = true;
            }
            if (Main.LocalPlayer.ZoneDesert || Main.LocalPlayer.ZoneUndergroundDesert)
            {
                beenToDesert = true;
            }
            if (Main.LocalPlayer.ZoneBeach)
            {
                beenToOcean = true;
            }
            if (Main.LocalPlayer.ZoneJungle)
            {
                beenToJungle = true;
            }
            if (Main.LocalPlayer.ZoneGlowshroom)
            {
                beenToMushroom = true;
            }
            if (Main.LocalPlayer.ZoneCorrupt)
            {
                beenToCorruption = true;
            }
            if (Main.LocalPlayer.ZoneCrimson)
            {
                beenToCrimson = true;
            }
            if (Main.LocalPlayer.ZoneHallow)
            {
                beenToHallow = true;
            }
            if (Main.LocalPlayer.ZoneLihzhardTemple)
            {
                beenToTemple = true;
            }
            if (Main.LocalPlayer.ZoneDungeon)
            {
                beenToDungeon = true;
            }
            if (Main.LocalPlayer.ZoneShimmer)
            {
                beenToAether = true;
            }
            #endregion

            if (aequusLoaded)
            {
                #region Bosses & Events
                downedCrabson = (bool)aequusMod.Call("downedCrabson");
                downedOmegaStarite = (bool)aequusMod.Call("downedOmegaStarite");
                downedDustDevil = (bool)aequusMod.Call("downedDustDevil");
                downedRedSprite = (bool)aequusMod.Call("downedRedSprite");
                downedSpaceSquid = (bool)aequusMod.Call("downedSpaceSquid");
                downedHyperStarite = (bool)aequusMod.Call("downedHyperStarite");
                downedUltraStarite = (bool)aequusMod.Call("downedUltraStarite");
                //Events
                downedDemonSiege = (bool)aequusMod.Call("downedEventDemon");
                downedGlimmer = (bool)aequusMod.Call("downedEventCosmic");
                downedGaleStreams = (bool)aequusMod.Call("downedEventAtmosphere");
                #endregion

                #region Biomes
                if (aequusMod.TryFind("CrabCreviceBiome", out ModBiome CrabCreviceBiome) && Main.LocalPlayer.InModBiome(CrabCreviceBiome))
                    beenToCrabCrevice = true;
                #endregion
            }

            if (calamityLoaded)
            {
                #region Bosses & Events
                //Bosses

                downedDesertScourge = (bool)calamityMod.Call("GetBossDowned", "DesertScourge");
                downedCrabulon = (bool)calamityMod.Call("GetBossDowned", "Crabulon");
                downedHiveMind = (bool)calamityMod.Call("GetBossDowned", "HiveMind");
                downedPerforators = (bool)calamityMod.Call("GetBossDowned", "Perforator");
                downedSlimeGod = (bool)calamityMod.Call("GetBossDowned", "SlimeGod");
                downedCryogen = (bool)calamityMod.Call("GetBossDowned", "Cryogen");
                downedAquaticScourge = (bool)calamityMod.Call("GetBossDowned", "AquaticScourge");
                downedBrimstoneElemental = (bool)calamityMod.Call("GetBossDowned", "BrimstoneElemental");
                downedCalamitasClone = (bool)calamityMod.Call("GetBossDowned", "CalamitasClone");
                downedLeviathanAndAnahita = (bool)calamityMod.Call("GetBossDowned", "AnahitaLeviathan");
                downedAstrumAureus = (bool)calamityMod.Call("GetBossDowned", "AstrumAureus");
                downedPlaguebringerGoliath = (bool)calamityMod.Call("GetBossDowned", "PlaguebringerGoliath");
                downedRavager = (bool)calamityMod.Call("GetBossDowned", "Ravager");
                downedAstrumDeus = (bool)calamityMod.Call("GetBossDowned", "AstrumDeus");
                downedProfanedGuardians = (bool)calamityMod.Call("GetBossDowned", "Guardians");
                downedDragonfolly = (bool)calamityMod.Call("GetBossDowned", "Dragonfolly");
                downedProvidence = (bool)calamityMod.Call("GetBossDowned", "Providence");
                downedStormWeaver = (bool)calamityMod.Call("GetBossDowned", "StormWeaver");
                downedCeaselessVoid = (bool)calamityMod.Call("GetBossDowned", "CeaselessVoid");
                downedSignus = (bool)calamityMod.Call("GetBossDowned", "Signus");
                downedPolterghast = (bool)calamityMod.Call("GetBossDowned", "Polterghast");
                downedOldDuke = (bool)calamityMod.Call("GetBossDowned", "OldDuke");
                downedDevourerOfGods = (bool)calamityMod.Call("GetBossDowned", "DevourerOfGods");
                downedYharon = (bool)calamityMod.Call("GetBossDowned", "Yharon");
                downedExoMechs = (bool)calamityMod.Call("GetBossDowned", "ExoMechs");
                downedSupremeCalamitas = (bool)calamityMod.Call("GetBossDowned", "SupremeCalamitas");
                //Minibosses
                downedGiantClam = (bool)calamityMod.Call("GetBossDowned", "GiantClam");
                downedCragmawMire = (bool)calamityMod.Call("GetBossDowned", "cragmawmire");
                downedGreatSandShark = (bool)calamityMod.Call("GetBossDowned", "GreatSandShark");
                downedMauler = (bool)calamityMod.Call("GetBossDowned", "mauler");
                downedNuclearTerror = (bool)calamityMod.Call("GetBossDowned", "nuclearterror");
                downedEidolonWyrm = (bool)calamityMod.Call("GetBossDowned", "primordialwyrm");
                //Events
                downedAcidRain1 = (bool)calamityMod.Call("GetBossDowned", "acidraineoc");
                downedAcidRain2 = (bool)calamityMod.Call("GetBossDowned", "acidrainscourge");
                downedBossRush = (bool)calamityMod.Call("GetBossDowned", "bossrush");

                #endregion

                #region Biomes
                if (calamityMod.TryFind("AstralInfectionBiome", out ModBiome AstralInfectionBiome) && Main.LocalPlayer.InModBiome(AstralInfectionBiome))
                    beenToAstral = true;

                if (calamityMod.TryFind("AbyssLayer1Biome", out ModBiome AbyssLayer1Biome) && Main.LocalPlayer.InModBiome(AbyssLayer1Biome))
                {
                    beenToAbyss = true;
                    beenToAbyssLayer1 = true;
                }
                if (calamityMod.TryFind("AbyssLayer2Biome", out ModBiome AbyssLayer2Biome) && Main.LocalPlayer.InModBiome(AbyssLayer2Biome))
                {
                    beenToAbyss = true;
                    beenToAbyssLayer2 = true;
                }

                if (calamityMod.TryFind("AbyssLayer3Biome", out ModBiome AbyssLayer3Biome) && Main.LocalPlayer.InModBiome(AbyssLayer3Biome))
                {
                    beenToAbyss = true;
                    beenToAbyssLayer3 = true;
                }
                if (calamityMod.TryFind("AbyssLayer4Biome", out ModBiome AbyssLayer4Biome) && Main.LocalPlayer.InModBiome(AbyssLayer4Biome))
                {
                    beenToAbyss = true;
                    beenToAbyssLayer4 = true;
                }

                if (calamityMod.TryFind("BrimstoneCragsBiome", out ModBiome BrimstoneCragsBiome) && Main.LocalPlayer.InModBiome(BrimstoneCragsBiome))
                    beenToCrags = true;

                if (calamityMod.TryFind("SulphurousSeaBiome", out ModBiome SulphurousSeaBiome) && Main.LocalPlayer.InModBiome(SulphurousSeaBiome))
                    beenToSulphurSea = true;

                if (calamityMod.TryFind("SunkenSeaBiome", out ModBiome SunkenSeaBiome) && Main.LocalPlayer.InModBiome(SunkenSeaBiome))
                    beenToSunkenSea = true;
                #endregion
            }

            if (calamityVanitiesLoaded)
            {
                if (calamityVanitiesMod.TryFind("AstralBlight", out ModBiome AstralBlight) && Main.LocalPlayer.InModBiome(AstralBlight))
                {
                    beenToAstralBlight = true;
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
                    beenToConfection = true;
                    beenToHallow = true;
                }
            }

            if (depthsLoaded)
            {
                if (depthsMod.TryFind("DepthsBiome", out ModBiome DepthsBiome) && Main.LocalPlayer.InModBiome(DepthsBiome))
                {
                    beenToDepths = true;
                    beenToUnderworld = true;
                }
            }

            if (everjadeLoaded)
            {
                if (everjadeMod.TryFind("JadeLakeBiome", out ModBiome JadeLakeBiome) && Main.LocalPlayer.InModBiome(JadeLakeBiome))
                {
                    beenToJadeLake = true;
                }
            }

            if (exxoAvalonOriginsLoaded)
            {
                if ((exxoAvalonOriginsMod.TryFind("Contagion", out ModBiome Contagion) && Main.LocalPlayer.InModBiome(Contagion))
                    || (exxoAvalonOriginsMod.TryFind("UndergroundContagion", out ModBiome UndergroundContagion) && Main.LocalPlayer.InModBiome(UndergroundContagion))
                    || (exxoAvalonOriginsMod.TryFind("ContagionDesert", out ModBiome ContagionDesert) && Main.LocalPlayer.InModBiome(ContagionDesert))
                    || (exxoAvalonOriginsMod.TryFind("ContagionCaveDesert", out ModBiome ContagionCaveDesert) && Main.LocalPlayer.InModBiome(ContagionCaveDesert)))
                {
                    beenToContagion = true;
                }
            }

            if (fracturesOfPenumbraLoaded)
            {
                if ((fracturesOfPenumbraMod.TryFind("DreadSurfaceBiome", out ModBiome DreadSurfaceBiome) && Main.LocalPlayer.InModBiome(DreadSurfaceBiome))
                    || (fracturesOfPenumbraMod.TryFind("DreadUndergroundBiome", out ModBiome DreadUndergroundBiome) && Main.LocalPlayer.InModBiome(DreadUndergroundBiome)))
                {
                    beenToDread = true;
                }
            }

            if (homewardJourneyLoaded)
            {
                if (homewardJourneyMod.TryFind("AbyssUndergroundBiome", out ModBiome AbyssUndergroundBiome) && Main.LocalPlayer.InModBiome(AbyssUndergroundBiome))
                {
                    beenToHomewardAbyss = true;
                }
            }

            if (infernumLoaded)
            {
                if (infernumMod.TryFind("ProfanedTempleBiome", out ModBiome ProfanedTempleBiome) && Main.LocalPlayer.InModBiome(ProfanedTempleBiome))
                {
                    beenToProfanedGardens = true;
                }
            }

            if (lunarVeilLoaded)
            {
                if (lunarVeilMod.TryFind("AbyssBiome", out ModBiome AbyssBiome) && Main.LocalPlayer.InModBiome(AbyssBiome))
                {
                    beenToLunarVeilAbyss = true;
                }
                if (lunarVeilMod.TryFind("AcidBiome", out ModBiome AcidBiome) && Main.LocalPlayer.InModBiome(AcidBiome))
                {
                    beenToAcid = true;
                }
                if (lunarVeilMod.TryFind("AurelusBiome", out ModBiome AurelusBiome) && Main.LocalPlayer.InModBiome(AurelusBiome))
                {
                    beenToAurelus = true;
                }
                if (lunarVeilMod.TryFind("FableBiome", out ModBiome FableBiome) && Main.LocalPlayer.InModBiome(FableBiome))
                {
                    beenToFable = true;
                }
                if (lunarVeilMod.TryFind("GovheilCastle", out ModBiome GovheilCastle) && Main.LocalPlayer.InModBiome(GovheilCastle))
                {
                    beenToGovheilCastle = true;
                }
                if (lunarVeilMod.TryFind("CathedralBiome", out ModBiome CathedralBiome) && Main.LocalPlayer.InModBiome(CathedralBiome))
                {
                    beenToCathedral = true;
                }
                if (lunarVeilMod.TryFind("MarrowSurfaceBiome", out ModBiome MarrowSurfaceBiome) && Main.LocalPlayer.InModBiome(MarrowSurfaceBiome))
                {
                    beenToMarrowSurface = true;
                }
                if (lunarVeilMod.TryFind("MorrowUndergroundBiome", out ModBiome MorrowUndergroundBiome) && Main.LocalPlayer.InModBiome(MorrowUndergroundBiome))
                {
                    beenToMorrowUnderground = true;
                }
            }

            if (qwertyLoaded)
            {
                if (qwertyMod.TryFind("FortressBiome", out ModBiome FortressBiome) && Main.LocalPlayer.InModBiome(FortressBiome))
                {
                    beenToSkyFortress = true;
                }
            }

            if (redemptionLoaded)
            {
                if (redemptionMod.TryFind("LabBiome", out ModBiome LabBiome) && Main.LocalPlayer.InModBiome(LabBiome))
                {
                    beenToLab = true;
                }
                if (redemptionMod.TryFind("WastelandPurityBiome", out ModBiome WastelandPurityBiome) && Main.LocalPlayer.InModBiome(WastelandPurityBiome))
                {
                    beenToWasteland = true;
                }
                /*
                if (downedAkka && downedUkko)
                {
                    downedAncientDeityDuo = true;
                }
                */
            }

            if (secretsOfTheShadowsLoaded)
            {
                if (secretsOfTheShadowsMod.TryFind("PyramidBiome", out ModBiome PyramidBiome) && Main.LocalPlayer.InModBiome(PyramidBiome))
                {
                    beenToPyramid = true;
                }
                if (secretsOfTheShadowsMod.TryFind("PlanetariumBiome", out ModBiome PlanetariumBiome) && Main.LocalPlayer.InModBiome(PlanetariumBiome))
                {
                    beenToPlanetarium = true;
                }
            }

            if (shadowsOfAbaddonLoaded)
            {
                if ((shadowsOfAbaddonMod.TryFind("CinderDesertBiome", out ModBiome CinderDesertBiome) && Main.LocalPlayer.InModBiome(CinderDesertBiome)) || (shadowsOfAbaddonMod.TryFind("CinderForestBiome", out ModBiome CinderForestBiome) && Main.LocalPlayer.InModBiome(CinderForestBiome)) || (shadowsOfAbaddonMod.TryFind("CinderForestUndergroundBiome", out ModBiome CinderForestUndergroundBiome) && Main.LocalPlayer.InModBiome(CinderForestUndergroundBiome)))
                {
                    beenToCinderForest = true;
                }
            }

            if (spiritLoaded)
            {
                if ((spiritMod.TryFind("BriarSurfaceBiome", out ModBiome BriarSurfaceBiome) && Main.LocalPlayer.InModBiome(BriarSurfaceBiome))
                    || (spiritMod.TryFind("BriarUndergroundBiome", out ModBiome BriarUndergroundBiome) && Main.LocalPlayer.InModBiome(BriarUndergroundBiome)))
                {
                    beenToBriar = true;
                }
                if ((spiritMod.TryFind("SpiritSurfaceBiome", out ModBiome SpiritSurfaceBiome) && Main.LocalPlayer.InModBiome(SpiritSurfaceBiome))
                    || (spiritMod.TryFind("SpiritUndergroundBiome", out ModBiome SpiritUndergroundBiome) && Main.LocalPlayer.InModBiome(SpiritUndergroundBiome)))
                {
                    beenToSpirit = true;
                }
            }

            if (spookyLoaded)
            {
                if (spookyMod.TryFind("SpookyBiome", out ModBiome SpookyBiome) && Main.LocalPlayer.InModBiome(SpookyBiome))
                {
                    beenToSpookyForest = true;
                }
                if (spookyMod.TryFind("SpookyBiomeUg", out ModBiome SpookyBiomeUg) && Main.LocalPlayer.InModBiome(SpookyBiomeUg))
                {
                    beenToSpookyUnderground = true;
                }
                if (spookyMod.TryFind("SpookyHellBiome", out ModBiome SpookyHellBiome) && Main.LocalPlayer.InModBiome(SpookyHellBiome))
                {
                    beenToEyeValley = true;
                }
                if (spookyMod.TryFind("SpiderCaveBiome", out ModBiome SpiderCaveBiome) && Main.LocalPlayer.InModBiome(SpiderCaveBiome))
                {
                    beenToSpiderCave = true;
                }
                if (spookyMod.TryFind("CatacombBiome", out ModBiome CatacombBiome) && Main.LocalPlayer.InModBiome(CatacombBiome))
                {
                    beenToCatacombs = true;
                }
                if (spookyMod.TryFind("CemeteryBiome", out ModBiome CemeteryBiome) && Main.LocalPlayer.InModBiome(CemeteryBiome))
                {
                    beenToCemetery = true;
                }
                /*
                if (downedOrro && downedBoro)
                {
                    downedOrroBoro = true;
                }
                */
            }

            if (starlightRiverLoaded)
            {
                if (starlightRiverMod.TryFind("PermafrostTempleBiome", out ModBiome PermafrostTempleBiome) && Main.LocalPlayer.InModBiome(PermafrostTempleBiome))
                {
                    beenToAuroracleTemple = true;
                }
                if (starlightRiverMod.TryFind("VitricDesertBiome", out ModBiome VitricDesertBiome) && Main.LocalPlayer.InModBiome(VitricDesertBiome))
                {
                    beenToVitricDesert = true;
                }
                if (starlightRiverMod.TryFind("VitricTempleBiome", out ModBiome VitricTempleBiome) && Main.LocalPlayer.InModBiome(VitricTempleBiome))
                {
                    beenToVitricTemple = true;
                }
            }

            if (starsAboveLoaded)
            {
                downedVagrantofSpace = (bool)starsAboveMod.Call("downedVagrant", Mod);
                downedThespian = (bool)starsAboveMod.Call("downedThespian", Mod);
                downedDioskouroi = (bool)starsAboveMod.Call("downedDioskouroi", Mod);
                downedNalhaun = (bool)starsAboveMod.Call("downedNalhaun", Mod);
                downedStarfarers = (bool)starsAboveMod.Call("downedStarfarers", Mod);
                downedPenthesilea = (bool)starsAboveMod.Call("downedPenthesilea", Mod);
                downedArbitration = (bool)starsAboveMod.Call("downedArbitration", Mod);
                downedWarriorOfLight = (bool)starsAboveMod.Call("downedWarriorOfLight", Mod);
                downedTsukiyomi = (bool)starsAboveMod.Call("downedTsukiyomi", Mod);

                if (downedCastor && downedPollux)
                {
                    downedDioskouroi = true;
                }
            }

            if (thoriumLoaded)
            {
                #region Bosses
                downedGrandThunderBird = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "TheGrandThunderBird"
                });
                downedQueenJellyfish = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "QueenJellyfish"
                });
                downedViscount = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "Viscount"
                });
                downedGraniteEnergyStorm = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "GraniteEnergyStorm"
                });
                downedBuriedChampion = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "BuriedChampion"
                });
                downedStarScouter = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "StarScouter"
                });
                downedBoreanStrider = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "BoreanStrider"
                });
                downedFallenBeholder = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "FallenBeholder"
                });
                downedLich = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "Lich"
                });
                downedForgottenOne = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "ForgottenOne"
                });
                downedPrimordials = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "ThePrimordials"
                });
                downedPatchWerk = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "PatchWerk"
                });
                downedCorpseBloom = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "CorpseBloom"
                });
                downedIllusionist = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "Illusionist"
                });
                #endregion

                #region Biomes
                if (thoriumMod.TryFind("DepthsBiome", out ModBiome DepthsBiome) && Main.LocalPlayer.InModBiome(DepthsBiome))
                {
                    beenToAquaticDepths = true;
                }
                #endregion
            }

            if (verdantLoaded)
            {
                if (verdantMod.TryFind("VerdantBiome", out ModBiome VerdantBiome) && Main.LocalPlayer.InModBiome(VerdantBiome))
                {
                    beenToVerdant = true;
                }
            }

            if (wrathOfTheGodsLoaded)
            {
                downedNoxus = (bool)wrathOfTheGodsMod.Call("GetBossDefeated", "noxus");
                downedNamelessDeityOfLight = (bool)wrathOfTheGodsMod.Call("GetBossDefeated", "namelessdeity");
            }
        }

        public override void SaveWorldData(TagCompound tag)
        {
            //VANILLA
            //EVENTS
            tag.Add("downedBloodMoon", downedBloodMoon);
            tag.Add("downedEclipse", downedEclipse);
            tag.Add("downedLunarEvent", downedLunarEvent);
            tag.Add("beenThroughNight", beenThroughNight);
            //BIOMES
            tag.Add("beenToPurity", beenToPurity);
            tag.Add("beenToCavernsOrUnderground", beenToCavernsOrUnderground);
            tag.Add("beenToUnderworld", beenToUnderworld);
            tag.Add("beenToSky", beenToSky);
            tag.Add("beenToSnow", beenToSnow);
            tag.Add("beenToDesert", beenToDesert);
            tag.Add("beenToOcean", beenToOcean);
            tag.Add("beenToJungle", beenToJungle);
            tag.Add("beenToMushroom", beenToMushroom);
            tag.Add("beenToCorruption", beenToCorruption);
            tag.Add("beenToCrimson", beenToCrimson);
            tag.Add("beenToHallow", beenToHallow);
            tag.Add("beenToTemple", beenToTemple);
            tag.Add("beenToDungeon", beenToDungeon);
            tag.Add("beenToAether", beenToAether);
            //OTHER
            tag.Add("talkedToSkeletonMerchant", talkedToSkeletonMerchant);
            tag.Add("talkedToTravelingMerchant", talkedToTravelingMerchant);

            //AEQUUS
            //BIOMES
            tag.Add("beenToCrabCrevice", beenToCrabCrevice);

            //CALAMITY
            //BIOMES
            tag.Add("beenToCrags", beenToCrags);
            tag.Add("beenToAstral", beenToAstral);
            tag.Add("beenToSunkenSea", beenToSunkenSea);
            tag.Add("beenToSulphurSea", beenToSulphurSea);
            tag.Add("beenToAbyss", beenToAbyss);
            tag.Add("beenToAbyssLayer1", beenToAbyssLayer1);
            tag.Add("beenToAbyssLayer2", beenToAbyssLayer2);
            tag.Add("beenToAbyssLayer3", beenToAbyssLayer3);
            tag.Add("beenToAbyssLayer4", beenToAbyssLayer4);

            //CALAMITY VANITIES
            tag.Add("beenToAstralBlight", beenToAstralBlight);

            //DEPTHS
            tag.Add("beenToDepths", beenToDepths);

            //EVERJADE
            tag.Add("beenToJadeLake", beenToJadeLake);

            //EXXO AVALON ORIGINS
            tag.Add("beenToContagion", beenToContagion);

            //FRACTURES OF PENUMBRA
            //BIOMES
            tag.Add("beenToDread", beenToDread);

            //HOMEWARD JOURNEY
            //BIOMES
            tag.Add("beenToHomewardAbyss", beenToHomewardAbyss);

            //INFERNUM
            //BIOMES
            tag.Add("beenToProfanedGardens", beenToProfanedGardens);

            //LUNAR VEIL
            //BIOMES
            tag.Add("beenToLunarVeilAbyss", beenToLunarVeilAbyss);
            tag.Add("beenToAcid", beenToAcid);
            tag.Add("beenToAurelus", beenToAurelus);
            tag.Add("beenToFable", beenToFable);
            tag.Add("beenToGovheilCastle", beenToGovheilCastle);
            tag.Add("beenToCathedral", beenToCathedral);
            tag.Add("beenToMarrowSurface", beenToMarrowSurface);
            tag.Add("beenToMorrowUnderground", beenToMorrowUnderground);

            //QWERTY
            //BIOMES
            tag.Add("beenToSkyFortress", beenToSkyFortress);

            //REDEMPTION
            //BIOMES
            tag.Add("beenToLab", beenToLab);
            tag.Add("beenToWasteland", beenToWasteland);

            //SOTS
            //BIOMES
            tag.Add("beenToPyramid", beenToPyramid);
            tag.Add("beenToPlanetarium", beenToPlanetarium);

            //SHADOWS OF ABADDON
            //BIOMES
            tag.Add("beenToCinderForest", beenToCinderForest);

            //SPIRIT
            //BIOMES
            tag.Add("beenToBriar", beenToBriar);
            tag.Add("beenToSpirit", beenToSpirit);

            //SPOOKY
            //BIOMES
            tag.Add("beenToSpookyForest", beenToSpookyForest);
            tag.Add("beenToSpookyUnderground", beenToSpookyUnderground);
            tag.Add("beenToEyeValley", beenToEyeValley);
            tag.Add("beenToSpiderCave", beenToSpiderCave);
            tag.Add("beenToCatacombs", beenToCatacombs);
            tag.Add("beenToCemetery", beenToCemetery);

            //STARLIGHT RIVER
            //BIOMES
            tag.Add("beenToAuroracleTemple", beenToAuroracleTemple);
            tag.Add("beenToVitricDesert", beenToVitricDesert);
            tag.Add("beenToVitricTemple", beenToVitricTemple);

            //THORIUM
            //BIOMES
            tag.Add("beenToAquaticDepths", beenToAquaticDepths);

            //VERDANT
            tag.Add("beenToVerdant", beenToVerdant);

            List<string> downed = new();
            for (int i = 0; i < DownedBoss.Length; i++)
            {
                if (DownedBoss[i])
                    downed.Add("QoLCdownedBoss" + i);
            }
            tag.Add("QoLCdowned", downed);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            //VANILLA
            //EVENTS
            downedBloodMoon = tag.Get<bool>("downedBloodMoon");
            downedEclipse = tag.Get<bool>("downedEclipse");
            downedLunarEvent = tag.Get<bool>("downedLunarEvent");
            beenThroughNight = tag.Get<bool>("beenThroughNight");
            //BIOMES
            beenToPurity = tag.Get<bool>("beenToPurity");
            beenToCavernsOrUnderground = tag.Get<bool>("beenToCavernsOrUnderground");
            beenToUnderworld = tag.Get<bool>("beenToUnderworld");
            beenToSky = tag.Get<bool>("beenToSky");
            beenToSnow = tag.Get<bool>("beenToSnow");
            beenToDesert = tag.Get<bool>("beenToDesert");
            beenToOcean = tag.Get<bool>("beenToOcean");
            beenToJungle = tag.Get<bool>("beenToJungle");
            beenToMushroom = tag.Get<bool>("beenToMushroom");
            beenToCorruption = tag.Get<bool>("beenToCorruption");
            beenToCrimson = tag.Get<bool>("beenToCrimson");
            beenToHallow = tag.Get<bool>("beenToHallow");
            beenToTemple = tag.Get<bool>("beenToTemple");
            beenToDungeon = tag.Get<bool>("beenToDungeon");
            beenToAether = tag.Get<bool>("beenToAether");
            //OTHER
            talkedToSkeletonMerchant = tag.Get<bool>("talkedToSkeletonMerchant");
            talkedToTravelingMerchant = tag.Get<bool>("talkedToTravelingMerchant");

            //AEQUUS
            //BIOMES
            beenToCrabCrevice = tag.Get<bool>("beenToCrabCrevice");

            //CALAMITY
            //BIOMES
            beenToCrags = tag.Get<bool>("beenToCrags");
            beenToAstral = tag.Get<bool>("beenToAstral");
            beenToSunkenSea = tag.Get<bool>("beenToSunkenSea");
            beenToSulphurSea = tag.Get<bool>("beenToSulphurSea");
            beenToAbyss = tag.Get<bool>("beenToAbyss");
            beenToAbyssLayer1 = tag.Get<bool>("beenToAbyssLayer1");
            beenToAbyssLayer2 = tag.Get<bool>("beenToAbyssLayer2");
            beenToAbyssLayer3 = tag.Get<bool>("beenToAbyssLayer3");
            beenToAbyssLayer4 = tag.Get<bool>("beenToAbyssLayer4");

            //CALAMITY VANITIES
            beenToAstralBlight = tag.Get<bool>("beenToAstralBlight");

            //DEPTHS
            beenToDepths = tag.Get<bool>("beenToDepths");

            //EVERJADE
            beenToJadeLake = tag.Get<bool>("beenToJadeLake");

            //EXXO AVALON ORIGINS
            beenToContagion = tag.Get<bool>("beenToContagion");

            //FRACTURES OF PENUMBRA
            //BIOMES
            beenToDread = tag.Get<bool>("beenToDread");

            //HOMEWARD JOURNEY
            //BIOMES
            beenToHomewardAbyss = tag.Get<bool>("beenToHomewardAbyss");


            //INFERNUM
            //BIOMES
            beenToProfanedGardens = tag.Get<bool>("beenToProfanedGardens");

            //LUNAR VEIL
            //BIOMES
            beenToLunarVeilAbyss = tag.Get<bool>("beenToLunarVeilAbyss");
            beenToAcid = tag.Get<bool>("beenToAcid");
            beenToAurelus = tag.Get<bool>("beenToAurelus");
            beenToFable = tag.Get<bool>("beenToFable");
            beenToGovheilCastle = tag.Get<bool>("beenToGovheilCastle");
            beenToCathedral = tag.Get<bool>("beenToCathedral");
            beenToMarrowSurface = tag.Get<bool>("beenToMarrowSurface");
            beenToMorrowUnderground = tag.Get<bool>("beenToMorrowUnderground");

            //QWERTY
            //BIOMES
            beenToSkyFortress = tag.Get<bool>("beenToSkyFortress");

            //REDEMPTION
            //BIOMES
            beenToLab = tag.Get<bool>("beenToLab");
            beenToWasteland = tag.Get<bool>("beenToWasteland");

            //SOTS
            //BIOMES
            beenToPyramid = tag.Get<bool>("beenToPyramid");
            beenToPlanetarium = tag.Get<bool>("beenToPlanetarium");

            //SHADOWS OF ABADDON
            //BIOMES
            beenToCinderForest = tag.Get<bool>("beenToCinderForest");

            //SPIRIT
            //BIOMES
            beenToBriar = tag.Get<bool>("beenToBriar");
            beenToSpirit = tag.Get<bool>("beenToSpirit");

            //SPOOKY
            //BIOMES
            beenToSpookyForest = tag.Get<bool>("beenToSpookyForest");
            beenToSpookyUnderground = tag.Get<bool>("beenToSpookyUnderground");
            beenToEyeValley = tag.Get<bool>("beenToEyeValley");
            beenToSpiderCave = tag.Get<bool>("beenToSpiderCave");
            beenToCatacombs = tag.Get<bool>("beenToCatacombs");
            beenToCemetery = tag.Get<bool>("beenToCemetery");

            //STARLIGHT RIVER
            //BIOMES
            beenToAuroracleTemple = tag.Get<bool>("beenToAuroracleTemple");
            beenToVitricDesert = tag.Get<bool>("beenToVitricDesert");
            beenToVitricTemple = tag.Get<bool>("beenToVitricTemple");

            //THORIUM
            //BIOMES
            beenToAquaticDepths = tag.Get<bool>("beenToAquaticDepths");

            //VERDANT
            beenToVerdant = tag.Get<bool>("beenToVerdant");

            IList<string> downed = tag.GetList<string>("QoLCdowned");
            for (int i = 0; i < DownedBoss.Length; i++)
                DownedBoss[i] = downed.Contains($"QoLCdownedBoss{i}");
        }

        public override void NetSend(BinaryWriter writer)
        {
            //vanilla
            writer.Write(new BitsByte
            {
                [0] = downedDreadnautilus,
                [1] = downedMartianSaucer,
                [2] = downedBloodMoon,
                [3] = downedEclipse,
                [4] = downedLunarEvent
            });

            //afkpets
            writer.Write(new BitsByte
            {
                [0] = downedSlayerOfEvil,
                [1] = downedSATLA,
                [2] = downedDrFetus,
                [3] = downedSlimesHope,
                [4] = downedPoliticianSlime,
                [5] = downedAncientTrio,
                [6] = downedLavalGolem,
                [7] = downedAntony
            });
            writer.Write(new BitsByte
            {
                [0] = downedBunnyZeppelin,
                [1] = downedOkiku,
                [2] = downedHarpyAirforce,
                [3] = downedIsaac,
                [4] = downedAncientGuardian,
                [5] = downedHeroicSlime,
                [6] = downedHoloSlime,
                [7] = downedSecurityBot
            });
            writer.Write(new BitsByte
            {
                [0] = downedUndeadChef,
                [1] = downedGuardianOfFrost
            });

            //assorted crazy things
            writer.Write(new BitsByte
            {
                [0] = downedSoulHarvester
            });

            //awful garbage
            writer.Write(new BitsByte
            {
                [0] = downedTreeToad,
                [1] = downedSeseKitsugai,
                [2] = downedEyeOfTheStorm,
                [3] = downedFrigidius
            });

            //block's core boss
            writer.Write(new BitsByte
            {
                [0] = downedCoreBoss
            });

            //calamity
            writer.Write(new BitsByte
            {
                [0] = downedCragmawMire,
                [1] = downedNuclearTerror,
                [2] = downedMauler
            });

            //calamity community remix
            writer.Write(new BitsByte
            {
                [0] = downedWulfrumExcavator
            });

            //calamity entropy
            writer.Write(new BitsByte
            {
                [0] = downedCruiser
            });

            //catalyst
            writer.Write(new BitsByte
            {
                [0] = downedAstrageldon
            });

            //clamity
            writer.Write(new BitsByte
            {
                [0] = downedClamitas,
                [1] = downedPyrogen,
                [2] = downedWallOfBronze
            });

            //consolaria
            writer.Write(new BitsByte
            {
                [0] = downedLepus,
                [1] = downedTurkor,
                [2] = downedOcram
            });

            //coralite
            writer.Write(new BitsByte
            {
                [0] = downedRediancie,
                [1] = downedBabyIceDragon,
                [2] = downedSlimeEmperor,
                [3] = downedBloodiancie,
                [4] = downedThunderveinDragon,
                [5] = downedNightmarePlantera
            });

            //depths
            writer.Write(new BitsByte
            {
                [0] = downedChasme
            });

            //dormant dawn
            writer.Write(new BitsByte
            {
                [0] = downedLifeGuardian,
                [1] = downedManaGuardian,
                [2] = downedMeteorExcavator,
                [3] = downedMeteorAnnihilator,
                [4] = downedHellfireSerpent,
                [5] = downedWitheredAcornSpirit,
                [6] = downedGoblinSorcererChieftain
            });

            //echoes of the ancients
            writer.Write(new BitsByte
            {
                [0] = downedGalahis,
                [1] = downedCreation,
                [2] = downedDestruction
            });

            //edorbis
            writer.Write(new BitsByte
            {
                [0] = downedBlightKing,
                [1] = downedGardener,
                [2] = downedGlaciation,
                [3] = downedHandOfCthulhu,
                [4] = downedCursePreacher
            });

            //exalt
            writer.Write(new BitsByte
            {
                [0] = downedEffulgence,
                [1] = downedIceLich
            });

            //excelsior
            writer.Write(new BitsByte
            {
                [0] = downedNiflheim,
                [1] = downedStellarStarship
            });

            //exxo avalon origins
            writer.Write(new BitsByte
            {
                [0] = downedBacteriumPrime,
                [1] = downedDesertBeak,
                [2] = downedKingSting,
                [3] = downedMechasting,
                [4] = downedPhantasm
            });

            //fargos
            writer.Write(new BitsByte
            {
                [0] = downedTrojanSquirrel,
                [1] = downedCursedCoffin,
                [2] = downedDeviantt,
                [3] = downedLifelight,
                [4] = downedBanishedBaron,
                [5] = downedEridanus,
                [6] = downedAbominationn,
                [7] = downedMutant
            });

            //fractures of penumbra
            writer.Write(new BitsByte
            {
                [0] = downedAlphaFrostjaw,
                [1] = downedSanguineElemental
            });

            //gameterraria
            writer.Write(new BitsByte
            {
                [0] = downedLad,
                [1] = downedHornlitz,
                [2] = downedSnowDon,
                [3] = downedStoffie
            });

            //gensokyo
            writer.Write(new BitsByte
            {
                [0] = downedLilyWhite,
                [1] = downedRumia,
                [2] = downedEternityLarva,
                [3] = downedNazrin,
                [4] = downedHinaKagiyama,
                [5] = downedSekibanki,
                [6] = downedSeiran,
                [7] = downedNitoriKawashiro
            });
            writer.Write(new BitsByte
            {
                [0] = downedMedicineMelancholy,
                [1] = downedCirno,
                [2] = downedMinamitsuMurasa,
                [3] = downedAliceMargatroid,
                [4] = downedSakuyaIzayoi,
                [5] = downedSeijaKijin,
                [6] = downedMayumiJoutouguu,
                [7] = downedToyosatomimiNoMiko
            });
            writer.Write(new BitsByte
            {
                [0] = downedKaguyaHouraisan,
                [1] = downedUtsuhoReiuji,
                [2] = downedTenshiHinanawi,
                [3] = downedKisume
            });

            //gerds lab
            writer.Write(new BitsByte
            {
                [0] = downedTrerios,
                [1] = downedMagmaEye,
                [2] = downedJack,
                [3] = downedAcheron
            });

            //homeward journey
            writer.Write(new BitsByte
            {
                [0] = downedMarquisMoonsquid,
                [1] = downedPriestessRod,
                [2] = downedDiver,
                [3] = downedMotherbrain,
                [4] = downedWallOfShadow,
                [5] = downedSunSlimeGod,
                [6] = downedOverwatcher,
                [7] = downedLifebringer
            });
            writer.Write(new BitsByte
            {
                [0] = downedMaterealizer,
                [1] = downedScarabBelief,
                [2] = downedWorldsEndWhale,
                [3] = downedSon,
                [4] = downedCaveOrdeal,
                [5] = downedCorruptOrdeal,
                [6] = downedCrimsonOrdeal,
                [7] = downedDesertOrdeal
            });
            writer.Write(new BitsByte
            {
                [0] = downedForestOrdeal,
                [1] = downedHallowOrdeal,
                [2] = downedJungleOrdeal,
                [3] = downedSkyOrdeal,
                [4] = downedSnowOrdeal,
                [5] = downedUnderworldOrdeal
            });

            //hunt of the old god
            writer.Write(new BitsByte
            {
                [0] = downedGoozma
            });

            //infernum
            writer.Write(new BitsByte
            {
                [0] = downedBereftVassal
            });

            //lunar veil
            writer.Write(new BitsByte
            {
                [0] = downedStoneGuardian,
                [1] = downedCommanderGintzia,
                [2] = downedSunStalker,
                [3] = downedPumpkinJack,
                [4] = downedForgottenPuppetDaedus,
                [5] = downedDreadMire,
                [6] = downedSingularityFragment,
                [7] = downedVerlia
            });
            writer.Write(new BitsByte
            {
                [0] = downedIrradia,
                [1] = downedSylia,
                [2] = downedFenix,
                [3] = downedBlazingSerpent,
                [4] = downedCogwork,
                [5] = downedWaterCogwork,
                [6] = downedWaterJellyfish,
                [7] = downedSparn
            });
            writer.Write(new BitsByte
            {
                [0] = downedPandorasFlamebox,
                [1] = downedSTARBOMBER,
                [2] = downedGintzeArmy
            });

            //martains order
            writer.Write(new BitsByte
            {
                [0] = downedBritzz,
                [1] = downedTheAlchemist,
                [2] = downedCarnagePillar,
                [3] = downedVoidDigger,
                [4] = downedPrinceSlime,
                [5] = downedTriplets,
                [6] = downedJungleDefenders
            });

            //mech rework
            writer.Write(new BitsByte
            {
                [0] = downedSt4sys,
                [1] = downedTerminator,
                [2] = downedCaretaker,
                [3] = downedSiegeEngine
            });

            //medial rift
            writer.Write(new BitsByte
            {
                [0] = downedSuperVoltaicMotherSlime
            });

            //metroid
            writer.Write(new BitsByte
            {
                [0] = downedTorizo,
                [1] = downedSerris,
                [2] = downedKraid,
                [3] = downedPhantoon,
                [4] = downedOmegaPirate,
                [5] = downedNightmare,
                [6] = downedGoldenTorizo
            });

            //ophioid
            writer.Write(new BitsByte
            {
                [0] = downedOphiopede,
                [1] = downedOphiocoon,
                [2] = downedOphiofly
            });

            //polarities
            writer.Write(new BitsByte
            {
                [0] = downedStormCloudfish,
                [1] = downedStarConstruct,
                [2] = downedGigabat,
                [3] = downedSunPixie,
                [4] = downedEsophage,
                [5] = downedConvectiveWanderer
            });

            //project zero
            writer.Write(new BitsByte
            {
                [0] = downedForestGuardian,
                [1] = downedCryoGuardian,
                [2] = downedPrimordialWorm,
                [3] = downedTheGuardianOfHell,
                [4] = downedVoid,
                [5] = downedArmagem
            });

            //qwerty
            writer.Write(new BitsByte
            {
                [0] = downedPolarExterminator,
                [1] = downedDivineLight,
                [2] = downedAncientMachine,
                [3] = downedNoehtnap,
                [4] = downedHydra,
                [5] = downedImperious,
                [6] = downedRuneGhost,
                [7] = downedInvaderBattleship
            });
            writer.Write(new BitsByte
            {
                [0] = downedInvaderNoehtnap,
                [1] = downedOLORD,
                [2] = downedGreatTyrannosaurus,
                [3] = downedDinoMilitia,
                [4] = downedInvaders
            });

            //redemption
            writer.Write(new BitsByte
            {
                [0] = downedThorn,
                [1] = downedErhan,
                [2] = downedKeeper,
                [3] = downedSeedOfInfection,
                [4] = downedKingSlayerIII,
                [5] = downedOmegaCleaver,
                [6] = downedOmegaGigapora,
                [7] = downedOmegaObliterator
            });
            writer.Write(new BitsByte
            {
                [0] = downedPatientZero,
                [1] = downedAkka,
                [2] = downedUkko,
                [3] = downedAncientDeityDuo,
                [4] = downedNebuleus,
                [5] = downedFowlEmperor,
                [6] = downedCockatrice,
                [7] = downedBasan
            });
            writer.Write(new BitsByte
            {
                [0] = downedSkullDigger,
                [1] = downedEaglecrestGolem,
                [2] = downedCalavia,
                [3] = downedTheJanitor,
                [4] = downedIrradiatedBehemoth,
                [5] = downedBlisterface,
                [6] = downedProtectorVolt,
                [7] = downedMACEProject
            });
            writer.Write(new BitsByte
            {
                [0] = downedFowlMorning,
                [1] = downedRaveyard
            });

            //secrets of the shadows
            writer.Write(new BitsByte
            {
                [0] = downedPutridPinky,
                [1] = downedGlowmoth,
                [2] = downedPharaohsCurse,
                [3] = downedAdvisor,
                [4] = downedPolaris,
                [5] = downedLux,
                [6] = downedSubspaceSerpent,
                [7] = downedNatureConstruct
            });
            writer.Write(new BitsByte
            {
                [0] = downedEarthenConstruct,
                [1] = downedPermafrostConstruct,
                [2] = downedTidalConstruct,
                [3] = downedOtherworldlyConstruct,
                [4] = downedEvilConstruct,
                [5] = downedInfernoConstruct,
                [6] = downedChaosConstruct,
                [7] = downedNatureSpirit
            });
            writer.Write(new BitsByte
            {
                [0] = downedEarthenSpirit,
                [1] = downedPermafrostSpirit,
                [2] = downedTidalSpirit,
                [3] = downedOtherworldlySpirit,
                [4] = downedEvilSpirit,
                [5] = downedInfernoSpirit,
                [6] = downedChaosSpirit
            });

            //shadows of abaddon
            writer.Write(new BitsByte
            {
                [0] = downedDecree,
                [1] = downedFlamingPumpkin,
                [2] = downedZombiePiglinBrute,
                [3] = downedJensenTheGrandHarpy,
                [4] = downedAraneas,
                [5] = downedHarpyQueenRaynare,
                [6] = downedPrimordia,
                [7] = downedAbaddon
            });
            writer.Write(new BitsByte
            {
                [0] = downedAraghur,
                [1] = downedLostSiblings,
                [2] = downedErazor,
                [3] = downedNihilus
            });

            //sloome
            writer.Write(new BitsByte
            {
                [0] = downedExodygen
            });

            //spirit
            writer.Write(new BitsByte
            {
                [0] = downedScarabeus,
                [1] = downedMoonJellyWizard,
                [2] = downedVinewrathBane,
                [3] = downedAncientAvian,
                [4] = downedStarplateVoyager,
                [5] = downedInfernon,
                [6] = downedDusking,
                [7] = downedAtlas
            });
            writer.Write(new BitsByte
            {
                [0] = downedJellyDeluge,
                [1] = downedTide,
                [2] = downedMysticMoon
            });

            //spooky
            writer.Write(new BitsByte
            {
                [0] = downedSpookySpirit,
                [1] = downedRotGourd,
                [2] = downedMoco,
                [3] = downedDaffodil,
                [4] = downedOrroBoro,
                [5] = downedBigBone
            });

            //starlight river
            writer.Write(new BitsByte
            {
                [0] = downedAuroracle,
                [1] = downedCeiros,
                [2] = downedGlassweaver
            });

            //stars above
            writer.Write(new BitsByte
            {
                [0] = downedVagrantofSpace,
                [1] = downedThespian,
                [2] = downedDioskouroi,
                [3] = downedNalhaun,
                [4] = downedStarfarers,
                [5] = downedPenthesilea,
                [6] = downedArbitration,
                [7] = downedWarriorOfLight
            });
            writer.Write(new BitsByte
            {
                [0] = downedTsukiyomi
            });

            //storms additions
            writer.Write(new BitsByte
            {
                [0] = downedAncientHusk,
                [1] = downedOverloadedScandrone,
                [2] = downedPainbringer
            });

            //supernova
            writer.Write(new BitsByte
            {
                [0] = downedHarbingerOfAnnihilation,
                [1] = downedFlyingTerror,
                [2] = downedStoneMantaRay,
                [3] = downedBloodweaver
            });

            //terrorborn
            writer.Write(new BitsByte
            {
                [0] = downedInfectedIncarnate,
                [1] = downedTidalTitan,
                [2] = downedDunestock,
                [3] = downedHexedConstructor,
                [4] = downedShadowcrawler,
                [5] = downedPrototypeI
            });

            //trae
            writer.Write(new BitsByte
            {
                [0] = downedGraniteOvergrowth,
                [1] = downedBeholder
            });

            //uhtric
            writer.Write(new BitsByte
            {
                [0] = downedDredger,
                [1] = downedCharcoolSnowman,
                [2] = downedCosmicMenace
            });

            //universe of swords
            writer.Write(new BitsByte
            {
                [0] = downedEvilFlyingBlade
            });

            //valhalla
            writer.Write(new BitsByte
            {
                [0] = downedColossalCarnage,
                [1] = downedYurnero
            });

            //vitality
            writer.Write(new BitsByte
            {
                [0] = downedStormCloud,
                [1] = downedGrandAntlion,
                [2] = downedGemstoneElemental,
                [3] = downedMoonlightDragonfly,
                [4] = downedDreadnaught,
                [5] = downedMosquitoMonarch,
                [6] = downedAnarchulesBeetle,
                [7] = downedChaosbringer
            });
            writer.Write(new BitsByte
            {
                [0] = downedPaladinSpirit
            });

            //wayfair
            writer.Write(new BitsByte
            {
                [0] = downedManaflora
            });

            //wrath of the gods
            writer.Write(new BitsByte
            {
                [0] = downedNoxus,
                [1] = downedNamelessDeityOfLight
            });

            //zylon
            writer.Write(new BitsByte
            {
                [0] = downedDirtball,
                [1] = downedMetelord,
                [2] = downedAdeneb,
                [3] = downedEldritchJellyfish,
                [4] = downedSaburRex
            });

            BitsByte bitsByte = new();
            for (int i = 0; i < DownedBoss.Length; i++)
            {
                int bit = i % 8;

                if (bit == 0 && i != 0)
                {
                    writer.Write(bitsByte);
                    bitsByte = new BitsByte();
                }

                bitsByte[bit] = DownedBoss[i];
            }
            writer.Write(bitsByte);
        }

        public override void NetReceive(BinaryReader reader)
        {
            //vanilla
            BitsByte flags = reader.ReadByte();
            downedDreadnautilus = flags[0];
            downedMartianSaucer = flags[1];
            downedBloodMoon = flags[2];
            downedEclipse = flags[3];
            downedLunarEvent = flags[4];

            //afkpets
            flags = reader.ReadByte();
            downedSlayerOfEvil = flags[0];
            downedSATLA = flags[1];
            downedDrFetus = flags[2];
            downedSlimesHope = flags[3];
            downedPoliticianSlime = flags[4];
            downedAncientTrio = flags[5];
            downedLavalGolem = flags[6];
            downedAntony = flags[7];
            flags = reader.ReadByte();
            downedBunnyZeppelin = flags[0];
            downedOkiku = flags[1];
            downedHarpyAirforce = flags[2];
            downedIsaac = flags[3];
            downedAncientGuardian = flags[4];
            downedHeroicSlime = flags[5];
            downedHoloSlime = flags[6];
            downedSecurityBot = flags[7];
            flags = reader.ReadByte();
            downedUndeadChef = flags[0];
            downedGuardianOfFrost = flags[1];
            downedGuardianOfFrost = flags[1];

            //assorted crazy things
            flags = reader.ReadByte();
            downedSoulHarvester = flags[0];

            //awful garbage
            flags = reader.ReadByte();
            downedTreeToad = flags[0];
            downedSeseKitsugai = flags[1];
            downedEyeOfTheStorm = flags[2];
            downedFrigidius = flags[3];

            //BLOCK'S CORE BOSS
            flags = reader.ReadByte();
            downedCoreBoss = flags[0];

            //calamity
            flags = reader.ReadByte();
            downedCragmawMire = flags[0];
            downedNuclearTerror = flags[1];
            downedMauler = flags[2];

            //calamity community remix
            flags = reader.ReadByte();
            downedWulfrumExcavator = flags[0];

            //calamity entropy
            flags = reader.ReadByte();
            downedCruiser = flags[0];

            //catalyst
            flags = reader.ReadByte();
            downedAstrageldon = flags[0];

            //clamity
            flags = reader.ReadByte();
            downedClamitas = flags[0];
            downedPyrogen = flags[1];
            downedWallOfBronze = flags[2];

            //consolaria
            flags = reader.ReadByte();
            downedLepus = flags[0];
            downedTurkor = flags[1];
            downedOcram = flags[2];

            //coralite
            flags = reader.ReadByte();
            downedRediancie = flags[0];
            downedBabyIceDragon = flags[1];
            downedSlimeEmperor = flags[2];
            downedBloodiancie = flags[3];
            downedThunderveinDragon = flags[4];
            downedNightmarePlantera = flags[5];

            //depths
            flags = reader.ReadByte();
            downedChasme = flags[0];

            //dormant dawn
            flags = reader.ReadByte();
            downedLifeGuardian = flags[0];
            downedManaGuardian = flags[1];
            downedMeteorExcavator = flags[2];
            downedMeteorAnnihilator = flags[3];
            downedHellfireSerpent = flags[4];
            downedWitheredAcornSpirit = flags[5];
            downedGoblinSorcererChieftain = flags[6];

            //echoes of the ancients
            flags = reader.ReadByte();
            downedGalahis = flags[0];
            downedCreation = flags[1];
            downedDestruction = flags[2];

            //edorbis
            flags = reader.ReadByte();
            downedBlightKing = flags[0];
            downedGardener = flags[1];
            downedGlaciation = flags[2];
            downedHandOfCthulhu = flags[3];
            downedCursePreacher = flags[4];

            //exalt
            flags = reader.ReadByte();
            downedEffulgence = flags[0];
            downedIceLich = flags[1];

            //excelsior
            flags = reader.ReadByte();
            downedNiflheim = flags[0];
            downedStellarStarship = flags[1];

            //exxo avalon origins
            flags = reader.ReadByte();
            downedBacteriumPrime = flags[0];
            downedDesertBeak = flags[1];
            downedKingSting = flags[2];
            downedMechasting = flags[3];
            downedPhantasm = flags[4];

            //fargos
            flags = reader.ReadByte();
            downedTrojanSquirrel = flags[0];
            downedCursedCoffin = flags[1];
            downedDeviantt = flags[2];
            downedLifelight = flags[3];
            downedBanishedBaron = flags[4];
            downedEridanus = flags[5];
            downedAbominationn = flags[6];
            downedMutant = flags[7];

            //fractures of penumbra
            flags = reader.ReadByte();
            downedAlphaFrostjaw = flags[0];
            downedSanguineElemental = flags[1];

            //gameterraria
            flags = reader.ReadByte();
            downedLad = flags[0];
            downedHornlitz = flags[1];
            downedSnowDon = flags[2];
            downedStoffie = flags[3];

            //gensokyo
            flags = reader.ReadByte();
            downedLilyWhite = flags[0];
            downedRumia = flags[1];
            downedEternityLarva = flags[2];
            downedNazrin = flags[3];
            downedHinaKagiyama = flags[4];
            downedSekibanki = flags[5];
            downedSeiran = flags[6];
            downedNitoriKawashiro = flags[7];
            flags = reader.ReadByte();
            downedMedicineMelancholy = flags[0];
            downedCirno = flags[1];
            downedMinamitsuMurasa = flags[2];
            downedAliceMargatroid = flags[3];
            downedSakuyaIzayoi = flags[4];
            downedSeijaKijin = flags[5];
            downedMayumiJoutouguu = flags[6];
            downedToyosatomimiNoMiko = flags[7];
            flags = reader.ReadByte();
            downedKaguyaHouraisan = flags[0];
            downedUtsuhoReiuji = flags[1];
            downedTenshiHinanawi = flags[2];
            downedKisume = flags[3];

            //gerds lab
            flags = reader.ReadByte();
            downedTrerios = flags[0];
            downedMagmaEye = flags[1];
            downedJack = flags[2];
            downedAcheron = flags[3];

            //homeward journey
            flags = reader.ReadByte();
            downedMarquisMoonsquid = flags[0];
            downedPriestessRod = flags[1];
            downedDiver = flags[2];
            downedMotherbrain = flags[3];
            downedWallOfShadow = flags[4];
            downedSunSlimeGod = flags[5];
            downedOverwatcher = flags[6];
            downedLifebringer = flags[7];
            flags = reader.ReadByte();
            downedMaterealizer = flags[0];
            downedScarabBelief = flags[1];
            downedWorldsEndWhale = flags[2];
            downedSon = flags[3];
            downedCaveOrdeal = flags[4];
            downedCorruptOrdeal = flags[5];
            downedCrimsonOrdeal = flags[6];
            downedDesertOrdeal = flags[7];
            flags = reader.ReadByte();
            downedForestOrdeal = flags[0];
            downedHallowOrdeal = flags[1];
            downedJungleOrdeal = flags[2];
            downedSkyOrdeal = flags[3];
            downedSnowOrdeal = flags[4];
            downedUnderworldOrdeal = flags[5];

            //hunt of the old god
            flags = reader.ReadByte();
            downedGoozma = flags[0];

            //infernum
            flags = reader.ReadByte();
            downedBereftVassal = flags[0];

            //lunar veil
            flags = reader.ReadByte();
            downedStoneGuardian = flags[0];
            downedCommanderGintzia = flags[1];
            downedSunStalker = flags[2];
            downedPumpkinJack = flags[3];
            downedForgottenPuppetDaedus = flags[4];
            downedDreadMire = flags[5];
            downedSingularityFragment = flags[6];
            downedVerlia = flags[7];
            flags = reader.ReadByte();
            downedIrradia = flags[0];
            downedSylia = flags[1];
            downedFenix = flags[2];
            downedBlazingSerpent = flags[3];
            downedCogwork = flags[4];
            downedWaterCogwork = flags[5];
            downedWaterJellyfish = flags[6];
            downedSparn = flags[7];
            flags = reader.ReadByte();
            downedPandorasFlamebox = flags[0];
            downedSTARBOMBER = flags[1];
            downedGintzeArmy = flags[2];

            //martains order
            flags = reader.ReadByte();
            downedBritzz = flags[0];
            downedTheAlchemist = flags[1];
            downedCarnagePillar = flags[2];
            downedVoidDigger = flags[3];
            downedPrinceSlime = flags[4];
            downedTriplets = flags[5];
            downedJungleDefenders = flags[6];

            //mech rework
            flags = reader.ReadByte();
            downedSt4sys = flags[0];
            downedTerminator = flags[1];
            downedCaretaker = flags[2];
            downedSiegeEngine = flags[3];

            //medial rift
            flags = reader.ReadByte();
            downedSuperVoltaicMotherSlime = flags[0];

            //metroid
            flags = reader.ReadByte();
            downedTorizo = flags[0];
            downedSerris = flags[1];
            downedKraid = flags[2];
            downedPhantoon = flags[3];
            downedOmegaPirate = flags[4];
            downedNightmare = flags[5];
            downedGoldenTorizo = flags[6];

            //ophioid
            flags = reader.ReadByte();
            downedOphiopede = flags[0];
            downedOphiocoon = flags[1];
            downedOphiofly = flags[2];

            //polarities
            flags = reader.ReadByte();
            downedStormCloudfish = flags[0];
            downedStarConstruct = flags[1];
            downedGigabat = flags[2];
            downedSunPixie = flags[3];
            downedEsophage = flags[4];
            downedConvectiveWanderer = flags[5];

            //project zero
            flags = reader.ReadByte();
            downedForestGuardian = flags[0];
            downedCryoGuardian = flags[1];
            downedPrimordialWorm = flags[2];
            downedTheGuardianOfHell = flags[3];
            downedVoid = flags[4];
            downedArmagem = flags[5];

            //qwerty
            flags = reader.ReadByte();
            downedPolarExterminator = flags[0];
            downedDivineLight = flags[1];
            downedAncientMachine = flags[2];
            downedNoehtnap = flags[3];
            downedHydra = flags[4];
            downedImperious = flags[5];
            downedRuneGhost = flags[6];
            downedInvaderBattleship = flags[7];
            flags = reader.ReadByte();
            downedInvaderNoehtnap = flags[0];
            downedOLORD = flags[1];
            downedGreatTyrannosaurus = flags[2];
            downedDinoMilitia = flags[3];
            downedInvaders = flags[4];

            //redemption
            flags = reader.ReadByte();
            downedThorn = flags[0];
            downedErhan = flags[1];
            downedKeeper = flags[2];
            downedSeedOfInfection = flags[3];
            downedKingSlayerIII = flags[4];
            downedOmegaCleaver = flags[5];
            downedOmegaGigapora = flags[6];
            downedOmegaObliterator = flags[7];
            flags = reader.ReadByte();
            downedPatientZero = flags[0];
            downedAkka = flags[1];
            downedUkko = flags[2];
            downedAncientDeityDuo = flags[3];
            downedNebuleus = flags[4];
            downedFowlEmperor = flags[5];
            downedCockatrice = flags[6];
            downedBasan = flags[7];
            flags = reader.ReadByte();
            downedSkullDigger = flags[0];
            downedEaglecrestGolem = flags[1];
            downedCalavia = flags[2];
            downedTheJanitor = flags[3];
            downedIrradiatedBehemoth = flags[4];
            downedBlisterface = flags[5];
            downedProtectorVolt = flags[6];
            downedMACEProject = flags[7];
            flags = reader.ReadByte();
            downedFowlMorning = flags[0];
            downedRaveyard = flags[1];

            //secrets of the shadows
            flags = reader.ReadByte();
            downedPutridPinky = flags[0];
            downedGlowmoth = flags[1];
            downedPharaohsCurse = flags[2];
            downedAdvisor = flags[3];
            downedPolaris = flags[4];
            downedLux = flags[5];
            downedSubspaceSerpent = flags[6];
            downedNatureConstruct = flags[7];
            flags = reader.ReadByte();
            downedEarthenConstruct = flags[0];
            downedPermafrostConstruct = flags[1];
            downedTidalConstruct = flags[2];
            downedOtherworldlyConstruct = flags[3];
            downedEvilConstruct = flags[4];
            downedInfernoConstruct = flags[5];
            downedChaosConstruct = flags[6];
            downedNatureSpirit = flags[7];
            flags = reader.ReadByte();
            downedEarthenSpirit = flags[0];
            downedPermafrostSpirit = flags[1];
            downedTidalSpirit = flags[2];
            downedOtherworldlySpirit = flags[3];
            downedEvilSpirit = flags[4];
            downedInfernoSpirit = flags[5];
            downedChaosSpirit = flags[6];

            //shadows of abaddon
            flags = reader.ReadByte();
            downedDecree = flags[0];
            downedFlamingPumpkin = flags[1];
            downedZombiePiglinBrute = flags[2];
            downedJensenTheGrandHarpy = flags[3];
            downedAraneas = flags[4];
            downedHarpyQueenRaynare = flags[5];
            downedPrimordia = flags[6];
            downedAbaddon = flags[7];
            flags = reader.ReadByte();
            downedAraghur = flags[0];
            downedLostSiblings = flags[1];
            downedErazor = flags[2];
            downedNihilus = flags[3];

            //sloome
            flags = reader.ReadByte();
            downedExodygen = flags[0];

            //spirit
            flags = reader.ReadByte();
            downedScarabeus = flags[0];
            downedMoonJellyWizard = flags[1];
            downedVinewrathBane = flags[2];
            downedAncientAvian = flags[3];
            downedStarplateVoyager = flags[4];
            downedInfernon = flags[5];
            downedDusking = flags[6];
            downedAtlas = flags[7];
            flags = reader.ReadByte();
            downedJellyDeluge = flags[0];
            downedTide = flags[1];
            downedMysticMoon = flags[2];

            //spooky
            flags = reader.ReadByte();
            downedSpookySpirit = flags[0];
            downedRotGourd = flags[1];
            downedMoco = flags[2];
            downedDaffodil = flags[3];
            downedOrroBoro = flags[4];
            downedBigBone = flags[5];

            //starlight river
            flags = reader.ReadByte();
            downedAuroracle = flags[0];
            downedCeiros = flags[1];
            downedGlassweaver = flags[2];

            //stars above
            flags = reader.ReadByte();
            downedVagrantofSpace = flags[0];
            downedThespian = flags[1];
            downedDioskouroi = flags[2];
            downedNalhaun = flags[3];
            downedStarfarers = flags[4];
            downedPenthesilea = flags[5];
            downedArbitration = flags[6];
            downedWarriorOfLight = flags[7];
            flags = reader.ReadByte();
            downedTsukiyomi = flags[0];

            //storms additions
            flags = reader.ReadByte();
            downedAncientHusk = flags[0];
            downedOverloadedScandrone = flags[1];
            downedPainbringer = flags[2];

            //supernova
            flags = reader.ReadByte();
            downedHarbingerOfAnnihilation = flags[0];
            downedFlyingTerror = flags[1];
            downedStoneMantaRay = flags[2];
            downedBloodweaver = flags[3];

            //terrorborn
            flags = reader.ReadByte();
            downedInfectedIncarnate = flags[0];
            downedTidalTitan = flags[1];
            downedDunestock = flags[2];
            downedHexedConstructor = flags[3];
            downedShadowcrawler = flags[4];
            downedPrototypeI = flags[5];

            //trae
            flags = reader.ReadByte();
            downedGraniteOvergrowth = flags[0];
            downedBeholder = flags[1];

            //uhtric
            flags = reader.ReadByte();
            downedDredger = flags[0];
            downedCharcoolSnowman = flags[1];
            downedCosmicMenace = flags[2];

            //universe of swords
            flags = reader.ReadByte();
            downedEvilFlyingBlade = flags[0];

            //valhalla
            flags = reader.ReadByte();
            downedColossalCarnage = flags[0];
            downedYurnero = flags[1];

            //vitality
            flags = reader.ReadByte();
            downedStormCloud = flags[0];
            downedGrandAntlion = flags[1];
            downedGemstoneElemental = flags[2];
            downedMoonlightDragonfly = flags[3];
            downedDreadnaught = flags[4];
            downedMosquitoMonarch = flags[5];
            downedAnarchulesBeetle = flags[6];
            downedChaosbringer = flags[7];
            flags = reader.ReadByte();
            downedPaladinSpirit = flags[0];

            //wayfair
            flags = reader.ReadByte();
            downedManaflora = flags[0];

            //wrath of the gods
            flags = reader.ReadByte();
            downedNoxus = flags[0];
            downedNamelessDeityOfLight = flags[1];

            //zylon
            flags = reader.ReadByte();
            downedDirtball = flags[0];
            downedMetelord = flags[1];
            downedAdeneb = flags[2];
            downedEldritchJellyfish = flags[3];
            downedSaburRex = flags[4];

            for (int i = 0; i < DownedBoss.Length; i++)
            {
                int bits = i % 8;
                if (bits == 0)
                    flags = reader.ReadByte();

                DownedBoss[i] = flags[bits];
            }
        }

        public static void ResetDowned()
        {
            //VANILLA
            //BOSSES
            downedDreadnautilus = false;
            downedMartianSaucer = false;
            //EVENTS
            downedBloodMoon = false;
            downedEclipse = false;
            downedLunarEvent = false;
            beenThroughNight = false;
            //BIOMES
            beenToPurity = false;
            beenToCavernsOrUnderground = false;
            beenToUnderworld = false;
            beenToSky = false;
            beenToSnow = false;
            beenToDesert = false;
            beenToOcean = false;
            beenToJungle = false;
            beenToMushroom = false;
            beenToCorruption = false;
            beenToCrimson = false;
            beenToHallow = false;
            beenToTemple = false;
            beenToDungeon = false;
            beenToAether = false;
            //OTHER
            talkedToSkeletonMerchant = false;
            talkedToTravelingMerchant = false;

            //AEQUUS
            downedCrabson = false;
            downedOmegaStarite = false;
            downedDustDevil = false;
            downedRedSprite = false;
            downedSpaceSquid = false;
            downedHyperStarite = false;
            downedUltraStarite = false;
            //EVENTS
            downedDemonSiege = false;
            downedGlimmer = false;
            downedGaleStreams = false;
            //BIOMES
            beenToCrabCrevice = false;

            //AFKPETS
            downedSlayerOfEvil = false;
            downedSATLA = false;
            downedDrFetus = false;
            downedSlimesHope = false;
            downedPoliticianSlime = false;
            downedAncientTrio = false;
            downedLavalGolem = false;
            //MINIBOSSES
            downedAntony = false;
            downedBunnyZeppelin = false;
            downedOkiku = false;
            downedHarpyAirforce = false;
            downedIsaac = false;
            downedAncientGuardian = false;
            downedHeroicSlime = false;
            downedHoloSlime = false;
            downedSecurityBot = false;
            downedUndeadChef = false;
            downedGuardianOfFrost = false;

            //ASSORTED CRAZY THINGS
            downedSoulHarvester = false;

            //AWFUL GARBAGE
            downedTreeToad = false;
            downedSeseKitsugai = false;
            downedEyeOfTheStorm = false;
            downedFrigidius = false;

            //BLOCK'S CORE BOSS
            downedCoreBoss = false;

            //CALAMITY
            downedDesertScourge = false;
            downedCrabulon = false;
            downedHiveMind = false;
            downedPerforators = false;
            downedSlimeGod = false;
            downedCryogen = false;
            downedAquaticScourge = false;
            downedBrimstoneElemental = false;
            downedCalamitasClone = false;
            downedLeviathanAndAnahita = false;
            downedAstrumAureus = false;
            downedPlaguebringerGoliath = false;
            downedRavager = false;
            downedAstrumDeus = false;
            downedProfanedGuardians = false;
            downedDragonfolly = false;
            downedProvidence = false;
            downedStormWeaver = false;
            downedCeaselessVoid = false;
            downedSignus = false;
            downedPolterghast = false;
            downedOldDuke = false;
            downedDevourerOfGods = false;
            downedYharon = false;
            downedExoMechs = false;
            downedSupremeCalamitas = false;
            downedGiantClam = false;
            downedGreatSandShark = false;
            downedCragmawMire = false;
            downedNuclearTerror = false;
            downedMauler = false;
            downedEidolonWyrm = false;
            //EVENTS
            downedAcidRain1 = false;
            downedAcidRain2 = false;
            downedBossRush = false;
            //BIOMES
            beenToCrags = false;
            beenToAstral = false;
            beenToSunkenSea = false;
            beenToSulphurSea = false;
            beenToAbyss = false;
            beenToAbyssLayer1 = false;
            beenToAbyssLayer2 = false;
            beenToAbyssLayer3 = false;
            beenToAbyssLayer4 = false;

            //CALAMITY COMMUNITY REMIX
            downedWulfrumExcavator = false;

            //CALAMITY ENTROPY
            downedCruiser = false;

            //CALAMITY VANITIES
            beenToAstralBlight = false;

            //CATALYST
            downedAstrageldon = false;

            //CLAMITY
            downedClamitas = false;
            downedPyrogen = false;
            downedWallOfBronze = false;

            //CONFECTION
            beenToConfection = false;

            //CONSOLARIA
            downedLepus = false;
            downedTurkor = false;
            downedOcram = false;

            //CORALITE
            downedRediancie = false;
            downedBabyIceDragon = false;
            downedSlimeEmperor = false;
            downedBloodiancie = false;
            downedThunderveinDragon = false;
            downedNightmarePlantera = false;

            //DEPTHS
            beenToDepths = false;

            //DORMANT DAWN
            downedLifeGuardian = false;
            downedManaGuardian = false;
            downedMeteorExcavator = false;
            downedMeteorAnnihilator = false;
            downedHellfireSerpent = false;
            downedWitheredAcornSpirit = false;
            downedGoblinSorcererChieftain = false;

            //ECHOES OF THE ANCIENTS
            downedGalahis = false;
            downedCreation = false;
            downedDestruction = false;

            //EDORBIS
            downedBlightKing = false;
            downedGardener = false;
            downedGlaciation = false;
            downedHandOfCthulhu = false;
            downedCursePreacher = false;

            //EVERJADE
            beenToJadeLake = false;

            //EXALT
            downedEffulgence = false;
            downedIceLich = false;

            //EXXO AVALON ORIGINS
            downedBacteriumPrime = false;
            downedDesertBeak = false;
            downedKingSting = false;
            downedMechasting = false;
            downedPhantasm = false;
            //BIOMES
            beenToContagion = false;

            //FARGOS SOULS
            downedTrojanSquirrel = false;
            downedCursedCoffin = false;
            downedDeviantt = false;
            downedBanishedBaron = false;
            downedLifelight = false;
            downedEridanus = false;
            downedAbominationn = false;
            downedMutant = false;

            //FRACTURES OF PENUMBRA
            downedAlphaFrostjaw = false;
            downedSanguineElemental = false;
            //BIOMES
            beenToDread = false;

            //GAMETERRARIA
            downedLad = false;
            downedHornlitz = false;
            downedSnowDon = false;
            downedStoffie = false;

            //GENSOKYO
            downedLilyWhite = false;
            downedRumia = false;
            downedEternityLarva = false;
            downedNazrin = false;
            downedHinaKagiyama = false;
            downedSekibanki = false;
            downedSeiran = false;
            downedNitoriKawashiro = false;
            downedMedicineMelancholy = false;
            downedCirno = false;
            downedMinamitsuMurasa = false;
            downedAliceMargatroid = false;
            downedSakuyaIzayoi = false;
            downedSeijaKijin = false;
            downedMayumiJoutouguu = false;
            downedToyosatomimiNoMiko = false;
            downedKaguyaHouraisan = false;
            downedUtsuhoReiuji = false;
            downedTenshiHinanawi = false;
            //MINIBOSSES
            downedKisume = false;

            //GMR
            downedTrerios = false;
            downedMagmaEye = false;
            downedJack = false;
            downedAcheron = false;

            //HOMEWARD JOURNEY
            downedMarquisMoonsquid = false;
            downedPriestessRod = false;
            downedDiver = false;
            downedMotherbrain = false;
            downedWallOfShadow = false;
            downedSunSlimeGod = false;
            downedOverwatcher = false;
            downedLifebringer = false;
            downedMaterealizer = false;
            downedScarabBelief = false;
            downedWorldsEndWhale = false;
            downedSon = false;
            //EVENTS
            downedCaveOrdeal = false;
            downedCorruptOrdeal = false;
            downedCrimsonOrdeal = false;
            downedDesertOrdeal = false;
            downedForestOrdeal = false;
            downedHallowOrdeal = false;
            downedJungleOrdeal = false;
            downedSkyOrdeal = false;
            downedSnowOrdeal = false;
            downedUnderworldOrdeal = false;
            //BIOMES
            beenToHomewardAbyss = false;

            //HUNT OF THE OLD GOD
            downedGoozma = false;

            //INFERNUM
            downedBereftVassal = false;
            //BIOMES
            beenToProfanedGardens = false;

            //LUNAR VEIL
            downedStoneGuardian = false;
            downedCommanderGintzia = false;
            downedSunStalker = false;
            downedPumpkinJack = false;
            downedForgottenPuppetDaedus = false;
            downedDreadMire = false;
            downedSingularityFragment = false;
            downedVerlia = false;
            downedIrradia = false;
            downedSylia = false;
            downedFenix = false;
            //MINIBOSSSES
            downedBlazingSerpent = false;
            downedCogwork = false;
            downedWaterCogwork = false;
            downedWaterJellyfish = false;
            downedSparn = false;
            downedPandorasFlamebox = false;
            downedSTARBOMBER = false;
            //EVENT
            downedGintzeArmy = false;
            //BIOMES
            beenToLunarVeilAbyss = false;
            beenToAcid = false;
            beenToAurelus = false;
            beenToFable = false;
            beenToGovheilCastle = false;
            beenToCathedral = false;
            beenToMarrowSurface = false;
            beenToMorrowUnderground = false;

            //MARTAINS ORDER
            downedBritzz = false;
            downedTheAlchemist = false;
            downedCarnagePillar = false;
            downedVoidDigger = false;
            downedPrinceSlime = false;
            downedTriplets = false;
            downedJungleDefenders = false;

            //MECH REWORK
            downedSt4sys = false;
            downedTerminator = false;
            downedCaretaker = false;
            downedSiegeEngine = false;

            //MEDIAL RIFT
            downedSuperVoltaicMotherSlime = false;

            //METROID
            downedTorizo = false;
            downedSerris = false;
            downedKraid = false;
            downedPhantoon = false;
            downedOmegaPirate = false;
            downedNightmare = false;
            downedGoldenTorizo = false;

            //OPHIOID
            downedOphiopede = false;
            downedOphiocoon = false;
            downedOphiofly = false;

            //POLARITIES
            downedStormCloudfish = false;
            downedStarConstruct = false;
            downedGigabat = false;
            downedSunPixie = false;
            downedEsophage = false;
            downedConvectiveWanderer = false;

            //PROJECT ZERO
            downedForestGuardian = false;
            downedCryoGuardian = false;
            downedPrimordialWorm = false;
            downedTheGuardianOfHell = false;
            downedVoid = false;
            downedArmagem = false;

            //QWERTY
            downedPolarExterminator = false;
            downedDivineLight = false;
            downedAncientMachine = false;
            downedNoehtnap = false;
            downedHydra = false;
            downedImperious = false;
            downedRuneGhost = false;
            downedInvaderBattleship = false;
            downedInvaderNoehtnap = false;
            downedOLORD = false;
            //MINIBOSSES
            downedGreatTyrannosaurus = false;
            //EVENTS
            downedDinoMilitia = false;
            downedInvaders = false;
            //BIOMES
            beenToSkyFortress = false;

            //REDEMPTION
            downedThorn = false;
            downedErhan = false;
            downedKeeper = false;
            downedSeedOfInfection = false;
            downedKingSlayerIII = false;
            downedOmegaCleaver = false;
            downedOmegaGigapora = false;
            downedOmegaObliterator = false;
            downedPatientZero = false;
            downedAkka = false;
            downedUkko = false;
            downedAncientDeityDuo = false;
            downedNebuleus = false;
            //MINIBOSSES
            downedFowlEmperor = false;
            downedCockatrice = false;
            downedBasan = false;
            downedSkullDigger = false;
            downedEaglecrestGolem = false;
            downedCalavia = false;
            downedTheJanitor = false;
            downedIrradiatedBehemoth = false;
            downedBlisterface = false;
            downedProtectorVolt = false;
            downedMACEProject = false;
            //EVENTS
            downedFowlMorning = false;
            downedRaveyard = false;
            //BIOMES
            beenToLab = false;
            beenToWasteland = false;

            //SOTS
            downedGlowmoth = false;
            downedPutridPinky = false;
            downedPharaohsCurse = false;
            downedAdvisor = false;
            downedPolaris = false;
            downedLux = false;
            downedSubspaceSerpent = false;
            //MINIBOSSES
            downedNatureConstruct = false;
            downedEarthenConstruct = false;
            downedPermafrostConstruct = false;
            downedTidalConstruct = false;
            downedOtherworldlyConstruct = false;
            downedEvilConstruct = false;
            downedInfernoConstruct = false;
            downedChaosConstruct = false;
            downedNatureSpirit = false;
            downedEarthenSpirit = false;
            downedPermafrostSpirit = false;
            downedTidalSpirit = false;
            downedOtherworldlySpirit = false;
            downedEvilSpirit = false;
            downedInfernoSpirit = false;
            downedChaosSpirit = false;
            //BIOMES
            beenToPyramid = false;
            beenToPlanetarium = false;

            //SHADOWS OF ABADDON
            downedDecree = false;
            downedFlamingPumpkin = false;
            downedZombiePiglinBrute = false;
            downedJensenTheGrandHarpy = false;
            downedAraneas = false;
            downedHarpyQueenRaynare = false;
            downedPrimordia = false;
            downedAbaddon = false;
            downedAraghur = false;
            downedLostSiblings = false;
            downedErazor = false;
            downedNihilus = false;
            //BIOMES
            beenToCinderForest = false;

            //SLOOME
            downedExodygen = false;

            //SPIRIT
            downedScarabeus = false;
            downedMoonJellyWizard = false;
            downedVinewrathBane = false;
            downedAncientAvian = false;
            downedStarplateVoyager = false;
            downedInfernon = false;
            downedDusking = false;
            downedAtlas = false;
            //EVENTS
            downedJellyDeluge = false;
            downedTide = false;
            downedMysticMoon = false;
            //BIOMES
            beenToBriar = false;
            beenToSpirit = false;

            //SPOOKY
            downedSpookySpirit = false;
            downedRotGourd = false;
            downedMoco = false;
            downedDaffodil = false;
            downedOrroBoro = false;
            downedOrro = false;
            downedBoro = false;
            downedBigBone = false;
            //BIOMES
            beenToSpookyForest = false;
            beenToSpookyUnderground = false;
            beenToEyeValley = false;
            beenToSpiderCave = false;
            beenToCatacombs = false;
            beenToCemetery = false;

            //STARLIGHT RIVER
            downedAuroracle = false;
            downedCeiros = false;
            //MINIBOSSES
            downedGlassweaver = false;
            //BIOMES
            beenToAuroracleTemple = false;
            beenToVitricDesert = false;
            beenToVitricTemple = false;

            //STARS ABOVE
            downedVagrantofSpace = false;
            downedThespian = false;
            downedDioskouroi = false;
            downedNalhaun = false;
            downedStarfarers = false;
            downedPenthesilea = false;
            downedArbitration = false;
            downedWarriorOfLight = false;
            downedTsukiyomi = false;

            //STORM DIVERS MOD
            downedAncientHusk = false;
            downedOverloadedScandrone = false;
            downedPainbringer = false;

            //SUPERNOVA
            downedHarbingerOfAnnihilation = false;
            downedFlyingTerror = false;
            downedStoneMantaRay = false;
            //MINIBOSSES
            downedBloodweaver = false;

            //TERRORBORN
            downedInfectedIncarnate = false;
            downedTidalTitan = false;
            downedDunestock = false;
            downedShadowcrawler = false;
            downedHexedConstructor = false;
            downedPrototypeI = false;

            //THORIUM
            downedGrandThunderBird = false;
            downedQueenJellyfish = false;
            downedViscount = false;
            downedGraniteEnergyStorm = false;
            downedBuriedChampion = false;
            downedBoreanStrider = false;
            downedFallenBeholder = false;
            downedLich = false;
            downedForgottenOne = false;
            downedPrimordials = false;
            //MINIBOSSES
            downedPatchWerk = false;
            downedCorpseBloom = false;
            downedIllusionist = false;
            //BIOMES
            beenToAquaticDepths = false;

            //TRAE
            downedGraniteOvergrowth = false;
            downedBeholder = false;

            //UHTRIC
            downedDredger = false;
            downedCharcoolSnowman = false;
            downedCosmicMenace = false;

            //UNIVERSE OF SWORDS
            downedEvilFlyingBlade = false;

            //VALHALLA
            downedColossalCarnage = false;
            downedYurnero = false;

            //VERDANT
            beenToVerdant = false;

            //VITALITY
            downedStormCloud = false;
            downedGrandAntlion = false;
            downedGemstoneElemental = false;
            downedMoonlightDragonfly = false;
            downedDreadnaught = false;
            downedMosquitoMonarch = false;
            downedAnarchulesBeetle = false;
            downedChaosbringer = false;
            downedPaladinSpirit = false;

            //WAYFAIR
            downedManaflora = false;

            //WRATH OF THE GODS
            downedNoxus = false;
            downedNamelessDeityOfLight = false;

            //ZYLON
            downedDirtball = false;
            downedMetelord = false;
            downedAdeneb = false;
            downedEldritchJellyfish = false;
            downedSaburRex = false;

            for (int i = 0; i < DownedBoss.Length; i++)
                DownedBoss[i] = false;
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