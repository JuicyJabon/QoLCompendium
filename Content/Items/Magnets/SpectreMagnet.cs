using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Magnets
{
    public class SpectreMagnet : ModItem
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
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 4);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type);
            r.AddIngredient(ModContent.ItemType<ChlorophyteMagnet>());
            r.AddIngredient(ItemID.SpectreBar, 10);
            r.Register();
            r.AddTile(TileID.MythrilAnvil);
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<MagnetPlayer>().SpectreMagnet = true;
            }
        }
    }
}
