using Clamity.Content.Biomes.FrozenHell.Items;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Solutions.Clamity
{
    [JITWhenModsEnabled(CrossModSupport.Clamity.Name)]
    [ExtendsFromMod(CrossModSupport.Clamity.Name)]
    public class EndlessCyanSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CyanSolution>();
    }
}
