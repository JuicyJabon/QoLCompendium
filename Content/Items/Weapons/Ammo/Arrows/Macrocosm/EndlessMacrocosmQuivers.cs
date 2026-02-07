using Macrocosm.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Macrocosm
{
    [JITWhenModsEnabled(CrossModSupport.Macrocosm.Name)]
    [ExtendsFromMod(CrossModSupport.Macrocosm.Name)]
    public class EndlessInvarQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<InvarArrow>();
    }
}
