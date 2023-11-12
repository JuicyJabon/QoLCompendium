using QoLCompendium.Tweaks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using QoLCompendium.UI;

namespace QoLCompendium.Items.InformationAccessories
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
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 9);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<Fitbit>(), 1)
                .AddIngredient(ModContent.ItemType<HeartbeatSensor>(), 1)
                .AddIngredient(ModContent.ItemType<ToleranceDetector>(), 1)
                .AddIngredient(ModContent.ItemType<VitalDisplay>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().battalionLog = true;
            player.GetModPlayer<InfoPlayer>().harmInducer = true;
            player.GetModPlayer<InfoPlayer>().headCounter = true;
            player.GetModPlayer<InfoPlayer>().kettlebell = true;
            player.GetModPlayer<InfoPlayer>().luckyDie = true;
            player.GetModPlayer<InfoPlayer>().metallicClover = true;
            player.GetModPlayer<InfoPlayer>().plateCracker = true;
            player.GetModPlayer<InfoPlayer>().regenerator = true;
            player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            player.GetModPlayer<InfoPlayer>().replenisher = true;
            player.GetModPlayer<InfoPlayer>().trackingDevice = true;
            player.GetModPlayer<InfoPlayer>().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().battalionLog = true;
            player.GetModPlayer<InfoPlayer>().harmInducer = true;
            player.GetModPlayer<InfoPlayer>().headCounter = true;
            player.GetModPlayer<InfoPlayer>().kettlebell = true;
            player.GetModPlayer<InfoPlayer>().luckyDie = true;
            player.GetModPlayer<InfoPlayer>().metallicClover = true;
            player.GetModPlayer<InfoPlayer>().plateCracker = true;
            player.GetModPlayer<InfoPlayer>().regenerator = true;
            player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            player.GetModPlayer<InfoPlayer>().replenisher = true;
            player.GetModPlayer<InfoPlayer>().trackingDevice = true;
            player.GetModPlayer<InfoPlayer>().wingTimer = true;
        }
    }
}
