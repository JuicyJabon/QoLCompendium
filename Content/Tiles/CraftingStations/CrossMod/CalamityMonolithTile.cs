using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
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
            AdjTiles = new int[] { ModContent.TileType<WulfrumLabstation>(), ModContent.TileType<EutrophicShelf>(), ModContent.TileType<StaticRefiner>(), ModContent.TileType<AncientAltar>(), ModContent.TileType<AshenAltar>(), ModContent.TileType<MonolithAmalgam>(), ModContent.TileType<PlagueInfuser>(), ModContent.TileType<VoidCondenser>(), ModContent.TileType<ProfanedCrucible>(), ModContent.TileType<BotanicPlanter>(), ModContent.TileType<SilvaBasin>(), ModContent.TileType<SCalAltar>(), ModContent.TileType<SCalAltarLarge>(), ModContent.TileType<CosmicAnvil>(), ModContent.TileType<DraedonsForge>() };
            DustType = -1;
        }
    }
}
