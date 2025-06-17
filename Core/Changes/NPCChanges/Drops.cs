using System.Reflection;
using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class PillarsDropMore : GlobalNPC
    {
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
            if (Common.LunarPillarIDs.Contains(npc.type) && QoLCompendium.mainConfig.LunarPillarsDropMoreFragments)
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
        }
    }
}
