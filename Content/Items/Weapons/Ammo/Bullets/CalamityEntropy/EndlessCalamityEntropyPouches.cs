using CalamityEntropy.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Bullets.CalamityEntropy
{
    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class EndlessCondensedBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CondensedBullet>();
    }

    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class EndlessHiveBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HiveBullet>();
    }

    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class EndlessNegentropyBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<NegentropyBullet>();
    }

    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class EndlessRockBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RockBullet>();
    }
}
