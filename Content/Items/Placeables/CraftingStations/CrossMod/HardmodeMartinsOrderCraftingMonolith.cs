using QoLCompendium.Content.Tiles.CraftingStations.CrossMod;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class HardmodeMartinsOrderCraftingMonolith : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public new string LocalizationCategory => "Items.Placeables.CraftingStations";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HardmodeMartinsOrderMonolithTile>());
            Item.SetShopValues(ItemRarityColor.LightPurple6, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "AdvWorkBench"));
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "DemonAltar"));
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "FabricSewer"));
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "FactoryCentral"));
            r.Register();
        }
    }
}
