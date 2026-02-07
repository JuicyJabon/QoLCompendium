namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [JITWhenModsEnabled(CrossModSupport.SecretsOfTheShadows.Name)]
    [ExtendsFromMod(CrossModSupport.SecretsOfTheShadows.Name)]
    public class SOTSClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            int index = tooltips.FindIndex(tt => tt.Mod.Equals("Terraria") && tt.Name.Equals("ItemName"));
            if (index == -1) return;

            //VOID ROGUE
            if (CrossModSupport.InfernalEclipse.Loaded && item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "VoidRogue")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidRogueClass")));
                return;
            }

            //VOID WARRIOR
            if (item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidMelee")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidWarriorClass")));
                return;
            }

            //VOID RANGER
            if (item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidRanged")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidRangerClass")));
                return;
            }

            //VOID SORCERER
            if (item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidMagic")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidSorcererClass")));
                return;
            }

            //VOID SUMMONER
            if (item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidSummon")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidSummonerClass")));
                return;
            }

            //VOID BARD
            if (CrossModSupport.SecretsOfTheShadowsBardHealer.Loaded && item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidSymphonic")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidBardClass")));
                return;
            }

            //VOID HEALER
            if (CrossModSupport.SecretsOfTheShadowsBardHealer.Loaded && item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidRadiant")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidHealerClass")));
                return;
            }

            //VOID THROWER
            if (CrossModSupport.SecretsOfTheShadowsBardHealer.Loaded && item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidThrowing")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidThrowerClass")));
                return;
            }

            //VOID GENERIC
            if (item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidGeneric")) && item.IsAWeapon())
            {
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VoidGenericClass")));
                return;
            }
        }
    }
}
