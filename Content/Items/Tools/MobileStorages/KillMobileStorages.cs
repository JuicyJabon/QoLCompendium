using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.MobileStorages
{
    public class KillMobileStorages : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.MoneyTrough || entity.type == ItemID.VoidLens || entity.type == ItemID.ClosedVoidBag || entity.type == ModContent.ItemType<FlyingSafe>() || entity.type == ModContent.ItemType<EtherianConstruct>();
        }

        public override bool CanRightClick(Item item) => true;

        public override void RightClick(Item item, Player player)
        {
            foreach (Projectile proj in Main.projectile)
            {
                if (Common.MobileStorages.Contains(proj.type) && player.ownedProjectileCounts[proj.type] > 0 && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
        }

        public override void OnConsumeItem(Item item, Player player) => item.stack++;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "KillMobileStorage", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.KillMobileStorage"));
            tooltipLine.OverrideColor = Color.Gray;
            Common.AddLastTooltip(tooltips, tooltipLine);
        }
    }
}
