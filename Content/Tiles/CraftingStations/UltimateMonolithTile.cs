using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations
{
    public class UltimateMonolithTile : ModTile
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
                TileID.HeavyWorkBench,
                TileID.Furnaces,
                TileID.Anvils,
                TileID.Bottles,
                TileID.Sawmill,
                TileID.Loom,
                TileID.Tables,
                TileID.Chairs,
                TileID.CookingPots,
                TileID.Sinks,
                TileID.Kegs,
                TileID.BoneWelder,
                TileID.GlassKiln,
                TileID.HoneyDispenser,
                TileID.IceMachine,
                TileID.LivingLoom,
                TileID.SkyMill,
                TileID.Solidifier,
                TileID.TeaKettle,
                TileID.AlchemyTable,
                TileID.TinkerersWorkbench,
                TileID.ImbuingStation,
                TileID.DyeVat,
                TileID.Hellforge,
                TileID.Tombstones,
                TileID.MythrilAnvil,
                TileID.AdamantiteForge,
                TileID.Bookcases,
                TileID.CrystalBall,
                TileID.FleshCloningVat,
                TileID.LesionStation,
                TileID.SteampunkBoiler,
                TileID.Blendomatic,
                TileID.MeatGrinder,
                TileID.LunarCraftingStation,
                TileID.Autohammer,
                TileID.LihzahrdFurnace,
                TileID.DemonAltar,
                ModContent.TileType<AetherAltarTile>()};
            TileID.Sets.CountsAsWaterSource[Type] = true;
            TileID.Sets.CountsAsLavaSource[Type] = true;
            TileID.Sets.CountsAsHoneySource[Type] = true;
            TileID.Sets.CountsAsShimmerSource[Type] = true;
            DustType = -1;
        }
    }
}
