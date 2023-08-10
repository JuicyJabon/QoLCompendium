using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class InvincibleTownies : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            bool dontTakeDamageFromHostiles = npc.dontTakeDamageFromHostiles;
            if (npc.type == NPCID.DD2EterniaCrystal && ModContent.GetInstance<QoLCConfig>().FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = false;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
            if (npc.friendly && ModContent.GetInstance<QoLCConfig>().FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = true;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
        }
    }

    public class IncreasedCoinDrop : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            npc.value *= ModContent.GetInstance<QoLCConfig>().MoreCoins;
        }
    }

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
                spawnRate = (int)(spawnRate * 0.1);
                maxSpawns = (int)(maxSpawns * 10f);
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
