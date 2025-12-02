namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(ModConditions.ragnarokName)]
    [JITWhenModsEnabled(ModConditions.ragnarokName)]
    public class RagnarokPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"))
            {
                OverrideColor = Color.LightGreen
            };

            int bardResourceMax = (int)ModConditions.thoriumMod.Call("GetBardInspirationMax", Main.LocalPlayer);
            int essenceMax = 40;
            if (item.type == Common.GetModItem(ModConditions.ragnarokMod, "InspirationEssence"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - essenceMax, 0), 0, 10), 10);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
