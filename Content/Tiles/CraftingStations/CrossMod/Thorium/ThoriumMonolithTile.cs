using Terraria.ObjectData;
using ThoriumMod.Tiles;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Thorium
{
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
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
            AdjTiles = new int[] { 
                TileID.AdamantiteForge, 
                TileID.Furnaces, 
                TileID.Hellforge, 
                TileID.WorkBenches, 
                TileID.Bottles, 
                TileID.AlchemyTable, 
                TileID.MythrilAnvil, 
                TileID.Anvils, 
                TileID.DemonAltar, 
                TileID.Chairs, 
                TileID.Tables, 
                TileID.Tables2, 
                TileID.Bookcases, 
                TileID.TinkerersWorkbench, 
                TileID.Sawmill, 
                TileID.HeavyWorkBench, 
                TileID.Loom, 
                ModContent.TileType<ThoriumAnvil>(), 
                ModContent.TileType<ArcaneArmorFabricator>(), 
                ModContent.TileType<GrimPedestal>(), 
                ModContent.TileType<SoulForge>(), 
                ModContent.TileType<SoulForgeNew>(), 
                ModContent.TileType<GuidesFinalGiftTile>() 
            };
            DustType = -1;
        }
    }
}
