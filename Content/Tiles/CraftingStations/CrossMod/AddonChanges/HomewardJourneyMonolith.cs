using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.HomewardJourney;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class HomewardJourneyMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = [.. base.AdjTiles(type)];
            if (type == ModContent.TileType<BasicHomewardJourneyMonolithTile>() || type == ModContent.TileType<HomewardJourneyMonolithTile>())
            {
                //Pre Hardmode
                newAdjTiles.Add(Common.GetModTile(CrossModSupport.HomewardJourney.Mod, "StrangeDripMachine"));
            }
            return [.. newAdjTiles];
        }
    }
}