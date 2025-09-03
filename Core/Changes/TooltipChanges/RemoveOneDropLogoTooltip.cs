namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class RemoveOneDropLogoTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine oneDropLogo = tooltips.Find(l => l.Name == "OneDropLogo");
            if (QoLCompendium.tooltipConfig.NoYoyoTooltip) 
                tooltips.Remove(oneDropLogo);
        }
    }
}
