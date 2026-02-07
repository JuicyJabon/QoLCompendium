using MartainsOrder.Tiles;
using MartainsOrder.Tiles.Modern;
using MartainsOrder.Tiles.Void;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class MartinsOrderMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<UltimateMonolithTile>())
            {
                //Pre Hardmode
                newAdjTiles.Add(ModContent.TileType<ArcheologyTable>());
                newAdjTiles.Add(ModContent.TileType<SporeFarm>());
                newAdjTiles.Add(ModContent.TileType<MartianBrewer>());
                newAdjTiles.Add(ModContent.TileType<Processor>());
                newAdjTiles.Add(ModContent.TileType<SturdyAnvil>());
                //Hardmode
                newAdjTiles.Add(ModContent.TileType<AdvWorkBench>());
                newAdjTiles.Add(ModContent.TileType<FabricSewer>());
                newAdjTiles.Add(ModContent.TileType<FactoryCentral>());
                //Post Moon Lord
                newAdjTiles.Add(ModContent.TileType<VoidAltar>());
            }
            return newAdjTiles.ToArray();
        }
    }
}