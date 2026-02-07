using ContinentOfJourney.Items;
using ContinentOfJourney.Items.Accessories.PermanentUpgradesSystem;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    public class HomewardJourneyPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            #region Coffee
            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "Americano") && Main.LocalPlayer.GetModPlayer<CoffeePlayer>().Americano > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "Latte") && Main.LocalPlayer.GetModPlayer<CoffeePlayer>().Latte > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "Mocha") && Main.LocalPlayer.GetModPlayer<CoffeePlayer>().Mocha > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "Cappuccino") && Main.LocalPlayer.GetModPlayer<CoffeePlayer>().Cappuccino > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);
            #endregion

            #region Other Upgrades
            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "AirHandcanon") && Main.LocalPlayer.GetModPlayer<OtherUpgradesPlayer>().AirHandcanon > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "HotCase") && Main.LocalPlayer.GetModPlayer<OtherUpgradesPlayer>().HotCase > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "GreatCrystal") && Main.LocalPlayer.GetModPlayer<OtherUpgradesPlayer>().GreatCrystal > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "WhimInABottle") && Main.LocalPlayer.GetModPlayer<OtherUpgradesPlayer>().WhimInABottle > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);
            
            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "SunsHeart") && Main.LocalPlayer.GetModPlayer<OtherUpgradesPlayer>().SunsHeart > 0)
                Common.AddLastTooltip(tooltips, tooltipLine);

            if (item.type == Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "TheSwitch") && Main.LocalPlayer.GetModPlayer<PermanentUpgradesPlayer>().PermanentUpgradesActivated[0] && Main.LocalPlayer.GetModPlayer<PermanentUpgradesPlayer>().PermanentUpgradesActivated[1])
                Common.AddLastTooltip(tooltips, tooltipLine);
            #endregion
        }
    }
}
