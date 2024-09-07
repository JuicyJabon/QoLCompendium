using QoLCompendium.Core;

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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type);
            r.AddIngredient(ModContent.ItemType<SpectreMagnet>());
            r.AddIngredient(ItemID.LunarBar, 10);
            r.Register();
            r.AddTile(TileID.LunarCraftingStation);
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
