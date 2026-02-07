using ContinentOfJourney.Items.Placables.Furniture.Death;
using ContinentOfJourney.Items.Placables.Furniture.Nothingness;
using ContinentOfJourney.Tiles;
using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.HomewardJourney;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
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
                newAdjTiles.Add(Common.GetModTile(CrossModSupport.HomewardJourney.Mod, "StrangeDripMachine"));
                //Hardmode
                //Post Moon Lord
                newAdjTiles.Add(ModContent.TileType<FinalAnvil>());
                newAdjTiles.Add(ModContent.TileType<HallowedAltar>());
                newAdjTiles.Add(ModContent.TileType<FountainofLife>());
                newAdjTiles.Add(ModContent.TileType<FountainofMatter>());
                newAdjTiles.Add(ModContent.TileType<FountainofTime>());
                newAdjTiles.Add(ModContent.TileType<DeathWorkbench>());
                newAdjTiles.Add(ModContent.TileType<NothingnessWorkbench>());
            }
            if (type == ModContent.TileType<BasicHomewardJourneyMonolithTile>() || type == ModContent.TileType<HomewardJourneyMonolithTile>())
            {
                //Pre Hardmode
                newAdjTiles.Add(Common.GetModTile(CrossModSupport.HomewardJourney.Mod, "StrangeDripMachine"));
            }
            return newAdjTiles.ToArray();
        }
    }
}