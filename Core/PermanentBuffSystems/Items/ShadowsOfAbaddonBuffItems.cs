using SacredTools.Buffs;
using SacredTools.Content.Buffs.Potions;
using SacredTools.Content.Buffs.Potions.Neil;
using SacredTools.Content.Items.Potions;
using SacredTools.Content.Items.Potions.Neil;
using SacredTools.Items.Placeable;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(ModConditions.shadowsOfAbaddonName)]
    [ExtendsFromMod(ModConditions.shadowsOfAbaddonName)]
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
            new NewBuffEffect(ModContent.BuffType<FruitBuff>(), (int)Common.EffectTypes.Arena),
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
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<SentryPotion>(), ModContent.BuffType<SentryBuff>(), Common.AllEffects[ModContent.BuffType<SentryBuff>()], 30, "PermanentCommanding", "Permanent Commanding"),
                new NewBuffItem(ModContent.ItemType<DayStatsPotion>(), ModContent.BuffType<DayStatsBuff>(), Common.AllEffects[ModContent.BuffType<DayStatsBuff>()], 30, "PermanentDawn", "Permanent Dawn"),
                new NewBuffItem(ModContent.ItemType<NightStatsPotion>(), ModContent.BuffType<NightStatsBuff>(), Common.AllEffects[ModContent.BuffType<NightStatsBuff>()], 30, "PermanentDusk", "Permanent Dusk"),
                new NewBuffItem(ModContent.ItemType<ExtraEndurancePotion>(), ModContent.BuffType<ExtraEnduranceBuff>(), Common.AllEffects[ModContent.BuffType<ExtraEnduranceBuff>()], 30, "PermanentDraconiumSkin", "Permanent Draconium Skin"),
                new NewBuffItem(ModContent.ItemType<ComboPotion>(), ModContent.BuffType<ComboBuff>(), Common.AllEffects[ModContent.BuffType<ComboBuff>()], 30, "PermanentEssenceOfFury", "Permanent Essence of Fury"),
                new NewBuffItem(ModContent.ItemType<FlariumInfernoImmunityPotion>(), ModContent.BuffType<FlariumInfernoImmunityBuff>(), Common.AllEffects[ModContent.BuffType<FlariumInfernoImmunityBuff>()], 30, "PermanentFlareElixir", "Permanent Flare Elixir"),
                new NewBuffItem(ModContent.ItemType<NeilShinePotion>(), ModContent.BuffType<NeilShineBuff>(), Common.AllEffects[ModContent.BuffType<NeilShineBuff>()], 30, "PermanentFlariumFlurry", "Permanent Flarium Flurry"),
                new NewBuffItem(ModContent.ItemType<NeilCritDamagePotion>(), ModContent.BuffType<NeilCritDamageBuff>(), Common.AllEffects[ModContent.BuffType<NeilCritDamageBuff>()], 30, "PermanentFrenziedAnimosity", "Permanent Frenzied Animosity"),
                new NewBuffItem(ModContent.ItemType<NeilBossDamagePotion>(), ModContent.BuffType<NeilBossDamageBuff>(), Common.AllEffects[ModContent.BuffType<NeilBossDamageBuff>()], 30, "PermanentH", "Permanent h"),
                new NewBuffItem(ModContent.ItemType<FastFallPotion>(), ModContent.BuffType<FastFallBuff>(), Common.AllEffects[ModContent.BuffType<FastFallBuff>()], 30, "PermanentHeavyFall", "Permanent Heavy Fall"),
                new NewBuffItem(ModContent.ItemType<HolyShinePotion>(), ModContent.BuffType<HolyShineBuff>(), Common.AllEffects[ModContent.BuffType<HolyShineBuff>()], 30, "PermanentHolyLight", "Permanent Holy Light"),
                new NewBuffItem(ModContent.ItemType<SkeletonMinionPotion>(), ModContent.BuffType<SkeletonMinionBuff>(), Common.AllEffects[ModContent.BuffType<SkeletonMinionBuff>()], 30, "PermanentMilk", "Permanent Milk"),
                new NewBuffItem(ModContent.ItemType<MoonlightPotion>(), ModContent.BuffType<MoonlightBuff>(), Common.AllEffects[ModContent.BuffType<MoonlightBuff>()], 30, "PermanentMoonlight", "Permanent Moonlight"),
                new NewBuffItem(ModContent.ItemType<NightmarePotion>(), ModContent.BuffType<NightmareBuff>(), Common.AllEffects[ModContent.BuffType<NightmareBuff>()], 30, "PermanentNightmareFuel", "Permanent Nightmare Fuel"),
                new NewBuffItem(ModContent.ItemType<ThrownPotion>(), ModContent.BuffType<ThrownBuff>(), Common.AllEffects[ModContent.BuffType<ThrownBuff>()], 30, "PermanentNinjaFocus", "Permanent Ninja Focus"),
                new NewBuffItem(ModContent.ItemType<NeilPolarizePotion>(), ModContent.BuffType<NeilPolarizeBuff>(), Common.AllEffects[ModContent.BuffType<NeilPolarizeBuff>()], 30, "PermanentNumberOne", "Permanent Number One"),
                new NewBuffItem(ModContent.ItemType<ThrownSpeedPotion>(), ModContent.BuffType<ThrownSpeedBuff>(), Common.AllEffects[ModContent.BuffType<ThrownSpeedBuff>()], 30, "PermanentRobustMuscle", "Permanent Robust Muscle"),
                new NewBuffItem(ModContent.ItemType<FewerSpawnsPotion>(), ModContent.BuffType<FewerSpawnsBuff>(), Common.AllEffects[ModContent.BuffType<FewerSpawnsBuff>()], 30, "PermanentSerene", "Permanent Serene"),
                new NewBuffItem(ModContent.ItemType<NeilSpeedPotion>(), ModContent.BuffType<NeilSpeedBuff>(), Common.AllEffects[ModContent.BuffType<NeilSpeedBuff>()], 30, "PermanentSeriousSyrusianSyrup", "Permanent Serious Syrusian Syrup"),
                new NewBuffItem(ModContent.ItemType<ExtraFishPotion>(), ModContent.BuffType<ExtraFishBuff>(), Common.AllEffects[ModContent.BuffType<ExtraFishBuff>()], 30, "PermanentShoalFishing", "Permanent Shoal Fishing"),
                new NewBuffItem(ModContent.ItemType<SuppressionPotion>(), ModContent.BuffType<SuppressionBuff>(), Common.AllEffects[ModContent.BuffType<SuppressionBuff>()], 30, "PermanentSuppression", "Permanent Suppression"),
                new NewBuffItem(ModContent.ItemType<JumpBoostPotion>(), ModContent.BuffType<JumpBoostBuff>(), Common.AllEffects[ModContent.BuffType<JumpBoostBuff>()], 30, "PermanentTowerSurmount", "Permanent Tower Surmount"),
                new NewBuffItem(ModContent.ItemType<SandstormWindImmunityPotion>(), ModContent.BuffType<SandstormWindImmunityBuff>(), Common.AllEffects[ModContent.BuffType<SandstormWindImmunityBuff>()], 30, "PermanentWindResistance", "Permanent Wind Resistance"),
                //arena
                new NewBuffItem(ModContent.ItemType<FruitLantern>(), ModContent.BuffType<FruitBuff>(), Common.AllEffects[ModContent.BuffType<FruitBuff>()], 3, "PermanentLifeFruitLantern", "Permanent Life Fruit Lantern"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonDamage = new()
            {
                { Common.AllEffects[ModContent.BuffType<SentryBuff>()], ModContent.BuffType<SentryBuff>() },
                { Common.AllEffects[ModContent.BuffType<DayStatsBuff>()], ModContent.BuffType<DayStatsBuff>() },
                { Common.AllEffects[ModContent.BuffType<NightStatsBuff>()], ModContent.BuffType<NightStatsBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilCritDamageBuff>()], ModContent.BuffType<NeilCritDamageBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilBossDamageBuff>()], ModContent.BuffType<NeilBossDamageBuff>() },
                { Common.AllEffects[ModContent.BuffType<SkeletonMinionBuff>()], ModContent.BuffType<SkeletonMinionBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoonlightBuff>()], ModContent.BuffType<MoonlightBuff>() },
                { Common.AllEffects[ModContent.BuffType<NightmareBuff>()], ModContent.BuffType<NightmareBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonDefense = new()
            {
                { Common.AllEffects[ModContent.BuffType<ExtraEnduranceBuff>()], ModContent.BuffType<ExtraEnduranceBuff>() },
                { Common.AllEffects[ModContent.BuffType<ComboBuff>()], ModContent.BuffType<ComboBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlariumInfernoImmunityBuff>()], ModContent.BuffType<FlariumInfernoImmunityBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilPolarizeBuff>()], ModContent.BuffType<NeilPolarizeBuff>() },
                { Common.AllEffects[ModContent.BuffType<SuppressionBuff>()], ModContent.BuffType<SuppressionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FruitBuff>()], ModContent.BuffType<FruitBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonRevenant = new()
            {
                { Common.AllEffects[ModContent.BuffType<ThrownBuff>()], ModContent.BuffType<ThrownBuff>() },
                { Common.AllEffects[ModContent.BuffType<ThrownSpeedBuff>()], ModContent.BuffType<ThrownSpeedBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonMovement = new()
            {
                { Common.AllEffects[ModContent.BuffType<FastFallBuff>()], ModContent.BuffType<FastFallBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilSpeedBuff>()], ModContent.BuffType<NeilSpeedBuff>() },
                { Common.AllEffects[ModContent.BuffType<JumpBoostBuff>()], ModContent.BuffType<JumpBoostBuff>() },
                { Common.AllEffects[ModContent.BuffType<SandstormWindImmunityBuff>()], ModContent.BuffType<SandstormWindImmunityBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddonFarming = new()
            {
                { Common.AllEffects[ModContent.BuffType<NeilShineBuff>()], ModContent.BuffType<NeilShineBuff>() },
                { Common.AllEffects[ModContent.BuffType<HolyShineBuff>()], ModContent.BuffType<HolyShineBuff>() },
                { Common.AllEffects[ModContent.BuffType<FewerSpawnsBuff>()], ModContent.BuffType<FewerSpawnsBuff>() },
                { Common.AllEffects[ModContent.BuffType<ExtraFishBuff>()], ModContent.BuffType<ExtraFishBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentShadowsOfAbaddon = new()
            {
                { Common.AllEffects[ModContent.BuffType<SentryBuff>()], ModContent.BuffType<SentryBuff>() },
                { Common.AllEffects[ModContent.BuffType<DayStatsBuff>()], ModContent.BuffType<DayStatsBuff>() },
                { Common.AllEffects[ModContent.BuffType<NightStatsBuff>()], ModContent.BuffType<NightStatsBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilCritDamageBuff>()], ModContent.BuffType<NeilCritDamageBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilBossDamageBuff>()], ModContent.BuffType<NeilBossDamageBuff>() },
                { Common.AllEffects[ModContent.BuffType<SkeletonMinionBuff>()], ModContent.BuffType<SkeletonMinionBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoonlightBuff>()], ModContent.BuffType<MoonlightBuff>() },
                { Common.AllEffects[ModContent.BuffType<NightmareBuff>()], ModContent.BuffType<NightmareBuff>() },
                { Common.AllEffects[ModContent.BuffType<ExtraEnduranceBuff>()], ModContent.BuffType<ExtraEnduranceBuff>() },
                { Common.AllEffects[ModContent.BuffType<ComboBuff>()], ModContent.BuffType<ComboBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlariumInfernoImmunityBuff>()], ModContent.BuffType<FlariumInfernoImmunityBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilPolarizeBuff>()], ModContent.BuffType<NeilPolarizeBuff>() },
                { Common.AllEffects[ModContent.BuffType<SuppressionBuff>()], ModContent.BuffType<SuppressionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FruitBuff>()], ModContent.BuffType<FruitBuff>() },
                { Common.AllEffects[ModContent.BuffType<ThrownBuff>()], ModContent.BuffType<ThrownBuff>() },
                { Common.AllEffects[ModContent.BuffType<ThrownSpeedBuff>()], ModContent.BuffType<ThrownSpeedBuff>() },
                { Common.AllEffects[ModContent.BuffType<FastFallBuff>()], ModContent.BuffType<FastFallBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilSpeedBuff>()], ModContent.BuffType<NeilSpeedBuff>() },
                { Common.AllEffects[ModContent.BuffType<JumpBoostBuff>()], ModContent.BuffType<JumpBoostBuff>() },
                { Common.AllEffects[ModContent.BuffType<SandstormWindImmunityBuff>()], ModContent.BuffType<SandstormWindImmunityBuff>() },
                { Common.AllEffects[ModContent.BuffType<NeilShineBuff>()], ModContent.BuffType<NeilShineBuff>() },
                { Common.AllEffects[ModContent.BuffType<HolyShineBuff>()], ModContent.BuffType<HolyShineBuff>() },
                { Common.AllEffects[ModContent.BuffType<FewerSpawnsBuff>()], ModContent.BuffType<FewerSpawnsBuff>() },
                { Common.AllEffects[ModContent.BuffType<ExtraFishBuff>()], ModContent.BuffType<ExtraFishBuff>() }
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
            }
        }
    }
}
