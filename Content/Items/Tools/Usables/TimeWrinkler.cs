using QoLCompendium.Core.UI.Panels;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class TimeWrinkler : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.TimeWrinkler;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item29;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.LightRed4, Item.buyPrice(0, 4, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ItemUtils.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.TimeWrinkler);

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators.Length; i++)
            {
                if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators[i])
                {
                    TooltipLine time = new(Mod, "QolCTimeManipulatorSelected" + i, Language.GetTextValue("Mods.QoLCompendium.ItemNames.TimeWrinkler.Time" + i));
                    time.OverrideColor = Common.ColorSwap(Color.DimGray, Color.Silver, 3);
                    Common.AddLastTooltip(tooltips, time);
                }
            }

            TooltipLine noSelection = new(Mod, "QolCNoTimeManipulatorSelected", Language.GetTextValue("Mods.QoLCompendium.ItemNames.TimeWrinkler.Time5"));
            noSelection.OverrideColor = Color.Red;
            TooltipLine selection = new(Mod, "QolCTimeManipulatorSelection", Language.GetTextValue("Mods.QoLCompendium.ItemNames.TimeWrinkler.Selected"));
            selection.OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3);

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators.All(c => c == false))
                Common.AddLastTooltip(tooltips, noSelection);
            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators.Any(c => c == true))
                Common.AddLastTooltip(tooltips, selection);
        }

        public override bool? UseItem(Player player)
        {
            if (!TimeWrinklerUI.visible)
                TimeWrinklerUI.timeStart = Main.GameUpdateCount;
            TimeWrinklerUI.visible = true;

            return base.UseItem(player);
        }

        public override void RightClick(Player player)
        {
            if (!TimeWrinklerUI.visible)
                TimeWrinklerUI.timeStart = Main.GameUpdateCount;
            TimeWrinklerUI.visible = !TimeWrinklerUI.visible;
        }

        public override bool CanRightClick() => true;
        public override bool ConsumeItem(Player player) => false;

        public override void AddRecipes()
        {
            Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.TimeWrinkler, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup("QoLCompendium:GoldBars", 12);
            r.AddIngredient(ItemID.Glass, 8);
            r.AddIngredient(ItemID.PixieDust, 10);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
