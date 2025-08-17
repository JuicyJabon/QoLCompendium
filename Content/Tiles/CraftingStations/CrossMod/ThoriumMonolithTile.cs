using Terraria.ObjectData;
using ThoriumMod.Tiles;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod
{
    [JITWhenModsEnabled("ThoriumMod")]
    [ExtendsFromMod("ThoriumMod")]
    public class ThoriumMonolithTile : ModTile
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
            AdjTiles = new int[] { ModContent.TileType<ThoriumAnvil>(), ModContent.TileType<ArcaneArmorFabricator>(), ModContent.TileType<GrimPedestal>(), ModContent.TileType<SoulForge>(), ModContent.TileType<GuidesFinalGiftTile>() };
            DustType = -1;
        }
    }
}
