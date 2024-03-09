using QoLCompendium.Content.Items.MobileStorages;
using QoLCompendium.Core;

namespace QoLCompendium.Content.Projectiles.MobileStorages
{
    public class EtherianConstructProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 36;
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
                PortableBankAI.BankAI(Projectile, ModContent.ItemType<EtherianConstruct>(), -4, ref modPlayer.defenders, player, modPlayer);
            }
        }
    }
}
