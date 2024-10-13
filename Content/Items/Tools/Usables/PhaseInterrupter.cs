using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using QoLCompendium.Core.UI.Panels;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class PhaseInterrupter : ModItem
    {
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
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PhaseInterrupter);
        }

        public override void UpdateInventory(Player player)
        {
            if (Main.moonPhase == 0)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.FullMoon"));

            if (Main.moonPhase == 1)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.WaningGibbous"));

            if (Main.moonPhase == 2)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.ThirdQuarter"));

            if (Main.moonPhase == 3)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.WaningCrescent"));

            if (Main.moonPhase == 4)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.NewMoon"));

            if (Main.moonPhase == 5)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.WaxingCrescent"));

            if (Main.moonPhase == 6)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.FirstQuarter"));

            if (Main.moonPhase == 7)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PhaseInterrupter.WaxingGibbous"));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PhaseInterrupter, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
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
