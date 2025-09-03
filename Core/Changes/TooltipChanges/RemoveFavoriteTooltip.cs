namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class RemoveFavoriteTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine fav = tooltips.Find(l => l.Name == "Favorite");
            TooltipLine favDescr = tooltips.Find(l => l.Name == "FavoriteDesc");

            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip)
            {
                tooltips.Remove(fav);
                tooltips.Remove(favDescr);
            }
        }
    }
}
