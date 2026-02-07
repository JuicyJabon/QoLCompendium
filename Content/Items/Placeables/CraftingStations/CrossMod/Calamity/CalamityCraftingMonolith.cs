using CalamityMod.Items.Placeables.Furniture.CraftingStations;
using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Calamity;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class CalamityCraftingMonolith : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public new string LocalizationCategory => "Items.Placeables.CraftingStations";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CalamityMonolithTile>());
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<HardmodeCalamityCraftingMonolith>());
            r.AddIngredient(ModContent.ItemType<AltarOfTheAccursedItem>());
            r.AddIngredient(ModContent.ItemType<DraedonsForge>());
            r.AddIngredient(ModContent.ItemType<ProfanedCrucible>());
            r.Register();
        }
    }
}