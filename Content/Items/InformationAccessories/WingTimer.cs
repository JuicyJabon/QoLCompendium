using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.InformationAccessories
{
    public class WingTimer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 14;
            Item.maxStack = 1;
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 3, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type);
            r.AddIngredient(ItemID.Feather, 3);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            r.AddIngredient(ItemID.Wire, 6);
            r.Register();
            r.AddTile(TileID.Anvils);
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetInfoPlayer().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetInfoPlayer().wingTimer = true;
        }
    }
}
