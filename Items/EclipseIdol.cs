using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class EclipseIdol : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 23;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().MoonPedestals)
            {
                CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 4)
                .AddIngredient(ItemID.Amber, 2)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().eclipseIdol = true;
            }
        }
    }
}
