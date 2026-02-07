using CalamityMod.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessBloodfireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BloodfireArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessCinderQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CinderArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessElysianQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ElysianArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessIcicleQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<IcicleArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessSproutingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SproutingArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessVanquisherQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VanquisherArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessVeriumQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VeriumBolt>();
    }
}
