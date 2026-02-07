using CalamityEntropy.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Bullets.CalamityEntropy
{
    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessCondensedBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CondensedBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessHiveBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HiveBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessNegentropyBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<NegentropyBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessRockBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RockBullet>();
    }
}
