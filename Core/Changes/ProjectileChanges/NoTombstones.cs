namespace QoLCompendium.Core.Changes.ProjectileChanges
{
    public class NoTombstones : ModSystem
    {
        public override void Load()
        {
            On_Player.DropTombstone += DontSpawnTombstones;
        }

        public override void Unload()
        {
            On_Player.DropTombstone -= DontSpawnTombstones;
        }

        private void DontSpawnTombstones(On_Player.orig_DropTombstone orig, Player self, long coinsOwned, NetworkText deathText, int hitDirection)
        {
            if (!QoLCompendium.mainConfig.NoTombstoneDrops)
                orig(self, coinsOwned, deathText, hitDirection);
        }
    }
}
