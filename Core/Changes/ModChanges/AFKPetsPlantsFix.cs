namespace QoLCompendium.Core.Changes.ModChanges
{
    public class AFKPetsPlantsFix : GlobalTile
    {
        public override void SetStaticDefaults()
        {
            if (!ModConditions.afkpetsLoaded)
                return;

            if (!QoLCompendium.crossModConfig.AFKPetsCropFix)
                return;

            Main.tileCut[Common.GetModTile(ModConditions.afkpetsMod, "Plants")] = false;
        }

        public override void RandomUpdate(int i, int j, int type)
        {
            if (!ModConditions.afkpetsLoaded)
                return;

            if (!QoLCompendium.crossModConfig.AFKPetsFasterCropGrowth)
                return;

            if (type == Common.GetModTile(ModConditions.afkpetsMod, "Plants"))
            {
                Main.tile[i, j].TileFrameY = 18;
            }
        }
    }
}
