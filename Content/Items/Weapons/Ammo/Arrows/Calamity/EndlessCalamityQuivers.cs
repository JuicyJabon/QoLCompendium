using CalamityMod.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class EndlessBloodfireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BloodfireArrow>();
    }

    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class EndlessCinderQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CinderArrow>();
    }

    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class EndlessElysianQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ElysianArrow>();
    }

    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class EndlessIcicleQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<IcicleArrow>();
    }

    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class EndlessSproutingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SproutingArrow>();
    }

    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class EndlessVanquisherQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VanquisherArrow>();
    }

    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class EndlessVeriumQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VeriumBolt>();
    }
}
