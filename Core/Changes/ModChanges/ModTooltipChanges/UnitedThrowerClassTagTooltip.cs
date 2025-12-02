namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    public class UnitedThrowerClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (Common.VoidDamageClasses.Contains(item.DamageType))
                return;

            //UNITED THROWER
            if (ModConditions.throwerUnificationLoaded && item.CountsAsClass(Common.GetModDamageClass(ModConditions.throwerUnificationMod, "UnitedModdedThrower")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
        }
    }
}
