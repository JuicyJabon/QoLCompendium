using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class NoSpawns : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (AnyBossAlive() && player.Distance(Main.npc[boss].Center) < 6000f && ModContent.GetInstance<QoLCConfig>().NoSpawns)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QoLCPlayer>().enemyEraser)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QoLCPlayer>().enemyAggressor)
            {
                spawnRate = (int)((double)spawnRate * 0.1);
                maxSpawns = (int)((float)maxSpawns * 10f);
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

        public static int boss = -1;
    }
}
