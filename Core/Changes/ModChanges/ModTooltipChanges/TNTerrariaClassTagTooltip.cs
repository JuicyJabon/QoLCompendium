namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    public class TNTerrariaClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            int index = tooltips.FindIndex(tt => tt.Mod.Equals("Terraria") && tt.Name.Equals("ItemName"));
            if (index == -1) return;

            //ENGINEER
            if (CrossModSupport.TNTerraria.Loaded &&
                Constants.DemolisherDamageClasses.Contains(item.DamageType) && 
                item.IsAWeapon())
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.DemolisherClass")));
        }
    }
}
