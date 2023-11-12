using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.InformationAccessories
{
    public class Regenerator : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 11;
            Item.height = 16;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ItemID.LifeCrystal, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().regenerator = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().regenerator = true;
        }
    }
}
