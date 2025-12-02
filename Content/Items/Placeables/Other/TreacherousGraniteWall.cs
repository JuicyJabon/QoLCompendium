using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Other
{
    public class TreacherousGraniteWall : ModItem, ILocalizedModType
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.GraniteWall;

        public new string LocalizationCategory => "Items.Placeables.Other";

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[ItemID.GraniteWall] = Type;
            Item.ResearchUnlockCount = 400;
            ItemID.Sets.DrawUnsafeIndicator[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(WallID.GraniteUnsafe);
            Item.SetShopValues(ItemRarityColor.White0, Item.sellPrice(0, 0, 0, 0));
        }
    }
}
