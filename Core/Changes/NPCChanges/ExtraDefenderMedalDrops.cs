using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class ExtraDefenderMedalDrops : GlobalNPC
    {
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
        }
    }
}
