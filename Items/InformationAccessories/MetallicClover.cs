using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.InformationAccessories
{
    public class MetallicClover : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 15;
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
                .AddIngredient(ItemID.Vine, 2)
                .AddIngredient(ItemID.TatteredCloth, 1)
                .AddIngredient(RecipeGroupID.IronBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().metallicClover = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().metallicClover = true;
        }
    }
}
