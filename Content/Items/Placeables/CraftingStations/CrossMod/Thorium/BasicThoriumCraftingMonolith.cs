using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Thorium;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.Thorium
{
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class BasicThoriumCraftingMonolith : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public new string LocalizationCategory => "Items.Placeables.CraftingStations";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BasicThoriumMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.Thorium.Mod, "ThoriumAnvil"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.Thorium.Mod, "ArcaneArmorFabricator"));
            r.AddRecipeGroup("QoLCompendium:GrimPedestals");
            r.Register();
        }
    }
}
