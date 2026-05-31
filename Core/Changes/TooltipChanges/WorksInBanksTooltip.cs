namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class WorksInBanksTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if ((QoLCompendium.tooltipConfig.WorksInBanksTooltip && QoLCompendium.mainConfig.UtilityAccessoriesWorkInBanks) || (QoLCompendium.tooltipConfig.WorksInBanksTooltip && QoLCompendium.crossModConfig.ElementsAwokenBatteriesInBanks)) 
                WorksInBankTooltip(item, tooltips);
        }

        public void WorksInBankTooltip(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "WorksInBanks", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.WorksInBanks")) { OverrideColor = Color.Gray };

            if (Constants.BankItems.Contains(item.type))
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (Constants.ElementsAwokenBatteryItems.Contains(item.type))
                Common.AddLastTooltip(tooltips, tooltipLine);
        }
    }
}
