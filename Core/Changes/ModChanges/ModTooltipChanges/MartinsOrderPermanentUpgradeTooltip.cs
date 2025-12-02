using MartainsOrder;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    public class MartinsOrderPermanentUpgradeTooltip : GlobalItem
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
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "FishOfSpirit") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfSpirit)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "FishOfWrath") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfWrath)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "ShimmerFish") && Main.LocalPlayer.GetModPlayer<MyPlayer>().shimmerFish)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "MerchantBag") && Main.LocalPlayer.GetModPlayer<MyPlayer>().shimmerMerchBag)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "FirstAidTreatments") && MartainWorld.firstAidTreatments)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.martainsOrderMod, "MartiniteBless") && MartainWorld.martiniteBless)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
