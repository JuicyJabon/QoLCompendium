namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class NewCombinedBuffItem(Dictionary<BuffEffect, int> effects, string itemName, string displayName, string textureName)
    {
        public Dictionary<BuffEffect, int> effects = effects;
        public string displayName = displayName;
        public string itemName = itemName;
        public string textureName = "QoLCompendium/Assets/Items/PermanentBuffs/" + textureName;
    }
}
