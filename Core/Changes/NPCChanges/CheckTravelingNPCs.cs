namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class CheckTravelingNPCs : GlobalNPC
    {
        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (npc.type == NPCID.TravellingMerchant)
                ModConditions.talkedToTravelingMerchant = true;
            if (npc.type == NPCID.SkeletonMerchant)
                ModConditions.talkedToSkeletonMerchant = true;
        }
    }
}
