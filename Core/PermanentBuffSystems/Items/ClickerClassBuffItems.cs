namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class ClickerClassBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.ClickerClass.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] ClickerClassEffects = [
                //potions
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.ClickerClass.Mod, "InfluenceBuff")),
                //stations
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.ClickerClass.Mod, "DesktopComputerBuff"), (int)Constants.EffectTypes.Station)
            ];

            foreach (var newEffect in ClickerClassEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.ClickerClass.Mod, "InfluencePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ClickerClass.Mod, "InfluenceBuff")], 30, "PermanentInfluence"),
                //stations
                new NewBuffItem(Common.GetModItem(CrossModSupport.ClickerClass.Mod, "DesktopComputer"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ClickerClass.Mod, "DesktopComputerBuff")], 3, "PermanentDesktopComputer")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentClickerClass =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ClickerClass.Mod, "InfluenceBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ClickerClass.Mod, "DesktopComputerBuff")]
            ];

            List<int> PermanentClickerClassIngredients =
            [
                Common.GetModItem(QoLCompendium.Instance, "PermanentInfluence"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentDesktopComputer")
            ];

            NewCombinedBuffItem newCombinedBuffItem = new("PermanentClickerClass", PermanentClickerClass, PermanentClickerClassIngredients);
            ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);
        }
    }
}
