﻿using Terraria.ObjectData;

namespace QoLCompendium.Content.Tiles.CraftingStations
{
    public class BasicMonolithTile : ModTile
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
            AdjTiles = new int[] { TileID.WorkBenches, TileID.HeavyWorkBench, TileID.Furnaces, TileID.Anvils, TileID.Bottles, TileID.Sawmill, TileID.Loom, TileID.Tables, TileID.Chairs, TileID.CookingPots, TileID.Sinks, TileID.Kegs };
            TileID.Sets.CountsAsWaterSource[Type] = true;
            DustType = -1;
        }
    }
}
