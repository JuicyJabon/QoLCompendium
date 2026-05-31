using SacredTools.Buffs;
using SacredTools.Content.Buffs.Potions;
using SacredTools.Content.Buffs.Potions.Neil;
using SacredTools.Content.Items.Potions;
using SacredTools.Content.Items.Potions.Neil;
using SacredTools.Items.Placeable;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.ShadowsOfAbaddon.Name)]
    [ExtendsFromMod(CrossModSupport.ShadowsOfAbaddon.Name)]
    public static class ShadowsOfAbaddonBuffItems
    {
        public static NewBuffEffect[] ShadowsOfAbaddonEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<SentryBuff>()),
            new NewBuffEffect(ModContent.BuffType<DayStatsBuff>()),
            new NewBuffEffect(ModContent.BuffType<NightStatsBuff>()),
            new NewBuffEffect(ModContent.BuffType<ExtraEnduranceBuff>()),
            new NewBuffEffect(ModContent.BuffType<ComboBuff>()),
            new NewBuffEffect(ModContent.BuffType<FlariumInfernoImmunityBuff>()),
            new NewBuffEffect(ModContent.BuffType<NeilShineBuff>()),
            new NewBuffEffect(ModContent.BuffType<NeilCritDamageBuff>()),
            new NewBuffEffect(ModContent.BuffType<NeilBossDamageBuff>()),
            new NewBuffEffect(ModContent.BuffType<FastFallBuff>()),
            new NewBuffEffect(ModContent.BuffType<HolyShineBuff>()),
            new NewBuffEffect(ModContent.BuffType<SkeletonMinionBuff>()),
            new NewBuffEffect(ModContent.BuffType<MoonlightBuff>()),
            new NewBuffEffect(ModContent.BuffType<NightmareBuff>()),
            new NewBuffEffect(ModContent.BuffType<ThrownBuff>()),
            new NewBuffEffect(ModContent.BuffType<NeilPolarizeBuff>()),
            new NewBuffEffect(ModContent.BuffType<ThrownSpeedBuff>()),
            new NewBuffEffect(ModContent.BuffType<FewerSpawnsBuff>()),
            new NewBuffEffect(ModContent.BuffType<NeilSpeedBuff>()),
            new NewBuffEffect(ModContent.BuffType<ExtraFishBuff>()),
            new NewBuffEffect(ModContent.BuffType<SuppressionBuff>()),
            new NewBuffEffect(ModContent.BuffType<JumpBoostBuff>()),
            new NewBuffEffect(ModContent.BuffType<SandstormWindImmunityBuff>()),
            //arena
            new NewBuffEffect(ModContent.BuffType<FruitBuff>(), (int)Constants.EffectTypes.Arena),
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in ShadowsOfAbaddonEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Constants.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<SentryPotion>(), ModContent.BuffType<SentryBuff>(), Constants.AllEffects[ModContent.BuffType<SentryBuff>()], 30, "PermanentCommanding", "Permanent Commanding"),
                new NewBuffItem(ModContent.ItemType<DayStatsPotion>(), ModContent.BuffType<DayStatsBuff>(), Constants.AllEffects[ModContent.BuffType<DayStatsBuff>()], 30, "PermanentDawn", "Permanent Dawn"),
                new NewBuffItem(ModContent.ItemType<NightStatsPotion>(), ModContent.BuffType<NightStatsBuff>(), Constants.AllEffects[ModContent.BuffType<NightStatsBuff>()], 30, "PermanentDusk", "Permanent Dusk"),
                new NewBuffItem(ModContent.ItemType<ExtraEndurancePotion>(), ModContent.BuffType<ExtraEnduranceBuff>(), Constants.AllEffects[ModContent.BuffType<ExtraEnduranceBuff>()], 30, "PermanentDraconiumSkin", "Permanent Draconium Skin"),
                new NewBuffItem(ModContent.ItemType<ComboPotion>(), ModContent.BuffType<ComboBuff>(), Constants.AllEffects[ModContent.BuffType<ComboBuff>()], 30, "PermanentEssenceOfFury", "Permanent Essence of Fury"),
                new NewBuffItem(ModContent.ItemType<FlariumInfernoImmunityPotion>(), ModContent.BuffType<FlariumInfernoImmunityBuff>(), Constants.AllEffects[ModContent.BuffType<FlariumInfernoImmunityBuff>()], 30, "PermanentFlareElixir", "Permanent Flare Elixir"),
                new NewBuffItem(ModContent.ItemType<NeilShinePotion>(), ModContent.BuffType<NeilShineBuff>(), Constants.AllEffects[ModContent.BuffType<NeilShineBuff>()], 30, "PermanentFlariumFlurry", "Permanent Flarium Flurry"),
                new NewBuffItem(ModContent.ItemType<NeilCritDamagePotion>(), ModContent.BuffType<NeilCritDamageBuff>(), Constants.AllEffects[ModContent.BuffType<NeilCritDamageBuff>()], 30, "PermanentFrenziedAnimosity", "Permanent Frenzied Animosity"),
                new NewBuffItem(ModContent.ItemType<NeilBossDamagePotion>(), ModContent.BuffType<NeilBossDamageBuff>(), Constants.AllEffects[ModContent.BuffType<NeilBossDamageBuff>()], 30, "PermanentH", "Permanent h"),
                new NewBuffItem(ModContent.ItemType<FastFallPotion>(), ModContent.BuffType<FastFallBuff>(), Constants.AllEffects[ModContent.BuffType<FastFallBuff>()], 30, "PermanentHeavyFall", "Permanent Heavy Fall"),
                new NewBuffItem(ModContent.ItemType<HolyShinePotion>(), ModContent.BuffType<HolyShineBuff>(), Constants.AllEffects[ModContent.BuffType<HolyShineBuff>()], 30, "PermanentHolyLight", "Permanent Holy Light"),
                new NewBuffItem(ModContent.ItemType<SkeletonMinionPotion>(), ModContent.BuffType<SkeletonMinionBuff>(), Constants.AllEffects[ModContent.BuffType<SkeletonMinionBuff>()], 30, "PermanentMilk", "Permanent Milk"),
                new NewBuffItem(ModContent.ItemType<MoonlightPotion>(), ModContent.BuffType<MoonlightBuff>(), Constants.AllEffects[ModContent.BuffType<MoonlightBuff>()], 30, "PermanentMoonlight", "Permanent Moonlight"),
                new NewBuffItem(ModContent.ItemType<NightmarePotion>(), ModContent.BuffType<NightmareBuff>(), Constants.AllEffects[ModContent.BuffType<NightmareBuff>()], 30, "PermanentNightmareFuel", "Permanent Nightmare Fuel"),
                new NewBuffItem(ModContent.ItemType<ThrownPotion>(), ModContent.BuffType<ThrownBuff>(), Constants.AllEffects[ModContent.BuffType<ThrownBuff>()], 30, "PermanentNinjaFocus", "Permanent Ninja Focus"),
                new NewBuffItem(ModContent.ItemType<NeilPolarizePotion>(), ModContent.BuffType<NeilPolarizeBuff>(), Constants.AllEffects[ModContent.BuffType<NeilPolarizeBuff>()], 30, "PermanentNumberOne", "Permanent Number One"),
                new NewBuffItem(ModContent.ItemType<ThrownSpeedPotion>(), ModContent.BuffType<ThrownSpeedBuff>(), Constants.AllEffects[ModContent.BuffType<ThrownSpeedBuff>()], 30, "PermanentRobustMuscle", "Permanent Robust Muscle"),
                new NewBuffItem(ModContent.ItemType<FewerSpawnsPotion>(), ModContent.BuffType<FewerSpawnsBuff>(), Constants.AllEffects[ModContent.BuffType<FewerSpawnsBuff>()], 30, "PermanentSerene", "Permanent Serene"),
                new NewBuffItem(ModContent.ItemType<NeilSpeedPotion>(), ModContent.BuffType<NeilSpeedBuff>(), Constants.AllEffects[ModContent.BuffType<NeilSpeedBuff>()], 30, "PermanentSeriousSyrusianSyrup", "Permanent Serious Syrusian Syrup"),
                new NewBuffItem(ModContent.ItemType<ExtraFishPotion>(), ModContent.BuffType<ExtraFishBuff>(), Constants.AllEffects[ModContent.BuffType<ExtraFishBuff>()], 30, "PermanentShoalFishing", "Permanent Shoal Fishing"),
                new NewBuffItem(ModContent.ItemType<SuppressionPotion>(), ModContent.BuffType<SuppressionBuff>(), Constants.AllEffects[ModContent.BuffType<SuppressionBuff>()], 30, "PermanentSuppression", "Permanent Suppression"),
                new NewBuffItem(ModContent.ItemType<JumpBoostPotion>(), ModContent.BuffType<JumpBoostBuff>(), Constants.AllEffects[ModContent.BuffType<JumpBoostBuff>()], 30, "PermanentTowerSurmount", "Permanent Tower Surmount"),
                new NewBuffItem(ModContent.ItemType<SandstormWindImmunityPotion>(), ModContent.BuffType<SandstormWindImmunityBuff>(), Constants.AllEffects[ModContent.BuffType<SandstormWindImmunityBuff>()], 30, "PermanentWindResistance", "Permanent Wind Resistance"),
                //arena
                new NewBuffItem(ModContent.ItemType<FruitLantern>(), ModContent.BuffType<FruitBuff>(), Constants.AllEffects[ModContent.BuffType<FruitBuff>()], 3, "PermanentLifeFruitLantern", "Permanent Life Fruit Lantern"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName);
                QoLCompendium.Instance.AddContent(item);
                Constants.AllBuffItems.Add(item.Type);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonDamage = new()
            {
                { Constants.AllEffects[ModContent.BuffType<SentryBuff>()], ModContent.BuffType<SentryBuff>() },
                { Constants.AllEffects[ModContent.BuffType<DayStatsBuff>()], ModContent.BuffType<DayStatsBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NightStatsBuff>()], ModContent.BuffType<NightStatsBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilCritDamageBuff>()], ModContent.BuffType<NeilCritDamageBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilBossDamageBuff>()], ModContent.BuffType<NeilBossDamageBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SkeletonMinionBuff>()], ModContent.BuffType<SkeletonMinionBuff>() },
                { Constants.AllEffects[ModContent.BuffType<MoonlightBuff>()], ModContent.BuffType<MoonlightBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NightmareBuff>()], ModContent.BuffType<NightmareBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonDefense = new()
            {
                { Constants.AllEffects[ModContent.BuffType<ExtraEnduranceBuff>()], ModContent.BuffType<ExtraEnduranceBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ComboBuff>()], ModContent.BuffType<ComboBuff>() },
                { Constants.AllEffects[ModContent.BuffType<FlariumInfernoImmunityBuff>()], ModContent.BuffType<FlariumInfernoImmunityBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilPolarizeBuff>()], ModContent.BuffType<NeilPolarizeBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SuppressionBuff>()], ModContent.BuffType<SuppressionBuff>() },
                { Constants.AllEffects[ModContent.BuffType<FruitBuff>()], ModContent.BuffType<FruitBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonRevenant = new()
            {
                { Constants.AllEffects[ModContent.BuffType<ThrownBuff>()], ModContent.BuffType<ThrownBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ThrownSpeedBuff>()], ModContent.BuffType<ThrownSpeedBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonMovement = new()
            {
                { Constants.AllEffects[ModContent.BuffType<FastFallBuff>()], ModContent.BuffType<FastFallBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilSpeedBuff>()], ModContent.BuffType<NeilSpeedBuff>() },
                { Constants.AllEffects[ModContent.BuffType<JumpBoostBuff>()], ModContent.BuffType<JumpBoostBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SandstormWindImmunityBuff>()], ModContent.BuffType<SandstormWindImmunityBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonFarming = new()
            {
                { Constants.AllEffects[ModContent.BuffType<NeilShineBuff>()], ModContent.BuffType<NeilShineBuff>() },
                { Constants.AllEffects[ModContent.BuffType<HolyShineBuff>()], ModContent.BuffType<HolyShineBuff>() },
                { Constants.AllEffects[ModContent.BuffType<FewerSpawnsBuff>()], ModContent.BuffType<FewerSpawnsBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ExtraFishBuff>()], ModContent.BuffType<ExtraFishBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddon = new()
            {
                { Constants.AllEffects[ModContent.BuffType<SentryBuff>()], ModContent.BuffType<SentryBuff>() },
                { Constants.AllEffects[ModContent.BuffType<DayStatsBuff>()], ModContent.BuffType<DayStatsBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NightStatsBuff>()], ModContent.BuffType<NightStatsBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilCritDamageBuff>()], ModContent.BuffType<NeilCritDamageBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilBossDamageBuff>()], ModContent.BuffType<NeilBossDamageBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SkeletonMinionBuff>()], ModContent.BuffType<SkeletonMinionBuff>() },
                { Constants.AllEffects[ModContent.BuffType<MoonlightBuff>()], ModContent.BuffType<MoonlightBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NightmareBuff>()], ModContent.BuffType<NightmareBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ExtraEnduranceBuff>()], ModContent.BuffType<ExtraEnduranceBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ComboBuff>()], ModContent.BuffType<ComboBuff>() },
                { Constants.AllEffects[ModContent.BuffType<FlariumInfernoImmunityBuff>()], ModContent.BuffType<FlariumInfernoImmunityBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilPolarizeBuff>()], ModContent.BuffType<NeilPolarizeBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SuppressionBuff>()], ModContent.BuffType<SuppressionBuff>() },
                { Constants.AllEffects[ModContent.BuffType<FruitBuff>()], ModContent.BuffType<FruitBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ThrownBuff>()], ModContent.BuffType<ThrownBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ThrownSpeedBuff>()], ModContent.BuffType<ThrownSpeedBuff>() },
                { Constants.AllEffects[ModContent.BuffType<FastFallBuff>()], ModContent.BuffType<FastFallBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilSpeedBuff>()], ModContent.BuffType<NeilSpeedBuff>() },
                { Constants.AllEffects[ModContent.BuffType<JumpBoostBuff>()], ModContent.BuffType<JumpBoostBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SandstormWindImmunityBuff>()], ModContent.BuffType<SandstormWindImmunityBuff>() },
                { Constants.AllEffects[ModContent.BuffType<NeilShineBuff>()], ModContent.BuffType<NeilShineBuff>() },
                { Constants.AllEffects[ModContent.BuffType<HolyShineBuff>()], ModContent.BuffType<HolyShineBuff>() },
                { Constants.AllEffects[ModContent.BuffType<FewerSpawnsBuff>()], ModContent.BuffType<FewerSpawnsBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ExtraFishBuff>()], ModContent.BuffType<ExtraFishBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentShadowsOfAbaddonDamage, "PermanentShadowsOfAbaddonDamage", "Permanent Shadows of Abaddon Damage", "PermanentShadowsOfAbaddonDamage"),
                new NewCombinedBuffItem(PermanentShadowsOfAbaddonDefense, "PermanentShadowsOfAbaddonDefense", "Permanent Shadows of Abaddon Defense", "PermanentShadowsOfAbaddonDefense"),
                new NewCombinedBuffItem(PermanentShadowsOfAbaddonRevenant, "PermanentShadowsOfAbaddonRevenant", "Permanent Shadows of Abaddon Revenant", "PermanentShadowsOfAbaddonRevenant"),
                new NewCombinedBuffItem(PermanentShadowsOfAbaddonMovement, "PermanentShadowsOfAbaddonMovement", "Permanent Shadows of Abaddon Movement", "PermanentShadowsOfAbaddonMovement"),
                new NewCombinedBuffItem(PermanentShadowsOfAbaddonFarming, "PermanentShadowsOfAbaddonFarming", "Permanent Shadows of Abaddon Farming", "PermanentShadowsOfAbaddonFarming"),
                new NewCombinedBuffItem(PermanentShadowsOfAbaddon, "PermanentShadowsOfAbaddon", "Permanent Shadows of Abaddon", "PermanentShadowsOfAbaddon"),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
                Constants.AllCombinedBuffItems.Add(item.Type);
            }
        }
    }
}
