namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class ItemActiveTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ActiveTooltip) ActiveTooltip(item, tooltips);
        }

        public void ActiveTooltip(Item item, List<TooltipLine> tooltips)
        {
            var tooltipActive = new TooltipLine(Mod, "Active", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Active")) { OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3) };

            var tooltipActiveBuff = new TooltipLine(Mod, "ActiveBuff", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ActiveBuff")) { OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3) };

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeItems.Contains(item.type))
                Common.AddLastTooltip(tooltips, tooltipActive);
            else
                tooltips.Remove(tooltipActive);

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeBuffItems.Contains(item.type))
                Common.AddLastTooltip(tooltips, tooltipActiveBuff);
            else
                tooltips.Remove(tooltipActiveBuff);
        }
    }
}
