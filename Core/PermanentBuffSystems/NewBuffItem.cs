namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class NewBuffItem(int buffItem, int buffID, BuffEffect effect, int ingredientCount, string itemName, string displayName)
    {
        public int buffItem = buffItem;
        public int buffID = buffID;
        public int ingredientCount = ingredientCount;
        public string displayName = displayName;
        public string itemName = itemName;
        public BuffEffect effect = effect;
    }
}
