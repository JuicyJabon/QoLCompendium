namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class EverythingBuffItem
    {
        public static void LoadTasks()
        {
            Dictionary<BuffEffect, int> PermanentEverything = new();

            foreach (KeyValuePair<int, BuffEffect> effect in Common.AllEffects)
                PermanentEverything.Add(effect.Value, effect.Key);

            NewCombinedBuffItem newItem = new NewCombinedBuffItem(PermanentEverything, "PermanentEverything", "Permanent Everything", "PermanentEverything");
            CombinedBuffItem item = new(newItem.itemName, newItem.effects, newItem.displayName, newItem.textureName);
            QoLCompendium.Instance.AddContent(item);
        }
    }
}
