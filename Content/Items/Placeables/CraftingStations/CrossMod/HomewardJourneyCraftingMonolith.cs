using QoLCompendium.Content.Tiles.CraftingStations.CrossMod;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
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
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "FinalAnvil"));
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "HallowedAltar"));
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "FountainofLife"));
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "FountainofMatter"));
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "FountainofTime"));
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "ItemDeathWorkbench"));
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "ItemNothingnessWorkbench"));
            r.Register();
        }
    }
}
