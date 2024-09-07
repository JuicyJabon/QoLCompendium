using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;

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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type);
            r.AddIngredient(ItemID.CrimtaneBar, 5);
            r.AddIngredient(ItemID.CrimstoneBlock, 12);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
