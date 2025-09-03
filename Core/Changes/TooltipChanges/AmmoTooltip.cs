namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class AmmoTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.AmmoTooltip) UseAmmoTooltip(item, tooltips);
        }

        public void UseAmmoTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (item.useAmmo != AmmoID.None)
            {
                Item displayItem = new(item.useAmmo);
                var tooltipLine = new TooltipLine(Mod, "UseAmmo", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UseAmmo")) { Text = Common.GetTooltipValue("UseAmmo", item.useAmmo, displayItem.Name) };
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
