using CalamityEntropy.Content.Tiles;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class CalamityEntropyMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<CalamityMonolithTile>() || type == ModContent.TileType<UltimateMonolithTile>())
                newAdjTiles.Add(ModContent.TileType<AbyssalAltarTile>());
            return newAdjTiles.ToArray();
        }
    }
}
