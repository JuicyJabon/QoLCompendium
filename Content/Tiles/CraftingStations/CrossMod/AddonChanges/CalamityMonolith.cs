using CalamityMod.Tiles.Furniture.CraftingStations;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class CalamityMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<UltimateMonolithTile>())
            {
                //Pre Hardmode
                newAdjTiles.Add(ModContent.TileType<WulfrumLabstation>());
                newAdjTiles.Add(ModContent.TileType<EutrophicShelf>());
                newAdjTiles.Add(ModContent.TileType<StaticRefiner>());
                //Hardmode
                newAdjTiles.Add(ModContent.TileType<AncientAltar>());
                newAdjTiles.Add(ModContent.TileType<AshenAltar>());
                newAdjTiles.Add(ModContent.TileType<MonolithAmalgam>());
                newAdjTiles.Add(ModContent.TileType<PlagueInfuser>());
                newAdjTiles.Add(ModContent.TileType<VoidCondenser>());
                //Post Moon Lord
                newAdjTiles.Add(ModContent.TileType<ProfanedCrucible>());
                newAdjTiles.Add(ModContent.TileType<BotanicPlanter>());
                newAdjTiles.Add(ModContent.TileType<SilvaBasin>());
                newAdjTiles.Add(ModContent.TileType<SCalAltar>());
                newAdjTiles.Add(ModContent.TileType<SCalAltarLarge>());
                newAdjTiles.Add(ModContent.TileType<CosmicAnvil>());
                newAdjTiles.Add(ModContent.TileType<DraedonsForge>());
            }
            return newAdjTiles.ToArray();
        }
    }
}