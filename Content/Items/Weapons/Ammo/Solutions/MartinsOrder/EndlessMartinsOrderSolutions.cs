using MartainsOrder.Items;
using MartainsOrder.Items.Extra;
using MartainsOrder.Items.Void;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Solutions.MartinsOrder
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessBlackSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<VoidSolution>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessGraySolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FillerSolution>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessMeanSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MSolution>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessTealSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MoisturizerSolution>();
    }
}
