using CalamityMod;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod(ModConditions.calamityName)]
    [JITWhenModsEnabled(ModConditions.calamityName)]
    public class CalamityPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem")) { OverrideColor = Color.LightGreen };

            //Mana
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "EnchantedStarfish"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedManaCrystals, 9);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            //Rage
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "MushroomPlasmaRoot") && Main.LocalPlayer.Calamity().rageBoostOne)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "InfernalBlood") && Main.LocalPlayer.Calamity().rageBoostTwo)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "RedLightningContainer") && Main.LocalPlayer.Calamity().rageBoostThree)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            //Adrenaline
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "ElectrolyteGelPack") && Main.LocalPlayer.Calamity().adrenalineBoostOne)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "StarlightFuelCell") && Main.LocalPlayer.Calamity().adrenalineBoostTwo)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "Ectoheart") && Main.LocalPlayer.Calamity().adrenalineBoostThree)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            //Accessory
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "CelestialOnion") && Main.LocalPlayer.Calamity().extraAccessoryML)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
