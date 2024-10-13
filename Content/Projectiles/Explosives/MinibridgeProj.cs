namespace QoLCompendium.Content.Projectiles.Explosives
{
    public class MinibridgeProj : ModProjectile
    {
        public override string Texture => "QoLCompendium/Content/Items/Tools/Explosives/Minibridge";

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
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
            Vector2 center = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, center, null);
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;
            bool centerX = Projectile.Center.X < Main.player[Projectile.owner].Center.X;
            int[] source = { 80, 5, 32, 352, 69 };

            Tile tileCenter = Main.tile[(int)(center.X / 16f), (int)(center.Y / 16f)];
            if (!(tileCenter == null))
            {
                if (source.Contains(tileCenter.TileType))
                {
                    Destruction.ClearEverything((int)(center.X / 16f), (int)(center.Y / 16f));
                }
                WorldGen.PlaceTile((int)(center.X / 16f), (int)(center.Y / 16f), TileID.Platforms, false, false, -1, 0);
                NetMessage.SendTileSquare(-1, (int)(center.X / 16f), (int)(center.Y / 16f), 1, TileChangeType.None);
            }

            //Make Bridges
            int startLeft = centerX ? (-100) : 0;
            int endLeft = (!centerX) ? 100 : 0;
            for (int i = startLeft; i < endLeft; i++)
            {
                int posX = (int)(i + center.X / 16f);
                int posY = (int)(center.Y / 16f);
                if (posX < 0 || posX >= Main.maxTilesX || posY < 0 || posY >= Main.maxTilesY)
                {
                    continue;
                }
                Tile tile = Main.tile[posX, posY];
                if (!(tile == null))
                {
                    if (source.Contains(tile.TileType))
                    {
                        Destruction.ClearEverything(posX, posY);
                    }
                    WorldGen.PlaceTile(posX, posY, TileID.Platforms, false, false, -1, 0);
                    NetMessage.SendTileSquare(-1, posX, posY, 1, TileChangeType.None);
                }
            }


            int startRight = centerX ? 100 : 0;
            int endRight = (!centerX) ? -100 : 0;
            for (int i = startRight; i > endRight; i--)
            {
                int posX = (int)(i + center.X / 16f);
                int posY = (int)(center.Y / 16f);
                if (posX < 0 || posX >= Main.maxTilesX || posY < 0 || posY >= Main.maxTilesY)
                {
                    continue;
                }
                Tile tile = Main.tile[posX, posY];
                if (!(tile == null))
                {
                    if (source.Contains(tile.TileType))
                    {
                        Destruction.ClearEverything(posX, posY);
                    }
                    WorldGen.PlaceTile(posX, posY, TileID.Platforms, false, false, -1, 0);
                    NetMessage.SendTileSquare(-1, posX, posY, 1, TileChangeType.None);
                }
            }
        }
    }
}
