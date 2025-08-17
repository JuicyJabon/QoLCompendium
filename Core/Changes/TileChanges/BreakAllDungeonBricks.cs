using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.TileChanges
{
    public class BreakAllDungeonBricks : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            var src = new EntitySource_TileBreak(i, j);
            Vector2 projPos = new(Common.ToPixels(i) + 8, Common.ToPixels(j) + 8);

            if (!QoLCompendium.mainConfig.BreakAllDungeonBricks)
                return;

            if (!Main.tileCracked[type] || Main.netMode == NetmodeID.MultiplayerClient)
                return;

            for (int k = 0; k < 8; k++)
            {
                int x = i;
                int y = j;

                switch (k)
                {
                    case 0:
                        x--;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y--;
                        break;
                    case 3:
                        y++;
                        break;
                    case 4:
                        x--;
                        y--;
                        break;
                    case 5:
                        x++;
                        y--;
                        break;
                    case 6:
                        x--;
                        y++;
                        break;
                    case 7:
                        x++;
                        y++;
                        break;
                }

                Tile tile = Main.tile[x, y];

                if (tile.HasTile && Main.tileCracked[tile.TileType])
                {
                    Main.tile[i, j].Get<TileWallWireStateData>().HasTile = false;
                    WorldGen.KillTile(x, y, noItem: true);

                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.TrySendData(MessageID.TileManipulation, number: 20, number2: x, number3: y);
                    }
                }
            }

            int dungeonBrickVariant = type - TileID.CrackedBlueDungeonBrick; // Should be 0, 1, or 2
            int projType = dungeonBrickVariant + ProjectileID.BlueDungeonDebris;

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Projectile.NewProjectile(src, projPos, Vector2.Zero, projType, 20, 0, Main.myPlayer);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                Projectile proj = Projectile.NewProjectileDirect(src, projPos, Vector2.Zero, projType, 20, 0, Main.myPlayer);
                proj.netUpdate = true;
            }
        }
    }
}
