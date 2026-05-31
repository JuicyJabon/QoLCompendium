using Terraria.DataStructures;

namespace QoLCompendium.Core.QoLCUtils
{
    public static class TileUtils
    {
        public static bool IsTileWithinPlayerReach(Player player)
        {
            Item item = player.inventory[player.selectedItem];
            int extraItemRange = 0;
            int extraBlockRange = player.blockRange;
            if (!item.IsAir)
                extraItemRange = item.tileBoost;
            Vector2 playerRange = new(Player.tileRangeX + extraBlockRange + extraItemRange, Player.tileRangeY + extraBlockRange + extraItemRange);
            Vector2 playerPosX = new(player.position.X / 16f - playerRange.X, (player.position.X + player.width) / 16f + playerRange.X);
            Vector2 playerPosY = new(player.position.Y / 16f - playerRange.Y, (player.position.Y + player.height) / 16f + playerRange.Y);

            if (playerPosX.X <= Player.tileTargetX && playerPosX.Y >= Player.tileTargetX && playerPosY.X <= Player.tileTargetY && playerPosY.Y >= Player.tileTargetY)
                return true;
            return false;
        }

        public static int ToPixels(float blocks)
        {
            return (int)(blocks * 16);
        }
        
        public static float ToBlocks(float pixels)
        {
            return pixels / 16;
        }

        public static Point16 PlayerCenterTile(Player player)
        {
            return new Point16((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f));
        }

        public static int PlayerCenterTileX(Player player)
        {
            return (int)(player.Center.X / 16f);
        }

        public static int PlayerCenterTileY(Player player)
        {
            return (int)(player.Center.Y / 16f);
        }

        public static bool InGameWorldLeft(int x)
        {
            return x > 39;
        }

        public static bool InGameWorldRight(int x)
        {
            return x < Main.maxTilesX - 39;
        }

        public static bool InGameWorldTop(int y)
        {
            return y > 39;
        }

        public static bool InGameWorldBottom(int y)
        {
            return y < Main.maxTilesY - 39;
        }

        public static bool InGameWorld(int x, int y)
        {
            return x > 39 && x < Main.maxTilesX - 39 && y > 39 && y < Main.maxTilesY - 39;
        }

        public static bool InWorldLeft(int x)
        {
            return x >= 0;
        }

        public static bool InWorldRight(int x)
        {
            return x < Main.maxTilesX;
        }

        public static bool InWorldTop(int y)
        {
            return y >= 0;
        }

        public static bool InWorldBottom(int y)
        {
            return y < Main.maxTilesY;
        }

        public static bool InWorld(int x, int y)
        {
            return x >= 0 && x < Main.maxTilesX && y >= 0 && y < Main.maxTilesY;
        }

        public static int CoordsX(int x)
        {
            return x * 2 - Main.maxTilesX;
        }

        public static int CoordsY(int y)
        {
            return y * 2 - (int)Main.worldSurface * 2;
        }

        public static string CoordsString(int x, int y)
        {
            x = x * 2 - Main.maxTilesX;
            y = y * 2 - (int)Main.worldSurface * 2;
            string text = x < 0 ? " west, " : " east, ";
            string text2 = y < 0 ? " surface." : " underground.";
            x = x < 0 ? x * -1 : x;
            y = y < 0 ? y * -1 : y;
            return x.ToString() + text + y.ToString() + text2;
        }

        public static void TileSafe(int x, int y)
        {
            if (x < 0 || y < 0 || x > Main.ActiveWorldFileData.WorldSizeX || y > Main.ActiveWorldFileData.WorldSizeY)
            {
                return;
            }
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y].ResetToType(0);
            }
        }

        public static bool TileNull(int x, int y)
        {
            return Main.tile[x, y] == null;
        }

        public static bool SolidTile(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return !TileNull(x, y) && tile.HasTile && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType] && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid && !tile.IsActuated;
        }

        public static bool SearchBelow(Player player, Func<int, int, bool> toSearch, int gap)
        {
            int centerX = PlayerCenterTileX(player);
            int centerY = PlayerCenterTileY(player);
            int num3 = 0;
            while (InGameWorldLeft(centerX - num3) || InGameWorldRight(centerX + num3))
            {
                int tempY = centerY;
                while (InGameWorldBottom(tempY))
                {
                    int nX = centerX - num3;
                    int pX = centerX + num3;
                    if (InGameWorldLeft(nX))
                    {
                        TileSafe(nX, tempY);
                        if (toSearch.Invoke(nX, tempY))
                        {
                            return true;
                        }
                    }
                    if (InGameWorldRight(pX))
                    {
                        TileSafe(pX, tempY);
                        if (toSearch.Invoke(pX, tempY))
                        {
                            return true;
                        }
                    }
                    tempY += gap;
                }
                num3 += gap;
            }
            return false;
        }
    }
}
