using SOTS.Items.AbandonedVillage;
using SOTS.Items.Conduit;
using SOTS.Items.Earth;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.SOTS
{
    [JITWhenModsEnabled(CrossModSupport.SecretsOfTheShadows.Name)]
    [ExtendsFromMod(CrossModSupport.SecretsOfTheShadows.Name)]
    public class EndlessScrapMetalQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AncientSteelArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.SecretsOfTheShadows.Name)]
    [ExtendsFromMod(CrossModSupport.SecretsOfTheShadows.Name)]
    public class EndlessVibrantQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VibrantArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.SecretsOfTheShadows.Name)]
    [ExtendsFromMod(CrossModSupport.SecretsOfTheShadows.Name)]
    public class EndlessWormholeQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SkipArrow>();
    }
}
