using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class BannerBox : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.BannerBox;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 11;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 0, 20, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.BannerBox);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BannerBox, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Wood, 12);
            r.AddIngredient(ItemID.Silk, 2);
            r.AddTile(TileID.Loom);
            r.Register();
        }
    }
}
