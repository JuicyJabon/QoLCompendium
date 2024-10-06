using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Magnets
{
    public class HellstoneMagnet : ModItem
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

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 2, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type);
            r.AddIngredient(ModContent.ItemType<Magnet>());
            r.AddIngredient(ItemID.HellstoneBar, 10);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<MagnetPlayer>().HellstoneMagnet = true;
            }
        }
    }
}
