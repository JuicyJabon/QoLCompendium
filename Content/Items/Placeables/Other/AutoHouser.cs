using QoLCompendium.Content.Tiles.AutoStructures;

namespace QoLCompendium.Content.Items.Placeables.Other
{
    public class AutoHouser : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 19;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.consumable = false;
            Item.createTile = ModContent.TileType<AutoHouserTile>();
            Item.value = Item.sellPrice(copper: 50);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.AutoStructures)
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
