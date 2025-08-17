using CalamityEntropy.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.CalamityEntropy
{
    [JITWhenModsEnabled("CalamityEntropy")]
    [ExtendsFromMod("CalamityEntropy")]
    public class EndlessAnnihilateQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AnnihilateArrow>();
    }

    [JITWhenModsEnabled("CalamityEntropy")]
    [ExtendsFromMod("CalamityEntropy")]
    public class EndlessHiveQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HiveArrow>();
    }
}
