namespace QoLCompendium.Core.Changes.ModChanges
{
    public class AFKPetsMiracleFruitFix : GlobalTile
    {
        public override void SetStaticDefaults()
        {
            if (!ModConditions.afkpetsLoaded)
                return;

            Main.tileCut[Common.GetModTile(ModConditions.afkpetsMod, "Plants")] = false;
        }

        public override void RandomUpdate(int i, int j, int type)
        {
            if (!ModConditions.afkpetsLoaded)
                return;

            if (type == Common.GetModTile(ModConditions.afkpetsMod, "Plants"))
            {
                Tile plant = Main.tile[i, j];
                if (plant.TileFrameX / 18 == 6)
                    plant.TileFrameY = 18;
            }
        }
    }
}
