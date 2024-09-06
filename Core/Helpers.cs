using QoLCompendium.Content.Items.Magnets;
using QoLCompendium.Core.UI;
using Terraria.Chat;

namespace QoLCompendium.Core
{
    public static class PlayerHelper
    {
        #pragma warning disable CA2211
        public static QoLCPlayer localQoLCPlayer;
        public static MagnetPlayer localMagnetPlayer;
        public static InfoPlayer localInfoPlayer;
        #pragma warning restore

        public static void Unload()
        {
            localQoLCPlayer = null;
            localMagnetPlayer = null;
            localInfoPlayer = null;
        }

        public static void SetLocalQoLCPlayer(QoLCPlayer player)
        {
            if (Main.myPlayer == player.Player.whoAmI && !player.Player.isDisplayDollOrInanimate)
                localQoLCPlayer = player;
        }

        public static QoLCPlayer GetQoLCPlayer(this Player player)
        {
            if (!Main.gameMenu && player.whoAmI == Main.myPlayer && !player.isDisplayDollOrInanimate && localQoLCPlayer != null)
                return localQoLCPlayer;
            return player.GetQoLCPlayer();
        }

        public static void SetLocalMagnetPlayer(MagnetPlayer player)
        {
            if (Main.myPlayer == player.Player.whoAmI && !player.Player.isDisplayDollOrInanimate)
                localMagnetPlayer = player;
        }

        public static MagnetPlayer GetMagnetPlayer(this Player player)
        {
            if (!Main.gameMenu && player.whoAmI == Main.myPlayer && !player.isDisplayDollOrInanimate && localMagnetPlayer != null)
                return localMagnetPlayer;
            return player.GetMagnetPlayer();
        }

        public static void SetLocalInfoPlayer(InfoPlayer player)
        {
            if (Main.myPlayer == player.Player.whoAmI && !player.Player.isDisplayDollOrInanimate)
                localInfoPlayer = player;
        }

        public static InfoPlayer GetInfoPlayer(this Player player)
        {
            if (!Main.gameMenu && player.whoAmI == Main.myPlayer && !player.isDisplayDollOrInanimate && localInfoPlayer != null)
                return localInfoPlayer;
            return player.GetInfoPlayer();
        }
    }

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

        public static void PrintText(string text, Color color)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
                Main.NewText(text, color);
            else if (Main.netMode == NetmodeID.Server)
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color);
        }

        public static void PrintText(string text, int r, int g, int b) => PrintText(text, new Color(r, g, b));
    }
}
