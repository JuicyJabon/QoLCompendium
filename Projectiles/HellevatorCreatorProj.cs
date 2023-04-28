using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Projectiles
{
    // Token: 0x02000018 RID: 24
    public class HellevatorCreatorProj : ModProjectile
    {
        // Token: 0x06000086 RID: 134 RVA: 0x00007F83 File Offset: 0x00006183
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellevator Creator");
        }

        // Token: 0x06000087 RID: 135 RVA: 0x00007F98 File Offset: 0x00006198
        public override void SetDefaults()
        {
            Projectile.width = 13;
            Projectile.height = 31;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 170;
        }

        // Token: 0x06000088 RID: 136 RVA: 0x00007FF4 File Offset: 0x000061F4
        public override bool? CanDamage()
        {
            return false;
        }

        // Token: 0x06000089 RID: 137 RVA: 0x00007FFC File Offset: 0x000061FC
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = false;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
        }

        // Token: 0x0600008A RID: 138 RVA: 0x0000800C File Offset: 0x0000620C
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return true;
        }

        // Token: 0x0600008B RID: 139 RVA: 0x0000801C File Offset: 0x0000621C
        public override void Kill(int timeLeft)
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
