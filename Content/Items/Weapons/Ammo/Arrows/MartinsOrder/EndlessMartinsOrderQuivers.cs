using MartainsOrder.Fool;
using MartainsOrder.Items;
using MartainsOrder.Items.Geo;
using MartainsOrder.Items.Shadowflame;
using MartainsOrder.Items.Zinc;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.MartinsOrder
{
    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessBouncyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BouncyArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessGlowingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<GlowingArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessHyperQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<WhiteArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessPoisonQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PoisonArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessSeaQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SeaArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessShadowflameQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ShadowflameArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessStickyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<StickyArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessTectonicQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RockArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessTrojanQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<TrojanArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessUltraGlowingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<UltraGlowingArrow>();
    }

    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class EndlessZincQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ZincArrow>();
    }
}
