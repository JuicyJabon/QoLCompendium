using QoLCompendium.Items.MobileStorages;
using QoLCompendium.Tweaks;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Projectiles
{
    public class DefendersCatalystProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 34;
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
                PortableBankAI.BankAI(Projectile, ModContent.ItemType<DefendersCatalyst>(), -4, ref modPlayer.defenders, player, modPlayer);
            }
        }
    }
}
