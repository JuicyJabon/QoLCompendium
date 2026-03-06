namespace QoLCompendium.Content.Tiles.Other
{
    public class NothingTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
        }

        public override bool CanDrop(int i, int j)
        {
            return false;
        }

        public override bool KillSound(int i, int j, bool fail)
        {
            return false;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Main.tile[i, j].ClearTile();
        }
    }
}
