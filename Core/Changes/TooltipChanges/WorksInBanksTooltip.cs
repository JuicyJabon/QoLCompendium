namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class WorksInBanksTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.WorksInBanksTooltip && QoLCompendium.mainConfig.UtilityAccessoriesWorkInBanks) WorksInBankTooltip(item, tooltips);
        }

        public void WorksInBankTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (!Common.BankItems.Contains(item.type))
                return;

            var tooltipLine = new TooltipLine(Mod, "WorksInBanks", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.WorksInBanks")) { OverrideColor = Color.Gray };
            Common.AddLastTooltip(tooltips, tooltipLine);
        }
    }
}
