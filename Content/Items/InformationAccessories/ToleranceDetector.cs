using QoLCompendium.Core;
using QoLCompendium.Core.UI.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.InformationAccessories
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
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 6, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type);
            r.AddIngredient(ModContent.ItemType<HarmInducer>());
            r.AddIngredient(ModContent.ItemType<LuckyDie>());
            r.AddIngredient(ModContent.ItemType<PlateCracker>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
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
