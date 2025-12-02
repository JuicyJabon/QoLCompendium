using MartainsOrder;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    public class MartinsOrderClassTagTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ClassTagTooltip && !ModContent.GetInstance<MOConfigServer>().MClassTooltip) ItemClassTooltip(item, tooltips);
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (Common.VoidDamageClasses.Contains(item.DamageType))
                return;

            //ARTIST
            if ((item.CountsAsClass(Common.GetModDamageClass(ModConditions.martainsOrderMod, "ArtistClass")) || item.CountsAsClass(Common.GetModDamageClass(ModConditions.martainsOrderMod, "ArtistClassNoSpeed")) || item.CountsAsClass(Common.GetModDamageClass(ModConditions.martainsOrderMod, "ArtistClassTempera"))) && item.IsAWeapon())
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ArtistClass")));
        }
    }
}
