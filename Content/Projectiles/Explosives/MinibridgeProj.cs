using FargowiltasSouls.Content.Tiles;

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
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position, null);
            
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            bool goLeft = Projectile.Center.X < Main.player[Projectile.owner].Center.X;
            int[] deletableTiles = [TileID.Cactus, TileID.Trees, TileID.CorruptThorns, TileID.CrimsonThorns, TileID.JungleThorns];
            int length = 400;
            int min = goLeft ? -length : 0;
            int max = goLeft ? 0 : length;

            //Make Bridges
            for (int x = min; x < max; x++)
            {
                int xPosition = (int)(x + position.X / 16.0f);
                int yPosition = (int)(position.Y / 16.0f);

                if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                    continue;

                Tile tile = Main.tile[xPosition, yPosition];

                if (Common.TileNull(xPosition, yPosition))
                    continue;

                if (deletableTiles.Contains(tile.TileType))
                    Destruction.ClearEverything(xPosition, yPosition);

                // Spawn platforms
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms);
                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            }
        }
    }
}
