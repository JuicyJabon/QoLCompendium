namespace QoLCompendium.Projectiles
{
    public class HellevatorCreatorProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 13;
            Projectile.height = 31;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 170;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = false;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return true;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            for (int x = -3; x <= 3; x++)
            {
                for (int y = (int)(1 + position.Y / 16.0f); y <= (Main.maxTilesY - 40); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, y];

                    if (tile == null)
                        continue;

                    if (!CheckDestruction.OkayToDestroyTile(tile))
                        continue;

                    Destruction.ClearEverything(xPosition, y, false);

                    // Spawn structure
                    if (x == -3 || x == 3)
                    {
                        WorldGen.PlaceTile(xPosition, y, 38, false, false, -1, 0);
                    }
                    else if (x == -2 || x == 2)
                    {
                        WorldGen.PlaceWall(xPosition, y, 155, false);
                    }
                    else if ((x == -2 || x == 2) && y % 10 == 0)
                    {
                        WorldGen.PlaceTile(xPosition, y, 19, false, false, -1, 14);
                    }
                    else if (x == -1 || x == 1)
                    {
                        WorldGen.PlaceWall(xPosition, y, 1, false);
                    }
                    else if (x == 0)
                    {
                        WorldGen.PlaceTile(xPosition, y, 365, false, false, -1, 0);
                        WorldGen.PlaceWall(xPosition, y, 5, false);
                    }
                    NetMessage.SendTileSquare(-1, xPosition, y, 1, 0);

                    NetMessage.SendTileSquare(-1, xPosition, y, 1);
                }
            }
        }
    }
}
