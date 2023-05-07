using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

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

        public override void OnWorldLoad()
        {
            ResetDowned();
        }

        public override void OnWorldUnload()
        {
            ResetDowned();
        }

        public static void ResetDowned()
        {
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

        public override void SaveWorldData(TagCompound tag)
        {
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

        public override void PreUpdateNPCs()
        {
            foreach (NPC npc2 in Main.npc)
            {
                npc2.GetLifeStats(out int num, out int num2);
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

        internal static bool downedProfanedGuardians;
        public static Condition profguardians = new("CheckDowned.downedProfanedGuardians", () => downedProfanedGuardians);

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

        internal static bool downedLepus;
        public static Condition lepus = new("CheckDowned.downedLepus", () => downedLepus);

        internal static bool downedTurkor;
        public static Condition turkor = new("CheckDowned.downedTurkor", () => downedTurkor);
  
        internal static bool downedOcram;
        public static Condition ocram = new("CheckDowned.downedOcram", () => downedOcram);

        internal static bool downedGourd;
        public static Condition gourd = new("CheckDowned.downedGourd", () => downedGourd);

        internal static bool downedMoco;
        public static Condition moco = new("CheckDowned.downedMoco", () => downedMoco);

        internal static bool downedOrroBoro;
        public static Condition orroboro = new("CheckDowned.downedOrroBoro", () => downedOrroBoro);

        internal static bool downedBigBone;
        public static Condition bigbone = new("CheckDowned.downedBigBone", () => downedBigBone);

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

        internal static bool downedGeldon;
        public static Condition geldon = new("CheckDowned.downedGeldon", () => downedGeldon);

        internal static bool downedCrabson;
        public static Condition crabson = new("CheckDowned.downedCrabson", () => downedCrabson);

        internal static bool downedStarite;
        public static Condition starite = new("CheckDowned.downedStarite", () => downedStarite);

        internal static bool downedDevil;
        public static Condition devil = new("CheckDowned.downedDevil", () => downedDevil);

        internal static bool downedSprite;
        public static Condition sprite = new("CheckDowned.downedSprite", () => downedSprite);

        internal static bool downedSpaceSquid;
        public static Condition spacesquid = new("CheckDowned.downedSpaceSquid", () => downedSpaceSquid);

        internal static bool downedUltraStarite;
        public static Condition ultrastarite = new("CheckDowned.downedUltraStarite", () => downedUltraStarite);

        internal static bool calamityLoaded;
        public static Condition calamityloaded = new("CheckDowned.calamityLoaded", () => calamityLoaded);

        internal static Mod calamityMod;

        internal static bool thoriumLoaded;
        public static Condition thoriumloaded = new("CheckDowned.thoriumLoaded", () => thoriumLoaded);

        internal static Mod thoriumMod;

        internal static bool sotsLoaded;
        public static Condition sotsloaded = new("CheckDowned.sotsLoaded", () => sotsLoaded);

        internal static Mod sotsMod;

        internal static bool vitalityLoaded;
        public static Condition vitalityloaded = new("CheckDowned.vitalityLoaded", () => vitalityLoaded);

        internal static Mod vitalityMod;

        internal static bool consolariaLoaded;
        public static Condition consolarialoaded = new("CheckDowned.consolariaLoaded", () => consolariaLoaded);

        internal static Mod consolariaMod;

        internal static bool spookyLoaded;
        public static Condition spookyloaded = new("CheckDowned.spookyLoaded", () => spookyLoaded);

        internal static Mod spookyMod;

        internal static bool fargosSoulsLoaded;
        public static Condition soulsloaded = new("CheckDowned.fargosSoulsLoaded", () => fargosSoulsLoaded);

        internal static Mod fargosSoulsMod;

        internal static bool polaritiesLoaded;
        public static Condition polaritiesloaded = new("CheckDowned.polaritiesLoaded", () => polaritiesLoaded);

        internal static Mod polaritiesMod;

        internal static bool redemptionLoaded;
        public static Condition redemptionloaded = new("CheckDowned.redemptionLoaded", () => redemptionLoaded);

        internal static Mod redemptionMod;

        internal static bool terrorbornLoaded;
        public static Condition terrorbornloaded = new("CheckDowned.terrorbornLoaded", () => terrorbornLoaded);

        internal static Mod terrorbornMod;

        internal static bool homewardLoaded;
        public static Condition homewardloaded = new("CheckDowned.homewardLoaded", () => homewardLoaded);

        internal static Mod homewardMod;

        internal static bool catalystLoaded;
        public static Condition catalystloaded = new("CheckDowned.catalystLoaded", () => catalystLoaded);

        internal static Mod catalystMod;

        internal static bool aqLoaded;
        public static Condition aqloaded = new("CheckDowned.aqLoaded", () => aqLoaded);

        internal static Mod aqMod;
    }
}
