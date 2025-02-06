namespace QoLCompendium.Content.Projectiles.Explosives
{
    public class HellevatorCreatorProj : ModProjectile
    {
        public override string Texture => "QoLCompendium/Content/Items/Tools/Explosives/HellevatorCreator";

        public override void SetDefaults()
        {
            Projectile.width = 13;
            Projectile.height = 31;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position);

            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            for (int x = -3; x <= 3; x++)
            {
                for (int y = (int)(1 + position.Y / 16.0f); y <= Main.maxTilesY - 40; y++)
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
                        WorldGen.PlaceTile(xPosition, y, TileID.GrayBrick, false, false, -1, 0);
                    }
                    else if (x == -2 || x == 2 || x == -1 || x == 1)
                    {
                        WorldGen.PlaceWall(xPosition, y, WallID.GrayBrick, false);
                    }
                    else if (x == 0)
                    {
                        WorldGen.PlaceTile(xPosition, y, TileID.Rope, false, false, -1, 0);
                        WorldGen.PlaceWall(xPosition, y, WallID.DiamondGemspark, false);
                    }
                    NetMessage.SendTileSquare(-1, xPosition, y, 1, 0);
                }
            }
        }
    }
}
