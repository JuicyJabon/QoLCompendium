namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class DownedFlags : GlobalNPC
    {
        //FOR NPCs THAT DON'T TECHNICALLY "DIE"
        public override bool PreAI(NPC npc)
        {
            if (npc.type == Common.GetModNPC(CrossModSupport.StarlightRiver.Mod, "Glassweaver") && npc.life <= 1)
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
            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "SlayerofEvil"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SlayerOfEvil], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "SATLA001"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SATLA], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "DrFetusThirdPhase"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DrFetus], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "MechanicalSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SlimesHope], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "PoliticianSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PoliticianSlime], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "FlagCarrier"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientTrio], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "LavalGolem"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.LavalGolem], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "NecromancerDummy"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Antony], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "BunnyZepplin"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BunnyZeppelin], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "Okiku"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Okiku], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "StormTinkererH"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyAirforce], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "DemonIsaac"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Isaac], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "AncientGuardian"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientGuardian], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "HeroicSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HeroicSlime], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "HolographicSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HoloSlime], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "SecurityBot"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SecurityBot], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "UndeadChef") || npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "ChefEnergy"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UndeadChef], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "NekoSlime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NekoSlime], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "NightmareAmplifierSlime") || npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "NightmareAmplifierSlimeDeath"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NightmareAmplifierSlime], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "IceGuardian") || npc.type == Common.GetModNPC(CrossModSupport.AFKPets.Mod, "IceWormH"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GuardianOfFrost], -1);
            #endregion

            #region Assorted Crazy Things
            if (npc.type == Common.GetModNPC(CrossModSupport.AssortedCrazyThings.Mod, "HarvesterBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SoulHarvester], -1);
            #endregion

            #region Awful Garbage Mod
            if (npc.type == Common.GetModNPC(CrossModSupport.AwfulGarbage.Mod, "TreeToad"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TreeToad], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AwfulGarbage.Mod, "SeseKitsugai"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SeseKitsugai], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AwfulGarbage.Mod, "EyeOfTheStorm"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EyeOfTheStorm], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.AwfulGarbage.Mod, "FrigidiusHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Frigidius], -1);
            #endregion

            #region Blocks Core Boss
            if (npc.type == Common.GetModNPC(CrossModSupport.BlocksCoreBoss.Mod, "CoreBoss") || npc.type == Common.GetModNPC(CrossModSupport.BlocksCoreBoss.Mod, "CoreBossCrim"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CoreBoss], -1);
            #endregion

            #region Calamity Community Remix
            if (npc.type == Common.GetModNPC(CrossModSupport.CalamityCommunityRemix.Mod, "WulfwyrmHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WulfrumExcavator], -1);
            #endregion

            #region Calamity Entropy
            if (npc.type == Common.GetModNPC(CrossModSupport.CalamityEntropy.Mod, "Luminaris"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Luminaris], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.CalamityEntropy.Mod, "TheProphet"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Prophet], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.CalamityEntropy.Mod, "NihilityActeriophage"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NihilityTwin], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.CalamityEntropy.Mod, "CruiserHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cruiser], -1);
            #endregion

            #region Catalyst
            if (npc.type == Common.GetModNPC(CrossModSupport.Catalyst.Mod, "Astrageldon"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Astrageldon], -1);
            #endregion

            #region Clamity Addon
            if (npc.type == Common.GetModNPC(CrossModSupport.Clamity.Mod, "ClamitasBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Clamitas], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Clamity.Mod, "PyrogenBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Pyrogen], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Clamity.Mod, "WallOfBronze"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfBronze], -1);
            #endregion

            #region Consolaria
            if (npc.type == Common.GetModNPC(CrossModSupport.Consolaria.Mod, "Lepus"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lepus], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Consolaria.Mod, "TurkortheUngrateful"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Turkor], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Consolaria.Mod, "Ocram"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ocram], -1);
            #endregion

            #region Coralite
            if (npc.type == Common.GetModNPC(CrossModSupport.Coralite.Mod, "Rediancie"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Rediancie], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Coralite.Mod, "BabyIceDragon"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BabyIceDragon], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Coralite.Mod, "SlimeEmperor"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SlimeEmperor], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Coralite.Mod, "Bloodiancie"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodiancie], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Coralite.Mod, "ThunderveinDragon"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ThunderveinDragon], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Coralite.Mod, "NightmarePlantera"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NightmarePlantera], -1);
            #endregion

            #region Depths
            if (npc.type == Common.GetModNPC(CrossModSupport.Depths.Mod, "ChasmeHeart"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Chasme], -1);
            #endregion

            #region Dormant Dawn [WIP]
            /*
            if (npc.type == Common.GetModNPC(CrossModSupport.DormantDawn.Mod, "LifeGuard"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedLifeGuardian, -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.DormantDawn.Mod, "StarGuard"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedManaGuardian, -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.DormantDawn.Mod, "MeteorDigger_Head"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedMeteorExcavator, -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.DormantDawn.Mod, "MeteorAnnihilator"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedMeteorAnnihilator, -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.DormantDawn.Mod, "????"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedHellfireSerpent, -1);
            }
            */
            #endregion

            #region Echoes of the Ancients
            if (npc.type == Common.GetModNPC(CrossModSupport.EchoesoftheAncients.Mod, "Galahis"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Galahis], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.EchoesoftheAncients.Mod, "AquaWormHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Creation], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.EchoesoftheAncients.Mod, "PumpkinWormHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Destruction], -1);
            #endregion

            #region Edorbis
            if (npc.type == Common.GetModNPC(CrossModSupport.Edorbis.Mod, "BlightKing"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BlightKing], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Edorbis.Mod, "TheGardener"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Gardener], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Edorbis.Mod, "GlaciationHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Glaciation], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Edorbis.Mod, "HandofCthulhu"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HandOfCthulhu], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Edorbis.Mod, "CursedLord"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CursePreacher], -1);
            #endregion

            #region Elements Awoken
            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Wasteland"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Wasteland], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Infernace"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Infernace], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ScourgeFighter"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ScourgeFighter], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "RegarothHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Regaroth], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Permafrost"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Permafrost], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Obsidious"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Obsidious], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Aqueous"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Aqueous], -1);

            if ((npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "AncientWyrmHead") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "TheEye"))) || npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "TheEye") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "AncientWyrmHead")))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheTempleKeepers], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "TheGuardianFly"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheGuardian], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Volcanox"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Volcanox], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "VoidLeviathanHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.VoidLeviathan], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Azana"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Azana], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "AncientAmalgam"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheAncients], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "CosmicObserver"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CosmicObserver], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ShadeWyrmHead") || npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ShadeWyrmBody") || npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ShadeWyrmTail"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ShadeWyrm], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "RadiantMaster"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RadiantMaster], -1);

            List<int> dawnOfTheVoidNPCs = new()
                {
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "Immolator"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ReaverSlime"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "VoidKnight"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "VoidElemental"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "AbyssSkull"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "AbyssSkullette"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "VoidFly"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "AccursedFlier"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "DimensionalHive"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ZergCaster"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ShadeWyrmHead"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ShadeWyrmBody"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "ShadeWyrmTail"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "EtherealHunter"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "VoidCrawler"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "VoidGolem")
                };
            if (dawnOfTheVoidNPCs.Contains(npc.type))
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.DawnOfTheVoid], -1);

            List<int> radiantRainNPCs = new()
                {
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "SparklingSlime"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "RadiantWarrior"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "StellarStarfish"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "AllKnowerHead"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "StarlightGlobule"),
                    Common.GetModNPC(CrossModSupport.ElementsAwoken.Mod, "RadiantMaster")
                };
            if (radiantRainNPCs.Contains(npc.type))
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.RadiantRain], -1);
            #endregion

            #region Exalt
            if (npc.type == Common.GetModNPC(CrossModSupport.Exalt.Mod, "Effulgence"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Effulgence], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Exalt.Mod, "IceLich"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.IceLich], -1);
            #endregion

            #region Excelsior
            if (npc.type == Common.GetModNPC(CrossModSupport.Excelsior.Mod, "Niflheim"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Niflheim], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Excelsior.Mod, "StellarStarship"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StellarStarship], -1);
            #endregion

            #region Exxo Avalon Origins
            if (npc.type == Common.GetModNPC(CrossModSupport.ExxoAvalonOrigins.Mod, "BacteriumPrime"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BacteriumPrime], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ExxoAvalonOrigins.Mod, "DesertBeak"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DesertBeak], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ExxoAvalonOrigins.Mod, "KingSting"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.KingSting], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ExxoAvalonOrigins.Mod, "Mechasting"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Mechasting], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.ExxoAvalonOrigins.Mod, "Phantasm"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Phantasm], -1);
            #endregion

            #region Fargos Souls
            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "TrojanSquirrel"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TrojanSquirrel], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "CursedCoffin"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CursedCoffin], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "DeviBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Deviantt], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "BanishedBaron"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BanishedBaron], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "LifeChallenger"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lifelight], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "CosmosChampion"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Eridanus], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "AbomBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Abominationn], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FargowiltasSouls.Mod, "MutantBoss"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Mutant], -1);
            #endregion

            #region Fractures of Penumbra
            if (npc.type == Common.GetModNPC(CrossModSupport.FracturesOfPenumbra.Mod, "AlphaFrostjawHead"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AlphaFrostjaw], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.FracturesOfPenumbra.Mod, "SanguineElemental"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SanguineElemental], -1);
            #endregion

            #region GaMeTerraria
            if (npc.type == Common.GetModNPC(CrossModSupport.GaMeTerraria.Mod, "Lad"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lad], -1);
            
            if (npc.type == Common.GetModNPC(CrossModSupport.GaMeTerraria.Mod, "Hornlitz"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Hornlitz], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.GaMeTerraria.Mod, "SnowDonCore"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SnowDon], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.GaMeTerraria.Mod, "Stoffie"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Stoffie], -1);
            #endregion

            #region Gensokyo
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "LilyWhite"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.LilyWhite], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "Rumia"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Rumia], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "EternityLarva"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EternityLarva], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "Nazrin"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nazrin], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "HinaKagiyama"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HinaKagiyama], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "Sekibanki"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Sekibanki], -1);

            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "Seiran"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Seiran], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "NitoriKawashiro"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NitoriKawashiro], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "MedicineMelancholy"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MedicineMelancholy], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "Cirno"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cirno], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "MinamitsuMurasa"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MinamitsuMurasa], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "AliceMargatroid"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AliceMargatroid], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "SakuyaIzayoi"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SakuyaIzayoi], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "SeijaKijin"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SeijaKijin], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "MayumiJoutouguu"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MayumiJoutouguu], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "ToyosatomimiNoMiko"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ToyosatomimiNoMiko], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "KaguyaHouraisan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.KaguyaHouraisan], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "UtsuhoReiuji"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UtsuhoReiuji], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "TenshiHinanawi"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TenshiHinanawi], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Gensokyo.Mod, "Kisume"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Kisume], -1);
            }
            #endregion

            #region Gerd's Lab
            if (npc.type == Common.GetModNPC(CrossModSupport.GerdsLab.Mod, "Trerios"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Trerios], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.GerdsLab.Mod, "MagmaEye"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MagmaEye], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.GerdsLab.Mod, "Jack"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Jack], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.GerdsLab.Mod, "Acheron"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Acheron], -1);
            }
            #endregion

            #region Homeward Journey
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "GoblinChariot"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GoblinChariot], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "BigDipper"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BigDipper], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "PuppetOpera"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PuppetOpera], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "MarquisMoonsquid"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MarquisMoonsquid], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "PriestessRod"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PriestessRod], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Diver"))
            {
                SubworldModConditions.downedDiver = true;
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Diver], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "TheMotherbrain"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Motherbrain], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "WallofShadow"))
            {
                SubworldModConditions.downedWallOfShadow = true;
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfShadow], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "SlimeGod"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SunSlimeGod], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "TheOverwatcher"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Overwatcher], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "TheLifebringerHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lifebringer], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "TheMaterealizer"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Materealizer], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "ScarabBelief"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ScarabBelief], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "WorldsEndEverlastingFallingWhale"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WorldsEndWhale], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "TheSon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Son], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Cave"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CaveOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Corruption"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CorruptOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Crimson"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CrimsonOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Desert"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DesertOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Forest"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ForestOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Hallow"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HallowOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Jungle"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.JungleOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Pure"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SkyOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Snow"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SnowOrdeal], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "Trial_Underworld"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UnderworldOrdeal], -1);
            }
            #endregion

            #region Hunt of the Old God
            if (npc.type == Common.GetModNPC(CrossModSupport.HuntOfTheOldGod.Mod, "Goozma"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Goozma], -1);
            }
            #endregion

            #region Infernum
            if (npc.type == Common.GetModNPC(CrossModSupport.Infernum.Mod, "BereftVassal"))
            {
                SubworldModConditions.downedBereftVassal = true;
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal], -1);
            }
            #endregion

            #region Lunar Veil
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "StarrVeriplant"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StoneGuardian], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "CommanderGintzia"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CommanderGintzia], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.GintzeArmy], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "SunStalker"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SunStalker], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "Jack"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PumpkinJack], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "DaedusR"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ForgottenPuppetDaedus], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "DreadMire"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DreadMire], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "SingularityFragment"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SingularityFragment], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "VerliaB"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Verlia], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "Gothiviab"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Irradia], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "Sylia"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Sylia], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "Fenix"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Fenix], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "BlazingSerpentHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BlazingSerpent], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "Cogwork"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cogwork], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "WaterCogwork"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WaterCogwork], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "WaterJellyfish"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.WaterJellyfish], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "Sparn"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Sparn], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "PandorasFlamebox"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PandorasFlamebox], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.LunarVeil.Mod, "STARBOMBER"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.STARBOMBER], -1);
            }
            #endregion

            #region Martin's Order
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Britzz"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Britzz], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "CactusCat"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CactusCat], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Alchemist"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheAlchemist], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "CarnagePillar"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CarnagePillar], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "VoidDiggerHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.VoidDigger], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "PrinceSlime"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PrinceSlime], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Evocornator") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Retinator")) && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Spazmator")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Retinator") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Evocornator")) && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Spazmator")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Spazmator") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Evocornator")) && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "Retinator")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Triplets], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "MechPlantera"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.JungleDefenders], -1);
            }
            //EVENTS
            List<int> hauntedRainforestNPCs = new()
            {
                    Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "BunnySpirit"),
                    Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "EagleSpirit"),
                    Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "NaiveSpirit"),
                    Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "SlimeSpirit"),
                    Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "TreeSpirit"),
                    Common.GetModNPC(CrossModSupport.MartinsOrder.Mod, "WolfSpirit")
            };
            if (hauntedRainforestNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.HauntedRainforest], -1);
            }
            #endregion

            #region Mech Boss Rework
            if (npc.type == Common.GetModNPC(CrossModSupport.MechBossRework.Mod, "Mechclops"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.St4sys], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MechBossRework.Mod, "TheTerminator"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Terminator], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MechBossRework.Mod, "Caretaker"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Caretaker], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.MechBossRework.Mod, "SiegeEngine"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SiegeEngine], -1);
            }
            #endregion

            #region Medial Rift
            if (npc.type == Common.GetModNPC(CrossModSupport.MedialRift.Mod, "SuperVoltaicMotherSlime"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SuperVMS], -1);
            }
            #endregion

            #region Metroid
            if (npc.type == Common.GetModNPC(CrossModSupport.Metroid.Mod, "Torizo"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Torizo], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Metroid.Mod, "Serris_Head"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Serris], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Metroid.Mod, "Kraid_Head"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Kraid], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Metroid.Mod, "Phantoon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Phantoon], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Metroid.Mod, "OmegaPirate"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaPirate], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Metroid.Mod, "Nightmare"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nightmare], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Metroid.Mod, "GoldenTorizo"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GoldenTorizo], -1);
            }
            #endregion

            #region Ophioid
            if (npc.type == Common.GetModNPC(CrossModSupport.Ophioid.Mod, "OphiopedeHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiopede], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Ophioid.Mod, "Ophiocoon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiocoon], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Ophioid.Mod, "Ophiofly"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ophiofly], -1);
            }
            #endregion

            #region Polarities
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "StormCloudfish"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloudfish], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "StarConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StarConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "Gigabat"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Gigabat], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "RiftDenizen"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RiftDenizen], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "SunPixie"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SunPixie], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "Esophage"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Esophage], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "ConvectiveWanderer"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ConvectiveWanderer], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "SelfsimilarSentinel"))
            {
                SubworldModConditions.downedSelfsimilarSentinel = true;
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SelfsimilarSentinel], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "Eclipxie"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Eclipxie], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "Hemorrphage"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Hemorrphage], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "Electris") || npc.type == Common.GetModNPC(CrossModSupport.Polarities.Mod, "Magneton"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Polarities], -1);
            }
            #endregion

            #region Project Zero
            if (npc.type == Common.GetModNPC(CrossModSupport.ProjectZero.Mod, "ForestGuardian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ForestGuardian], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ProjectZero.Mod, "CryoGuardian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CryoGuardian], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ProjectZero.Mod, "PrimordialWormHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PrimordialWorm], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ProjectZero.Mod, "HellGuardian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheGuardianOfHell], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ProjectZero.Mod, "Void"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Void], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ProjectZero.Mod, "ArmagemHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Armagem], -1);
            }
            #endregion

            #region Qwerty's Mod
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "PolarBear"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PolarExterminator], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "FortressBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.DivineLight], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "AncientMachine"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientMachine], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "CloakedDarkBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Noehtnap], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "Hydra"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Hydra], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "Imperious"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Imperious], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "RuneGhost"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RuneGhost], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "InvaderBattleship"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderBattleship], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "InvaderNoehtnap"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InvaderNoehtnap], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.SpaceInvaders], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "OLORDv2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OLORD], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Qwerty.Mod, "TheGreatTyrannosaurus"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GreatTyrannosaurus], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.DinoMilitia], -1);
            }
            #endregion

            #region Redemption
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Thorn"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Thorn], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Erhan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Erhan], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Keeper"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Keeper], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "SoI"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SeedOfInfection], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "KS3"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.KingSlayerIII], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "OmegaCleaver"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaCleaver], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Gigapora"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaGigapora], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "OO"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OmegaObliterator], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "PZ"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PatientZero], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Akka") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.Redemption.Mod, "Ukko")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Akka], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientDeityDuo], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Ukko") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.Redemption.Mod, "Akka")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ukko], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientDeityDuo], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Nebuleus"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nebuleus], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Nebuleus2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nebuleus], -1);
            }
            //MINIBOSSES
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "FowlEmperor"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FowlEmperor], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Cockatrice"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Cockatrice], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Basan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Basan], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.FowlMorning], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "SkullDigger"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SkullDigger], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "EaglecrestGolem"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EaglecrestGolem], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Calavia"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Calavia], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "JanitorBot"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TheJanitor], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "IrradiatedBehemoth"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.IrradiatedBehemoth], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "Blisterface"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Blisterface], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "ProtectorVolt"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ProtectorVolt], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Redemption.Mod, "MACEProject"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MACEProject], -1);
            }
            //EVENTS
            List<int> raveyardNPCs = new()
            {
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "CorpseWalkerPriest"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "DancingSkeleton"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "EpidotrianSkeleton"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "JollyMadman"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "RaveyardSkeleton"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "SkeletonAssassin"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "SkeletonDuelist"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "SkeletonFlagbearer"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "SkeletonNoble"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "SkeletonWanderer"),
                Common.GetModNPC(CrossModSupport.Redemption.Mod, "SkeletonWarden"),
            };
            if (raveyardNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.Raveyard], -1);
            }
            #endregion

            #region Secrets of the Shadows
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "Glowmoth"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Glowmoth], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "PutridPinkyPhase2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PutridPinky], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "PharaohsCurse"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PharaohsCurse], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "Excavator") || npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "GulaSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Excavator], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "TheAdvisorHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Advisor], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlySpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "Polaris") || npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "NewPolaris"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Polaris], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "Lux"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Lux], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "SubspaceSerpentHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SubspaceSerpent], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "NatureConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NatureConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "EarthenConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "PermafrostConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "TidalConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TidalConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "OtherworldlyConstructHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlyConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "OtherworldlyConstructHead2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OtherworldlyConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "EvilConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EvilConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "InfernoConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "ChaosConstruct"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ChaosConstruct], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "NatureSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.NatureSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "EarthenSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EarthenSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "PermafrostSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PermafrostSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "TidalSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TidalSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "EvilSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EvilSpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SecretsOfTheShadows.Mod, "InfernoSpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InfernoSpirit], -1);
            }
            #endregion

            #region Shadows of Abaddon
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Decree"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Decree], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Ralnek") && Condition.InClassicMode.IsMet())
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FlamingPumpkin], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "RalnekPhase3") && ModConditions.expertOrMaster.IsMet())
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FlamingPumpkin], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "ZombiePigmanBrute"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ZombiePiglinBrute], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Jensen"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.JensenTheGrandHarpy], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Araneas"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Araneas], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Raynare"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HarpyQueenRaynare], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Primordia2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Primordia], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Abaddon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Abaddon], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "AraghurHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Araghur], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Novaniel"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.LostSiblings], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "ErazorBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Erazor], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.ShadowsOfAbaddon.Mod, "Nihilus2"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Nihilus], -1);
            }
            #endregion

            #region Sloome
            if (npc.type == Common.GetModNPC(CrossModSupport.Sloome.Mod, "ExoSlimeGod"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Exodygen], -1);
            }
            #endregion

            #region Spirit
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Scarabeus"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Scarabeus], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "MoonWizard"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MoonJellyWizard], -1);
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.JellyDeluge], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "ReachBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.VinewrathBane], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "AncientFlyer"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientAvian], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "SteamRaiderHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StarplateVoyager], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Infernon"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Infernon], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Dusking"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dusking], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Atlas"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Atlas], -1);
            }
            //EVENTS
            List<int> jellyDelugeNPCs = new()
                {
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "MoonlightPreserver"),
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "ExplodingMoonjelly"),
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "MoonjellyGiant")
                };
            if (jellyDelugeNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.JellyDeluge], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Rylheian"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.TheTide], -1);
            }
            List<int> mysticMoonNPCs = new()
                {
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Bloomshroom"),
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Glitterfly"),
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "GlowToad"),
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "Lumantis"),
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "LunarSlime"),
                    Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "MadHatter")
                };
            if (mysticMoonNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.MysticMoon], -1);
            }
            #endregion

            #region Spooky
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "RotGourd"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.RotGourd], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "SpookySpirit"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SpookySpirit], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "Moco"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Moco], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "DaffodilEye"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Daffodil], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "OrroHead") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.Spooky.Mod, "BoroHead")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OrroBoro], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "BoroHead") && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.Spooky.Mod, "OrroHead")))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OrroBoro], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "BigBone"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.BigBone], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "SpookFishron"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SpookFishron], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Spooky.Mod, "Chester"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.PandorasBox], -1);
            }
            List<int> eggIncursionNPCs = new()
            {
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "Biojetter"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "BiojetterEye"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "CoughLungs"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "CruxBat"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "EarWorm"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "ExplodingAppendix"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "FleshBolster"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "GooSlug"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "HoppingHeart"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "HoverBrain"),
                Common.GetModNPC(CrossModSupport.Spooky.Mod, "TongueBiter")
            };
            if (eggIncursionNPCs.Contains(npc.type))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedEvents[(int)ModConditions.DownedEvent.EggIncursion], -1);
            }
            #endregion

            #region Starlight River
            if (npc.type == Common.GetModNPC(CrossModSupport.StarlightRiver.Mod, "SquidBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Auroracle], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.StarlightRiver.Mod, "VitricBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Ceiros], -1);
            }
            #endregion

            #region Storm's Additions
            if (npc.type == Common.GetModNPC(CrossModSupport.StormsAdditions.Mod, "AridBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AncientHusk], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.StormsAdditions.Mod, "StormBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.OverloadedScandrone], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.StormsAdditions.Mod, "TheUltimateBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Painbringer], -1);
            }
            #endregion

            #region Supernova
            if (npc.type == Common.GetModNPC(CrossModSupport.Supernova.Mod, "HarbingerOfAnnihilation"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HarbingerOfAnnihilation], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Supernova.Mod, "FlyingTerror"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.FlyingTerror], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Supernova.Mod, "StoneMantaRay"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StoneMantaRay], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Supernova.Mod, "Bloodweaver"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Bloodweaver], -1);
            }
            #endregion

            #region Terrorborn
            if (npc.type == Common.GetModNPC(CrossModSupport.Terrorborn.Mod, "InfectedIncarnate"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.InfectedIncarnate], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Terrorborn.Mod, "TidalTitan"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.TidalTitan], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Terrorborn.Mod, "Dunestock"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dunestock], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Terrorborn.Mod, "Shadowcrawler"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Shadowcrawler], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Terrorborn.Mod, "HexedConstructor"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.HexedConstructor], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Terrorborn.Mod, "PrototypeI"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PrototypeI], -1);
            }
            #endregion

            #region TRAE
            if (npc.type == Common.GetModNPC(CrossModSupport.TRAEProject.Mod, "GraniteOvergrowthNPC"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GraniteOvergrowth], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.TRAEProject.Mod, "BeholderNPC"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Beholder], -1);
            }
            #endregion

            #region Uhtric
            if (npc.type == Common.GetModNPC(CrossModSupport.Uhtric.Mod, "Dredger"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dredger], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Uhtric.Mod, "CharcoolSnowman"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CharcoolSnowman], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Uhtric.Mod, "CosmicMenace"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.CosmicMenace], -1);
            }
            #endregion

            #region Universe of Swords
            if (npc.type == Common.GetModNPC(CrossModSupport.UniverseOfSwords.Mod, "SwordBossNPC"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EvilFlyingBlade], -1);
            }
            #endregion

            #region Valhalla
            if (npc.type == Common.GetModNPC(CrossModSupport.Valhalla.Mod, "Emperor"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Yurnero], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Valhalla.Mod, "PirateSquid"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.ColossalCarnage], -1);
            }
            #endregion

            #region Vitality
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "StormCloudBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.StormCloud], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "GrandAntlionBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GrandAntlion], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "GemstoneElementalBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.GemstoneElemental], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "MoonlightDragonflyBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MoonlightDragonfly], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "DreadnaughtBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dreadnaught], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "MosquitoMonarchBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.MosquitoMonarch], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "AnarchulesBeetleBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.AnarchulesBeetle], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "ChaosbringerBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Chaosbringer], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Vitality.Mod, "PaladinSpiritBoss"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.PaladinSpirit], -1);
            }
            #endregion

            #region Wayfair Content
            if (npc.type == Common.GetModNPC(CrossModSupport.WAYFAIRContentPack.Mod, "Lifebloom"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Manaflora], -1);
            }
            #endregion

            #region Zylon
            if (npc.type == Common.GetModNPC(CrossModSupport.Zylon.Mod, "Dirtball"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Dirtball], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Zylon.Mod, "MetelordHead"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Metelord], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Zylon.Mod, "Adeneb"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.Adeneb], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Zylon.Mod, "EldritchJellyfish"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.EldritchJellyfish], -1);
            }
            if (npc.type == Common.GetModNPC(CrossModSupport.Zylon.Mod, "SaburRex"))
            {
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.SaburRex], -1);
            }
            #endregion
        }
    }

}
