using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class RelicsDropInExpertMode : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
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
