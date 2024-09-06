using QoLCompendium.Core;
using Terraria.Enums;

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

            Item.SetShopValues(ItemRarityColor.Yellow8, Item.buyPrice(0, 4, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type);
            r.AddIngredient(ModContent.ItemType<SoulMagnet>());
            r.AddIngredient(ItemID.SpectreBar, 10);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetMagnetPlayer().SpectreMagnet = true;
            }
        }
    }
}
