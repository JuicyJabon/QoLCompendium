using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations
{
    public class UltimateMonolithTile : ModTile
    {
        public override void Load()
        {
            On_Recipe.PlayerMeetsEnvironmentConditions += On_PlayerMeetsEnvironmentConditions;
            On_Recipe.PlayerMeetsTileRequirements += On_PlayerMeetsTileRequirements;
        }

        public override void Unload()
        {
            On_Recipe.PlayerMeetsEnvironmentConditions -= On_PlayerMeetsEnvironmentConditions;
            On_Recipe.PlayerMeetsTileRequirements -= On_PlayerMeetsTileRequirements;
        }

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
            AdjTiles = [.. Enumerable.Range(0, TileLoader.TileCount)];
            TileID.Sets.CountsAsWaterSource[Type] = true;
            TileID.Sets.CountsAsLavaSource[Type] = true;
            TileID.Sets.CountsAsHoneySource[Type] = true;
            TileID.Sets.CountsAsShimmerSource[Type] = true;
            DustType = -1;
        }

        private bool On_PlayerMeetsEnvironmentConditions(On_Recipe.orig_PlayerMeetsEnvironmentConditions orig, Player player, Recipe tempRec)
        {
            if (player.adjTile[Type])
                return true;

            return orig(player, tempRec);
        }

        private bool On_PlayerMeetsTileRequirements(On_Recipe.orig_PlayerMeetsTileRequirements orig, Player player, Recipe tempRec)
        {
            if (player.adjTile[Type])
                return true;

            return orig(player, tempRec);
        }
    }
}
