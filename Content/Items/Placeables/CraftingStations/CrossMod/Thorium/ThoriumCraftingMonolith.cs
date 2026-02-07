using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Thorium;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.Thorium
{
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class ThoriumCraftingMonolith : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public new string LocalizationCategory => "Items.Placeables.CraftingStations";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ThoriumMonolithTile>());
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<BasicThoriumCraftingMonolith>());
            r.AddIngredient(Common.GetModItem(CrossModSupport.Thorium.Mod, "SoulForge"));
            r.AddIngredient(Common.GetModItem(CrossModSupport.Thorium.Mod, "GuidesFinalGift"));
            r.Register();
        }
    }
}
