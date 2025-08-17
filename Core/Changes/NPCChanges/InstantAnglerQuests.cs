namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class InstantAnglerQuests : GlobalNPC
    {
        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (QoLCompendium.mainConfig.AnglerQuestInstantReset && Main.anglerQuestFinished)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.AnglerQuestSwap();
                }
                else if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    // Broadcast swap request to server
                    var netMessage = Mod.GetPacket();
                    netMessage.Write((byte)3);
                    netMessage.Send();
                }
            }
        }
    }
}
