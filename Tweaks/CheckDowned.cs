using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;

namespace QoLCompendium.Tweaks
{
    public class CheckDowned : ModSystem
    {
        public override void Unload()
        {
            if (!calamityLoaded)
            {
                calamityMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!sotsLoaded)
            {
                sotsMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!polaritiesLoaded)
            {
                polaritiesMod = null;
            }
            if (!redemptionLoaded)
            {
                redemptionMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
            if (!homewardLoaded)
            {
                homewardMod = null;
            }
            if (!catalystLoaded)
            {
                catalystMod = null;
            }
            if (!aqLoaded)
            {
                aqMod = null;
            }
        }

        // Token: 0x0600004B RID: 75 RVA: 0x000025E8 File Offset: 0x000007E8
        public override void Load()
        {
            if (!calamityLoaded)
            {
                calamityMod = null;
            }
            if (!thoriumLoaded)
            {
                thoriumMod = null;
            }
            if (!sotsLoaded)
            {
                sotsMod = null;
            }
            if (!vitalityLoaded)
            {
                vitalityMod = null;
            }
            if (!consolariaLoaded)
            {
                consolariaMod = null;
            }
            if (!spookyLoaded)
            {
                spookyMod = null;
            }
            if (!fargosSoulsLoaded)
            {
                fargosSoulsMod = null;
            }
            if (!polaritiesLoaded)
            {
                polaritiesMod = null;
            }
            if (!redemptionLoaded)
            {
                redemptionMod = null;
            }
            if (!terrorbornLoaded)
            {
                terrorbornMod = null;
            }
            if (!homewardLoaded)
            {
                homewardMod = null;
            }
            if (!catalystLoaded)
            {
                catalystMod = null;
            }
            if (!aqLoaded)
            {
                aqMod = null;
            }
        }

        // Token: 0x0600004C RID: 76 RVA: 0x00002684 File Offset: 0x00000884
        public override void PostSetupContent()
        {
            calamityLoaded = ModLoader.TryGetMod("CalamityMod", out Mod mod);
            calamityMod = mod;
            thoriumLoaded = ModLoader.TryGetMod("ThoriumMod", out Mod mod2);
            thoriumMod = mod2;
            sotsLoaded = ModLoader.TryGetMod("SOTS", out Mod mod3);
            sotsMod = mod3;
            vitalityLoaded = ModLoader.TryGetMod("VitalityMod", out Mod mod4);
            vitalityMod = mod4;
            consolariaLoaded = ModLoader.TryGetMod("Consolaria", out Mod mod5);
            consolariaMod = mod5;
            spookyLoaded = ModLoader.TryGetMod("Spooky", out Mod mod6);
            spookyMod = mod6;
            fargosSoulsLoaded = ModLoader.TryGetMod("FargowiltasSouls", out Mod mod7);
            fargosSoulsMod = mod7;
            polaritiesLoaded = ModLoader.TryGetMod("Polarities", out Mod mod8);
            polaritiesMod = mod8;
            redemptionLoaded = ModLoader.TryGetMod("Redemption", out Mod mod9);
            redemptionMod = mod9;
            terrorbornLoaded = ModLoader.TryGetMod("TerrorbornMod", out Mod mod10);
            terrorbornMod = mod10;
            homewardLoaded = ModLoader.TryGetMod("ContinentOfJourney", out Mod mod11);
            homewardMod = mod11;
            catalystLoaded = ModLoader.TryGetMod("CatalystMod", out Mod mod12);
            catalystMod = mod12;
            aqLoaded = ModLoader.TryGetMod("Aequus", out Mod mod13);
            aqMod = mod13;
        }

        // Token: 0x0600004D RID: 77 RVA: 0x00002795 File Offset: 0x00000995
        public override void OnWorldLoad()
        {
            ResetDowned();
        }

        // Token: 0x0600004E RID: 78 RVA: 0x00002795 File Offset: 0x00000995
        public override void OnWorldUnload()
        {
            ResetDowned();
        }

        // Token: 0x0600004F RID: 79 RVA: 0x0000279C File Offset: 0x0000099C
        public static void ResetDowned()
        {
            downedBetsy = false;
            downedOgre = false;
            downedDarkMage = false;
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
            downedProfanedGuardians = false;
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
            downedPutridPinky = false;
            downedPharaohsCurse = false;
            downedAdvisor = false;
            downedPolaris = false;
            downedLux = false;
            downedSerpent = false;
            downedStormCloud = false;
            downedGrandAntlion = false;
            downedGemstoneElemental = false;
            downedMoonlightDragonfly = false;
            downedDreadnaught = false;
            downedAnarchulesBeetle = false;
            downedChaosbringer = false;
            downedLepus = false;
            downedTurkor = false;
            downedOcram = false;
            downedGourd = false;
            downedMoco = false;
            downedOrroBoro = false;
            downedBigBone = false;
            downedPaladinSpirit = false;
            downedTrojanSquirrel = false;
            downedDeviant = false;
            downedCosmosChampion = false;
            downedAbomination = false;
            downedMutant = false;
            downedCloudfish = false;
            downedConstruct = false;
            downedGigabat = false;
            downedSunPixie = false;
            downedEsophage = false;
            downedWanderer = false;
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
            downedIncarnate = false;
            downedTitan = false;
            downedDunestock = false;
            downedCrawler = false;
            downedConstructor = false;
            downedP1 = false;
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
            downedGeldon = false;
            downedCrabson = false;
            downedStarite = false;
            downedDevil = false;
            downedSprite = false;
            downedSpaceSquid = false;
            downedUltraStarite = false;
        }

        // Token: 0x06000050 RID: 80 RVA: 0x00002A20 File Offset: 0x00000C20
        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("betsy", downedBetsy);
            tag.Add("darkMage", downedDarkMage);
            tag.Add("ogre", downedOgre);
            tag.Add("desertScourge", downedDesertScourge);
            tag.Add("crabulon", downedCrabulon);
            tag.Add("hiveMind", downedHiveMind);
            tag.Add("perforators", downedPerforators);
            tag.Add("slimeGod", downedSlimeGod);
            tag.Add("cryogen", downedCryogen);
            tag.Add("aquaticScourge", downedAquaticScourge);
            tag.Add("brimstoneElemental", downedBrimstoneElemental);
            tag.Add("calamitas", downedCalamitas);
            tag.Add("leviathan", downedLeviathan);
            tag.Add("astrumAureus", downedAureus);
            tag.Add("plaguebringerGoliath", downedPlaguebringer);
            tag.Add("ravager", downedRavager);
            tag.Add("astrumDeus", downedDeus);
            tag.Add("dragonfolly", downedDragonfolly);
            tag.Add("providence", downedProvidence);
            tag.Add("stormWeaver", downedStormWeaver);
            tag.Add("ceaselessVoid", downedCeaselessVoid);
            tag.Add("signus", downedSignus);
            tag.Add("polterghast", downedPolterghast);
            tag.Add("oldDuke", downedOldDuke);
            tag.Add("devourerOfGods", downedDevourerOfGods);
            tag.Add("yharon", downedYharon);
            tag.Add("exoMechs", downedExoMechs);
            tag.Add("supremeCalamitas", downedSupremeCalamitas);
            tag.Add("giantClam", downedGiantClam);
            tag.Add("greatSandShark", downedGreatSandShark);
            tag.Add("cragmawMire", downedCragmawMire);
            tag.Add("nuclearTerror", downedNuclearTerror);
            tag.Add("mauler", downedMauler);
            tag.Add("grandBird", downedGrandBird);
            tag.Add("queenJelly", downedQueenJelly);
            tag.Add("viscount", downedViscount);
            tag.Add("engeryStorm", downedEnergyStorm);
            tag.Add("buriedChampion", downedBuriedChampion);
            tag.Add("strider", downedStrider);
            tag.Add("fallenBeholder", downedFallenBeholder);
            tag.Add("lich", downedLich);
            tag.Add("forgottenOne", downedForgottenOne);
            tag.Add("primordials", downedPrimordials);
            tag.Add("putridPinky", downedPutridPinky);
            tag.Add("pharaohsCurse", downedPharaohsCurse);
            tag.Add("advisor", downedAdvisor);
            tag.Add("polaris", downedPolaris);
            tag.Add("lux", downedLux);
            tag.Add("serpent", downedSerpent);
            tag.Add("stormCloud", downedStormCloud);
            tag.Add("grandAntlion", downedGrandAntlion);
            tag.Add("gemstoneElemental", downedGemstoneElemental);
            tag.Add("moonlightDragonfly", downedMoonlightDragonfly);
            tag.Add("dreadnaught", downedDreadnaught);
            tag.Add("anarchulesBeetle", downedAnarchulesBeetle);
            tag.Add("chaosbringer", downedChaosbringer);
            tag.Add("paladinSpirit", downedPaladinSpirit);
            tag.Add("lepus", downedLepus);
            tag.Add("turkor", downedTurkor);
            tag.Add("ocram", downedOcram);
            tag.Add("gourd", downedGourd);
            tag.Add("moco", downedMoco);
            tag.Add("orroBoro", downedOrroBoro);
            tag.Add("bigBone", downedBigBone);
            tag.Add("trojanSquirrel", downedTrojanSquirrel);
            tag.Add("deviant", downedDeviant);
            tag.Add("lieflight", downedLieflight);
            tag.Add("cosmosChampion", downedCosmosChampion);
            tag.Add("abomination", downedAbomination);
            tag.Add("mutant", downedMutant);
            tag.Add("cloudfish", downedCloudfish);
            tag.Add("construct", downedConstruct);
            tag.Add("gigabat", downedGigabat);
            tag.Add("sunPixie", downedSunPixie);
            tag.Add("esophage", downedEsophage);
            tag.Add("wanderer", downedWanderer);
            tag.Add("thorn", downedThorn);
            tag.Add("erhan", downedErhan);
            tag.Add("keeper", downedKeeper);
            tag.Add("seed", downedSeed);
            tag.Add("ks3", downedKS3);
            tag.Add("cleaver", downedCleaver);
            tag.Add("gigapora", downedGigapora);
            tag.Add("obliterator", downedObliterator);
            tag.Add("zero", downedZero);
            tag.Add("duo", downedDuo);
            tag.Add("nebby", downedNebby);
            tag.Add("incarnate", downedIncarnate);
            tag.Add("titan", downedTitan);
            tag.Add("dunestock", downedDunestock);
            tag.Add("crawler", downedCrawler);
            tag.Add("constructor", downedConstructor);
            tag.Add("p1", downedP1);
            tag.Add("squid", downedSquid);
            tag.Add("rod", downedRod);
            tag.Add("diver", downedDiver);
            tag.Add("motherbrain", downedMotherbrain);
            tag.Add("wos", downedWoS);
            tag.Add("sgod", downedSGod);
            tag.Add("overwatcher", downedOverwatcher);
            tag.Add("lifebringer", downedLifebringer);
            tag.Add("materealizer", downedMaterealizer);
            tag.Add("scarab", downedScarab);
            tag.Add("whale", downedWhale);
            tag.Add("son", downedSon);
            tag.Add("geldon", downedGeldon);
            tag.Add("crabson", downedCrabson);
            tag.Add("starite", downedStarite);
            tag.Add("devil", downedDevil);
            tag.Add("sprite", downedSprite);
            tag.Add("ssquid", downedSpaceSquid);
            tag.Add("ustarite", downedUltraStarite);
        }

