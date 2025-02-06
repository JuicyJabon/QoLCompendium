using Terraria.GameContent.Bestiary;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class DisableNaturalBossSpawns : ModSystem
    {
        public override void PreUpdateTime()
        {
            if (QoLCompendium.mainConfig.NoNaturalBossSpawns)
            {
                WorldGen.spawnEye = false;
                WorldGen.spawnHardBoss = 0;
            }
        }
    }

    public class SpawnRateEdits : GlobalNPC
    {
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
#pragma warning disable CA2211
        public static int boss = -1;
#pragma warning restore CA2211
    }

    public class TowerShieldHealth : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (NPC.ShieldStrengthTowerVortex > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerVortex = QoLCompendium.mainConfig.LunarPillarShieldHeath;

            if (NPC.ShieldStrengthTowerSolar > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerSolar = QoLCompendium.mainConfig.LunarPillarShieldHeath;

            if (NPC.ShieldStrengthTowerNebula > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerNebula = QoLCompendium.mainConfig.LunarPillarShieldHeath;

            if (NPC.ShieldStrengthTowerStardust > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerStardust = QoLCompendium.mainConfig.LunarPillarShieldHeath;
        }
    }

    public class BestiaryUnlock : GlobalNPC
    {
        public override void SetBestiary(NPC npc, BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            if (QoLCompendium.mainConfig.OneKillForBestiaryEntries)
                bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[npc.type], true);
        }
    }

    public class NoLavaFromSlimes : GlobalNPC
    {
        public override void HitEffect(NPC npc, NPC.HitInfo hit)
        {
            if (npc.type != NPCID.LavaSlime || Main.netMode == NetmodeID.MultiplayerClient || npc.life > 0)
            {
                return;
            }
            try
            {
                if (QoLCompendium.mainConfig.LavaSlimesDontDropLava)
                {
                    int num = (int)(npc.Center.X / 16f);
                    int num2 = (int)(npc.Center.Y / 16f);
                    if (!WorldGen.SolidTile(num, num2, false))
                    {
                        Tile val = Main.tile[num, num2];
                        if (val.CheckingLiquid)
                        {
                            Tile val2 = Main.tile[num, num2];
                            val2.LiquidAmount = 0;
                            WorldGen.SquareTileFrame(num, num2, true);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
