namespace QoLCompendium.Core.Changes.TileChanges
{
    public class BombableOres : GlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            if (!QoLCompendium.mainConfig.BombableHardmodeOres)
                return base.CanExplode(i, j, type);

            HashSet<int> hardmodeOres = [
                TileID.Cobalt,
                TileID.Palladium,
                TileID.Mythril,
                TileID.Orichalcum,
                TileID.Adamantite,
                TileID.Titanium
            ];

            if (hardmodeOres.Contains(type) && Condition.DownedMechBossAll.IsMet())
                return true;
            else if (type == TileID.Chlorophyte && Condition.DownedPlantera.IsMet())
                return true;
            else
                return base.CanExplode(i, j, type);
        }
    }
}
