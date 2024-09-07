﻿using QoLCompendium.Content.Tiles.Pylons;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Pylons
{
    public class HellPylon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HellPylonTile>(), 0);
            Item.SetShopValues((ItemRarityColor)1, Item.buyPrice(0, 10, 0, 0));
        }
    }
}
