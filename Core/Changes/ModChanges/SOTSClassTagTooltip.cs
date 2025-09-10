namespace QoLCompendium.Core.Changes.ModChanges
{
    public class SOTSClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ThrowerClassTooltip(item, tooltips);
        }

        public static void ThrowerClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            //VOID ROGUE
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")) && ModConditions.infernalEclipseLoaded && !item.accessory)
            {
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidRogueClass")));
                return;
            }

            //VOID WARRIOR
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMelee")) && ModConditions.secretsOfTheShadowsLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidWarriorClass")));

            //VOID RANGER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidRanged")) && ModConditions.secretsOfTheShadowsLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidRangerClass")));

            //VOID SORCERER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMagic")) && ModConditions.secretsOfTheShadowsLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidSorcererClass")));

            //VOID SUMMONER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidSummon")) && ModConditions.secretsOfTheShadowsLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidSummonerClass")));

            //VOID BARD
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic")) && ModConditions.secretsOfTheShadowsBardHealerLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidBardClass")));

            //VOID HEALER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant")) && ModConditions.secretsOfTheShadowsBardHealerLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidHealerClass")));

            //VOID THROWER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing")) && ModConditions.secretsOfTheShadowsBardHealerLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidThrowerClass")));


            List<DamageClass> voidClasses = new()
            {
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMelee"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidRanged"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMagic"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidSummon"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing"),
                Common.GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")
            };

            //VOID GENERIC
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidGeneric")) && !voidClasses.Contains(item.DamageType) && ModConditions.secretsOfTheShadowsLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidGenericClass")));
        }
    }
}
