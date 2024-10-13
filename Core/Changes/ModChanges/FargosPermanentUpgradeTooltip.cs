using FargowiltasSouls;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod("FargowiltasSouls")]
    [JITWhenModsEnabled("FargowiltasSouls")]
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

            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "DeerSinew") && Main.LocalPlayer.FargoSouls().DeerSinew)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsCreditCard") && Main.LocalPlayer.FargoSouls().MutantsCreditCard)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsDiscountCard") && Main.LocalPlayer.FargoSouls().MutantsDiscountCard)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsPact") && Main.LocalPlayer.FargoSouls().MutantsPactSlot)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "RabiesVaccine") && Main.LocalPlayer.FargoSouls().RabiesVaccine)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
