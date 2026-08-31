namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class SOTSBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.SecretsOfTheShadows.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] SOTSEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Assassination")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Bluefire")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Brittle")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "DoubleVision")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Harmony")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Nightmare")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "RippleBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Roughskin")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "SoulAccess")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "GoodVibes")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Vigor")),
            //stations
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "CyberneticEnhancements"), (int)Constants.EffectTypes.Station),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "DEFEBuff"), (int)Constants.EffectTypes.Station)
            ];

            foreach (var newEffect in SOTSEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "AssassinationPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Assassination")], 30, "PermanentAssassination"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "BluefirePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Bluefire")], 30, "PermanentBluefire"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "BrittlePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Brittle")], 30, "PermanentBrittle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "DoubleVisionPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "DoubleVision")], 30, "PermanentDoubleVision"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "HarmonyPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Harmony")], 30, "PermanentHarmony"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "NightmarePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Nightmare")], 30, "PermanentNightmare"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "RipplePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "RippleBuff")], 30, "PermanentRipple"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "RoughskinPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Roughskin")], 30, "PermanentRoughskin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "SoulAccessPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "SoulAccess")], 30, "PermanentSoulAccess"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "VibePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "GoodVibes")], 30, "PermanentVibe"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "VigorPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Vigor")], 30, "PermanentVigor"),
                //stations
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "DigitalDisplay"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "CyberneticEnhancements")], 3, "PermanentDigitalDisplay"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "ElectromagneticDeterrent"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "DEFEBuff")], 3, "PermanentElectromagneticDeterrent")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentSecretsOfTheShadows =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Assassination")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Bluefire")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Brittle")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "DoubleVision")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Harmony")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Nightmare")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "RippleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Roughskin")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "SoulAccess")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "GoodVibes")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "Vigor")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "CyberneticEnhancements")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SecretsOfTheShadows.Mod, "DEFEBuff")]
            ];
            List<int> PermanentSecretsOfTheShadowsIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAssassination"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBluefire"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBrittle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDoubleVision"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHarmony"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNightmare"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRipple"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRoughskin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoulAccess"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVibe"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVigor"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDigitalDisplay"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentElectromagneticDeterrent")];

            NewCombinedBuffItem[] CombinedBuffItems = [new NewCombinedBuffItem("PermanentSecretsOfTheShadows", PermanentSecretsOfTheShadows, PermanentSecretsOfTheShadowsIngredients)];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);
        }
    }
}
