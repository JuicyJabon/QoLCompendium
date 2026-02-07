using MartainsOrder;

namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
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

            int index = tooltips.FindIndex(tt => tt.Mod.Equals("Terraria") && tt.Name.Equals("ItemName"));
            if (index == -1) return;

            //ARTIST
            if ((item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.MartinsOrder.Mod, "ArtistClass")) || item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.MartinsOrder.Mod, "ArtistClassNoSpeed")) || item.CountsAsClass(Common.GetModDamageClass(CrossModSupport.MartinsOrder.Mod, "ArtistClassTempera"))) && item.IsAWeapon())
                tooltips.Insert(index + 1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ArtistClass")));
        }
    }
}
