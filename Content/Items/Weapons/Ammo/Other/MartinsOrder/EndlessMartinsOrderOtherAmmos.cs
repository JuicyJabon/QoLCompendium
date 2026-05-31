using MartainsOrder.Items;
using MartainsOrder.Items.Boss.Alchemist;
using MartainsOrder.Items.Extra;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Other.MartinsOrder
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessCompressedAirCapsulePouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<CompressedAirCapsule>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessFishyumCoinBag : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FishyumCoin>();
        public override int IngredientStackCount => 396;
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessHayBale : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HayBall>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessWoodSplinterBundle : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<WoodSplinter>();
    }
}
