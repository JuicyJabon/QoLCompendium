using FargowiltasSouls;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.FargowiltasSouls.Name)]
    [JITWhenModsEnabled(CrossModSupport.FargowiltasSouls.Name)]
    public class FargosPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(CrossModSupport.FargowiltasSouls.Mod, "DeerSinew") && Main.LocalPlayer.FargoSouls().DeerSinew)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MutantsCreditCard") && Main.LocalPlayer.FargoSouls().MutantsCreditCard)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MutantsDiscountCard") && Main.LocalPlayer.FargoSouls().MutantsDiscountCard)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MutantsPact") && Main.LocalPlayer.FargoSouls().MutantsPactSlot)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.FargowiltasSouls.Mod, "RabiesVaccine") && Main.LocalPlayer.FargoSouls().RabiesVaccine)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