        // Token: 0x06000051 RID: 81 RVA: 0x000032CC File Offset: 0x000014CC
        public override void LoadWorldData(TagCompound tag)
        {
            downedBetsy = tag.Get<bool>("betsy");
            downedDarkMage = tag.Get<bool>("darkMage");
            downedOgre = tag.Get<bool>("ogre");
            downedDesertScourge = tag.Get<bool>("desertScourge");
            downedCrabulon = tag.Get<bool>("crabulon");
            downedHiveMind = tag.Get<bool>("hiveMind");
            downedPerforators = tag.Get<bool>("perforators");
            downedSlimeGod = tag.Get<bool>("slimeGod");
            downedCryogen = tag.Get<bool>("cryogen");
            downedAquaticScourge = tag.Get<bool>("aquaticScourge");
            downedBrimstoneElemental = tag.Get<bool>("brimstoneElemental");
            downedCalamitas = tag.Get<bool>("calamitas");
            downedLeviathan = tag.Get<bool>("leviathan");
            downedAureus = tag.Get<bool>("astrumAureus");
            downedPlaguebringer = tag.Get<bool>("plaguebringerGoliath");
            downedRavager = tag.Get<bool>("ravager");
            downedDeus = tag.Get<bool>("astrumDeus");
            downedDragonfolly = tag.Get<bool>("dragonfolly");
            downedProvidence = tag.Get<bool>("providence");
            downedStormWeaver = tag.Get<bool>("stormWeaver");
            downedCeaselessVoid = tag.Get<bool>("ceaselessVoid");
            downedSignus = tag.Get<bool>("signus");
            downedPolterghast = tag.Get<bool>("polterghast");
            downedOldDuke = tag.Get<bool>("oldDuke");
            downedDevourerOfGods = tag.Get<bool>("devourerOfGods");
            downedYharon = tag.Get<bool>("yharon");
            downedExoMechs = tag.Get<bool>("exoMechs");
            downedSupremeCalamitas = tag.Get<bool>("supremeCalamitas");
            downedGiantClam = tag.Get<bool>("giantClam");
            downedGreatSandShark = tag.Get<bool>("greatSandShark");
            downedCragmawMire = tag.Get<bool>("cragmawMire");
            downedNuclearTerror = tag.Get<bool>("nuclearTerror");
            downedMauler = tag.Get<bool>("mauler");
            downedProfanedGuardians = tag.Get<bool>("profanedGuardians");
            downedGrandBird = tag.Get<bool>("grandBird");
            downedQueenJelly = tag.Get<bool>("queenJelly");
            downedViscount = tag.Get<bool>("viscount");
            downedEnergyStorm = tag.Get<bool>("engeryStorm");
            downedBuriedChampion = tag.Get<bool>("buriedChampion");
            downedStrider = tag.Get<bool>("strider");
            downedFallenBeholder = tag.Get<bool>("fallenBeholder");
            downedLich = tag.Get<bool>("lich");
            downedForgottenOne = tag.Get<bool>("forgottenOne");
            downedPrimordials = tag.Get<bool>("primordials");
            downedPutridPinky = tag.Get<bool>("putridPinky");
            downedPharaohsCurse = tag.Get<bool>("pharaohsCurse");
            downedAdvisor = tag.Get<bool>("advisor");
            downedPolaris = tag.Get<bool>("polaris");
            downedLux = tag.Get<bool>("lux");
            downedSerpent = tag.Get<bool>("serpent");
            downedStormCloud = tag.Get<bool>("stormCloud");
            downedGrandAntlion = tag.Get<bool>("grandAntlion");
            downedGemstoneElemental = tag.Get<bool>("gemstoneElemental");
            downedMoonlightDragonfly = tag.Get<bool>("moonlightDragonfly");
            downedDreadnaught = tag.Get<bool>("dreadnaught");
            downedAnarchulesBeetle = tag.Get<bool>("anarchulesBeetle");
            downedChaosbringer = tag.Get<bool>("chaosbringer");
            downedPaladinSpirit = tag.Get<bool>("paladinSpirit");
            downedLepus = tag.Get<bool>("lepus");
            downedTurkor = tag.Get<bool>("turkor");
            downedOcram = tag.Get<bool>("ocram");
            downedGourd = tag.Get<bool>("gourd");
            downedMoco = tag.Get<bool>("moco");
            downedOrroBoro = tag.Get<bool>("orroBoro");
            downedBigBone = tag.Get<bool>("bigBone");
            downedTrojanSquirrel = tag.Get<bool>("trojanSquirrel");
            downedDeviant = tag.Get<bool>("deviant");
            downedLieflight = tag.Get<bool>("lieflight");
            downedCosmosChampion = tag.Get<bool>("cosmosChampion");
            downedAbomination = tag.Get<bool>("abomination");
            downedMutant = tag.Get<bool>("mutant");
            downedCloudfish = tag.Get<bool>("cloudfish");
            downedConstruct = tag.Get<bool>("construct");
            downedGigabat = tag.Get<bool>("gigabat");
            downedSunPixie = tag.Get<bool>("sunPixie");
            downedEsophage = tag.Get<bool>("esophage");
            downedWanderer = tag.Get<bool>("wanderer");
            downedThorn = tag.Get<bool>("thorn");
            downedErhan = tag.Get<bool>("erhan");
            downedKeeper = tag.Get<bool>("keeper");
            downedSeed = tag.Get<bool>("seed");
            downedKS3 = tag.Get<bool>("ks3");
            downedCleaver = tag.Get<bool>("cleaver");
            downedGigapora = tag.Get<bool>("gigapora");
            downedObliterator = tag.Get<bool>("obliterator");
            downedZero = tag.Get<bool>("zero");
            downedDuo = tag.Get<bool>("duo");
            downedNebby = tag.Get<bool>("nebby");
            downedIncarnate = tag.Get<bool>("incarnate");
            downedTitan = tag.Get<bool>("titan");
            downedDunestock = tag.Get<bool>("dunestock");
            downedCrawler = tag.Get<bool>("crawler");
            downedConstructor = tag.Get<bool>("constructor");
            downedP1 = tag.Get<bool>("p1");
            downedSquid = tag.Get<bool>("squid");
            downedRod = tag.Get<bool>("rod");
            downedDiver = tag.Get<bool>("diver");
            downedMotherbrain = tag.Get<bool>("motherbrain");
            downedWoS = tag.Get<bool>("wos");
            downedSGod = tag.Get<bool>("sgod");
            downedOverwatcher = tag.Get<bool>("overwatcher");
            downedLifebringer = tag.Get<bool>("lifebringer");
            downedMaterealizer = tag.Get<bool>("materealizer");
            downedScarab = tag.Get<bool>("scarab");
            downedWhale = tag.Get<bool>("whale");
            downedSon = tag.Get<bool>("son");
            downedGeldon = tag.Get<bool>("geldon");
            downedCrabson = tag.Get<bool>("crabson");
            downedStarite = tag.Get<bool>("starite");
            downedDevil = tag.Get<bool>("devil");
            downedSprite = tag.Get<bool>("sprite");
            downedSpaceSquid = tag.Get<bool>("ssquid");
            downedUltraStarite = tag.Get<bool>("ustarite");
        }

