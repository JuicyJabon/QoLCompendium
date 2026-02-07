using Clamity.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Clamity
{
    [JITWhenModsEnabled(CrossModSupport.Clamity.Name)]
    [ExtendsFromMod(CrossModSupport.Clamity.Name)]
    public class EndlessFrostfireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FrostfireArrow>();
    }
}
