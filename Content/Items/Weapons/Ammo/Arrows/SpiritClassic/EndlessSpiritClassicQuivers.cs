using SpiritMod.Items.Ammo.Arrow;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.SpiritClassic
{
    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class EndlessAccursedQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SepulchreArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class EndlessBeetleQuiver : BaseAmmo
    {
        public override int AmmunitionItem => Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BeetleArrow");
    }
}
