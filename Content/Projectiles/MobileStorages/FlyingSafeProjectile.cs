using QoLCompendium.Content.Items.Tools.MobileStorages;
using QoLCompendium.Core.Changes.PlayerChanges;

namespace QoLCompendium.Content.Projectiles.MobileStorages
{
    public class FlyingSafeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 32;
            Projectile.aiStyle = ProjAIStyleID.FlyingPiggyBank;
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
                PortableBankAI.BankAI(Projectile, ModContent.ItemType<FlyingSafe>(), BankRange.Safe, player);
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
