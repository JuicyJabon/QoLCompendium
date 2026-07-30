namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class MoreCoinDrops : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            npc.value *= QoLCompendium.mainConfig.EnemiesDropMoreCoins;
        }
    }
}
