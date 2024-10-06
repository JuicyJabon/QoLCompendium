using QoLCompendium.Content.Buffs;

namespace QoLCompendium.Content.Projectiles.Dedicated
{
    public class LittleYagi : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, Main.projFrames[Projectile.type], 6)
                .WithOffset(-10, -20f)
                .WithSpriteDirection(-1)
                .WithCode(DelegateMethods.CharacterPreview.Float);
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.DD2PetGato);
            AIType = ProjectileID.DD2PetGato;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff(ModContent.BuffType<LittleYagiBuff>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}
