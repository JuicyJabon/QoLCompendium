using CalamityEntropy.Content.Tiles;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled("CalamityEntropy")]
    [ExtendsFromMod("CalamityEntropy")]
    public class CalamityEntropyMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<CalamityMonolithTile>())
                newAdjTiles.Add(ModContent.TileType<AbyssalAltarTile>());
            return newAdjTiles.ToArray();
        }
    }
}
