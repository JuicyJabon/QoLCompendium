using QoLCompendium.Items.MobileStorages;
using QoLCompendium.Tweaks;

namespace QoLCompendium.Projectiles
{
    public class WeightlessSafeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 28;
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
                QoLCPlayer modPlayer = player.GetModPlayer<QoLCPlayer>();
                PortableBankAI.BankAI(Projectile, ModContent.ItemType<WeightlessSafe>(), -3, ref modPlayer.safe, player, modPlayer);
            }
        }
    }
}
