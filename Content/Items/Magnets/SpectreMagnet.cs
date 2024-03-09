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
            if (QoLCompendium.itemConfig.Magnets)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<ChlorophyteMagnet>())
                .AddIngredient(ItemID.SpectreBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            }
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
