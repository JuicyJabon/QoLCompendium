﻿using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class CrimsonAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Item.type] = ModContent.ItemType<AetherAltar>();
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CrimsonAltarTile>());
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type);
            r.AddIngredient(ItemID.CrimtaneBar, 5);
            r.AddIngredient(ItemID.CrimstoneBlock, 12);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
