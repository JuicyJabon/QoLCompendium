using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.InformationAccessories
{
    public class VitalDisplay : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 16;
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
                .AddIngredient(ModContent.ItemType<MetallicClover>(), 1)
                .AddIngredient(ModContent.ItemType<Regenerator>(), 1)
                .AddIngredient(ModContent.ItemType<Replenisher>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().metallicClover = true;
            player.GetModPlayer<InfoPlayer>().regenerator = true;
            player.GetModPlayer<InfoPlayer>().replenisher = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().metallicClover = true;
            player.GetModPlayer<InfoPlayer>().regenerator = true;
            player.GetModPlayer<InfoPlayer>().replenisher = true;
        }
    }
}
