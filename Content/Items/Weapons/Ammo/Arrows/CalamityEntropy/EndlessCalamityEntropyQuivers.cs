using CalamityEntropy.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.CalamityEntropy
{
    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessAnnihilateQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AnnihilateArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class EndlessHiveQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HiveArrow>();
    }
}
