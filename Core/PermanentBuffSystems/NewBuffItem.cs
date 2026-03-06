namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class NewBuffItem
    {
        public int buffItem;
        public int buffID;
        public int ingredientCount;
        public string displayName;
        public string itemName;
        public BuffEffect effect;

        public NewBuffItem(int buffItem, int buffID, BuffEffect effect, int ingredientCount, string itemName, string displayName)
        {
            this.buffItem = buffItem;
            this.buffID = buffID;
            this.effect = effect;
            this.ingredientCount = ingredientCount;
            this.itemName = itemName;
            this.displayName = displayName;
        }
    }
}
