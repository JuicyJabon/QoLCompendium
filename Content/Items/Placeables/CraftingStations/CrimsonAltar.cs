using QoLCompendium.Content.Tiles.CraftingStations;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class CrimsonAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Item.type] = ModContent.ItemType<AetherAltar>();
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<CrimsonAltarTile>();
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.CraftingStations)
            {
                CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 5)
                .AddIngredient(ItemID.CrimstoneBlock, 12)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
