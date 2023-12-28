using QoLCompendium.Tiles;
using Terraria;
using Terraria.ID;

namespace QoLCompendium.Items.Placeables
{
    public class BasicCraftingMonolith : ModItem
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
            Item.createTile = ModContent.TileType<BasicCraftingMonolithTile>();
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.CraftingStations)
            {
                CreateRecipe()
                .AddIngredient(ItemID.WorkBench)
                .AddIngredient(ItemID.Furnace)
                .AddRecipeGroup(nameof(ItemID.IronAnvil))
                .AddRecipeGroup(nameof(ItemID.WoodenTable))
                .AddRecipeGroup(nameof(ItemID.WoodenChair))
                .AddIngredient(ItemID.CookingPot)
                .AddIngredient(ItemID.HeavyWorkBench)
                .AddIngredient(ItemID.Sawmill)
                .AddIngredient(ItemID.Loom)
                .AddIngredient(ItemID.Keg)
                .AddRecipeGroup(nameof(ItemID.WoodenSink))
                .AddIngredient(ItemID.Bottle)
                .Register();
            }
        }
    }
}
