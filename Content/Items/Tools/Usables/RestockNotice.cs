using QoLCompendium.Core;

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
            Item.width = 19;
            Item.height = 18;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = new SoundStyle?(SoundID.Item4);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(gold: 2);
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
            r.AddIngredient(ItemID.BlackInk, 1);
            r.AddIngredient(ItemID.Feather, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
