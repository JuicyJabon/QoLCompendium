using CalamityEntropy.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.CalamityEntropy
{
    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class EndlessAnnihilateQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AnnihilateArrow>();
    }

    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class EndlessHiveQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HiveArrow>();
    }
}
