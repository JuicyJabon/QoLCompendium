using QoLCompendium.Content.Buffs;

namespace QoLCompendium.Content.Projectiles.Dedicated
{
    public class Snake : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //Main.projFrames[Projectile.type] = 4;
            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, Main.projFrames[Projectile.type], 6)
                .WithOffset(-10, -20f)
                .WithSpriteDirection(-1)
                .WithCode(DelegateMethods.CharacterPreview.Float);
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SharkPup);
            AIType = ProjectileID.SharkPup;
            Projectile.width = 38;
            Projectile.height = 52;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.petFlagBabyShark = false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff(ModContent.BuffType<SnakeBuff>()))
                Projectile.timeLeft = 2;

            /*
            if (++Projectile.frameCounter >= 15)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            */
        }
    }
}
