using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class EclipsePedestal : ModItem
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
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.MoonPedestals)
            {
                CreateRecipe()
                .AddIngredient(ItemID.GrayBrick, 10)
                .AddIngredient(ItemID.SunplateBlock, 4)
                .AddIngredient(ItemID.StoneBlock, 4)
                .AddIngredient(ItemID.HallowedBar, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().eclipsePedestal = true;
            }
        }
    }
}
