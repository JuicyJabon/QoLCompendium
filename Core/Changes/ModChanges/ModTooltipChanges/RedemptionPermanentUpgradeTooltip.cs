using Redemption.BaseExtension;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.Redemption.Name)]
    [JITWhenModsEnabled(CrossModSupport.Redemption.Name)]
    public class RedemptionPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(CrossModSupport.Redemption.Mod, "GalaxyHeart") && Main.LocalPlayer.Redemption().galaxyHeart)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.Redemption.Mod, "MedicKit") && Main.LocalPlayer.Redemption().medKit)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
