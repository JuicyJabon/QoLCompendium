namespace QoLCompendium.Content.Items.Magnets
{
    public class LunarMagnet : ModItem
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
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 8);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.Magnets)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<SpectreMagnet>())
                .AddIngredient(ItemID.LunarBar, 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<MagnetPlayer>().LunarMagnet = true;
            }
        }
    }
}
