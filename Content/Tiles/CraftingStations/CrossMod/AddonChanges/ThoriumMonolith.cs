using ThoriumMod.Tiles;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.AddonChanges
{
    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class ThoriumMonolith : GlobalTile
    {
        public override int[] AdjTiles(int type)
        {
            HashSet<int> newAdjTiles = base.AdjTiles(type).ToHashSet();
            if (type == ModContent.TileType<UltimateMonolithTile>())
            {
                //Pre Hardmode
                newAdjTiles.Add(ModContent.TileType<ThoriumAnvil>());
                newAdjTiles.Add(ModContent.TileType<ArcaneArmorFabricator>());
                newAdjTiles.Add(ModContent.TileType<GrimPedestal>());
                //Hardmode
                newAdjTiles.Add(ModContent.TileType<SoulForgeNew>());
                newAdjTiles.Add(ModContent.TileType<GuidesFinalGiftTile>());
            }
            return newAdjTiles.ToArray();
        }
    }
}