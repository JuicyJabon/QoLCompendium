using System.Reflection;
using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class PillarsDropMore : GlobalNPC
    {
        private static readonly int[] LunarPillars = { NPCID.LunarTowerSolar, NPCID.LunarTowerVortex, NPCID.LunarTowerNebula, NPCID.LunarTowerStardust };

        private static void MakeLunarPillarDropRulesBetter(DropOneByOne drop)
        {
            PropertyInfo parametersProperty = typeof(DropOneByOne).GetProperty("parameters", BindingFlags.Public | BindingFlags.Instance);
            DropOneByOne.Parameters newParameters = new()
            {
                MinimumItemDropsCount = 90,
                MaximumItemDropsCount = 110,
                ChanceNumerator = 1,
                ChanceDenominator = 1,
                MinimumStackPerChunkBase = 1,
                MaximumStackPerChunkBase = 1,
                BonusMinDropsPerChunkPerPlayer = 1,
                BonusMaxDropsPerChunkPerPlayer = 1
            };
            parametersProperty.SetValue(drop, newParameters);
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (LunarPillars.Contains(npc.type) && QoLCompendium.mainConfig.LunarPillarsDropMoreFragments)
            {
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode expertRule)
                    {
                        if (expertRule.ruleForNormalMode is DropOneByOne normalDrop)
                        {
                            MakeLunarPillarDropRulesBetter(normalDrop);
                        }

                        if (expertRule.ruleForExpertMode is DropOneByOne expertDrop)
                        {
                            MakeLunarPillarDropRulesBetter(expertDrop);
                        }
                    }
                }
            }
        }
    }

    public class NPCDrops : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            npc.value *= QoLCompendium.mainConfig.EnemiesDropMoreCoins;
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.DD2DarkMageT1 && QoLCompendium.mainConfig.ExtraDefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 10, 10));
            }

            if (npc.type == NPCID.DD2DarkMageT3 && QoLCompendium.mainConfig.ExtraDefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 25, 25));
            }

            if (npc.type == NPCID.DD2OgreT2 && QoLCompendium.mainConfig.ExtraDefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 25, 25));
            }

            if (npc.type == NPCID.DD2OgreT3 && QoLCompendium.mainConfig.ExtraDefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 30, 30));
            }

            if (npc.type == NPCID.DD2Betsy && QoLCompendium.mainConfig.ExtraDefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 50, 50));
            }

            if ((npc.type == NPCID.NebulaHeadcrab || npc.type == NPCID.NebulaBeast || npc.type == NPCID.NebulaBrain || npc.type == NPCID.NebulaSoldier) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentNebula, 1, 1, 3));
            }

            if ((npc.type == NPCID.SolarCorite || npc.type == NPCID.SolarCrawltipedeHead || npc.type == NPCID.SolarSpearman || npc.type == NPCID.SolarDrakomire || npc.type == NPCID.SolarDrakomireRider || npc.type == NPCID.SolarSolenian || npc.type == NPCID.SolarSroller) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentSolar, 1, 1, 3));
            }

            if ((npc.type == NPCID.StardustJellyfishBig || npc.type == NPCID.StardustWormHead || npc.type == NPCID.StardustCellBig || npc.type == NPCID.StardustSoldier || npc.type == NPCID.StardustSpiderBig) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentStardust, 1, 1, 3));
            }

            if ((npc.type == NPCID.VortexHornet || npc.type == NPCID.VortexHornetQueen || npc.type == NPCID.VortexRifleman || npc.type == NPCID.VortexSoldier) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentVortex, 1, 1, 3));
            }


            int allowedRecursionDepth = 10;
            foreach (IItemDropRule item in npcLoot.Get(true))
            {
                CheckMasterDropRule(item);
            }
            void AddDrop(IItemDropRule dropRule)
            {
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    LeadingConditionRule noTwin = new LeadingConditionRule(new Conditions.MissingTwin());
                    Chains.OnSuccess((IItemDropRule)(object)noTwin, dropRule, false);
                    npcLoot.Add((IItemDropRule)(object)noTwin);
                }
                else if (npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsTail)
                {
                    LeadingConditionRule lastEater = new LeadingConditionRule(new Conditions.LegacyHack_IsABoss());
                    Chains.OnSuccess((IItemDropRule)(object)lastEater, dropRule, false);
                    npcLoot.Add((IItemDropRule)(object)lastEater);
                }
                else
                {
                    npcLoot.Add(dropRule);
                }
            }
            void CheckMasterDropRule(IItemDropRule dropRule)
            {
                if (--allowedRecursionDepth > 0)
                {
                    if (dropRule != null && dropRule.ChainedRules != null)
                    {
                        foreach (IItemDropRuleChainAttempt chain in dropRule.ChainedRules)
                        {
                            if (chain != null && chain.RuleToChain != null)
                            {
                                CheckMasterDropRule(chain.RuleToChain);
                            }
                        }
                    }
                    DropBasedOnMasterMode dropBasedOnMasterMode = (DropBasedOnMasterMode)(object)((dropRule is DropBasedOnMasterMode) ? dropRule : null);
                    if (dropBasedOnMasterMode != null && dropBasedOnMasterMode != null && dropBasedOnMasterMode.ruleForMasterMode != null)
                    {
                        CheckMasterDropRule(dropBasedOnMasterMode.ruleForMasterMode);
                    }
                }
                allowedRecursionDepth++;
                ItemDropWithConditionRule itemDropWithCondition = (ItemDropWithConditionRule)(object)((dropRule is ItemDropWithConditionRule) ? dropRule : null);
                if (itemDropWithCondition != null && itemDropWithCondition.condition is Conditions.IsMasterMode)
                {
                    AddDrop(ItemDropRule.ByCondition((IItemDropRuleCondition)(object)new ExpertOnlyDropCondition(), itemDropWithCondition.itemId, itemDropWithCondition.chanceDenominator, itemDropWithCondition.amountDroppedMinimum, itemDropWithCondition.amountDroppedMaximum, itemDropWithCondition.chanceNumerator));
                }
                else
                {
                    DropPerPlayerOnThePlayer dropPerPlayer = (DropPerPlayerOnThePlayer)(object)((dropRule is DropPerPlayerOnThePlayer) ? dropRule : null);
                    if (dropPerPlayer != null && dropPerPlayer.condition is Conditions.IsMasterMode)
                    {
                        AddDrop(ItemDropRule.ByCondition((IItemDropRuleCondition)(object)new ExpertOnlyDropCondition(), dropPerPlayer.itemId, dropPerPlayer.chanceDenominator, dropPerPlayer.amountDroppedMinimum, dropPerPlayer.amountDroppedMaximum, dropPerPlayer.chanceNumerator));
                    }
                }
            }

            /*
            #region Relic Drops
            //VANILLA
            if (ModConditions.calamityLoaded && ModConditions.fargosSoulsLoaded)
            {
                if (npc.type == NPCID.KingSlime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.KingSlimeMasterTrophy));
                if (npc.type == NPCID.EyeofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.EyeofCthulhuMasterTrophy));
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.EaterofWorldsMasterTrophy));
                if (npc.type == NPCID.BrainofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.BrainofCthulhuMasterTrophy));
                if (npc.type == NPCID.QueenBee)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.QueenBeeMasterTrophy));
                if (npc.type == NPCID.Deerclops)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.DeerclopsMasterTrophy));
                if (npc.type == NPCID.SkeletronHead)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.SkeletronMasterTrophy));
                if (npc.type == NPCID.WallofFlesh)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.WallofFleshMasterTrophy));
                if (npc.type == NPCID.QueenSlimeBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.QueenSlimeMasterTrophy));
                if (npc.type == NPCID.Retinazer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.Spazmatism)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.TheDestroyer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.DestroyerMasterTrophy));
                if (npc.type == NPCID.SkeletronPrime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.SkeletronPrimeMasterTrophy));
                if (npc.type == NPCID.Plantera)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.PlanteraMasterTrophy));
                if (npc.type == NPCID.Golem)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.GolemMasterTrophy));
                if (npc.type == NPCID.HallowBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.FairyQueenMasterTrophy));
                if (npc.type == NPCID.DukeFishron)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.DukeFishronMasterTrophy));
                if (npc.type == NPCID.CultistBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.LunaticCultistMasterTrophy));
                if (npc.type == NPCID.MoonLordCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.MoonLordMasterTrophy));
                //MINIBOSSES
                if (npc.type == NPCID.DD2DarkMageT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.DarkMageMasterTrophy));
                if (npc.type == NPCID.DD2OgreT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.OgreMasterTrophy));
                if (npc.type == NPCID.DD2Betsy)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.BetsyMasterTrophy));
                if (npc.type == NPCID.MourningWood)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.MourningWoodMasterTrophy));
                if (npc.type == NPCID.Pumpking)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.PumpkingMasterTrophy));
                if (npc.type == NPCID.Everscream)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.EverscreamMasterTrophy));
                if (npc.type == NPCID.SantaNK1)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.SantankMasterTrophy));
                if (npc.type == NPCID.IceQueen)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.IceQueenMasterTrophy));
                if (npc.type == NPCID.PirateShip)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.FlyingDutchmanMasterTrophy));
                if (npc.type == NPCID.MartianSaucerCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsAndCalamityDropCondition(), ItemID.UFOMasterTrophy));
            }
            else if (ModConditions.calamityLoaded)
            {
                if (npc.type == NPCID.KingSlime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.KingSlimeMasterTrophy));
                if (npc.type == NPCID.EyeofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.EyeofCthulhuMasterTrophy));
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.EaterofWorldsMasterTrophy));
                if (npc.type == NPCID.BrainofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.BrainofCthulhuMasterTrophy));
                if (npc.type == NPCID.QueenBee)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.QueenBeeMasterTrophy));
                if (npc.type == NPCID.Deerclops)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.DeerclopsMasterTrophy));
                if (npc.type == NPCID.SkeletronHead)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.SkeletronMasterTrophy));
                if (npc.type == NPCID.WallofFlesh)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.WallofFleshMasterTrophy));
                if (npc.type == NPCID.QueenSlimeBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.QueenSlimeMasterTrophy));
                if (npc.type == NPCID.Retinazer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.Spazmatism)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.TheDestroyer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.DestroyerMasterTrophy));
                if (npc.type == NPCID.SkeletronPrime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.SkeletronPrimeMasterTrophy));
                if (npc.type == NPCID.Plantera)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.PlanteraMasterTrophy));
                if (npc.type == NPCID.Golem)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.GolemMasterTrophy));
                if (npc.type == NPCID.HallowBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.FairyQueenMasterTrophy));
                if (npc.type == NPCID.DukeFishron)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.DukeFishronMasterTrophy));
                if (npc.type == NPCID.CultistBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.LunaticCultistMasterTrophy));
                if (npc.type == NPCID.MoonLordCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.MoonLordMasterTrophy));
                //MINIBOSSES
                if (npc.type == NPCID.DD2DarkMageT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.DarkMageMasterTrophy));
                if (npc.type == NPCID.DD2OgreT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.OgreMasterTrophy));
                if (npc.type == NPCID.DD2Betsy)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.BetsyMasterTrophy));
                if (npc.type == NPCID.MourningWood)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.MourningWoodMasterTrophy));
                if (npc.type == NPCID.Pumpking)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.PumpkingMasterTrophy));
                if (npc.type == NPCID.Everscream)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.EverscreamMasterTrophy));
                if (npc.type == NPCID.SantaNK1)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.SantankMasterTrophy));
                if (npc.type == NPCID.IceQueen)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.IceQueenMasterTrophy));
                if (npc.type == NPCID.PirateShip)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.FlyingDutchmanMasterTrophy));
                if (npc.type == NPCID.MartianSaucerCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), ItemID.UFOMasterTrophy));
            }
            else if (ModConditions.fargosSoulsLoaded)
            {
                if (npc.type == NPCID.KingSlime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.KingSlimeMasterTrophy));
                if (npc.type == NPCID.EyeofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.EyeofCthulhuMasterTrophy));
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.EaterofWorldsMasterTrophy));
                if (npc.type == NPCID.BrainofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.BrainofCthulhuMasterTrophy));
                if (npc.type == NPCID.QueenBee)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.QueenBeeMasterTrophy));
                if (npc.type == NPCID.Deerclops)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.DeerclopsMasterTrophy));
                if (npc.type == NPCID.SkeletronHead)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.SkeletronMasterTrophy));
                if (npc.type == NPCID.WallofFlesh)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.WallofFleshMasterTrophy));
                if (npc.type == NPCID.QueenSlimeBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.QueenSlimeMasterTrophy));
                if (npc.type == NPCID.Retinazer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.Spazmatism)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.TheDestroyer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.DestroyerMasterTrophy));
                if (npc.type == NPCID.SkeletronPrime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.SkeletronPrimeMasterTrophy));
                if (npc.type == NPCID.Plantera)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.PlanteraMasterTrophy));
                if (npc.type == NPCID.Golem)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.GolemMasterTrophy));
                if (npc.type == NPCID.HallowBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.FairyQueenMasterTrophy));
                if (npc.type == NPCID.DukeFishron)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.DukeFishronMasterTrophy));
                if (npc.type == NPCID.CultistBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.LunaticCultistMasterTrophy));
                if (npc.type == NPCID.MoonLordCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.MoonLordMasterTrophy));
                //MINIBOSSES
                if (npc.type == NPCID.DD2DarkMageT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.DarkMageMasterTrophy));
                if (npc.type == NPCID.DD2OgreT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.OgreMasterTrophy));
                if (npc.type == NPCID.DD2Betsy)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.BetsyMasterTrophy));
                if (npc.type == NPCID.MourningWood)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.MourningWoodMasterTrophy));
                if (npc.type == NPCID.Pumpking)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.PumpkingMasterTrophy));
                if (npc.type == NPCID.Everscream)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.EverscreamMasterTrophy));
                if (npc.type == NPCID.SantaNK1)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.SantankMasterTrophy));
                if (npc.type == NPCID.IceQueen)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.IceQueenMasterTrophy));
                if (npc.type == NPCID.PirateShip)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.FlyingDutchmanMasterTrophy));
                if (npc.type == NPCID.MartianSaucerCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), ItemID.UFOMasterTrophy));
            }
            else
            {
                if (npc.type == NPCID.KingSlime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.KingSlimeMasterTrophy));
                if (npc.type == NPCID.EyeofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.EyeofCthulhuMasterTrophy));
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.EaterofWorldsMasterTrophy));
                if (npc.type == NPCID.BrainofCthulhu)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.BrainofCthulhuMasterTrophy));
                if (npc.type == NPCID.QueenBee)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.QueenBeeMasterTrophy));
                if (npc.type == NPCID.Deerclops)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.DeerclopsMasterTrophy));
                if (npc.type == NPCID.SkeletronHead)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.SkeletronMasterTrophy));
                if (npc.type == NPCID.WallofFlesh)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.WallofFleshMasterTrophy));
                if (npc.type == NPCID.QueenSlimeBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.QueenSlimeMasterTrophy));
                if (npc.type == NPCID.Retinazer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.Spazmatism)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.TwinsMasterTrophy));
                if (npc.type == NPCID.TheDestroyer)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.DestroyerMasterTrophy));
                if (npc.type == NPCID.SkeletronPrime)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.SkeletronPrimeMasterTrophy));
                if (npc.type == NPCID.Plantera)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.PlanteraMasterTrophy));
                if (npc.type == NPCID.Golem)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.GolemMasterTrophy));
                if (npc.type == NPCID.HallowBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.FairyQueenMasterTrophy));
                if (npc.type == NPCID.DukeFishron)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.DukeFishronMasterTrophy));
                if (npc.type == NPCID.CultistBoss)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.LunaticCultistMasterTrophy));
                if (npc.type == NPCID.MoonLordCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.MoonLordMasterTrophy));
                //MINIBOSSES
                if (npc.type == NPCID.DD2DarkMageT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.DarkMageMasterTrophy));
                if (npc.type == NPCID.DD2OgreT3)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.OgreMasterTrophy));
                if (npc.type == NPCID.DD2Betsy)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.BetsyMasterTrophy));
                if (npc.type == NPCID.MourningWood)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.MourningWoodMasterTrophy));
                if (npc.type == NPCID.Pumpking)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.PumpkingMasterTrophy));
                if (npc.type == NPCID.Everscream)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.EverscreamMasterTrophy));
                if (npc.type == NPCID.SantaNK1)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.SantankMasterTrophy));
                if (npc.type == NPCID.IceQueen)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.IceQueenMasterTrophy));
                if (npc.type == NPCID.PirateShip)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.FlyingDutchmanMasterTrophy));
                if (npc.type == NPCID.MartianSaucerCore)
                    npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), ItemID.UFOMasterTrophy));
            }

            //AEQUUS
            if (npc.type == Common.GetModNPC(ModConditions.aequusMod, "Crabson") || npc.type == Common.GetModNPC(ModConditions.aequusMod, "CrabsonOld") || npc.type == Common.GetModNPC(ModConditions.aequusMod, "CrabsonClaw"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.aequusMod, "CrabsonRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.aequusMod, "OmegaStarite"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.aequusMod, "OmegaStariteRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.aequusMod, "DustDevil"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.aequusMod, "DustDevilRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.aequusMod, "UltraStarite"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.aequusMod, "UltraStariteRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.aequusMod, "RedSprite"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.aequusMod, "RedSpriteRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.aequusMod, "SpaceSquid"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.aequusMod, "SpaceSquidRelic")));


            //CALAMITY
            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "DesertScourgeHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "DesertScourgeRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Crabulon"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "CrabulonRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "HiveMind"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "HiveMindRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "PerforatorHive"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "PerforatorsRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "SlimeGodCore"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "SlimeGodRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Cryogen"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "CryogenRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "AquaticScourgeHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "AquaticScourgeRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "BrimstoneElemental"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "BrimstoneElementalRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "CalamitasClone"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "CalamitasCloneRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Leviathan") || npc.type == Common.GetModNPC(ModConditions.calamityMod, "Anahita"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "LeviathanAnahitaRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "AstrumAureus"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "AstrumAureusRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "PlaguebringerGoliath"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "PlaguebringerGoliathRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "RavagerBody"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "RavagerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "AstrumDeusHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "AstrumDeusRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "ProfanedGuardianCommander") || npc.type == Common.GetModNPC(ModConditions.calamityMod, "ProfanedGuardianDefender") || npc.type == Common.GetModNPC(ModConditions.calamityMod, "ProfanedGuardianHealer"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "ProfanedGuardiansRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Bumblefuck"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "DragonfollyRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Providence"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "ProvidenceRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "StormWeaverHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "StormWeaverRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "CeaselessVoid"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "CeaselessVoidRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Signus"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "SignusRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Polterghast"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "PolterghastRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "OldDuke"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "OldDukeRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "DevourerofGodsHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "DevourerOfGodsRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Yharon"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "YharonRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Apollo") || npc.type == Common.GetModNPC(ModConditions.calamityMod, "Artemis") || npc.type == Common.GetModNPC(ModConditions.calamityMod, "AresBody") || npc.type == Common.GetModNPC(ModConditions.calamityMod, "ThanatosHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "DraedonRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "SupremeCalamitas"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "CalamitasRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "CragmawMire"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "CragmawMireRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Mauler"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "MaulerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "NuclearTerror"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "NuclearTerrorRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "GiantClam"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "GiantClamRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "GreatSandShark"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyCalamityDropCondition(), Common.GetModItem(ModConditions.calamityMod, "GreatSandSharkRelic")));


            //CONSOLARIA
            if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "Lepus"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.consolariaMod, "LepusRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "TurkortheUngrateful"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.consolariaMod, "TurkorRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "Ocram"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.consolariaMod, "OcramRelic")));


            //EDORBIS
            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "BlightKing"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.edorbisMod, "BlightKingRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "TheGardener"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.edorbisMod, "GardenerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "GlaciationHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.edorbisMod, "GlaciationRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "HandofCthulhu"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.edorbisMod, "HandofCthulhuRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "CursedLord"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.edorbisMod, "CursePreacherRelic")));


            //FARGOS SOULS
            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "TrojanSquirrel"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "TrojanSquirrelRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "DeviBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "DeviRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "BanishedBaron"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "BaronRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "LifeChallenger"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "LifelightRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "EarthChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "EarthChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "LifeChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "LifeChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "NatureChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "NatureChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "ShadowChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "ShadowChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "SpiritChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "SpiritChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "TerraChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "TerraChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "TimberChampion") || npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "TimberChampionHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "TimberChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "WillChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "WillChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "CosmosChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "EridanusRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "AbomBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "AbomRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "MutantBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyFargoSoulsDropCondition(), Common.GetModItem(ModConditions.fargosSoulsMod, "MutantRelic")));


            //HOMEWARD JOURNEY
            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "MarquisMoonsquid"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "MarquisMoonsquidRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "PriestessRod"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "PriestessRodRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Diver"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "DiverRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMotherbrain"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "TheMotherbrainRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WallofShadow"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "WallofShadowRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "SlimeGod"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "SolarRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheOverwatcher"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "TheOverwatcherRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheLifebringerHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "TheLifebringerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMaterealizer"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "TheMaterealizerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "ScarabBeliefRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WorldsEndEverlastingFallingWhale"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "EverlastingFallingWhaleRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheSon"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.homewardJourneyMod, "TheSonRelic")));


            //MARTAIN'S ORDER
            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Britzz"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.martainsOrderMod, "BritzzRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Alchemist"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.martainsOrderMod, "AlchemistRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "CarnagePillar"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.martainsOrderMod, "FleshyRelic")));


            //QWERTY
            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "PolarBear"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "PolarBearRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "FortressBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "DivineLightRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "AncientMachine"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "AncientMachineRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "CloakedDarkBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "NoehtnapRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Hydra"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "HydraRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Imperious"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "ImperiousRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "RuneGhost"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "RuneGhostRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "OLORDv2"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "OLORDRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "TheGreatTyrannosaurus"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.qwertyMod, "TyrantRelic")));


            //REDEMPTION
            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "FowlEmperor"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "FowlEmperorRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Cockatrice"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "CockatriceRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Basan"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "BasanRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Thorn"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "ThornRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Erhan") || npc.type == Common.GetModNPC(ModConditions.redemptionMod, "ErhanSpirit"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "ErhanRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Keeper") || npc.type == Common.GetModNPC(ModConditions.redemptionMod, "KeeperSpirit"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "KeeperRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "SkullDigger"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "SkullDiggerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "EaglecrestGolem"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "EaglecrestGolemRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "SoI"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "SoIRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "KS3"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "KS3Relic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OmegaCleaver"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "CleaverRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Gigapora"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "GigaporaRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OO"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "OORelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "PZ"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "PZRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Akka"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "AkkaRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Ukko"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "UkkoRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus") || npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus2") || npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus_Clone") || npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus2_Clone"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.redemptionMod, "NebRelic")));

            //SECRETS OF THE SHADOWS
            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Glowmoth"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "GlowmothRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PutridPinkyPhase2"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "PutridPinkyRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PharaohsCurse"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "PharaohsCurseRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TheAdvisorHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "AdvisorRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NewPolaris"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "PolarisRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Lux"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "LuxRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "SubspaceSerpentHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "SubspaceSerpentRelic")));

            //SPIRIT
            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Scarabeus"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "ScarabeusRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "MoonWizard") || npc.type == Common.GetModNPC(ModConditions.spiritMod, "MoonWizardTwo"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "MJWRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "ReachBoss") || npc.type == Common.GetModNPC(ModConditions.spiritMod, "ReachBoss1"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "VinewrathRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "AncientFlyer"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "AvianRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "SteamRaiderHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "StarplateRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "OccultistBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "OccultistRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Rylheian"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "RlyehianRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "FrostSaucer"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "FrostSaucerRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Infernon"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "InfernonRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Dusking"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "DuskingRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Atlas"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spiritMod, "AtlasRelicItem")));


            //SPOOKY
            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "RotGourd"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spookyMod, "RotGourdRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "SpookySpirit"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spookyMod, "SpookySpiritRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "Moco"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spookyMod, "MocoRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "DaffodilEye"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spookyMod, "DaffodilRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "OrroHead") || npc.type == Common.GetModNPC(ModConditions.spookyMod, "BoroHead"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spookyMod, "OrroboroRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "BigBone"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.spookyMod, "BigBoneRelicItem")));


            //STARS ABOVE
            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "VagrantBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "VagrantBossRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "ThespianBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "ThespianBossRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "CastorBoss") || npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "PolluxBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "DioskouroiBossRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "PenthesileaBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "PenthBossRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "NalhaunBoss") || npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "NalhaunBossPhase2"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "NalhaunBossRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "ArbitrationBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "ArbitrationBossRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "WarriorOfLightBoss") || npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "WarriorOfLightBossFinalPhase"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "WarriorBossRelicItem")));

            if (npc.type == Common.GetModNPC(ModConditions.starsAboveMod, "TsukiyomiBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.starsAboveMod, "TsukiyomiBossRelicItem")));


            //STORMS ADDITIONS
            if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "AridBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.stormsAdditionsMod, "AridBossRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "StormBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.stormsAdditionsMod, "StormBossRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "TheUltimateBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.stormsAdditionsMod, "UltimateBossRelic")));


            //THORIUM
            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "TheGrandThunderBird"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "TheGrandThunderBirdRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "QueenJellyfish"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "QueenJellyfishRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "Viscount"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "ViscountRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "GraniteEnergyStorm"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "GraniteEnergyStormRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "BuriedChampion"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "BuriedChampionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "StarScouter"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "StarScouterRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "CorpseBloom"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "CorpseBloomRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "Illusionist"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "IllusionistRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "PatchWerk"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "PatchWerkRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "BoreanStrider") || npc.type == Common.GetModNPC(ModConditions.thoriumMod, "BoreanStriderPopped"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "BoreanStriderRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "FallenBeholder") || npc.type == Common.GetModNPC(ModConditions.thoriumMod, "FallenBeholder2"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "FallenBeholderRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "Lich") || npc.type == Common.GetModNPC(ModConditions.thoriumMod, "LichHeadless"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "LichRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "ForgottenOne") || npc.type == Common.GetModNPC(ModConditions.thoriumMod, "ForgottenOneCracked") || npc.type == Common.GetModNPC(ModConditions.thoriumMod, "ForgottenOneReleased"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "ForgottenOneRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.thoriumMod, "DreamEater"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.thoriumMod, "ThePrimordialsRelic")));


            //UHTRIC
            if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "Dredger"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.uhtricMod, "DredgerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CharcoolSnowman"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.uhtricMod, "CharcoolSnowmanRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CosmicMenace"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.uhtricMod, "CosmicMenaceRelic")));


            //VITALITY
            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "StormCloudBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "StormCloudRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GrandAntlionBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "GrandAntlionRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GemstoneElementalBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "GemstoneElementalRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MoonlightDragonflyBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "MoonlightDragonflyRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "DreadnaughtBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "DreadnaughtRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MosquitoMonarchBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "MosquitoMonarchRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "AnarchulesBeetleBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "AnarchulesBeetleRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "ChaosbringerBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "ChaosbringerRelic")));

            if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "PaladinSpiritBoss"))
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOnlyDropCondition(), Common.GetModItem(ModConditions.vitalityMod, "PaladinSpiritRelic")));
            #endregion
            */
        }
    }
}
