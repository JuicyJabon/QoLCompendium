using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories.Construction
{
    public class ConstructionEmblem : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.ConstructionAccessories;

        public new string LocalizationCategory => "Items.Accessories.Construction";

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
            player.tileSpeed += 0.15f;
            player.wallSpeed += 0.15f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.ConstructionAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.ConstructionAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.DirtBlock, 50);
            r.AddIngredient(ItemID.StoneBlock, 50);
            r.AddIngredient(ItemID.ClayBlock, 50);
            r.AddIngredient(ItemID.SandBlock, 50);
            r.AddIngredient(ItemID.SnowBlock, 50);
            r.AddTile(TileID.HeavyWorkBench);
            r.Register();
        }
    }
}
