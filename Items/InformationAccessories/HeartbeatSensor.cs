using QoLCompendium.UI;

namespace QoLCompendium.Items.InformationAccessories
{
    public class HeartbeatSensor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 12;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<BattalionLog>(), 1)
                .AddIngredient(ModContent.ItemType<HeadCounter>(), 1)
                .AddIngredient(ModContent.ItemType<TrackingDevice>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().battalionLog = true;
            player.GetModPlayer<InfoPlayer>().headCounter = true;
            player.GetModPlayer<InfoPlayer>().trackingDevice = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().battalionLog = true;
            player.GetModPlayer<InfoPlayer>().headCounter = true;
            player.GetModPlayer<InfoPlayer>().trackingDevice = true;
        }
    }
}
