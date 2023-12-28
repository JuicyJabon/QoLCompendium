using Terraria.ObjectData;

namespace QoLCompendium.Tiles
{
    public class HardmodeCraftingMonolithTile : ModTile
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
            AdjTiles = new int[] { TileID.MythrilAnvil, TileID.AdamantiteForge, TileID.Bookcases, TileID.CrystalBall, TileID.FleshCloningVat, TileID.LesionStation, TileID.SteampunkBoiler, TileID.Blendomatic, TileID.MeatGrinder };
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
