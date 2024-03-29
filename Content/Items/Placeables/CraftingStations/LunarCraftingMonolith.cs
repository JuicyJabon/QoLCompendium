using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;

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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type);
            r.AddIngredient(ItemID.LunarCraftingStation);
            r.AddIngredient(ItemID.Autohammer);
            r.AddIngredient(ItemID.LihzahrdFurnace);
            r.AddRecipeGroup("Altars");
            r.AddIngredient(ModContent.ItemType<AetherAltar>());
            r.AddIngredient(ModContent.ItemType<BasicCraftingMonolith>());
            r.AddIngredient(ModContent.ItemType<AdvancedCraftingMonolith>());
            r.AddIngredient(ModContent.ItemType<HardmodeCraftingMonolith>());
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
