using ClickerClass;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod("ClickerClass")]
    [JITWhenModsEnabled("ClickerClass")]
    public class ClickerPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(ModConditions.clickerClassMod, "HeavenlyChip") && Main.LocalPlayer.GetModPlayer<ClickerPlayer>().consumedHeavenlyChip)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
