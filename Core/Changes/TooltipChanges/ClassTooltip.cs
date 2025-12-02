namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class ClassTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (Common.VoidDamageClasses.Contains(item.DamageType))
                return;

            //TOOL
            if (item.IsATool())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Tool")));
            //WARRIOR
            if (item.CountsAsClass(DamageClass.Melee) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.WarriorClass")));
            //RANGER
            if (item.CountsAsClass(DamageClass.Ranged) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.RangerClass")));
            //SORCERER
            if (item.CountsAsClass(DamageClass.Magic) && item.IsAWeapon() && item.type != ItemID.Dynamite && item.damage > 0)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SorcererClass")));
            //SUMMONER
            if (item.CountsAsClass(DamageClass.Summon) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SummonerClass")));
            //THROWER
            if (item.CountsAsClass(DamageClass.Throwing) && item.IsAWeapon() && !ModConditions.thoriumLoaded && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.throwerUnificationMod, "UnitedModdedThrower")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
            //GENERIC
            if (item.CountsAsClass(DamageClass.Generic) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Classless")));
        }
    }
}
