using ContinentOfJourney.Items.Placables.Furniture.Death;
using ContinentOfJourney.Items.Placables.Furniture.Nothingness;
using ContinentOfJourney.Tiles;
using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations.CrossMod
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class HomewardJourneyMonolithTile : ModTile
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
            AdjTiles = new int[] { TileID.BubbleMachine, ModContent.TileType<FishmenFreeMarketTradingSystem>(), ModContent.TileType<FinalAnvil>(), ModContent.TileType<HallowedAltar>(), ModContent.TileType<FountainofLife>(), ModContent.TileType<FountainofMatter>(), ModContent.TileType<FountainofTime>(), ModContent.TileType<DeathWorkbench>(), ModContent.TileType<NothingnessWorkbench>() };
            DustType = -1;
        }
    }
}
