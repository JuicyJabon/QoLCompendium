using MartainsOrder.Tiles;
using MartainsOrder.Tiles.Modern;
using MartainsOrder.Tiles.Void;
using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class MartinsOrderMonolithTile : ModTile
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
            AdjTiles = new int[] { ModContent.TileType<ArcheologyTable>(), ModContent.TileType<SporeFarm>(), ModContent.TileType<MartianBrewer>(), ModContent.TileType<Processor>(), TileID.WorkBenches, TileID.Furnaces, TileID.Anvils, TileID.TinkerersWorkbench, TileID.DemonAltar, ModContent.TileType<AdvWorkBench>(), ModContent.TileType<FabricSewer>(), ModContent.TileType<FactoryCentral>(), ModContent.TileType<VoidAltar>() };
            DustType = -1;
        }
    }
}
