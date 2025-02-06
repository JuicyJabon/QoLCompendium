using QoLCompendium.Content.Tiles.Other;
using QoLCompendium.Core;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace QoLCompendium.Content.Projectiles.Explosives
{
    public class CheckDestruction : GlobalProjectile
    {
        public static bool OkayToDestroyTile(Tile tile, bool ignoreModdedTiles = false)
        {
            bool noDungeon = !NPC.downedBoss3 &&
                (tile.TileType == TileID.BlueDungeonBrick || tile.TileType == TileID.GreenDungeonBrick || tile.TileType == TileID.PinkDungeonBrick
                || tile.WallType == WallID.BlueDungeonSlabUnsafe || tile.WallType == WallID.BlueDungeonTileUnsafe || tile.WallType == WallID.BlueDungeonUnsafe
                || tile.WallType == WallID.GreenDungeonSlabUnsafe || tile.WallType == WallID.GreenDungeonTileUnsafe || tile.WallType == WallID.GreenDungeonUnsafe
                || tile.WallType == WallID.PinkDungeonSlabUnsafe || tile.WallType == WallID.PinkDungeonTileUnsafe || tile.WallType == WallID.PinkDungeonUnsafe
            );
            bool noHMOre = (tile.TileType == TileID.Cobalt || tile.TileType == TileID.Palladium || tile.TileType == TileID.Mythril || tile.TileType == TileID.Orichalcum || tile.TileType == TileID.Adamantite || tile.TileType == TileID.Titanium) && !NPC.downedMechBossAny;
            bool noChloro = tile.TileType == TileID.Chlorophyte && !(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3);
            bool noLihzahrd = (tile.TileType == TileID.LihzahrdBrick || tile.WallType == WallID.LihzahrdBrickUnsafe) && !NPC.downedGolemBoss;

            if (noDungeon || noHMOre || noChloro || noLihzahrd)
                return false;
            if (TileBelongsToMod(tile) && ignoreModdedTiles)
                return false;

            return true;
        }

        public static bool OkayToDestroyTileAt(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            if (tile == null)
                return false;
            return OkayToDestroyTile(tile);
        }

        public static bool TileIsLiterallyAir(Tile tile)
        {
            return tile.TileType == 0 && tile.WallType == 0 && tile.LiquidAmount == 0 && tile.TileFrameX == 0 && tile.TileFrameY == 0;
        }

        public static bool TileBelongsToMod(Tile tile)
        {
            return (tile.TileType > TileID.Count || tile.WallType > WallID.Count) && tile.TileType != ModContent.TileType<AsphaltPlatformTile>() && tile.TileType != Common.GetModTile(ModConditions.aequusMod, "Manacle") && tile.TileType != Common.GetModTile(ModConditions.aequusMod, "Mistral") && tile.TileType != Common.GetModTile(ModConditions.aequusMod, "Moonflower") && tile.TileType != Common.GetModTile(ModConditions.aequusMod, "Moray");
        }
    }

    public class Destruction : GlobalTile
    {
        internal static void DestroyChest(int x, int y)
        {
            int chestType = 1;

            int chest = Chest.FindChest(x, y);
            if (chest != -1)
            {
                for (int i = 0; i < 40; i++)
                {
                    Main.chest[chest].item[i] = new Item();
                }

                Main.chest[chest] = null;

                if (Main.tile[x, y].TileType == TileID.Containers2)
                {
                    chestType = 5;
                }

                if (Main.tile[x, y].TileType >= TileID.Count)
                {
                    chestType = 101;
                }
            }

            for (int i = x; i < x + 2; i++)
            {
                for (int j = y; j < y + 2; j++)
                {
                    Main.tile[i, j].TileType = 0;
                    Main.tile[i, j].TileFrameX = 0;
                    Main.tile[i, j].TileFrameY = 0;
                }
            }

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                if (chest != -1)
                {
                    NetMessage.SendData(MessageID.ChestUpdates, -1, -1, null, chestType, x, y, 0f, chest, Main.tile[x, y].TileType);
                }

                NetMessage.SendTileSquare(-1, x, y, 3);
            }
        }


        internal static Point16 FindChestTopLeft(int x, int y, bool destroy)
        {
            Tile tile = Main.tile[x, y];
            if (TileID.Sets.BasicChest[tile.TileType])
            {
                TileObjectData data = TileObjectData.GetTileData(tile.TileType, 0);
                x -= tile.TileFrameX / 18 % data.Width;
                y -= tile.TileFrameY / 18 % data.Height;

                if (destroy)
                {
                    DestroyChest(x, y);
                }

                return new Point16(x, y);
            }

            return Point16.NegativeOne;
        }

        internal static void ClearTileAndLiquid(int x, int y, bool sendData = true)
        {
            FindChestTopLeft(x, y, true);

            Tile tile = Main.tile[x, y];
            bool hadLiquid = tile.LiquidAmount != 0;
            WorldGen.KillTile(x, y, noItem: true);

            tile.Clear(TileDataType.Tile);
            tile.Clear(TileDataType.Liquid);

            if (Main.netMode == NetmodeID.Server)
            {
                if (hadLiquid)
                    NetMessage.sendWater(x, y);
                if (sendData)
                    NetMessage.SendTileSquare(-1, x, y, 1);
            }
        }

        internal static void ClearEverything(int x, int y, bool sendData = true)
        {
            FindChestTopLeft(x, y, true);

            Tile tile = Main.tile[x, y];
            bool hadLiquid = tile.LiquidAmount != 0;
            WorldGen.KillTile(x, y, noItem: true);
            tile.ClearEverything();

            if (Main.netMode == NetmodeID.Server)
            {
                if (hadLiquid)
                    NetMessage.sendWater(x, y);
                if (sendData)
                    NetMessage.SendTileSquare(-1, x, y, 1);
            }
        }
    }
}
