using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class Paperweight : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 11;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Paperweight, Type);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 3);
            r.AddIngredient(ItemID.Glass, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited && !Main.playerInventory)
            {
                player.controlUseItem = true;
            }
        }
    }
}
