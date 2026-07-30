using CalamityLegacy.Content.Items.Tiles.Crafting;
using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Calamity;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.CalamityRekindled.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityRekindled.Name)]
    public class CalamityRekindledMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = [.. base.AdjTiles(type)];
            if (type == ModContent.TileType<CalamityMonolithTile>())
                newAdjTiles.Add(ModContent.TileType<ParticleAcceleratorTile>());
            return [.. newAdjTiles];
        }
    }
}
