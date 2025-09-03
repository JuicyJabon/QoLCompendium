using Humanizer;

namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class FromModTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.FromModTooltip) ItemModTooltip(item, tooltips);
        }

        public static void ItemModTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem != null)
            {
                TooltipLine name = tooltips.Find(l => l.Name == "ItemName");
                var tooltipFromMod = new TooltipLine(QoLCompendium.instance, "FromMod", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.FromMod").FormatWith(item.ModItem.Mod.DisplayName)) { OverrideColor = Common.ColorSwap(Color.AliceBlue, Color.Azure, 1) };
                tooltips.AddAfter(name, tooltipFromMod);
            }
        }
    }
}
