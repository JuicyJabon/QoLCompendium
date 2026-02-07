using MartainsOrder.Items;
using MartainsOrder.Items.Geo;
using MartainsOrder.Items.Shadowflame;
using MartainsOrder.Items.Shimmer;
using MartainsOrder.Items.Zinc;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Bullets.MartinsOrder
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessBloodshotPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<Bloodshot>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessBouncyBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BouncyBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessHyperBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<WhiteBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessJestersBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<JesterBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessPoisonBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PoisonBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessSeashellBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SeaBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessShadowflameBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ShadowflameBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessShimmerBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ShimmerBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessStickyBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<StickyBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessTectonicBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RockBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessTrojanBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<TrojanBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessZincBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ZincBullet>();
    }
}
