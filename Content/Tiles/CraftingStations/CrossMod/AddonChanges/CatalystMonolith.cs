using CatalystMod.Tiles.Furniture.CraftingStations;
using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Calamity;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.Catalyst.Name)]
    [ExtendsFromMod(CrossModSupport.Catalyst.Name)]
    public class CatalystMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<HardmodeCalamityMonolithTile>() || type == ModContent.TileType<CalamityMonolithTile>() || type == ModContent.TileType<UltimateMonolithTile>())
                newAdjTiles.Add(ModContent.TileType<AstralTransmogrifier>());
            return newAdjTiles.ToArray();
        }
    }
}
