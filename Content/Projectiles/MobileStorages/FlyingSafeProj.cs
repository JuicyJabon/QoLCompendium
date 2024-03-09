using QoLCompendium.Content.Items.MobileStorages;
using QoLCompendium.Core;

namespace QoLCompendium.Content.Projectiles.MobileStorages
{
    public class FlyingSafeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 46;
            Projectile.aiStyle = 97;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 10800;
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverPlayers, List<int> drawCacheProjsOverWiresUI)
        {
            drawCacheProjsOverWiresUI.Add(Projectile.whoAmI);
        }

        public override void PostAI()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Player player = Main.player[Main.myPlayer];
                BankPlayer modPlayer = player.GetModPlayer<BankPlayer>();
                PortableBankAI.BankAI(Projectile, ModContent.ItemType<FlyingSafe>(), -3, ref modPlayer.safe, player, modPlayer);
            }
        }

        public override void AI()
        {
            if (++Projectile.frameCounter >= 15)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
        }
    }
}
