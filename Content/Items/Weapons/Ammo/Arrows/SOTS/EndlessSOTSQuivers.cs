using SOTS.Items.AbandonedVillage;
using SOTS.Items.Conduit;
using SOTS.Items.Earth;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.SOTS
{
    [JITWhenModsEnabled(ModConditions.secretsOfTheShadowsName)]
    [ExtendsFromMod(ModConditions.secretsOfTheShadowsName)]
    public class EndlessScrapMetalQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AncientSteelArrow>();
    }

    [JITWhenModsEnabled(ModConditions.secretsOfTheShadowsName)]
    [ExtendsFromMod(ModConditions.secretsOfTheShadowsName)]
    public class EndlessVibrantQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VibrantArrow>();
    }

    [JITWhenModsEnabled(ModConditions.secretsOfTheShadowsName)]
    [ExtendsFromMod(ModConditions.secretsOfTheShadowsName)]
    public class EndlessWormholeQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SkipArrow>();
    }
}
