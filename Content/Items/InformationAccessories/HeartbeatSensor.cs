using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.InformationAccessories
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
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 6, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type);
            r.AddIngredient(ModContent.ItemType<BattalionLog>());
            r.AddIngredient(ModContent.ItemType<HeadCounter>());
            r.AddIngredient(ModContent.ItemType<TrackingDevice>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetInfoPlayer().battalionLog = true;
            player.GetInfoPlayer().headCounter = true;
            player.GetInfoPlayer().trackingDevice = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetInfoPlayer().battalionLog = true;
            player.GetInfoPlayer().headCounter = true;
            player.GetInfoPlayer().trackingDevice = true;
        }
    }
}
