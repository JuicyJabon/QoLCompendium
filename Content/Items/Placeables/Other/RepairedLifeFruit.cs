using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Other
{
    public class RepairedLifeFruit : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.RepairedLifeFruit;

        public new string LocalizationCategory => "Items.Placeables.Other";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(TileID.LifeFruit);

            Item.SetShopValues(ItemRarityColor.Lime7, Item.buyPrice(0, 10, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RepairedLifeFruit);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.RepairedLifeFruit, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.LifeFruit);
            r.AddTile(TileID.HeavyWorkBench);
            r.AddCondition(Condition.InGraveyard);
            r.Register();
        }
    }
}
