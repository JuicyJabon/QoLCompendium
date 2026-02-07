using CalamityMod.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Solutions.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessAstralSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AstralSolution>();
    }
}
