using MartainsOrder.Fool;
using MartainsOrder.Items;
using MartainsOrder.Items.Geo;
using MartainsOrder.Items.Shadowflame;
using MartainsOrder.Items.Zinc;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.MartinsOrder
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessBouncyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BouncyArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessGlowingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<GlowingArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessHyperQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<WhiteArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessPoisonQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PoisonArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessSeaQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SeaArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessShadowflameQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ShadowflameArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessStickyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<StickyArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessTectonicQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RockArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessTrojanQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<TrojanArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessUltraGlowingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<UltraGlowingArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessZincQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ZincArrow>();
    }
}
