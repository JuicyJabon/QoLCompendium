using Split;
using Split.Bosses;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    public class SplitPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(CrossModSupport.Split.Mod, "OverloadingCrystal") && Main.LocalPlayer.SplitPlayer().usedOverloadingCrystal)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }

            if (item.type == Common.GetModItem(CrossModSupport.Split.Mod, "TinyTinyCrystalHeart") && WorldFlagsSystem.BuffedGenoshi)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
