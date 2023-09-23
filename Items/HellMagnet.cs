using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class HellMagnet : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().Magnets)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<Magnet>())
                .AddIngredient(ItemID.HellstoneBar, 4)
                .AddTile(TileID.Hellforge)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<MagnetPlayer>().HellMagnet = true;
            }
        }
    }
}
