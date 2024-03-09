using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class SunPedestal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 18;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.MoonPedestals)
            {
                CreateRecipe()
                .AddIngredient(ItemID.GrayBrick, 10)
                .AddIngredient(ItemID.SunplateBlock, 8)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().sunPedestal = true;
            }
        }
    }
}
