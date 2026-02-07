using MartainsOrder;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
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

            if (item.type == Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FishOfPurity") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfPurity)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FishOfSpirit") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfSpirit)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FishOfWrath") && Main.LocalPlayer.GetModPlayer<MyPlayer>().fishOfWrath)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ShimmerFish") && Main.LocalPlayer.GetModPlayer<MyPlayer>().shimmerFish)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "MerchantBag") && Main.LocalPlayer.GetModPlayer<MyPlayer>().shimmerMerchBag)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FirstAidTreatments") && MartainWorld.firstAidTreatments)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "MartiniteBless") && MartainWorld.martiniteBless)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
