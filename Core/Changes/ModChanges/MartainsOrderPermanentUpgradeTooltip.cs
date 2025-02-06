﻿using MartainsOrder;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod("MartainsOrder")]
    [JITWhenModsEnabled("MartainsOrder")]
    public class MartainsOrderPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "FishOfPurity") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfPurity)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "FishOfSpirit") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfSpirit)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "FishOfWrath") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfWrath)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "ShimmerFish") && Main.LocalPlayer.GetModPlayer<MyPlayer>().shimmerFish)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "MerchantBag") && Main.LocalPlayer.GetModPlayer<MyPlayer>().shimmerMerchBag)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "FirstAidTreatments") && MartainWorld.firstAidTreatments)
            {
                TooltipChanges.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
