using CalamityMod.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessBloodfireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BloodfireArrow>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessCinderQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CinderArrow>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessElysianQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ElysianArrow>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessIcicleQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<IcicleArrow>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessSproutingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SproutingArrow>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessVanquisherQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VanquisherArrow>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessVeriumQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VeriumBolt>();
    }
}
