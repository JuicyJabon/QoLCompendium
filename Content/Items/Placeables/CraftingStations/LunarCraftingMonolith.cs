using QoLCompendium.Content.Tiles.CraftingStations;

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
            Item.width = 10;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = Item.buyPrice(gold: 30);
            Item.createTile = ModContent.TileType<LunarCraftingMonolithTile>();
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.CraftingStations)
            {
                CreateRecipe()
                .AddIngredient(ItemID.LunarCraftingStation)
                .AddIngredient(ItemID.Autohammer)
                .AddIngredient(ItemID.LihzahrdFurnace)
                .AddRecipeGroup("Altars")
                .AddIngredient(ModContent.ItemType<AetherAltar>())
                .AddIngredient(ModContent.ItemType<BasicCraftingMonolith>())
                .AddIngredient(ModContent.ItemType<AdvancedCraftingMonolith>())
                .AddIngredient(ModContent.ItemType<HardmodeCraftingMonolith>())
                .Register();
            }
        }
    }
}
