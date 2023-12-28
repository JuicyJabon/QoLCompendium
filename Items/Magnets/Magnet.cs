using QoLCompendium.Tweaks;

namespace QoLCompendium.Items.Magnets
{
    public class Magnet : ModItem
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
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.Magnets)
            {
                CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 6)
                .AddIngredient(ItemID.Sapphire, 1)
                .AddIngredient(ItemID.Ruby, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<MagnetPlayer>().BaseMagnet = true;
            }
        }
    }
}