        // Token: 0x06000052 RID: 82 RVA: 0x0000397C File Offset: 0x00001B7C
        public override void PreUpdateNPCs()
        {
            foreach (NPC npc2 in Main.npc)
            {
                npc2.GetLifeStats(out int num, out int num2);
                if (npc2.type == NPCID.DD2Betsy && num <= 0)
                {
                    downedBetsy = true;
                }
                if ((npc2.type == NPCID.DD2DarkMageT1 || npc2.type == NPCID.DD2DarkMageT3) && num <= 0)
                {
                    downedDarkMage = true;
                }
                if ((npc2.type == NPCID.DD2OgreT2 || npc2.type == NPCID.DD2OgreT3) && num <= 0)
                {
                    downedOgre = true;
                }
                if (calamityLoaded)
                {
                    if (npc2.type == calamityMod.Find<ModNPC>("CragmawMire").Type && num <= 0)
                    {
                        downedCragmawMire = true;
                    }
                    if (npc2.type == calamityMod.Find<ModNPC>("NuclearTerror").Type && num <= 0)
                    {
                        downedNuclearTerror = true;
                    }
                    if (npc2.type == calamityMod.Find<ModNPC>("Mauler").Type && num <= 0)
                    {
                        downedMauler = true;
                    }
                }
                if (thoriumLoaded)
                {
                    if (npc2.type == thoriumMod.Find<ModNPC>("TheGrandThunderBirdv2").Type && num <= 0)
                    {
                        downedGrandBird = true;
                    }
                    if (npc2.type == thoriumMod.Find<ModNPC>("QueenJelly").Type && num <= 0)
                    {
                        downedQueenJelly = true;
                    }
                    if (npc2.type == thoriumMod.Find<ModNPC>("Viscount").Type && num <= 0)
                    {
                        downedViscount = true;
                    }
                    if (npc2.type == thoriumMod.Find<ModNPC>("GraniteEnergyStorm").Type && num <= 0)
                    {
                        downedEnergyStorm = true;
                    }
                    if (npc2.type == thoriumMod.Find<ModNPC>("TheBuriedWarrior").Type && num <= 0)
                    {
                        downedBuriedChampion = true;
                    }
                    if (npc2.type == thoriumMod.Find<ModNPC>("ThePrimeScouter").Type && num <= 0)
                    {
                        downedScouter = true;
                    }
                    if ((npc2.type == thoriumMod.Find<ModNPC>("BoreanStrider").Type || npc2.type == thoriumMod.Find<ModNPC>("BoreanStriderPopped").Type) && num <= 0)
                    {
                        downedStrider = true;
                    }
                    if ((npc2.type == thoriumMod.Find<ModNPC>("FallenDeathBeholder").Type || npc2.type == thoriumMod.Find<ModNPC>("FallenDeathBeholder2").Type) && num <= 0)
                    {
                        downedFallenBeholder = true;
                    }
                    if ((npc2.type == thoriumMod.Find<ModNPC>("Lich").Type || npc2.type == thoriumMod.Find<ModNPC>("LichHeadless").Type) && num <= 0)
                    {
                        downedLich = true;
                    }
                    if ((npc2.type == thoriumMod.Find<ModNPC>("Abyssion").Type || npc2.type == thoriumMod.Find<ModNPC>("AbyssionCracked").Type || npc2.type == thoriumMod.Find<ModNPC>("AbyssionReleased").Type) && num <= 0)
                    {
                        downedForgottenOne = true;
                    }
                    if (npc2.type == thoriumMod.Find<ModNPC>("RealityBreaker").Type && num <= 0)
                    {
                        downedPrimordials = true;
                    }
                }
                if (sotsLoaded)
                {
                    if (npc2.type == sotsMod.Find<ModNPC>("PutridPinkyPhase2").Type && num <= 0)
                    {
                        downedPutridPinky = true;
                    }
                    if (npc2.type == sotsMod.Find<ModNPC>("PharaohsCurse").Type && num <= 0)
                    {
                        downedPharaohsCurse = true;
                    }
                    if (npc2.type == sotsMod.Find<ModNPC>("TheAdvisorHead").Type && num <= 0)
                    {
                        downedAdvisor = true;
                    }
                    if (npc2.type == sotsMod.Find<ModNPC>("Polaris").Type && num <= 0)
                    {
                        downedPolaris = true;
                    }
                    if (npc2.type == sotsMod.Find<ModNPC>("Lux").Type && num <= 0)
                    {
                        downedLux = true;
                    }
                    if ((npc2.type == sotsMod.Find<ModNPC>("SubspaceSerpentHead").Type || npc2.type == sotsMod.Find<ModNPC>("SubspaceSerpentBody").Type || npc2.type == sotsMod.Find<ModNPC>("SubspaceSerpentTail").Type) && num <= 0)
                    {
                        downedSerpent = true;
                    }
                }
                if (vitalityLoaded)
                {
                    if (npc2.type == vitalityMod.Find<ModNPC>("StormCloudBoss").Type && num <= 0)
                    {
                        downedStormCloud = true;
                    }
                    if (npc2.type == vitalityMod.Find<ModNPC>("GrandAntlionBoss").Type && num <= 0)
                    {
                        downedGrandAntlion = true;
                    }
                    if (npc2.type == vitalityMod.Find<ModNPC>("GemstoneElementalBoss").Type && num <= 0)
                    {
                        downedGemstoneElemental = true;
                    }
                    if (npc2.type == vitalityMod.Find<ModNPC>("MoonlightDragonflyBoss").Type && num <= 0)
                    {
                        downedMoonlightDragonfly = true;
                    }
                    if (npc2.type == vitalityMod.Find<ModNPC>("DreadnaughtBoss").Type && num <= 0)
                    {
                        downedDreadnaught = true;
                    }
                    if (npc2.type == vitalityMod.Find<ModNPC>("AnarchulesBeetleBoss").Type && num <= 0)
                    {
                        downedAnarchulesBeetle = true;
                    }
                    if (npc2.type == vitalityMod.Find<ModNPC>("ChaosbringerBoss").Type && num <= 0)
                    {
                        downedChaosbringer = true;
                    }
                    if (npc2.type == vitalityMod.Find<ModNPC>("PaladinSpiritBoss").Type && num <= 0)
                    {
                        downedPaladinSpirit = true;
                    }
                }
                if (consolariaLoaded)
                {
                    if (npc2.type == consolariaMod.Find<ModNPC>("Lepus").Type && num <= 0)
                    {
                        downedLepus = true;
                    }
                    if (npc2.type == consolariaMod.Find<ModNPC>("TurkortheUngrateful").Type && num <= 0)
                    {
                        downedTurkor = true;
                    }
                    if (npc2.type == consolariaMod.Find<ModNPC>("Ocram").Type && num <= 0)
                    {
                        downedOcram = true;
                    }
                }
                if (spookyLoaded)
                {
                    if (npc2.type == spookyMod.Find<ModNPC>("RotGourd").Type && num <= 0)
                    {
                        downedGourd = true;
                    }
                    if (npc2.type == spookyMod.Find<ModNPC>("Moco").Type && num <= 0)
                    {
                        downedMoco = true;
                    }
                    if ((npc2.type == spookyMod.Find<ModNPC>("OrroboroBody1").Type || npc2.type == spookyMod.Find<ModNPC>("OrroboroBody2").Type || npc2.type == spookyMod.Find<ModNPC>("OrroboroHead").Type || npc2.type == spookyMod.Find<ModNPC>("OrroboroTail").Type) && num <= 0)
                    {
                        downedOrroBoro = true;
                    }
                    if (npc2.type == spookyMod.Find<ModNPC>("BigBone").Type && num <= 0)
                    {
                        downedBigBone = true;
                    }
                }
                if (fargosSoulsLoaded)
                {
                    if (npc2.type == fargosSoulsMod.Find<ModNPC>("TrojanSquirrel").Type && num <= 0)
                    {
                        downedTrojanSquirrel = true;
                    }
                    if (npc2.type == fargosSoulsMod.Find<ModNPC>("DeviBoss").Type && num <= 0)
                    {
                        downedDeviant = true;
                    }
                    if (npc2.type == fargosSoulsMod.Find<ModNPC>("CosmosChampion").Type && num <= 0)
                    {
                        downedCosmosChampion = true;
                    }
                    if (npc2.type == fargosSoulsMod.Find<ModNPC>("AbomBoss").Type && num <= 0)
                    {
                        downedAbomination = true;
                    }
                    if (npc2.type == fargosSoulsMod.Find<ModNPC>("MutantBoss").Type && num <= 0)
                    {
                        downedMutant = true;
                    }
                }
                if (polaritiesLoaded)
                {
                    if (npc2.type == polaritiesMod.Find<ModNPC>("StormCloudfish").Type && num <= 0)
                    {
                        downedCloudfish = true;
                    }
                    if (npc2.type == polaritiesMod.Find<ModNPC>("StarConstruct").Type && num <= 0)
                    {
                        downedConstruct = true;
                    }
                    if (npc2.type == polaritiesMod.Find<ModNPC>("Gigabat").Type && num <= 0)
                    {
                        downedGigabat = true;
                    }
                    if (npc2.type == polaritiesMod.Find<ModNPC>("SunPixie").Type && num <= 0)
                    {
                        downedSunPixie = true;
                    }
                    if (npc2.type == polaritiesMod.Find<ModNPC>("Esophage").Type && num <= 0)
                    {
                        downedEsophage = true;
                    }
                    if (npc2.type == polaritiesMod.Find<ModNPC>("ConvectiveWanderer").Type && num <= 0)
                    {
                        downedWanderer = true;
                    }
                }
                if (redemptionLoaded)
                {
                    if (npc2.type == redemptionMod.Find<ModNPC>("Thorn").Type && num <= 0)
                    {
                        downedThorn = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("Erhan").Type && num <= 0)
                    {
                        downedErhan = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("Keeper").Type && num <= 0)
                    {
                        downedKeeper = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("SoI").Type && num <= 0)
                    {
                        downedSeed = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("KS3").Type && num <= 0)
                    {
                        downedKS3 = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("OmegaCleaver").Type && num <= 0)
                    {
                        downedCleaver = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("Gigapora").Type && num <= 0)
                    {
                        downedGigapora = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("OO").Type && num <= 0)
                    {
                        downedObliterator = true;
                    }
                    if (npc2.type == redemptionMod.Find<ModNPC>("PZ").Type && num <= 0)
                    {
                        downedZero = true;
                    }
                    if ((npc2.type == redemptionMod.Find<ModNPC>("Akka").Type && num <= 0) || (npc2.type == redemptionMod.Find<ModNPC>("Ukko").Type && num <= 0))
                    {
                        downedDuo = true;
                    }
                    if ((npc2.type == redemptionMod.Find<ModNPC>("Nebuleus").Type && num <= 0) || (npc2.type == redemptionMod.Find<ModNPC>("Nebuleus2").Type && num <= 0))
                    {
                        downedNebby = true;
                    }
                }
                if (terrorbornLoaded)
                {
                    if (npc2.type == terrorbornMod.Find<ModNPC>("InfectedIncarnate").Type && num <= 0)
                    {
                        downedIncarnate = true;
                    }
                    if (npc2.type == terrorbornMod.Find<ModNPC>("TidalTitan").Type && num <= 0)
                    {
                        downedTitan = true;
                    }
                    if (npc2.type == terrorbornMod.Find<ModNPC>("Dunestock").Type && num <= 0)
                    {
                        downedDunestock = true;
                    }
                    if (npc2.type == terrorbornMod.Find<ModNPC>("Shadowcrawler").Type && num <= 0)
                    {
                        downedCrawler = true;
                    }
                    if (npc2.type == terrorbornMod.Find<ModNPC>("HexedConstructor").Type && num <= 0)
                    {
                        downedConstructor = true;
                    }
                    if (npc2.type == terrorbornMod.Find<ModNPC>("PrototypeI").Type && num <= 0)
                    {
                        downedP1 = true;
                    }
                }
                if (homewardLoaded)
                {
                    if (npc2.type == homewardMod.Find<ModNPC>("MarquisMoonsquid").Type && num <= 0)
                    {
                        downedSquid = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("PriestessRod").Type && num <= 0)
                    {
                        downedRod = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("Diver").Type && num <= 0)
                    {
                        downedDiver = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("TheMotherbrain").Type && num <= 0)
                    {
                        downedMotherbrain = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("WallofShadow").Type && num <= 0)
                    {
                        downedWoS = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("SlimeGod").Type && num <= 0)
                    {
                        downedSGod = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("TheOverwatcher").Type && num <= 0)
                    {
                        downedOverwatcher = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("TheLifebringerHead").Type && num <= 0)
                    {
                        downedLifebringer = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("TheMaterealizer").Type && num <= 0)
                    {
                        downedMaterealizer = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("ScarabBelief").Type && num <= 0)
                    {
                        downedScarab = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("WorldsEndEverlastingFallingWhale").Type && num <= 0)
                    {
                        downedWhale = true;
                    }
                    if (npc2.type == homewardMod.Find<ModNPC>("TheSon").Type && num <= 0)
                    {
                        downedSon = true;
                    }
                }
                if (aqLoaded)
                {
                    if (npc2.type == aqMod.Find<ModNPC>("Crabson").Type && num <= 0)
                    {
                        downedCrabson = true;
                    }
                    if (npc2.type == aqMod.Find<ModNPC>("OmegaStarite").Type && num <= 0)
                    {
                        downedStarite = true;
                    }
                    if (npc2.type == aqMod.Find<ModNPC>("DustDevil").Type && num <= 0)
                    {
                        downedDevil = true;
                    }
                    if (npc2.type == aqMod.Find<ModNPC>("RedSprite").Type && num <= 0)
                    {
                        downedSprite = true;
                    }
                    if (npc2.type == aqMod.Find<ModNPC>("SpaceSquid").Type && num <= 0)
                    {
                        downedSpaceSquid = true;
                    }
                    if (npc2.type == aqMod.Find<ModNPC>("UltraStarite").Type && num <= 0)
                    {
                        downedUltraStarite = true;
                    }
                }
                if (catalystLoaded)
                {
                    if (npc2.type == catalystMod.Find<ModNPC>("Astrageldon").Type && num <= 0)
                    {
                        downedGeldon = true;
                    }
                }
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
                downedProfanedGuardians = (bool)calamityMod.Call(new object[]
                {
                    "GetBossDowned",
                    "Guardians"
                });
            }
        }

