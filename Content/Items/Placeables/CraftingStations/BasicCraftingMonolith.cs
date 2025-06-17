using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class BasicCraftingMonolith : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BasicMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup("QoLCompendium:AnyWorkBench");
            r.AddIngredient(ItemID.Furnace);
            r.AddRecipeGroup("QoLCompendium:Anvils");
            r.AddRecipeGroup("QoLCompendium:AnyTable");
            r.AddRecipeGroup("QoLCompendium:AnyChair");
            r.AddRecipeGroup("QoLCompendium:AnyCookingPot");
            r.AddIngredient(ItemID.HeavyWorkBench);
            r.AddIngredient(ItemID.Sawmill);
            r.AddIngredient(ItemID.Loom);
            r.AddIngredient(ItemID.Keg);
            r.AddRecipeGroup("QoLCompendium:AnySink");
            r.AddRecipeGroup("QoLCompendium:AnyBottle");
            r.Register();
        }
    }
}
