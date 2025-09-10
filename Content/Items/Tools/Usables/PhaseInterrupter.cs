using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using QoLCompendium.Core.UI.Panels;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class PhaseInterrupter : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.PhaseInterrupter;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 7;
            Item.height = 18;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 0, 90, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PhaseInterrupter);
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.Moon" + Main.moonPhase.ToString()));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PhaseInterrupter, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 7);
            r.AddIngredient(ItemID.Diamond, 3);
            r.AddIngredient(ItemID.BlackLens, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override bool? UseItem(Player player)
        {
            if (!PhaseInterrupterUI.visible) PhaseInterrupterUI.timeStart = Main.GameUpdateCount;
            PhaseInterrupterUI.visible = true;

            return base.UseItem(player);
        }
    }
}
