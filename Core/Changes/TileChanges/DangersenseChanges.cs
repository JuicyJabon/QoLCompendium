namespace QoLCompendium.Core.Changes.TileChanges
{
    public class DangersenseChanges : GlobalTile
    {
        public override bool? IsTileDangerous(int i, int j, int type, Player player)
        {
            if (QoLCompendium.mainConfig.DangersenseHighlightsSiltAndSlush && (type == TileID.Silt || type == TileID.Slush))
                return true;
            if (QoLCompendium.mainConfig.DangersenseIgnoresThinIce && type == TileID.BreakableIce)
                return false;
            return base.IsTileDangerous(i, j, type, player);
        }
    }
}
