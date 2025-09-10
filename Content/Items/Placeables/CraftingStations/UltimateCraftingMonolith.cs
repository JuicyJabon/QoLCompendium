﻿using QoLCompendium.Content.Tiles.CraftingStations;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class UltimateCraftingMonolith : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<UltimateMonolithTile>());
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 20, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<LunarCraftingMonolith>());
            r.Register();
        }
    }
}
