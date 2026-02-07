using CalamityMod.Tiles.Furniture.CraftingStations;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class CalamityMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<UltimateMonolithTile>())
            {
                //Hardmode
                newAdjTiles.Add(ModContent.TileType<AshenAltar>());
                newAdjTiles.Add(ModContent.TileType<PlagueInfuser>());
                newAdjTiles.Add(ModContent.TileType<VoidCondenser>());
                //Post Moon Lord
                newAdjTiles.Add(ModContent.TileType<SCalAltar>());
                newAdjTiles.Add(ModContent.TileType<SCalAltarLarge>());
                newAdjTiles.Add(ModContent.TileType<CosmicAnvil>());
                newAdjTiles.Add(ModContent.TileType<DraedonsForge>());
                newAdjTiles.Add(ModContent.TileType<ProfanedCrucible>());
            }
            return newAdjTiles.ToArray();
        }
    }
}