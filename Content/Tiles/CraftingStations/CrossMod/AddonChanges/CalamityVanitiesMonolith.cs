using CalValEX.Tiles.FurnitureSets.Auric;
using CalValEX.Tiles.MiscFurniture;
using QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Calamity;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.CalamityVanities.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityVanities.Name)]
    public class CalamityVanitiesMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<HardmodeCalamityMonolithTile>())
            {
                newAdjTiles.Add(ModContent.TileType<StarstruckSynthesizerPlaced>());
            }
            if (type == ModContent.TileType<CalamityMonolithTile>() || type == ModContent.TileType<UltimateMonolithTile>())
            {
                newAdjTiles.Add(ModContent.TileType<StarstruckSynthesizerPlaced>());
                newAdjTiles.Add(ModContent.TileType<AuricManufacturerPlaced>());
            }
            return newAdjTiles.ToArray();
        }
    }
}
