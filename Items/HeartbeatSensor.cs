using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class HeartbeatSensor : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 12;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<HeartbeatSensor>(), 1).AddIngredient(ModContent.ItemType<BattalionLog>()).AddIngredient(ModContent.ItemType<HeadCounter>()).AddIngredient(ModContent.ItemType<TrackingDevice>()).AddTile(TileID.TinkerersWorkbench).Register();
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
            player.GetModPlayer<QoLCPlayer>().trackingDevice = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
            player.GetModPlayer<QoLCPlayer>().trackingDevice = true;
        }
    }
}