        // Token: 0x0400001B RID: 27
        internal static bool downedBetsy;

        // Token: 0x0400001C RID: 28
        internal static bool downedDarkMage;

        // Token: 0x0400001D RID: 29
        internal static bool downedOgre;

        // Token: 0x0400001E RID: 30
        internal static bool downedDesertScourge;

        // Token: 0x0400001F RID: 31
        internal static bool downedCrabulon;

        // Token: 0x04000020 RID: 32
        internal static bool downedHiveMind;

        // Token: 0x04000021 RID: 33
        internal static bool downedPerforators;

        // Token: 0x04000022 RID: 34
        internal static bool downedSlimeGod;

        // Token: 0x04000023 RID: 35
        internal static bool downedCryogen;

        // Token: 0x04000024 RID: 36
        internal static bool downedAquaticScourge;

        // Token: 0x04000025 RID: 37
        internal static bool downedBrimstoneElemental;

        // Token: 0x04000026 RID: 38
        internal static bool downedCalamitas;

        // Token: 0x04000027 RID: 39
        internal static bool downedLeviathan;

        // Token: 0x04000028 RID: 40
        internal static bool downedAureus;

        // Token: 0x04000029 RID: 41
        internal static bool downedPlaguebringer;

        // Token: 0x0400002A RID: 42
        internal static bool downedRavager;

