using QoLCompendium.Content.Tiles.CraftingStations.CrossMod;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class BasicMartinsOrderCraftingMonolith : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public new string LocalizationCategory => "Items.Placeables.CraftingStations";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BasicMartinsOrderMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.FireflyinaBottle);
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "ArcheologyTable"));
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "SporeFarm"));
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "MartianBrewer"));
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "Processor"));
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "SturdyAnvil"));
            r.Register();
        }
    }
}
