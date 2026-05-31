using TerrorbornMod;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.Terrorborn.Name)]
    [JITWhenModsEnabled(CrossModSupport.Terrorborn.Name)]
    public class TerrorbornPermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;

            TerrorbornPlayer modPlayer = TerrorbornPlayer.modPlayer(Main.LocalPlayer);
            if (item.type == Common.GetModItem(CrossModSupport.Terrorborn.Mod, "AnekronianApple") && modPlayer.AnekronianApple)
                Common.AddLastTooltip(tooltips, tooltipLine);
            if (item.type == Common.GetModItem(CrossModSupport.Terrorborn.Mod, "CoreOfFear") && modPlayer.CoreOfFear)
                Common.AddLastTooltip(tooltips, tooltipLine);
            if (item.type == Common.GetModItem(CrossModSupport.Terrorborn.Mod, "DemonicLense") && modPlayer.DemonicLense)
                Common.AddLastTooltip(tooltips, tooltipLine);
            if (item.type == Common.GetModItem(CrossModSupport.Terrorborn.Mod, "GoldenTooth") && modPlayer.GoldenTooth)
                Common.AddLastTooltip(tooltips, tooltipLine);
            if (item.type == Common.GetModItem(CrossModSupport.Terrorborn.Mod, "EyeOfTheMenace") && modPlayer.EyeOfTheMenace)
                Common.AddLastTooltip(tooltips, tooltipLine);
        }
    }
}
