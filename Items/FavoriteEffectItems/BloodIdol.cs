using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.FavoriteEffectItems
{
    public class BloodIdol : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 23;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.MoonPedestals)
            {
                CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 5)
                .AddIngredient(ItemID.Ruby, 2)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().bloodIdol = true;
            }
        }
    }
}
