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
            Item.width = 12;
            Item.height = 20;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MoonPedestals, Type);
            r.AddIngredient(ItemID.GrayBrick, 10);
            r.AddIngredient(ItemID.StoneBlock, 4);
            r.AddIngredient(ItemID.SunplateBlock, 4);
            r.AddIngredient(ItemID.HallowedBar, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
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
