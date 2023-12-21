using QoLCompendium.UI;

namespace QoLCompendium.Items.InformationAccessories
{
    public class ToleranceDetector : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 10;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<HarmInducer>(), 1)
                .AddIngredient(ModContent.ItemType<LuckyDie>(), 1)
                .AddIngredient(ModContent.ItemType<PlateCracker>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().harmInducer = true;
            player.GetModPlayer<InfoPlayer>().luckyDie = true;
            player.GetModPlayer<InfoPlayer>().plateCracker = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().harmInducer = true;
            player.GetModPlayer<InfoPlayer>().luckyDie = true;
            player.GetModPlayer<InfoPlayer>().plateCracker = true;
        }
    }
}
