namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    public class EdorbisClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (Common.VoidDamageClasses.Contains(item.DamageType))
                return;

            //ENGINEER
            if (ModConditions.edorbisLoaded && item.CountsAsClass(Common.GetModDamageClass(ModConditions.edorbisMod, "EngineerDamageClass")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.EngineerClass")));
        }
    }
}
