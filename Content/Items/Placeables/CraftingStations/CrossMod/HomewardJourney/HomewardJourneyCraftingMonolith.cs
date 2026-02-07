using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.HomewardJourney;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.HomewardJourney
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class HomewardJourneyCraftingMonolith : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public new string LocalizationCategory => "Items.Placeables.CraftingStations";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HomewardJourneyMonolithTile>());
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<BasicHomewardJourneyCraftingMonolith>());
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FinalAnvil"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "HallowedAltar"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FountainofLife"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FountainofMatter"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FountainofTime"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "ItemDeathWorkbench"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "ItemNothingnessWorkbench"));
            r.Register();
        }
    }
}
