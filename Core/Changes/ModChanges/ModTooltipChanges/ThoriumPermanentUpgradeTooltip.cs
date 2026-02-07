using ThoriumMod.Utilities;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
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

            if (item.type == Common.GetModItem(CrossModSupport.Thorium.Mod, "CrystalWave"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.GetThoriumPlayer().consumedCrystalWaveCount, 5);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.Thorium.Mod, "AstralWave") && Main.LocalPlayer.GetThoriumPlayer().consumedAstralWave)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.Thorium.Mod, "InspirationGem") && Main.LocalPlayer.GetThoriumPlayer().consumedInspirationGem)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            int bardResourceMax = (int)CrossModSupport.Thorium.Mod.Call("GetBardInspirationMax", Main.LocalPlayer);
            int fragmentMax = 10;
            int shardMax = 20;
            int crystalMax = 30;
            if (item.type == Common.GetModItem(CrossModSupport.Thorium.Mod, "InspirationFragment"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - fragmentMax, 0), 0, 10), 10);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.Thorium.Mod, "InspirationShard"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - shardMax, 0), 0, 10), 10);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(CrossModSupport.Thorium.Mod, "InspirationCrystalNew"))
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - crystalMax, 0), 0, 10), 10);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
