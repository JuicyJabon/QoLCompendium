using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories
{
    public class SonarDevice : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 15;
            Item.maxStack = 1;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.sonarPotion = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.FishingAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.FishingAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddIngredient(ItemID.SonarPotion, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
