namespace QoLCompendium.Core.Changes.TileChanges
{
    public class FastTreeGrowth : GlobalTile
    {
        public override void RandomUpdate(int i, int j, int type)
        {
            if (!QoLCompendium.mainConfig.FastTreeGrowth || !Main.tile[i, j].HasTile)
            {
                return;
            }
            for (int time = 0; time < 4; time++)
            {
                switch (type)
                {
                    case TileID.Saplings:
                        if (Main.tile[i, j].TileFrameX < 324 || Main.tile[i, j].TileFrameX >= 540 ? WorldGen.GrowTree(i, j) : WorldGen.GrowPalmTree(i, j) && WorldGen.PlayerLOS(i, j))
                            WorldGen.TreeGrowFXCheck(i, j);
                        return;
                    case TileID.VanityTreeSakuraSaplings:
                    case TileID.VanityTreeWillowSaplings:
                        if (WorldGen.genRand.NextBool(5) && WorldGen.TryGrowingTreeByType(type + 1, i, j) && WorldGen.PlayerLOS(i, j))
                            WorldGen.TreeGrowFXCheck(i, j);
                        return;
                    case TileID.GemSaplings:
                        if (WorldGen.genRand.NextBool(5))
                        {
                            int style = Main.tile[i, j].TileFrameX / 54;
                            int treeTileType = TileID.TreeTopaz + style;

                            if (WorldGen.TryGrowingTreeByType(treeTileType, i, j) && WorldGen.PlayerLOS(i, j))
                                WorldGen.TreeGrowFXCheck(i, j);
                        }
                        return;
                }
                if (TileID.Sets.TreeSapling[type])
                {
                    TileLoader.GetTile(type)?.RandomUpdate(i, j);
                }
            }
        }
    }

}
