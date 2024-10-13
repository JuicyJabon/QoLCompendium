using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class LunarCraftingMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<LunarMonolithTile>());
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 20, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<BasicCraftingMonolith>());
            r.AddIngredient(ModContent.ItemType<SpecializedCraftingMonolith>());
            r.AddIngredient(ModContent.ItemType<HardmodeCraftingMonolith>());
            r.AddIngredient(ItemID.LunarCraftingStation);
            r.AddIngredient(ItemID.Autohammer);
            r.AddIngredient(ItemID.LihzahrdFurnace);
            r.AddRecipeGroup("QoLCompendium:Altars");
            r.AddIngredient(ModContent.ItemType<AetherAltar>());
            r.Register();
        }
    }
}
