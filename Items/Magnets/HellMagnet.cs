using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.Magnets
{
    public class HellMagnet : ModItem
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
            if (QoLCompendium.itemConfig.Magnets)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<Magnet>())
                .AddIngredient(ItemID.Hellstone, 2)
                .AddIngredient(ItemID.AshWood, 4)
                .AddTile(TileID.Hellforge)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<MagnetPlayer>().HellMagnet = true;
            }
        }
    }
}
