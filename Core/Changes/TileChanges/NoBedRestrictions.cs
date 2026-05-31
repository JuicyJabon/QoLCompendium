namespace QoLCompendium.Core.Changes.TileChanges
{
    public class NoBedRestrictions : ModSystem
    {
        public override void Load()
        {
            On_Player.CheckSpawn += Player_CheckSpawn;
        }

        public override void Unload()
        {
            On_Player.CheckSpawn -= Player_CheckSpawn;
        }

        private bool Player_CheckSpawn(On_Player.orig_CheckSpawn orig, int x, int y)
        {
            if (QoLCompendium.mainConfig.NoBedRestrictions)
                return true;
            return orig.Invoke(x, y);
        }
    }
}