        // Token: 0x0400002B RID: 43
        internal static bool downedDeus;

        // Token: 0x0400002C RID: 44
        internal static bool downedDragonfolly;

        // Token: 0x0400002D RID: 45
        internal static bool downedProvidence;

        // Token: 0x0400002E RID: 46
        internal static bool downedStormWeaver;

        // Token: 0x0400002F RID: 47
        internal static bool downedCeaselessVoid;

        // Token: 0x04000030 RID: 48
        internal static bool downedSignus;

        // Token: 0x04000031 RID: 49
        internal static bool downedPolterghast;

        // Token: 0x04000032 RID: 50
        internal static bool downedOldDuke;

        // Token: 0x04000033 RID: 51
        internal static bool downedDevourerOfGods;

        // Token: 0x04000034 RID: 52
        internal static bool downedYharon;

        // Token: 0x04000035 RID: 53
        internal static bool downedExoMechs;

        // Token: 0x04000036 RID: 54
        internal static bool downedSupremeCalamitas;

        // Token: 0x04000037 RID: 55
        internal static bool downedGiantClam;

        // Token: 0x04000038 RID: 56
        internal static bool downedGreatSandShark;

        // Token: 0x04000039 RID: 57
        internal static bool downedCragmawMire;

        // Token: 0x0400003A RID: 58
        internal static bool downedNuclearTerror;

