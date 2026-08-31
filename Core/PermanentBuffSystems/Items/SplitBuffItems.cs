namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public class SplitBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Split.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] SplitEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Split.Mod, "AnxiousnessBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Split.Mod, "AttractionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Split.Mod, "DiligenceBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Split.Mod, "GelidStarPower")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Split.Mod, "PurityBuff")),
            //stations
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Split.Mod, "StrategicAdvantage"), (int)Constants.EffectTypes.Station),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Split.Mod, "HouseOfEvil"), (int)Constants.EffectTypes.Station)
            ];

            foreach (var newEffect in SplitEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.Split.Mod, "AnxiousnessPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "AnxiousnessBuff")], 30, "PermanentAnxiety"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Split.Mod, "AttractionPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "AttractionBuff")], 30, "PermanentAttraction"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Split.Mod, "DiligencePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "DiligenceBuff")], 30, "PermanentDiligence"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Split.Mod, "GelidManaPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "GelidStarPower")], 30, "PermanentGelidMana"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Split.Mod, "PurifyingPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "PurityBuff")], 30, "PermanentPurity"),
                //stations
                new NewBuffItem(Common.GetModItem(CrossModSupport.Split.Mod, "Keystone"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "StrategicAdvantage")], 3, "PermanentKeystone"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Split.Mod, "WarningSign"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "HouseOfEvil")], 3, "PermanentWarningSign")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentSplit =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "AnxiousnessBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "AttractionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "DiligenceBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "GelidStarPower")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "PurityBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "HouseOfEvil")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Split.Mod, "StrategicAdvantage")]
            ];
            List<int> PermanentSplitIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAnxiety"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAttraction"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDiligence"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGelidMana"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentPurity"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentKeystone"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWarningSign")];

            NewCombinedBuffItem[] CombinedBuffItems = [new NewCombinedBuffItem("PermanentSplit", PermanentSplit, PermanentSplitIngredients)];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);
        }
    }
}
