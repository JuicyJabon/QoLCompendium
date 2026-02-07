using SOTS.Void;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(CrossModSupport.SecretsOfTheShadows.Name)]
    public class SOTSPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(Main.LocalPlayer);
            if (item.type == Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "ScarletStar") && voidPlayer.voidStar > 0)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "VioletStar") && voidPlayer.voidStar > 0)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "SoulHeart") && voidPlayer.voidSoul > 0)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "VoidenAnkh"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", voidPlayer.voidAnkh, 5);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
