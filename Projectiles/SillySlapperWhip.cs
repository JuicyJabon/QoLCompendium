namespace QoLCompendium.Projectiles
{
    public class SillySlapperWhip : WhipProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetWhipStats()
        {
            Projectile.width = 26;
            Projectile.height = 36;
            Projectile.WhipSettings.RangeMultiplier = 1f;
            Projectile.WhipSettings.Segments = 30;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.damage = 100;
            fishingLineColor = Color.Green;
            dustAmount = 0;
            swingDust = 0;
            tagDuration = 0;
            whipCrackSound = new SoundStyle($"{nameof(QoLCompendium)}/Assets/Sounds/SillySlapperSFX");
            multihitModifier = 1f;
        }
    }
}
