﻿using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class DemonAltar : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Item.type] = ModContent.ItemType<AetherAltar>();
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<DemonAltarTile>());
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.DemoniteBar, 5);
            r.AddIngredient(ItemID.EbonstoneBlock, 12);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
