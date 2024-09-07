using QoLCompendium.Content.Tiles.Other;
using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Placeables.Other
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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.AsphaltPlatform, Type, 2);
            r.AddIngredient(ItemID.AsphaltBlock);
            r.Register();

            r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.AsphaltPlatform, ItemID.AsphaltBlock);
            r.AddIngredient(ModContent.ItemType<AsphaltPlatform>(), 2);
            r.Register();
        }
    }
}
