﻿using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Other
{
    public class TreacherousMarbleWall : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.MarbleWall;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[ItemID.MarbleWall] = Type;
            Item.ResearchUnlockCount = 400;
            ItemID.Sets.DrawUnsafeIndicator[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(WallID.MarbleUnsafe);
            Item.SetShopValues(ItemRarityColor.White0, Item.sellPrice(0, 0, 0, 0));
        }
    }
}
