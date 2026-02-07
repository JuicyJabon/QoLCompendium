namespace QoLCompendium.Core.Changes.ModChanges.ModTileChanges
{
    public class AFKPetsPlantsFix : GlobalTile
    {
        public override void SetStaticDefaults()
        {
            if (!CrossModSupport.AFKPets.Loaded)
                return;

            if (!QoLCompendium.crossModConfig.AFKPetsCropFix)
                return;

            Main.tileCut[Common.GetModTile(CrossModSupport.AFKPets.Mod, "Plants")] = false;
        }

        public override void RandomUpdate(int i, int j, int type)
        {
            if (!CrossModSupport.AFKPets.Loaded)
                return;

            if (!QoLCompendium.crossModConfig.AFKPetsFasterCropGrowth)
                return;

            if (type == Common.GetModTile(CrossModSupport.AFKPets.Mod, "Plants"))
            {
                Main.tile[i, j].TileFrameY = 18;
            }
        }
    }
}
