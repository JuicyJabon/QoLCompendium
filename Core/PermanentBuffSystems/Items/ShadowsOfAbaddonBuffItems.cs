namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class ShadowsOfAbaddonBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.ShadowsOfAbaddon.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] ShadowsOfAbaddonEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SentryBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "DayStatsBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NightStatsBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraEnduranceBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ComboBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FlariumInfernoImmunityBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilShineBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilCritDamageBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilBossDamageBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FastFallBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "HolyShineBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SkeletonMinionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "MoonlightBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NightmareBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilPolarizeBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownSpeedBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FewerSpawnsBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilSpeedBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraFishBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SuppressionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "JumpBoostBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SandstormWindImmunityBuff")),
            //arena
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FruitBuff"), (int)Constants.EffectTypes.Arena),
            ];

            foreach (var newEffect in ShadowsOfAbaddonEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "SentryPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SentryBuff")], 30, "PermanentCommanding"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "DayStatsPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "DayStatsBuff")], 30, "PermanentDawn"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NightStatsPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NightStatsBuff")], 30, "PermanentDusk"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraEndurancePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraEnduranceBuff")], 30, "PermanentDraconiumSkin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "ComboPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ComboBuff")], 30, "PermanentEssenceOfFury"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "FlariumInfernoImmunityPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FlariumInfernoImmunityBuff")], 30, "PermanentFlareElixir"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilShinePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilShineBuff")], 30, "PermanentFlariumFlurry"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilCritDamagePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilCritDamageBuff")], 30, "PermanentFrenziedAnimosity"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilBossDamagePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilBossDamageBuff")], 30, "PermanentH"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "FastFallPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FastFallBuff")], 30, "PermanentHeavyFall"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "HolyShinePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "HolyShineBuff")], 30, "PermanentHolyLight"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "SkeletonMinionPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SkeletonMinionBuff")], 30, "PermanentMilk"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "MoonlightPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "MoonlightBuff")], 30, "PermanentMoonlight"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NightmarePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NightmareBuff")], 30, "PermanentNightmareFuel"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownBuff")], 30, "PermanentNinjaFocus"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilPolarizePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilPolarizeBuff")], 30, "PermanentNumberOne"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownSpeedPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownSpeedBuff")], 30, "PermanentRobustMuscle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "FewerSpawnsPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FewerSpawnsBuff")], 30, "PermanentSerene"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilSpeedPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilSpeedBuff")], 30, "PermanentSeriousSyrusianSyrup"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraFishPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraFishBuff")], 30, "PermanentShoalFishing"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "SuppressionPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SuppressionBuff")], 30, "PermanentSuppression"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "JumpBoostPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "JumpBoostBuff")], 30, "PermanentTowerSurmount"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "SandstormWindImmunityPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SandstormWindImmunityBuff")], 30, "PermanentWindResistance"),
                //arena
                new NewBuffItem(Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "FruitLantern"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FruitBuff")], 3, "PermanentLifeFruitLantern"),
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentShadowsOfAbaddonDamage =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SentryBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "DayStatsBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NightStatsBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilCritDamageBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilBossDamageBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SkeletonMinionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "MoonlightBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NightmareBuff")]
            ];
            List<int> PermanentShadowsOfAbaddonDamageIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCommanding"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDawn"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDusk"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFrenziedAnimosity"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentH"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMilk"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoonlight"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNightmareFuel")];

            List<BuffEffect> PermanentShadowsOfAbaddonDefense =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraEnduranceBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ComboBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FlariumInfernoImmunityBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilPolarizeBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SuppressionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FruitBuff")]
            ];
            List<int> PermanentShadowsOfAbaddonDefenseIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDraconiumSkin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEssenceOfFury"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlareElixir"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNumberOne"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSuppression"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLifeFruitLantern")];

            List<BuffEffect> PermanentShadowsOfAbaddonRevenant =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ThrownSpeedBuff")]
            ];
            List<int> PermanentShadowsOfAbaddonRevenantIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNinjaFocus"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRobustMuscle")];

            List<BuffEffect> PermanentShadowsOfAbaddonMovement =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FastFallBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilSpeedBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "JumpBoostBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "SandstormWindImmunityBuff")]
            ];
            List<int> PermanentShadowsOfAbaddonMovementIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHeavyFall"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSeriousSyrusianSyrup"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTowerSurmount"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWindResistance")];

            List<BuffEffect> PermanentShadowsOfAbaddonFarming =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "NeilShineBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "HolyShineBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "FewerSpawnsBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.ShadowsOfAbaddon.Mod, "ExtraFishBuff")]
            ];
            List<int> PermanentShadowsOfAbaddonFarmingIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlariumFlurry"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHolyLight"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSerene"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShoalFishing")];

            List<BuffEffect> PermanentShadowsOfAbaddon = [];
            PermanentShadowsOfAbaddon.AddRange(PermanentShadowsOfAbaddonDamage);
            PermanentShadowsOfAbaddon.AddRange(PermanentShadowsOfAbaddonDefense);
            PermanentShadowsOfAbaddon.AddRange(PermanentShadowsOfAbaddonRevenant);
            PermanentShadowsOfAbaddon.AddRange(PermanentShadowsOfAbaddonMovement);
            PermanentShadowsOfAbaddon.AddRange(PermanentShadowsOfAbaddonFarming);

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem("PermanentShadowsOfAbaddonDamage", PermanentShadowsOfAbaddonDamage, PermanentShadowsOfAbaddonDamageIngredients),
                new NewCombinedBuffItem("PermanentShadowsOfAbaddonDefense", PermanentShadowsOfAbaddonDefense, PermanentShadowsOfAbaddonDefenseIngredients),
                new NewCombinedBuffItem("PermanentShadowsOfAbaddonRevenant", PermanentShadowsOfAbaddonRevenant, PermanentShadowsOfAbaddonRevenantIngredients),
                new NewCombinedBuffItem("PermanentShadowsOfAbaddonMovement", PermanentShadowsOfAbaddonMovement, PermanentShadowsOfAbaddonMovementIngredients),
                new NewCombinedBuffItem("PermanentShadowsOfAbaddonFarming", PermanentShadowsOfAbaddonFarming, PermanentShadowsOfAbaddonFarmingIngredients),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);

            List<int> PermanentShadowsOfAbaddonIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonRevenant"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonFarming")];

            NewCombinedBuffItem permanentShadowsOfAbaddonItem = new("PermanentShadowsOfAbaddon", PermanentShadowsOfAbaddon, PermanentShadowsOfAbaddonIngredients);
            CombinedBuffItem newPermanentShadowsOfAbaddon = new(permanentShadowsOfAbaddonItem.itemName, permanentShadowsOfAbaddonItem.textureName, permanentShadowsOfAbaddonItem.effects, permanentShadowsOfAbaddonItem.ingredients);
            QoLCompendium.Instance.AddContent(newPermanentShadowsOfAbaddon);
            Constants.AllCombinedBuffItems.Add(newPermanentShadowsOfAbaddon.Type);
        }
    }
}
