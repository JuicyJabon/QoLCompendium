using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Tweaks
{
    public class TeleportClass : GlobalItem
    {
        public static void HandleTeleport(int teleportType = 0, bool forceHandle = false, int whoAmI = 0)
        {
            bool syncData = forceHandle || Main.netMode == NetmodeID.SinglePlayer;
            if (syncData)
            {
                TeleportPlayer(teleportType, forceHandle, whoAmI);
            }
            else
            {
                SyncTeleport(teleportType);
            }
        }

        private static void SyncTeleport(int teleportType = 0)
        {
            var netMessage = QoLCompendium.Instance.GetPacket();
            netMessage.Write((byte)QoLCompendium.QoLCMessageType.TeleportPlayer);
            netMessage.Write(teleportType);
            netMessage.Send();
        }

        private static void TeleportPlayer(int teleportType = 0, bool syncData = false, int whoAmI = 0)
        {
            Player player;
            if (!syncData)
            {
                player = Main.LocalPlayer;
            }
            else
            {
                player = Main.player[whoAmI];
            }
            switch (teleportType)
            {
                case 0:
                    HandleDungeonTeleport(player, syncData);
                    break;
                case 1:
                    HandleTempleTeleport(player, syncData);
                    break;
                default:
                    break;
            }
        }

        private static void HandleDungeonTeleport(Player player, bool syncData = false)
        {
            RunTeleport(player, new Vector2(Main.dungeonX, Main.dungeonY), syncData, true);
        }

        private static void HandleTempleTeleport(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int x = 0; x < Main.tile.Width; ++x)
            {
                for (int y = 0; y < Main.tile.Height; ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 237) continue;
                    pos = new Vector2((x + 2) * 16, y * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void RunTeleport(Player player, Vector2 pos, bool syncData = false, bool convertFromTiles = false)
        {
            bool postImmune = player.immune;
            int postImmunteTime = player.immuneTime;

            if (convertFromTiles)
                pos = new Vector2(pos.X * 16 + 8 - player.width / 2, pos.Y * 16 - player.height);

            LeaveDust(player);

            //Kill hooks
            player.grappling[0] = -1;
            player.grapCount = 0;
            for (int index = 0; index < 1000; ++index)
            {
                if (Main.projectile[index].active && Main.projectile[index].owner == player.whoAmI && Main.projectile[index].aiStyle == 7)
                    Main.projectile[index].Kill();
            }

            player.Teleport(pos, 2, 0);
            player.velocity = Vector2.Zero;
            player.immune = postImmune;
            player.immuneTime = postImmunteTime;

            LeaveDust(player);

            if (Main.netMode != NetmodeID.Server)
                return;

            if (syncData)
            {
                RemoteClient.CheckSection(player.whoAmI, player.position, 1);
                NetMessage.SendData(MessageID.TeleportEntity, -1, -1, null, 0, (float)player.whoAmI, pos.X, pos.Y, 3, 0, 0);
            }
        }

        private static void LeaveDust(Player player)
        {
            //Leave dust
            for (int index = 0; index < 70; ++index)
                Main.dust[Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
            Main.TeleportEffect(player.getRect(), 1);
            Main.TeleportEffect(player.getRect(), 3);
        }
    }
}
