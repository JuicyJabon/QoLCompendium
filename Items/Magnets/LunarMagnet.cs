using QoLCompendium.Tweaks;

namespace QoLCompendium.Items.Magnets
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
                .AddIngredient(ModContent.ItemType<SpookyMagnet>())
                .AddIngredient(ItemID.LunarBar, 4)
                .AddTile(TileID.Hellforge)
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
