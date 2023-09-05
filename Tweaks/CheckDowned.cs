using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Tweaks
{
    public class CheckDowned : ModSystem
    {
        #pragma warning disable CA2211
        #region Bools & Conditions
        //VANILLA
        public static Condition expertOrMaster = new("CheckDowned.inExpertOrMaster", () => Main.expertMode || Main.masterMode);
        //EVENTS
        internal static bool downedBloodMoon;
        public static Condition bloodMoon = new("CheckDowned.downedBloodMoon", () => downedBloodMoon);
        internal static bool downedEclipse;
        public static Condition eclipse = new("CheckDowned.downedEclipse", () => downedEclipse);
        //BIOMES
        internal static bool beenToPurity;
        public static Condition hasBeenToPurity = new("CheckDowned.beenToPurity", () => beenToPurity);
        internal static bool beenToCavernsOrUnderground;
        public static Condition hasBeenToCavernsOrUnderground = new("CheckDowned.beenToCavernsOrUnderground", () => beenToCavernsOrUnderground);
        internal static bool beenToUnderworld;
        public static Condition hasBeenToUnderworld = new("CheckDowned.beenToUnderworld", () => beenToUnderworld);
        internal static bool beenToSky;
        public static Condition hasBeenToSky = new("CheckDowned.beenToSky", () => beenToSky);
        internal static bool beenToSnow;
        public static Condition hasBeenToSnow = new("CheckDowned.beenToSnow", () => beenToSnow);
        internal static bool beenToDesert;
        public static Condition hasBeenToDesert = new("CheckDowned.beenToDesert", () => beenToDesert);
        internal static bool beenToOcean;
        public static Condition hasBeenToOcean = new("CheckDowned.beenToOcean", () => beenToOcean);
        internal static bool beenToJungle;
        public static Condition hasBeenToJungle = new("CheckDowned.beenToJungle", () => beenToJungle);
        internal static bool beenToMushroom;
        public static Condition hasBeenToMushroom = new("CheckDowned.beenToMushroom", () => beenToMushroom);
        internal static bool beenToCorruption;
        public static Condition hasBeenToCorruption = new("CheckDowned.beenToCorruption", () => beenToCorruption);
        internal static bool beenToCrimson;
        public static Condition hasBeenToCrimson = new("CheckDowned.beenToCrimson", () => beenToCrimson);
        public static Condition hasBeenToEvil = new("CheckDowned.beenToEvil", () => beenToCorruption || beenToCrimson);
        internal static bool beenToHallow;
        public static Condition hasBeenToHallow = new("CheckDowned.beenToDesert", () => beenToHallow);
        internal static bool beenToTemple;
        public static Condition hasBeenToTemple = new("CheckDowned.beenToTemple", () => beenToTemple);
        internal static bool beenToDungeon;
        public static Condition hasBeenToDungeon = new("CheckDowned.beenToDungeon", () => beenToDungeon);


        //AEQUUS
        internal static bool aqLoaded;
        internal static Mod aqMod;
        internal static bool downedCrabson;
        public static Condition crabson = new("CheckDowned.downedCrabson", () => downedCrabson);
        internal static bool downedOmegaStarite;
        public static Condition omegastarite = new("CheckDowned.downedStarite", () => downedOmegaStarite);
        internal static bool downedDevil;
        public static Condition devil = new("CheckDowned.downedDevil", () => downedDevil);
        internal static bool downedSprite;
        public static Condition sprite = new("CheckDowned.downedSprite", () => downedSprite);
        internal static bool downedSpaceSquid;
        public static Condition spacesquid = new("CheckDowned.downedSpaceSquid", () => downedSpaceSquid);
        internal static bool downedHyperStarite;
        public static Condition hyperStarite = new("CheckDowned.downedHyperStarite", () => downedHyperStarite);
        internal static bool downedUltraStarite;
        public static Condition ultrastarite = new("CheckDowned.downedUltraStarite", () => downedUltraStarite);
        //EVENTS
        internal static bool downedDemonSiege;
        public static Condition demonSiege = new("CheckDowned.downedDemonSiege", () => downedDemonSiege);
        internal static bool downedGlimmer;
        public static Condition glimmer = new("CheckDowned.downedGlimmer", () => downedGlimmer);
        internal static bool downedGaleStreams;
        public static Condition galeStreams = new("CheckDowned.downedGaleStreams", () => downedGaleStreams);


        //ARBOUR
        internal static bool arbourLoaded;
        internal static Mod arbourMod;


        //CALAMITY
        internal static bool calamityLoaded;
        internal static Mod calamityMod;
        internal static bool downedDesertScourge;
        public static Condition desertscourge = new("CheckDowned.downedDesertScourge", () => downedDesertScourge);
        internal static bool downedCrabulon;
        public static Condition crabulon = new("CheckDowned.downedCrabulon", () => downedCrabulon);
        internal static bool downedHiveMind;
        public static Condition hivemind = new("CheckDowned.downedHiveMind", () => downedHiveMind);
        internal static bool downedPerforators;
        public static Condition perforators = new("CheckDowned.downedPerforators", () => downedPerforators);
        public static Condition perfOrHive = new("CheckDowned.downedPerfOrHive", () => downedPerforators || downedHiveMind);
        internal static bool downedSlimeGod;
        public static Condition slimegod = new("CheckDowned.downedSlimeGod", () => downedSlimeGod);
        internal static bool downedCryogen;
        public static Condition cryogen = new("CheckDowned.downedCryogen", () => downedCryogen);
        internal static bool downedAquaticScourge;
        public static Condition aquaticscourge = new("CheckDowned.downedAquaticScourge", () => downedAquaticScourge);
        internal static bool downedBrimstoneElemental;
        public static Condition brimstoneelemental = new("CheckDowned.downedBrimstoneElemental", () => downedBrimstoneElemental);
        internal static bool downedCalamitas;
        public static Condition calamitas = new("CheckDowned.downedCalamitas", () => downedCalamitas);
        internal static bool downedLeviathan;
        public static Condition leviathan = new("CheckDowned.downedLeviathan", () => downedLeviathan);
        internal static bool downedAureus;
        public static Condition aureus = new("CheckDowned.downedAureus", () => downedAureus);
        internal static bool downedPlaguebringer;
        public static Condition plaguebringer = new("CheckDowned.downedPlaguebringer", () => downedPlaguebringer);
        internal static bool downedRavager;
        public static Condition ravager = new("CheckDowned.downedRavager", () => downedRavager);
        internal static bool downedDeus;
        public static Condition deus = new("CheckDowned.downedDeus", () => downedDeus);
        internal static bool downedProfanedGuardians;
        public static Condition profguardians = new("CheckDowned.downedProfanedGuardians", () => downedProfanedGuardians);
        internal static bool downedDragonfolly;
        public static Condition dragonfolly = new("CheckDowned.downedDragonfolly", () => downedDragonfolly);
        internal static bool downedProvidence;
        public static Condition providence = new("CheckDowned.downedProvidence", () => downedProvidence);
        internal static bool downedStormWeaver;
        public static Condition stormweaver = new("CheckDowned.downedStormWeaver", () => downedStormWeaver);
        internal static bool downedCeaselessVoid;
        public static Condition ceaselessvoid = new("CheckDowned.downedCeaselessVoid", () => downedCeaselessVoid);
        internal static bool downedSignus;
        public static Condition signus = new("CheckDowned.downedSignus", () => downedSignus);
        internal static bool downedPolterghast;
        public static Condition polterghast = new("CheckDowned.downedPolterghast", () => downedPolterghast);
        internal static bool downedOldDuke;
        public static Condition oldduke = new("CheckDowned.downedOldDuke", () => downedOldDuke);
        internal static bool downedDevourerOfGods;
        public static Condition dog = new("CheckDowned.downedDevourerOfGods", () => downedDevourerOfGods);
        internal static bool downedYharon;
        public static Condition yharon = new("CheckDowned.downedYharon", () => downedYharon);
        internal static bool downedExoMechs;
        public static Condition exomechs = new("CheckDowned.downedExoMechs", () => downedExoMechs);
        internal static bool downedSupremeCalamitas;
        public static Condition scalamitas = new("CheckDowned.downedSupremeCalamitas", () => downedSupremeCalamitas);
        internal static bool downedGiantClam;
        public static Condition giantclam = new("CheckDowned.downedGiantClam", () => downedGiantClam);
        internal static bool downedGreatSandShark;
        public static Condition sandshark = new("CheckDowned.downedGreatSandShark", () => downedGreatSandShark);
        internal static bool downedCragmawMire;
        public static Condition cragmaw = new("CheckDowned.downedCragmawMire", () => downedCragmawMire);
        internal static bool downedNuclearTerror;
        public static Condition nuclearterror = new("CheckDowned.downedNuclearTerror", () => downedNuclearTerror);
        internal static bool downedMauler;
        public static Condition mauler = new("CheckDowned.downedMauler", () => downedMauler);
        //EVENTS
        internal static bool downedAcidRain1;
        public static Condition acidRain1 = new("CheckDowned.downedAcidRain1", () => downedAcidRain1);
        internal static bool downedAcidRain2;
        public static Condition acidRain2 = new("CheckDowned.downedAcidRain2", () => downedAcidRain2);
        internal static bool downedBossRush;
        public static Condition bossRush = new("CheckDowned.downedBossRush", () => downedBossRush);
        //BIOMES
        internal static bool beenToCrags;
        public static Condition hasBeenToCrags = new("CheckDowned.beenToCrags", () => beenToCrags);
        internal static bool beenToAstral;
        public static Condition hasBeenToAstral = new("CheckDowned.beenToAstral", () => beenToAstral);
        internal static bool beenToSunkenSea;
        public static Condition hasBeenToSunkenSea = new("CheckDowned.beenToSunkenSea", () => beenToSunkenSea);
        internal static bool beenToSulphurSea;
        public static Condition hasBeenToSulphurSea = new("CheckDowned.beenToSulphurSea", () => beenToSulphurSea);
        internal static bool beenToAbyss;
        public static Condition hasBeenToAbyss = new("CheckDowned.beenToAbyss", () => beenToAbyss);
        internal static bool beenToAbyssLayer1;
        public static Condition hasBeenToAbyssLayer1 = new("CheckDowned.beenToAbyssLayer1", () => beenToAbyssLayer1);
        internal static bool beenToAbyssLayer2;
        public static Condition hasBeenToAbyssLayer2 = new("CheckDowned.beenToAbyssLayer2", () => beenToAbyssLayer2);
        internal static bool beenToAbyssLayer3;
        public static Condition hasBeenToAbyssLayer3 = new("CheckDowned.beenToAbyssLayer3", () => beenToAbyssLayer3);
        internal static bool beenToAbyssLayer4;
        public static Condition hasBeenToAbyssLayer4 = new("CheckDowned.beenToAbyssLayer4", () => beenToAbyssLayer4);


        //CALAMITY VANITIES
        internal static bool calamityVanitiesLoaded;
        internal static Mod calamityVanitiesMod;


        //CATALYST
        internal static bool catalystLoaded;
        internal static Mod catalystMod;
        internal static bool downedGeldon;
        public static Condition geldon = new("CheckDowned.downedGeldon", () => downedGeldon);


        //CONSOLARIA
        internal static bool consolariaLoaded;
        internal static Mod consolariaMod;
        internal static bool downedLepus;
        public static Condition lepus = new("CheckDowned.downedLepus", () => downedLepus);
        internal static bool downedTurkor;
        public static Condition turkor = new("CheckDowned.downedTurkor", () => downedTurkor);
        internal static bool downedOcram;
        public static Condition ocram = new("CheckDowned.downedOcram", () => downedOcram);


        //ECHOES OF THE ANCIENTS
        internal static bool echoesLoaded;
        internal static Mod echoesMod;
        internal static bool downedGalahis;
        public static Condition galahis = new("CheckDowned.downedGalahis", () => downedGalahis);
        internal static bool downedCreation;
        public static Condition creation = new("CheckDowned.downedCreation", () => downedCreation);
        internal static bool downedDestruction;
        public static Condition destruction = new("CheckDowned.downedDestruction", () => downedDestruction);


        //EXALT
        internal static bool exaltLoaded;
        internal static Mod exaltMod;
        internal static bool downedEffulgence;
        public static Condition effulgence = new("CheckDowned.downedEffulgence", () => downedEffulgence);
        internal static bool downedIceLich;
        public static Condition iceLich = new("CheckDowned.downedIceLich", () => downedIceLich);


        //FARGOS SOULS
        internal static bool fargosSoulsLoaded;
        internal static Mod fargosSoulsMod;
        internal static bool fargosLoaded;
        internal static Mod fargosMod;
        internal static bool downedTrojanSquirrel;
        public static Condition squirrel = new("CheckDowned.downedTrojanSquirrel", () => downedTrojanSquirrel);
        internal static bool downedDeviant;
        public static Condition devi = new("CheckDowned.downedDeviant", () => downedDeviant);
        internal static bool downedLieflight;
        public static Condition lieflight = new("CheckDowned.downedLieflight", () => downedLieflight);
        internal static bool downedCosmosChampion;
        public static Condition cosmoschamp = new("CheckDowned.downedCosmosChampion", () => downedCosmosChampion);
        internal static bool downedAbomination;
        public static Condition abom = new("CheckDowned.downedAbomination", () => downedAbomination);
        internal static bool downedMutant;
        public static Condition mutant = new("CheckDowned.downedMutant", () => downedMutant);


        //GMR
        internal static bool gmrLoaded;
        internal static Mod gmrMod;
        internal static bool downedTrerios;
        public static Condition trerios = new("CheckDowned.downedTrerios", () => downedTrerios);
        internal static bool downedMagmaEye;
        public static Condition magmaEye = new("CheckDowned.downedMagmaEye", () => downedMagmaEye);
        internal static bool downedJack;
        public static Condition jack = new("CheckDowned.downedJack", () => downedJack);
        internal static bool downedAcheron;
        public static Condition acheron = new("CheckDowned.downedAcheron", () => downedAcheron);


        //HOMEWARD JOURNEY
        internal static bool homewardLoaded;
        internal static Mod homewardMod;
        internal static bool downedSquid;
        public static Condition squid = new("CheckDowned.downedSquid", () => downedSquid);
        internal static bool downedRod;
        public static Condition rod = new("CheckDowned.downedRod", () => downedRod);
        internal static bool downedDiver;
        public static Condition diver = new("CheckDowned.downedDiver", () => downedDiver);
        internal static bool downedMotherbrain;
        public static Condition motherbrain = new("CheckDowned.downedMotherbrain", () => downedMotherbrain);
        internal static bool downedWoS;
        public static Condition wos = new("CheckDowned.downedWoS", () => downedWoS);
        internal static bool downedSGod;
        public static Condition sgod = new("CheckDowned.downedSGod", () => downedSGod);
        internal static bool downedOverwatcher;
        public static Condition overwatcher = new("CheckDowned.downedOverwatcher", () => downedOverwatcher);
        internal static bool downedLifebringer;
        public static Condition lifebringer = new("CheckDowned.downedLifebringer", () => downedLifebringer);
        internal static bool downedMaterealizer;
        public static Condition materealizer = new("CheckDowned.downedMaterealizer", () => downedMaterealizer);
        internal static bool downedScarab;
        public static Condition scarab = new("CheckDowned.downedScarab", () => downedScarab);
        internal static bool downedWhale;
        public static Condition whale = new("CheckDowned.downedWhale", () => downedWhale);
        internal static bool downedSon;
        public static Condition son = new("CheckDowned.downedSon", () => downedSon);
        //EVENTS
        internal static bool downedCaveOrdeal;
        public static Condition caveOrdeal = new("CheckDowned.downedCaveOrdeal", () => downedCaveOrdeal);
        internal static bool downedCorruptOrdeal;
        public static Condition corruptOrdeal = new("CheckDowned.downedCorruptOrdeal", () => downedCorruptOrdeal);
        internal static bool downedCrimsonOrdeal;
        public static Condition crimsonOrdeal = new("CheckDowned.downedCrimsonOrdeal", () => downedCrimsonOrdeal);
        internal static bool downedDesertOrdeal;
        public static Condition desertOrdeal = new("CheckDowned.downedDesertOrdeal", () => downedDesertOrdeal);
        internal static bool downedForestOrdeal;
        public static Condition forestOrdeal = new("CheckDowned.downedForestOrdeal", () => downedForestOrdeal);
        internal static bool downedHallowOrdeal;
        public static Condition hallowOrdeal = new("CheckDowned.downedHallowOrdeal", () => downedHallowOrdeal);
        internal static bool downedJungleOrdeal;
        public static Condition jungleOrdeal = new("CheckDowned.downedJungleOrdeal", () => downedJungleOrdeal);
        internal static bool downedSkyOrdeal;
        public static Condition skyOrdeal = new("CheckDowned.downedSkyOrdeal", () => downedSkyOrdeal);
        internal static bool downedSnowOrdeal;
        public static Condition snowOrdeal = new("CheckDowned.downedSnowOrdeal", () => downedSnowOrdeal);
        internal static bool downedUnderworldOrdeal;
        public static Condition underworldOrdeal = new("CheckDowned.downedUnderworldOrdeal", () => downedUnderworldOrdeal);


        //HUNT OF THE OLD GOD
        internal static bool huntLoaded;
        internal static Mod huntMod;
        internal static bool downedGoozma;
        public static Condition goozma = new("CheckDowned.downedGoozma", () => downedGoozma);


        //INFERNUM
        internal static bool infernumLoaded;
        internal static Mod infernumMod;
        internal static bool downedVassal;
        public static Condition vassal = new("CheckDowned.downedVassal", () => downedVassal);


        //POLARITIES
        internal static bool polaritiesLoaded;
        internal static Mod polaritiesMod;
        internal static bool downedCloudfish;
        public static Condition cloudfish = new("CheckDowned.downedCloudfish", () => downedCloudfish);
        internal static bool downedConstruct;
        public static Condition construct = new("CheckDowned.downedConstruct", () => downedConstruct);
        internal static bool downedGigabat;
        public static Condition gigabat = new("CheckDowned.downedGigabat", () => downedGigabat);
        internal static bool downedSunPixie;
        public static Condition sunpixie = new("CheckDowned.downedSunPixie", () => downedSunPixie);
        internal static bool downedEsophage;
        public static Condition esophage = new("CheckDowned.downedEsophage", () => downedEsophage);
        internal static bool downedWanderer;
        public static Condition wanderer = new("CheckDowned.downedWanderer", () => downedWanderer);


        //QWERTY
        internal static bool qwertyLoaded;
        internal static Mod qwertyMod;
        internal static bool downedPolarBear;
        public static Condition polarBear = new("CheckDowned.downedPolarBear", () => downedPolarBear);
        internal static bool downedDivineLight;
        public static Condition divineLight = new("CheckDowned.downedDivineLight", () => downedDivineLight);
        internal static bool downedAncientMachine;
        public static Condition ancientMachine = new("CheckDowned.downedAncientMachine", () => downedAncientMachine);
        internal static bool downedNoehtnap;
        public static Condition noehtnap = new("CheckDowned.downedNoehtnap", () => downedNoehtnap);
        internal static bool downedHydra;
        public static Condition hydra = new("CheckDowned.downedHydra", () => downedHydra);
        internal static bool downedImperious;
        public static Condition imperious = new("CheckDowned.downedImperious", () => downedImperious);
        internal static bool downedRuneGhost;
        public static Condition runeGhost = new("CheckDowned.downedRuneGhost", () => downedRuneGhost);
        internal static bool downedOLORD;
        public static Condition olord = new("CheckDowned.downedOLORD", () => downedOLORD);


        //REDEMPTION
        internal static bool redemptionLoaded;
        internal static Mod redemptionMod;
        internal static bool downedFowlEmperor;
        public static Condition fowlEmperor = new("CheckDowned.downedFowlEmperor", () => downedFowlEmperor);
        internal static bool downedThorn;
        public static Condition thorn = new("CheckDowned.downedThorn", () => downedThorn);
        internal static bool downedErhan;
        public static Condition erhan = new("CheckDowned.downedErhan", () => downedErhan);
        internal static bool downedKeeper;
        public static Condition keeper = new("CheckDowned.downedKeeper", () => downedKeeper);
        internal static bool downedSeed;
        public static Condition seed = new("CheckDowned.downedSeed", () => downedSeed);
        internal static bool downedKS3;
        public static Condition ks3 = new("CheckDowned.downedKS3", () => downedKS3);
        internal static bool downedCleaver;
        public static Condition cleaver = new("CheckDowned.downedCleaver", () => downedCleaver);
        internal static bool downedGigapora;
        public static Condition gigapora = new("CheckDowned.downedGigapora", () => downedGigapora);
        internal static bool downedObliterator;
        public static Condition obliterator = new("CheckDowned.downedObliterator", () => downedObliterator);
        internal static bool downedZero;
        public static Condition zero = new("CheckDowned.downedZero", () => downedZero);
        internal static bool downedDuo;
        public static Condition duo = new("CheckDowned.downedDuo", () => downedDuo);
        internal static bool downedNebby;
        public static Condition nebby = new("CheckDowned.downedNebby", () => downedNebby);
        //EVENTS
        internal static bool downedFowlMorning;
        public static Condition fowlMorning = new("CheckDowned.downedFowlMorning", () => downedFowlMorning);
        internal static bool downedRaveyard;
        public static Condition raveyard = new("CheckDowned.downedRaveyard", () => downedRaveyard);


        //SECRETS OF THE SHADOWS
        internal static bool sotsLoaded;
        internal static Mod sotsMod;
        internal static bool downedPutridPinky;
        public static Condition putridpinky = new("CheckDowned.downedPutridPinky", () => downedPutridPinky);
        internal static bool downedGlowmoth;
        public static Condition glowmoth = new("CheckDowned.downedGlowmoth", () => downedGlowmoth);
        internal static bool downedPharaohsCurse;
        public static Condition pharaohscurse = new("CheckDowned.downedPharaohsCurse", () => downedPharaohsCurse);
        internal static bool downedAdvisor;
        public static Condition advisor = new("CheckDowned.downedAdvisor", () => downedAdvisor);
        internal static bool downedPolaris;
        public static Condition polaris = new("CheckDowned.downedPolaris", () => downedPolaris);
        internal static bool downedLux;
        public static Condition lux = new("CheckDowned.downedLux", () => downedLux);
        internal static bool downedSerpent;
        public static Condition serpent = new("CheckDowned.downedSerpent", () => downedSerpent);
        internal static bool downedNatureConstruct;
        public static Condition natureConstruct = new("CheckDowned.downedNatureConstruct", () => downedNatureConstruct);
        internal static bool downedEarthenConstruct;
        public static Condition earthenConstruct = new("CheckDowned.downedEarthenConstruct", () => downedEarthenConstruct);
        internal static bool downedPermafrostConstruct;
        public static Condition permafrostConstruct = new("CheckDowned.downedPermafrostConstruct", () => downedPermafrostConstruct);
        internal static bool downedTidalConstruct;
        public static Condition tidalConstruct = new("CheckDowned.downedTidalConstruct", () => downedTidalConstruct);
        internal static bool downedOtherworldlyConstruct;
        public static Condition otherworldlyConstruct = new("CheckDowned.downedOtherworldlyConstruct", () => downedOtherworldlyConstruct);
        internal static bool downedEvilConstruct;
        public static Condition evilConstruct = new("CheckDowned.downedEvilConstruct", () => downedEvilConstruct);
        internal static bool downedInfernoConstruct;
        public static Condition infernoConstruct = new("CheckDowned.downedInfernoConstruct", () => downedInfernoConstruct);
        internal static bool downedChaosConstruct;
        public static Condition chaosConstruct = new("CheckDowned.downedChaosConstruct", () => downedChaosConstruct);
        internal static bool downedNatureSpirit;
        public static Condition natureSpirit = new("CheckDowned.downedNatureSpirit", () => downedNatureSpirit);
        internal static bool downedEarthenSpirit;
        public static Condition earthenSpirit = new("CheckDowned.downedEarthenSpirit", () => downedEarthenSpirit);
        internal static bool downedPermafrostSpirit;
        public static Condition permafrostSpirit = new("CheckDowned.downedPermafrostSpirit", () => downedPermafrostSpirit);
        internal static bool downedTidalSpirit;
        public static Condition tidalSpirit = new("CheckDowned.downedTidalSpirit", () => downedTidalSpirit);
        internal static bool downedOtherworldlySpirit;
        public static Condition otherworldlySpirit = new("CheckDowned.downedOtherworldlySpirit", () => downedOtherworldlySpirit);
        internal static bool downedEvilSpirit;
        public static Condition evilSpirit = new("CheckDowned.downedEvilSpirit", () => downedEvilSpirit);
        internal static bool downedInfernoSpirit;
        public static Condition infernoSpirit = new("CheckDowned.downedInfernoSpirit", () => downedInfernoSpirit);
        internal static bool downedChaosSpirit;
        public static Condition chaosSpirit = new("CheckDowned.downedChaosSpirit", () => downedChaosSpirit);


        //SPIRIT
        internal static bool spiritLoaded;
        internal static Mod spiritMod;
        internal static bool downedScarabeus;
        public static Condition scarabeus = new("CheckDowned.downedScarabeus", () => downedScarabeus);
        internal static bool downedMoonJelly;
        public static Condition moonjelly = new("CheckDowned.downedMoonJelly", () => downedMoonJelly);
        internal static bool downedVinewrath;
        public static Condition vinewrath = new("CheckDowned.downedVinewrath", () => downedVinewrath);
        internal static bool downedAvian;
        public static Condition avian = new("CheckDowned.downedAvian", () => downedAvian);
        internal static bool downedStarVoyager;
        public static Condition starvoyager = new("CheckDowned.downedStarVoyager", () => downedStarVoyager);
        internal static bool downedInfernon;
        public static Condition infernon = new("CheckDowned.downedInfernon", () => downedInfernon);
        internal static bool downedDusking;
        public static Condition dusking = new("CheckDowned.downedDusking", () => downedDusking);
        internal static bool downedAtlas;
        public static Condition atlas = new("CheckDowned.downedAtlas", () => downedAtlas);
        //EVENTS
        internal static bool downedJellyDeluge;
        public static Condition jellyDeluge = new("CheckDowned.downedJellyDeluge", () => downedJellyDeluge);
        internal static bool downedTide;
        public static Condition tide = new("CheckDowned.downedTide", () => downedTide);
        internal static bool downedMysticMoon;
        public static Condition mysticMoon = new("CheckDowned.downedMysticMoon", () => downedMysticMoon);


        //SPOOKY
        internal static bool spookyLoaded;
        internal static Mod spookyMod;
        internal static bool downedSpookySpirit;
        public static Condition spookyspirit = new("CheckDowned.downedSpookySpirit", () => downedSpookySpirit);
        internal static bool downedGourd;
        public static Condition gourd = new("CheckDowned.downedGourd", () => downedGourd);
        internal static bool downedMoco;
        public static Condition moco = new("CheckDowned.downedMoco", () => downedMoco);
        internal static bool downedOrroBoro;
        internal static bool downedOrro;
        internal static bool downedBoro;
        public static Condition orroboro = new("CheckDowned.downedOrroBoro", () => downedOrroBoro);
        internal static bool downedBigBone;
        public static Condition bigbone = new("CheckDowned.downedBigBone", () => downedBigBone);


        //STORM DIVERS MOD
        internal static bool stormLoaded;
        internal static Mod stormMod;
        internal static bool downedArid;
        public static Condition arid = new("CheckDowned.downedArid", () => downedArid);
        internal static bool downedStorm;
        public static Condition storm = new("CheckDowned.downedArid", () => downedStorm);
        internal static bool downedPainbringer;
        public static Condition painbringer = new("CheckDowned.downedPainbringer", () => downedPainbringer);


        //TERRORBORN
        internal static bool terrorbornLoaded;
        internal static Mod terrorbornMod;
        internal static bool downedIncarnate;
        public static Condition incarnate = new("CheckDowned.downedIncarnate", () => downedIncarnate);
        internal static bool downedTitan;
        public static Condition titan = new("CheckDowned.downedTitan", () => downedTitan);
        internal static bool downedDunestock;
        public static Condition dunestock = new("CheckDowned.downedDunestock", () => downedDunestock);
        internal static bool downedCrawler;
        public static Condition crawler = new("CheckDowned.downedCrawler", () => downedCrawler);
        internal static bool downedConstructor;
        public static Condition constructor = new("CheckDowned.downedConstructor", () => downedConstructor);
        internal static bool downedP1;
        public static Condition p1 = new("CheckDowned.downedP1", () => downedP1);


        //THORIUM
        internal static bool thoriumLoaded;
        internal static Mod thoriumMod;
        internal static bool downedGrandBird;
        public static Condition grandbird = new("CheckDowned.downedGrandBird", () => downedGrandBird);
        internal static bool downedQueenJelly;
        public static Condition queenjelly = new("CheckDowned.downedQueenJelly", () => downedQueenJelly);
        internal static bool downedViscount;
        public static Condition viscount = new("CheckDowned.downedViscount", () => downedViscount);
        internal static bool downedEnergyStorm;
        public static Condition energystorm = new("CheckDowned.downedEnergyStorm", () => downedEnergyStorm);
        internal static bool downedBuriedChampion;
        public static Condition buriedchampion = new("CheckDowned.downedBuriedChampion", () => downedBuriedChampion);
        internal static bool downedScouter;
        public static Condition scouter = new("CheckDowned.downedScouter", () => downedScouter);
        internal static bool downedStrider;
        public static Condition strider = new("CheckDowned.downedStrider", () => downedStrider);
        internal static bool downedFallenBeholder;
        public static Condition fallenbeholder = new("CheckDowned.downedFallenBeholder", () => downedFallenBeholder);
        internal static bool downedLich;
        public static Condition lich = new("CheckDowned.downedLich", () => downedLich);
        internal static bool downedForgottenOne;
        public static Condition forgottenone = new("CheckDowned.downedForgottenOne", () => downedForgottenOne);
        internal static bool downedPrimordials;
        public static Condition primordials = new("CheckDowned.downedPrimordials", () => downedPrimordials);
        internal static bool downedPatchWerk;
        public static Condition patchWerk = new("CheckDowned.downedPatchWerk", () => downedPatchWerk);
        internal static bool downedCorpseBloom;
        public static Condition corpseBloom = new("CheckDowned.downedCorpseBloom", () => downedCorpseBloom);
        internal static bool downedIllusionist;
        public static Condition illusionist = new("CheckDowned.downedIllusionist", () => downedIllusionist);
        //BIOMES
        internal static bool beenToAquaticDepths;
        public static Condition hasBeenToAquaticDepths = new("CheckDowned.beenToAquaticDepths", () => beenToAquaticDepths);


        //VERDANT
        internal static bool verdantLoaded;
        internal static Mod verdantMod;


        //VITALITY
        internal static bool vitalityLoaded;
        internal static Mod vitalityMod;
        internal static bool downedStormCloud;
        public static Condition stormcloud = new("CheckDowned.downedStormCloud", () => downedStormCloud);
        internal static bool downedGrandAntlion;
        public static Condition grandantlion = new("CheckDowned.downedGrandAntlion", () => downedGrandAntlion);
        internal static bool downedGemstoneElemental;
        public static Condition gemstone = new("CheckDowned.downedGemstoneElemental", () => downedGemstoneElemental);
        internal static bool downedMoonlightDragonfly;
        public static Condition dragonfly = new("CheckDowned.downedMoonlightDragonfly", () => downedMoonlightDragonfly);
        internal static bool downedDreadnaught;
        public static Condition dreadnaught = new("CheckDowned.downedDreadnaught", () => downedDreadnaught);
        internal static bool downedAnarchulesBeetle;
        public static Condition anarchulesbeetle = new("CheckDowned.downedAnarchulesBeetle", () => downedAnarchulesBeetle);
        internal static bool downedChaosbringer;
        public static Condition chaosbringer = new("CheckDowned.downedChaosbringer", () => downedChaosbringer);
        internal static bool downedPaladinSpirit;
        public static Condition paladin = new("CheckDowned.downedPaladinSpirit", () => downedPaladinSpirit);
        #endregion
        #pragma warning restore CA2211

        public override void Unload()
        {
            if (!aqLoaded)
            {
                aqMod = null;
            }
            if (!arbourLoaded)
            {
                arbourMod = null;
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
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!echoesLoaded)
            {
                echoesMod = null;
            }
            if (!exaltLoaded)
            {
                exaltMod = null;
            }
            if (!fargosLoaded)
            {
                fargosMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!gmrLoaded)
            {
                gmrMod = null;
            }
            if (!homewardLoaded)
            {
                homewardMod = null;
            }
            if (!huntLoaded)
            {
                huntMod = null;
            }
            if (!infernumLoaded)
            {
                infernumMod = null;
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
            if (!sotsLoaded)
            {
                sotsMod = null;
            }
            if (!spiritLoaded)
            {
                spiritMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!stormLoaded)
            {
                stormMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!verdantLoaded)
            {
                verdantMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
        }

        public override void Load()
        {
            if (!aqLoaded)
            {
                aqMod = null;
            }
            if (!arbourLoaded)
            {
                arbourMod = null;
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
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!echoesLoaded)
            {
                echoesMod = null;
            }
            if (!exaltLoaded)
            {
                exaltMod = null;
            }
            if (!fargosLoaded)
            {
                fargosMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!gmrLoaded)
            {
                gmrMod = null;
            }
            if (!homewardLoaded)
            {
                homewardMod = null;
            }
            if (!huntLoaded)
            {
                huntMod = null;
            }
            if (!infernumLoaded)
            {
                infernumMod = null;
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
            if (!sotsLoaded)
            {
                sotsMod = null;
            }
            if (!spiritLoaded)
            {
                spiritMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!stormLoaded)
            {
                stormMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!verdantLoaded)
            {
                verdantMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
        }

        public override void PostSetupContent()
        {
            aqLoaded = ModLoader.TryGetMod("Aequus", out Mod Aequus);
            aqMod = Aequus;

            arbourLoaded = ModLoader.TryGetMod("Arbour", out Mod Arbour);
            arbourMod = Arbour;

            calamityLoaded = ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod);
            calamityMod = CalamityMod;

            calamityVanitiesLoaded = ModLoader.TryGetMod("CalValEX", out Mod CalValEX);
            calamityVanitiesMod = CalValEX;

            catalystLoaded = ModLoader.TryGetMod("CatalystMod", out Mod CatalystMod);
            catalystMod = CatalystMod;

            consolariaLoaded = ModLoader.TryGetMod("Consolaria", out Mod Consolaria);
            consolariaMod = Consolaria;

            echoesLoaded = ModLoader.TryGetMod("EchoesoftheAncients", out Mod EchoesoftheAncients);
            echoesMod = EchoesoftheAncients;

            exaltLoaded = ModLoader.TryGetMod("ExaltMod", out Mod ExaltMod);
            exaltMod = ExaltMod;

            fargosLoaded = ModLoader.TryGetMod("Fargowiltas", out Mod Fargowiltas);
            fargosMod = Fargowiltas;

            fargosSoulsLoaded = ModLoader.TryGetMod("FargowiltasSouls", out Mod FargowiltasSouls);
            fargosSoulsMod = FargowiltasSouls;

            gmrLoaded = ModLoader.TryGetMod("GMR", out Mod GMR);
            gmrMod = GMR;

            homewardLoaded = ModLoader.TryGetMod("ContinentOfJourney", out Mod ContinentOfJourney);
            homewardMod = ContinentOfJourney;

            huntLoaded = ModLoader.TryGetMod("CalamityHunt", out Mod CalamityHunt);
            huntMod = CalamityHunt;

            infernumLoaded = ModLoader.TryGetMod("InfernumMode", out Mod InfernumMode);
            infernumMod = InfernumMode;

            polaritiesLoaded = ModLoader.TryGetMod("Polarities", out Mod Polarities);
            polaritiesMod = Polarities;

            qwertyLoaded = ModLoader.TryGetMod("QwertyMod", out Mod QwertyMod);
            qwertyMod = QwertyMod;

            redemptionLoaded = ModLoader.TryGetMod("Redemption", out Mod Redemption);
            redemptionMod = Redemption;

            sotsLoaded = ModLoader.TryGetMod("SOTS", out Mod SOTS);
            sotsMod = SOTS;

            spiritLoaded = ModLoader.TryGetMod("SpiritMod", out Mod SpiritMod);
            spiritMod = SpiritMod;

            spookyLoaded = ModLoader.TryGetMod("Spooky", out Mod Spooky);
            spookyMod = Spooky;

            stormLoaded = ModLoader.TryGetMod("StormDiversMod", out Mod StormDiversMod);
            stormMod = StormDiversMod;

            terrorbornLoaded = ModLoader.TryGetMod("TerrorbornMod", out Mod TerrorbornMod);
            terrorbornMod = TerrorbornMod;

            thoriumLoaded = ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            thoriumMod = ThoriumMod;

            verdantLoaded = ModLoader.TryGetMod("Verdant", out Mod Verdant);
            verdantMod = Verdant;

            vitalityLoaded = ModLoader.TryGetMod("VitalityMod", out Mod VitalityMod);
            vitalityMod = VitalityMod;
        }

        public override void OnWorldLoad()
        {
            ResetDowned();
        }

        public override void OnWorldUnload()
        {
            ResetDowned();
        }

        public override void SaveWorldData(TagCompound tag)
        {
            //VANILLA
            //EVENTS
            tag.Add("downedBloodMoon", downedBloodMoon);
            tag.Add("downedEclipse", downedEclipse);
            //BIOMES
            tag.Add("beenToPurity", beenToPurity);
            tag.Add("beenToCavernsOrUnderground", beenToCavernsOrUnderground);
            tag.Add("beenToUnderworld", beenToUnderworld);
            tag.Add("beenToSky", beenToSky);
            tag.Add("beenToSnow", beenToSnow);
            tag.Add("beenToOcean", beenToOcean);
            tag.Add("beenToJungle", beenToJungle);
            tag.Add("beenToMushroom", beenToMushroom);
            tag.Add("beenToCorruption", beenToCorruption);
            tag.Add("beenToCrimson", beenToCrimson);
            tag.Add("beenToHallow", beenToHallow);
            tag.Add("beenToTemple", beenToTemple);
            tag.Add("beenToDungeon", beenToDungeon);

            //AEQUUS
            tag.Add("downedCrabson", downedCrabson);
            tag.Add("downedOmegaStarite", downedOmegaStarite);
            tag.Add("downedDevil", downedDevil);
            tag.Add("downedSprite", downedSprite);
            tag.Add("downedSpaceSquid", downedSpaceSquid);
            tag.Add("downedHyperStarite", downedHyperStarite);
            tag.Add("downedUltraStarite", downedUltraStarite);
            //EVENTS
            tag.Add("downedDemonSiege", downedDemonSiege);
            tag.Add("downedGlimmer", downedGlimmer);
            tag.Add("downedGaleStreams", downedGaleStreams);

            //CALAMITY
            tag.Add("downedDesertScourge", downedDesertScourge);
            tag.Add("downedCrabulon", downedCrabulon);
            tag.Add("downedHiveMind", downedHiveMind);
            tag.Add("downedPerforators", downedPerforators);
            tag.Add("downedSlimeGod", downedSlimeGod);
            tag.Add("downedCryogen", downedCryogen);
            tag.Add("downedAquaticScourge", downedAquaticScourge);
            tag.Add("downedBrimstoneElemental", downedBrimstoneElemental);
            tag.Add("downedCalamitas", downedCalamitas);
            tag.Add("downedLeviathan", downedLeviathan);
            tag.Add("downedAureus", downedAureus);
            tag.Add("downedPlaguebringer", downedPlaguebringer);
            tag.Add("downedRavager", downedRavager);
            tag.Add("downedDeus", downedDeus);
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
            tag.Add("downedGiantClam", downedGiantClam);
            tag.Add("downedGreatSandShark", downedGreatSandShark);
            tag.Add("downedCragmawMire", downedCragmawMire);
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

            //CATALYST
            tag.Add("downedGeldon", downedGeldon);

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
            tag.Add("downedDeviant", downedDeviant);
            tag.Add("downedLieflight", downedLieflight);
            tag.Add("downedCosmosChampion", downedCosmosChampion);
            tag.Add("downedAbomination", downedAbomination);
            tag.Add("downedMutant", downedMutant);

            //GMR
            tag.Add("downedTrerios", downedTrerios);
            tag.Add("downedMagmaEye", downedMagmaEye);
            tag.Add("downedJack", downedJack);
            tag.Add("downedAcheron", downedAcheron);

            //HOMEWARD JOURNEY
            tag.Add("downedSquid", downedSquid);
            tag.Add("downedRod", downedRod);
            tag.Add("downedDiver", downedDiver);
            tag.Add("downedMotherbrain", downedMotherbrain);
            tag.Add("downedWoS", downedWoS);
            tag.Add("downedSGod", downedSGod);
            tag.Add("downedOverwatcher", downedOverwatcher);
            tag.Add("downedLifebringer", downedLifebringer);
            tag.Add("downedMaterealizer", downedMaterealizer);
            tag.Add("downedScarab", downedScarab);
            tag.Add("downedWhale", downedWhale);
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

            //HUNT OF THE OLD GOD
            tag.Add("downedGoozma", downedGoozma);

            //INFERNUM
            tag.Add("downedVassal", downedVassal);

            //POLARITIES
            tag.Add("downedCloudfish", downedCloudfish);
            tag.Add("downedConstruct", downedConstruct);
            tag.Add("downedGigabat", downedGigabat);
            tag.Add("downedSunPixie", downedSunPixie);
            tag.Add("downedEsophage", downedEsophage);
            tag.Add("downedWanderer", downedWanderer);

            //QWERTY
            tag.Add("downedPolarBear", downedPolarBear);
            tag.Add("downedDivineLight", downedDivineLight);
            tag.Add("downedAncientMachine", downedAncientMachine);
            tag.Add("downedNoehtnap", downedNoehtnap);
            tag.Add("downedHydra", downedHydra);
            tag.Add("downedImperious", downedImperious);
            tag.Add("downedRuneGhost", downedRuneGhost);
            tag.Add("downedOLORD", downedOLORD);

            //REDEMPTION
            tag.Add("downedFowlEmperor", downedFowlEmperor);
            tag.Add("downedThorn", downedThorn);
            tag.Add("downedErhan", downedErhan);
            tag.Add("downedKeeper", downedKeeper);
            tag.Add("downedSeed", downedSeed);
            tag.Add("downedKS3", downedKS3);
            tag.Add("downedCleaver", downedCleaver);
            tag.Add("downedGigapora", downedGigapora);
            tag.Add("downedObliterator", downedObliterator);
            tag.Add("downedZero", downedZero);
            tag.Add("downedDuo", downedDuo);
            tag.Add("downedNebby", downedNebby);
            //EVENTS
            tag.Add("downedFowlMorning", downedFowlMorning);
            tag.Add("downedRaveyard", downedRaveyard);

            //SOTS
            tag.Add("downedGlowmoth", downedGlowmoth);
            tag.Add("downedPutridPinky", downedPutridPinky);
            tag.Add("downedPharaohsCurse", downedPharaohsCurse);
            tag.Add("downedAdvisor", downedAdvisor);
            tag.Add("downedPolaris", downedPolaris);
            tag.Add("downedLux", downedLux);
            tag.Add("downedSerpent", downedSerpent);
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

            //SPIRIT
            tag.Add("downedScarabeus", downedScarabeus);
            tag.Add("downedMoonJelly", downedMoonJelly);
            tag.Add("downedVinewrath", downedVinewrath);
            tag.Add("downedAvian", downedAvian);
            tag.Add("downedStarVoyager", downedStarVoyager);
            tag.Add("downedInfernon", downedInfernon);
            tag.Add("downedDusking", downedDusking);
            tag.Add("downedAtlas", downedAtlas);
            //EVENTS
            tag.Add("downedJellyDeluge", downedJellyDeluge);
            tag.Add("downedTide", downedTide);
            tag.Add("downedMysticMoon", downedMysticMoon);

            //SPOOKY
            tag.Add("downedSpookySpirit", downedSpookySpirit);
            tag.Add("downedGourd", downedGourd);
            tag.Add("downedMoco", downedMoco);
            tag.Add("downedOrroBoro", downedOrroBoro);
            tag.Add("downedBigBone", downedBigBone);

            //STORM DIVERS MOD
            tag.Add("downedArid", downedArid);
            tag.Add("downedStorm", downedStorm);
            tag.Add("downedPainbringer", downedPainbringer);

            //TERRORBORN
            tag.Add("downedIncarnate", downedIncarnate);
            tag.Add("downedTitan", downedTitan);
            tag.Add("downedDunestock", downedDunestock);
            tag.Add("downedCrawler", downedCrawler);
            tag.Add("downedConstructor", downedConstructor);
            tag.Add("downedP1", downedP1);

            //THORIUM
            tag.Add("downedGrandBird", downedGrandBird);
            tag.Add("downedQueenJelly", downedQueenJelly);
            tag.Add("downedViscount", downedViscount);
            tag.Add("downedEnergyStorm", downedEnergyStorm);
            tag.Add("downedBuriedChampion", downedBuriedChampion);
            tag.Add("downedStrider", downedStrider);
            tag.Add("downedFallenBeholder", downedFallenBeholder);
            tag.Add("downedLich", downedLich);
            tag.Add("downedForgottenOne", downedForgottenOne);
            tag.Add("downedPrimordials", downedPrimordials);
            tag.Add("downedPatchWerk", downedPatchWerk);
            tag.Add("downedCorpseBloom", downedCorpseBloom);
            tag.Add("downedIllusionist", downedIllusionist);
            //BIOMES
            tag.Add("beenToAquaticDepths", beenToAquaticDepths);

            //VITALITY
            tag.Add("downedStormCloud", downedStormCloud);
            tag.Add("downedGrandAntlion", downedGrandAntlion);
            tag.Add("downedGemstoneElemental", downedGemstoneElemental);
            tag.Add("downedMoonlightDragonfly", downedMoonlightDragonfly);
            tag.Add("downedDreadnaught", downedDreadnaught);
            tag.Add("downedAnarchulesBeetle", downedAnarchulesBeetle);
            tag.Add("downedChaosbringer", downedChaosbringer);
            tag.Add("downedPaladinSpirit", downedPaladinSpirit);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            //VANILLA
            downedBloodMoon = tag.Get<bool>("downedBloodMoon");
            downedEclipse = tag.Get<bool>("downedEclipse");
            //BIOMES
            beenToPurity = tag.Get<bool>("beenToPurity");
            beenToCavernsOrUnderground = tag.Get<bool>("beenToCavernsOrUnderground");
            beenToUnderworld = tag.Get<bool>("beenToUnderworld");
            beenToSky = tag.Get<bool>("beenToSky");
            beenToSnow = tag.Get<bool>("beenToSnow");
            beenToOcean = tag.Get<bool>("beenToOcean");
            beenToJungle = tag.Get<bool>("beenToJungle");
            beenToMushroom = tag.Get<bool>("beenToMushroom");
            beenToCorruption = tag.Get<bool>("beenToCorruption");
            beenToCrimson = tag.Get<bool>("beenToCrimson");
            beenToHallow = tag.Get<bool>("beenToHallow");
            beenToTemple = tag.Get<bool>("beenToTemple");
            beenToDungeon = tag.Get<bool>("beenToDungeon");

            //AEQUUS
            downedCrabson = tag.Get<bool>("downedCrabson");
            downedOmegaStarite = tag.Get<bool>("downedOmegaStarite");
            downedDevil = tag.Get<bool>("downedDevil");
            downedSprite = tag.Get<bool>("downedSprite");
            downedSpaceSquid = tag.Get<bool>("downedSpaceSquid");
            downedHyperStarite = tag.Get<bool>("downedHyperStarite");
            downedUltraStarite = tag.Get<bool>("downedUltraStarite");
            //EVENTS
            downedDemonSiege = tag.Get<bool>("downedDemonSiege");
            downedGlimmer = tag.Get<bool>("downedGlimmer");
            downedGaleStreams = tag.Get<bool>("downedGaleStreams");

            //CALAMITY
            downedDesertScourge = tag.Get<bool>("downedDesertScourge");
            downedCrabulon = tag.Get<bool>("downedCrabulon");
            downedHiveMind = tag.Get<bool>("downedHiveMind");
            downedPerforators = tag.Get<bool>("downedPerforators");
            downedSlimeGod = tag.Get<bool>("downedSlimeGod");
            downedCryogen = tag.Get<bool>("downedCryogen");
            downedAquaticScourge = tag.Get<bool>("downedAquaticScourge");
            downedBrimstoneElemental = tag.Get<bool>("downedBrimstoneElemental");
            downedCalamitas = tag.Get<bool>("downedCalamitas");
            downedLeviathan = tag.Get<bool>("downedLeviathan");
            downedAureus = tag.Get<bool>("downedAureus");
            downedPlaguebringer = tag.Get<bool>("downedPlaguebringer");
            downedRavager = tag.Get<bool>("downedRavager");
            downedDeus = tag.Get<bool>("downedDeus");
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
            downedGiantClam = tag.Get<bool>("downedGiantClam");
            downedGreatSandShark = tag.Get<bool>("downedGreatSandShark");
            downedCragmawMire = tag.Get<bool>("downedCragmawMire");
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

            //CATALYST
            downedGeldon = tag.Get<bool>("downedGeldon");

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
            downedDeviant = tag.Get<bool>("downedDeviant");
            downedLieflight = tag.Get<bool>("downedLieflight");
            downedCosmosChampion = tag.Get<bool>("downedCosmosChampion");
            downedAbomination = tag.Get<bool>("downedAbomination");
            downedMutant = tag.Get<bool>("downedMutant");

            //GMR
            downedTrerios = tag.Get<bool>("downedTrerios");
            downedMagmaEye = tag.Get<bool>("downedMagmaEye");
            downedJack = tag.Get<bool>("downedJack");
            downedAcheron = tag.Get<bool>("downedAcheron");

            //HOMEWARD JOURNEY
            downedSquid = tag.Get<bool>("downedSquid");
            downedRod = tag.Get<bool>("downedRod");
            downedDiver = tag.Get<bool>("downedDiver");
            downedMotherbrain = tag.Get<bool>("downedMotherbrain");
            downedWoS = tag.Get<bool>("downedWoS");
            downedSGod = tag.Get<bool>("downedSGod");
            downedOverwatcher = tag.Get<bool>("downedOverwatcher");
            downedLifebringer = tag.Get<bool>("downedLifebringer");
            downedMaterealizer = tag.Get<bool>("downedMaterealizer");
            downedScarab = tag.Get<bool>("downedScarab");
            downedWhale = tag.Get<bool>("downedWhale");
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

            //HUNT OF THE OLD GOD
            downedGoozma = tag.Get<bool>("downedGoozma");

            //INFERNUM
            downedVassal = tag.Get<bool>("downedVassal");

            //POLARITIES
            downedCloudfish = tag.Get<bool>("downedCloudfish");
            downedConstruct = tag.Get<bool>("downedConstruct");
            downedGigabat = tag.Get<bool>("downedGigabat");
            downedSunPixie = tag.Get<bool>("downedSunPixie");
            downedEsophage = tag.Get<bool>("downedEsophage");
            downedWanderer = tag.Get<bool>("downedWanderer");

            //QWERTY
            downedPolarBear = tag.Get<bool>("downedPolarBear");
            downedDivineLight = tag.Get<bool>("downedDivineLight");
            downedAncientMachine = tag.Get<bool>("downedAncientMachine");
            downedNoehtnap = tag.Get<bool>("downedNoehtnap");
            downedHydra = tag.Get<bool>("downedHydra");
            downedImperious = tag.Get<bool>("downedImperious");
            downedRuneGhost = tag.Get<bool>("downedRuneGhost");
            downedOLORD = tag.Get<bool>("downedOLORD");

            //REDEMPTION
            downedFowlEmperor = tag.Get<bool>("downedFowlEmperor");
            downedThorn = tag.Get<bool>("downedThorn");
            downedErhan = tag.Get<bool>("downedErhan");
            downedKeeper = tag.Get<bool>("downedKeeper");
            downedSeed = tag.Get<bool>("downedSeed");
            downedKS3 = tag.Get<bool>("downedKS3");
            downedCleaver = tag.Get<bool>("downedCleaver");
            downedGigapora = tag.Get<bool>("downedGigapora");
            downedObliterator = tag.Get<bool>("downedObliterator");
            downedZero = tag.Get<bool>("downedZero");
            downedDuo = tag.Get<bool>("downedDuo");
            downedNebby = tag.Get<bool>("downedNebby");
            //EVENTS
            downedFowlMorning = tag.Get<bool>("downedFowlMorning");
            downedRaveyard = tag.Get<bool>("downedRaveyard");

            //SOTS
            downedGlowmoth = tag.Get<bool>("downedGlowmoth");
            downedPutridPinky = tag.Get<bool>("downedPutridPinky");
            downedPharaohsCurse = tag.Get<bool>("downedPharaohsCurse");
            downedAdvisor = tag.Get<bool>("downedAdvisor");
            downedPolaris = tag.Get<bool>("downedPolaris");
            downedLux = tag.Get<bool>("downedLux");
            downedSerpent = tag.Get<bool>("downedSerpent");
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

            //SPIRIT
            downedScarabeus = tag.Get<bool>("downedScarabeus");
            downedMoonJelly = tag.Get<bool>("downedMoonJelly");
            downedVinewrath = tag.Get<bool>("downedVinewrath");
            downedAvian = tag.Get<bool>("downedAvian");
            downedStarVoyager = tag.Get<bool>("downedStarVoyager");
            downedInfernon = tag.Get<bool>("downedInfernon");
            downedDusking = tag.Get<bool>("downedDusking");
            downedAtlas = tag.Get<bool>("downedAtlas");
            //EVENTS
            downedJellyDeluge = tag.Get<bool>("downedJellyDeluge");
            downedTide = tag.Get<bool>("downedTide");
            downedMysticMoon = tag.Get<bool>("downedMysticMoon");

            //SPOOKY
            downedSpookySpirit = tag.Get<bool>("downedSpookySpirit");
            downedGourd = tag.Get<bool>("downedGourd");
            downedMoco = tag.Get<bool>("downedMoco");
            downedOrroBoro = tag.Get<bool>("downedOrroBoro");
            downedBigBone = tag.Get<bool>("downedBigBone");

            //STORM DIVERS MOD
            downedArid = tag.Get<bool>("downedArid");
            downedStorm = tag.Get<bool>("downedStorm");
            downedPainbringer = tag.Get<bool>("downedPainbringer");

            //TERRORBORN
            downedIncarnate = tag.Get<bool>("downedIncarnate");
            downedTitan = tag.Get<bool>("downedTitan");
            downedDunestock = tag.Get<bool>("downedDunestock");
            downedCrawler = tag.Get<bool>("downedCrawler");
            downedConstructor = tag.Get<bool>("downedConstructor");
            downedP1 = tag.Get<bool>("downedP1");

            //THORIUM
            downedGrandBird = tag.Get<bool>("downedGrandBird");
            downedQueenJelly = tag.Get<bool>("downedQueenJelly");
            downedViscount = tag.Get<bool>("downedViscount");
            downedEnergyStorm = tag.Get<bool>("downedEnergyStorm");
            downedBuriedChampion = tag.Get<bool>("downedBuriedChampion");
            downedStrider = tag.Get<bool>("downedStrider");
            downedFallenBeholder = tag.Get<bool>("downedFallenBeholder");
            downedLich = tag.Get<bool>("downedLich");
            downedForgottenOne = tag.Get<bool>("downedForgottenOne");
            downedPrimordials = tag.Get<bool>("downedPrimordials");
            downedPatchWerk = tag.Get<bool>("downedPatchWerk");
            downedCorpseBloom = tag.Get<bool>("downedCorpseBloom");
            downedIllusionist = tag.Get<bool>("downedIllusionist");
            //BIOMES
            beenToAquaticDepths = tag.Get<bool>("beenToAquaticDepths");

            //VITALITY
            downedStormCloud = tag.Get<bool>("downedStormCloud");
            downedGrandAntlion = tag.Get<bool>("downedGrandAntlion");
            downedGemstoneElemental = tag.Get<bool>("downedGemstoneElemental");
            downedMoonlightDragonfly = tag.Get<bool>("downedMoonlightDragonfly");
            downedDreadnaught = tag.Get<bool>("downedDreadnaught");
            downedAnarchulesBeetle = tag.Get<bool>("downedAnarchulesBeetle");
            downedChaosbringer = tag.Get<bool>("downedChaosbringer");
            downedPaladinSpirit = tag.Get<bool>("downedPaladinSpirit");
        }

        public override void PostUpdatePlayers()
        {
            #region Biomes
            /*
            if (Main.LocalPlayer.ZoneForest)
            {
                beenToPurity = true;
            }
            if (Main.LocalPlayer.ZoneNormalUnderground)
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
            if (Main.LocalPlayer.ZoneDesert)
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

            if (calamityLoaded)
            {
                beenToCrags = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "crags"
                });
                beenToAstral = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "astral"
                });
                beenToSunkenSea = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "sunkensea"
                });
                beenToSulphurSea = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "sulphursea"
                });
                beenToAbyss = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "abyss"
                });
                beenToAbyssLayer1 = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "layer1"
                });
                beenToAbyssLayer2 = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "layer2"
                });
                beenToAbyssLayer3 = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "layer3"
                });
                beenToAbyssLayer4 = (bool)calamityMod.Call(new object[]
                {
                    "GetInZone",
                    Main.LocalPlayer,
                    "layer4"
                });
            }

            if (thoriumLoaded)
            {
                if (thoriumMod.TryFind("DepthsBiome", out ModBiome DepthsBiome))
                {
                    beenToAquaticDepths = Main.LocalPlayer.InModBiome(DepthsBiome);
                }
            }
            */
            #endregion

            if (infernumLoaded)
            {
                if (infernumMod.TryFind("BereftVassalBossBag", out ModItem BereftVassalBossBag))
                {
                    if (Main.LocalPlayer.HasItem(BereftVassalBossBag.Type))
                    {
                        downedVassal = true;
                    }
                }
            }

            if (qwertyLoaded)
            {
                if (qwertyMod.TryFind("HydraBag", out ModItem HydraBag))
                {
                    if (Main.LocalPlayer.HasItem(HydraBag.Type))
                    {
                        downedHydra = true;
                    }
                }

                if (qwertyMod.TryFind("HydraScale", out ModItem HydraScale))
                {
                    if (Main.LocalPlayer.HasItem(HydraScale.Type))
                    {
                        downedHydra = true;
                    }
                }
            }

            if (sotsLoaded)
            {
                if (sotsMod.TryFind("TheAdvisorBossBag", out ModItem TheAdvisorBossBag))
                {
                    if (Main.LocalPlayer.HasItem(TheAdvisorBossBag.Type))
                    {
                        downedAdvisor = true;
                    }
                }

                if (sotsMod.TryFind("DissolvingAether", out ModItem DissolvingAether))
                {
                    if (Main.LocalPlayer.HasItem(DissolvingAether.Type))
                    {
                        downedAdvisor = true;
                    }
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

            if (spookyLoaded)
            {
                if (downedOrro && downedBoro)
                {
                    downedOrroBoro = true;
                }
            }
        }

        public override void PreUpdateWorld()
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
            #endregion

            if (aqLoaded)
            {
                downedCrabson = (bool)aqMod.Call("downedCrabson", Mod);
                downedOmegaStarite = (bool)aqMod.Call("downedOmegaStarite", Mod);
                downedDevil = (bool)aqMod.Call("downedDustDevil", Mod);
                downedSprite = (bool)aqMod.Call("downedRedSprite", Mod);
                downedSpaceSquid = (bool)aqMod.Call("downedSpaceSquid", Mod);
                downedHyperStarite = (bool)aqMod.Call("downedHyperStarite", Mod);
                downedUltraStarite = (bool)aqMod.Call("downedUltraStarite", Mod);
                downedDemonSiege = (bool)aqMod.Call("downedEventDemon", Mod);
                downedGlimmer = (bool)aqMod.Call("downedEventCosmic", Mod);
                downedGaleStreams = (bool)aqMod.Call("downedEventAtmosphere", Mod);
            }

            if (calamityLoaded)
            {
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
                downedCalamitas = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "CalamitasClone"
                });
                downedLeviathan = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "AnahitaLeviathan"
                });
                downedAureus = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "AstrumAureus"
                });
                downedPlaguebringer = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "PlaguebringerGoliath"
                });
                downedRavager = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Ravager"
                });
                downedDeus = (bool)calamityMod.Call(new object[]
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
            }
            
            if (thoriumLoaded)
            {
                downedGrandBird = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "TheGrandThunderBird"
                });
                downedQueenJelly = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "QueenJellyfish"
                });
                downedViscount = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "Viscount"
                });
                downedEnergyStorm = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "GraniteEnergyStorm"
                });
                downedBuriedChampion = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "BuriedChampion"
                });
                downedScouter = (bool)thoriumMod.Call(new object[]
                {
                    "GetDownedBoss",
                    "StarScouter"
                });
                downedStrider = (bool)thoriumMod.Call(new object[]
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
            }
        }

        public override void PreUpdateNPCs()
        {
            foreach (NPC npc in Main.npc)
            {
                npc.GetLifeStats(out int life, out int lifemax);

                if (calamityLoaded)
                {
                    if (calamityMod.TryFind("CragmawMire", out ModNPC CragmawMire))
                    {
                        if (npc.type == CragmawMire.Type && CragmawMire.NPC.life <= 0)
                        {
                            downedCragmawMire = true;
                        }
                    }
                    if (calamityMod.TryFind("NuclearTerror", out ModNPC NuclearTerror))
                    {
                        if (npc.type == NuclearTerror.Type && NuclearTerror.NPC.life <= 0)
                        {
                            downedNuclearTerror = true;
                        }
                    }
                    if (calamityMod.TryFind("Mauler", out ModNPC Mauler))
                    {
                        if (npc.type == Mauler.Type && Mauler.NPC.life <= 0)
                        {
                            downedMauler = true;
                        }
                    }
                }

                if (catalystLoaded)
                {
                    if (catalystMod.TryFind("Astrageldon", out ModNPC Astrageldon))
                    {
                        if (npc.type == Astrageldon.Type && Astrageldon.NPC.life <= 0)
                        {
                            downedGeldon = true;
                        }
                    }
                }

                if (consolariaLoaded)
                {
                    if (consolariaMod.TryFind("Lepus", out ModNPC Lepus))
                    {
                        if (npc.type == Lepus.Type && Lepus.NPC.life <= 0)
                        {
                            downedLepus = true;
                        }
                    }
                    if (consolariaMod.TryFind("TurkortheUngrateful", out ModNPC TurkortheUngrateful))
                    {
                        if (npc.type == TurkortheUngrateful.Type && TurkortheUngrateful.NPC.life <= 0)
                        {
                            downedTurkor = true;
                        }
                    }
                    if (consolariaMod.TryFind("Ocram", out ModNPC Ocram))
                    {
                        if (npc.type == Ocram.Type && Ocram.NPC.life <= 0)
                        {
                            downedOcram = true;
                        }
                    }
                }

                if (echoesLoaded)
                {
                    if (echoesMod.TryFind("Galahis", out ModNPC Galahis))
                    {
                        if (npc.type == Galahis.Type && Galahis.NPC.life <= 0)
                        {
                            downedGalahis = true;
                        }
                    }
                    if (echoesMod.TryFind("AquaWormHead", out ModNPC AquaWormHead))
                    {
                        if (npc.type == AquaWormHead.Type && AquaWormHead.NPC.life <= 0)
                        {
                            downedCreation = true;
                        }
                    }
                    if (echoesMod.TryFind("PumpkinWormHead", out ModNPC PumpkinWormHead))
                    {
                        if (npc.type == PumpkinWormHead.Type && PumpkinWormHead.NPC.life <= 0)
                        {
                            downedDestruction = true;
                        }
                    }
                }

                if (exaltLoaded)
                {
                    if (exaltMod.TryFind("Effulgence", out ModNPC Effulgence))
                    {
                        if (npc.type == Effulgence.Type && Effulgence.NPC.life <= 0)
                        {
                            downedEffulgence = true;
                        }
                    }
                    if (exaltMod.TryFind("IceLich", out ModNPC IceLich))
                    {
                        if (npc.type == IceLich.Type && IceLich.NPC.life <= 0)
                        {
                            downedIceLich = true;
                        }
                    }
                }

                if (fargosSoulsLoaded)
                {
                    if (fargosSoulsMod.TryFind("TrojanSquirrel", out ModNPC TrojanSquirrel))
                    {
                        if (npc.type == TrojanSquirrel.Type && TrojanSquirrel.NPC.life <= 0)
                        {
                            downedTrojanSquirrel = true;
                        }
                    }
                    if (fargosSoulsMod.TryFind("TrojanSquirrelPart", out ModNPC TrojanSquirrelPart))
                    {
                        if (npc.type == TrojanSquirrelPart.Type && TrojanSquirrelPart.NPC.life <= 0)
                        {
                            downedTrojanSquirrel = true;
                        }
                    }
                    if (fargosSoulsMod.TryFind("DeviBoss", out ModNPC DeviBoss))
                    {
                        if (npc.type == DeviBoss.Type && DeviBoss.NPC.life <= 0)
                        {
                            downedDeviant = true;
                        }
                    }
                    if (fargosSoulsMod.TryFind("LifeChallenger", out ModNPC LifeChallenger))
                    {
                        if (npc.type == LifeChallenger.Type && LifeChallenger.NPC.life <= 0)
                        {
                            downedLieflight = true;
                        }
                    }
                    if (fargosSoulsMod.TryFind("CosmosChampion", out ModNPC CosmosChampion))
                    {
                        if (npc.type == CosmosChampion.Type && CosmosChampion.NPC.life <= 0)
                        {
                            downedCosmosChampion = true;
                        }
                    }
                    if (fargosSoulsMod.TryFind("AbomBoss", out ModNPC AbomBoss))
                    {
                        if (npc.type == AbomBoss.Type && AbomBoss.NPC.life <= 0)
                        {
                            downedAbomination = true;
                        }
                    }
                    if (fargosSoulsMod.TryFind("MutantBoss", out ModNPC MutantBoss))
                    {
                        if (npc.type == MutantBoss.Type && MutantBoss.NPC.life <= 0)
                        {
                            downedMutant = true;
                        }
                    }
                }

                if (gmrLoaded)
                {
                    if (gmrMod.TryFind("Trerios", out ModNPC Trerios))
                    {
                        if (npc.type == Trerios.Type && Trerios.NPC.life <= 0)
                        {
                            downedTrerios = true;
                        }
                    }
                    if (gmrMod.TryFind("MagmaEye", out ModNPC MagmaEye))
                    {
                        if (npc.type == MagmaEye.Type && MagmaEye.NPC.life <= 0)
                        {
                            downedMagmaEye = true;
                        }
                    }
                    if (gmrMod.TryFind("Jack", out ModNPC Jack))
                    {
                        if (npc.type == Jack.Type && Jack.NPC.life <= 0)
                        {
                            downedJack = true;
                        }
                    }
                    if (gmrMod.TryFind("Acheron", out ModNPC Acheron))
                    {
                        if (npc.type == Acheron.Type && Acheron.NPC.life <= 0)
                        {
                            downedAcheron = true;
                        }
                    }
                }

                if (homewardLoaded)
                {
                    if (homewardMod.TryFind("MarquisMoonsquid", out ModNPC MarquisMoonsquid))
                    {
                        if (npc.type == MarquisMoonsquid.Type && MarquisMoonsquid.NPC.life <= 0)
                        {
                            downedSquid = true;
                        }
                    }
                    if (homewardMod.TryFind("PriestessRod", out ModNPC PriestessRod))
                    {
                        if (npc.type == PriestessRod.Type && PriestessRod.NPC.life <= 0)
                        {
                            downedRod = true;
                        }
                    }
                    if (homewardMod.TryFind("Diver", out ModNPC Diver))
                    {
                        if (npc.type == Diver.Type && Diver.NPC.life <= 0)
                        {
                            downedDiver = true;
                        }
                    }
                    if (homewardMod.TryFind("TheMotherbrain", out ModNPC TheMotherbrain))
                    {
                        if (npc.type == TheMotherbrain.Type && TheMotherbrain.NPC.life <= 0)
                        {
                            downedMotherbrain = true;
                        }
                    }
                    if (homewardMod.TryFind("WallofShadow", out ModNPC WallofShadow))
                    {
                        if (npc.type == WallofShadow.Type && WallofShadow.NPC.life <= 0)
                        {
                            downedWoS = true;
                        }
                    }
                    if (homewardMod.TryFind("SlimeGod", out ModNPC SlimeGod))
                    {
                        if (npc.type == SlimeGod.Type && SlimeGod.NPC.life <= 0)
                        {
                            downedSGod = true;
                        }
                    }
                    if (homewardMod.TryFind("TheOverwatcher", out ModNPC TheOverwatcher))
                    {
                        if (npc.type == TheOverwatcher.Type && TheOverwatcher.NPC.life <= 0)
                        {
                            downedOverwatcher = true;
                        }
                    }
                    if (homewardMod.TryFind("TheLifebringerHead", out ModNPC TheLifebringerHead))
                    {
                        if (npc.type == TheLifebringerHead.Type && TheLifebringerHead.NPC.life <= 0)
                        {
                            downedLifebringer = true;
                        }
                    }
                    if (homewardMod.TryFind("TheMaterealizer", out ModNPC TheMaterealizer))
                    {
                        if (npc.type == TheMaterealizer.Type && TheMaterealizer.NPC.life <= 0)
                        {
                            downedMaterealizer = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Cave", out ModNPC Trial_Cave))
                    {
                        if (npc.type == Trial_Cave.Type && Trial_Cave.NPC.life <= 0)
                        {
                            downedCaveOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Corruption", out ModNPC Trial_Corruption))
                    {
                        if (npc.type == Trial_Corruption.Type && Trial_Corruption.NPC.life <= 0)
                        {
                            downedCorruptOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Crimson", out ModNPC Trial_Crimson))
                    {
                        if (npc.type == Trial_Crimson.Type && Trial_Crimson.NPC.life <= 0)
                        {
                            downedCrimsonOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Desert", out ModNPC Trial_Desert))
                    {
                        if (npc.type == Trial_Desert.Type && Trial_Desert.NPC.life <= 0)
                        {
                            downedDesertOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Forest", out ModNPC Trial_Forest))
                    {
                        if (npc.type == Trial_Forest.Type && Trial_Forest.NPC.life <= 0)
                        {
                            downedForestOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Hallow", out ModNPC Trial_Hallow))
                    {
                        if (npc.type == Trial_Hallow.Type && Trial_Hallow.NPC.life <= 0)
                        {
                            downedHallowOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Jungle", out ModNPC Trial_Jungle))
                    {
                        if (npc.type == Trial_Jungle.Type && Trial_Jungle.NPC.life <= 0)
                        {
                            downedJungleOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Pure", out ModNPC Trial_Pure))
                    {
                        if (npc.type == Trial_Pure.Type && Trial_Pure.NPC.life <= 0)
                        {
                            downedSkyOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Snow", out ModNPC Trial_Snow))
                    {
                        if (npc.type == Trial_Snow.Type && Trial_Snow.NPC.life <= 0)
                        {
                            downedSnowOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("Trial_Underworld", out ModNPC Trial_Underworld))
                    {
                        if (npc.type == Trial_Underworld.Type && Trial_Underworld.NPC.life <= 0)
                        {
                            downedUnderworldOrdeal = true;
                        }
                    }
                    if (homewardMod.TryFind("ScarabBelief", out ModNPC ScarabBelief))
                    {
                        if (npc.type == ScarabBelief.Type && ScarabBelief.NPC.life <= 0)
                        {
                            downedScarab = true;
                        }
                    }
                    if (homewardMod.TryFind("WorldsEndEverlastingFallingWhale", out ModNPC WorldsEndEverlastingFallingWhale))
                    {
                        if (npc.type == WorldsEndEverlastingFallingWhale.Type && WorldsEndEverlastingFallingWhale.NPC.life <= 0)
                        {
                            downedWhale = true;
                        }
                    }
                    if (homewardMod.TryFind("TheSon", out ModNPC TheSon))
                    {
                        if (npc.type == TheSon.Type && TheSon.NPC.life <= 0)
                        {
                            downedSon = true;
                        }
                    }
                }

                if (huntLoaded)
                {
                    if (huntMod.TryFind("Goozma", out ModNPC Goozma))
                    {
                        if (npc.type == Goozma.Type && Goozma.NPC.life <= 0)
                        {
                            downedGoozma = true;
                        }
                    }
                }

                if (infernumLoaded)
                {
                    if (infernumMod.TryFind("BereftVassal", out ModNPC BereftVassal))
                    {
                        if (npc.type == BereftVassal.Type && BereftVassal.NPC.life <= 0)
                        {
                            downedVassal = true;
                        }
                    }
                }
               
                if (polaritiesLoaded)
                {
                    if (polaritiesMod.TryFind("StormCloudfish", out ModNPC StormCloudfish))
                    {
                        if (npc.type == StormCloudfish.Type && StormCloudfish.NPC.life <= 0)
                        {
                            downedCloudfish = true;
                        }
                    }
                    if (polaritiesMod.TryFind("StarConstruct", out ModNPC StarConstruct))
                    {
                        if (npc.type == StarConstruct.Type && StarConstruct.NPC.life <= 0)
                        {
                            downedConstruct = true;
                        }
                    }
                    if (polaritiesMod.TryFind("Gigabat", out ModNPC Gigabat))
                    {
                        if (npc.type == Gigabat.Type && Gigabat.NPC.life <= 0)
                        {
                            downedGigabat = true;
                        }
                    }
                    if (polaritiesMod.TryFind("SunPixie", out ModNPC SunPixie))
                    {
                        if (npc.type == SunPixie.Type && SunPixie.NPC.life <= 0)
                        {
                            downedSunPixie = true;
                        }
                    }
                    if (polaritiesMod.TryFind("Esophage", out ModNPC Esophage))
                    {
                        if (npc.type == Esophage.Type && Esophage.NPC.life <= 0)
                        {
                            downedEsophage = true;
                        }
                    }
                    if (polaritiesMod.TryFind("ConvectiveWanderer", out ModNPC ConvectiveWanderer))
                    {
                        if (npc.type == ConvectiveWanderer.Type && ConvectiveWanderer.NPC.life <= 0)
                        {
                            downedWanderer = true;
                        }
                    }
                }

                if (qwertyLoaded)
                {
                    if (qwertyMod.TryFind("PolarBear", out ModNPC PolarBear))
                    {
                        if (npc.type == PolarBear.Type && PolarBear.NPC.life <= 0)
                        {
                            downedPolarBear = true;
                        }
                    }
                    if (qwertyMod.TryFind("FortressBoss", out ModNPC FortressBoss))
                    {
                        if (npc.type == FortressBoss.Type && FortressBoss.NPC.life <= 0)
                        {
                            downedDivineLight = true;
                        }
                    }
                    if (qwertyMod.TryFind("AncientMachine", out ModNPC AncientMachine))
                    {
                        if (npc.type == AncientMachine.Type && AncientMachine.NPC.life <= 0)
                        {
                            downedAncientMachine = true;
                        }
                    }
                    if (qwertyMod.TryFind("CloakedDarkBoss", out ModNPC CloakedDarkBoss))
                    {
                        if (npc.type == CloakedDarkBoss.Type && CloakedDarkBoss.NPC.life <= 0)
                        {
                            downedNoehtnap = true;
                        }
                    }
                    if (qwertyMod.TryFind("Hydra", out ModNPC Hydra))
                    {
                        if (npc.type == Hydra.Type && Hydra.NPC.life <= 0)
                        {
                            downedHydra = true;
                        }
                    }
                    if (qwertyMod.TryFind("Imperious", out ModNPC Imperious))
                    {
                        if (npc.type == Imperious.Type && Imperious.NPC.life <= 0)
                        {
                            downedImperious = true;
                        }
                    }
                    if (qwertyMod.TryFind("RuneGhost", out ModNPC RuneGhost))
                    {
                        if (npc.type == RuneGhost.Type && RuneGhost.NPC.life <= 0)
                        {
                            downedRuneGhost = true;
                        }
                    }
                    if (qwertyMod.TryFind("OLORDv2", out ModNPC OLORDv2))
                    {
                        if (npc.type == OLORDv2.Type && OLORDv2.NPC.life <= 0)
                        {
                            downedOLORD = true;
                        }
                    }
                }
                
                if (redemptionLoaded)
                {
                    if (redemptionMod.TryFind("FowlEmperor", out ModNPC FowlEmperor))
                    {
                        if (npc.type == FowlEmperor.Type && FowlEmperor.NPC.life <= 0)
                        {
                            downedFowlEmperor = true;
                        }
                    }
                    if (redemptionMod.TryFind("Thorn", out ModNPC Thorn))
                    {
                        if (npc.type == Thorn.Type && Thorn.NPC.life <= 0)
                        {
                            downedThorn = true;
                        }
                    }
                    if (redemptionMod.TryFind("Erhan", out ModNPC Erhan))
                    {
                        if (npc.type == Erhan.Type && Erhan.NPC.life <= 0)
                        {
                            downedErhan = true;
                        }
                    }
                    if (redemptionMod.TryFind("Keeper", out ModNPC Keeper))
                    {
                        if (npc.type == Keeper.Type && Keeper.NPC.life <= 0)
                        {
                            downedKeeper = true;
                        }
                    }
                    if (redemptionMod.TryFind("SoI", out ModNPC SoI))
                    {
                        if (npc.type == SoI.Type && SoI.NPC.life <= 0)
                        {
                            downedSeed = true;
                        }
                    }
                    if (redemptionMod.TryFind("KS3", out ModNPC KS3))
                    {
                        if (npc.type == KS3.Type && KS3.NPC.life <= 0)
                        {
                            downedKS3 = true;
                        }
                    }
                    if (redemptionMod.TryFind("OmegaCleaver", out ModNPC OmegaCleaver))
                    {
                        if (npc.type == OmegaCleaver.Type && OmegaCleaver.NPC.life <= 0)
                        {
                            downedCleaver = true;
                        }
                    }
                    if (redemptionMod.TryFind("Gigapora", out ModNPC Gigapora))
                    {
                        if (npc.type == Gigapora.Type && Gigapora.NPC.life <= 0)
                        {
                            downedGigapora = true;
                        }
                    }
                    if (redemptionMod.TryFind("OO", out ModNPC OO))
                    {
                        if (npc.type == OO.Type && OO.NPC.life <= 0)
                        {
                            downedObliterator = true;
                        }
                    }
                    if (redemptionMod.TryFind("PZ", out ModNPC PZ))
                    {
                        if (npc.type == PZ.Type && PZ.NPC.life <= 0)
                        {
                            downedZero = true;
                        }
                    }
                    if (redemptionMod.TryFind("Akka", out ModNPC Akka))
                    {
                        if (npc.type == Akka.Type && Akka.NPC.life <= 0)
                        {
                            downedDuo = true;
                        }
                    }
                    if (redemptionMod.TryFind("Ukko", out ModNPC Ukko))
                    {
                        if (npc.type == Ukko.Type && Ukko.NPC.life <= 0)
                        {
                            downedDuo = true;
                        }
                    }
                    if (redemptionMod.TryFind("Nebuleus", out ModNPC Nebuleus))
                    {
                        if (npc.type == Nebuleus.Type && Nebuleus.NPC.life <= 0)
                        {
                            downedNebby = true;
                        }
                    }
                    if (redemptionMod.TryFind("Nebuleus2", out ModNPC Nebuleus2))
                    {
                        if (npc.type == Nebuleus2.Type && Nebuleus2.NPC.life <= 0)
                        {
                            downedNebby = true;
                        }
                    }
                    if (redemptionMod.TryFind("Basan", out ModNPC Basan))
                    {
                        if (npc.type == Basan.Type && Basan.NPC.life <= 0)
                        {
                            downedFowlMorning = true;
                        }
                    }
                    redemptionMod.TryFind("CorpseWalkerPriest", out ModNPC CorpseWalkerPriest);
                    redemptionMod.TryFind("DancingSkeleton", out ModNPC DancingSkeleton);
                    redemptionMod.TryFind("EpidotrianSkeleton", out ModNPC EpidotrianSkeleton);
                    redemptionMod.TryFind("JollyMadman", out ModNPC JollyMadman);
                    redemptionMod.TryFind("RaveyardSkeleton", out ModNPC RaveyardSkeleton);
                    redemptionMod.TryFind("SkeletonAssassin", out ModNPC SkeletonAssassin);
                    redemptionMod.TryFind("SkeletonDuelist", out ModNPC SkeletonDuelist);
                    redemptionMod.TryFind("SkeletonFlagbearer", out ModNPC SkeletonFlagbearer);
                    redemptionMod.TryFind("SkeletonNoble", out ModNPC SkeletonNoble);
                    redemptionMod.TryFind("SkeletonWanderer", out ModNPC SkeletonWanderer);
                    redemptionMod.TryFind("SkeletonWarden", out ModNPC SkeletonWarden);
                    if (CorpseWalkerPriest != null ||
                        DancingSkeleton != null ||
                        EpidotrianSkeleton != null ||
                        JollyMadman != null ||
                        RaveyardSkeleton != null ||
                        SkeletonAssassin != null ||
                        SkeletonDuelist != null ||
                        SkeletonFlagbearer != null ||
                        SkeletonNoble != null ||
                        SkeletonWanderer != null ||
                        SkeletonWarden != null)
                    {
                        if ((npc.type == CorpseWalkerPriest.Type && CorpseWalkerPriest.NPC.life <= 0)
                            || (npc.type == DancingSkeleton.Type && DancingSkeleton.NPC.life <= 0)
                            || (npc.type == EpidotrianSkeleton.Type && EpidotrianSkeleton.NPC.life <= 0)
                            || (npc.type == JollyMadman.Type && JollyMadman.NPC.life <= 0)
                            || (npc.type == RaveyardSkeleton.Type && RaveyardSkeleton.NPC.life <= 0)
                            || (npc.type == SkeletonAssassin.Type && SkeletonAssassin.NPC.life <= 0)
                            || (npc.type == SkeletonDuelist.Type && SkeletonDuelist.NPC.life <= 0)
                            || (npc.type == SkeletonFlagbearer.Type && SkeletonFlagbearer.NPC.life <= 0)
                            || (npc.type == SkeletonNoble.Type && SkeletonNoble.NPC.life <= 0)
                            || (npc.type == SkeletonWanderer.Type && SkeletonWanderer.NPC.life <= 0)
                            || (npc.type == SkeletonWarden.Type && SkeletonWarden.NPC.life <= 0))
                        {
                            downedRaveyard = true;
                        }
                    }
                }

                if (sotsLoaded)
                {
                    if (sotsMod.TryFind("Glowmoth", out ModNPC Glowmoth))
                    {
                        if (npc.type == Glowmoth.Type && Glowmoth.NPC.life <= 0)
                        {
                            downedGlowmoth = true;
                        }
                    }
                    if (sotsMod.TryFind("PutridPinkyPhase2", out ModNPC PutridPinkyPhase2))
                    {
                        if (npc.type == PutridPinkyPhase2.Type && PutridPinkyPhase2.NPC.life <= 0)
                        {
                            downedPutridPinky = true;
                        }
                    }
                    if (sotsMod.TryFind("PharaohsCurse", out ModNPC PharaohsCurse))
                    {
                        if (npc.type == PharaohsCurse.Type && PharaohsCurse.NPC.life <= 0)
                        {
                            downedPharaohsCurse = true;
                        }
                    }
                    /*
                    if (sotsMod.TryFind("TheAdvisorHead", out ModNPC TheAdvisorHead))
                    {
                        if (npc.type == TheAdvisorHead.Type && TheAdvisorHead.NPC.life <= 0)
                        {
                            downedAdvisor = true;
                        }
                    }
                    */
                    if (sotsMod.TryFind("Polaris", out ModNPC Polaris))
                    {
                        if (npc.type == Polaris.Type && Polaris.NPC.life <= 0)
                        {
                            downedPolaris = true;
                        }
                    }
                    if (sotsMod.TryFind("Lux", out ModNPC Lux))
                    {
                        if (npc.type == Lux.Type && Lux.NPC.life <= 0)
                        {
                            downedLux = true;
                        }
                    }
                    if (sotsMod.TryFind("SubspaceSerpentHead", out ModNPC SubspaceSerpentHead))
                    {
                        if (npc.type == SubspaceSerpentHead.Type && SubspaceSerpentHead.NPC.life <= 0)
                        {
                            downedSerpent = true;
                        }
                    }
                    if (sotsMod.TryFind("NatureConstruct", out ModNPC NatureConstruct))
                    {
                        if (npc.type == NatureConstruct.Type && NatureConstruct.NPC.life <= 0)
                        {
                            downedNatureConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("EarthenConstruct", out ModNPC EarthenConstruct))
                    {
                        if (npc.type == EarthenConstruct.Type && EarthenConstruct.NPC.life <= 0)
                        {
                            downedEarthenConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("PermafrostConstruct", out ModNPC PermafrostConstruct))
                    {
                        if (npc.type == PermafrostConstruct.Type && PermafrostConstruct.NPC.life <= 0)
                        {
                            downedPermafrostConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("TidalConstruct", out ModNPC TidalConstruct))
                    {
                        if (npc.type == TidalConstruct.Type && TidalConstruct.NPC.life <= 0)
                        {
                            downedTidalConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("OtherworldlyConstructHead", out ModNPC OtherworldlyConstructHead))
                    {
                        if (npc.type == OtherworldlyConstructHead.Type && OtherworldlyConstructHead.NPC.life <= 0)
                        {
                            downedOtherworldlyConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("OtherworldlyConstructHead2", out ModNPC OtherworldlyConstructHead2))
                    {
                        if (npc.type == OtherworldlyConstructHead2.Type && OtherworldlyConstructHead2.NPC.life <= 0)
                        {
                            downedOtherworldlyConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("EvilConstruct", out ModNPC EvilConstruct))
                    {
                        if (npc.type == EvilConstruct.Type && EvilConstruct.NPC.life <= 0)
                        {
                            downedEvilConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("InfernoConstruct", out ModNPC InfernoConstruct))
                    {
                        if (npc.type == InfernoConstruct.Type && InfernoConstruct.NPC.life <= 0)
                        {
                            downedInfernoConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("ChaosConstruct", out ModNPC ChaosConstruct))
                    {
                        if (npc.type == ChaosConstruct.Type && ChaosConstruct.NPC.life <= 0)
                        {
                            downedChaosConstruct = true;
                        }
                    }
                    if (sotsMod.TryFind("NatureSpirit", out ModNPC NatureSpirit))
                    {
                        if (npc.type == NatureSpirit.Type && NatureSpirit.NPC.life <= 0)
                        {
                            downedNatureSpirit = true;
                        }
                    }
                    if (sotsMod.TryFind("EarthenSpirit", out ModNPC EarthenSpirit))
                    {
                        if (npc.type == EarthenSpirit.Type && EarthenSpirit.NPC.life <= 0)
                        {
                            downedEarthenSpirit = true;
                        }
                    }
                    if (sotsMod.TryFind("PermafrostSpirit", out ModNPC PermafrostSpirit))
                    {
                        if (npc.type == PermafrostSpirit.Type && PermafrostSpirit.NPC.life <= 0)
                        {
                            downedPermafrostSpirit = true;
                        }
                    }
                    if (sotsMod.TryFind("TidalSpirit", out ModNPC TidalSpirit))
                    {
                        if (npc.type == TidalSpirit.Type && TidalSpirit.NPC.life <= 0)
                        {
                            downedTidalSpirit = true;
                        }
                    }
                    if (sotsMod.TryFind("EvilSpirit", out ModNPC EvilSpirit))
                    {
                        if (npc.type == EvilSpirit.Type && EvilSpirit.NPC.life <= 0)
                        {
                            downedEvilSpirit = true;
                        }
                    }
                    if (sotsMod.TryFind("InfernoSpirit", out ModNPC InfernoSpirit))
                    {
                        if (npc.type == InfernoSpirit.Type && InfernoSpirit.NPC.life <= 0)
                        {
                            downedInfernoSpirit = true;
                        }
                    }
                }

                if (spiritLoaded)
                {
                    if (spiritMod.TryFind("Scarabeus", out ModNPC Scarabeus))
                    {
                        if (npc.type == Scarabeus.Type && Scarabeus.NPC.life <= 0)
                        {
                            downedScarabeus = true;
                        }
                    }
                    if (spiritMod.TryFind("MoonWizard", out ModNPC MoonWizard))
                    {
                        if (npc.type == MoonWizard.Type && MoonWizard.NPC.life <= 0)
                        {
                            downedMoonJelly = true;
                            downedJellyDeluge = true;
                        }
                    }
                    if (spiritMod.TryFind("ReachBoss", out ModNPC ReachBoss))
                    {
                        if (npc.type == ReachBoss.Type && ReachBoss.NPC.life <= 0)
                        {
                            downedVinewrath = true;
                        }
                    }
                    if (spiritMod.TryFind("AncientFlyer", out ModNPC AncientFlyer))
                    {
                        if (npc.type == AncientFlyer.Type && AncientFlyer.NPC.life <= 0)
                        {
                            downedAvian = true;
                        }
                    }
                    if (spiritMod.TryFind("SteamRaiderHead", out ModNPC SteamRaiderHead))
                    {
                        if (npc.type == SteamRaiderHead.Type && SteamRaiderHead.NPC.life <= 0)
                        {
                            downedStarVoyager = true;
                        }
                    }
                    if (spiritMod.TryFind("Infernon", out ModNPC Infernon))
                    {
                        if (npc.type == Infernon.Type && Infernon.NPC.life <= 0)
                        {
                            downedInfernon = true;
                        }
                    }
                    if (spiritMod.TryFind("Dusking", out ModNPC Dusking))
                    {
                        if (npc.type == Dusking.Type && Dusking.NPC.life <= 0)
                        {
                            downedDusking = true;
                        }
                    }
                    if (spiritMod.TryFind("Atlas", out ModNPC Atlas))
                    {
                        if (npc.type == Atlas.Type && Atlas.NPC.life <= 0)
                        {
                            downedAtlas = true;
                        }
                    }
                    spiritMod.TryFind("MoonlightPreserver", out ModNPC MoonlightPreserver);
                    spiritMod.TryFind("ExplodingMoonjelly", out ModNPC ExplodingMoonjelly);
                    spiritMod.TryFind("MoonjellyGiant", out ModNPC MoonjellyGiant);
                    if (MoonlightPreserver != null ||
                        ExplodingMoonjelly != null ||
                        MoonjellyGiant != null)
                    {
                        if ((npc.type == MoonlightPreserver.Type && MoonlightPreserver.NPC.life <= 0)
                            || (npc.type == ExplodingMoonjelly.Type && ExplodingMoonjelly.NPC.life <= 0)
                            || (npc.type == MoonjellyGiant.Type && MoonjellyGiant.NPC.life <= 0))
                        {
                            downedJellyDeluge = true;
                        }
                    }
                    if (spiritMod.TryFind("Rylheian", out ModNPC Rylheian))
                    {
                        if (npc.type == Rylheian.Type && Rylheian.NPC.life <= 0)
                        {
                            downedTide = true;
                        }
                    }
                    spiritMod.TryFind("Bloomshroom", out ModNPC Bloomshroom);
                    spiritMod.TryFind("Glitterfly", out ModNPC Glitterfly);
                    spiritMod.TryFind("GlowToad", out ModNPC GlowToad);
                    spiritMod.TryFind("Lumantis", out ModNPC Lumantis);
                    spiritMod.TryFind("LunarSlime", out ModNPC LunarSlime);
                    spiritMod.TryFind("MadHatter", out ModNPC MadHatter);
                    if (Bloomshroom != null ||
                        Glitterfly != null ||
                        GlowToad != null ||
                        Lumantis != null ||
                        LunarSlime != null ||
                        MadHatter != null)
                    {
                        if ((npc.type == Bloomshroom.Type && Bloomshroom.NPC.life <= 0)
                            || (npc.type == Glitterfly.Type && Glitterfly.NPC.life <= 0)
                            || (npc.type == GlowToad.Type && GlowToad.NPC.life <= 0)
                            || (npc.type == Lumantis.Type && Lumantis.NPC.life <= 0)
                            || (npc.type == LunarSlime.Type && LunarSlime.NPC.life <= 0)
                            || (npc.type == MadHatter.Type && MadHatter.NPC.life <= 0))
                        {
                            downedMysticMoon = true;
                        }
                    }
                }

                if (spookyLoaded)
                {
                    if (spookyMod.TryFind("SpookySpirit", out ModNPC SpookySpirit))
                    {
                        if (npc.type == SpookySpirit.Type && SpookySpirit.NPC.life <= 0)
                        {
                            downedSpookySpirit = true;
                        }
                    }
                    if (spookyMod.TryFind("RotGourd", out ModNPC RotGourd))
                    {
                        if (npc.type == RotGourd.Type && RotGourd.NPC.life <= 0)
                        {
                            downedGourd = true;
                        }
                    }
                    if (spookyMod.TryFind("Moco", out ModNPC Moco))
                    {
                        if (npc.type == Moco.Type && Moco.NPC.life <= 0)
                        {
                            downedMoco = true;
                        }
                    }
                    if (spookyMod.TryFind("OrroHead", out ModNPC OrroHead))
                    {
                        if (npc.type == OrroHead.Type && OrroHead.NPC.life <= 0)
                        {
                            downedOrro = true;
                        }
                    }
                    if (spookyMod.TryFind("BoroHead", out ModNPC BoroHead))
                    {
                        if (npc.type == BoroHead.Type && BoroHead.NPC.life <= 0)
                        {
                            downedBoro = true;
                        }
                    }
                    if (spookyMod.TryFind("BigBone", out ModNPC BigBone))
                    {
                        if (npc.type == BigBone.Type && BigBone.NPC.life <= 0)
                        {
                            downedBigBone = true;
                        }
                    }
                }
                
                if (stormLoaded)
                {
                    if (stormMod.TryFind("AridBoss", out ModNPC AridBoss))
                    {
                        if (npc.type == AridBoss.Type && AridBoss.NPC.life <= 0)
                        {
                            downedArid = true;
                        }
                    }
                    if (stormMod.TryFind("StormBoss", out ModNPC StormBoss))
                    {
                        if (npc.type == StormBoss.Type && StormBoss.NPC.life <= 0)
                        {
                            downedStorm = true;
                        }
                    }
                    if (stormMod.TryFind("TheUltimateBoss", out ModNPC TheUltimateBoss))
                    {
                        if (npc.type == TheUltimateBoss.Type && TheUltimateBoss.NPC.life <= 0)
                        {
                            downedPainbringer = true;
                        }
                    }
                }

                if (terrorbornLoaded)
                {
                    if (terrorbornMod.TryFind("InfectedIncarnate", out ModNPC InfectedIncarnate))
                    {
                        if (npc.type == InfectedIncarnate.Type && InfectedIncarnate.NPC.life <= 0)
                        {
                            downedIncarnate = true;
                        }
                    }
                    if (terrorbornMod.TryFind("TidalTitan", out ModNPC TidalTitan))
                    {
                        if (npc.type == TidalTitan.Type && TidalTitan.NPC.life <= 0)
                        {
                            downedTitan = true;
                        }
                    }
                    if (terrorbornMod.TryFind("Dunestock", out ModNPC Dunestock))
                    {
                        if (npc.type == Dunestock.Type && Dunestock.NPC.life <= 0)
                        {
                            downedDunestock = true;
                        }
                    }
                    if (terrorbornMod.TryFind("Shadowcrawler", out ModNPC Shadowcrawler))
                    {
                        if (npc.type == Shadowcrawler.Type && Shadowcrawler.NPC.life <= 0)
                        {
                            downedCrawler = true;
                        }
                    }
                    if (terrorbornMod.TryFind("HexedConstructor", out ModNPC HexedConstructor))
                    {
                        if (npc.type == HexedConstructor.Type && HexedConstructor.NPC.life <= 0)
                        {
                            downedConstructor = true;
                        }
                    }
                    if (terrorbornMod.TryFind("PrototypeI", out ModNPC PrototypeI))
                    {
                        if (npc.type == PrototypeI.Type && PrototypeI.NPC.life <= 0)
                        {
                            downedP1 = true;
                        }
                    }
                }

                if (thoriumLoaded)
                {
                    /*
                    if (thoriumMod.TryFind("TheGrandThunderBirdv2", out ModNPC TheGrandThunderBirdv2))
                    {
                        if (npc.type == TheGrandThunderBirdv2.Type && TheGrandThunderBirdv2.NPC.life <= 0)
                        {
                            downedGrandBird = true;
                        }
                    }
                    if (thoriumMod.TryFind("QueenJelly", out ModNPC QueenJelly))
                    {
                        if (npc.type == QueenJelly.Type && QueenJelly.NPC.life <= 0)
                        {
                            downedQueenJelly = true;
                        }
                    }
                    if (thoriumMod.TryFind("Viscount", out ModNPC Viscount))
                    {
                        if (npc.type == Viscount.Type && Viscount.NPC.life <= 0)
                        {
                            downedViscount = true;
                        }
                    }
                    if (thoriumMod.TryFind("GraniteEnergyStorm", out ModNPC GraniteEnergyStorm))
                    {
                        if (npc.type == GraniteEnergyStorm.Type && GraniteEnergyStorm.NPC.life <= 0)
                        {
                            downedEnergyStorm = true;
                        }
                    }
                    if (thoriumMod.TryFind("TheBuriedWarrior", out ModNPC TheBuriedWarrior))
                    {
                        if (npc.type == TheBuriedWarrior.Type && TheBuriedWarrior.NPC.life <= 0)
                        {
                            downedBuriedChampion = true;
                        }
                    }
                    if (thoriumMod.TryFind("ThePrimeScouter", out ModNPC ThePrimeScouter))
                    {
                        if (npc.type == ThePrimeScouter.Type && ThePrimeScouter.NPC.life <= 0)
                        {
                            downedScouter = true;
                        }
                    }
                    if (thoriumMod.TryFind("BoreanStriderPopped", out ModNPC BoreanStriderPopped))
                    {
                        if (npc.type == BoreanStriderPopped.Type && BoreanStriderPopped.NPC.life <= 0)
                        {
                            downedStrider = true;
                        }
                    }
                    if (thoriumMod.TryFind("FallenDeathBeholder2", out ModNPC FallenDeathBeholder2))
                    {
                        if (npc.type == FallenDeathBeholder2.Type && FallenDeathBeholder2.NPC.life <= 0)
                        {
                            downedFallenBeholder = true;
                        }
                    }
                    if (thoriumMod.TryFind("LichHeadless", out ModNPC LichHeadless))
                    {
                        if (npc.type == LichHeadless.Type && LichHeadless.NPC.life <= 0)
                        {
                            downedLich = true;
                        }
                    }
                    if (thoriumMod.TryFind("AbyssionReleased", out ModNPC AbyssionReleased))
                    {
                        if (npc.type == AbyssionReleased.Type && AbyssionReleased.NPC.life <= 0)
                        {
                            downedForgottenOne = true;
                        }
                    }
                    if (thoriumMod.TryFind("RealityBreaker", out ModNPC RealityBreaker))
                    {
                        if (npc.type == RealityBreaker.Type && RealityBreaker.NPC.life <= 0)
                        {
                            downedPrimordials = true;
                        }
                    }
                    */
                }

                if (vitalityLoaded)
                {
                    if (vitalityMod.TryFind("StormCloudBoss", out ModNPC StormCloudBoss))
                    {
                        if (npc.type == StormCloudBoss.Type && StormCloudBoss.NPC.life <= 0)
                        {
                            downedStormCloud = true;
                        }
                    }
                    if (vitalityMod.TryFind("GrandAntlionBoss", out ModNPC GrandAntlionBoss))
                    {
                        if (npc.type == GrandAntlionBoss.Type && GrandAntlionBoss.NPC.life <= 0)
                        {
                            downedGrandAntlion = true;
                        }
                    }
                    if (vitalityMod.TryFind("GemstoneElementalBoss", out ModNPC GemstoneElementalBoss))
                    {
                        if (npc.type == GemstoneElementalBoss.Type && GemstoneElementalBoss.NPC.life <= 0)
                        {
                            downedGemstoneElemental = true;
                        }
                    }
                    if (vitalityMod.TryFind("MoonlightDragonflyBoss", out ModNPC MoonlightDragonflyBoss))
                    {
                        if (npc.type == MoonlightDragonflyBoss.Type && MoonlightDragonflyBoss.NPC.life <= 0)
                        {
                            downedMoonlightDragonfly = true;
                        }
                    }
                    if (vitalityMod.TryFind("DreadnaughtBoss", out ModNPC DreadnaughtBoss))
                    {
                        if (npc.type == DreadnaughtBoss.Type && DreadnaughtBoss.NPC.life <= 0)
                        {
                            downedDreadnaught = true;
                        }
                    }
                    if (vitalityMod.TryFind("AnarchulesBeetleBoss", out ModNPC AnarchulesBeetleBoss))
                    {
                        if (npc.type == AnarchulesBeetleBoss.Type && AnarchulesBeetleBoss.NPC.life <= 0)
                        {
                            downedAnarchulesBeetle = true;
                        }
                    }
                    if (vitalityMod.TryFind("ChaosbringerBoss", out ModNPC ChaosbringerBoss))
                    {
                        if (npc.type == ChaosbringerBoss.Type && ChaosbringerBoss.NPC.life <= 0)
                        {
                            downedChaosbringer = true;
                        }
                    }
                    if (vitalityMod.TryFind("PaladinSpiritBoss", out ModNPC PaladinSpiritBoss))
                    {
                        if (npc.type == PaladinSpiritBoss.Type && PaladinSpiritBoss.NPC.life <= 0)
                        {
                            downedPaladinSpirit = true;
                        }
                    }
                }
            }
        }

        public static void ResetDowned()
        {
            //VANILLA
            downedBloodMoon = false;
            downedEclipse = false;
            //BIOMES
            beenToPurity = false;
            beenToCavernsOrUnderground = false;
            beenToUnderworld = false;
            beenToSky = false;
            beenToSnow = false;
            beenToOcean = false;
            beenToJungle = false;
            beenToMushroom = false;
            beenToCorruption = false;
            beenToCrimson = false;
            beenToHallow = false;
            beenToTemple = false;
            beenToDungeon = false;

            //AEQUUS
            downedCrabson = false;
            downedOmegaStarite = false;
            downedDevil = false;
            downedSprite = false;
            downedSpaceSquid = false;
            downedHyperStarite = false;
            downedUltraStarite = false;
            //EVENTS
            downedDemonSiege = false;
            downedGlimmer = false;
            downedGaleStreams = false;

            //CALAMITY
            downedDesertScourge = false;
            downedCrabulon = false;
            downedHiveMind = false;
            downedPerforators = false;
            downedSlimeGod = false;
            downedCryogen = false;
            downedAquaticScourge = false;
            downedBrimstoneElemental = false;
            downedCalamitas = false;
            downedLeviathan = false;
            downedAureus = false;
            downedPlaguebringer = false;
            downedRavager = false;
            downedDeus = false;
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

            //CATALYST
            downedGeldon = false;

            //CONSOLARIA
            downedLepus = false;
            downedTurkor = false;
            downedOcram = false;

            //ECHOES OF THE ANCIENTS
            downedGalahis = false;
            downedCreation = false;
            downedDestruction = false;

            //EXALT
            downedEffulgence = false;
            downedIceLich = false;

            //FARGOS SOULS
            downedTrojanSquirrel = false;
            downedDeviant = false;
            downedCosmosChampion = false;
            downedAbomination = false;
            downedMutant = false;

            //GMR
            downedTrerios = false;
            downedMagmaEye = false;
            downedJack = false;
            downedAcheron = false;

            //HOMEWARD JOURNEY
            downedSquid = false;
            downedRod = false;
            downedDiver = false;
            downedMotherbrain = false;
            downedWoS = false;
            downedSGod = false;
            downedOverwatcher = false;
            downedLifebringer = false;
            downedMaterealizer = false;
            downedScarab = false;
            downedWhale = false;
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

            //HUNT OF THE OLD GOD
            downedGoozma = false;

            //INFERNUM
            downedVassal = false;

            //POLARITIES
            downedCloudfish = false;
            downedConstruct = false;
            downedGigabat = false;
            downedSunPixie = false;
            downedEsophage = false;
            downedWanderer = false;

            //QWERTY
            downedPolarBear = false;
            downedDivineLight = false;
            downedAncientMachine = false;
            downedNoehtnap = false;
            downedHydra = false;
            downedImperious = false;
            downedRuneGhost = false;
            downedOLORD = false;

            //REDEMPTION
            downedFowlEmperor = false;
            downedThorn = false;
            downedErhan = false;
            downedKeeper = false;
            downedSeed = false;
            downedKS3 = false;
            downedCleaver = false;
            downedGigapora = false;
            downedObliterator = false;
            downedZero = false;
            downedDuo = false;
            downedNebby = false;
            //EVENTS
            downedFowlMorning = false;
            downedRaveyard = false;

            //SOTS
            downedGlowmoth = false;
            downedPutridPinky = false;
            downedPharaohsCurse = false;
            downedAdvisor = false;
            downedPolaris = false;
            downedLux = false;
            downedSerpent = false;
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

            //SPIRIT
            downedScarabeus = false;
            downedMoonJelly = false;
            downedVinewrath = false;
            downedAvian = false;
            downedStarVoyager = false;
            downedInfernon = false;
            downedDusking = false;
            downedAtlas = false;
            //EVENTS
            downedJellyDeluge = false;
            downedTide = false;
            downedMysticMoon = false;

            //SPOOKY
            downedSpookySpirit = false;
            downedGourd = false;
            downedMoco = false;
            downedOrroBoro = false;
            downedOrro = false;
            downedBoro = false;
            downedBigBone = false;

            //STORM DIVERS MOD
            downedArid = false;
            downedStorm = false;
            downedPainbringer = false;

            //TERRORBORN
            downedIncarnate = false;
            downedTitan = false;
            downedDunestock = false;
            downedCrawler = false;
            downedConstructor = false;
            downedP1 = false;

            //THORIUM
            downedGrandBird = false;
            downedQueenJelly = false;
            downedViscount = false;
            downedEnergyStorm = false;
            downedBuriedChampion = false;
            downedStrider = false;
            downedFallenBeholder = false;
            downedLich = false;
            downedForgottenOne = false;
            downedPrimordials = false;
            downedPatchWerk = false;
            downedCorpseBloom = false;
            downedIllusionist = false;
            //BIOMES
            beenToAquaticDepths = false;

            //VITALITY
            downedStormCloud = false;
            downedGrandAntlion = false;
            downedGemstoneElemental = false;
            downedMoonlightDragonfly = false;
            downedDreadnaught = false;
            downedAnarchulesBeetle = false;
            downedChaosbringer = false;
            downedPaladinSpirit = false;
        }
    }
}