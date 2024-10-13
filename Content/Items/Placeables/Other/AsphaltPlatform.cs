using QoLCompendium.Content.Tiles.Other;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Other
{
    public class AsphaltPlatform : ModItem
    {
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
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.AsphaltPlatform);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.AsphaltPlatform, Type, 2, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.AsphaltBlock);
            r.Register();

            r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.AsphaltPlatform, ItemID.AsphaltBlock, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<AsphaltPlatform>(), 2);
            r.Register();
        }
    }
}
