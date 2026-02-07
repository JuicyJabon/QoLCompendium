using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class CalamityMonolithTile : ModTile
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
                TileID.WorkBenches, 
                TileID.Tables, 
                TileID.Tables2, 
                TileID.Chairs, 
                TileID.Anvils, 
                TileID.Furnaces, 
                TileID.TinkerersWorkbench, 
                TileID.Hellforge, 
                TileID.DemonAltar, 
                TileID.MythrilAnvil, 
                TileID.AdamantiteForge, 
                TileID.LunarCraftingStation, 
                ModContent.TileType<AshenAltar>(), 
                ModContent.TileType<PlagueInfuser>(), 
                ModContent.TileType<VoidCondenser>(), 
                ModContent.TileType<SCalAltar>(), 
                ModContent.TileType<SCalAltarLarge>(), 
                ModContent.TileType<CosmicAnvil>(), 
                ModContent.TileType<DraedonsForge>(),
                ModContent.TileType<ProfanedCrucible>() 
            };
            DustType = -1;
        }
    }
}
