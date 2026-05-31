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
                if (CrossModSupport.CalamityEntropy.Loaded)
                {
                    if (displayItem.type == ItemID.HoneyLantern && item.ModItem.Mod == CrossModSupport.CalamityEntropy.Mod)
                    {
                        displayItem = new(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "CharredMissile"));
                    }
                }

                var tooltipLine = new TooltipLine(Mod, "UseAmmo", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UseAmmo")) { Text = Common.GetTooltipValue("UseAmmo", displayItem.type, displayItem.Name) };
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
