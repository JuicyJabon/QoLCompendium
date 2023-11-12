﻿using Microsoft.Xna.Framework;
using QoLCompendium.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Projectiles
{
    public class HellbridgerProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 37;
            Projectile.height = 19;
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
            {
                return;
            }

            bool stopRight = false;
            bool stopLeft = false;

            //RIGHT
            for (int x = Main.maxTilesX / 2; x < Main.maxTilesX; x++)
            {
                if (stopRight)
                    break;

                // Six down, last is platforms
                for (int y = -40; y <= 0; y++)
                {
                    int xPosition = x;
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];
                    if (tile == null)
                        continue;

                    if (!CheckDestruction.OkayToDestroyTile(tile))
                        stopRight = true;


                    if (y == -20 || y == 0)
                    {
                        Destruction.ClearEverything(xPosition, yPosition, false);
                        // Spawn platforms
                        WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms, false, false, -1, 13);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                    }
                    else
                    {
                        if (!CheckDestruction.TileIsLiterallyAir(tile))
                            Destruction.ClearEverything(xPosition, yPosition);
                    }
                }
            }

            //LEFT
            for (int x = Main.maxTilesX / 2; x > 0; x--)
            {
                if (stopLeft)
                    break;

                // Six down, last is platforms
                for (int y = -40; y <= 0; y++)
                {
                    int xPosition = x;
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];
                    if (tile == null)
                        continue;

                    if (!CheckDestruction.OkayToDestroyTile(tile))
                        stopLeft = true;

                    if (y == -20 || y == 0)
                    {
                        Destruction.ClearEverything(xPosition, yPosition, false);
                        // Spawn platforms
                        WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms, false, false, -1, 13);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                    }
                    else
                    {
                        if (!CheckDestruction.TileIsLiterallyAir(tile))
                            Destruction.ClearEverything(xPosition, yPosition);
                    }
                }
            }
        }
    }
}