namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class SpawnRateEdits : GlobalNPC
    {
        #pragma warning disable CA2211
        public static int boss = -1;
        #pragma warning restore CA2211

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (AnyBossAlive() && player.Distance(Main.npc[boss].Center) < 6000f && QoLCompendium.mainConfig.NoSpawnsDuringBosses)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QoLCPlayer>().noSpawns)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QoLCPlayer>().increasedSpawns)
            {
                spawnRate = (int)(spawnRate * 0.1);
                maxSpawns = (int)(maxSpawns * 10f);
            }
            if (player.GetModPlayer<QoLCPlayer>().decreasedSpawns)
            {
                spawnRate = (int)(spawnRate * 2.5);
                maxSpawns = (int)(maxSpawns * 0.3f);
            }
        }

        public override bool PreAI(NPC npc)
        {
            if (npc.boss)
            {
                boss = npc.whoAmI;
            }
            return true;
        }

        public static bool AnyBossAlive()
        {
            if (boss == -1)
            {
                return false;
            }
            NPC npc = Main.npc[boss];
            if (npc.active && npc.type != NPCID.MartianSaucerCore && (npc.boss || npc.type == NPCID.EaterofWorldsHead))
            {
                return true;
            }
            boss = -1;
            return false;
        }
    }
}
