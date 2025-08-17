namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class NoLakeSizePenaltyFishing : ModSystem
    {
        public override void Load()
        {
            On_Projectile.GetFishingPondState += PondState;
        }

        private void PondState(On_Projectile.orig_GetFishingPondState orig, int x, int y, out bool lava, out bool honey, out int numWaters, out int chumCount)
        {
            orig.Invoke(x, y, out lava, out honey, out numWaters, out chumCount);
            if (QoLCompendium.mainConfig.NoLakeSizePenalty)
                numWaters = 114514;
        }
    }
}
