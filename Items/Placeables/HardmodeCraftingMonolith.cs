using QoLCompendium.Tiles;

namespace QoLCompendium.Items.Placeables
{
    public class HardmodeCraftingMonolith : ModItem
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
            Item.createTile = ModContent.TileType<HardmodeCraftingMonolithTile>();
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.CraftingStations)
            {
                CreateRecipe()
                .AddRecipeGroup(nameof(ItemID.MythrilAnvil))
                .AddRecipeGroup(nameof(ItemID.AdamantiteForge))
                .AddRecipeGroup(nameof(ItemID.Bookcase))
                .AddIngredient(ItemID.CrystalBall)
                .AddIngredient(ItemID.FleshCloningVaat)
                .AddIngredient(ItemID.LesionStation)
                .AddIngredient(ItemID.SteampunkBoiler)
                .AddIngredient(ItemID.BlendOMatic)
                .AddIngredient(ItemID.MeatGrinder)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
