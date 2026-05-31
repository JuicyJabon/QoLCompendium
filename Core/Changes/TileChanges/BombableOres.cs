/*
namespace QoLCompendium.Core.Changes.TileChanges
{
    public class BombableOres : GlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            if (!QoLCompendium.mainConfig.BombableHardmodeOres)
                return base.CanExplode(i, j, type);

            if (Constants.HardmodeOres.Contains(type) || type == TileID.Chlorophyte)
                return true;
            else
                return base.CanExplode(i, j, type);
        }
    }
}
*/