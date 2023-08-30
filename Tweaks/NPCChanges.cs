using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
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
            if (player.GetModPlayer<QoLCPlayer>().enemyCalmer)
            {
                spawnRate = (int)(spawnRate * 5f);
                maxSpawns = (int)(maxSpawns * 1f);
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

    public class NoLavaFromSlimes : ModSystem
    {
        public override void Load()
        {
            IL_NPC.VanillaHitEffect += LavalessLavaSlime;
        }

        private void LavalessLavaSlime(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(
                    MoveType.After,
                    i => i.MatchCall(typeof(Main), "get_expertMode"),
                    i => i.Match(OpCodes.Brfalse),
                    i => i.Match(OpCodes.Ldarg_0),
                    i => i.MatchLdfld(typeof(NPC), nameof(NPC.type)),
                    i => i.Match(OpCodes.Ldc_I4_S, (sbyte)NPCID.LavaSlime)
                ))
                return;

            c.EmitDelegate<Func<int, int>>(returnValue => ModContent.GetInstance<QoLCConfig>().LavaSlimeNoLava ? NPCLoader.NPCCount : returnValue);
        }
    }
}
