﻿using QoLCompendium.Content.Tiles.CraftingStations;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class AetherAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AetherAltarTile>());
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 5, 0, 0));
        }
    }
}
