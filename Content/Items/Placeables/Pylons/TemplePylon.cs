﻿using QoLCompendium.Content.Tiles.Pylons;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Pylons
{
    public class TemplePylon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<TemplePylonTile>(), 0);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 10, 0, 0));
        }
    }
}
