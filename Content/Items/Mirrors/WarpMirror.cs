using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Mirrors
{
    public class WarpMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 2, 0, 0));
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().warpMirror = true;
        }

        public override bool CanUseItem(Player player) => false;

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Mirrors, Type);
            r.AddIngredient(ItemID.Glass, 10);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 8);
            r.AddIngredient(ItemID.GoldCoin, 3);
            r.AddTile(TileID.Furnaces);
            r.Register();
        }
    }
}
