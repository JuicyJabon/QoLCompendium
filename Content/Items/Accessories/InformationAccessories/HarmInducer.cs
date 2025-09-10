using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using QoLCompendium.Core.UI.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories.InformationAccessories
{
    public class HarmInducer : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.InformationAccessories;
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 17;
            Item.maxStack = 1;
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 3, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.InformationAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Wood, 12);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 6);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().harmInducer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().harmInducer = true;
        }
    }
}
