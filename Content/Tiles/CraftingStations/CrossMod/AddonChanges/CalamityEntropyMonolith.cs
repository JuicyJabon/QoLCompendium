using CalamityEntropy.Content.Tiles;
using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Calamity;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class CalamityEntropyMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<CalamityMonolithTile>() || type == ModContent.TileType<UltimateMonolithTile>())
            {
                newAdjTiles.Add(ModContent.TileType<AbyssalAltarTile>());
                newAdjTiles.Add(ModContent.TileType<VoidWellTile>());
            }
            return newAdjTiles.ToArray();
        }
    }
}
