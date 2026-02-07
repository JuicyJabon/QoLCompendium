using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class JellyfishDropGel : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if ((npc.type == NPCID.BlueJellyfish || npc.type == NPCID.GreenJellyfish || npc.type == NPCID.BloodJelly || npc.type == NPCID.FungoFish) && QoLCompendium.mainConfig.JellyfishDropGel)
                npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 3));
            if (npc.type == NPCID.PinkJellyfish && QoLCompendium.mainConfig.PinkJellyfishDropPinkGel)
                npcLoot.Add(ItemDropRule.Common(ItemID.PinkGel, 1, 3, 9));
        }
    }
}
