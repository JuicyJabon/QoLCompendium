using QoLCompendium.Core;
using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations
{
    public class SpecializedMonolithTile : ModTile
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
            AdjTiles = new int[] { TileID.BoneWelder, TileID.GlassKiln, TileID.HoneyDispenser, TileID.IceMachine, TileID.LivingLoom, TileID.SkyMill, TileID.Solidifier, TileID.TeaKettle, TileID.AlchemyTable, TileID.TinkerersWorkbench, TileID.ImbuingStation, TileID.DyeVat, TileID.Hellforge, TileID.Tombstones };
            TileID.Sets.CountsAsLavaSource[Type] = true;
            TileID.Sets.CountsAsHoneySource[Type] = true;
            TileID.Sets.CountsAsWaterSource[Type] = true;
            DustType = -1;
        }
    }
}
