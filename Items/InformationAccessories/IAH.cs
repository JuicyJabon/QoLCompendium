using QoLCompendium.Tweaks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

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
            Item.width = 13;
            Item.height = 18;
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
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
            player.GetModPlayer<QoLCPlayer>().harmInducer = true;
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
            player.GetModPlayer<QoLCPlayer>().kettlebell = true;
            player.GetModPlayer<QoLCPlayer>().luckyDie = true;
            player.GetModPlayer<QoLCPlayer>().metallicClover = true;
            player.GetModPlayer<QoLCPlayer>().plateCracker = true;
            player.GetModPlayer<QoLCPlayer>().regenerator = true;
            player.GetModPlayer<QoLCPlayer>().reinforcedPanel = true;
            player.GetModPlayer<QoLCPlayer>().replenisher = true;
            player.GetModPlayer<QoLCPlayer>().trackingDevice = true;
            player.GetModPlayer<QoLCPlayer>().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
            player.GetModPlayer<QoLCPlayer>().harmInducer = true;
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
            player.GetModPlayer<QoLCPlayer>().kettlebell = true;
            player.GetModPlayer<QoLCPlayer>().luckyDie = true;
            player.GetModPlayer<QoLCPlayer>().metallicClover = true;
            player.GetModPlayer<QoLCPlayer>().plateCracker = true;
            player.GetModPlayer<QoLCPlayer>().regenerator = true;
            player.GetModPlayer<QoLCPlayer>().reinforcedPanel = true;
            player.GetModPlayer<QoLCPlayer>().replenisher = true;
            player.GetModPlayer<QoLCPlayer>().trackingDevice = true;
            player.GetModPlayer<QoLCPlayer>().wingTimer = true;
        }
    }
}