        // Token: 0x0400003B RID: 59
        internal static bool downedMauler;

        // Token: 0x0400003C RID: 60
        internal static bool downedProfanedGuardians;

        // Token: 0x0400003D RID: 61
        internal static bool downedGrandBird;

        // Token: 0x0400003E RID: 62
        internal static bool downedQueenJelly;

        // Token: 0x0400003F RID: 63
        internal static bool downedViscount;

        // Token: 0x04000040 RID: 64
        internal static bool downedEnergyStorm;

        // Token: 0x04000041 RID: 65
        internal static bool downedBuriedChampion;

        // Token: 0x04000042 RID: 66
        internal static bool downedScouter;

        // Token: 0x04000043 RID: 67
        internal static bool downedStrider;

        // Token: 0x04000044 RID: 68
        internal static bool downedFallenBeholder;

        // Token: 0x04000045 RID: 69
        internal static bool downedLich;

        // Token: 0x04000046 RID: 70
        internal static bool downedForgottenOne;

        // Token: 0x04000047 RID: 71
        internal static bool downedPrimordials;

        // Token: 0x04000048 RID: 72
        internal static bool downedPutridPinky;

        // Token: 0x04000049 RID: 73
        internal static bool downedPharaohsCurse;

        // Token: 0x0400004A RID: 74
        internal static bool downedAdvisor;

