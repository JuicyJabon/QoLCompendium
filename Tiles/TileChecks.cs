using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace QoLCompendium.Tiles
{
    internal static class TileChecks
    {
        internal static Point16 PlayerCenterTile(Player player)
        {
            return new Point16((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f));
        }

        internal static int PlayerCenterTileX(Player player)
        {
            return (int)(player.Center.X / 16f);
        }

        internal static int PlayerCenterTileY(Player player)
        {
            return (int)(player.Center.Y / 16f);
        }

        internal static bool InGameWorldLeft(int x)
        {
            return x > 39;
        }

        internal static bool InGameWorldRight(int x)
        {
            return x < Main.maxTilesX - 39;
        }

        internal static bool InGameWorldTop(int y)
        {
            return y > 39;
        }

        internal static bool InGameWorldBottom(int y)
        {
            return y < Main.maxTilesY - 39;
        }

        internal static bool InGameWorld(int x, int y)
        {
            return x > 39 && x < Main.maxTilesX - 39 && y > 39 && y < Main.maxTilesY - 39;
        }

        internal static bool InWorldLeft(int x)
        {
            return x >= 0;
        }

        internal static bool InWorldRight(int x)
        {
            return x < Main.maxTilesX;
        }

        internal static bool InWorldTop(int y)
        {
            return y >= 0;
        }

        internal static bool InWorldBottom(int y)
        {
            return y < Main.maxTilesY;
        }

        internal static bool InWorld(int x, int y)
        {
            return x >= 0 && x < Main.maxTilesX && y >= 0 && y < Main.maxTilesY;
        }

        internal static int CoordsX(int x)
        {
            return x * 2 - Main.maxTilesX;
        }

        internal static int CoordsY(int y)
        {
            return y * 2 - (int)Main.worldSurface * 2;
        }

        internal static string CoordsString(int x, int y)
        {
            x = x * 2 - Main.maxTilesX;
            y = y * 2 - (int)Main.worldSurface * 2;
            string text = (x < 0) ? " west, " : " east, ";
            string text2 = (y < 0) ? " surface." : " underground.";
            x = ((x < 0) ? (x * -1) : x);
            y = ((y < 0) ? (y * -1) : y);
            return x.ToString() + text + y.ToString() + text2;
        }

        internal static void TileSafe(int x, int y)
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

        internal static bool TileNull(int x, int y)
        {
            return Main.tile[x, y] == null;
        }

        internal static bool SolidTile(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return !TileNull(x, y) && tile.HasTile && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType] && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid && !tile.IsActuated;
        }

        internal static bool SearchBelow(Player player, Func<int, int, bool> toSearch, int gap)
        {
            int num = PlayerCenterTileX(player);
            int num2 = PlayerCenterTileY(player);
            int num3 = 0;
            while (InGameWorldLeft(num - num3) || InGameWorldRight(num + num3))
            {
                int num4 = num2;
                while (InGameWorldBottom(num4))
                {
                    int num5 = num - num3;
                    int num6 = num + num3;
                    if (InGameWorldLeft(num5))
                    {
                        TileSafe(num5, num4);
                        if (toSearch.Invoke(num5, num4))
                        {
                            return true;
                        }
                    }
                    if (InGameWorldRight(num6))
                    {
                        TileSafe(num6, num4);
                        if (toSearch.Invoke(num6, num4))
                        {
                            return true;
                        }
                    }
                    num4 += gap;
                }
                num3 += gap;
            }
            return false;
        }
    }
}
