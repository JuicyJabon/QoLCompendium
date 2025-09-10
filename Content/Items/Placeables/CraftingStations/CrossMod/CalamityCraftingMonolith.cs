using QoLCompendium.Content.Tiles.CraftingStations.CrossMod;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class CalamityCraftingMonolith : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

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
            r.AddIngredient(ModContent.ItemType<BasicCalamityCraftingMonolith>());
            r.AddIngredient(ModContent.ItemType<HardmodeCalamityCraftingMonolith>());
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "ProfanedCrucible"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "BotanicPlanter"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "SilvaBasin"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "AltarOfTheAccursedItem"));
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "DraedonsForge"));
            r.Register();
        }
    }
}