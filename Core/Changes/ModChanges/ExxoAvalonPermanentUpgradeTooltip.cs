using Avalon.Common.Players;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod(ModConditions.exxoAvalonOriginsName)]
    [JITWhenModsEnabled(ModConditions.exxoAvalonOriginsName)]
    public class ExxoAvalonPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "StaminaCrystal"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", (Main.LocalPlayer.GetModPlayer<AvalonStaminaPlayer>().StatStam / 30) - 1, 9);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "EnergyCrystal") && Main.LocalPlayer.GetModPlayer<AvalonStaminaPlayer>().EnergyCrystal)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
