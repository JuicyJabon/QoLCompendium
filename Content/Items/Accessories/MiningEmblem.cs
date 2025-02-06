using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories
{
    public class MiningEmblem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 14;
            Item.maxStack = 1;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.pickSpeed -= 0.15f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.ConstructionAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.ConstructionAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.CopperBar, 5);
            r.AddIngredient(ItemID.TinBar, 5);
            r.AddIngredient(ItemID.IronBar, 5);
            r.AddIngredient(ItemID.LeadBar, 5);
            r.AddIngredient(ItemID.SilverBar, 5);
            r.AddIngredient(ItemID.TungstenBar, 5);
            r.AddIngredient(ItemID.GoldBar, 5);
            r.AddIngredient(ItemID.PlatinumBar, 5);
            r.AddTile(TileID.HeavyWorkBench);
            r.Register();
        }
    }
}
