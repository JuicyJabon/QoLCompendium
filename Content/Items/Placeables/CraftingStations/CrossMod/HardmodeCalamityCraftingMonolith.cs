using QoLCompendium.Content.Tiles.CraftingStations.CrossMod;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class HardmodeCalamityCraftingMonolith : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HardmodeCalamityMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Yellow8, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "AncientAltar"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "AshenAltar"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "MonolithAmalgam"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "PlagueInfuser"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "VoidCondenser"));
            r.Register();
        }
    }
}