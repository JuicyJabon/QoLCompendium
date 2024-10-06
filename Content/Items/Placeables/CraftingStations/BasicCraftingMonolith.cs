using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class BasicCraftingMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BasicMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 5, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type);
            r.AddIngredient(ItemID.WorkBench);
            r.AddIngredient(ItemID.Furnace);
            r.AddRecipeGroup("QoLCompendium:Anvils");
            r.AddRecipeGroup("QoLCompendium:WoodenTables");
            r.AddRecipeGroup("QoLCompendium:WoodenChairs");
            r.AddIngredient(ItemID.CookingPot);
            r.AddIngredient(ItemID.HeavyWorkBench);
            r.AddIngredient(ItemID.Sawmill);
            r.AddIngredient(ItemID.Loom);
            r.AddIngredient(ItemID.Keg);
            r.AddRecipeGroup("QoLCompendium:WoodenSinks");
            r.AddIngredient(ItemID.Bottle);
            r.Register();
        }
    }
}
