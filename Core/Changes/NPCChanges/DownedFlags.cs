namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class DownedFlags : GlobalNPC
    {
        //FOR NPCs THAT DON'T TECHNICALLY "DIE"
        public override bool PreAI(NPC npc)
        {
            if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "Glassweaver") && npc.life <= 1)
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Glassweaver], -1);
            return base.PreAI(npc);
        }

        //NORMAL CIRCUMSTANCES
        public override void OnKill(NPC npc)
        {
            #region Vanilla
            if (npc.type == NPCID.BloodNautilus)
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dreadnautilus], -1);

            if (npc.type == NPCID.MartianSaucerCore || npc.type == NPCID.MartianSaucer)
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MartianSaucer], -1);
            #endregion

            #region AFKPets
            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "SlayerofEvil"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SlayerOfEvil], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "SATLA001"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SATLA], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "DrFetusThirdPhase"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DrFetus], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "MechanicalSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SlimesHope], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "PoliticianSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PoliticianSlime], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "FlagCarrier"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientTrio], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "LavalGolem"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.LavalGolem], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "NecromancerDummy"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Antony], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "BunnyZepplin"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BunnyZeppelin], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "Okiku"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Okiku], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "StormTinkererH"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyAirforce], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "DemonIsaac"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Isaac], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "AncientGuardian"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientGuardian], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "HeroicSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HeroicSlime], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "HolographicSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HoloSlime], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "SecurityBot"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SecurityBot], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "UndeadChef") || npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "ChefEnergy"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UndeadChef], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "NekoSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NekoSlime], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "NightmareAmplifierSlime") || npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "NightmareAmplifierSlimeDeath"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NightmareAmplifierSlime], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "IceGuardian") || npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "IceWormH"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GuardianOfFrost], -1);
            #endregion

            #region Assorted Crazy Things
            if (npc.type == Common.GetModNPC(ModConditions.assortedCrazyThingsMod, "HarvesterBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SoulHarvester], -1);
            #endregion

            #region Awful Garbage Mod
            if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "TreeToad"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TreeToad], -1);

            if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "SeseKitsugai"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SeseKitsugai], -1);

            if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "EyeOfTheStorm"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EyeOfTheStorm], -1);

            if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "FrigidiusHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Frigidius], -1);
            #endregion

            #region Blocks Core Boss
            if (npc.type == Common.GetModNPC(ModConditions.blocksCoreBossMod, "CoreBoss") || npc.type == Common.GetModNPC(ModConditions.blocksCoreBossMod, "CoreBossCrim"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CoreBoss], -1);
            #endregion

            #region Calamity Community Remix
            if (npc.type == Common.GetModNPC(ModConditions.calamityCommunityRemixMod, "WulfwyrmHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WulfrumExcavator], -1);
            #endregion

            #region Calamity Entropy
            if (npc.type == Common.GetModNPC(ModConditions.calamityEntropyMod, "Luminaris"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Luminaris], -1);

            if (npc.type == Common.GetModNPC(ModConditions.calamityEntropyMod, "TheProphet"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Prophet], -1);

            if (npc.type == Common.GetModNPC(ModConditions.calamityEntropyMod, "NihilityActeriophage"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NihilityTwin], -1);

            if (npc.type == Common.GetModNPC(ModConditions.calamityEntropyMod, "CruiserHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cruiser], -1);
            #endregion

            #region Catalyst
            if (npc.type == Common.GetModNPC(ModConditions.catalystMod, "Astrageldon"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Astrageldon], -1);
            #endregion

            #region Clamity Addon
            if (npc.type == Common.GetModNPC(ModConditions.clamityAddonMod, "ClamitasBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Clamitas], -1);

            if (npc.type == Common.GetModNPC(ModConditions.clamityAddonMod, "PyrogenBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Pyrogen], -1);

            if (npc.type == Common.GetModNPC(ModConditions.clamityAddonMod, "WallOfBronze"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfBronze], -1);
            #endregion

            #region Consolaria
            if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "Lepus"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lepus], -1);

            if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "TurkortheUngrateful"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Turkor], -1);

            if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "Ocram"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ocram], -1);
            #endregion

            #region Coralite
            if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "Rediancie"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Rediancie], -1);

            if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "BabyIceDragon"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BabyIceDragon], -1);

            if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "SlimeEmperor"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SlimeEmperor], -1);

            if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "Bloodiancie"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodiancie], -1);

            if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "ThunderveinDragon"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ThunderveinDragon], -1);

            if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "NightmarePlantera"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NightmarePlantera], -1);
            #endregion

            #region Depths
            if (npc.type == Common.GetModNPC(ModConditions.depthsMod, "ChasmeHeart"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Chasme], -1);
            #endregion

            #region Dormant Dawn [WIP]
            /*
            if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "LifeGuard"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedLifeGuardian, -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "StarGuard"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedManaGuardian, -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "MeteorDigger_Head"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedMeteorExcavator, -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "MeteorAnnihilator"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedMeteorAnnihilator, -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "????"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedHellfireSerpent, -1);
            }
            */
            #endregion

            #region Echoes of the Ancients
            if (npc.type == Common.GetModNPC(ModConditions.echoesOfTheAncientsMod, "Galahis"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Galahis], -1);

            if (npc.type == Common.GetModNPC(ModConditions.echoesOfTheAncientsMod, "AquaWormHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Creation], -1);

            if (npc.type == Common.GetModNPC(ModConditions.echoesOfTheAncientsMod, "PumpkinWormHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Destruction], -1);
            #endregion

            #region Edorbis
            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "BlightKing"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BlightKing], -1);

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "TheGardener"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Gardener], -1);

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "GlaciationHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Glaciation], -1);

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "HandofCthulhu"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HandOfCthulhu], -1);

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "CursedLord"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CursePreacher], -1);
            #endregion

            #region Elements Awoken
            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "Wasteland"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Wasteland], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "Infernace"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Infernace], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "ScourgeFighter"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ScourgeFighter], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "RegarothHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Regaroth], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "Permafrost"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Permafrost], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "Obsidious"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Obsidious], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "Aqueous"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Aqueous], -1);

            if ((npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "AncientWyrmHead") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.elementsAwokenMod, "TheEye"))) || npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "TheEye") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.elementsAwokenMod, "AncientWyrmHead")))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheTempleKeepers], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "TheGuardianFly"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheGuardian], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "Volcanox"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Volcanox], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "VoidLeviathanHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.VoidLeviathan], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "Azana"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Azana], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "AncientAmalgam"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheAncients], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "CosmicObserver"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CosmicObserver], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "ShadeWyrmHead") || npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "ShadeWyrmBody") || npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "ShadeWyrmTail"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ShadeWyrm], -1);

            if (npc.type == Common.GetModNPC(ModConditions.elementsAwokenMod, "RadiantMaster"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RadiantMaster], -1);

            List<int> dawnOfTheVoidNPCs = new()
                {
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "Immolator"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "ReaverSlime"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "VoidKnight"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "VoidElemental"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "AbyssSkull"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "AbyssSkullette"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "VoidFly"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "AccursedFlier"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "DimensionalHive"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "ZergCaster"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "ShadeWyrmHead"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "ShadeWyrmBody"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "ShadeWyrmTail"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "EtherealHunter"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "VoidCrawler"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "VoidGolem")
                };
            if (dawnOfTheVoidNPCs.Contains(npc.type))
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.DawnOfTheVoid], -1);

            List<int> radiantRainNPCs = new()
                {
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "SparklingSlime"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "RadiantWarrior"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "StellarStarfish"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "AllKnowerHead"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "StarlightGlobule"),
                    Common.GetModNPC(ModConditions.elementsAwokenMod, "RadiantMaster")
                };
            if (radiantRainNPCs.Contains(npc.type))
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.RadiantRain], -1);
            #endregion

            #region Exalt
            if (npc.type == Common.GetModNPC(ModConditions.exaltMod, "Effulgence"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Effulgence], -1);

            if (npc.type == Common.GetModNPC(ModConditions.exaltMod, "IceLich"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.IceLich], -1);
            #endregion

            #region Excelsior
            if (npc.type == Common.GetModNPC(ModConditions.excelsiorMod, "Niflheim"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Niflheim], -1);

            if (npc.type == Common.GetModNPC(ModConditions.excelsiorMod, "StellarStarship"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StellarStarship], -1);
            #endregion

            #region Exxo Avalon Origins
            if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "BacteriumPrime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BacteriumPrime], -1);

            if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "DesertBeak"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DesertBeak], -1);

            if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "KingSting"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.KingSting], -1);

            if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "Mechasting"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Mechasting], -1);

            if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "Phantasm"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Phantasm], -1);
            #endregion

            #region Fargos Souls
            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "TrojanSquirrel"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TrojanSquirrel], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "CursedCoffin"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CursedCoffin], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "DeviBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Deviantt], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "BanishedBaron"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BanishedBaron], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "LifeChallenger"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lifelight], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "CosmosChampion"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Eridanus], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "AbomBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Abominationn], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "MutantBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Mutant], -1);
            #endregion

            #region Fractures of Penumbra
            if (npc.type == Common.GetModNPC(ModConditions.fracturesOfPenumbraMod, "AlphaFrostjawHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AlphaFrostjaw], -1);

            if (npc.type == Common.GetModNPC(ModConditions.fracturesOfPenumbraMod, "SanguineElemental"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SanguineElemental], -1);
            #endregion

            #region GaMeTerraria
            if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "Lad"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lad], -1);
            
            if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "Hornlitz"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Hornlitz], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "SnowDonCore"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SnowDon], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "Stoffie"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Stoffie], -1);
            #endregion

            #region Gensokyo
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "LilyWhite"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.LilyWhite], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Rumia"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Rumia], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "EternityLarva"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EternityLarva], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Nazrin"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nazrin], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "HinaKagiyama"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HinaKagiyama], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Sekibanki"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Sekibanki], -1);

            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Seiran"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Seiran], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "NitoriKawashiro"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NitoriKawashiro], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MedicineMelancholy"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MedicineMelancholy], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Cirno"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cirno], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MinamitsuMurasa"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MinamitsuMurasa], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "AliceMargatroid"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AliceMargatroid], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "SakuyaIzayoi"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SakuyaIzayoi], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "SeijaKijin"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SeijaKijin], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MayumiJoutouguu"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MayumiJoutouguu], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "ToyosatomimiNoMiko"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ToyosatomimiNoMiko], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "KaguyaHouraisan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.KaguyaHouraisan], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "UtsuhoReiuji"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UtsuhoReiuji], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "TenshiHinanawi"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TenshiHinanawi], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Kisume"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Kisume], -1);
            }
            #endregion

            #region Gerd's Lab
            if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Trerios"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Trerios], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "MagmaEye"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MagmaEye], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Jack"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Jack], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Acheron"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Acheron], -1);
            }
            #endregion

            #region Homeward Journey
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "GoblinChariot"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GoblinChariot], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "BigDipper"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BigDipper], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "PuppetOpera"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PuppetOpera], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "MarquisMoonsquid"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MarquisMoonsquid], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "PriestessRod"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PriestessRod], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Diver"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Diver], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMotherbrain"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Motherbrain], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WallofShadow"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfShadow], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "SlimeGod"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SunSlimeGod], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheOverwatcher"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Overwatcher], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheLifebringerHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lifebringer], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMaterealizer"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Materealizer], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ScarabBelief], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WorldsEndEverlastingFallingWhale"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WorldsEndWhale], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheSon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Son], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Cave"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CaveOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Corruption"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CorruptOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Crimson"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CrimsonOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Desert"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DesertOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Forest"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ForestOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Hallow"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HallowOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Jungle"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.JungleOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Pure"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SkyOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Snow"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SnowOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Underworld"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UnderworldOrdeal], -1);
            }
            #endregion

            #region Hunt of the Old God
            if (npc.type == Common.GetModNPC(ModConditions.huntOfTheOldGodMod, "Goozma"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Goozma], -1);
            }
            #endregion

            #region Infernum
            if (npc.type == Common.GetModNPC(ModConditions.infernumMod, "BereftVassal"))
            {
                SubworldModConditions.downedBereftVassal = true;
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal], -1);
            }
            #endregion

            #region Lunar Veil
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "StarrVeriplant"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StoneGuardian], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "CommanderGintzia"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CommanderGintzia], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.GintzeArmy], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "SunStalker"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SunStalker], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Jack"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PumpkinJack], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "DaedusR"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ForgottenPuppetDaedus], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "DreadMire"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DreadMire], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "SingularityFragment"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SingularityFragment], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "VerliaB"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Verlia], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Gothiviab"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Irradia], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Sylia"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Sylia], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Fenix"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Fenix], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "BlazingSerpentHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BlazingSerpent], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Cogwork"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cogwork], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "WaterCogwork"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WaterCogwork], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "WaterJellyfish"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WaterJellyfish], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Sparn"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Sparn], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "PandorasFlamebox"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PandorasFlamebox], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "STARBOMBER"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.STARBOMBER], -1);
            }
            #endregion

            #region Martin's Order
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Britzz"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Britzz], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "CactusCat"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CactusCat], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Alchemist"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheAlchemist], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "CarnagePillar"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CarnagePillar], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "VoidDiggerHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.VoidDigger], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "PrinceSlime"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PrinceSlime], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Evocornator") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.martainsOrderMod, "Retinator")) && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.martainsOrderMod, "Spazmator")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Retinator") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.martainsOrderMod, "Evocornator")) && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.martainsOrderMod, "Spazmator")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Spazmator") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.martainsOrderMod, "Evocornator")) && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.martainsOrderMod, "Retinator")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "MechPlantera"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.JungleDefenders], -1);
            }
            //EVENTS
            List<int> hauntedRainforestNPCs = new()
            {
                    Common.GetModNPC(ModConditions.martainsOrderMod, "BunnySpirit"),
                    Common.GetModNPC(ModConditions.martainsOrderMod, "EagleSpirit"),
                    Common.GetModNPC(ModConditions.martainsOrderMod, "NaiveSpirit"),
                    Common.GetModNPC(ModConditions.martainsOrderMod, "SlimeSpirit"),
                    Common.GetModNPC(ModConditions.martainsOrderMod, "TreeSpirit"),
                    Common.GetModNPC(ModConditions.martainsOrderMod, "WolfSpirit")
            };
            if (hauntedRainforestNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.HauntedRainforest], -1);
            }
            #endregion

            #region Mech Boss Rework
            if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "Mechclops"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.St4sys], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "TheTerminator"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Terminator], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "Caretaker"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Caretaker], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "SiegeEngine"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SiegeEngine], -1);
            }
            #endregion

            #region Medial Rift
            if (npc.type == Common.GetModNPC(ModConditions.medialRiftMod, "SuperVoltaicMotherSlime"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SuperVMS], -1);
            }
            #endregion

            #region Metroid
            if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Torizo"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Torizo], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Serris_Head"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Serris], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Kraid_Head"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Kraid], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Phantoon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Phantoon], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "OmegaPirate"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaPirate], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Nightmare"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nightmare], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "GoldenTorizo"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GoldenTorizo], -1);
            }
            #endregion

            #region Ophioid
            if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "OphiopedeHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiopede], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "Ophiocoon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiocoon], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "Ophiofly"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiofly], -1);
            }
            #endregion

            #region Polarities
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "StormCloudfish"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloudfish], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "StarConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StarConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Gigabat"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Gigabat], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "RiftDenizen"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RiftDenizen], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "SunPixie"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SunPixie], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Esophage"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Esophage], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "ConvectiveWanderer"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ConvectiveWanderer], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "SelfsimilarSentinel"))
            {
                SubworldModConditions.downedSelfsimilarSentinel = true;
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SelfsimilarSentinel], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Eclipxie"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Eclipxie], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Hemorrphage"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Hemorrphage], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Electris") || npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Magneton"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Polarities], -1);
            }
            #endregion

            #region Project Zero
            if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "ForestGuardian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ForestGuardian], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "CryoGuardian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CryoGuardian], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "PrimordialWormHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PrimordialWorm], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "HellGuardian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheGuardianOfHell], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "Void"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Void], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "ArmagemHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Armagem], -1);
            }
            #endregion

            #region Qwerty's Mod
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "PolarBear"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PolarExterminator], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "FortressBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DivineLight], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "AncientMachine"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientMachine], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "CloakedDarkBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Noehtnap], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Hydra"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Hydra], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Imperious"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Imperious], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "RuneGhost"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RuneGhost], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "InvaderBattleship"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderBattleship], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "InvaderNoehtnap"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderNoehtnap], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.SpaceInvaders], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "OLORDv2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OLORD], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "TheGreatTyrannosaurus"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GreatTyrannosaurus], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.DinoMilitia], -1);
            }
            #endregion

            #region Redemption
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Thorn"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Thorn], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Erhan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Erhan], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Keeper"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Keeper], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "SoI"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SeedOfInfection], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "KS3"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.KingSlayerIII], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OmegaCleaver"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaCleaver], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Gigapora"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaGigapora], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OO"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaObliterator], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "PZ"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PatientZero], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Akka") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.redemptionMod, "Ukko")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Akka], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientDeityDuo], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Ukko") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.redemptionMod, "Akka")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ukko], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientDeityDuo], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nebuleus], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nebuleus], -1);
            }
            //MINIBOSSES
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "FowlEmperor"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FowlEmperor], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Cockatrice"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cockatrice], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Basan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Basan], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.FowlMorning], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "SkullDigger"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SkullDigger], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "EaglecrestGolem"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EaglecrestGolem], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Calavia"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Calavia], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "JanitorBot"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheJanitor], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "IrradiatedBehemoth"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.IrradiatedBehemoth], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Blisterface"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Blisterface], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "ProtectorVolt"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ProtectorVolt], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "MACEProject"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MACEProject], -1);
            }
            //EVENTS
            List<int> raveyardNPCs = new()
            {
                Common.GetModNPC(ModConditions.redemptionMod, "CorpseWalkerPriest"),
                Common.GetModNPC(ModConditions.redemptionMod, "DancingSkeleton"),
                Common.GetModNPC(ModConditions.redemptionMod, "EpidotrianSkeleton"),
                Common.GetModNPC(ModConditions.redemptionMod, "JollyMadman"),
                Common.GetModNPC(ModConditions.redemptionMod, "RaveyardSkeleton"),
                Common.GetModNPC(ModConditions.redemptionMod, "SkeletonAssassin"),
                Common.GetModNPC(ModConditions.redemptionMod, "SkeletonDuelist"),
                Common.GetModNPC(ModConditions.redemptionMod, "SkeletonFlagbearer"),
                Common.GetModNPC(ModConditions.redemptionMod, "SkeletonNoble"),
                Common.GetModNPC(ModConditions.redemptionMod, "SkeletonWanderer"),
                Common.GetModNPC(ModConditions.redemptionMod, "SkeletonWarden"),
            };
            if (raveyardNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Raveyard], -1);
            }
            #endregion

            #region Secrets of the Shadows
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Glowmoth"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Glowmoth], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PutridPinkyPhase2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PutridPinky], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PharaohsCurse"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PharaohsCurse], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Excavator") || npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "GulaSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Excavator], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TheAdvisorHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Advisor], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlySpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Polaris") || npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NewPolaris"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Polaris], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Lux"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lux], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "SubspaceSerpentHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SubspaceSerpent], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NatureConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NatureConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EarthenConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PermafrostConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TidalConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TidalConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "OtherworldlyConstructHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlyConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "OtherworldlyConstructHead2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlyConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EvilConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EvilConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "InfernoConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "ChaosConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NatureSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NatureSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EarthenSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PermafrostSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TidalSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TidalSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EvilSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EvilSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "InfernoSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoSpirit], -1);
            }
            #endregion

            #region Shadows of Abaddon
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Decree"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Decree], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Ralnek") && Condition.InClassicMode.IsMet())
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FlamingPumpkin], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "RalnekPhase3") && ModConditions.expertOrMaster.IsMet())
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FlamingPumpkin], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "ZombiePigmanBrute"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ZombiePiglinBrute], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Jensen"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.JensenTheGrandHarpy], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Araneas"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Araneas], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Raynare"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyQueenRaynare], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Primordia2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Primordia], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Abaddon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Abaddon], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "AraghurHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Araghur], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Novaniel"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.LostSiblings], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "ErazorBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Erazor], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Nihilus2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nihilus], -1);
            }
            #endregion

            #region Sloome
            if (npc.type == Common.GetModNPC(ModConditions.sloomeMod, "ExoSlimeGod"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Exodygen], -1);
            }
            #endregion

            #region Spirit
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "Scarabeus"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Scarabeus], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "MoonWizard"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MoonJellyWizard], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.JellyDeluge], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "ReachBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.VinewrathBane], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "AncientFlyer"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientAvian], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "SteamRaiderHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StarplateVoyager], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "Infernon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Infernon], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "Dusking"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dusking], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "Atlas"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Atlas], -1);
            }
            //EVENTS
            List<int> jellyDelugeNPCs = new()
                {
                    Common.GetModNPC(ModConditions.spiritClassicMod, "MoonlightPreserver"),
                    Common.GetModNPC(ModConditions.spiritClassicMod, "ExplodingMoonjelly"),
                    Common.GetModNPC(ModConditions.spiritClassicMod, "MoonjellyGiant")
                };
            if (jellyDelugeNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.JellyDeluge], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spiritClassicMod, "Rylheian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.TheTide], -1);
            }
            List<int> mysticMoonNPCs = new()
                {
                    Common.GetModNPC(ModConditions.spiritClassicMod, "Bloomshroom"),
                    Common.GetModNPC(ModConditions.spiritClassicMod, "Glitterfly"),
                    Common.GetModNPC(ModConditions.spiritClassicMod, "GlowToad"),
                    Common.GetModNPC(ModConditions.spiritClassicMod, "Lumantis"),
                    Common.GetModNPC(ModConditions.spiritClassicMod, "LunarSlime"),
                    Common.GetModNPC(ModConditions.spiritClassicMod, "MadHatter")
                };
            if (mysticMoonNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.MysticMoon], -1);
            }
            #endregion

            #region Spooky
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "RotGourd"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RotGourd], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "SpookySpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SpookySpirit], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "Moco"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Moco], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "DaffodilEye"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Daffodil], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "OrroHead") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.spookyMod, "BoroHead")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OrroBoro], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "BoroHead") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.spookyMod, "OrroHead")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OrroBoro], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "BigBone"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BigBone], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "SpookFishron"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SpookFishron], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "Chester"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.PandorasBox], -1);
            }
            List<int> eggIncursionNPCs = new()
            {
                Common.GetModNPC(ModConditions.spookyMod, "Biojetter"),
                Common.GetModNPC(ModConditions.spookyMod, "BiojetterEye"),
                Common.GetModNPC(ModConditions.spookyMod, "CoughLungs"),
                Common.GetModNPC(ModConditions.spookyMod, "CruxBat"),
                Common.GetModNPC(ModConditions.spookyMod, "EarWorm"),
                Common.GetModNPC(ModConditions.spookyMod, "ExplodingAppendix"),
                Common.GetModNPC(ModConditions.spookyMod, "FleshBolster"),
                Common.GetModNPC(ModConditions.spookyMod, "GooSlug"),
                Common.GetModNPC(ModConditions.spookyMod, "HoppingHeart"),
                Common.GetModNPC(ModConditions.spookyMod, "HoverBrain"),
                Common.GetModNPC(ModConditions.spookyMod, "TongueBiter")
            };
            if (eggIncursionNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.EggIncursion], -1);
            }
            #endregion

            #region Starlight River
            if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "SquidBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Auroracle], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "VitricBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ceiros], -1);
            }
            #endregion

            #region Storm's Additions
            if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "AridBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientHusk], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "StormBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OverloadedScandrone], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "TheUltimateBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Painbringer], -1);
            }
            #endregion

            #region Supernova
            if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "HarbingerOfAnnihilation"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HarbingerOfAnnihilation], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "FlyingTerror"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FlyingTerror], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "StoneMantaRay"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StoneMantaRay], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "Bloodweaver"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodweaver], -1);
            }
            #endregion

            #region Terrorborn
            if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "InfectedIncarnate"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InfectedIncarnate], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "TidalTitan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TidalTitan], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "Dunestock"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dunestock], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "Shadowcrawler"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Shadowcrawler], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "HexedConstructor"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HexedConstructor], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "PrototypeI"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PrototypeI], -1);
            }
            #endregion

            #region TRAE
            if (npc.type == Common.GetModNPC(ModConditions.traeMod, "GraniteOvergrowthNPC"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GraniteOvergrowth], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.traeMod, "BeholderNPC"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Beholder], -1);
            }
            #endregion

            #region Uhtric
            if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "Dredger"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dredger], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CharcoolSnowman"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CharcoolSnowman], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CosmicMenace"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CosmicMenace], -1);
            }
            #endregion

            #region Universe of Swords
            if (npc.type == Common.GetModNPC(ModConditions.universeOfSwordsMod, "SwordBossNPC"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EvilFlyingBlade], -1);
            }
            #endregion

            #region Valhalla
            if (npc.type == Common.GetModNPC(ModConditions.valhallaMod, "Emperor"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Yurnero], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.valhallaMod, "PirateSquid"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ColossalCarnage], -1);
            }
            #endregion

            #region Vitality
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "StormCloudBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloud], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GrandAntlionBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GrandAntlion], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GemstoneElementalBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GemstoneElemental], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MoonlightDragonflyBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MoonlightDragonfly], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "DreadnaughtBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dreadnaught], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MosquitoMonarchBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MosquitoMonarch], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "AnarchulesBeetleBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AnarchulesBeetle], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "ChaosbringerBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Chaosbringer], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "PaladinSpiritBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PaladinSpirit], -1);
            }
            #endregion

            #region Wayfair Content
            if (npc.type == Common.GetModNPC(ModConditions.wayfairContentMod, "Lifebloom"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Manaflora], -1);
            }
            #endregion

            #region Zylon
            if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "Dirtball"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dirtball], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "MetelordHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Metelord], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "Adeneb"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Adeneb], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "EldritchJellyfish"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EldritchJellyfish], -1);
            }
            if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "SaburRex"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SaburRex], -1);
            }
            #endregion
        }
    }

}
