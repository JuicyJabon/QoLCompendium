namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(ModConditions.calamityName)]
    [JITWhenModsEnabled(ModConditions.calamityName)]
    public class CalamityClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (Common.VoidDamageClasses.Contains(item.DamageType))
                return;

            //ROGUE
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")) && item.IsAWeapon() && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.throwerUnificationMod, "UnitedModdedThrower")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.RogueClass")));

            //CLASSLESS
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "AverageDamageClass")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Classless")));
        }
    }
}
