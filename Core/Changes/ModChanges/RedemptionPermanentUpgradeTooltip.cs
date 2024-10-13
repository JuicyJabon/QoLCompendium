using Redemption.BaseExtension;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod("Redemption")]
    [JITWhenModsEnabled("Redemption")]
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

            if (item.type == Common.GetModItem(ModConditions.redemptionMod, "GalaxyHeart") && Main.LocalPlayer.Redemption().galaxyHeart)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.redemptionMod, "MedicKit") && Main.LocalPlayer.Redemption().medKit)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
