using Clamity.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Clamity
{
    [JITWhenModsEnabled(ModConditions.clamityAddonName)]
    [ExtendsFromMod(ModConditions.clamityAddonName)]
    public class EndlessFrostfireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FrostfireArrow>();
    }
}
