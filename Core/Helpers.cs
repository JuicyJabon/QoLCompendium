using Terraria.Chat;

namespace QoLCompendium.Core
{
    public static class ShopHelper
    {
        public static NPCShop AddModItemToShop(this NPCShop shop, Mod mod, string itemName, int price)
        {
            if (mod != null)
            {
                if (mod.TryFind(itemName, out ModItem currItem))
                {
                    shop.Add(new Item(currItem.Type) { shopCustomPrice = price });
                }
            }
            return shop;
        }

        public static NPCShop AddModItemToShop(this NPCShop shop, Mod mod, string itemName, int price, params Condition[] condition)
        {
            if (mod != null)
            {
                if (mod.TryFind(itemName, out ModItem currItem))
                {
                    shop.Add(new Item(currItem.Type) { shopCustomPrice = price }, condition);
                }
            }
            return shop;
        }

        public static NPCShop AddModItemToShop(this NPCShop shop, Mod mod, string itemName, int price, Func<bool> predicate)
        {
            if (mod != null)
            {
                if (mod.TryFind(itemName, out ModItem currItem))
                {
                    shop.Add(new Item(currItem.Type) { shopCustomPrice = price }, new Condition("", predicate));
                }
            }
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(this NPCShop shop, int price) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price });
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(this NPCShop shop, int price, params Condition[] condition) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price }, condition);
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(this NPCShop shop, int price, Func<bool> predicate) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price }, new Condition("", predicate));
            return shop;
        }

        public static void OpenShop(ref string Shop, string shop, ref bool visible)
        {
            Shop = shop;
            visible = false;
            NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
            string _ = "";
            npc.ModNPC.SetChatButtons(ref _, ref _);
        }
    }

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
