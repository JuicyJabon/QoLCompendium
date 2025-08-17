namespace QoLCompendium.Core.Changes.TileChanges
{
    public class HellstoneSpelunker : GlobalTile
    {
        public override bool? IsTileSpelunkable(int i, int j, int type)
        {
            if (QoLCompendium.mainConfig.HellstoneSpelunker && type == TileID.Hellstone)
                return true;
            return base.IsTileSpelunkable(i, j, type);
        }
    }
}
