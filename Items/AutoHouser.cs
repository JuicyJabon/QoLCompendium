using QoLCompendium.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class AutoHouser : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 19;
            Item.maxStack = 9999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AutoHouserTile>();
            Item.value = Item.sellPrice(copper: 50);
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().AutoStructures)
            {
                CreateRecipe()
                .AddIngredient(ItemID.GrayBrick, 25)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
