using Redemption.Items.Weapons.HM.Ammo;
using Redemption.Items.Weapons.PreHM.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Redemption
{
    [JITWhenModsEnabled(ModConditions.redemptionName)]
    [ExtendsFromMod(ModConditions.redemptionName)]
    public class EndlessAquaQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AquaArrow>();
    }

    [JITWhenModsEnabled(ModConditions.redemptionName)]
    [ExtendsFromMod(ModConditions.redemptionName)]
    public class EndlessBileQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BileArrow>();
    }

    [JITWhenModsEnabled(ModConditions.redemptionName)]
    [ExtendsFromMod(ModConditions.redemptionName)]
    public class EndlessMoonflareQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MoonflareArrow>();
    }
}
