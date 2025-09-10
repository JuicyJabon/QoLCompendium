using MartainsOrder.Fool;
using MartainsOrder.Items;
using MartainsOrder.Items.Geo;
using MartainsOrder.Items.Shadowflame;
using MartainsOrder.Items.Zinc;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.MartinsOrder
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessBouncyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BouncyArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessGlowingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<GlowingArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessHyperQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<WhiteArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessPoisonQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PoisonArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessSeaQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SeaArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessShadowflameQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ShadowflameArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessStickyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<StickyArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessTectonicQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RockArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessTrojanQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<TrojanArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessUltraGlowingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<UltraGlowingArrow>();
    }

    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class EndlessZincQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ZincArrow>();
    }
}
