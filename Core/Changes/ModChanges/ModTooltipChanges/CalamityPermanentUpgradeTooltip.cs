namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    public class CalamityPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem")) { OverrideColor = Color.LightGreen };

            //Countable Upgrades
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "EnchantedStarfish"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedManaCrystals, 9);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}