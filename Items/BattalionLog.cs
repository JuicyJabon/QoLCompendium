using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class BattalionLog : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 15;
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
                .AddIngredient(ItemID.BambooBlock, 4)
                .AddIngredient(ItemID.Wood, 2)
                .AddIngredient(ItemID.IronBar, 2)
                .AddTile(TileID.Loom)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
        }
    }
}
