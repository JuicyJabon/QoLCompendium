using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;

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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type);
            r.AddIngredient(ItemID.WorkBench);
            r.AddIngredient(ItemID.Furnace);
            r.AddRecipeGroup(nameof(ItemID.IronAnvil));
            r.AddRecipeGroup(nameof(ItemID.WoodenTable));
            r.AddRecipeGroup(nameof(ItemID.WoodenChair));
            r.AddIngredient(ItemID.CookingPot);
            r.AddIngredient(ItemID.HeavyWorkBench);
            r.AddIngredient(ItemID.Sawmill);
            r.AddIngredient(ItemID.Loom);
            r.AddIngredient(ItemID.Keg);
            r.AddRecipeGroup(nameof(ItemID.WoodenSink));
            r.AddIngredient(ItemID.Bottle);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
