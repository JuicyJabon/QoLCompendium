using Macrocosm.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Macrocosm
{
    [JITWhenModsEnabled(ModConditions.macrocosmName)]
    [ExtendsFromMod(ModConditions.macrocosmName)]
    public class EndlessInvarQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<InvarArrow>();
    }
}
