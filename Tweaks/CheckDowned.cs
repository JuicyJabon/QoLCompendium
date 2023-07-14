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
                    if (npc.type == calamityMod.Find<ModNPC>("CragmawMire").Type && life <= 0)
                    {
                        downedCragmawMire = true;
                    }
                    if (npc.type == calamityMod.Find<ModNPC>("NuclearTerror").Type && life <= 0)
                    {
                        downedNuclearTerror = true;
                    }
                    if (npc.type == calamityMod.Find<ModNPC>("Mauler").Type && life <= 0)
                    {
                        downedMauler = true;
                    }
                }

                if (catalystLoaded && npc.type == catalystMod.Find<ModNPC>("Astrageldon").Type && life <= 0)
                {
                    downedGeldon = true;
                }

                if (thoriumLoaded)
                {
                    if (npc.type == thoriumMod.Find<ModNPC>("TheGrandThunderBirdv2").Type && life <= 0)
                    {
                        downedGrandBird = true;
                    }
                    if (npc.type == thoriumMod.Find<ModNPC>("QueenJelly").Type && life <= 0)
                    {
                        downedQueenJelly = true;
                    }
                    if (npc.type == thoriumMod.Find<ModNPC>("Viscount").Type && life <= 0)
                    {
                        downedViscount = true;
                    }
                    if (npc.type == thoriumMod.Find<ModNPC>("GraniteEnergyStorm").Type && life <= 0)
                    {
                        downedEnergyStorm = true;
                    }
                    if (npc.type == thoriumMod.Find<ModNPC>("TheBuriedWarrior").Type && life <= 0)
                    {
                        downedBuriedChampion = true;
                    }
                    if (npc.type == thoriumMod.Find<ModNPC>("ThePrimeScouter").Type && life <= 0)
                    {
                        downedScouter = true;
                    }
                    if ((npc.type == thoriumMod.Find<ModNPC>("BoreanStrider").Type || npc.type == thoriumMod.Find<ModNPC>("BoreanStriderPopped").Type) && life <= 0)
                    {
                        downedStrider = true;
                    }
                    if ((npc.type == thoriumMod.Find<ModNPC>("FallenDeathBeholder").Type || npc.type == thoriumMod.Find<ModNPC>("FallenDeathBeholder2").Type) && life <= 0)
                    {
                        downedFallenBeholder = true;
                    }
                    if ((npc.type == thoriumMod.Find<ModNPC>("Lich").Type || npc.type == thoriumMod.Find<ModNPC>("LichHeadless").Type) && life <= 0)
                    {
                        downedLich = true;
                    }
                    if ((npc.type == thoriumMod.Find<ModNPC>("Abyssion").Type || npc.type == thoriumMod.Find<ModNPC>("AbyssionCracked").Type || npc.type == thoriumMod.Find<ModNPC>("AbyssionReleased").Type) && life <= 0)
                    {
                        downedForgottenOne = true;
                    }
                    if (npc.type == thoriumMod.Find<ModNPC>("RealityBreaker").Type && life <= 0)
                    {
                        downedPrimordials = true;
                    }
                }

                if (spiritLoaded)
                {
                    if (npc.type == spiritMod.Find<ModNPC>("Scarabeus").Type && life <= 0)
                    {
                        downedScarabeus = true;
                    }
                    if (npc.type == spiritMod.Find<ModNPC>("MoonWizard").Type && life <= 0)
                    {
                        downedMoonJelly = true;
                    }
                    if (npc.type == spiritMod.Find<ModNPC>("ReachBoss").Type && life <= 0)
                    {
                        downedVinewrath = true;
                    }
                    if (npc.type == spiritMod.Find<ModNPC>("AncientFlyer").Type && life <= 0)
                    {
                        downedAvian = true;
                    }
                    if (npc.type == spiritMod.Find<ModNPC>("SteamRaiderHead").Type && life <= 0)
                    {
                        downedStarVoyager = true;
                    }
                    if (npc.type == spiritMod.Find<ModNPC>("Infernon").Type && life <= 0)
                    {
                        downedInfernon = true;
                    }
                    if (npc.type == spiritMod.Find<ModNPC>("Dusking").Type && life <= 0)
                    {
                        downedDusking = true;
                    }
                    if (npc.type == spiritMod.Find<ModNPC>("Atlas").Type && life <= 0)
                    {
                        downedAtlas = true;
                    }
                }

                if (redemptionLoaded)
                {
                    if (npc.type == redemptionMod.Find<ModNPC>("Thorn").Type && life <= 0)
                    {
                        downedThorn = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("Erhan").Type && life <= 0)
                    {
                        downedErhan = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("Keeper").Type && life <= 0)
                    {
                        downedKeeper = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("SoI").Type && life <= 0)
                    {
                        downedSeed = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("KS3").Type && life <= 0)
                    {
                        downedKS3 = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("OmegaCleaver").Type && life <= 0)
                    {
                        downedCleaver = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("Gigapora").Type && life <= 0)
                    {
                        downedGigapora = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("OO").Type && life <= 0)
                    {
                        downedObliterator = true;
                    }
                    if (npc.type == redemptionMod.Find<ModNPC>("PZ").Type && life <= 0)
                    {
                        downedZero = true;
                    }
                    if ((npc.type == redemptionMod.Find<ModNPC>("Akka").Type && life <= 0) || (npc.type == redemptionMod.Find<ModNPC>("Ukko").Type && life <= 0))
                    {
                        downedDuo = true;
                    }
                    if ((npc.type == redemptionMod.Find<ModNPC>("Nebuleus").Type && life <= 0) || (npc.type == redemptionMod.Find<ModNPC>("Nebuleus2").Type && life <= 0))
                    {
                        downedNebby = true;
                    }
                }

                if (sotsLoaded)
                {
                    if (npc.type == sotsMod.Find<ModNPC>("PutridPinkyPhase2").Type && life <= 0)
                    {
                        downedPutridPinky = true;
                    }
                    if (npc.type == sotsMod.Find<ModNPC>("PharaohsCurse").Type && life <= 0)
                    {
                        downedPharaohsCurse = true;
                    }
                    if (npc.type == sotsMod.Find<ModNPC>("TheAdvisorHead").Type && life <= 0)
                    {
                        downedAdvisor = true;
                    }
                    if (npc.type == sotsMod.Find<ModNPC>("Polaris").Type && life <= 0)
                    {
                        downedPolaris = true;
                    }
                    if (npc.type == sotsMod.Find<ModNPC>("Lux").Type && life <= 0)
                    {
                        downedLux = true;
                    }
                    if ((npc.type == sotsMod.Find<ModNPC>("SubspaceSerpentHead").Type || npc.type == sotsMod.Find<ModNPC>("SubspaceSerpentBody").Type || npc.type == sotsMod.Find<ModNPC>("SubspaceSerpentTail").Type) && life <= 0)
                    {
                        downedSerpent = true;
                    }
                }

                if (fargosSoulsLoaded)
                {
                    if ((npc.type == fargosSoulsMod.Find<ModNPC>("TrojanSquirrel").Type || npc.type == fargosSoulsMod.Find<ModNPC>("TrojanSquirrelPart").Type) && life <= 0)
                    {
                        downedTrojanSquirrel = true;
                    }
                    if (npc.type == fargosSoulsMod.Find<ModNPC>("DeviBoss").Type && life <= 0)
                    {
                        downedDeviant = true;
                    }
                    if (npc.type == fargosSoulsMod.Find<ModNPC>("CosmosChampion").Type && life <= 0)
                    {
                        downedCosmosChampion = true;
                    }
                    if (npc.type == fargosSoulsMod.Find<ModNPC>("AbomBoss").Type && life <= 0)
                    {
                        downedAbomination = true;
                    }
                    if ((npc.type == fargosSoulsMod.Find<ModNPC>("MutantBoss").Type || npc.type == fargosSoulsMod.Find<ModNPC>("MutantIllusion").Type) && life <= 0)
                    {
                        downedMutant = true;
                    }
                }

                if (homewardLoaded)
                {
                    if (npc.type == homewardMod.Find<ModNPC>("MarquisMoonsquid").Type && life <= 0)
                    {
                        downedSquid = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("PriestessRod").Type && life <= 0)
                    {
                        downedRod = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("Diver").Type && life <= 0)
                    {
                        downedDiver = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("TheMotherbrain").Type && life <= 0)
                    {
                        downedMotherbrain = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("WallofShadow").Type && life <= 0)
                    {
                        downedWoS = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("SlimeGod").Type && life <= 0)
                    {
                        downedSGod = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("TheOverwatcher").Type && life <= 0)
                    {
                        downedOverwatcher = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("TheLifebringerHead").Type && life <= 0)
                    {
                        downedLifebringer = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("TheMaterealizer").Type && life <= 0)
                    {
                        downedMaterealizer = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("ScarabBelief").Type && life <= 0)
                    {
                        downedScarab = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("WorldsEndEverlastingFallingWhale").Type && life <= 0)
                    {
                        downedWhale = true;
                    }
                    if (npc.type == homewardMod.Find<ModNPC>("TheSon").Type && life <= 0)
                    {
                        downedSon = true;
                    }
                }

                if (aqLoaded)
                {
                    if (npc.type == aqMod.Find<ModNPC>("Crabson").Type && life <= 0)
                    {
                        downedCrabson = true;
                    }
                    if (npc.type == aqMod.Find<ModNPC>("OmegaStarite").Type && life <= 0)
                    {
                        downedOmegaStarite = true;
                    }
                    if (npc.type == aqMod.Find<ModNPC>("DustDevil").Type && life <= 0)
                    {
                        downedDevil = true;
                    }
                    if (npc.type == aqMod.Find<ModNPC>("RedSprite").Type && life <= 0)
                    {
                        downedSprite = true;
                    }
                    if (npc.type == aqMod.Find<ModNPC>("SpaceSquid").Type && life <= 0)
                    {
                        downedSpaceSquid = true;
                    }
                    if (npc.type == aqMod.Find<ModNPC>("UltraStarite").Type && life <= 0)
                    {
                        downedUltraStarite = true;
                    }
                }

                if (spookyLoaded)
                {
                    if (npc.type == spookyMod.Find<ModNPC>("SpookySpirit").Type && life <= 0)
                    {
                        downedSpookySpirit = true;
                    }
                    if (npc.type == spookyMod.Find<ModNPC>("RotGourd").Type && life <= 0)
                    {
                        downedGourd = true;
                    }
                    if (npc.type == spookyMod.Find<ModNPC>("Moco").Type && life <= 0)
                    {
                        downedMoco = true;
                    }
                    if ((npc.type == spookyMod.Find<ModNPC>("OrroboroBody1").Type || npc.type == spookyMod.Find<ModNPC>("OrroboroBody2").Type || npc.type == spookyMod.Find<ModNPC>("OrroboroHead").Type || npc.type == spookyMod.Find<ModNPC>("OrroboroTail").Type) && life <= 0)
                    {
                        downedOrroBoro = true;
                    }
                    if (npc.type == spookyMod.Find<ModNPC>("BigBone").Type && life <= 0)
                    {
                        downedBigBone = true;
                    }
                }

                if (consolariaLoaded)
                {
                    if (npc.type == consolariaMod.Find<ModNPC>("Lepus").Type && life <= 0)
                    {
                        downedLepus = true;
                    }
                    if (npc.type == consolariaMod.Find<ModNPC>("TurkortheUngrateful").Type && life <= 0)
                    {
                        downedTurkor = true;
                    }
                    if (npc.type == consolariaMod.Find<ModNPC>("Ocram").Type && life <= 0)
                    {
                        downedOcram = true;
                    }
                }

                if (polaritiesLoaded)
                {
                    if (npc.type == polaritiesMod.Find<ModNPC>("StormCloudfish").Type && life <= 0)
                    {
                        downedCloudfish = true;
                    }
                    if (npc.type == polaritiesMod.Find<ModNPC>("StarConstruct").Type && life <= 0)
                    {
                        downedConstruct = true;
                    }
                    if (npc.type == polaritiesMod.Find<ModNPC>("Gigabat").Type && life <= 0)
                    {
                        downedGigabat = true;
                    }
                    if (npc.type == polaritiesMod.Find<ModNPC>("SunPixie").Type && life <= 0)
                    {
                        downedSunPixie = true;
                    }
                    if (npc.type == polaritiesMod.Find<ModNPC>("Esophage").Type && life <= 0)
                    {
                        downedEsophage = true;
                    }
                    if (npc.type == polaritiesMod.Find<ModNPC>("ConvectiveWanderer").Type && life <= 0)
                    {
                        downedWanderer = true;
                    }
                }

                if (vitalityLoaded)
                {
                    if (npc.type == vitalityMod.Find<ModNPC>("StormCloudBoss").Type && life <= 0)
                    {
                        downedStormCloud = true;
                    }
                    if (npc.type == vitalityMod.Find<ModNPC>("GrandAntlionBoss").Type && life <= 0)
                    {
                        downedGrandAntlion = true;
                    }
                    if (npc.type == vitalityMod.Find<ModNPC>("GemstoneElementalBoss").Type && life <= 0)
                    {
                        downedGemstoneElemental = true;
                    }
                    if (npc.type == vitalityMod.Find<ModNPC>("MoonlightDragonflyBoss").Type && life <= 0)
                    {
                        downedMoonlightDragonfly = true;
                    }
                    if (npc.type == vitalityMod.Find<ModNPC>("DreadnaughtBoss").Type && life <= 0)
                    {
                        downedDreadnaught = true;
                    }
                    if (npc.type == vitalityMod.Find<ModNPC>("AnarchulesBeetleBoss").Type && life <= 0)
                    {
                        downedAnarchulesBeetle = true;
                    }
                    if (npc.type == vitalityMod.Find<ModNPC>("ChaosbringerBoss").Type && life <= 0)
                    {
                        downedChaosbringer = true;
                    }
                    if (npc.type == vitalityMod.Find<ModNPC>("PaladinSpiritBoss").Type && life <= 0)
                    {
                        downedPaladinSpirit = true;
                    }
                }

                if (terrorbornLoaded)
                {
                    if (npc.type == terrorbornMod.Find<ModNPC>("InfectedIncarnate").Type && life <= 0)
                    {
                        downedIncarnate = true;
                    }
                    if (npc.type == terrorbornMod.Find<ModNPC>("TidalTitan").Type && life <= 0)
                    {
                        downedTitan = true;
                    }
                    if (npc.type == terrorbornMod.Find<ModNPC>("Dunestock").Type && life <= 0)
                    {
                        downedDunestock = true;
                    }
                    if (npc.type == terrorbornMod.Find<ModNPC>("Shadowcrawler").Type && life <= 0)
                    {
                        downedCrawler = true;
                    }
                    if (npc.type == terrorbornMod.Find<ModNPC>("HexedConstructor").Type && life <= 0)
                    {
                        downedConstructor = true;
                    }
                    if (npc.type == terrorbornMod.Find<ModNPC>("PrototypeI").Type && life <= 0)
                    {
                        downedP1 = true;
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
