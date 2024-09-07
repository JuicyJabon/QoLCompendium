using QoLCompendium.Core;
using QoLCompendium.Core.UI;

namespace QoLCompendium.Content.Items.InformationAccessories
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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type);
            r.AddIngredient(ModContent.ItemType<MetallicClover>());
            r.AddIngredient(ModContent.ItemType<Regenerator>());
            r.AddIngredient(ModContent.ItemType<Replenisher>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
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
