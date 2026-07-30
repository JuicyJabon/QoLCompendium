namespace QoLCompendium.Content.NPCs.Town
{
    public abstract class QoLCTownNPC : ModNPC
    {
        public abstract string ShopNameValue { get; }
        public abstract List<string> AllShops { get; }
        public abstract void ChangeShopName(string shopName);
    }
}
