using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class EarlyOOARelicDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.DD2DarkMageT1 && QoLCompendium.mainConfig.EarlyOldOnesArmyRelics)
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOrMasterDropCondition(), ItemID.DarkMageMasterTrophy));

            if (npc.type == NPCID.DD2OgreT2 && QoLCompendium.mainConfig.EarlyOldOnesArmyRelics)
                npcLoot.Add(ItemDropRule.ByCondition(new ExpertOrMasterDropCondition(), ItemID.OgreMasterTrophy));
        }
    }
}
