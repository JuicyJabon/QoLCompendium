using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class HardmodeCraftingMonolith : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HardmodeMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Pink5, Item.buyPrice(0, 10, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup("QoLCompendium:HardmodeAnvils");
            r.AddRecipeGroup("QoLCompendium:HardmodeForges");
            r.AddRecipeGroup("QoLCompendium:AnyBookcase");
            r.AddIngredient(ItemID.CrystalBall);
            r.AddIngredient(ItemID.FleshCloningVaat);
            r.AddIngredient(ItemID.LesionStation);
            r.AddIngredient(ItemID.SteampunkBoiler);
            r.AddIngredient(ItemID.BlendOMatic);
            r.AddIngredient(ItemID.MeatGrinder);
            r.Register();
        }
    }
}
