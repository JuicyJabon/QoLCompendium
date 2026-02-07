using ThoriumMod.Items.Donate;
using ThoriumMod.Items.Geode;
using ThoriumMod.Items.Icy;
using ThoriumMod.Items.RangedItems;
using ThoriumMod.Items.Steel;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Thorium
{
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class EndlessCrystalQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CrystalArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class EndlessDurasteelQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DurasteelArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class EndlessGhostPulseQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<GhostPulseArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class EndlessIcyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<IcyArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class EndlessSpiritQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SpiritArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class EndlessThoriumSteelQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SteelArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class EndlessTalonQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<TalonArrow>();
    }
}
