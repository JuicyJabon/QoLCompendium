using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.MartinsOrder;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.MartinsOrder
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
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
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "AdvWorkBench"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "DemonAltar"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FabricSewer"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FactoryCentral"));
            r.Register();
        }
    }
}
