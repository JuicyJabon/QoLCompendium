﻿namespace QoLCompendium.Content.Projectiles.Explosives
{
    public class SuperbomberProj : ModProjectile
    {
        public override string Texture => "QoLCompendium/Content/Items/Tools/Explosives/Superbomber";

        public override void SetDefaults()
        {
            Projectile.width = 29;
            Projectile.height = 29;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            DrawOffsetX = -13;
            DrawOriginOffsetY = -20;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            return base.OnTileCollide(oldVelocity);
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
            int radius = 64;     //bigger = boomer

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius * 2; y <= 0; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];
                    if (tile == null)
                        continue;

                    if (!CheckDestruction.OkayToDestroyTile(tile, false) || CheckDestruction.TileIsLiterallyAir(tile))
                        continue;

                    Destruction.ClearTileAndLiquid(xPosition, yPosition);
                }
            }
            Main.refreshMap = true;
        }
    }
}