using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class RestockNotice : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 12;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 0, 50, 0));
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode is NetmodeID.SinglePlayer)
            {
                Chest.SetupTravelShop();
            }
            if (Main.netMode is NetmodeID.Server)
            {
                Chest.SetupTravelShop();
                NetMessage.SendTravelShop(Main.myPlayer);
            }

            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.RestockNotice, Type);
            r.AddIngredient(ItemID.Silk, 8);
            r.AddIngredient(ItemID.BlackDye, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
