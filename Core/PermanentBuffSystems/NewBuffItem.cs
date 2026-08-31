namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class NewBuffItem(int baseItem, BuffEffect effect, int ingredientCount, string itemName)
    {
        public int baseItem = baseItem;
        public BuffEffect effect = effect;
        public int ingredientCount = ingredientCount;
        public string itemName = itemName;
    }
}
