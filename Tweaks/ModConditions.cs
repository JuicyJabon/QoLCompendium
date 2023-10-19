using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Tweaks
{
    public class ModConditions : ModSystem
    {
        #pragma warning disable CA2211
        #region Bools & Conditions
        //VANILLA
        //EXPERT/MASTER
        public static Condition expertOrMaster = new("ModConditions.inExpertOrMaster", () => Main.expertMode || Main.masterMode);
        //BOSSES
        internal static bool downedDreadnautilus;
        public static Condition DownedDreadnautilus = new("ModConditions.downedDreadnautilus", () => downedDreadnautilus);
        internal static bool downedMartianSaucer;
        public static Condition DownedMartianSaucer = new("ModConditions.downedMartianSaucer", () => downedMartianSaucer);
        public static Condition DownedLunarPillarAny = new("ModConditions.downedLunarPillarAny", () => NPC.downedTowerNebula || NPC.downedTowerSolar || NPC.downedTowerStardust || NPC.downedTowerVortex);
        //EVENTS
        internal static bool downedBloodMoon;
        public static Condition DownedBloodMoon = new("ModConditions.downedBloodMoon", () => downedBloodMoon);
        internal static bool downedEclipse;
        public static Condition DownedEclipse = new("ModConditions.downedEclipse", () => downedEclipse);
        internal static bool downedLunarEvent;
        public static Condition DownedLunarEvent = new("ModConditions.downedLunarEvent", () => downedLunarEvent);
        internal static bool beenThroughNight;
        public static Condition HasBeenThroughNight = new("ModConditions.beenThroughNight", () => beenThroughNight);
        //BIOMES
        internal static bool beenToPurity;
        public static Condition HasBeenToPurity = new("ModConditions.beenToPurity", () => beenToPurity);
        internal static bool beenToCavernsOrUnderground;
        public static Condition HasBeenToCavernsOrUnderground = new("ModConditions.beenToCavernsOrUnderground", () => beenToCavernsOrUnderground);
        internal static bool beenToUnderworld;
        public static Condition HasBeenToUnderworld = new("ModConditions.beenToUnderworld", () => beenToUnderworld);
        internal static bool beenToSky;
        public static Condition HasBeenToSky = new("ModConditions.beenToSky", () => beenToSky);
        internal static bool beenToSnow;
        public static Condition HasBeenToSnow = new("ModConditions.beenToSnow", () => beenToSnow);
        internal static bool beenToDesert;
        public static Condition HasBeenToDesert = new("ModConditions.beenToDesert", () => beenToDesert);
        internal static bool beenToOcean;
        public static Condition HasBeenToOcean = new("ModConditions.beenToOcean", () => beenToOcean);
        internal static bool beenToJungle;
        public static Condition HasBeenToJungle = new("ModConditions.beenToJungle", () => beenToJungle);
        internal static bool beenToMushroom;
        public static Condition HasBeenToMushroom = new("ModConditions.beenToMushroom", () => beenToMushroom);
        internal static bool beenToCorruption;
        public static Condition HasBeenToCorruption = new("ModConditions.beenToCorruption", () => beenToCorruption);
        internal static bool beenToCrimson;
        public static Condition HasBeenToCrimson = new("ModConditions.beenToCrimson", () => beenToCrimson);
        public static Condition HasBeenToEvil = new("ModConditions.beenToEvil", () => beenToCorruption || beenToCrimson);
        internal static bool beenToHallow;
        public static Condition HasBeenToHallow = new("ModConditions.beenToHallow", () => beenToHallow);
        internal static bool beenToTemple;
        public static Condition HasBeenToTemple = new("ModConditions.beenToTemple", () => beenToTemple);
        internal static bool beenToDungeon;
        public static Condition HasBeenToDungeon = new("ModConditions.beenToDungeon", () => beenToDungeon);
        internal static bool beenToAether;
        public static Condition HasBeenToAether = new("ModConditions.beenToAether", () => beenToAether);


        //AEQUUS
        internal static bool aequusLoaded;
        internal static Mod aequusMod;
        //BOSSES
        internal static bool downedCrabson;
        public static Condition DownedCrabson = new("ModConditions.downedCrabson", () => downedCrabson);
        internal static bool downedOmegaStarite;
        public static Condition DownedOmegaStarite = new("ModConditions.downedStarite", () => downedOmegaStarite);
        internal static bool downedDustDevil;
        public static Condition DownedDustDevil = new("ModConditions.downedDustDevil", () => downedDustDevil);
        //MINIBOSSES
        internal static bool downedHyperStarite;
        public static Condition DownedHyperStarite = new("ModConditions.downedHyperStarite", () => downedHyperStarite);
        internal static bool downedUltraStarite;
        public static Condition DownedUltraStarite = new("ModConditions.downedUltraStarite", () => downedUltraStarite);
        internal static bool downedRedSprite;
        public static Condition DownedRedSprite = new("ModConditions.downedRedSprite", () => downedRedSprite);
        internal static bool downedSpaceSquid;
        public static Condition DownedSpaceSquid = new("ModConditions.downedSpaceSquid", () => downedSpaceSquid);
        //EVENTS
        internal static bool downedDemonSiege;
        public static Condition DownedDemonSiege = new("ModConditions.downedDemonSiege", () => downedDemonSiege);
        internal static bool downedGlimmer;
        public static Condition DownedGlimmer = new("ModConditions.downedGlimmer", () => downedGlimmer);
        internal static bool downedGaleStreams;
        public static Condition DownedGaleStreams = new("ModConditions.downedGaleStreams", () => downedGaleStreams);
        //BIOMES
        internal static bool beenToCrabCrevice;
        public static Condition HasBeenToCrabCrevice = new("ModConditions.beenToCrabCrevice", () => beenToCrabCrevice);


        //AFKPETS
        internal static bool afkpetsLoaded;
        internal static Mod afkpetsMod;
        //BOSSES
        internal static bool downedSlayerOfEvil;
        public static Condition DownedSlayerOfEvil = new("ModConditions.downedSlayerOfEvil", () => downedSlayerOfEvil);
        internal static bool downedSATLA;
        public static Condition DownedSATLA = new("ModConditions.downedSATLA", () => downedSATLA);
        internal static bool downedDrFetus;
        public static Condition DownedDrFetus = new("ModConditions.downedDrFetus", () => downedDrFetus);
        internal static bool downedSlimesHope;
        public static Condition DownedSlimesHope = new("ModConditions.downedSlimesHope", () => downedSlimesHope);
        internal static bool downedPoliticianSlime;
        public static Condition DownedPoliticianSlime = new("ModConditions.downedPoliticianSlime", () => downedPoliticianSlime);
        internal static bool downedAncientTrio;
        public static Condition DownedAncientTrio = new("ModConditions.downedAncientTrio", () => downedAncientTrio);
        internal static bool downedLavalGolem;
        public static Condition DownedLavalGolem = new("ModConditions.downedLavalGolem", () => downedLavalGolem);
        //MINIBOSSES
        internal static bool downedAntony;
        public static Condition DownedAntony = new("ModConditions.downedAntony", () => downedAntony);
        internal static bool downedBunnyZeppelin;
        public static Condition DownedBunnyZeppelin = new("ModConditions.downedBunnyZeppelin", () => downedBunnyZeppelin);
        internal static bool downedOkiku;
        public static Condition DownedOkiku = new("ModConditions.downedOkiku", () => downedOkiku);
        internal static bool downedHarpyAirforce;
        public static Condition DownedHarpyAirforce = new("ModConditions.downedHarpyAirforce", () => downedHarpyAirforce);
        internal static bool downedIsaac;
        public static Condition DownedIsaac = new("ModConditions.downedIsaac", () => downedIsaac);
        internal static bool downedAncientGuardian;
        public static Condition DownedAncientGuardian = new("ModConditions.downedAncientGuardian", () => downedAncientGuardian);
        internal static bool downedHeroicSlime;
        public static Condition DownedHeroicSlime = new("ModConditions.downedHeroicSlime", () => downedHeroicSlime);
        internal static bool downedHoloSlime;
        public static Condition DownedHoloSlime = new("ModConditions.downedHoloSlime", () => downedHoloSlime);
        internal static bool downedSecurityBot;
        public static Condition DownedSecurityBot = new("ModConditions.downedSecurityBot", () => downedSecurityBot);
        internal static bool downedUndeadChef;
        public static Condition DownedUndeadChef = new("ModConditions.downedUndeadChef", () => downedUndeadChef);
        internal static bool downedGuardianOfFrost;
        public static Condition DownedGuardianOfFrost = new("ModConditions.downedGuardianOfFrost", () => downedGuardianOfFrost);


        //AMULET OF MANY MINIONS
        internal static bool amuletOfManyMinionsLoaded;
        internal static Mod amuletOfManyMinionsMod;


        //ARBOUR
        internal static bool arbourLoaded;
        internal static Mod arbourMod;


        //ASSORTED CRAZY THINGS
        internal static bool assortedCrazyThingsLoaded;
        internal static Mod assortedCrazyThingsMod;
        //BOSSES
        internal static bool downedSoulHarvester;
        public static Condition DownedSoulHarvester = new("ModConditions.downedSoulHarvester", () => downedSoulHarvester);


        //BOMBUS APIS
        internal static bool bombusApisLoaded;
        internal static Mod bombusApisMod;


        //BUFFARIA
        internal static bool buffariaLoaded;
        internal static Mod buffariaMod;


        //CALAMITY
        internal static bool calamityLoaded;
        internal static Mod calamityMod;
        //BOSSES
        internal static bool downedDesertScourge;
        public static Condition DownedDesertScourge = new("ModConditions.downedDesertScourge", () => downedDesertScourge);
        internal static bool downedCrabulon;
        public static Condition DownedCrabulon = new("ModConditions.downedCrabulon", () => downedCrabulon);
        internal static bool downedHiveMind;
        public static Condition DownedHiveMind = new("ModConditions.downedHiveMind", () => downedHiveMind);
        internal static bool downedPerforators;
        public static Condition DownedPerforators = new("ModConditions.downedPerforators", () => downedPerforators);
        public static Condition DownedPerforatorsOrHiveMind = new("ModConditions.downedPerfOrHive", () => downedPerforators || downedHiveMind);
        internal static bool downedSlimeGod;
        public static Condition DownedSlimeGod = new("ModConditions.downedSlimeGod", () => downedSlimeGod);
        internal static bool downedCryogen;
        public static Condition DownedCryogen = new("ModConditions.downedCryogen", () => downedCryogen);
        internal static bool downedAquaticScourge;
        public static Condition DownedAquaticScourge = new("ModConditions.downedAquaticScourge", () => downedAquaticScourge);
        internal static bool downedBrimstoneElemental;
        public static Condition DownedBrimstoneElemental = new("ModConditions.downedBrimstoneElemental", () => downedBrimstoneElemental);
        internal static bool downedCalamitasClone;
        public static Condition DownedCalamitasClone = new("ModConditions.downedCalamitasClone", () => downedCalamitasClone);
        internal static bool downedLeviathanAndAnahita;
        public static Condition DownedLeviathanAndAnahita = new("ModConditions.downedLeviathanAndAnahita", () => downedLeviathanAndAnahita);
        internal static bool downedAstrumAureus;
        public static Condition DownedAstrumAureus = new("ModConditions.downedAstrumAureus", () => downedAstrumAureus);
        internal static bool downedPlaguebringerGoliath;
        public static Condition DownedPlaguebringerGoliath = new("ModConditions.downedPlaguebringerGoliath", () => downedPlaguebringerGoliath);
        internal static bool downedRavager;
        public static Condition DownedRavager = new("ModConditions.downedRavager", () => downedRavager);
        internal static bool downedAstrumDeus;
        public static Condition DownedAstrumDeus = new("ModConditions.downedAstrumDeus", () => downedAstrumDeus);
        internal static bool downedProfanedGuardians;
        public static Condition DownedProfanedGuardians = new("ModConditions.downedProfanedGuardians", () => downedProfanedGuardians);
        internal static bool downedDragonfolly;
        public static Condition DownedDragonfolly = new("ModConditions.downedDragonfolly", () => downedDragonfolly);
        internal static bool downedProvidence;
        public static Condition DownedProvidence = new("ModConditions.downedProvidence", () => downedProvidence);
        internal static bool downedStormWeaver;
        public static Condition DownedStormWeaver = new("ModConditions.downedStormWeaver", () => downedStormWeaver);
        internal static bool downedCeaselessVoid;
        public static Condition DownedCeaselessVoid = new("ModConditions.downedCeaselessVoid", () => downedCeaselessVoid);
        internal static bool downedSignus;
        public static Condition DownedSignus = new("ModConditions.downedSignus", () => downedSignus);
        internal static bool downedPolterghast;
        public static Condition DownedPolterghast = new("ModConditions.downedPolterghast", () => downedPolterghast);
        internal static bool downedOldDuke;
        public static Condition DownedOldDuke = new("ModConditions.downedOldDuke", () => downedOldDuke);
        internal static bool downedDevourerOfGods;
        public static Condition DownedDevourerOfGods = new("ModConditions.downedDevourerOfGods", () => downedDevourerOfGods);
        internal static bool downedYharon;
        public static Condition DownedYharon = new("ModConditions.downedYharon", () => downedYharon);
        internal static bool downedExoMechs;
        public static Condition DownedExoMechs = new("ModConditions.downedExoMechs", () => downedExoMechs);
        internal static bool downedSupremeCalamitas;
        public static Condition DownedSupremeCalamitas = new("ModConditions.downedSupremeCalamitas", () => downedSupremeCalamitas);
        //MINIBOSSES
        internal static bool downedGiantClam;
        public static Condition DownedGiantClam = new("ModConditions.downedGiantClam", () => downedGiantClam);
        internal static bool downedCragmawMire;
        public static Condition DownedCragmawMire = new("ModConditions.downedCragmawMire", () => downedCragmawMire);
        internal static bool downedGreatSandShark;
        public static Condition DownedGreatSandShark = new("ModConditions.downedGreatSandShark", () => downedGreatSandShark);
        internal static bool downedNuclearTerror;
        public static Condition DownedNuclearTerror = new("ModConditions.downedNuclearTerror", () => downedNuclearTerror);
        internal static bool downedMauler;
        public static Condition DownedMauler = new("ModConditions.downedMauler", () => downedMauler);
        //EVENTS
        internal static bool downedAcidRain1;
        public static Condition DownedAcidRain1 = new("ModConditions.downedAcidRain1", () => downedAcidRain1);
        internal static bool downedAcidRain2;
        public static Condition DownedAcidRain2 = new("ModConditions.downedAcidRain2", () => downedAcidRain2);
        internal static bool downedBossRush;
        public static Condition DownedBossRush = new("ModConditions.downedBossRush", () => downedBossRush);
        //BIOMES
        internal static bool beenToCrags;
        public static Condition HasBeenToCrags = new("ModConditions.beenToCrags", () => beenToCrags);
        internal static bool beenToAstral;
        public static Condition HasBeenToAstral = new("ModConditions.beenToAstral", () => beenToAstral);
        internal static bool beenToSunkenSea;
        public static Condition HasBeenToSunkenSea = new("ModConditions.beenToSunkenSea", () => beenToSunkenSea);
        internal static bool beenToSulphurSea;
        public static Condition HasBeenToSulphurSea = new("ModConditions.beenToSulphurSea", () => beenToSulphurSea);
        internal static bool beenToAbyss;
        public static Condition HasBeenToAbyss = new("ModConditions.beenToAbyss", () => beenToAbyss);
        internal static bool beenToAbyssLayer1;
        public static Condition HasBeenToAbyssLayer1 = new("ModConditions.beenToAbyssLayer1", () => beenToAbyssLayer1);
        internal static bool beenToAbyssLayer2;
        public static Condition HasBeenToAbyssLayer2 = new("ModConditions.beenToAbyssLayer2", () => beenToAbyssLayer2);
        internal static bool beenToAbyssLayer3;
        public static Condition HasBeenToAbyssLayer3 = new("ModConditions.beenToAbyssLayer3", () => beenToAbyssLayer3);
        internal static bool beenToAbyssLayer4;
        public static Condition HasBeenToAbyssLayer4 = new("ModConditions.beenToAbyssLayer4", () => beenToAbyssLayer4);


        //CALAMITY VANITIES
        internal static bool calamityVanitiesLoaded;
        internal static Mod calamityVanitiesMod;
        //BIOMES
        internal static bool beenToAstralBlight;
        public static Condition HasBeenToAstralBlight = new("ModConditions.beenToAstralBlight", () => beenToAstralBlight);


        //CATALYST
        internal static bool catalystLoaded;
        internal static Mod catalystMod;
        //BOSSES
        internal static bool downedAstrageldon;
        public static Condition DownedAstrageldon = new("ModConditions.downedAstrageldon", () => downedAstrageldon);


        //CLAMITY
        internal static bool clamityAddonLoaded;
        internal static Mod clamityAddonMod;
        //BOSSES
        internal static bool downedClamitas;
        public static Condition DownedClamitas = new("ModConditions.downedClamitas", () => downedClamitas);


        //CLICKER CLASS
        internal static bool clickerClassLoaded;
        internal static Mod clickerClassMod;


        //CONFECTION
        internal static bool confectionRebakedLoaded;
        internal static Mod confectionRebakedMod;
        //BIOMES
        internal static bool beenToConfection;
        public static Condition HasBeenToConfection = new("ModConditions.beenToConfection", () => beenToConfection);
        public static Condition HasBeenToConfectionOrHallow = new("ModConditions.beenToConfectionOrHallow", () => beenToConfection || beenToHallow);


        //CONSOLARIA
        internal static bool consolariaLoaded;
        internal static Mod consolariaMod;
        //BOSSES
        internal static bool downedLepus;
        public static Condition DownedLepus = new("ModConditions.downedLepus", () => downedLepus);
        internal static bool downedTurkor;
        public static Condition DownedTurkor = new("ModConditions.downedTurkor", () => downedTurkor);
        internal static bool downedOcram;
        public static Condition DownedOcram = new("ModConditions.downedOcram", () => downedOcram);


        //DEPTHS
        internal static bool depthsLoaded;
        internal static Mod depthsMod;
        //BOSSES
        internal static bool downedChasme;
        public static Condition DownedChasme = new("ModConditions.downedChasme", () => downedChasme);
        //BIOMES
        internal static bool beenToDepths;
        public static Condition HasBeenToDepths = new("ModConditions.beenToDepths", () => beenToDepths);
        public static Condition HasBeenToDepthsOrUnderworld = new("ModConditions.beenToDepthsOrUnderworld", () => beenToDepths || beenToUnderworld);


        //DBZMOD
        internal static bool dragonBallTerrariaLoaded;
        internal static Mod dragonBallTerrariaMod;


        //ECHOES OF THE ANCIENTS
        internal static bool echoesOfTheAncientsLoaded;
        internal static Mod echoesOfTheAncientsMod;
        //BOSSES
        internal static bool downedGalahis;
        public static Condition DownedGalahis = new("ModConditions.downedGalahis", () => downedGalahis);
        internal static bool downedCreation;
        public static Condition DownedCreation = new("ModConditions.downedCreation", () => downedCreation);
        internal static bool downedDestruction;
        public static Condition DownedDestruction = new("ModConditions.downedDestruction", () => downedDestruction);


        //EDORBIS
        internal static bool edorbisLoaded;
        internal static Mod edorbisMod;
        //BOSSES
        internal static bool downedBlightKing;
        public static Condition DownedBlightKing = new("ModConditions.downedBlightKing", () => downedBlightKing);
        internal static bool downedGardener;
        public static Condition DownedGardener = new("ModConditions.downedGardener", () => downedGardener);
        internal static bool downedGlaciation;
        public static Condition DownedGlaciation = new("ModConditions.downedGlaciation", () => downedGlaciation);
        internal static bool downedHandOfCthulhu;
        public static Condition DownedHandOfCthulhu = new("ModConditions.downedHandOfCthulhu", () => downedHandOfCthulhu);
        internal static bool downedCursePreacher;
        public static Condition DownedCursePreacher = new("ModConditions.downedCursePreacher", () => downedCursePreacher);


        //ENCHANTED MOONS
        internal static bool enchantedMoonsLoaded;
        internal static Mod enchantedMoonsMod;


        //EXALT
        internal static bool exaltLoaded;
        internal static Mod exaltMod;
        //BOSSES
        internal static bool downedEffulgence;
        public static Condition DownedEffulgence = new("ModConditions.downedEffulgence", () => downedEffulgence);
        internal static bool downedIceLich;
        public static Condition DownedIceLich = new("ModConditions.downedIceLich", () => downedIceLich);


        //FARGOS
        internal static bool fargosMutantLoaded;
        internal static Mod fargosMutantMod;


        //FARGOS SOULS
        internal static bool fargosSoulsLoaded;
        internal static Mod fargosSoulsMod;
        //BOSSES
        internal static bool downedTrojanSquirrel;
        public static Condition DownedTrojanSquirrel = new("ModConditions.downedTrojanSquirrel", () => downedTrojanSquirrel);
        internal static bool downedDeviantt;
        public static Condition DownedDeviantt = new("ModConditions.downedDeviantt", () => downedDeviantt);
        internal static bool downedLieflight;
        public static Condition DownedLieflight = new("ModConditions.downedLieflight", () => downedLieflight);
        internal static bool downedEridanus;
        public static Condition DownedEridanus = new("ModConditions.downedEridanus", () => downedEridanus);
        internal static bool downedAbominationn;
        public static Condition DownedAbominationn = new("ModConditions.downedAbominationn", () => downedAbominationn);
        internal static bool downedMutant;
        public static Condition DownedMutant = new("ModConditions.downedMutant", () => downedMutant);


        //FARGOS SOULS DLC
        internal static bool fargosSoulsDLCLoaded;
        internal static Mod fargosSoulsDLCMod;


        //FRACTURES OF PENUMBRA
        internal static bool fracturesOfPenumbraLoaded;
        internal static Mod fracturesOfPenumbraMod;
        //BOSSES
        internal static bool downedAlphaFrostjaw;
        public static Condition DownedAlphaFrostjaw = new("ModConditions.downedAlphaFrostjaw", () => downedAlphaFrostjaw);
        internal static bool downedSanguineElemental;
        public static Condition DownedSanguineElemental = new("ModConditions.downedSanguineElemental", () => downedSanguineElemental);
        //BIOMES
        internal static bool beenToDread;
        public static Condition HasBeenToDread = new("ModConditions.beenToDread", () => beenToDread);


        //FURNITURE FOOD & FUN
        internal static bool furnitureFoodAndFunLoaded;
        internal static Mod furnitureFoodAndFunMod;


        //GAMETERRARIA
        internal static bool gameTerrariaLoaded;
        internal static Mod gameTerrariaMod;
        //BOSSES
        internal static bool downedLad;
        public static Condition DownedLad = new("ModConditions.downedLad", () => downedLad);
        internal static bool downedHornlitz;
        public static Condition DownedHornlitz = new("ModConditions.downedHornlitz", () => downedHornlitz);
        internal static bool downedSnowDon;
        public static Condition DownedSnowDon = new("ModConditions.downedSnowDon", () => downedSnowDon);
        internal static bool downedStoffie;
        public static Condition DownedStoffie = new("ModConditions.downedStoffie", () => downedStoffie);


        //GENSOKYO
        internal static bool gensokyoLoaded;
        internal static Mod gensokyoMod;
        //BOSSES
        internal static bool downedLilyWhite;
        public static Condition DownedLilyWhite = new("ModConditions.downedLilyWhite", () => downedLilyWhite);
        internal static bool downedRumia;
        public static Condition DownedRumia = new("ModConditions.downedRumia", () => downedRumia);
        internal static bool downedEternityLarva;
        public static Condition DownedEternityLarva = new("ModConditions.downedEternityLarva", () => downedEternityLarva);
        internal static bool downedNazrin;
        public static Condition DownedNazrin = new("ModConditions.downedNazrin", () => downedNazrin);
        internal static bool downedHinaKagiyama;
        public static Condition DownedHinaKagiyama = new("ModConditions.downedHinaKagiyama", () => downedHinaKagiyama);
        internal static bool downedSekibanki;
        public static Condition DownedSekibanki = new("ModConditions.downedSekibanki", () => downedSekibanki);
        internal static bool downedSeiran;
        public static Condition DownedSeiran = new("ModConditions.downedSeiran", () => downedSeiran);
        internal static bool downedNitoriKawashiro;
        public static Condition DownedNitoriKawashiro = new("ModConditions.downedNitoriKawashiro", () => downedNitoriKawashiro);
        internal static bool downedMedicineMelancholy;
        public static Condition DownedMedicineMelancholy = new("ModConditions.downedMedicineMelancholy", () => downedMedicineMelancholy);
        internal static bool downedCirno;
        public static Condition DownedCirno = new("ModConditions.downedCirno", () => downedCirno);
        internal static bool downedMinamitsuMurasa;
        public static Condition DownedMinamitsuMurasa = new("ModConditions.downedMinamitsuMurasa", () => downedMinamitsuMurasa);
        internal static bool downedAliceMargatroid;
        public static Condition DownedAliceMargatroid = new("ModConditions.downedAliceMargatroid", () => downedAliceMargatroid);
        internal static bool downedSakuyaIzayoi;
        public static Condition DownedSakuyaIzayoi = new("ModConditions.downedSakuyaIzayoi", () => downedSakuyaIzayoi);
        internal static bool downedSeijaKijin;
        public static Condition DownedSeijaKijin = new("ModConditions.downedSeijaKijin", () => downedSeijaKijin);
        internal static bool downedMayumiJoutouguu;
        public static Condition DownedMayumiJoutouguu = new("ModConditions.downedMayumiJoutouguu", () => downedMayumiJoutouguu);
        internal static bool downedToyosatomimiNoMiko;
        public static Condition DownedToyosatomimiNoMiko = new("ModConditions.downedToyosatomimiNoMiko", () => downedToyosatomimiNoMiko);
        internal static bool downedKaguyaHouraisan;
        public static Condition DownedKaguyaHouraisan = new("ModConditions.downedKaguyaHouraisan", () => downedKaguyaHouraisan);
        internal static bool downedUtsuhoReiuji;
        public static Condition DownedUtsuhoReiuji = new("ModConditions.downedUtsuhoReiuji", () => downedUtsuhoReiuji);
        internal static bool downedTenshiHinanawi;
        public static Condition DownedTenshiHinanawi = new("ModConditions.downedTenshiHinanawi", () => downedTenshiHinanawi);
        //MINIBOSSES
        internal static bool downedKisume;
        public static Condition DownedKisume = new("ModConditions.downedKisume", () => downedKisume);


        //GMR
        internal static bool gerdsLabLoaded;
        internal static Mod gerdsLabMod;
        //BOSSES
        internal static bool downedTrerios;
        public static Condition DownedTrerios = new("ModConditions.downedTrerios", () => downedTrerios);
        internal static bool downedMagmaEye;
        public static Condition DownedMagmaEye = new("ModConditions.downedMagmaEye", () => downedMagmaEye);
        internal static bool downedJack;
        public static Condition DownedJack = new("ModConditions.downedJack", () => downedJack);
        internal static bool downedAcheron;
        public static Condition DownedAcheron = new("ModConditions.downedAcheron", () => downedAcheron);


        //HEARTBEATARIA
        internal static bool heartbeatariaLoaded;
        internal static Mod heartbeatariaMod;


        //HOMEWARD JOURNEY
        internal static bool homewardJourneyLoaded;
        internal static Mod homewardJourneyMod;
        //BOSSES
        internal static bool downedMarquisMoonsquid;
        public static Condition DownedMarquisMoonsquid = new("ModConditions.downedMarquisMoonsquid", () => downedMarquisMoonsquid);
        internal static bool downedPriestessRod;
        public static Condition DownedPriestessRod = new("ModConditions.downedPriestessRod", () => downedPriestessRod);
        internal static bool downedDiver;
        public static Condition DownedDiver = new("ModConditions.downedDiver", () => downedDiver);
        internal static bool downedMotherbrain;
        public static Condition DownedMotherbrain = new("ModConditions.downedMotherbrain", () => downedMotherbrain);
        internal static bool downedWallOfShadow;
        public static Condition DownedWallOfShadow = new("ModConditions.downedWallOfShadow", () => downedWallOfShadow);
        internal static bool downedSunSlimeGod;
        public static Condition DownedSunSlimeGod = new("ModConditions.downedSunSlimeGod", () => downedSunSlimeGod);
        internal static bool downedOverwatcher;
        public static Condition DownedOverwatcher = new("ModConditions.downedOverwatcher", () => downedOverwatcher);
        internal static bool downedLifebringer;
        public static Condition DownedLifebringer = new("ModConditions.downedLifebringer", () => downedLifebringer);
        internal static bool downedMaterealizer;
        public static Condition DownedMaterealizer = new("ModConditions.downedMaterealizer", () => downedMaterealizer);
        internal static bool downedScarabBelief;
        public static Condition DownedScarabBelief = new("ModConditions.downedScarabBelief", () => downedScarabBelief);
        internal static bool downedWorldsEndWhale;
        public static Condition DownedWorldsEndWhale = new("ModConditions.downedWorldsEndWhale", () => downedWorldsEndWhale);
        internal static bool downedSon;
        public static Condition DownedSon = new("ModConditions.downedSon", () => downedSon);
        //EVENTS
        internal static bool downedCaveOrdeal;
        public static Condition DownedCaveOrdeal = new("ModConditions.downedCaveOrdeal", () => downedCaveOrdeal);
        internal static bool downedCorruptOrdeal;
        public static Condition DownedCorruptOrdeal = new("ModConditions.downedCorruptOrdeal", () => downedCorruptOrdeal);
        internal static bool downedCrimsonOrdeal;
        public static Condition DownedCrimsonOrdeal = new("ModConditions.downedCrimsonOrdeal", () => downedCrimsonOrdeal);
        internal static bool downedDesertOrdeal;
        public static Condition DownedDesertOrdeal = new("ModConditions.downedDesertOrdeal", () => downedDesertOrdeal);
        internal static bool downedForestOrdeal;
        public static Condition DownedForestOrdeal = new("ModConditions.downedForestOrdeal", () => downedForestOrdeal);
        internal static bool downedHallowOrdeal;
        public static Condition DownedHallowOrdeal = new("ModConditions.downedHallowOrdeal", () => downedHallowOrdeal);
        internal static bool downedJungleOrdeal;
        public static Condition DownedJungleOrdeal = new("ModConditions.downedJungleOrdeal", () => downedJungleOrdeal);
        internal static bool downedSkyOrdeal;
        public static Condition DownedSkyOrdeal = new("ModConditions.downedSkyOrdeal", () => downedSkyOrdeal);
        internal static bool downedSnowOrdeal;
        public static Condition DownedSnowOrdeal = new("ModConditions.downedSnowOrdeal", () => downedSnowOrdeal);
        internal static bool downedUnderworldOrdeal;
        public static Condition DownedUnderworldOrdeal = new("ModConditions.downedUnderworldOrdeal", () => downedUnderworldOrdeal);
        //BIOMES
        internal static bool beenToHomewardAbyss;
        public static Condition HasBeenToHomewardAbyss = new("ModConditions.beenToHomewardAbyss", () => beenToHomewardAbyss);


        //HUNT OF THE OLD GOD
        internal static bool huntOfTheOldGodLoaded;
        internal static Mod huntOfTheOldGodMod;
        //BOSSES
        internal static bool downedGoozma;
        public static Condition DownedGoozma = new("ModConditions.downedGoozma", () => downedGoozma);


        //INFERNUM
        internal static bool infernumLoaded;
        internal static Mod infernumMod;
        //BOSSES
        internal static bool downedBereftVassal;
        public static Condition DownedBereftVassal = new("ModConditions.downedBereftVassal", () => downedBereftVassal);
        //BIOMES
        internal static bool beenToProfanedGardens;
        public static Condition HasBeenToProfanedGardens = new("ModConditions.beenToProfanedGardens", () => beenToProfanedGardens);


        //MAGIC STORAGE
        internal static bool magicStorageLoaded;
        internal static Mod magicStorageMod;


        //MECH REWORK
        internal static bool mechReworkLoaded;
        internal static Mod mechReworkMod;
        //BOSSES
        internal static bool downedSt4sys;
        public static Condition DownedSt4sys = new("ModConditions.downedSt4sys", () => downedSt4sys);
        internal static bool downedTerminator;
        public static Condition DownedTerminator = new("ModConditions.downedTerminator", () => downedTerminator);
        internal static bool downedCaretaker;
        public static Condition DownedCaretaker = new("ModConditions.downedCaretaker", () => downedCaretaker);
        internal static bool downedSiegeEngine;
        public static Condition DownedSiegeEngine = new("ModConditions.downedSiegeEngine", () => downedSiegeEngine);


        //METROID MOD
        internal static bool metroidLoaded;
        internal static Mod metroidMod;
        //BOSSES
        internal static bool downedTorizo;
        public static Condition DownedTorizo = new("ModConditions.downedTorizo", () => downedTorizo);
        internal static bool downedSerris;
        public static Condition DownedSerris = new("ModConditions.downedSerris", () => downedSerris);
        internal static bool downedKraid;
        public static Condition DownedKraid = new("ModConditions.downedKraid", () => downedKraid);
        internal static bool downedPhantoon;
        public static Condition DownedPhantoon = new("ModConditions.downedPhantoon", () => downedPhantoon);
        internal static bool downedOmegaPirate;
        public static Condition DownedOmegaPirate = new("ModConditions.downedOmegaPirate", () => downedOmegaPirate);
        internal static bool downedNightmare;
        public static Condition DownedNightmare = new("ModConditions.downedNightmare", () => downedNightmare);
        internal static bool downedGoldenTorizo;
        public static Condition DownedGoldenTorizo = new("ModConditions.downedGoldenTorizo", () => downedGoldenTorizo);


        //POLARITIES
        internal static bool polaritiesLoaded;
        internal static Mod polaritiesMod;
        //BOSSES
        internal static bool downedStormCloudfish;
        public static Condition DownedStormCloudfish = new("ModConditions.downedStormCloudfish", () => downedStormCloudfish);
        internal static bool downedStarConstruct;
        public static Condition DownedStarConstruct = new("ModConditions.downedStarConstruct", () => downedStarConstruct);
        internal static bool downedGigabat;
        public static Condition DownedGigabat = new("ModConditions.downedGigabat", () => downedGigabat);
        internal static bool downedSunPixie;
        public static Condition DownedSunPixie = new("ModConditions.downedSunPixie", () => downedSunPixie);
        internal static bool downedEsophage;
        public static Condition DownedEsophage = new("ModConditions.downedEsophage", () => downedEsophage);
        internal static bool downedConvectiveWanderer;
        public static Condition DownedConvectiveWanderer = new("ModConditions.downedConvectiveWanderer", () => downedConvectiveWanderer);


        //QWERTY
        internal static bool qwertyLoaded;
        internal static Mod qwertyMod;
        //BOSSES
        internal static bool downedPolarExterminator;
        public static Condition DownedPolarExterminator = new("ModConditions.downedPolarExterminator", () => downedPolarExterminator);
        internal static bool downedDivineLight;
        public static Condition DownedDivineLight = new("ModConditions.downedDivineLight", () => downedDivineLight);
        internal static bool downedAncientMachine;
        public static Condition DownedAncientMachine = new("ModConditions.downedAncientMachine", () => downedAncientMachine);
        internal static bool downedNoehtnap;
        public static Condition DownedNoehtnap = new("ModConditions.downedNoehtnap", () => downedNoehtnap);
        internal static bool downedHydra;
        public static Condition DownedHydra = new("ModConditions.downedHydra", () => downedHydra);
        internal static bool downedImperious;
        public static Condition DownedImperious = new("ModConditions.downedImperious", () => downedImperious);
        internal static bool downedRuneGhost;
        public static Condition DownedRuneGhost = new("ModConditions.downedRuneGhost", () => downedRuneGhost);
        internal static bool downedInvaderBattleship;
        public static Condition DownedInvaderBattleship = new("ModConditions.downedInvaderBattleship", () => downedInvaderBattleship);
        internal static bool downedInvaderNoehtnap;
        public static Condition DownedInvaderNoehtnap = new("ModConditions.downedInvaderNoehtnap", () => downedInvaderNoehtnap);
        internal static bool downedOLORD;
        public static Condition DownedOLORD = new("ModConditions.downedOLORD", () => downedOLORD);
        //MINIBOSSES
        internal static bool downedGreatTyrannosaurus;
        public static Condition DownedGreatTyrannosaurus = new("ModConditions.downedGreatTyrannosaurus", () => downedGreatTyrannosaurus);
        //EVENTS
        internal static bool downedDinoMilitia;
        public static Condition DownedDinoMilitia = new("ModConditions.downedDinoMilitia", () => downedDinoMilitia);
        internal static bool downedInvaders;
        public static Condition DownedInvaders = new("ModConditions.downedInvaders", () => downedInvaders);
        //BIOMES
        internal static bool beenToSkyFortress;
        public static Condition HasBeenToSkyFortress = new("ModConditions.beenToSkyFortress", () => beenToSkyFortress);


        //REDEMPTION
        internal static bool redemptionLoaded;
        internal static Mod redemptionMod;
        //BOSSES
        internal static bool downedThorn;
        public static Condition DownedThorn = new("ModConditions.downedThorn", () => downedThorn);
        internal static bool downedErhan;
        public static Condition DownedErhan = new("ModConditions.downedErhan", () => downedErhan);
        internal static bool downedKeeper;
        public static Condition DownedKeeper = new("ModConditions.downedKeeper", () => downedKeeper);
        internal static bool downedSeedOfInfection;
        public static Condition DownedSeedOfInfection = new("ModConditions.downedSeedOfInfection", () => downedSeedOfInfection);
        internal static bool downedKingSlayerIII;
        public static Condition DownedKingSlayerIII = new("ModConditions.downedKingSlayerIII", () => downedKingSlayerIII);
        internal static bool downedOmegaCleaver;
        public static Condition DownedOmegaCleaver = new("ModConditions.downedOmegaCleaver", () => downedOmegaCleaver);
        internal static bool downedOmegaGigapora;
        public static Condition DownedOmegaGigapora = new("ModConditions.downedOmegaGigapora", () => downedOmegaGigapora);
        internal static bool downedOmegaObliterator;
        public static Condition DownedOmegaObliterator = new("ModConditions.downedOmegaObliterator", () => downedOmegaObliterator);
        internal static bool downedPatientZero;
        public static Condition DownedPatientZero = new("ModConditions.downedPatientZero", () => downedPatientZero);
        internal static bool downedAkka;
        public static Condition DownedAkka = new("ModConditions.downedAkka", () => downedAkka);
        internal static bool downedUkko;
        public static Condition DownedUkko = new("ModConditions.downedUkko", () => downedUkko);
        internal static bool downedAncientDeityDuo;
        public static Condition DownedAncientDeityDuo = new("ModConditions.downedAncientDeityDuo", () => downedAncientDeityDuo);
        internal static bool downedNebuleus;
        public static Condition DownedNebuleus = new("ModConditions.downedNebuleus", () => downedNebuleus);
        //MINIBOSSES
        internal static bool downedFowlEmperor;
        public static Condition DownedFowlEmperor = new("ModConditions.downedFowlEmperor", () => downedFowlEmperor);
        //EVENTS
        internal static bool downedFowlMorning;
        public static Condition DownedFowlMorning = new("ModConditions.downedFowlMorning", () => downedFowlMorning);
        internal static bool downedRaveyard;
        public static Condition DownedRaveyard = new("ModConditions.downedRaveyard", () => downedRaveyard);
        //BIOMES
        internal static bool beenToLab;
        public static Condition HasBeenToLab = new("ModConditions.beenToLab", () => beenToLab);
        internal static bool beenToWasteland;
        public static Condition HasBeenToWasteland = new("ModConditions.beenToWasteland", () => beenToWasteland);


        //REFORGED
        internal static bool reforgedLoaded;
        internal static Mod reforgedMod;


        //REMNANTS
        internal static bool remnantsLoaded;
        internal static Mod remnantsMod;


        //SECRETS OF THE SHADOWS
        internal static bool secretsOfTheShadowsLoaded;
        internal static Mod secretsOfTheShadowsMod;
        //BOSSES
        internal static bool downedPutridPinky;
        public static Condition DownedPutridPinky = new("ModConditions.downedPutridPinky", () => downedPutridPinky);
        internal static bool downedGlowmoth;
        public static Condition DownedGlowmoth = new("ModConditions.downedGlowmoth", () => downedGlowmoth);
        internal static bool downedPharaohsCurse;
        public static Condition DownedPharaohsCurse = new("ModConditions.downedPharaohsCurse", () => downedPharaohsCurse);
        internal static bool downedAdvisor;
        public static Condition DownedAdvisor = new("ModConditions.downedAdvisor", () => downedAdvisor);
        internal static bool downedPolaris;
        public static Condition DownedPolaris = new("ModConditions.downedPolaris", () => downedPolaris);
        internal static bool downedLux;
        public static Condition DownedLux = new("ModConditions.downedLux", () => downedLux);
        internal static bool downedSubspaceSerpent;
        public static Condition DownedSubspaceSerpent = new("ModConditions.downedSubspaceSerpent", () => downedSubspaceSerpent);
        //MINIBOSSES
        internal static bool downedNatureConstruct;
        public static Condition DownedNatureConstruct = new("ModConditions.downedNatureConstruct", () => downedNatureConstruct);
        internal static bool downedEarthenConstruct;
        public static Condition DownedEarthenConstruct = new("ModConditions.downedEarthenConstruct", () => downedEarthenConstruct);
        internal static bool downedPermafrostConstruct;
        public static Condition DownedPermafrostConstruct = new("ModConditions.downedPermafrostConstruct", () => downedPermafrostConstruct);
        internal static bool downedTidalConstruct;
        public static Condition DownedTidalConstruct = new("ModConditions.downedTidalConstruct", () => downedTidalConstruct);
        internal static bool downedOtherworldlyConstruct;
        public static Condition DownedOtherworldlyConstruct = new("ModConditions.downedOtherworldlyConstruct", () => downedOtherworldlyConstruct);
        internal static bool downedEvilConstruct;
        public static Condition DownedEvilConstruct = new("ModConditions.downedEvilConstruct", () => downedEvilConstruct);
        internal static bool downedInfernoConstruct;
        public static Condition DownedInfernoConstruct = new("ModConditions.downedInfernoConstruct", () => downedInfernoConstruct);
        internal static bool downedChaosConstruct;
        public static Condition DownedChaosConstruct = new("ModConditions.downedChaosConstruct", () => downedChaosConstruct);
        internal static bool downedNatureSpirit;
        public static Condition DownedNatureSpirit = new("ModConditions.downedNatureSpirit", () => downedNatureSpirit);
        internal static bool downedEarthenSpirit;
        public static Condition DownedEarthenSpirit = new("ModConditions.downedEarthenSpirit", () => downedEarthenSpirit);
        internal static bool downedPermafrostSpirit;
        public static Condition DownedPermafrostSpirit = new("ModConditions.downedPermafrostSpirit", () => downedPermafrostSpirit);
        internal static bool downedTidalSpirit;
        public static Condition DownedTidalSpirit = new("ModConditions.downedTidalSpirit", () => downedTidalSpirit);
        internal static bool downedOtherworldlySpirit;
        public static Condition DownedOtherworldlySpirit = new("ModConditions.downedOtherworldlySpirit", () => downedOtherworldlySpirit);
        internal static bool downedEvilSpirit;
        public static Condition DownedEvilSpirit = new("ModConditions.downedEvilSpirit", () => downedEvilSpirit);
        internal static bool downedInfernoSpirit;
        public static Condition DownedInfernoSpirit = new("ModConditions.downedInfernoSpirit", () => downedInfernoSpirit);
        internal static bool downedChaosSpirit;
        public static Condition DownedChaosSpirit = new("ModConditions.downedChaosSpirit", () => downedChaosSpirit);
        //BIOMES
        internal static bool beenToPyramid;
        public static Condition HasBeenToPyramid = new("ModConditions.beenToPyramid", () => beenToPyramid);
        internal static bool beenToPlanetarium;
        public static Condition HasBeenToPlanetarium = new("ModConditions.beenToPlanetarium", () => beenToPlanetarium);


        //SPIRIT
        internal static bool spiritLoaded;
        internal static Mod spiritMod;
        //BOSSES
        internal static bool downedScarabeus;
        public static Condition DownedScarabeus = new("ModConditions.downedScarabeus", () => downedScarabeus);
        internal static bool downedMoonJellyWizard;
        public static Condition DownedMoonJellyWizard = new("ModConditions.downedMoonJellyWizard", () => downedMoonJellyWizard);
        internal static bool downedVinewrathBane;
        public static Condition DownedVinewrathBane = new("ModConditions.downedVinewrathBane", () => downedVinewrathBane);
        internal static bool downedAncientAvian;
        public static Condition DownedAncientAvian = new("ModConditions.downedAncientAvian", () => downedAncientAvian);
        internal static bool downedStarplateVoyager;
        public static Condition DownedStarplateVoyager = new("ModConditions.downedStarplateVoyager", () => downedStarplateVoyager);
        internal static bool downedInfernon;
        public static Condition DownedInfernon = new("ModConditions.downedInfernon", () => downedInfernon);
        internal static bool downedDusking;
        public static Condition DownedDusking = new("ModConditions.downedDusking", () => downedDusking);
        internal static bool downedAtlas;
        public static Condition DownedAtlas = new("ModConditions.downedAtlas", () => downedAtlas);
        //EVENTS
        internal static bool downedJellyDeluge;
        public static Condition DownedJellyDeluge = new("ModConditions.downedJellyDeluge", () => downedJellyDeluge);
        internal static bool downedTide;
        public static Condition DownedTide = new("ModConditions.downedTide", () => downedTide);
        internal static bool downedMysticMoon;
        public static Condition DownedMysticMoon = new("ModConditions.downedMysticMoon", () => downedMysticMoon);
        //BIOMES
        internal static bool beenToBriar;
        public static Condition HasBeenToBriar = new("ModConditions.beenToBriar", () => beenToBriar);
        internal static bool beenToSpirit;
        public static Condition HasBeenToSpirit = new("ModConditions.beenToSpirit", () => beenToSpirit);


        //SPOOKY
        internal static bool spookyLoaded;
        internal static Mod spookyMod;
        //BOSSES
        internal static bool downedSpookySpirit;
        public static Condition DownedSpookySpirit = new("ModConditions.downedSpookySpirit", () => downedSpookySpirit);
        internal static bool downedRotGourd;
        public static Condition DownedRotGourd = new("ModConditions.downedRotGourd", () => downedRotGourd);
        internal static bool downedMoco;
        public static Condition DownedMoco = new("ModConditions.downedMoco", () => downedMoco);
        internal static bool downedDaffodil;
        public static Condition DownedDaffodil = new("ModConditions.downedDaffodil", () => downedDaffodil);
        internal static bool downedOrroBoro;
        internal static bool downedOrro;
        internal static bool downedBoro;
        public static Condition DownedOrroBoro = new("ModConditions.downedOrroBoro", () => downedOrroBoro);
        internal static bool downedBigBone;
        public static Condition DownedBigBone = new("ModConditions.downedBigBone", () => downedBigBone);
        //BIOMES
        internal static bool beenToSpookyForest;
        public static Condition HasBeenToSpookyForest = new("ModConditions.beenToSpookyForest", () => beenToSpookyForest);
        internal static bool beenToSpookyUnderground;
        public static Condition HasBeenToSpookyUnderground = new("ModConditions.beenToSpookyUnderground", () => beenToSpookyUnderground);
        internal static bool beenToEyeValley;
        public static Condition HasBeenToEyeValley = new("ModConditions.beenToEyeValley", () => beenToEyeValley);
        internal static bool beenToCatacombs;
        public static Condition HasBeenToCatacombs = new("ModConditions.beenToCatacombs", () => beenToCatacombs);
        internal static bool beenToCemetery;
        public static Condition HasBeenToCemetery = new("ModConditions.beenToCemetery", () => beenToCemetery);


        //STARLIGHT RIVER
        internal static bool starlightRiverLoaded;
        internal static Mod starlightRiverMod;
        //BOSSES
        internal static bool downedAuroracle;
        public static Condition DownedAuroracle = new("ModConditions.downedAuroracle", () => downedAuroracle);
        internal static bool downedCeiros;
        public static Condition DownedCeiros = new("ModConditions.downedCeiros", () => downedCeiros);
        //MINIBOSSES
        internal static bool downedGlassweaver;
        public static Condition DownedGlassweaver = new("ModConditions.downedGlassweaver", () => downedGlassweaver);
        //BIOMES
        internal static bool beenToAuroracleTemple;
        public static Condition HasBeenToAuroracleTemple = new("ModConditions.beenToAuroracleTemple", () => beenToAuroracleTemple);
        internal static bool beenToVitricDesert;
        public static Condition HasBeenToVitricDesert = new("ModConditions.beenToVitricDesert", () => beenToVitricDesert);
        internal static bool beenToVitricTemple;
        public static Condition HasBeenToVitricTemple = new("ModConditions.beenToVitricTemple", () => beenToVitricTemple);


        //STARS ABOVE
        internal static bool starsAboveLoaded;
        internal static Mod starsAboveMod;
        //BOSSES
        internal static bool downedVagrantofSpace;
        public static Condition DownedVagrantofSpace = new("ModConditions.downedVagrantofSpace", () => downedVagrantofSpace);
        internal static bool downedCastor;
        internal static bool downedPollux;
        internal static bool downedDioskouroi;
        public static Condition DownedDioskouroi = new("ModConditions.downedDioskouroi", () => downedDioskouroi);
        internal static bool downedNalhaun;
        public static Condition DownedNalhaun = new("ModConditions.downedNalhaun", () => downedNalhaun);
        internal static bool downedPenthesilea;
        public static Condition DownedPenthesilea = new("ModConditions.downedPenthesilea", () => downedPenthesilea);
        internal static bool downedArbitration;
        public static Condition DownedArbitration = new("ModConditions.downedArbitration", () => downedArbitration);
        internal static bool downedWarriorOfLight;
        public static Condition DownedWarriorOfLight = new("ModConditions.downedWarriorOfLight", () => downedWarriorOfLight);
        internal static bool downedTsukiyomi;
        public static Condition DownedTsukiyomi = new("ModConditions.downedTsukiyomi", () => downedTsukiyomi);


        //STORM DIVERS MOD
        internal static bool stormsAdditionsLoaded;
        internal static Mod stormsAdditionsMod;
        //BOSSES
        internal static bool downedAncientHusk;
        public static Condition DownedAncientHusk = new("ModConditions.downedAncientHusk", () => downedAncientHusk);
        internal static bool downedOverloadedScandrone;
        public static Condition DownedOverloadedScandrone = new("ModConditions.downedOverloadedScandrone", () => downedOverloadedScandrone);
        internal static bool downedPainbringer;
        public static Condition DownedPainbringer = new("ModConditions.downedPainbringer", () => downedPainbringer);


        //SUPERNOVA
        internal static bool supernovaLoaded;
        internal static Mod supernovaMod;
        //BOSSES
        internal static bool downedHarbingerOfAnnihilation;
        public static Condition DownedHarbingerOfAnnihilation = new("ModConditions.downedHarbingerOfAnnihilation", () => downedHarbingerOfAnnihilation);
        internal static bool downedFlyingTerror;
        public static Condition DownedFlyingTerror = new("ModConditions.downedFlyingTerror", () => downedFlyingTerror);
        internal static bool downedStoneMantaRay;
        public static Condition DownedStoneMantaRay = new("ModConditions.downedStoneMantaRay", () => downedStoneMantaRay);


        //TERRORBORN
        internal static bool terrorbornLoaded;
        internal static Mod terrorbornMod;
        //BOSSES
        internal static bool downedInfectedIncarnate;
        public static Condition DownedInfectedIncarnate = new("ModConditions.downedInfectedIncarnate", () => downedInfectedIncarnate);
        internal static bool downedTidalTitan;
        public static Condition DownedTidalTitan = new("ModConditions.downedTidalTitan", () => downedTidalTitan);
        internal static bool downedDunestock;
        public static Condition DownedDunestock = new("ModConditions.downedDunestock", () => downedDunestock);
        internal static bool downedHexedConstructor;
        public static Condition DownedHexedConstructor = new("ModConditions.downedHexedConstructor", () => downedHexedConstructor);
        internal static bool downedShadowcrawler;
        public static Condition DownedShadowcrawler = new("ModConditions.downedShadowcrawler", () => downedShadowcrawler);
        internal static bool downedPrototypeI;
        public static Condition DownedPrototypeI = new("ModConditions.downedPrototypeI", () => downedPrototypeI);


        //THORIUM
        internal static bool thoriumLoaded;
        internal static Mod thoriumMod;
        //BOSSES
        internal static bool downedGrandThunderBird;
        public static Condition DownedGrandThunderBird = new("ModConditions.downedGrandThunderBird", () => downedGrandThunderBird);
        internal static bool downedQueenJellyfish;
        public static Condition DownedQueenJellyfish = new("ModConditions.downedQueenJellyfish", () => downedQueenJellyfish);
        internal static bool downedViscount;
        public static Condition DownedViscount = new("ModConditions.downedViscount", () => downedViscount);
        internal static bool downedGraniteEnergyStorm;
        public static Condition DownedGraniteEnergyStorm = new("ModConditions.downedGraniteEnergyStorm", () => downedGraniteEnergyStorm);
        internal static bool downedBuriedChampion;
        public static Condition DownedBuriedChampion = new("ModConditions.downedBuriedChampion", () => downedBuriedChampion);
        internal static bool downedStarScouter;
        public static Condition DownedStarScouter = new("ModConditions.downedStarScouter", () => downedStarScouter);
        internal static bool downedBoreanStrider;
        public static Condition DownedBoreanStrider = new("ModConditions.downedBoreanStrider", () => downedBoreanStrider);
        internal static bool downedFallenBeholder;
        public static Condition DownedFallenBeholder = new("ModConditions.downedFallenBeholder", () => downedFallenBeholder);
        internal static bool downedLich;
        public static Condition DownedLich = new("ModConditions.downedLich", () => downedLich);
        internal static bool downedForgottenOne;
        public static Condition DownedForgottenOne = new("ModConditions.downedForgottenOne", () => downedForgottenOne);
        internal static bool downedPrimordials;
        public static Condition DownedPrimordials = new("ModConditions.downedPrimordials", () => downedPrimordials);
        //MINIBOSSES
        internal static bool downedPatchWerk;
        public static Condition DownedPatchWerk = new("ModConditions.downedPatchWerk", () => downedPatchWerk);
        internal static bool downedCorpseBloom;
        public static Condition DownedCorpseBloom = new("ModConditions.downedCorpseBloom", () => downedCorpseBloom);
        internal static bool downedIllusionist;
        public static Condition DownedIllusionist = new("ModConditions.downedIllusionist", () => downedIllusionist);
        //BIOMES
        internal static bool beenToAquaticDepths;
        public static Condition HasBeenToAquaticDepths = new("ModConditions.beenToAquaticDepths", () => beenToAquaticDepths);


        //TRAE
        internal static bool traeLoaded;
        internal static Mod traeMod;
        internal static bool downedGraniteOvergrowth;
        public static Condition DownedGraniteOvergrowth = new("ModConditions.downedGraniteOvergrowth", () => downedGraniteOvergrowth);
        internal static bool downedBeholder;
        public static Condition DownedBeholder = new("ModConditions.downedBeholder", () => downedBeholder);


        //UHTRIC
        internal static bool uhtricLoaded;
        internal static Mod uhtricMod;
        internal static bool downedDredger;
        public static Condition DownedDredger = new("ModConditions.downedDredger", () => downedDredger);
        internal static bool downedCharcoolSnowman;
        public static Condition DownedCharcoolSnowman = new("ModConditions.downedCharcoolSnowman", () => downedCharcoolSnowman);
        internal static bool downedCosmicMenace;
        public static Condition DownedCosmicMenace = new("ModConditions.downedCosmicMenace", () => downedCosmicMenace);


        //UNIVERSE OF SWORDS
        internal static bool universeOfSwordsLoaded;
        internal static Mod universeOfSwordsMod;
        internal static bool downedEvilFlyingBlade;
        public static Condition DownedEvilFlyingBlade = new("ModConditions.downedEvilFlyingBlade", () => downedEvilFlyingBlade);


        //VALHALLA
        internal static bool valhallaLoaded;
        internal static Mod valhallaMod;
        //BOSSES
        internal static bool downedColossalCarnage;
        public static Condition DownedColossalCarnage = new("ModConditions.downedColossalCarnage", () => downedColossalCarnage);
        internal static bool downedYurnero;
        public static Condition DownedYurnero = new("ModConditions.downedYurnero", () => downedYurnero);


        //VERDANT
        internal static bool verdantLoaded;
        internal static Mod verdantMod;
        //BIOMES
        internal static bool beenToVerdant;
        public static Condition HasBeenToVerdant = new("ModConditions.beenToVerdant", () => beenToVerdant);


        //VITALITY
        internal static bool vitalityLoaded;
        internal static Mod vitalityMod;
        //BOSSES
        internal static bool downedStormCloud;
        public static Condition DownedStormCloud = new("ModConditions.downedStormCloud", () => downedStormCloud);
        internal static bool downedGrandAntlion;
        public static Condition DownedGrandAntlion = new("ModConditions.downedGrandAntlion", () => downedGrandAntlion);
        internal static bool downedGemstoneElemental;
        public static Condition DownedGemstoneElemental = new("ModConditions.downedGemstoneElemental", () => downedGemstoneElemental);
        internal static bool downedMoonlightDragonfly;
        public static Condition DownedMoonlightDragonfly = new("ModConditions.downedMoonlightDragonfly", () => downedMoonlightDragonfly);
        internal static bool downedDreadnaught;
        public static Condition DownedDreadnaught = new("ModConditions.downedDreadnaught", () => downedDreadnaught);
        internal static bool downedAnarchulesBeetle;
        public static Condition DownedAnarchulesBeetle = new("ModConditions.downedAnarchulesBeetle", () => downedAnarchulesBeetle);
        internal static bool downedChaosbringer;
        public static Condition DownedChaosbringer = new("ModConditions.downedChaosbringer", () => downedChaosbringer);
        internal static bool downedPaladinSpirit;
        public static Condition DownedPaladinSpirit = new("ModConditions.downedPaladinSpirit", () => downedPaladinSpirit);


        //WAYFAIR CONTENT
        internal static bool wayfairContentLoaded;
        internal static Mod wayfairContentMod;
        //BOSSES
        internal static bool downedManaflora;
        public static Condition DownedManaflora = new("ModConditions.downedManaflora", () => downedManaflora);
        #endregion
#pragma warning restore CA2211

        public override void Unload()
        {
            if (!aequusLoaded)
            {
                aequusMod = null;
            }
            if (!afkpetsLoaded)
            {
                afkpetsMod = null;
            }
            if (!amuletOfManyMinionsLoaded)
            {
                amuletOfManyMinionsMod = null;
            }
            if (!arbourLoaded)
            {
                arbourMod = null;
            }
            if (!assortedCrazyThingsLoaded)
            {
                assortedCrazyThingsMod = null;
            }
            if (!bombusApisLoaded)
            {
                bombusApisMod = null;
            }
            if (!buffariaLoaded)
            {
                buffariaMod = null;
            }
            if (!calamityLoaded)
            {
                calamityMod = null;
            }
            if (!calamityVanitiesLoaded)
            {
                calamityVanitiesMod = null;
            }
            if (!catalystLoaded)
            {
                catalystMod = null;
            }
            if (!clamityAddonLoaded)
            {
                clamityAddonMod = null;
            }
            if (!clickerClassLoaded)
            {
                clickerClassMod = null;
            }
            if (!confectionRebakedLoaded)
            {
                confectionRebakedMod = null;
            }
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!depthsLoaded)
            {
                depthsMod = null;
            }
            if (!dragonBallTerrariaLoaded)
            {
                dragonBallTerrariaMod = null;
            }
            if (!echoesOfTheAncientsLoaded)
            {
                echoesOfTheAncientsMod = null;
            }
            if (!edorbisLoaded)
            {
                edorbisMod = null;
            }
            if (!enchantedMoonsLoaded)
            {
                enchantedMoonsMod = null;
            }
            if (!exaltLoaded)
            {
                exaltMod = null;
            }
            if (!fargosMutantLoaded)
            {
                fargosMutantMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!fargosSoulsDLCLoaded)
            {
                fargosSoulsDLCMod = null;
            }
            if (!fracturesOfPenumbraLoaded)
            {
                fracturesOfPenumbraMod = null;
            }
            if (!furnitureFoodAndFunLoaded)
            {
                furnitureFoodAndFunMod = null;
            }
            if (!gameTerrariaLoaded)
            {
                gameTerrariaMod = null;
            }
            if (!gensokyoLoaded)
            {
                gensokyoMod = null;
            }
            if (!gerdsLabLoaded)
            {
                gerdsLabMod = null;
            }
            if (!heartbeatariaLoaded)
            {
                heartbeatariaMod = null;
            }
            if (!homewardJourneyLoaded)
            {
                homewardJourneyMod = null;
            }
            if (!huntOfTheOldGodLoaded)
            {
                huntOfTheOldGodMod = null;
            }
            if (!infernumLoaded)
            {
                infernumMod = null;
            }
            if (!magicStorageLoaded)
            {
                magicStorageMod = null;
            }
            if (!mechReworkLoaded)
            {
                mechReworkMod = null;
            }
            if (!metroidLoaded)
            {
                metroidMod = null;
            }
            if (!polaritiesLoaded)
            {
                polaritiesMod = null;
            }
            if (!qwertyLoaded)
            {
                qwertyMod = null;
            }
            if (!redemptionLoaded)
            {
                redemptionMod = null;
            }
            if (!reforgedLoaded)
            {
                reforgedMod = null;
            }
            if (!remnantsLoaded)
            {
                remnantsMod = null;
            }
            if (!secretsOfTheShadowsLoaded)
            {
                secretsOfTheShadowsMod = null;
            }
            if (!spiritLoaded)
            {
                spiritMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!starlightRiverLoaded)
            {
                starlightRiverMod = null;
            }
            if (!starsAboveLoaded)
            {
                starsAboveMod = null;
            }
            if (!stormsAdditionsLoaded)
            {
                stormsAdditionsMod = null;
            }
            if (!supernovaLoaded)
            {
                supernovaMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!traeLoaded)
            {
                traeMod = null;
            }
            if (!uhtricLoaded)
            {
                uhtricMod = null;
            }
            if (!universeOfSwordsLoaded)
            {
                universeOfSwordsMod = null;
            }
            if (!valhallaLoaded)
            {
                valhallaMod = null;
            }
            if (!verdantLoaded)
            {
                verdantMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
            if (!wayfairContentLoaded)
            {
                wayfairContentMod = null;
            }
        }

        public override void Load()
        {
            if (!aequusLoaded)
            {
                aequusMod = null;
            }
            if (!afkpetsLoaded)
            {
                afkpetsMod = null;
            }
            if (!amuletOfManyMinionsLoaded)
            {
                amuletOfManyMinionsMod = null;
            }
            if (!arbourLoaded)
            {
                arbourMod = null;
            }
            if (!assortedCrazyThingsLoaded)
            {
                assortedCrazyThingsMod = null;
            }
            if (!bombusApisLoaded)
            {
                bombusApisMod = null;
            }
            if (!buffariaLoaded)
            {
                buffariaMod = null;
            }
            if (!calamityLoaded)
            {
                calamityMod = null;
            }
            if (!calamityVanitiesLoaded)
            {
                calamityVanitiesMod = null;
            }
            if (!catalystLoaded)
            {
                catalystMod = null;
            }
            if (!clamityAddonLoaded)
            {
                clamityAddonMod = null;
            }
            if (!clickerClassLoaded)
            {
                clickerClassMod = null;
            }
            if (!confectionRebakedLoaded)
            {
                confectionRebakedMod = null;
            }
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!depthsLoaded)
            {
                depthsMod = null;
            }
            if (!dragonBallTerrariaLoaded)
            {
                dragonBallTerrariaMod = null;
            }
            if (!echoesOfTheAncientsLoaded)
            {
                echoesOfTheAncientsMod = null;
            }
            if (!edorbisLoaded)
            {
                edorbisMod = null;
            }
            if (!enchantedMoonsLoaded)
            {
                enchantedMoonsMod = null;
            }
            if (!exaltLoaded)
            {
                exaltMod = null;
            }
            if (!fargosMutantLoaded)
            {
                fargosMutantMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!fargosSoulsDLCLoaded)
            {
                fargosSoulsDLCMod = null;
            }
            if (!fracturesOfPenumbraLoaded)
            {
                fracturesOfPenumbraMod = null;
            }
            if (!furnitureFoodAndFunLoaded)
            {
                furnitureFoodAndFunMod = null;
            }
            if (!gameTerrariaLoaded)
            {
                gameTerrariaMod = null;
            }
            if (!gensokyoLoaded)
            {
                gensokyoMod = null;
            }
            if (!gerdsLabLoaded)
            {
                gerdsLabMod = null;
            }
            if (!heartbeatariaLoaded)
            {
                heartbeatariaMod = null;
            }
            if (!homewardJourneyLoaded)
            {
                homewardJourneyMod = null;
            }
            if (!huntOfTheOldGodLoaded)
            {
                huntOfTheOldGodMod = null;
            }
            if (!infernumLoaded)
            {
                infernumMod = null;
            }
            if (!magicStorageLoaded)
            {
                magicStorageMod = null;
            }
            if (!mechReworkLoaded)
            {
                mechReworkMod = null;
            }
            if (!metroidLoaded)
            {
                metroidMod = null;
            }
            if (!polaritiesLoaded)
            {
                polaritiesMod = null;
            }
            if (!qwertyLoaded)
            {
                qwertyMod = null;
            }
            if (!redemptionLoaded)
            {
                redemptionMod = null;
            }
            if (!reforgedLoaded)
            {
                reforgedMod = null;
            }
            if (!remnantsLoaded)
            {
                remnantsMod = null;
            }
            if (!secretsOfTheShadowsLoaded)
            {
                secretsOfTheShadowsMod = null;
            }
            if (!spiritLoaded)
            {
                spiritMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!starlightRiverLoaded)
            {
                starlightRiverMod = null;
            }
            if (!starsAboveLoaded)
            {
                starsAboveMod = null;
            }
            if (!stormsAdditionsLoaded)
            {
                stormsAdditionsMod = null;
            }
            if (!supernovaLoaded)
            {
                supernovaMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!traeLoaded)
            {
                traeMod = null;
            }
            if (!uhtricLoaded)
            {
                uhtricMod = null;
            }
            if (!universeOfSwordsLoaded)
            {
                universeOfSwordsMod = null;
            }
            if (!valhallaLoaded)
            {
                valhallaMod = null;
            }
            if (!verdantLoaded)
            {
                verdantMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
            if (!wayfairContentLoaded)
            {
                wayfairContentMod = null;
            }
        }

        public override void PostSetupContent()
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

            bombusApisLoaded = ModLoader.TryGetMod("BombusApisBee", out Mod BombusApisBee);
            bombusApisMod = BombusApisBee;

            buffariaLoaded = ModLoader.TryGetMod("Buffaria", out Mod Buffaria);
            buffariaMod = Buffaria;

            calamityLoaded = ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod);
            calamityMod = CalamityMod;

            calamityVanitiesLoaded = ModLoader.TryGetMod("CalValEX", out Mod CalValEX);
            calamityVanitiesMod = CalValEX;

            catalystLoaded = ModLoader.TryGetMod("CatalystMod", out Mod CatalystMod);
            catalystMod = CatalystMod;

            clamityAddonLoaded = ModLoader.TryGetMod("Clamity", out Mod Clamity);
            clamityAddonMod = Clamity;

            clickerClassLoaded = ModLoader.TryGetMod("ClickerClass", out Mod ClickerClass);
            clickerClassMod = ClickerClass;

            confectionRebakedLoaded = ModLoader.TryGetMod("TheConfectionRebirth", out Mod TheConfectionRebirth);
            confectionRebakedMod = TheConfectionRebirth;

            consolariaLoaded = ModLoader.TryGetMod("Consolaria", out Mod Consolaria);
            consolariaMod = Consolaria;

            depthsLoaded = ModLoader.TryGetMod("TheDepths", out Mod TheDepths);
            depthsMod = TheDepths;
            
            dragonBallTerrariaLoaded = ModLoader.TryGetMod("DBZMODPORT", out Mod DBZMODPORT);
            dragonBallTerrariaMod = DBZMODPORT;

            echoesOfTheAncientsLoaded = ModLoader.TryGetMod("EchoesoftheAncients", out Mod EchoesoftheAncients);
            echoesOfTheAncientsMod = EchoesoftheAncients;

            edorbisLoaded = ModLoader.TryGetMod("Edorbis", out Mod Edorbis);
            edorbisMod = Edorbis;

            enchantedMoonsLoaded = ModLoader.TryGetMod("BlueMoon", out Mod BlueMoon);
            enchantedMoonsMod = BlueMoon;

            exaltLoaded = ModLoader.TryGetMod("ExaltMod", out Mod ExaltMod);
            exaltMod = ExaltMod;

            fargosMutantLoaded = ModLoader.TryGetMod("Fargowiltas", out Mod Fargowiltas);
            fargosMutantMod = Fargowiltas;

            fargosSoulsLoaded = ModLoader.TryGetMod("FargowiltasSouls", out Mod FargowiltasSouls);
            fargosSoulsMod = FargowiltasSouls;

            fargosSoulsDLCLoaded = ModLoader.TryGetMod("FargowiltasSoulsDLC", out Mod FargowiltasSoulsDLC);
            fargosSoulsDLCMod = FargowiltasSoulsDLC;

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

            infernumLoaded = ModLoader.TryGetMod("InfernumMode", out Mod InfernumMode);
            infernumMod = InfernumMode;

            magicStorageLoaded = ModLoader.TryGetMod("MagicStorage", out Mod MagicStorage);
            magicStorageMod = MagicStorage;

            mechReworkLoaded = ModLoader.TryGetMod("PrimeRework", out Mod PrimeRework);
            mechReworkMod = PrimeRework;

            metroidLoaded = ModLoader.TryGetMod("MetroidMod", out Mod MetroidMod);
            metroidMod = MetroidMod;

            polaritiesLoaded = ModLoader.TryGetMod("Polarities", out Mod Polarities);
            polaritiesMod = Polarities;

            qwertyLoaded = ModLoader.TryGetMod("QwertyMod", out Mod QwertyMod);
            qwertyMod = QwertyMod;

            redemptionLoaded = ModLoader.TryGetMod("Redemption", out Mod Redemption);
            redemptionMod = Redemption;

            reforgedLoaded = ModLoader.TryGetMod("ReforgeOverhaul", out Mod ReforgeOverhaul);
            reforgedMod = ReforgeOverhaul;

            remnantsLoaded = ModLoader.TryGetMod("Remnants", out Mod Remnants);
            remnantsMod = Remnants;

            secretsOfTheShadowsLoaded = ModLoader.TryGetMod("SOTS", out Mod SOTS);
            secretsOfTheShadowsMod = SOTS;

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

            supernovaLoaded = ModLoader.TryGetMod("SupernovaMod", out Mod SupernovaMod);
            supernovaMod = SupernovaMod;

            terrorbornLoaded = ModLoader.TryGetMod("TerrorbornMod", out Mod TerrorbornMod);
            terrorbornMod = TerrorbornMod;

            thoriumLoaded = ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            thoriumMod = ThoriumMod;

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
        }

        public override void OnWorldLoad()
        {
            Resetdowned();
        }

        public override void OnWorldUnload()
        {
            Resetdowned();
        }

        public override void SaveWorldData(TagCompound tag)
        {
            //VANILLA
            //BOSSES
            tag.Add("downedDreadnautilus", downedDreadnautilus);
            tag.Add("downedMartianSaucer", downedMartianSaucer);
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

            //AEQUUS
            tag.Add("downedCrabson", downedCrabson);
            tag.Add("downedOmegaStarite", downedOmegaStarite);
            tag.Add("downedDustDevil", downedDustDevil);
            tag.Add("downedRedSprite", downedRedSprite);
            tag.Add("downedSpaceSquid", downedSpaceSquid);
            tag.Add("downedHyperStarite", downedHyperStarite);
            tag.Add("downedUltraStarite", downedUltraStarite);
            //EVENTS
            tag.Add("downedDemonSiege", downedDemonSiege);
            tag.Add("downedGlimmer", downedGlimmer);
            tag.Add("downedGaleStreams", downedGaleStreams);
            //BIOMES
            tag.Add("beenToCrabCrevice", beenToCrabCrevice);

            //AFKPETS
            tag.Add("downedSlayerOfEvil", downedSlayerOfEvil);
            tag.Add("downedSATLA", downedSATLA);
            tag.Add("downedDrFetus", downedDrFetus);
            tag.Add("downedSlimesHope", downedSlimesHope);
            tag.Add("downedPoliticianSlime", downedPoliticianSlime);
            tag.Add("downedAncientTrio", downedAncientTrio);
            tag.Add("downedLavalGolem", downedLavalGolem);
            //MINIBOSSES
            tag.Add("downedAntony", downedAntony);
            tag.Add("downedBunnyZeppelin", downedBunnyZeppelin);
            tag.Add("downedOkiku", downedOkiku);
            tag.Add("downedHarpyAirforce", downedHarpyAirforce);
            tag.Add("downedIsaac", downedIsaac);
            tag.Add("downedAncientGuardian", downedAncientGuardian);
            tag.Add("downedHeroicSlime", downedHeroicSlime);
            tag.Add("downedHoloSlime", downedHoloSlime);
            tag.Add("downedSecurityBot", downedSecurityBot);
            tag.Add("downedUndeadChef", downedUndeadChef);
            tag.Add("downedGuardianOfFrost", downedGuardianOfFrost);

            //ASSORTED CRAZY THINGS
            tag.Add("downedSoulHarvester", downedSoulHarvester);

            //CALAMITY
            tag.Add("downedDesertScourge", downedDesertScourge);
            tag.Add("downedCrabulon", downedCrabulon);
            tag.Add("downedHiveMind", downedHiveMind);
            tag.Add("downedPerforators", downedPerforators);
            tag.Add("downedSlimeGod", downedSlimeGod);
            tag.Add("downedCryogen", downedCryogen);
            tag.Add("downedAquaticScourge", downedAquaticScourge);
            tag.Add("downedBrimstoneElemental", downedBrimstoneElemental);
            tag.Add("downedCalamitasClone", downedCalamitasClone);
            tag.Add("downedLeviathanAndAnahita", downedLeviathanAndAnahita);
            tag.Add("downedAstrumAureus", downedAstrumAureus);
            tag.Add("downedPlaguebringerGoliath", downedPlaguebringerGoliath);
            tag.Add("downedRavager", downedRavager);
            tag.Add("downedAstrumDeus", downedAstrumDeus);
            tag.Add("downedProfanedGuardians", downedProfanedGuardians);
            tag.Add("downedDragonfolly", downedDragonfolly);
            tag.Add("downedProvidence", downedProvidence);
            tag.Add("downedStormWeaver", downedStormWeaver);
            tag.Add("downedCeaselessVoid", downedCeaselessVoid);
            tag.Add("downedSignus", downedSignus);
            tag.Add("downedPolterghast", downedPolterghast);
            tag.Add("downedOldDuke", downedOldDuke);
            tag.Add("downedDevourerOfGods", downedDevourerOfGods);
            tag.Add("downedYharon", downedYharon);
            tag.Add("downedExoMechs", downedExoMechs);
            tag.Add("downedSupremeCalamitas", downedSupremeCalamitas);
            //MINIBOSSES
            tag.Add("downedGiantClam", downedGiantClam);
            tag.Add("downedCragmawMire", downedCragmawMire);
            tag.Add("downedGreatSandShark", downedGreatSandShark);
            tag.Add("downedNuclearTerror", downedNuclearTerror);
            tag.Add("downedMauler", downedMauler);
            //EVENTS
            tag.Add("downedAcidRain1", downedAcidRain1);
            tag.Add("downedAcidRain2", downedAcidRain2);
            tag.Add("downedBossRush", downedBossRush);
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

            //CATALYST
            tag.Add("downedAstrageldon", downedAstrageldon);

            //CLAMITY
            tag.Add("downedClamitas", downedClamitas);

            //CONSOLARIA
            tag.Add("downedLepus", downedLepus);
            tag.Add("downedTurkor", downedTurkor);
            tag.Add("downedOcram", downedOcram);

            //ECHOES OF THE ANCIENTS
            tag.Add("downedGalahis", downedGalahis);
            tag.Add("downedCreation", downedCreation);
            tag.Add("downedDestruction", downedDestruction);

            //EXALT
            tag.Add("downedEffulgence", downedEffulgence);
            tag.Add("downedIceLich", downedIceLich);

            //FARGOS SOULS
            tag.Add("downedTrojanSquirrel", downedTrojanSquirrel);
            tag.Add("downedDeviantt", downedDeviantt);
            tag.Add("downedLieflight", downedLieflight);
            tag.Add("downedEridanus", downedEridanus);
            tag.Add("downedAbominationn", downedAbominationn);
            tag.Add("downedMutant", downedMutant);

            //FRACTURES OF PENUMBRA
            tag.Add("downedAlphaFrostjaw", downedAlphaFrostjaw);
            tag.Add("downedSanguineElemental", downedSanguineElemental);
            //BIOMES
            tag.Add("beenToDread", beenToDread);

            //GAMETERRARIA
            tag.Add("downedLad", downedLad);
            tag.Add("downedHornlitz", downedHornlitz);
            tag.Add("downedSnowDon", downedSnowDon);
            tag.Add("downedStoffie", downedStoffie);

            //GENSOKYO
            tag.Add("downedLilyWhite", downedLilyWhite);
            tag.Add("downedRumia", downedRumia);
            tag.Add("downedEternityLarva", downedEternityLarva);
            tag.Add("downedNazrin", downedNazrin);
            tag.Add("downedHinaKagiyama", downedHinaKagiyama);
            tag.Add("downedSekibanki", downedSekibanki);
            tag.Add("downedSeiran", downedSeiran);
            tag.Add("downedNitoriKawashiro", downedNitoriKawashiro);
            tag.Add("downedMedicineMelancholy", downedMedicineMelancholy);
            tag.Add("downedCirno", downedCirno);
            tag.Add("downedMinamitsuMurasa", downedMinamitsuMurasa);
            tag.Add("downedAliceMargatroid", downedAliceMargatroid);
            tag.Add("downedSakuyaIzayoi", downedSakuyaIzayoi);
            tag.Add("downedSeijaKijin", downedSeijaKijin);
            tag.Add("downedMayumiJoutouguu", downedMayumiJoutouguu);
            tag.Add("downedToyosatomimiNoMiko", downedToyosatomimiNoMiko);
            tag.Add("downedKaguyaHouraisan", downedKaguyaHouraisan);
            tag.Add("downedUtsuhoReiuji", downedUtsuhoReiuji);
            tag.Add("downedTenshiHinanawi", downedTenshiHinanawi);
            //MINIBOSSES
            tag.Add("downedKisume", downedKisume);

            //GMR
            tag.Add("downedTrerios", downedTrerios);
            tag.Add("downedMagmaEye", downedMagmaEye);
            tag.Add("downedJack", downedJack);
            tag.Add("downedAcheron", downedAcheron);

            //HOMEWARD JOURNEY
            tag.Add("downedMarquisMoonsquid", downedMarquisMoonsquid);
            tag.Add("downedPriestessRod", downedPriestessRod);
            tag.Add("downedDiver", downedDiver);
            tag.Add("downedMotherbrain", downedMotherbrain);
            tag.Add("downedWallOfShadow", downedWallOfShadow);
            tag.Add("downedSunSlimeGod", downedSunSlimeGod);
            tag.Add("downedOverwatcher", downedOverwatcher);
            tag.Add("downedLifebringer", downedLifebringer);
            tag.Add("downedMaterealizer", downedMaterealizer);
            tag.Add("downedScarabBelief", downedScarabBelief);
            tag.Add("downedWorldsEndWhale", downedWorldsEndWhale);
            tag.Add("downedSon", downedSon);
            //EVENTS
            tag.Add("downedCaveOrdeal", downedCaveOrdeal);
            tag.Add("downedCorruptOrdeal", downedCorruptOrdeal);
            tag.Add("downedCrimsonOrdeal", downedCrimsonOrdeal);
            tag.Add("downedDesertOrdeal", downedDesertOrdeal);
            tag.Add("downedForestOrdeal", downedForestOrdeal);
            tag.Add("downedHallowOrdeal", downedHallowOrdeal);
            tag.Add("downedJungleOrdeal", downedJungleOrdeal);
            tag.Add("downedSkyOrdeal", downedSkyOrdeal);
            tag.Add("downedSnowOrdeal", downedSnowOrdeal);
            tag.Add("downedUnderworldOrdeal", downedUnderworldOrdeal);
            //BIOMES
            tag.Add("beenToHomewardAbyss", beenToHomewardAbyss);

            //HUNT OF THE OLD GOD
            tag.Add("downedGoozma", downedGoozma);

            //INFERNUM
            tag.Add("downedBereftVassal", downedBereftVassal);
            //BIOMES
            tag.Add("beenToProfanedGardens", beenToProfanedGardens);

            //MECH REWORK
            tag.Add("downedSt4sys", downedSt4sys);
            tag.Add("downedTerminator", downedTerminator);
            tag.Add("downedCaretaker", downedCaretaker);
            tag.Add("downedSiegeEngine", downedSiegeEngine);

            //METROID
            tag.Add("downedTorizo", downedTorizo);
            tag.Add("downedSerris", downedSerris);
            tag.Add("downedKraid", downedKraid);
            tag.Add("downedPhantoon", downedPhantoon);
            tag.Add("downedOmegaPirate", downedOmegaPirate);
            tag.Add("downedNightmare", downedNightmare);
            tag.Add("downedGoldenTorizo", downedGoldenTorizo);

            //POLARITIES
            tag.Add("downedStormCloudfish", downedStormCloudfish);
            tag.Add("downedStarConstruct", downedStarConstruct);
            tag.Add("downedGigabat", downedGigabat);
            tag.Add("downedSunPixie", downedSunPixie);
            tag.Add("downedEsophage", downedEsophage);
            tag.Add("downedConvectiveWanderer", downedConvectiveWanderer);

            //QWERTY
            tag.Add("downedPolarExterminator", downedPolarExterminator);
            tag.Add("downedDivineLight", downedDivineLight);
            tag.Add("downedAncientMachine", downedAncientMachine);
            tag.Add("downedNoehtnap", downedNoehtnap);
            tag.Add("downedHydra", downedHydra);
            tag.Add("downedImperious", downedImperious);
            tag.Add("downedRuneGhost", downedRuneGhost);
            tag.Add("downedInvaderBattleship", downedInvaderBattleship);
            tag.Add("downedInvaderNoehtnap", downedInvaderNoehtnap);
            tag.Add("downedOLORD", downedOLORD);
            //MINIBOSSES
            tag.Add("downedGreatTyrannosaurus", downedGreatTyrannosaurus);
            //EVENTS
            tag.Add("downedDinoMilitia", downedDinoMilitia);
            tag.Add("downedInvaders", downedInvaders);
            //BIOMES
            tag.Add("beenToSkyFortress", beenToSkyFortress);

            //REDEMPTION
            tag.Add("downedFowlEmperor", downedFowlEmperor);
            tag.Add("downedThorn", downedThorn);
            tag.Add("downedErhan", downedErhan);
            tag.Add("downedKeeper", downedKeeper);
            tag.Add("downedSeedOfInfection", downedSeedOfInfection);
            tag.Add("downedKingSlayerIII", downedKingSlayerIII);
            tag.Add("downedOmegaCleaver", downedOmegaCleaver);
            tag.Add("downedOmegaGigapora", downedOmegaGigapora);
            tag.Add("downedOmegaObliterator", downedOmegaObliterator);
            tag.Add("downedPatientZero", downedPatientZero);
            tag.Add("downedAkka", downedAkka);
            tag.Add("downedUkko", downedUkko);
            tag.Add("downedAncientDeityDuo", downedAncientDeityDuo);
            tag.Add("downedNebuleus", downedNebuleus);
            //EVENTS
            tag.Add("downedFowlMorning", downedFowlMorning);
            tag.Add("downedRaveyard", downedRaveyard);
            //BIOMES
            tag.Add("beenToLab", beenToLab);
            tag.Add("beenToWasteland", beenToWasteland);

            //SOTS
            tag.Add("downedGlowmoth", downedGlowmoth);
            tag.Add("downedPutridPinky", downedPutridPinky);
            tag.Add("downedPharaohsCurse", downedPharaohsCurse);
            tag.Add("downedAdvisor", downedAdvisor);
            tag.Add("downedPolaris", downedPolaris);
            tag.Add("downedLux", downedLux);
            tag.Add("downedSubspaceSerpent", downedSubspaceSerpent);
            tag.Add("downedNatureConstruct", downedNatureConstruct);
            tag.Add("downedEarthenConstruct", downedEarthenConstruct);
            tag.Add("downedPermafrostConstruct", downedPermafrostConstruct);
            tag.Add("downedTidalConstruct", downedTidalConstruct);
            tag.Add("downedOtherworldlyConstruct", downedOtherworldlyConstruct);
            tag.Add("downedEvilConstruct", downedEvilConstruct);
            tag.Add("downedInfernoConstruct", downedInfernoConstruct);
            tag.Add("downedChaosConstruct", downedChaosConstruct);
            tag.Add("downedNatureSpirit", downedNatureSpirit);
            tag.Add("downedEarthenSpirit", downedEarthenSpirit);
            tag.Add("downedPermafrostSpirit", downedPermafrostSpirit);
            tag.Add("downedTidalSpirit", downedTidalSpirit);
            tag.Add("downedOtherworldlySpirit", downedOtherworldlySpirit);
            tag.Add("downedEvilSpirit", downedEvilSpirit);
            tag.Add("downedInfernoSpirit", downedInfernoSpirit);
            tag.Add("downedChaosSpirit", downedChaosSpirit);
            //BIOMES
            tag.Add("beenToPyramid", beenToPyramid);
            tag.Add("beenToPlanetarium", beenToPlanetarium);

            //SPIRIT
            tag.Add("downedScarabeus", downedScarabeus);
            tag.Add("downedMoonJellyWizard", downedMoonJellyWizard);
            tag.Add("downedVinewrathBane", downedVinewrathBane);
            tag.Add("downedAncientAvian", downedAncientAvian);
            tag.Add("downedStarplateVoyager", downedStarplateVoyager);
            tag.Add("downedInfernon", downedInfernon);
            tag.Add("downedDusking", downedDusking);
            tag.Add("downedAtlas", downedAtlas);
            //EVENTS
            tag.Add("downedJellyDeluge", downedJellyDeluge);
            tag.Add("downedTide", downedTide);
            tag.Add("downedMysticMoon", downedMysticMoon);
            //BIOMES
            tag.Add("beenToBriar", beenToBriar);
            tag.Add("beenToSpirit", beenToSpirit);

            //SPOOKY
            tag.Add("downedSpookySpirit", downedSpookySpirit);
            tag.Add("downedRotGourd", downedRotGourd);
            tag.Add("downedMoco", downedMoco);
            tag.Add("downedDaffodil", downedDaffodil);
            tag.Add("downedOrroBoro", downedOrroBoro);
            tag.Add("downedBigBone", downedBigBone);
            //BIOMES
            tag.Add("beenToSpookyForest", beenToSpookyForest);
            tag.Add("beenToSpookyUnderground", beenToSpookyUnderground);
            tag.Add("beenToEyeValley", beenToEyeValley);
            tag.Add("beenToCatacombs", beenToCatacombs);
            tag.Add("beenToCemetery", beenToCemetery);

            //STARLIGHT RIVER
            tag.Add("downedAuroracle", downedAuroracle);
            tag.Add("downedCeiros", downedCeiros);
            //MINIBOSSES
            tag.Add("downedGlassweaver", downedGlassweaver);
            //BIOMES
            tag.Add("beenToAuroracleTemple", beenToAuroracleTemple);
            tag.Add("beenToVitricDesert", beenToVitricDesert);
            tag.Add("beenToVitricTemple", beenToVitricTemple);

            //STARS ABOVE
            tag.Add("downedVagrantofSpace", downedVagrantofSpace);
            tag.Add("downedDioskouroi", downedDioskouroi);
            tag.Add("downedNalhaun", downedNalhaun);
            tag.Add("downedPenthesilea", downedPenthesilea);
            tag.Add("downedArbitration", downedArbitration);
            tag.Add("downedWarriorOfLight", downedWarriorOfLight);
            tag.Add("downedTsukiyomi", downedTsukiyomi);

            //STORM DIVERS MOD
            tag.Add("downedAncientHusk", downedAncientHusk);
            tag.Add("downedOverloadedScandrone", downedOverloadedScandrone);
            tag.Add("downedPainbringer", downedPainbringer);

            //SUPERNOVA
            tag.Add("downedHarbingerOfAnnihilation", downedHarbingerOfAnnihilation);
            tag.Add("downedFlyingTerror", downedFlyingTerror);
            tag.Add("downedStoneMantaRay", downedStoneMantaRay);

            //TERRORBORN
            tag.Add("downedInfectedIncarnate", downedInfectedIncarnate);
            tag.Add("downedTidalTitan", downedTidalTitan);
            tag.Add("downedDunestock", downedDunestock);
            tag.Add("downedShadowcrawler", downedShadowcrawler);
            tag.Add("downedHexedConstructor", downedHexedConstructor);
            tag.Add("downedPrototypeI", downedPrototypeI);

            //THORIUM
            tag.Add("downedGrandThunderBird", downedGrandThunderBird);
            tag.Add("downedQueenJellyfish", downedQueenJellyfish);
            tag.Add("downedViscount", downedViscount);
            tag.Add("downedGraniteEnergyStorm", downedGraniteEnergyStorm);
            tag.Add("downedBuriedChampion", downedBuriedChampion);
            tag.Add("downedBoreanStrider", downedBoreanStrider);
            tag.Add("downedFallenBeholder", downedFallenBeholder);
            tag.Add("downedLich", downedLich);
            tag.Add("downedForgottenOne", downedForgottenOne);
            tag.Add("downedPrimordials", downedPrimordials);
            tag.Add("downedPatchWerk", downedPatchWerk);
            tag.Add("downedCorpseBloom", downedCorpseBloom);
            tag.Add("downedIllusionist", downedIllusionist);
            //BIOMES
            tag.Add("beenToAquaticDepths", beenToAquaticDepths);

            //TRAE
            tag.Add("downedGraniteOvergrowth", downedGraniteOvergrowth);
            tag.Add("downedBeholder", downedBeholder);

            //UHTRIC
            tag.Add("downedDredger", downedDredger);
            tag.Add("downedCharcoolSnowman", downedCharcoolSnowman);
            tag.Add("downedCosmicMenace", downedCosmicMenace);

            //UNIVERSE OF SWORDS
            tag.Add("downedEvilFlyingBlade", downedEvilFlyingBlade);

            //VALHALLA
            tag.Add("downedColossalCarnage", downedColossalCarnage);
            tag.Add("downedYurnero", downedYurnero);

            //VERDANT
            tag.Add("beenToVerdant", beenToVerdant);

            //VITALITY
            tag.Add("downedStormCloud", downedStormCloud);
            tag.Add("downedGrandAntlion", downedGrandAntlion);
            tag.Add("downedGemstoneElemental", downedGemstoneElemental);
            tag.Add("downedMoonlightDragonfly", downedMoonlightDragonfly);
            tag.Add("downedDreadnaught", downedDreadnaught);
            tag.Add("downedAnarchulesBeetle", downedAnarchulesBeetle);
            tag.Add("downedChaosbringer", downedChaosbringer);
            tag.Add("downedPaladinSpirit", downedPaladinSpirit);

            //WAYFAIR
            tag.Add("downedManaflora", downedManaflora);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            //VANILLA
            //BOSSES
            downedDreadnautilus = tag.Get<bool>("downedDreadnautilus");
            downedMartianSaucer = tag.Get<bool>("downedMartianSaucer");
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

            //AEQUUS
            downedCrabson = tag.Get<bool>("downedCrabson");
            downedOmegaStarite = tag.Get<bool>("downedOmegaStarite");
            downedDustDevil = tag.Get<bool>("downedDustDevil");
            downedRedSprite = tag.Get<bool>("downedRedSprite");
            downedSpaceSquid = tag.Get<bool>("downedSpaceSquid");
            downedHyperStarite = tag.Get<bool>("downedHyperStarite");
            downedUltraStarite = tag.Get<bool>("downedUltraStarite");
            //EVENTS
            downedDemonSiege = tag.Get<bool>("downedDemonSiege");
            downedGlimmer = tag.Get<bool>("downedGlimmer");
            downedGaleStreams = tag.Get<bool>("downedGaleStreams");
            //BIOMES
            beenToCrabCrevice = tag.Get<bool>("beenToCrabCrevice");

            //AFKPETS
            downedSlayerOfEvil = tag.Get<bool>("downedSlayerOfEvil");
            downedSATLA = tag.Get<bool>("downedSATLA");
            downedDrFetus = tag.Get<bool>("downedDrFetus");
            downedSlimesHope = tag.Get<bool>("downedSlimesHope");
            downedPoliticianSlime = tag.Get<bool>("downedPoliticianSlime");
            downedAncientTrio = tag.Get<bool>("downedAncientTrio");
            downedLavalGolem = tag.Get<bool>("downedLavalGolem");
            //MINIBOSSES
            downedAntony = tag.Get<bool>("downedAntony");
            downedBunnyZeppelin = tag.Get<bool>("downedBunnyZeppelin");
            downedOkiku = tag.Get<bool>("downedOkiku");
            downedHarpyAirforce = tag.Get<bool>("downedHarpyAirforce");
            downedAncientGuardian = tag.Get<bool>("downedAncientGuardian");
            downedHeroicSlime = tag.Get<bool>("downedHeroicSlime");
            downedHoloSlime = tag.Get<bool>("downedHoloSlime");
            downedSecurityBot = tag.Get<bool>("downedSecurityBot");
            downedUndeadChef = tag.Get<bool>("downedUndeadChef");
            downedGuardianOfFrost = tag.Get<bool>("downedGuardianOfFrost");

            //ASSORTED CRAZY THINGS
            downedSoulHarvester = tag.Get<bool>("downedSoulHarvester");

            //CALAMITY
            downedDesertScourge = tag.Get<bool>("downedDesertScourge");
            downedCrabulon = tag.Get<bool>("downedCrabulon");
            downedHiveMind = tag.Get<bool>("downedHiveMind");
            downedPerforators = tag.Get<bool>("downedPerforators");
            downedSlimeGod = tag.Get<bool>("downedSlimeGod");
            downedCryogen = tag.Get<bool>("downedCryogen");
            downedAquaticScourge = tag.Get<bool>("downedAquaticScourge");
            downedBrimstoneElemental = tag.Get<bool>("downedBrimstoneElemental");
            downedCalamitasClone = tag.Get<bool>("downedCalamitasClone");
            downedLeviathanAndAnahita = tag.Get<bool>("downedLeviathanAndAnahita");
            downedAstrumAureus = tag.Get<bool>("downedAstrumAureus");
            downedPlaguebringerGoliath = tag.Get<bool>("downedPlaguebringerGoliath");
            downedRavager = tag.Get<bool>("downedRavager");
            downedAstrumDeus = tag.Get<bool>("downedAstrumDeus");
            downedProfanedGuardians = tag.Get<bool>("downedProfanedGuardians");
            downedDragonfolly = tag.Get<bool>("downedDragonfolly");
            downedProvidence = tag.Get<bool>("downedProvidence");
            downedStormWeaver = tag.Get<bool>("downedStormWeaver");
            downedCeaselessVoid = tag.Get<bool>("downedCeaselessVoid");
            downedSignus = tag.Get<bool>("downedSignus");
            downedPolterghast = tag.Get<bool>("downedPolterghast");
            downedOldDuke = tag.Get<bool>("downedOldDuke");
            downedDevourerOfGods = tag.Get<bool>("downedDevourerOfGods");
            downedYharon = tag.Get<bool>("downedYharon");
            downedExoMechs = tag.Get<bool>("downedExoMechs");
            downedSupremeCalamitas = tag.Get<bool>("downedSupremeCalamitas");
            //MINIBOSSES
            downedGiantClam = tag.Get<bool>("downedGiantClam");
            downedCragmawMire = tag.Get<bool>("downedCragmawMire");
            downedGreatSandShark = tag.Get<bool>("downedGreatSandShark");
            downedNuclearTerror = tag.Get<bool>("downedNuclearTerror");
            downedMauler = tag.Get<bool>("downedMauler");
            //EVENTS
            downedAcidRain1 = tag.Get<bool>("downedAcidRain1");
            downedAcidRain2 = tag.Get<bool>("downedAcidRain2");
            downedBossRush = tag.Get<bool>("downedBossRush");
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

            //CATALYST
            downedAstrageldon = tag.Get<bool>("downedAstrageldon");

            //CLAMITY
            downedClamitas = tag.Get<bool>("downedClamitas");

            //CONSOLARIA
            downedLepus = tag.Get<bool>("downedLepus");
            downedTurkor = tag.Get<bool>("downedTurkor");
            downedOcram = tag.Get<bool>("downedOcram");

            //ECHOES OF THE ANCIENTS
            downedGalahis = tag.Get<bool>("downedGalahis");
            downedCreation = tag.Get<bool>("downedCreation");
            downedDestruction = tag.Get<bool>("downedDestruction");

            //EXALT
            downedEffulgence = tag.Get<bool>("downedEffulgence");
            downedIceLich = tag.Get<bool>("downedIceLich");

            //FARGOS SOULS
            downedTrojanSquirrel = tag.Get<bool>("downedTrojanSquirrel");
            downedDeviantt = tag.Get<bool>("downedDeviantt");
            downedLieflight = tag.Get<bool>("downedLieflight");
            downedEridanus = tag.Get<bool>("downedEridanus");
            downedAbominationn = tag.Get<bool>("downedAbominationn");
            downedMutant = tag.Get<bool>("downedMutant");

            //FRACTURES OF PENUMBRA
            downedAlphaFrostjaw = tag.Get<bool>("downedAlphaFrostjaw");
            downedSanguineElemental = tag.Get<bool>("downedSanguineElemental");
            //BIOMES
            beenToDread = tag.Get<bool>("beenToDread");

            //GAMETERRARIA
            downedLad = tag.Get<bool>("downedLad");
            downedHornlitz = tag.Get<bool>("downedHornlitz");
            downedSnowDon = tag.Get<bool>("downedSnowDon");
            downedStoffie = tag.Get<bool>("downedStoffie");

            //GENSOKYO
            downedLilyWhite = tag.Get<bool>("downedLilyWhite");
            downedRumia = tag.Get<bool>("downedRumia");
            downedEternityLarva = tag.Get<bool>("downedEternityLarva");
            downedNazrin = tag.Get<bool>("downedNazrin");
            downedHinaKagiyama = tag.Get<bool>("downedHinaKagiyama");
            downedSekibanki = tag.Get<bool>("downedSekibanki");
            downedSeiran = tag.Get<bool>("downedSeiran");
            downedNitoriKawashiro = tag.Get<bool>("downedNitoriKawashiro");
            downedMedicineMelancholy = tag.Get<bool>("downedMedicineMelancholy");
            downedCirno = tag.Get<bool>("downedCirno");
            downedMinamitsuMurasa = tag.Get<bool>("downedMinamitsuMurasa");
            downedAliceMargatroid = tag.Get<bool>("downedAliceMargatroid");
            downedSakuyaIzayoi = tag.Get<bool>("downedSakuyaIzayoi");
            downedSeijaKijin = tag.Get<bool>("downedSeijaKijin");
            downedMayumiJoutouguu = tag.Get<bool>("downedMayumiJoutouguu");
            downedToyosatomimiNoMiko = tag.Get<bool>("downedToyosatomimiNoMiko");
            downedKaguyaHouraisan = tag.Get<bool>("downedKaguyaHouraisan");
            downedUtsuhoReiuji = tag.Get<bool>("downedUtsuhoReiuji");
            downedTenshiHinanawi = tag.Get<bool>("downedTenshiHinanawi");
            //MINIBOSSES
            downedKisume = tag.Get<bool>("downedKisume");

            //GMR
            downedTrerios = tag.Get<bool>("downedTrerios");
            downedMagmaEye = tag.Get<bool>("downedMagmaEye");
            downedJack = tag.Get<bool>("downedJack");
            downedAcheron = tag.Get<bool>("downedAcheron");

            //HOMEWARD JOURNEY
            downedMarquisMoonsquid = tag.Get<bool>("downedMarquisMoonsquid");
            downedPriestessRod = tag.Get<bool>("downedPriestessRod");
            downedDiver = tag.Get<bool>("downedDiver");
            downedMotherbrain = tag.Get<bool>("downedMotherbrain");
            downedWallOfShadow = tag.Get<bool>("downedWallOfShadow");
            downedSunSlimeGod = tag.Get<bool>("downedSunSlimeGod");
            downedOverwatcher = tag.Get<bool>("downedOverwatcher");
            downedLifebringer = tag.Get<bool>("downedLifebringer");
            downedMaterealizer = tag.Get<bool>("downedMaterealizer");
            downedScarabBelief = tag.Get<bool>("downedScarabBelief");
            downedWorldsEndWhale = tag.Get<bool>("downedWorldsEndWhale");
            downedSon = tag.Get<bool>("downedSon");
            //EVENTS
            downedCaveOrdeal = tag.Get<bool>("downedCaveOrdeal");
            downedCorruptOrdeal = tag.Get<bool>("downedCorruptOrdeal");
            downedCrimsonOrdeal = tag.Get<bool>("downedCrimsonOrdeal");
            downedDesertOrdeal = tag.Get<bool>("downedDesertOrdeal");
            downedForestOrdeal = tag.Get<bool>("downedForestOrdeal");
            downedHallowOrdeal = tag.Get<bool>("downedHallowOrdeal");
            downedJungleOrdeal = tag.Get<bool>("downedJungleOrdeal");
            downedSkyOrdeal = tag.Get<bool>("downedSkyOrdeal");
            downedSnowOrdeal = tag.Get<bool>("downedSnowOrdeal");
            downedUnderworldOrdeal = tag.Get<bool>("downedUnderworldOrdeal");
            //BIOMES
            beenToHomewardAbyss = tag.Get<bool>("beenToHomewardAbyss");

            //HUNT OF THE OLD GOD
            downedGoozma = tag.Get<bool>("downedGoozma");

            //INFERNUM
            downedBereftVassal = tag.Get<bool>("downedBereftVassal");
            //BIOMES
            beenToProfanedGardens = tag.Get<bool>("beenToProfanedGardens");

            //MECH REWORK
            downedSt4sys = tag.Get<bool>("downedSt4sys");
            downedTerminator = tag.Get<bool>("downedTerminator");
            downedCaretaker = tag.Get<bool>("downedCaretaker");
            downedSiegeEngine = tag.Get<bool>("downedSiegeEngine");

            //METROID
            downedTorizo = tag.Get<bool>("downedTorizo");
            downedSerris = tag.Get<bool>("downedSerris");
            downedKraid = tag.Get<bool>("downedKraid");
            downedPhantoon = tag.Get<bool>("downedPhantoon");
            downedOmegaPirate = tag.Get<bool>("downedOmegaPirate");
            downedNightmare = tag.Get<bool>("downedNightmare");
            downedGoldenTorizo = tag.Get<bool>("downedGoldenTorizo");

            //POLARITIES
            downedStormCloudfish = tag.Get<bool>("downedStormCloudfish");
            downedStarConstruct = tag.Get<bool>("downedStarConstruct");
            downedGigabat = tag.Get<bool>("downedGigabat");
            downedSunPixie = tag.Get<bool>("downedSunPixie");
            downedEsophage = tag.Get<bool>("downedEsophage");
            downedConvectiveWanderer = tag.Get<bool>("downedConvectiveWanderer");

            //QWERTY
            downedPolarExterminator = tag.Get<bool>("downedPolarExterminator");
            downedDivineLight = tag.Get<bool>("downedDivineLight");
            downedAncientMachine = tag.Get<bool>("downedAncientMachine");
            downedNoehtnap = tag.Get<bool>("downedNoehtnap");
            downedHydra = tag.Get<bool>("downedHydra");
            downedImperious = tag.Get<bool>("downedImperious");
            downedRuneGhost = tag.Get<bool>("downedRuneGhost");
            downedInvaderBattleship = tag.Get<bool>("downedInvaderBattleship");
            downedInvaderNoehtnap = tag.Get<bool>("downedInvaderNoehtnap");
            downedOLORD = tag.Get<bool>("downedOLORD");
            //MINIBOSSES
            downedGreatTyrannosaurus = tag.Get<bool>("downedGreatTyrannosaurus");
            //EVENTS
            downedDinoMilitia = tag.Get<bool>("downedDinoMilitia");
            downedInvaders = tag.Get<bool>("downedInvaders");
            //BIOMES
            beenToSkyFortress = tag.Get<bool>("beenToSkyFortress");

            //REDEMPTION
            downedFowlEmperor = tag.Get<bool>("downedFowlEmperor");
            downedThorn = tag.Get<bool>("downedThorn");
            downedErhan = tag.Get<bool>("downedErhan");
            downedKeeper = tag.Get<bool>("downedKeeper");
            downedSeedOfInfection = tag.Get<bool>("downedSeedOfInfection");
            downedKingSlayerIII = tag.Get<bool>("downedKingSlayerIII");
            downedOmegaCleaver = tag.Get<bool>("downedOmegaCleaver");
            downedOmegaGigapora = tag.Get<bool>("downedOmegaGigapora");
            downedOmegaObliterator = tag.Get<bool>("downedOmegaObliterator");
            downedPatientZero = tag.Get<bool>("downedPatientZero");
            downedAkka = tag.Get<bool>("downedAkka");
            downedUkko = tag.Get<bool>("downedUkko");
            downedAncientDeityDuo = tag.Get<bool>("downedAncientDeityDuo");
            downedNebuleus = tag.Get<bool>("downedNebuleus");
            //EVENTS
            downedFowlMorning = tag.Get<bool>("downedFowlMorning");
            downedRaveyard = tag.Get<bool>("downedRaveyard");
            //BIOMES
            beenToLab = tag.Get<bool>("beenToLab");
            beenToWasteland = tag.Get<bool>("beenToWasteland");

            //SOTS
            downedGlowmoth = tag.Get<bool>("downedGlowmoth");
            downedPutridPinky = tag.Get<bool>("downedPutridPinky");
            downedPharaohsCurse = tag.Get<bool>("downedPharaohsCurse");
            downedAdvisor = tag.Get<bool>("downedAdvisor");
            downedPolaris = tag.Get<bool>("downedPolaris");
            downedLux = tag.Get<bool>("downedLux");
            downedSubspaceSerpent = tag.Get<bool>("downedSubspaceSerpent");
            downedNatureConstruct = tag.Get<bool>("downedNatureConstruct");
            downedEarthenConstruct = tag.Get<bool>("downedEarthenConstruct");
            downedPermafrostConstruct = tag.Get<bool>("downedPermafrostConstruct");
            downedTidalConstruct = tag.Get<bool>("downedTidalConstruct");
            downedOtherworldlyConstruct = tag.Get<bool>("downedOtherworldlyConstruct");
            downedEvilConstruct = tag.Get<bool>("downedEvilConstruct");
            downedInfernoConstruct = tag.Get<bool>("downedInfernoConstruct");
            downedChaosConstruct = tag.Get<bool>("downedChaosConstruct");
            downedNatureSpirit = tag.Get<bool>("downedNatureSpirit");
            downedEarthenSpirit = tag.Get<bool>("downedEarthenSpirit");
            downedPermafrostSpirit = tag.Get<bool>("downedPermafrostSpirit");
            downedTidalSpirit = tag.Get<bool>("downedTidalSpirit");
            downedOtherworldlySpirit = tag.Get<bool>("downedOtherworldlySpirit");
            downedEvilSpirit = tag.Get<bool>("downedEvilSpirit");
            downedInfernoSpirit = tag.Get<bool>("downedInfernoSpirit");
            downedChaosSpirit = tag.Get<bool>("downedChaosSpirit");
            //BIOMES
            beenToPyramid = tag.Get<bool>("beenToPyramid");
            beenToPlanetarium = tag.Get<bool>("beenToPlanetarium");

            //SPIRIT
            downedScarabeus = tag.Get<bool>("downedScarabeus");
            downedMoonJellyWizard = tag.Get<bool>("downedMoonJellyWizard");
            downedVinewrathBane = tag.Get<bool>("downedVinewrathBane");
            downedAncientAvian = tag.Get<bool>("downedAncientAvian");
            downedStarplateVoyager = tag.Get<bool>("downedStarplateVoyager");
            downedInfernon = tag.Get<bool>("downedInfernon");
            downedDusking = tag.Get<bool>("downedDusking");
            downedAtlas = tag.Get<bool>("downedAtlas");
            //EVENTS
            downedJellyDeluge = tag.Get<bool>("downedJellyDeluge");
            downedTide = tag.Get<bool>("downedTide");
            downedMysticMoon = tag.Get<bool>("downedMysticMoon");
            //BIOMES
            beenToBriar = tag.Get<bool>("beenToBriar");
            beenToSpirit = tag.Get<bool>("beenToSpirit");

            //SPOOKY
            downedSpookySpirit = tag.Get<bool>("downedSpookySpirit");
            downedRotGourd = tag.Get<bool>("downedRotGourd");
            downedMoco = tag.Get<bool>("downedMoco");
            downedDaffodil = tag.Get<bool>("downedDaffodil");
            downedOrroBoro = tag.Get<bool>("downedOrroBoro");
            downedBigBone = tag.Get<bool>("downedBigBone");
            //BIOMES
            beenToSpookyForest = tag.Get<bool>("beenToSpookyForest");
            beenToSpookyUnderground = tag.Get<bool>("beenToSpookyUnderground");
            beenToEyeValley = tag.Get<bool>("beenToEyeValley");
            beenToCatacombs = tag.Get<bool>("beenToCatacombs");
            beenToCemetery = tag.Get<bool>("beenToCemetery");

            //STARLIGHT RIVER
            downedAuroracle = tag.Get<bool>("downedAuroracle");
            downedCeiros = tag.Get<bool>("downedCeiros");
            //MINIBOSSES
            downedGlassweaver = tag.Get<bool>("downedGlassweaver");
            //BIOMES
            beenToAuroracleTemple = tag.Get<bool>("beenToAuroracleTemple");
            beenToVitricDesert = tag.Get<bool>("beenToVitricDesert");
            beenToVitricTemple = tag.Get<bool>("beenToVitricTemple");

            //STARS ABOVE
            downedVagrantofSpace = tag.Get<bool>("downedVagrantofSpace");
            downedDioskouroi = tag.Get<bool>("downedDioskouroi");
            downedNalhaun = tag.Get<bool>("downedNalhaun");
            downedPenthesilea = tag.Get<bool>("downedPenthesilea");
            downedArbitration = tag.Get<bool>("downedArbitration");
            downedWarriorOfLight = tag.Get<bool>("downedWarriorOfLight");
            downedTsukiyomi = tag.Get<bool>("downedTsukiyomi");

            //STORM DIVERS MOD
            downedAncientHusk = tag.Get<bool>("downedAncientHusk");
            downedOverloadedScandrone = tag.Get<bool>("downedOverloadedScandrone");
            downedPainbringer = tag.Get<bool>("downedPainbringer");

            //SUPERNOVA
            downedHarbingerOfAnnihilation = tag.Get<bool>("downedHarbingerOfAnnihilation");
            downedFlyingTerror = tag.Get<bool>("downedFlyingTerror");
            downedStoneMantaRay = tag.Get<bool>("downedStoneMantaRay");

            //TERRORBORN
            downedInfectedIncarnate = tag.Get<bool>("downedInfectedIncarnate");
            downedTidalTitan = tag.Get<bool>("downedTidalTitan");
            downedDunestock = tag.Get<bool>("downedDunestock");
            downedShadowcrawler = tag.Get<bool>("downedShadowcrawler");
            downedHexedConstructor = tag.Get<bool>("downedHexedConstructor");
            downedPrototypeI = tag.Get<bool>("downedPrototypeI");

            //THORIUM
            downedGrandThunderBird = tag.Get<bool>("downedGrandThunderBird");
            downedQueenJellyfish = tag.Get<bool>("downedQueenJellyfish");
            downedViscount = tag.Get<bool>("downedViscount");
            downedGraniteEnergyStorm = tag.Get<bool>("downedGraniteEnergyStorm");
            downedBuriedChampion = tag.Get<bool>("downedBuriedChampion");
            downedBoreanStrider = tag.Get<bool>("downedBoreanStrider");
            downedFallenBeholder = tag.Get<bool>("downedFallenBeholder");
            downedLich = tag.Get<bool>("downedLich");
            downedForgottenOne = tag.Get<bool>("downedForgottenOne");
            downedPrimordials = tag.Get<bool>("downedPrimordials");
            downedPatchWerk = tag.Get<bool>("downedPatchWerk");
            downedCorpseBloom = tag.Get<bool>("downedCorpseBloom");
            downedIllusionist = tag.Get<bool>("downedIllusionist");
            //BIOMES
            beenToAquaticDepths = tag.Get<bool>("beenToAquaticDepths");

            //TRAE
            downedGraniteOvergrowth = tag.Get<bool>("downedGraniteOvergrowth");
            downedBeholder = tag.Get<bool>("downedBeholder");

            //UHTRIC
            downedDredger = tag.Get<bool>("downedDredger");
            downedCharcoolSnowman = tag.Get<bool>("downedCharcoolSnowman");
            downedCosmicMenace = tag.Get<bool>("downedCosmicMenace");

            //UNIVERSE OF SWORDS
            downedEvilFlyingBlade = tag.Get<bool>("downedEvilFlyingBlade");

            //VALHALLA
            downedColossalCarnage = tag.Get<bool>("downedColossalCarnage");
            downedYurnero = tag.Get<bool>("downedYurnero");

            //VERDANT
            beenToVerdant = tag.Get<bool>("beenToVerdant");

            //VITALITY
            downedStormCloud = tag.Get<bool>("downedStormCloud");
            downedGrandAntlion = tag.Get<bool>("downedGrandAntlion");
            downedGemstoneElemental = tag.Get<bool>("downedGemstoneElemental");
            downedMoonlightDragonfly = tag.Get<bool>("downedMoonlightDragonfly");
            downedDreadnaught = tag.Get<bool>("downedDreadnaught");
            downedAnarchulesBeetle = tag.Get<bool>("downedAnarchulesBeetle");
            downedChaosbringer = tag.Get<bool>("downedChaosbringer");
            downedPaladinSpirit = tag.Get<bool>("downedPaladinSpirit");

            //WAYFAIR
            downedManaflora = tag.Get<bool>("downedManaflora");
        }

        public override void PreUpdatePlayers()
        {
            #region Vanilla Events
            if (Main.bloodMoon)
            {
                downedBloodMoon = true;
            }
            if (Main.eclipse)
            {
                downedEclipse = true;
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
                downedCrabson = (bool)aequusMod.Call("downedCrabson", Mod);
                downedOmegaStarite = (bool)aequusMod.Call("downedOmegaStarite", Mod);
                downedDustDevil = (bool)aequusMod.Call("downedDustDevil", Mod);
                downedRedSprite = (bool)aequusMod.Call("downedRedSprite", Mod);
                downedSpaceSquid = (bool)aequusMod.Call("downedSpaceSquid", Mod);
                downedHyperStarite = (bool)aequusMod.Call("downedHyperStarite", Mod);
                downedUltraStarite = (bool)aequusMod.Call("downedUltraStarite", Mod);
                downedDemonSiege = (bool)aequusMod.Call("downedEventDemon", Mod);
                downedGlimmer = (bool)aequusMod.Call("downedEventCosmic", Mod);
                downedGaleStreams = (bool)aequusMod.Call("downedEventAtmosphere", Mod);
                #endregion
            }

            if (calamityLoaded)
            {
                #region Bosses & Events
                downedDesertScourge = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "DesertScourge"
                });
                downedCrabulon = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Crabulon"
                });
                downedHiveMind = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "HiveMind"
                });
                downedPerforators = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Perforator"
                });
                downedSlimeGod = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "SlimeGod"
                });
                downedCryogen = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Cryogen"
                });
                downedAquaticScourge = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "AquaticScourge"
                });
                downedBrimstoneElemental = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "BrimstoneElemental"
                });
                downedCalamitasClone = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "CalamitasClone"
                });
                downedLeviathanAndAnahita = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "AnahitaLeviathan"
                });
                downedAstrumAureus = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "AstrumAureus"
                });
                downedPlaguebringerGoliath = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "PlaguebringerGoliath"
                });
                downedRavager = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Ravager"
                });
                downedAstrumDeus = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "AstrumDeus"
                });
                downedProfanedGuardians = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Guardians"
                });
                downedDragonfolly = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Dragonfolly"
                });
                downedProvidence = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Providence"
                });
                downedStormWeaver = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "StormWeaver"
                });
                downedCeaselessVoid = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "CeaselessVoid"
                });
                downedSignus = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Signus"
                });
                downedPolterghast = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Polterghast"
                });
                downedOldDuke = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "OldDuke"
                });
                downedDevourerOfGods = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "DevourerOfGods"
                });
                downedYharon = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Yharon"
                });
                downedExoMechs = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "ExoMechs"
                });
                downedSupremeCalamitas = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "SupremeCalamitas"
                });
                downedGiantClam = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "GiantClam"
                });
                downedGreatSandShark = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "GreatSandShark"
                });
                downedAcidRain1 = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "acidraineoc"
                });
                downedAcidRain2 = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "acidrainscourge"
                });
                downedBossRush = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "bossrush"
                });
                #endregion

                #region Biomes
                if ((calamityMod.TryFind("AbovegroundAstralBiome", out ModBiome AbovegroundAstralBiome) && Main.LocalPlayer.InModBiome(AbovegroundAstralBiome)) 
                    || (calamityMod.TryFind("AbovegroundAstralBiomeSurface", out ModBiome AbovegroundAstralBiomeSurface) && Main.LocalPlayer.InModBiome(AbovegroundAstralBiomeSurface))
                    || (calamityMod.TryFind("AbovegroundAstralDesertBiome", out ModBiome AbovegroundAstralDesertBiome) && Main.LocalPlayer.InModBiome(AbovegroundAstralDesertBiome))
                    || (calamityMod.TryFind("AbovegroundAstralSnowBiome", out ModBiome AbovegroundAstralSnowBiome) && Main.LocalPlayer.InModBiome(AbovegroundAstralSnowBiome))
                    || (calamityMod.TryFind("UndergroundAstralBiome", out ModBiome UndergroundAstralBiome) && Main.LocalPlayer.InModBiome(UndergroundAstralBiome)))
                {
                    beenToAstral = true;
                }
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
                {
                    beenToCrags = true;
                }
                if (calamityMod.TryFind("SulphurousSeaBiome", out ModBiome SulphurousSeaBiome) && Main.LocalPlayer.InModBiome(SulphurousSeaBiome))
                {
                    beenToSulphurSea = true;
                }
                if (calamityMod.TryFind("SunkenSeaBiome", out ModBiome SunkenSeaBiome) && Main.LocalPlayer.InModBiome(SunkenSeaBiome))
                {
                    beenToSunkenSea = true;
                }
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
                if (downedAkka && downedUkko)
                {
                    downedAncientDeityDuo = true;
                }
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
                if (downedAdvisor)
                {
                    downedOtherworldlySpirit = true;
                }
                if (downedLux)
                {
                    downedChaosSpirit = true;
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
                if (spookyMod.TryFind("CatacombBiome", out ModBiome CatacombBiome) && Main.LocalPlayer.InModBiome(CatacombBiome))
                {
                    beenToCatacombs = true;
                }
                if (spookyMod.TryFind("CemeteryBiome", out ModBiome CemeteryBiome) && Main.LocalPlayer.InModBiome(CemeteryBiome))
                {
                    beenToCemetery = true;
                }
                if (downedOrro && downedBoro)
                {
                    downedOrroBoro = true;
                }
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
                downedDioskouroi = (bool)starsAboveMod.Call("downedDioskouroi", Mod);
                downedNalhaun = (bool)starsAboveMod.Call("downedNalhaun", Mod);
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

                if (thoriumMod.TryFind("DepthsBiome", out ModBiome DepthsBiome) && Main.LocalPlayer.InModBiome(DepthsBiome))
                {
                    beenToAquaticDepths = true;
                }
            }

            if (verdantLoaded)
            {
                if (verdantMod.TryFind("VerdantBiome", out ModBiome VerdantBiome) && Main.LocalPlayer.InModBiome(VerdantBiome))
                {
                    beenToVerdant = true;
                }
            }
        }

        public static void Resetdowned()
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

            //CALAMITY VANITIES
            beenToAstralBlight = false;

            //CATALYST
            downedAstrageldon = false;

            //CLAMITY
            downedClamitas = false;

            //CONFECTION
            beenToConfection = false;

            //CONSOLARIA
            downedLepus = false;
            downedTurkor = false;
            downedOcram = false;

            //DEPTHS
            beenToDepths = false;

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

            //EXALT
            downedEffulgence = false;
            downedIceLich = false;

            //FARGOS SOULS
            downedTrojanSquirrel = false;
            downedDeviantt = false;
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

            //MECH REWORK
            downedSt4sys = false;
            downedTerminator = false;
            downedCaretaker = false;
            downedSiegeEngine = false;

            //METROID
            downedTorizo = false;
            downedSerris = false;
            downedKraid = false;
            downedPhantoon = false;
            downedOmegaPirate = false;
            downedNightmare = false;
            downedGoldenTorizo = false;

            //POLARITIES
            downedStormCloudfish = false;
            downedStarConstruct = false;
            downedGigabat = false;
            downedSunPixie = false;
            downedEsophage = false;
            downedConvectiveWanderer = false;

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
            downedFowlEmperor = false;
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
            downedDioskouroi = false;
            downedNalhaun = false;
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
            downedAnarchulesBeetle = false;
            downedChaosbringer = false;
            downedPaladinSpirit = false;

            //WAYFAIR
            downedPaladinSpirit = false;
        }
    }
}