using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class BannerBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 11;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 0, 20, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.BannerBox, Type);
            r.AddIngredient(ItemID.Wood, 12);
            r.AddIngredient(ItemID.Silk, 2);
            r.AddTile(TileID.Loom);
            r.Register();
        }
    }
}
