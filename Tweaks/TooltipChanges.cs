namespace QoLCompendium.Tweaks
{
    public class TooltipChanges : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine fav = tooltips.Find(l => l.Name == "Favorite");
            TooltipLine favDescr = tooltips.Find(l => l.Name == "FavoriteDesc");

            if (QoLCompendium.mainConfig.NoFavoriteTooltip) tooltips.Remove(fav);
            if (QoLCompendium.mainConfig.NoFavoriteTooltip) tooltips.Remove(favDescr);
        }
    }
}
