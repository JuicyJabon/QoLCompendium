using ThoriumMod.Items.Donate;
using ThoriumMod.Items.Geode;
using ThoriumMod.Items.Icy;
using ThoriumMod.Items.RangedItems;
using ThoriumMod.Items.Steel;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Thorium
{
    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class EndlessCrystalQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CrystalArrow>();
    }

    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class EndlessDurasteelQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DurasteelArrow>();
    }

    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class EndlessGhostPulseQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<GhostPulseArrow>();
    }

    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class EndlessIcyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<IcyArrow>();
    }

    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class EndlessSpiritQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SpiritArrow>();
    }

    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class EndlessThoriumSteelQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SteelArrow>();
    }

    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class EndlessTalonQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<TalonArrow>();
    }
}
