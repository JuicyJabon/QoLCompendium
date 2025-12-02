using SpiritMod.Items.Ammo.Arrow;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.SpiritClassic
{
    [JITWhenModsEnabled(ModConditions.spiritClassicName)]
    [ExtendsFromMod(ModConditions.spiritClassicName)]
    public class EndlessAccursedQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SepulchreArrow>();
    }

    [JITWhenModsEnabled(ModConditions.spiritClassicName)]
    [ExtendsFromMod(ModConditions.spiritClassicName)]
    public class EndlessBeetleQuiver : BaseAmmo
    {
        public override int AmmunitionItem => Common.GetModItem(ModConditions.spiritClassicMod, "BeetleArrow");
    }
}
