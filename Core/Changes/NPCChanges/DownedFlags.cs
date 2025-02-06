namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class DownedFlags : GlobalNPC
    {
        //FOR NPCs THAT DON'T TECHNICALLY "DIE"
        public override bool PreAI(NPC npc)
        {
            if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "Glassweaver") && npc.life <= 1)
            {
                NPC.SetEventFlagCleared(ref ModConditions.downedGlassweaver, -1);
            }
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

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "UndeadChef"))
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UndeadChef], -1);

            if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "IceGuardian"))
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

            if (ModConditions.gensokyoLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "LilyWhite"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLilyWhite, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Rumia"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedRumia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "EternityLarva"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEternityLarva, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Nazrin"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNazrin, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "HinaKagiyama"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHinaKagiyama, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Sekibanki"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSekibanki, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Seiran"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeiran, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "NitoriKawashiro"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNitoriKawashiro, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MedicineMelancholy"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMedicineMelancholy, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Cirno"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCirno, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MinamitsuMurasa"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMinamitsuMurasa, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "AliceMargatroid"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAliceMargatroid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "SakuyaIzayoi"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSakuyaIzayoi, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "SeijaKijin"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeijaKijin, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MayumiJoutouguu"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMayumiJoutouguu, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "ToyosatomimiNoMiko"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedToyosatomimiNoMiko, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "KaguyaHouraisan"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKaguyaHouraisan, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "UtsuhoReiuji"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedUtsuhoReiuji, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "TenshiHinanawi"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTenshiHinanawi, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Kisume"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKisume, -1);
                }
            }

            if (ModConditions.gerdsLabLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Trerios"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTrerios, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "MagmaEye"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMagmaEye, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Jack"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJack, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Acheron"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAcheron, -1);
                }
            }

            if (ModConditions.homewardJourneyLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "MarquisMoonsquid"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMarquisMoonsquid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "PriestessRod"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPriestessRod, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Diver"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDiver, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMotherbrain"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMotherbrain, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WallofShadow"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWallOfShadow, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "SlimeGod"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunSlimeGod, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheOverwatcher"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOverwatcher, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheLifebringerHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLifebringer, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMaterealizer"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMaterealizer, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedScarabBelief, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WorldsEndEverlastingFallingWhale"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWorldsEndWhale, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheSon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Cave"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCaveOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Corruption"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCorruptOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Crimson"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCrimsonOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Desert"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDesertOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Forest"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedForestOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Hallow"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHallowOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Jungle"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJungleOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Pure"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSkyOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Snow"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSnowOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Underworld"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedUnderworldOrdeal, -1);
                }
            }

            if (ModConditions.huntOfTheOldGodLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.huntOfTheOldGodMod, "Goozma"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGoozma, -1);
                }
            }

            if (ModConditions.infernumLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.infernumMod, "BereftVassal"))
                {
                    SubworldModConditions.downedBereftVassal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBereftVassal, -1);
                }
            }

            if (ModConditions.lunarVeilLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "StarrVeriplant"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoneGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "CommanderGintzia"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCommanderGintzia, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedGintzeArmy, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "SunStalker"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunStalker, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Jack"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPumpkinJack, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "DaedusR"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedForgottenPuppetDaedus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "DreadMire"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDreadMire, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "SingularityFragment"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSingularityFragment, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "VerliaB"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVerlia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Gothiviab"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedIrradia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Sylia"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSylia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Fenix"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFenix, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "BlazingSerpentHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBlazingSerpent, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Cogwork"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCogwork, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "WaterCogwork"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWaterCogwork, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "WaterJellyfish"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWaterJellyfish, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Sparn"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSparn, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "PandorasFlamebox"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPandorasFlamebox, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "STARBOMBER"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSTARBOMBER, -1);
                }
            }

            if (ModConditions.martainsOrderLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Britzz"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBritzz, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Alchemist"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTheAlchemist, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "CarnagePillar"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCarnagePillar, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "VoidDiggerHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVoidDigger, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "PrinceSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrinceSlime, -1);
                }
                ModConditions.martainsOrderMod.TryFind("Evocornator", out ModNPC Evocornator);
                ModConditions.martainsOrderMod.TryFind("Retinator", out ModNPC Retinator);
                ModConditions.martainsOrderMod.TryFind("Spazmator", out ModNPC Spazmator);
                if (npc.type == Evocornator.Type && !NPC.AnyNPCs(Retinator.Type) && !NPC.AnyNPCs(Spazmator.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Retinator.Type && !NPC.AnyNPCs(Evocornator.Type) && !NPC.AnyNPCs(Spazmator.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Spazmator.Type && !NPC.AnyNPCs(Evocornator.Type) && !NPC.AnyNPCs(Retinator.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "MechPlantera"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJungleDefenders, -1);
                }
            }

            if (ModConditions.mechReworkLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "Mechclops"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSt4sys, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "TheTerminator"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTerminator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "Caretaker"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCaretaker, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "SiegeEngine"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSiegeEngine, -1);
                }
            }

            if (ModConditions.medialRiftLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.medialRiftMod, "SuperVoltaicMotherSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSuperVoltaicMotherSlime, -1);
                }
            }

            if (ModConditions.metroidLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Torizo"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTorizo, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Serris_Head"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSerris, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Kraid_Head"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKraid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Phantoon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPhantoon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "OmegaPirate"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaPirate, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Nightmare"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNightmare, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "GoldenTorizo"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGoldenTorizo, -1);
                }
            }

            if (ModConditions.ophioidLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "OphiopedeHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOphiopede, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "Ophiocoon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOphiocoon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "Ophiofly"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOphiofly, -1);
                }
            }

            if (ModConditions.polaritiesLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "StormCloudfish"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStormCloudfish, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "StarConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStarConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Gigabat"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGigabat, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "SunPixie"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunPixie, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Esophage"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEsophage, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "ConvectiveWanderer"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedConvectiveWanderer, -1);
                }
            }

            if (ModConditions.projectZeroLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "ForestGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedForestGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "CryoGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCryoGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "PrimordialWormHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrimordialWorm, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "HellGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTheGuardianOfHell, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "Void"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVoid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "ArmagemHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedArmagem, -1);
                }
            }

            if (ModConditions.qwertyLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "PolarBear"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPolarExterminator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "FortressBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDivineLight, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "AncientMachine"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientMachine, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "CloakedDarkBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNoehtnap, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Hydra"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHydra, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Imperious"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedImperious, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "RuneGhost"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedRuneGhost, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "InvaderBattleship"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaderBattleship, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "InvaderNoehtnap"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaderNoehtnap, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaders, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "OLORDv2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOLORD, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "TheGreatTyrannosaurus"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGreatTyrannosaurus, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedDinoMilitia, -1);
                }
            }

            if (ModConditions.redemptionLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Thorn"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedThorn, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Erhan"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedErhan, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Keeper"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKeeper, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "SoI"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeedOfInfection, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "KS3"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKingSlayerIII, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OmegaCleaver"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaCleaver, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Gigapora"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaGigapora, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OO"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaObliterator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "PZ"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPatientZero, -1);
                }
                ModConditions.redemptionMod.TryFind("Akka", out ModNPC Akka);
                ModConditions.redemptionMod.TryFind("Ukko", out ModNPC Ukko);
                if (npc.type == Akka.Type && !NPC.AnyNPCs(Ukko.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAkka, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientDeityDuo, -1);
                }
                if (npc.type == Ukko.Type && !NPC.AnyNPCs(Akka.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedUkko, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientDeityDuo, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNebuleus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNebuleus, -1);
                }
                //MINIBOSSES
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "FowlEmperor"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFowlEmperor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Cockatrice"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCockatrice, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Basan"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBasan, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedFowlMorning, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "SkullDigger"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSkullDigger, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "EaglecrestGolem"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEaglecrestGolem, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Calavia"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCalavia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "JanitorBot"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTheJanitor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "IrradiatedBehemoth"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedIrradiatedBehemoth, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Blisterface"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBlisterface, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "ProtectorVolt"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedProtectorVolt, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "MACEProject"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMACEProject, -1);
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
                    NPC.SetEventFlagCleared(ref ModConditions.downedRaveyard, -1);
                }
            }

            if (ModConditions.secretsOfTheShadowsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Glowmoth"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGlowmoth, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PutridPinkyPhase2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPutridPinky, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PharaohsCurse"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPharaohsCurse, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TheAdvisorHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAdvisor, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlySpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Polaris") || npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NewPolaris"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPolaris, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Lux"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLux, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "SubspaceSerpentHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSubspaceSerpent, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NatureConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNatureConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EarthenConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEarthenConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PermafrostConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPermafrostConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TidalConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "OtherworldlyConstructHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlyConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "OtherworldlyConstructHead2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlyConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EvilConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "InfernoConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernoConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "ChaosConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NatureSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNatureSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EarthenSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEarthenSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PermafrostSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPermafrostSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TidalSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EvilSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "InfernoSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernoSpirit, -1);
                }
            }

            if (ModConditions.shadowsOfAbaddonLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Decree"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDecree, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Ralnek") && Condition.InClassicMode.IsMet())
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFlamingPumpkin, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "RalnekPhase3") && ModConditions.expertOrMaster.IsMet())
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFlamingPumpkin, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "ZombiePigmanBrute"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedZombiePiglinBrute, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Jensen"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJensenTheGrandHarpy, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Araneas"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAraneas, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Raynare"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHarpyQueenRaynare, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Primordia2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrimordia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Abaddon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAbaddon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "AraghurHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAraghur, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Novaniel"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLostSiblings, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "ErazorBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedErazor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.shadowsOfAbaddonMod, "Nihilus2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNihilus, -1);
                }
            }

            if (ModConditions.sloomeLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.sloomeMod, "ExoSlimeGod"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedExodygen, -1);
                }
            }

            if (ModConditions.spiritLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Scarabeus"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedScarabeus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "MoonWizard"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoonJellyWizard, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedJellyDeluge, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "ReachBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVinewrathBane, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "AncientFlyer"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientAvian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "SteamRaiderHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStarplateVoyager, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Infernon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Dusking"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDusking, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Atlas"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAtlas, -1);
                }
                //EVENTS
                List<int> jellyDelugeNPCs = new()
                {
                    Common.GetModNPC(ModConditions.spiritMod, "MoonlightPreserver"),
                    Common.GetModNPC(ModConditions.spiritMod, "ExplodingMoonjelly"),
                    Common.GetModNPC(ModConditions.spiritMod, "MoonjellyGiant")
                };
                if (jellyDelugeNPCs.Contains(npc.type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJellyDeluge, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Rylheian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTide, -1);
                }
                List<int> mysticMoonNPCs = new()
                {
                    Common.GetModNPC(ModConditions.spiritMod, "Bloomshroom"),
                    Common.GetModNPC(ModConditions.spiritMod, "Glitterfly"),
                    Common.GetModNPC(ModConditions.spiritMod, "GlowToad"),
                    Common.GetModNPC(ModConditions.spiritMod, "Lumantis"),
                    Common.GetModNPC(ModConditions.spiritMod, "LunarSlime"),
                    Common.GetModNPC(ModConditions.spiritMod, "MadHatter")
                };
                if (mysticMoonNPCs.Contains(npc.type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMysticMoon, -1);
                }
            }

            if (ModConditions.spookyLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "RotGourd"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedRotGourd, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "SpookySpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSpookySpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "Moco"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoco, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "DaffodilEye"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDaffodil, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "OrroHead") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.spookyMod, "BoroHead")))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOrro, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedOrroBoro, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "BoroHead") && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.spookyMod, "OrroHead")))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBoro, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedOrroBoro, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "BigBone"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBigBone, -1);
                }
            }

            if (ModConditions.starlightRiverLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "SquidBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAuroracle, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "VitricBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCeiros, -1);
                }
            }

            if (ModConditions.stormsAdditionsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "AridBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientHusk, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "StormBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOverloadedScandrone, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "TheUltimateBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPainbringer, -1);
                }
            }

            if (ModConditions.supernovaLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "HarbingerOfAnnihilation"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHarbingerOfAnnihilation, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "FlyingTerror"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFlyingTerror, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "StoneMantaRay"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoneMantaRay, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "Bloodweaver"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBloodweaver, -1);
                }
            }

            if (ModConditions.terrorbornLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "InfectedIncarnate"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfectedIncarnate, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "TidalTitan"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalTitan, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "Dunestock"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDunestock, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "Shadowcrawler"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedShadowcrawler, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "HexedConstructor"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHexedConstructor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "PrototypeI"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrototypeI, -1);
                }
            }

            if (ModConditions.traeLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.traeMod, "GraniteOvergrowthNPC"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGraniteOvergrowth, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.traeMod, "BeholderNPC"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBeholder, -1);
                }
            }

            if (ModConditions.uhtricLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "Dredger"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDredger, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CharcoolSnowman"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCharcoolSnowman, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CosmicMenace"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCosmicMenace, -1);
                }
            }

            if (ModConditions.universeOfSwordsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.universeOfSwordsMod, "SwordBossNPC"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilFlyingBlade, -1);
                }
            }

            if (ModConditions.valhallaLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.valhallaMod, "Emperor"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedYurnero, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.valhallaMod, "PirateSquid"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedColossalCarnage, -1);
                }
            }

            if (ModConditions.vitalityLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "StormCloudBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStormCloud, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GrandAntlionBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGrandAntlion, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GemstoneElementalBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGemstoneElemental, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MoonlightDragonflyBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoonlightDragonfly, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "DreadnaughtBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDreadnaught, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MosquitoMonarchBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMosquitoMonarch, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "AnarchulesBeetleBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAnarchulesBeetle, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "ChaosbringerBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosbringer, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "PaladinSpiritBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPaladinSpirit, -1);
                }
            }

            if (ModConditions.wayfairContentLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.wayfairContentMod, "Lifebloom"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedManaflora, -1);
                }
            }

            if (ModConditions.zylonLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "Dirtball"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDirtball, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "MetelordHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMetelord, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "Adeneb"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAdeneb, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "EldritchJellyfish"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEldritchJellyfish, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.zylonMod, "SaburRex"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSaburRex, -1);
                }
            }
        }
    }

}
