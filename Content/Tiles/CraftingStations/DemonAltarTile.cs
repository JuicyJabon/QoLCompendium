using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations
{
    public class DemonAltarTile : ModTile
    {
        public override string Texture => "Terraria/Images/Tiles_26";

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(200, 200, 200), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            //counts as
            AdjTiles = new int[] { TileID.DemonAltar };
            DustType = -1;
        }
    }
}
