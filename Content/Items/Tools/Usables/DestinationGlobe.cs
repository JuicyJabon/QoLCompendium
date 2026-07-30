using QoLCompendium.Core.UI;
using QoLCompendium.Core.UI.Panels;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class DestinationGlobe : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.DestinationGlobe;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 2, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ItemUtils.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.DestinationGlobe);

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedBiomes.Length; i++)
            {
                if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedBiomes[i])
                {
                    TooltipLine biome = new(Mod, "QolCBiomeSelected" + i, Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Biome" + i));
                    biome.OverrideColor = Common.ColorSwap(Color.DimGray, Color.Silver, 3);
                    Common.AddLastTooltip(tooltips, biome);
                }
            }

            TooltipLine noSelection = new(Mod, "QolCNoBiomeSelection", Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Biome" + (int)UIEnums.BiomeTypes.NoSelection));
            noSelection.OverrideColor = Color.Red;
            TooltipLine selection = new(Mod, "QolCBiomeSelection", Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Selected"));
            selection.OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3);

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedBiomes.All(c => c == false))
                Common.AddLastTooltip(tooltips, noSelection);
            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedBiomes.Any(c => c == true))
                Common.AddLastTooltip(tooltips, selection);
        }

        public override bool? UseItem(Player player)
        {
            if (!DestinationGlobeUI.visible) 
                DestinationGlobeUI.timeStart = Main.GameUpdateCount;
            DestinationGlobeUI.visible = true;

            return base.UseItem(player);
        }

        public override bool CanUseItem(Player player)
        {
            if (DestinationGlobeUI.visible)
                return false;
            else
                return true;
        }

        public override void RightClick(Player player)
        {
            if (!DestinationGlobeUI.visible)
                DestinationGlobeUI.timeStart = Main.GameUpdateCount;
            DestinationGlobeUI.visible = !DestinationGlobeUI.visible;
        }

        public override bool CanRightClick() => true;
        public override bool ConsumeItem(Player player) => false;

        public override void AddRecipes()
        {
            Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.DestinationGlobe, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Glass, 15);
            r.AddIngredient(ItemID.DirtBlock, 5);
            r.AddIngredient(ItemID.GrassSeeds, 5);
            r.AddIngredient(ItemID.WaterBucket, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
