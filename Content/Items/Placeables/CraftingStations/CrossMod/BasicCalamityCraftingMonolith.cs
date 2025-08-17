using QoLCompendium.Content.Tiles.CraftingStations.CrossMod;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class BasicCalamityCraftingMonolith : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BasicCalamityMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "WulfrumLabstationItem"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "EutrophicShelf"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "StaticRefiner"));
            r.Register();
        }
    }
}