using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.InformationAccessories
{
    public class BattalionLog : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 15;
            Item.maxStack = 1;
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 3, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type);
            r.AddIngredient(ItemID.BambooBlock, 4);
            r.AddIngredient(ItemID.Wood, 2);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            r.AddTile(TileID.Loom);
            r.Register();
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetInfoPlayer().battalionLog = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetInfoPlayer().battalionLog = true;
        }
    }
}
