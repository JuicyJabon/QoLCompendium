namespace QoLCompendium.UI
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
}
