namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class MapTeleporting : ModSystem
    {
        public static void TryToTeleportPlayerOnMap()
        {
            if (Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
            {
                Vector2 worldSize = new(Main.maxTilesX * 16, Main.maxTilesY * 16);
                Vector2 mousePos = new(Main.mouseX - (Main.screenWidth / 2), Main.mouseY - (Main.screenHeight / 2));
                Vector2 fullscreenMapPos = Main.mapFullscreenPos;
                mousePos /= 16f;
                mousePos *= 16f / Main.mapFullscreenScale;
                fullscreenMapPos += mousePos;
                fullscreenMapPos *= 16f;
                fullscreenMapPos.Y -= Main.LocalPlayer.height;

                if (fullscreenMapPos.X < 0f)
                    fullscreenMapPos.X = 0f;
                else if (fullscreenMapPos.X + Main.LocalPlayer.width > worldSize.X)
                    fullscreenMapPos.X = worldSize.X - Main.LocalPlayer.width;

                if (fullscreenMapPos.Y < 0f)
                    fullscreenMapPos.Y = 0f;
                else if (fullscreenMapPos.Y + Main.LocalPlayer.height > worldSize.Y)
                    fullscreenMapPos.Y = worldSize.Y - Main.LocalPlayer.height;

                if (Main.LocalPlayer.position != fullscreenMapPos)
                {
                    Main.LocalPlayer.Teleport(fullscreenMapPos, 1, 0);
                    Main.LocalPlayer.position = fullscreenMapPos;
                    Main.LocalPlayer.velocity = Vector2.Zero;
                    Main.LocalPlayer.fallStart = (int)(Main.LocalPlayer.position.Y / 16f);
                    NetMessage.SendData(MessageID.TeleportEntity, -1, -1, null, 0, Main.myPlayer, fullscreenMapPos.X, fullscreenMapPos.Y, 1, 0, 0);
                }
            }
        }

        public override void PostDrawFullscreenMap(ref string mouseText)
        {
            if (QoLCompendium.mainConfig.MapTeleporting)
                TryToTeleportPlayerOnMap();
        }
    }
}
