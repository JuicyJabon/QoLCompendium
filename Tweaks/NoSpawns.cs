using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Tweaks
{
    // Token: 0x02000011 RID: 17
    public class NoSpawns : GlobalNPC
    {
        // Token: 0x0600006C RID: 108 RVA: 0x00005998 File Offset: 0x00003B98
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (AnyBossAlive() && player.Distance(Main.npc[boss].Center) < 6000f && ModContent.GetInstance<QoLCConfig>().NoSpawns)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QolCPlayer>().enemyEraser)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QolCPlayer>().enemyAggressor)
            {
                spawnRate = (int)((double)spawnRate * 0.1);
                maxSpawns = (int)((float)maxSpawns * 10f);
            }
        }

        // Token: 0x0600006D RID: 109 RVA: 0x00005A11 File Offset: 0x00003C11
        public override bool PreAI(NPC npc)
        {
            if (npc.boss)
            {
                boss = npc.whoAmI;
            }
            return true;
        }

        // Token: 0x0600006E RID: 110 RVA: 0x00005A28 File Offset: 0x00003C28
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

        // Token: 0x040000A4 RID: 164
        public static int boss = -1;
    }
}
