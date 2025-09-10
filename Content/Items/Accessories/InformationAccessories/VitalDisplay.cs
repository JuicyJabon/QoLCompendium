using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using QoLCompendium.Core.UI.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories.InformationAccessories
{
    public class VitalDisplay : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.InformationAccessories;
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 16;
            Item.maxStack = 1;
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 6, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.InformationAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
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
