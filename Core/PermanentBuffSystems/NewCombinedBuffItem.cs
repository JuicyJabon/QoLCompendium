namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class NewCombinedBuffItem
    {
        public Dictionary<BuffEffect, int> effects;
        public string displayName;
        public string itemName;
        public string textureName;

        public NewCombinedBuffItem(Dictionary<BuffEffect, int> effects, string itemName, string displayName, string textureName)
        {
            this.effects = effects;
            this.itemName = itemName;
            this.displayName = displayName;
            this.textureName = "QoLCompendium/Assets/Items/" + textureName;
        }
    }
}
