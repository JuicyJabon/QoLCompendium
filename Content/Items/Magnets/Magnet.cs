using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Magnets
{
    public class Magnet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 13;
            Item.maxStack = 1;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetMagnetPlayer().BaseMagnet = true;
            }
        }
    }
}
