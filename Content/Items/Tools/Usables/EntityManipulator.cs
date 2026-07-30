using QoLCompendium.Core.UI;
using QoLCompendium.Core.UI.Panels;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class EntityManipulator : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.EntityManipulator;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ItemUtils.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EntityManipulator);

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnRateManipulators.Length; i++)
            {
                if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnRateManipulators[i])
                {
                    TooltipLine manipulator = new(Mod, "QolCSpawnManipulatorSelected" + i, Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.SpawnManipulator" + i));
                    manipulator.OverrideColor = Common.ColorSwap(Color.DimGray, Color.Silver, 3);
                    Common.AddLastTooltip(tooltips, manipulator);
                }
            }

            TooltipLine noSelection = new(Mod, "QolCNoSpawnSelection", Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.SpawnManipulator" + (int)UIEnums.SpawnRateManipulators.NoSelection));
            noSelection.OverrideColor = Color.Red;
            TooltipLine selection = new(Mod, "QolCSpawnSelection", Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.Selected"));
            selection.OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3);

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnRateManipulators.All(c => c == false))
                Common.AddLastTooltip(tooltips, noSelection);
            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnRateManipulators.Any(c => c == true))
                Common.AddLastTooltip(tooltips, selection);
        }

        public override bool? UseItem(Player player)
        {
            if (!EntityManipulatorUI.visible) 
                EntityManipulatorUI.timeStart = Main.GameUpdateCount;
            EntityManipulatorUI.visible = true;

            return base.UseItem(player);
        }

        public override void RightClick(Player player)
        {
            if (!EntityManipulatorUI.visible)
                EntityManipulatorUI.timeStart = Main.GameUpdateCount;
            EntityManipulatorUI.visible = !EntityManipulatorUI.visible;
        }

        public override bool CanRightClick() => true;
        public override bool ConsumeItem(Player player) => false;

        public override void AddRecipes()
        {
            Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.EntityManipulator, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.BattlePotion, 10);
            r.AddIngredient(ItemID.WaterCandle, 3);
            r.AddIngredient(ItemID.CalmingPotion, 10);
            r.AddIngredient(ItemID.PeaceCandle, 3);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
