namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [JITWhenModsEnabled(ModConditions.secretsOfTheShadowsName)]
    [ExtendsFromMod(ModConditions.secretsOfTheShadowsName)]
    public class SOTSClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            //VOID ROGUE
            if (ModConditions.infernalEclipseLoaded && item.CountsAsClass(Common.GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")) && item.IsAWeapon())
            {
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidRogueClass")));
                return;
            }

            //VOID WARRIOR
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMelee")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidWarriorClass")));

            //VOID RANGER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidRanged")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidRangerClass")));

            //VOID SORCERER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMagic")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidSorcererClass")));

            //VOID SUMMONER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidSummon")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidSummonerClass")));

            //VOID BARD
            if (ModConditions.secretsOfTheShadowsBardHealerLoaded && item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidBardClass")));

            //VOID HEALER
            if (ModConditions.secretsOfTheShadowsBardHealerLoaded && item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidHealerClass")));

            //VOID THROWER
            if (ModConditions.secretsOfTheShadowsBardHealerLoaded && item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidThrowerClass")));

            //VOID GENERIC
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidGeneric")) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidGenericClass")));
        }
    }
}
