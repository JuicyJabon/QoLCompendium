using Terraria.GameContent.Bestiary;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class InstantBestiaryUnlock : GlobalNPC
    {
        public override void SetBestiary(NPC npc, BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            if (QoLCompendium.mainConfig.OneKillForBestiaryEntries)
                bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[npc.type], true);
        }
    }
}
