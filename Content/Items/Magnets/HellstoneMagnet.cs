using QoLCompendium.Core;

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
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type);
            r.AddIngredient(ModContent.ItemType<Magnet>());
            r.AddIngredient(ItemID.HellstoneBar, 10);
            r.Register();
            r.AddTile(TileID.Anvils);
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
