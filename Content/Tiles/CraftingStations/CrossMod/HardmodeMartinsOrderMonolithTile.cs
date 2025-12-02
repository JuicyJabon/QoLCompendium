using MartainsOrder.Tiles.Modern;
using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class HardmodeMartinsOrderMonolithTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(200, 200, 200), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            //counts as
            AdjTiles = new int[] { TileID.WorkBenches, TileID.Furnaces, TileID.Anvils, TileID.TinkerersWorkbench, TileID.DemonAltar, ModContent.TileType<AdvWorkBench>(), ModContent.TileType<FabricSewer>(), ModContent.TileType<FactoryCentral>() };
            DustType = -1;
        }
    }
}
