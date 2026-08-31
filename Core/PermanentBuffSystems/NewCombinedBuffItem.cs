namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class NewCombinedBuffItem(string itemName, List<BuffEffect> effects, List<int> ingredients)
    {
        public List<BuffEffect> effects = effects;
        public List<int> ingredients = ingredients;
        public string itemName = itemName;
        public string textureName = "QoLCompendium/Assets/Items/PermanentBuffs/" + itemName;
    }
}
