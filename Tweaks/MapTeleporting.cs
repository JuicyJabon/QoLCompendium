using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Tweaks
{
    public class MapSystem : ModSystem
    {
        public static void TryToTeleportPlayerOnMap()
        {
            if (Main.mouseRight && Main.keyState.IsKeyUp((Microsoft.Xna.Framework.Input.Keys)162))
            {
                int num = Main.maxTilesX * 16;
                int num2 = Main.maxTilesY * 16;
                Vector2 vector = new((float)Main.mouseX, (float)Main.mouseY);
                vector.X -= (float)(Main.screenWidth / 2);
                vector.Y -= (float)(Main.screenHeight / 2);
                Vector2 vector2 = Main.mapFullscreenPos;
                vector /= 16f;
                vector *= 16f / Main.mapFullscreenScale;
                vector2 += vector;
                vector2 *= 16f;
                vector2.Y -= (float)Main.LocalPlayer.height;
                if (vector2.X < 0f)
                {
                    vector2.X = 0f;
                }
                else if (vector2.X + (float)Main.LocalPlayer.width > (float)num)
                {
                    vector2.X = (float)(num - Main.LocalPlayer.width);
                }
                if (vector2.Y < 0f)
                {
                    vector2.Y = 0f;
                }
                else if (vector2.Y + (float)Main.LocalPlayer.height > (float)num2)
                {
                    vector2.Y = (float)(num2 - Main.LocalPlayer.height);
                }
                if (Main.LocalPlayer.position != vector2)
                {
                    Main.LocalPlayer.Teleport(vector2, 1, 0);
                    Main.LocalPlayer.position = vector2;
                    Main.LocalPlayer.velocity = Vector2.Zero;
                    Main.LocalPlayer.fallStart = (int)(Main.LocalPlayer.position.Y / 16f);
                    NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, (float)Main.myPlayer, vector2.X, vector2.Y, 1, 0, 0);
                }
            }
        }

        public override void PostDrawFullscreenMap(ref string mouseText)
        {
            if (MapTeleport && ModContent.GetInstance<QoLCConfig>().MapPorting)
            {
                TryToTeleportPlayerOnMap();
            }
        }

        internal static bool MapTeleport = true;
    }
}
