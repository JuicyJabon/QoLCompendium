using System.ComponentModel;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Tweaks
{
    public class CheckDowned : ModSystem
    {
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


        //CATALYST
        internal static bool catalystLoaded;
        internal static Mod catalystMod;
        internal static bool downedGeldon;
        public static Condition geldon = new("CheckDowned.downedGeldon", () => downedGeldon);


        //INFERNUM
        internal static bool infernumLoaded;
        internal static Mod infernumMod;
        internal static bool downedVassal;
        public static Condition vassal = new("CheckDowned.downedVassal", () => downedVassal);


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


        //REDEMPTION
        internal static bool redemptionLoaded;
        internal static Mod redemptionMod;
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


        //SECRETS OF THE SHADOWS
        internal static bool sotsLoaded;
        internal static Mod sotsMod;
        internal static bool downedPutridPinky;
        public static Condition putridpinky = new("CheckDowned.downedPutridPinky", () => downedPutridPinky);
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


        //FARGOS SOULS
        internal static bool fargosSoulsLoaded;
        internal static Mod fargosSoulsMod;
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
        internal static bool downedUltraStarite;
        public static Condition ultrastarite = new("CheckDowned.downedUltraStarite", () => downedUltraStarite);


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
        public static Condition orroboro = new("CheckDowned.downedOrroBoro", () => downedOrroBoro);
        internal static bool downedBigBone;
        public static Condition bigbone = new("CheckDowned.downedBigBone", () => downedBigBone);


        //CONSOLARIA
        internal static bool consolariaLoaded;
        internal static Mod consolariaMod;
        internal static bool downedLepus;
        public static Condition lepus = new("CheckDowned.downedLepus", () => downedLepus);
        internal static bool downedTurkor;
        public static Condition turkor = new("CheckDowned.downedTurkor", () => downedTurkor);
        internal static bool downedOcram;
        public static Condition ocram = new("CheckDowned.downedOcram", () => downedOcram);


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

        public override void Unload()
        {
            if (!calamityLoaded)
            {
                calamityMod = null;
            }
            if (!catalystLoaded)
            {
                catalystMod = null;
            }
            if (!infernumLoaded)
            {
                infernumMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!spiritLoaded)
            {
                spiritMod = null;
            }
            if (!redemptionLoaded)
            {
                redemptionMod = null;
            }
            if (!sotsLoaded)
            {
                sotsMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!homewardLoaded)
            {
                homewardMod = null;
            }
            if (!aqLoaded)
            {
                aqMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!polaritiesLoaded)
            {
                polaritiesMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
        }

        public override void Load()
        {
            if (!calamityLoaded)
            {
                calamityMod = null;
            }
            if (!catalystLoaded)
            {
                catalystMod = null;
            }
            if (!infernumLoaded)
            {
                infernumMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!spiritLoaded)
            {
                spiritMod = null;
            }
            if (!redemptionLoaded)
            {
                redemptionMod = null;
            }
            if (!sotsLoaded)
            {
                sotsMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!homewardLoaded)
            {
                homewardMod = null;
            }
            if (!aqLoaded)
            {
                aqMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!polaritiesLoaded)
            {
                polaritiesMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
        }

        public override void PostSetupContent()
        {
            calamityLoaded = ModLoader.TryGetMod("CalamityMod", out Mod calamity);
            calamityMod = calamity;

            catalystLoaded = ModLoader.TryGetMod("CatalystMod", out Mod catalyst);
            catalystMod = catalyst;

            infernumLoaded = ModLoader.TryGetMod("InfernumMode", out Mod infernum);
            infernumMod = infernum;

            thoriumLoaded = ModLoader.TryGetMod("ThoriumMod", out Mod thorium);
            thoriumMod = thorium;

            spiritLoaded = ModLoader.TryGetMod("SpiritMod", out Mod spirit);
            spiritMod = spirit;

            redemptionLoaded = ModLoader.TryGetMod("Redemption", out Mod redemption);
            redemptionMod = redemption;

            sotsLoaded = ModLoader.TryGetMod("SOTS", out Mod sots);
            sotsMod = sots;

            fargosSoulsLoaded = ModLoader.TryGetMod("FargowiltasSouls", out Mod souls);
            fargosSoulsMod = souls;

            homewardLoaded = ModLoader.TryGetMod("ContinentOfJourney", out Mod homeward);
            homewardMod = homeward;

            aqLoaded = ModLoader.TryGetMod("Aequus", out Mod aequus);
            aqMod = aequus;

            spookyLoaded = ModLoader.TryGetMod("Spooky", out Mod spooky);
            spookyMod = spooky;

            consolariaLoaded = ModLoader.TryGetMod("Consolaria", out Mod consolaria);
            consolariaMod = consolaria;

            polaritiesLoaded = ModLoader.TryGetMod("Polarities", out Mod polarities);
            polaritiesMod = polarities;

            vitalityLoaded = ModLoader.TryGetMod("VitalityMod", out Mod vitality);
            vitalityMod = vitality;

            terrorbornLoaded = ModLoader.TryGetMod("TerrorbornMod", out Mod terrorborn);
            terrorbornMod = terrorborn;
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

            //CATALYST
            tag.Add("downedGeldon", downedGeldon);

            //INFERNUM
            tag.Add("downedVassal", downedVassal);

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

            //SPIRIT
            tag.Add("downedScarabeus", downedScarabeus);
            tag.Add("downedMoonJelly", downedMoonJelly);
            tag.Add("downedVinewrath", downedVinewrath);
            tag.Add("downedAvian", downedAvian);
            tag.Add("downedStarVoyager", downedStarVoyager);
            tag.Add("downedInfernon", downedInfernon);
            tag.Add("downedDusking", downedDusking);
            tag.Add("downedAtlas", downedAtlas);

            //REDEMPTION
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

            //SOTS
            tag.Add("downedPutridPinky", downedPutridPinky);
            tag.Add("downedPharaohsCurse", downedPharaohsCurse);
            tag.Add("downedAdvisor", downedAdvisor);
            tag.Add("downedPolaris", downedPolaris);
            tag.Add("downedLux", downedLux);
            tag.Add("downedSerpent", downedSerpent);

            //SOULS
            tag.Add("downedTrojanSquirrel", downedTrojanSquirrel);
            tag.Add("downedDeviant", downedDeviant);
            tag.Add("downedCosmosChampion", downedCosmosChampion);
            tag.Add("downedAbomination", downedAbomination);
            tag.Add("downedMutant", downedMutant);

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

            //AEQUUS
            tag.Add("downedCrabson", downedCrabson);
            tag.Add("downedOmegaStarite", downedOmegaStarite);
            tag.Add("downedDevil", downedDevil);
            tag.Add("downedSprite", downedSprite);
            tag.Add("downedSpaceSquid", downedSpaceSquid);
            tag.Add("downedUltraStarite", downedUltraStarite);

            //SPOOKY
            tag.Add("downedSpookySpirit", downedSpookySpirit);
            tag.Add("downedGourd", downedGourd);
            tag.Add("downedMoco", downedMoco);
            tag.Add("downedOrroBoro", downedOrroBoro);
            tag.Add("downedBigBone", downedBigBone);

            //CONSOLARIA
            tag.Add("downedLepus", downedLepus);
            tag.Add("downedTurkor", downedTurkor);
            tag.Add("downedOcram", downedOcram);

            //POLARITIES
            tag.Add("downedCloudfish", downedCloudfish);
            tag.Add("downedConstruct", downedConstruct);
            tag.Add("downedGigabat", downedGigabat);
            tag.Add("downedSunPixie", downedSunPixie);
            tag.Add("downedEsophage", downedEsophage);
            tag.Add("downedWanderer", downedWanderer);

            //VITALITY
            tag.Add("downedStormCloud", downedStormCloud);
            tag.Add("downedGrandAntlion", downedGrandAntlion);
            tag.Add("downedGemstoneElemental", downedGemstoneElemental);
            tag.Add("downedMoonlightDragonfly", downedMoonlightDragonfly);
            tag.Add("downedDreadnaught", downedDreadnaught);
            tag.Add("downedAnarchulesBeetle", downedAnarchulesBeetle);
            tag.Add("downedChaosbringer", downedChaosbringer);
            tag.Add("downedPaladinSpirit", downedPaladinSpirit);

            //TERRORBORN
            tag.Add("downedIncarnate", downedIncarnate);
            tag.Add("downedTitan", downedTitan);
            tag.Add("downedDunestock", downedDunestock);
            tag.Add("downedCrawler", downedCrawler);
            tag.Add("downedConstructor", downedConstructor);
            tag.Add("downedP1", downedP1);
        }

        public override void LoadWorldData(TagCompound tag)
        {
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

            //CATALYST
            downedGeldon = tag.Get<bool>("downedGeldon");

            //INFERNUM
            downedVassal = tag.Get<bool>("downedVassal");

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

            //SPIRIT
            downedScarabeus = tag.Get<bool>("downedScarabeus");
            downedMoonJelly = tag.Get<bool>("downedMoonJelly");
            downedVinewrath = tag.Get<bool>("downedVinewrath");
            downedAvian = tag.Get<bool>("downedAvian");
            downedStarVoyager = tag.Get<bool>("downedStarVoyager");
            downedInfernon = tag.Get<bool>("downedInfernon");
            downedDusking = tag.Get<bool>("downedDusking");
            downedAtlas = tag.Get<bool>("downedAtlas");
            downedAtlas = tag.Get<bool>("downedAtlas");

            //REDEMPTION
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

            //SOTS
            downedPutridPinky = tag.Get<bool>("downedPutridPinky");
            downedPharaohsCurse = tag.Get<bool>("downedPharaohsCurse");
            downedAdvisor = tag.Get<bool>("downedAdvisor");
            downedPolaris = tag.Get<bool>("downedPolaris");
            downedLux = tag.Get<bool>("downedLux");
            downedSerpent = tag.Get<bool>("downedSerpent");

            //SOULS
            downedTrojanSquirrel = tag.Get<bool>("downedTrojanSquirrel");
            downedDeviant = tag.Get<bool>("downedDeviant");
            downedCosmosChampion = tag.Get<bool>("downedCosmosChampion");
            downedAbomination = tag.Get<bool>("downedAbomination");
            downedMutant = tag.Get<bool>("downedMutant");

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

            //AEQUUS
            downedCrabson = tag.Get<bool>("downedCrabson");
            downedOmegaStarite = tag.Get<bool>("downedOmegaStarite");
            downedDevil = tag.Get<bool>("downedDevil");
            downedSprite = tag.Get<bool>("downedSprite");
            downedSpaceSquid = tag.Get<bool>("downedSpaceSquid");
            downedUltraStarite = tag.Get<bool>("downedUltraStarite");

            //SPOOKY
            downedSpookySpirit = tag.Get<bool>("downedSpookySpirit");
            downedGourd = tag.Get<bool>("downedGourd");
            downedMoco = tag.Get<bool>("downedMoco");
            downedOrroBoro = tag.Get<bool>("downedOrroBoro");
            downedBigBone = tag.Get<bool>("downedBigBone");

            //CONSOLARIA
            downedLepus = tag.Get<bool>("downedLepus");
            downedTurkor = tag.Get<bool>("downedTurkor");
            downedOcram = tag.Get<bool>("downedOcram");

            //POLARITIES
            downedCloudfish = tag.Get<bool>("downedCloudfish");
            downedConstruct = tag.Get<bool>("downedConstruct");
            downedGigabat = tag.Get<bool>("downedGigabat");
            downedSunPixie = tag.Get<bool>("downedSunPixie");
            downedEsophage = tag.Get<bool>("downedEsophage");
            downedWanderer = tag.Get<bool>("downedWanderer");

            //VITALITY
            downedStormCloud = tag.Get<bool>("downedStormCloud");
            downedGrandAntlion = tag.Get<bool>("downedGrandAntlion");
            downedGemstoneElemental = tag.Get<bool>("downedGemstoneElemental");
            downedMoonlightDragonfly = tag.Get<bool>("downedMoonlightDragonfly");
            downedDreadnaught = tag.Get<bool>("downedDreadnaught");
            downedAnarchulesBeetle = tag.Get<bool>("downedAnarchulesBeetle");
            downedChaosbringer = tag.Get<bool>("downedChaosbringer");
            downedPaladinSpirit = tag.Get<bool>("downedPaladinSpirit");

            //TERRORBORN
            downedIncarnate = tag.Get<bool>("downedIncarnate");
            downedTitan = tag.Get<bool>("downedTitan");
            downedDunestock = tag.Get<bool>("downedDunestock");
            downedCrawler = tag.Get<bool>("downedCrawler");
            downedConstructor = tag.Get<bool>("downedConstructor");
            downedP1 = tag.Get<bool>("downedP1");
        }

        public override void PreUpdateNPCs()
        {
            foreach (NPC npc in Main.npc)
            {
                npc.GetLifeStats(out int life, out int lifemax);

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
                }
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

                if (thoriumLoaded)
                {
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
                }

                if (redemptionLoaded)
                {
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
                }

                if (sotsLoaded)
                {
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
                    if (sotsMod.TryFind("TheAdvisorHead", out ModNPC TheAdvisorHead))
                    {
                        if (npc.type == TheAdvisorHead.Type && TheAdvisorHead.NPC.life <= 0)
                        {
                            downedAdvisor = true;
                        }
                    }
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
                    if (fargosSoulsMod.TryFind("MutantIllusion", out ModNPC MutantIllusion))
                    {
                        if (npc.type == MutantIllusion.Type && MutantIllusion.NPC.life <= 0)
                        {
                            downedMutant = true;
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

                if (aqLoaded)
                {
                    if (aqMod.TryFind("Crabson", out ModNPC Crabson))
                    {
                        if (npc.type == Crabson.Type && Crabson.NPC.life <= 0)
                        {
                            downedCrabson = true;
                        }
                    }
                    if (aqMod.TryFind("OmegaStarite", out ModNPC OmegaStarite))
                    {
                        if (npc.type == OmegaStarite.Type && OmegaStarite.NPC.life <= 0)
                        {
                            downedOmegaStarite = true;
                        }
                    }
                    if (aqMod.TryFind("DustDevil", out ModNPC DustDevil))
                    {
                        if (npc.type == DustDevil.Type && DustDevil.NPC.life <= 0)
                        {
                            downedDevil = true;
                        }
                    }
                    if (aqMod.TryFind("RedSprite", out ModNPC RedSprite))
                    {
                        if (npc.type == RedSprite.Type && RedSprite.NPC.life <= 0)
                        {
                            downedSprite = true;
                        }
                    }
                    if (aqMod.TryFind("SpaceSquid", out ModNPC SpaceSquid))
                    {
                        if (npc.type == SpaceSquid.Type && SpaceSquid.NPC.life <= 0)
                        {
                            downedSpaceSquid = true;
                        }
                    }
                    if (aqMod.TryFind("UltraStarite", out ModNPC UltraStarite))
                    {
                        if (npc.type == UltraStarite.Type && UltraStarite.NPC.life <= 0)
                        {
                            downedUltraStarite = true;
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
                            downedOrroBoro = true;
                        }
                    }
                    if (spookyMod.TryFind("BoroHead", out ModNPC BoroHead))
                    {
                        if (npc.type == BoroHead.Type && BoroHead.NPC.life <= 0)
                        {
                            downedOrroBoro = true;
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
            }
        }

        public static void ResetDowned()
        {
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

            //CATALYST
            downedGeldon = false;

            //INFERNUM
            downedVassal = false;

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

            //SPIRIT
            downedScarabeus = false;
            downedMoonJelly = false;
            downedVinewrath = false;
            downedAvian = false;
            downedStarVoyager = false;
            downedInfernon = false;
            downedDusking = false;
            downedAtlas = false;

            //REDEMPTION
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

            //SOTS
            downedPutridPinky = false;
            downedPharaohsCurse = false;
            downedAdvisor = false;
            downedPolaris = false;
            downedLux = false;
            downedSerpent = false;

            //SOULS
            downedTrojanSquirrel = false;
            downedDeviant = false;
            downedCosmosChampion = false;
            downedAbomination = false;
            downedMutant = false;

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

            //AEQUUS
            downedCrabson = false;
            downedOmegaStarite = false;
            downedDevil = false;
            downedSprite = false;
            downedSpaceSquid = false;
            downedUltraStarite = false;

            //SPOOKY
            downedSpookySpirit = false;
            downedGourd = false;
            downedMoco = false;
            downedOrroBoro = false;
            downedBigBone = false;

            //CONSOLARIA
            downedLepus = false;
            downedTurkor = false;
            downedOcram = false;

            //POLARITIES
            downedCloudfish = false;
            downedConstruct = false;
            downedGigabat = false;
            downedSunPixie = false;
            downedEsophage = false;
            downedWanderer = false;

            //VITALITY
            downedStormCloud = false;
            downedGrandAntlion = false;
            downedGemstoneElemental = false;
            downedMoonlightDragonfly = false;
            downedDreadnaught = false;
            downedAnarchulesBeetle = false;
            downedChaosbringer = false;
            downedPaladinSpirit = false;

            //TERRORBORN
            downedIncarnate = false;
            downedTitan = false;
            downedDunestock = false;
            downedCrawler = false;
            downedConstructor = false;
            downedP1 = false;
        }
    }
}
