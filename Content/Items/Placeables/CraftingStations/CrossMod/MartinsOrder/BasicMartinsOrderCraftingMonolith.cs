using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.MartinsOrder;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.MartinsOrder
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
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
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ArcheologyTable"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "SporeFarm"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "MartianBrewer"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "Processor"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "SturdyAnvil"));
            r.Register();
        }
    }
}
