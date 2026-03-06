using Terraria.Chat;

namespace QoLCompendium.Core
{
    public static class TextHelper
    {
        public static void PrintText(string text)
        {
            PrintText(text, Color.White);
        }

        public static void PrintText(string text, Color color, bool myPlayerOnly = false)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
                Main.NewText(text, color);
            else if (Main.netMode == NetmodeID.Server)
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color);
            else if (Main.netMode == NetmodeID.Server && myPlayerOnly)
                ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral(text), color, Main.myPlayer);
        }

        public static void PrintText(string text, int r, int g, int b) => PrintText(text, new Color(r, g, b));
    }

}
