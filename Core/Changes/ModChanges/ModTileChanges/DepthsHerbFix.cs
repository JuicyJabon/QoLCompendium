namespace QoLCompendium.Core.Changes.ModChanges.ModTileChanges
{
    public class DepthsHerbFix : GlobalTile
    {
        public override void SetStaticDefaults()
        {
            if (!CrossModSupport.Depths.Loaded)
                return;

            if (!QoLCompendium.crossModConfig.DepthsHerbFix)
                return;

            TileID.Sets.TileCutIgnore.Regrowth[Common.GetModTile(CrossModSupport.Depths.Mod, "ShadowShrub")] = true;
        }
    }
}