        // Token: 0x0400004B RID: 75
        internal static bool downedPolaris;

        // Token: 0x0400004C RID: 76
        internal static bool downedLux;

        // Token: 0x0400004D RID: 77
        internal static bool downedSerpent;

        // Token: 0x0400004E RID: 78
        internal static bool downedStormCloud;

        // Token: 0x0400004F RID: 79
        internal static bool downedGrandAntlion;

        // Token: 0x04000050 RID: 80
        internal static bool downedGemstoneElemental;

        // Token: 0x04000051 RID: 81
        internal static bool downedMoonlightDragonfly;

        // Token: 0x04000052 RID: 82
        internal static bool downedDreadnaught;

        // Token: 0x04000053 RID: 83
        internal static bool downedAnarchulesBeetle;

        // Token: 0x04000054 RID: 84
        internal static bool downedChaosbringer;

        // Token: 0x04000055 RID: 85
        internal static bool downedPaladinSpirit;

        // Token: 0x04000056 RID: 86
        internal static bool downedLepus;

        // Token: 0x04000057 RID: 87
        internal static bool downedTurkor;

        // Token: 0x04000058 RID: 88
        internal static bool downedOcram;

        // Token: 0x04000059 RID: 89
        internal static bool downedGourd;

        // Token: 0x0400005A RID: 90
        internal static bool downedMoco;

        // Token: 0x0400005B RID: 91
        internal static bool downedOrroBoro;

