using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.InformationAccessories
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
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<Kettlebell>(), 1)
                .AddIngredient(ModContent.ItemType<ReinforcedPanel>(), 1)
                .AddIngredient(ModContent.ItemType<WingTimer>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().kettlebell = true;
            player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            player.GetModPlayer<InfoPlayer>().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().kettlebell = true;
            player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            player.GetModPlayer<InfoPlayer>().wingTimer = true;
        }
    }
}
