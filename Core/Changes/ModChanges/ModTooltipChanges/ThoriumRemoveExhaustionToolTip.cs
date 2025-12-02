namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    public class ThoriumRemoveExhaustionToolTip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModConditions.thoriumLoaded && QoLCompendium.crossModConfig.RemoveThoriumExhaustionTooltip) ExhaustionToolTip(item, tooltips);
        }

        public static void ExhaustionToolTip(Item item, List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tip in tooltips)
            {
                if (item.type > ItemID.Count && item.ModItem.Mod == ModConditions.thoriumMod && tip.Text == "Overuse of this weapon exhausts you, massively reducing its damage" || tip.Text == "Killing enemies recovers some of your exhaustion")
                    tip.Hide();
            }
        }
    }
}
