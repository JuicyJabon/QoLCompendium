namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class VitalityBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Vitality.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] VitalityEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Vitality.Mod, "ArmorPiercingBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Vitality.Mod, "SpriteCranberryBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Vitality.Mod, "LeapingBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Vitality.Mod, "TranquillityBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Vitality.Mod, "TravelsenseBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Vitality.Mod, "WarriorBuff"))
            ];

            foreach (var newEffect in VitalityEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.Vitality.Mod, "ArmorPiercingPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "ArmorPiercingBuff")], 30, "PermanentArmorPiercing"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Vitality.Mod, "SpriteCranberry"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "SpriteCranberryBuff")], 30, "PermanentCranberrySoda"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Vitality.Mod, "LeapingPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "LeapingBuff")], 30, "PermanentLeaping"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Vitality.Mod, "TranquillityPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "TranquillityBuff")], 30, "PermanentTranquility"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Vitality.Mod, "TravelsensePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "TravelsenseBuff")], 30, "PermanentTravelsense"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Vitality.Mod, "WarriorPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "WarriorBuff")], 30, "PermanentWarrior")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentVitality =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "ArmorPiercingBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "SpriteCranberryBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "LeapingBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "TranquillityBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "TravelsenseBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Vitality.Mod, "WarriorBuff")]
            ];
            List<int> PermanentVitalityIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentArmorPiercing"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCranberrySoda"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLeaping"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTranquility"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTravelsense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWarrior")];

            NewCombinedBuffItem[] CombinedBuffItems = [new NewCombinedBuffItem("PermanentVitality", PermanentVitality, PermanentVitalityIngredients)];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);
        }
    }
}
