using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.InformationAccessories
{
    public class IAH : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 14;
            Item.maxStack = 1;
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Pink5, Item.buyPrice(0, 9, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type);
            r.AddIngredient(ModContent.ItemType<Fitbit>());
            r.AddIngredient(ModContent.ItemType<HeartbeatSensor>());
            r.AddIngredient(ModContent.ItemType<ToleranceDetector>());
            r.AddIngredient(ModContent.ItemType<VitalDisplay>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetInfoPlayer().battalionLog = true;
            player.GetInfoPlayer().harmInducer = true;
            player.GetInfoPlayer().headCounter = true;
            player.GetInfoPlayer().kettlebell = true;
            player.GetInfoPlayer().luckyDie = true;
            player.GetInfoPlayer().metallicClover = true;
            player.GetInfoPlayer().plateCracker = true;
            player.GetInfoPlayer().regenerator = true;
            player.GetInfoPlayer().reinforcedPanel = true;
            player.GetInfoPlayer().replenisher = true;
            player.GetInfoPlayer().trackingDevice = true;
            player.GetInfoPlayer().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetInfoPlayer().battalionLog = true;
            player.GetInfoPlayer().harmInducer = true;
            player.GetInfoPlayer().headCounter = true;
            player.GetInfoPlayer().kettlebell = true;
            player.GetInfoPlayer().luckyDie = true;
            player.GetInfoPlayer().metallicClover = true;
            player.GetInfoPlayer().plateCracker = true;
            player.GetInfoPlayer().regenerator = true;
            player.GetInfoPlayer().reinforcedPanel = true;
            player.GetInfoPlayer().replenisher = true;
            player.GetInfoPlayer().trackingDevice = true;
            player.GetInfoPlayer().wingTimer = true;
        }
    }
}
