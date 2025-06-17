﻿using ThoriumMod.Utilities;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod("ThoriumMod")]
    [JITWhenModsEnabled("ThoriumMod")]
    public class ThoriumPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "CrystalWave"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.GetThoriumPlayer().consumedCrystalWaveCount, 5);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "AstralWave") && Main.LocalPlayer.GetThoriumPlayer().consumedAstralWave)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationGem") && Main.LocalPlayer.GetThoriumPlayer().consumedInspirationGem)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            int bardResourceMax = (int)ModConditions.thoriumMod.Call("GetBardInspirationMax", Main.LocalPlayer);
            int fragmentMax = 10;
            int shardMax = 20;
            int crystalMax = 30;
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationFragment"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - fragmentMax, 0), 0, 10), 10);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationShard"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - shardMax, 0), 0, 10), 10);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationCrystalNew"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - crystalMax, 0), 0, 10), 10);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
