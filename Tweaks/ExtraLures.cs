using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class ExtraLures : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.bobber && projectile.owner == Main.myPlayer && ModContent.GetInstance<QoLCConfig>().ExtraLures && source is EntitySource_ItemUse)
            {
                int split = 1;

                switch (projectile.type)
                {
                    case ProjectileID.BobberFiberglass:
                    case ProjectileID.BobberFisherOfSouls:
                    case ProjectileID.BobberFleshcatcher:
                    case ProjectileID.BobberBloody:
                    case ProjectileID.BobberScarab:
                        split = 3;
                        break;

                    case ProjectileID.BobberMechanics:
                    case ProjectileID.BobbersittingDuck:
                        split = 4;
                        break;

                    case ProjectileID.BobberHotline:
                    case ProjectileID.BobberGolden:
                        split = 5;
                        break;
                }

                if (Main.player[projectile.owner].HasBuff(BuffID.Fishing))
                    split++;

                if (split > 1)
                    SplitProj(projectile, split);
            }
        }

        public static void SplitProj(Projectile projectile, int number)
        {
            Projectile split;

            double spread = 0.3 / number;

            for (int i = 0; i < number / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int factor = (j == 0) ? 1 : -1;
                    split = NewProjectileDirectSafe(projectile.GetSource_FromThis(), projectile.Center, projectile.velocity.RotatedBy(factor * spread * (i + 1)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

                    if (split != null)
                    {
                        split.friendly = true;
                    }
                }
            }

            if (number % 2 == 0)
            {
                projectile.active = false;
            }
        }

        public static Projectile NewProjectileDirectSafe(IEntitySource source, Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(source, pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < Main.maxProjectiles) ? Main.projectile[p] : null;
        }
    }
}
