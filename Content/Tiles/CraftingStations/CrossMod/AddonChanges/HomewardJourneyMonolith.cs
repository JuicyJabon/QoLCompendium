using ContinentOfJourney.Tiles;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class HomewardJourneyMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<UltimateMonolithTile>())
            {
                //Pre Hardmode
                newAdjTiles.Add(TileID.BubbleMachine);
                newAdjTiles.Add(ModContent.TileType<FishmenFreeMarketTradingSystem>());
                newAdjTiles.Add(Common.GetModTile(ModConditions.homewardJourneyMod, "StrangeDripMachine"));
                //Hardmode
                //Post Moon Lord
                newAdjTiles.Add(ModContent.TileType<FinalAnvil>());
                newAdjTiles.Add(ModContent.TileType<HallowedAltar>());
                newAdjTiles.Add(ModContent.TileType<FountainofLife>());
                newAdjTiles.Add(ModContent.TileType<FountainofMatter>());
                newAdjTiles.Add(ModContent.TileType<FountainofTime>());
            }
            if (type == ModContent.TileType<BasicHomewardJourneyMonolithTile>() || type == ModContent.TileType<HomewardJourneyMonolithTile>())
            {
                //Pre Hardmode
                newAdjTiles.Add(Common.GetModTile(ModConditions.homewardJourneyMod, "StrangeDripMachine"));
            }
            return newAdjTiles.ToArray();
        }
    }
}