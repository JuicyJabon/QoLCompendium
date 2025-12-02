using ThoriumMod;
using ThoriumMod.Items;
using ThoriumMod.Utilities;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
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
            if (Common.VoidDamageClasses.Contains(item.DamageType))
                return;

            int index = tooltips.FindIndex(tt => tt.Mod.Equals("Terraria") && tt.Name.Equals("ItemName"));
            if (index == -1) return;

            if (item.CountsAsClass(ThoriumDamageBase<BardDamage>.Instance) && item.IsAWeapon())
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.BardClass")));

            if ((item.CountsAsClass(ThoriumDamageBase<HealerDamage>.Instance) || item.CountsAsClass(ThoriumDamageBase<HealerTool>.Instance) || item.CountsAsClass(ThoriumDamageBase<HealerToolDamageHybrid>.Instance)) && item.IsAWeapon())
            {
                if (!Main.LocalPlayer.GetThoriumPlayer().darkAura)
                    tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HealerClass")));
                else if ((item.ModItem is ThoriumItem healerItem && healerItem.isDarkHealer) || Main.LocalPlayer.GetThoriumPlayer().darkAura)
                    tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.DarkHealerClass")));
            }

            if (item.CountsAsClass(DamageClass.Throwing) && item.IsAWeapon())
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
        }

        public static void ThrowerClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (Common.VoidDamageClasses.Contains(item.DamageType))
                return;

            int index = tooltips.FindIndex(tt => tt.Mod.Equals("Terraria") && tt.Name.Equals("ItemName"));
            if (index == -1) return;

            if (item.CountsAsClass(DamageClass.Throwing) && item.ModItem is not ThoriumItem && item.IsAWeapon() && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.throwerUnificationMod, "UnitedModdedThrower")))
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
        }
    }
}