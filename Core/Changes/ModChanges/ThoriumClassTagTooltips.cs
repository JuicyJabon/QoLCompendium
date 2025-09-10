using ThoriumMod;
using ThoriumMod.Items;
using ThoriumMod.Utilities;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod(ModConditions.thoriumName)]
    [JITWhenModsEnabled(ModConditions.thoriumName)]
    public class ThoriumClassTagTooltips : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip && !ThoriumConfigClient.Instance.ShowClassTags) ItemClassTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ThrowerClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (ModConditions.thoriumLoaded && item.ModItem is ThoriumItem throwerItem && throwerItem.isThrower && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));

            if (ModConditions.thoriumLoaded && item.ModItem is ThoriumItem healerItem && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant")))
            {
                if (healerItem.isHealer && !healerItem.isDarkHealer && !Main.LocalPlayer.GetThoriumPlayer().darkAura)
                    tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HealerClass")));
                if (healerItem.isDarkHealer || (healerItem.isHealer && Main.LocalPlayer.GetThoriumPlayer().darkAura))
                    tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.DarkHealerClass")));
            }
            if (ModConditions.thoriumLoaded && item.ModItem is BardItem && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.BardClass")));
        }

        public static void ThrowerClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (item.CountsAsClass(DamageClass.Throwing) && !item.accessory && item.ModItem is not ThoriumItem && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
        }
    }
}
