using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Projectiles
{
    // Token: 0x02000019 RID: 25
    internal class LifeformLocator : ModProjectile
    {
        // Token: 0x0600008D RID: 141 RVA: 0x00008184 File Offset: 0x00006384
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 28;
            Projectile.light = 0.75f;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 61;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }

        // Token: 0x0600008E RID: 142 RVA: 0x000081F8 File Offset: 0x000063F8
        public override void AI()
        {
            int NPCnumber = (int)Projectile.ai[0];
            Vector2 npcpos = new((int)Main.npc[NPCnumber].Center.X, (int)Main.npc[NPCnumber].Center.Y);
            Player player = Main.player[Projectile.owner];

            if (Projectile.owner == Main.myPlayer) // Multiplayer support
            {
                Vector2 diff = npcpos - player.Center;
                diff.Normalize();
                Projectile.velocity = diff;
                Projectile.direction = npcpos.X > player.Center.X ? 1 : -1;
                Projectile.netUpdate = true;
            }
            Projectile.position = player.position + Projectile.velocity * 45f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
    }
}
