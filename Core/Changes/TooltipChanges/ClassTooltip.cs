using QoLCompendium.Content.Items.Dedicated;

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
            List<DamageClass> voidClasses = new()
            {
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMelee"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidRanged"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMagic"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidSummon"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidGeneric"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant"),
                Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing"),
                Common.GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")
            };
            if (voidClasses.Contains(item.DamageType))
                return;

            //TOOL
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0 || item.fishingPole > 0 || item.damage > 0 && item.createTile > -1 && !item.IsCurrency)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Tool")));
            //WARRIOR
            if (item.CountsAsClass(DamageClass.Melee) && item.pick <= 0 && item.axe <= 0 && item.hammer <= 0 && item.createTile == -1 && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.WarriorClass")));
            //RANGER
            if (item.CountsAsClass(DamageClass.Ranged) && !item.IsCurrency && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.RangerClass")));
            //SORCERER
            if (item.CountsAsClass(DamageClass.Magic) && item.type != ItemID.Dynamite && item.damage > 0 && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SorcererClass")));
            //SUMMONER
            if (item.CountsAsClass(DamageClass.Summon) && !item.accessory)
            {
                if (!ProjectileID.Sets.IsAWhip[item.shoot])
                    tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SummonerClass")));
                else
                    tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SummonerClassWhip")));
            }
            //THROWER
            if (item.CountsAsClass(DamageClass.Throwing) && !item.accessory && !ModConditions.thoriumLoaded && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.throwerUnificationMod, "UnitedModdedThrower")) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
            //UNITED THROWER
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.throwerUnificationMod, "UnitedModdedThrower")) && ModConditions.throwerUnificationLoaded && !item.accessory && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
            //ROGUE
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")) && ModConditions.calamityLoaded && !item.accessory && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.throwerUnificationMod, "UnitedModdedThrower")) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.RogueClass")));
            //GENERIC
            if ((item.CountsAsClass(DamageClass.Generic) && !item.accessory) || item.type == ModContent.ItemType<SillySlapper>())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Classless")));
        }
    }
}
