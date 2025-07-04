﻿using Aequus;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod("Aequus")]
    [JITWhenModsEnabled("Aequus")]
    public class AequusPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(ModConditions.aequusMod, "CosmicChest") && Main.LocalPlayer.Aequus().usedPermaLootLuck)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "TinkerersGuidebook") && AequusWorld.UsedTinkererBook)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "MoneyTrashcan") && Main.LocalPlayer.Aequus().usedPermaTrashMoney)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "VictorsReward") && Main.LocalPlayer.Aequus().maxLifeRespawnReward)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
