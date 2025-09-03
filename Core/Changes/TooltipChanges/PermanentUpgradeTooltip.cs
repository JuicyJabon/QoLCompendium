namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class PermanentUpgradeTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem")) { OverrideColor = Color.LightGreen };

            //Countable Upgrades
            if (item.type == ItemID.LifeCrystal)
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedLifeCrystals, 15);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.LifeFruit)
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedLifeFruit, 20);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ManaCrystal)
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedManaCrystals, 9);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            //Upgrades
            if (item.type == ItemID.AegisCrystal && Main.LocalPlayer.usedAegisCrystal)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ArcaneCrystal && Main.LocalPlayer.usedArcaneCrystal)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.AegisFruit && Main.LocalPlayer.usedAegisFruit)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.Ambrosia && Main.LocalPlayer.usedAmbrosia)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.GummyWorm && Main.LocalPlayer.usedGummyWorm)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.GalaxyPearl && Main.LocalPlayer.usedGalaxyPearl)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.PeddlersSatchel && NPC.peddlersSatchelWasUsed)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ArtisanLoaf && Main.LocalPlayer.ateArtisanBread)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.CombatBook && NPC.combatBookWasUsed)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.CombatBookVolumeTwo && NPC.combatBookVolumeTwoWasUsed)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.TorchGodsFavor && Main.LocalPlayer.unlockedBiomeTorches)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.MinecartPowerup && Main.LocalPlayer.unlockedSuperCart)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.DemonHeart && Main.LocalPlayer.CanDemonHeartAccessoryBeShown())
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }
    }
}
