using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class TrackingDevice : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 13;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Ruby, 1)
                .AddIngredient(ItemID.IronBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().trackingDevice = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().trackingDevice = true;
        }
    }
}
