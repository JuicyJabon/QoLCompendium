using System.Reflection;
using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class PillarsDropMoreFragments : GlobalNPC
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
            if (Constants.LunarPillarIDs.Contains(npc.type) && QoLCompendium.mainConfig.LunarPillarsDropMoreFragments)
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
}