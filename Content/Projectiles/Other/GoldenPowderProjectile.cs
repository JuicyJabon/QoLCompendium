using QoLCompendium.Core;

namespace QoLCompendium.Content.Projectiles.Other
{
    public class GoldenPowderProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.PurificationPowder);
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Projectile.velocity *= 0.95f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 180f)
                Projectile.Kill();

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                for (int i = 0; i < 30; i++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GoldCoin, Projectile.velocity.X, Projectile.velocity.Y, 50);
                }
            }
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                var myHitbox = hitbox;
                foreach (var npc in from n in Main.npc where n.active && myHitbox.Intersects(n.getRect()) select n)
                {
                    if (Common.NormalBunnies[npc.type])
                    {
                        npc.Transform(NPCID.GoldBunny);
                    }
                    if (Common.NormalSquirrels[npc.type])
                    {
                        npc.Transform(NPCID.SquirrelGold);
                    }
                    if (Common.NormalButterflies[npc.type])
                    {
                        npc.Transform(NPCID.GoldButterfly);
                    }
                    if (Common.NormalBirds[npc.type])
                    {
                        npc.Transform(NPCID.GoldBird);
                    }
                    if (NPCID.Sets.IsDragonfly[npc.type] && npc.type != NPCID.GoldDragonfly)
                    {
                        npc.Transform(NPCID.GoldDragonfly);
                    }
                    if (npc.type == NPCID.Frog)
                    {
                        npc.Transform(NPCID.GoldFrog);
                    }
                    if (npc.type == NPCID.Goldfish)
                    {
                        npc.Transform(NPCID.GoldGoldfish);
                    }
                    if (npc.type == NPCID.GoldfishWalker)
                    {
                        npc.Transform(NPCID.GoldGoldfishWalker);
                    }
                    if (npc.type == NPCID.Grasshopper)
                    {
                        npc.Transform(NPCID.GoldGrasshopper);
                    }
                    if (npc.type == NPCID.LadyBug)
                    {
                        npc.Transform(NPCID.GoldLadyBug);
                    }
                    if (npc.type == NPCID.Mouse)
                    {
                        npc.Transform(NPCID.GoldMouse);
                    }
                    if (npc.type == NPCID.Seahorse)
                    {
                        npc.Transform(NPCID.GoldSeahorse);
                    }
                    if (npc.type == NPCID.WaterStrider)
                    {
                        npc.Transform(NPCID.GoldWaterStrider);
                    }
                    if (npc.type == NPCID.Worm || npc.type == NPCID.TruffleWorm || npc.type == NPCID.TruffleWormDigger)
                    {
                        npc.Transform(NPCID.GoldWorm);
                    }
                }
            }
        }
    }
}
