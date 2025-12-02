using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories.Fishing
{
    public class DuplicationBobber : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.FishingAccessories;

        public new string LocalizationCategory => "Items.Accessories.Fishing";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.maxStack = 1;
            Item.accessory = true;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 3, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.FishingAccessories);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().duplicationBobber = true;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.FishingAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddIngredient(ItemID.Diamond, 3);
            r.AddIngredient(ItemID.Bass, 2);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
