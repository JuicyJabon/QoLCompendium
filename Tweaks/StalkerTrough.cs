using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class StalkerTrough : GlobalProjectile
    {
        public override bool PreAI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.FlyingPiggyBank && ModContent.GetInstance<QoLCConfig>().StalkerMoneyTrough)
            {
                Player player = Main.player[projectile.owner];
                float dist = Vector2.Distance(projectile.Center, player.Center);

                if (dist > 3000)
                {
                    projectile.Center = player.Top;
                }
                else if (projectile.Center != player.Center)
                {
                    Vector2 velocity = (player.Center + projectile.DirectionFrom(player.Center) * 3 * 16 - projectile.Center) / (dist < 3f * 16 ? 30f : 60f);
                    projectile.position += velocity;
                }

                if (projectile.timeLeft < 2 && projectile.timeLeft > 0)
                    projectile.timeLeft = 2;
            }

            return true;
        }

        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (projectile.type == ProjectileID.FlyingPiggyBank && ModContent.GetInstance<QoLCConfig>().StalkerMoneyTrough)
            {
                foreach (Projectile p in Main.projectile.Where(p => p.active && p.type == projectile.type && p.owner == projectile.owner))
                    p.timeLeft = 0;
            }
        }
    }
}
