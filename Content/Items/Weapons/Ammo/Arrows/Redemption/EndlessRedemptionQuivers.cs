using Redemption.Items.Weapons.HM.Ammo;
using Redemption.Items.Weapons.PreHM.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Redemption
{
    [JITWhenModsEnabled(CrossModSupport.Redemption.Name)]
    [ExtendsFromMod(CrossModSupport.Redemption.Name)]
    public class EndlessAquaQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AquaArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Redemption.Name)]
    [ExtendsFromMod(CrossModSupport.Redemption.Name)]
    public class EndlessBileQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BileArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Redemption.Name)]
    [ExtendsFromMod(CrossModSupport.Redemption.Name)]
    public class EndlessMoonflareQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MoonflareArrow>();
    }
}
