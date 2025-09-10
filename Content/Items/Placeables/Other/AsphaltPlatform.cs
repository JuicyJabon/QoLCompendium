using QoLCompendium.Content.Tiles.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Other
{
    public class AsphaltPlatform : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.AsphaltPlatform;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 200;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AsphaltPlatformTile>());

            Item.SetShopValues(ItemRarityColor.White0, Item.buyPrice(0, 0, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.AsphaltPlatform);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.AsphaltPlatform, Type, 2, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.AsphaltBlock);
            r.Register();

            r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.AsphaltPlatform, ItemID.AsphaltBlock, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<AsphaltPlatform>(), 2);
            r.Register();
        }
    }
}
