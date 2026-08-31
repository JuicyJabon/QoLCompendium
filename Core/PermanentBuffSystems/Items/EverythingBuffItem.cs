namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class EverythingBuffItem
    {
        public static void LoadTasks()
        {
            List<BuffEffect> PermanentEverything = [];

            foreach (var effect in Constants.AllEffects)
                PermanentEverything.Add(effect.Value);

            List<int> ingredients =
            [
                Common.GetModItem(QoLCompendium.Instance, "PermanentVanilla"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentCalamity"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentClickerClass"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourney"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrder"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentRedemption"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddon"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSecretsOfTheShadows"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassic"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritReforged"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSplit"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentThorium"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentVitality"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentWiesnbrau")
            ];

            NewCombinedBuffItem newItem = new("PermanentEverything", PermanentEverything, ingredients);
            CombinedBuffItem item = new(newItem.itemName, newItem.textureName, newItem.effects, newItem.ingredients);
            QoLCompendium.Instance.AddContent(item);
            Constants.AllCombinedBuffItems.Add(item.Type);
        }
    }
}
