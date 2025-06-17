namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class UnlockAllHairstyles : ModSystem
    {
        private static bool _rebuilt;

        public override void Load()
        {
            On_HairstyleUnlocksHelper.ListWarrantsRemake += RebuildPatch;
            On_HairstyleUnlocksHelper.RebuildList += UnlockPatch;
        }

        public override void Unload()
        {
            On_HairstyleUnlocksHelper.ListWarrantsRemake -= RebuildPatch;
            On_HairstyleUnlocksHelper.RebuildList -= UnlockPatch;
        }

        private static bool RebuildPatch(On_HairstyleUnlocksHelper.orig_ListWarrantsRemake orig,
            HairstyleUnlocksHelper self)
        {
            if (!QoLCompendium.mainConfig.AllHairStylesAvailable)
                return false;

            if (!_rebuilt)
            {
                _rebuilt = true;
                return true;
            }

            return false;
        }

        private static void UnlockPatch(On_HairstyleUnlocksHelper.orig_RebuildList orig,
            HairstyleUnlocksHelper self)
        {
            if (!QoLCompendium.mainConfig.AllHairStylesAvailable)
                return;

            self.AvailableHairstyles.Clear();
            for (int i = 0; i < TextureAssets.PlayerHair.Length; i++)
            {
                self.AvailableHairstyles.Add(i);
            }
        }
    }
}
