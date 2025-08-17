using CatalystMod.Tiles.Furniture.CraftingStations;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled("CatalystMod")]
    [ExtendsFromMod("CatalystMod")]
    public class CatalystMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<CalamityMonolithTile>())
                newAdjTiles.Add(ModContent.TileType<AstralTransmogrifier>());
            return newAdjTiles.ToArray();
        }
    }
}
