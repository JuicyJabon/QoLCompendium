using CalamityEntropy.Content.Items;
using CalamityEntropy.Content.Projectiles;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Rockets.CalamityEntropy
{
    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessGodSlayerRocketPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<GodSlayerRocket>();
        public override int RocketProjectile => ModContent.ProjectileType<GodSlayerRocketProjectile>();
        public override int SnowmanProjectile => ModContent.ProjectileType<GodSlayerRocketProjectile>();
        public override int GrenadeProjectile => ModContent.ProjectileType<GodSlayerRocketProjectile>();
        public override int MineProjectile => ModContent.ProjectileType<GodSlayerRocketProjectile>();
    }

    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessRustyGrenadePouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<RustyGrenade>();
        public override int RocketProjectile => ModContent.ProjectileType<RustyGrenadeProjectile>();
        public override int SnowmanProjectile => ModContent.ProjectileType<RustyGrenadeProjectile>();
        public override int GrenadeProjectile => ModContent.ProjectileType<RustyGrenadeProjectile>();
        public override int MineProjectile => ModContent.ProjectileType<RustyGrenadeProjectile>();
    }
}
