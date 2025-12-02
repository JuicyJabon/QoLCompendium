using CalamityMod.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Solutions.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessAstralSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AstralSolution>();
    }
}
