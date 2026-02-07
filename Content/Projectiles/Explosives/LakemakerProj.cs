namespace QoLCompendium.Content.Projectiles.Explosives
{
    public class LakemakerProj : ModProjectile
    {
        public override string Texture => "QoLCompendium/Content/Items/Tools/Explosives/Lakemaker";

        public override void SetDefaults()
        {
            Projectile.width = 19;
            Projectile.height = 31;
            Projectile.aiStyle = ProjAIStyleID.Explosive;
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
            SoundEngine.PlaySound(SoundID.Item15, Projectile.Center);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            Vector2 position = Projectile.Center;
            int width = 50;
            int height = 50;

            for (int x = -width / 2; x <= width / 2; x++)
            {
                for (int y = 0; y <= height; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];
                    if (tile == null)
                        continue;

                    if (!CheckDestruction.OkayToDestroyTileAt(xPosition, yPosition) || CheckDestruction.TileIsLiterallyAir(tile))
                        continue;

                    Destruction.ClearTileAndLiquid(xPosition, yPosition);
                    if (y == height || Math.Abs(x) == width / 2)
                    {
                        WorldGen.PlaceTile(xPosition, yPosition, TileID.GrayBrick);
                    }
                    else
                    {
                        WorldGen.PlaceLiquid(xPosition, yPosition, (byte)LiquidID.Water, byte.MaxValue);
                    }

                }
            }
            Main.refreshMap = true;
        }
    }
}