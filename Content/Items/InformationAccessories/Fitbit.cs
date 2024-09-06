using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.InformationAccessories
{
    public class Fitbit : ModItem
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
            r.AddIngredient(ModContent.ItemType<Kettlebell>());
            r.AddIngredient(ModContent.ItemType<ReinforcedPanel>());
            r.AddIngredient(ModContent.ItemType<WingTimer>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetInfoPlayer().kettlebell = true;
            player.GetInfoPlayer().reinforcedPanel = true;
            player.GetInfoPlayer().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetInfoPlayer().kettlebell = true;
            player.GetInfoPlayer().reinforcedPanel = true;
            player.GetInfoPlayer().wingTimer = true;
        }
    }
}
