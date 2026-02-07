using QoLCompendium.Content.Items.Tools.MobileStorages;
using QoLCompendium.Core.Changes.PlayerChanges;

namespace QoLCompendium.Content.Projectiles.MobileStorages
{
    public class EtherianConstructProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 36;
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
                PortableBankAI.BankAI(Projectile, ModContent.ItemType<EtherianConstruct>(), BankRange.DefendersForge, player);
            }
        }
    }
}
