using Terraria.GameContent.Creative;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class UltimateChecklist : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Gray;
            Item.UseSound = new SoundStyle?(SoundID.Item29);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < ItemLoader.ItemCount; i++)
            {
                CreativeUI.ResearchItem(i);
            }
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.UltimateChecklist)
            {
                CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 12)
                .AddIngredient(ItemID.Silk, 6)
                .AddIngredient(ItemID.BlackInk, 1)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            }
        }
    }
}
