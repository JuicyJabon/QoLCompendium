using QoLCompendium.Tiles;

namespace QoLCompendium.Items.Placeables
{
    public class AsphaltPlatform : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 200;
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AsphaltPlatformTile>();

        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.AsphaltPlatform)
            {
                CreateRecipe(2)
                .AddIngredient(ItemID.AsphaltBlock, 1)
                .Register();

                Recipe.Create(ItemID.AsphaltBlock, 1)
                    .AddIngredient(ModContent.ItemType<AsphaltPlatform>(), 2)
                    .Register();
            }
        }
    }
}
