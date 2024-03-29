using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type);
            r.AddRecipeGroup(nameof(ItemID.MythrilAnvil));
            r.AddRecipeGroup(nameof(ItemID.AdamantiteForge));
            r.AddRecipeGroup(nameof(ItemID.Bookcase));
            r.AddIngredient(ItemID.CrystalBall);
            r.AddIngredient(ItemID.FleshCloningVaat);
            r.AddIngredient(ItemID.LesionStation);
            r.AddIngredient(ItemID.SteampunkBoiler);
            r.AddIngredient(ItemID.BlendOMatic);
            r.AddIngredient(ItemID.MeatGrinder);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