        // Token: 0x0400005C RID: 92
        internal static bool downedBigBone;

        // Token: 0x0400005D RID: 93
        internal static bool downedTrojanSquirrel;

        // Token: 0x0400005E RID: 94
        internal static bool downedDeviant;

        // Token: 0x0400005F RID: 95
        internal static bool downedLieflight;

        // Token: 0x04000060 RID: 96
        internal static bool downedCosmosChampion;

        // Token: 0x04000061 RID: 97
        internal static bool downedAbomination;

        // Token: 0x04000062 RID: 98
        internal static bool downedMutant;

        // Token: 0x04000063 RID: 99
        internal static bool downedCloudfish;

        // Token: 0x04000064 RID: 100
        internal static bool downedConstruct;

        // Token: 0x04000065 RID: 101
        internal static bool downedGigabat;

        // Token: 0x04000066 RID: 102
        internal static bool downedSunPixie;

        // Token: 0x04000067 RID: 103
        internal static bool downedEsophage;

        // Token: 0x04000068 RID: 104
        internal static bool downedWanderer;

        // Token: 0x04000069 RID: 105
        internal static bool downedThorn;

        // Token: 0x0400006A RID: 106
        internal static bool downedErhan;

        // Token: 0x0400006B RID: 107
        internal static bool downedKeeper;

        // Token: 0x0400006C RID: 108
        internal static bool downedSeed;

        // Token: 0x0400006D RID: 109
        internal static bool downedKS3;

        // Token: 0x0400006E RID: 110
        internal static bool downedCleaver;

        // Token: 0x0400006F RID: 111
        internal static bool downedGigapora;

        // Token: 0x04000070 RID: 112
        internal static bool downedObliterator;

        // Token: 0x04000071 RID: 113
        internal static bool downedZero;

        // Token: 0x04000072 RID: 114
        internal static bool downedDuo;

        // Token: 0x04000073 RID: 115
        internal static bool downedNebby;

        // Token: 0x04000074 RID: 116
        internal static bool downedIncarnate;

        // Token: 0x04000075 RID: 117
        internal static bool downedTitan;

        // Token: 0x04000076 RID: 118
        internal static bool downedDunestock;

        // Token: 0x04000077 RID: 119
        internal static bool downedCrawler;

        // Token: 0x04000078 RID: 120
        internal static bool downedConstructor;

        // Token: 0x04000079 RID: 121
        internal static bool downedP1;

        // Token: 0x0400007A RID: 122
        internal static bool downedSquid;

        // Token: 0x0400007B RID: 123
        internal static bool downedRod;

        // Token: 0x0400007C RID: 124
        internal static bool downedDiver;

        // Token: 0x0400007D RID: 125
        internal static bool downedMotherbrain;

        // Token: 0x0400007E RID: 126
        internal static bool downedWoS;

        // Token: 0x0400007F RID: 127
        internal static bool downedSGod;

        // Token: 0x04000080 RID: 128
        internal static bool downedOverwatcher;

        // Token: 0x04000081 RID: 129
        internal static bool downedLifebringer;

        // Token: 0x04000082 RID: 130
        internal static bool downedMaterealizer;

        // Token: 0x04000083 RID: 131
        internal static bool downedScarab;

        // Token: 0x04000084 RID: 132
        internal static bool downedWhale;

        // Token: 0x04000085 RID: 133
        internal static bool downedSon;

        internal static bool downedGeldon;

        internal static bool downedCrabson;

        internal static bool downedStarite;

        internal static bool downedDevil;

        internal static bool downedSprite;

        internal static bool downedSpaceSquid;

        internal static bool downedUltraStarite;

        // Token: 0x04000086 RID: 134
        internal static bool calamityLoaded;

        // Token: 0x04000087 RID: 135
        internal static Mod calamityMod;

        // Token: 0x04000088 RID: 136
        internal static bool thoriumLoaded;

        // Token: 0x04000089 RID: 137
        internal static Mod thoriumMod;

        // Token: 0x0400008A RID: 138
        internal static bool sotsLoaded;

        // Token: 0x0400008B RID: 139
        internal static Mod sotsMod;

        // Token: 0x0400008C RID: 140
        internal static bool vitalityLoaded;

        // Token: 0x0400008D RID: 141
        internal static Mod vitalityMod;

        // Token: 0x0400008E RID: 142
        internal static bool consolariaLoaded;

        // Token: 0x0400008F RID: 143
        internal static Mod consolariaMod;

        // Token: 0x04000090 RID: 144
        internal static bool spookyLoaded;

        // Token: 0x04000091 RID: 145
        internal static Mod spookyMod;

        // Token: 0x04000092 RID: 146
        internal static bool fargosSoulsLoaded;

        // Token: 0x04000093 RID: 147
        internal static Mod fargosSoulsMod;

        // Token: 0x04000094 RID: 148
        internal static bool polaritiesLoaded;

        // Token: 0x04000095 RID: 149
        internal static Mod polaritiesMod;

        // Token: 0x04000096 RID: 150
        internal static bool redemptionLoaded;

        // Token: 0x04000097 RID: 151
        internal static Mod redemptionMod;

        // Token: 0x04000098 RID: 152
        internal static bool terrorbornLoaded;

        // Token: 0x04000099 RID: 153
        internal static Mod terrorbornMod;

        // Token: 0x0400009A RID: 154
        internal static bool homewardLoaded;

        // Token: 0x0400009B RID: 155
        internal static Mod homewardMod;

        internal static bool catalystLoaded;

        internal static Mod catalystMod;

        internal static bool aqLoaded;

        internal static Mod aqMod;
    }
}
