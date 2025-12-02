using Clamity.Content.Biomes.FrozenHell.Items;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Solutions.Clamity
{
    [JITWhenModsEnabled(ModConditions.clamityAddonName)]
    [ExtendsFromMod(ModConditions.clamityAddonName)]
    public class EndlessCyanSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CyanSolution>();
    }
}
