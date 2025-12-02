using SOTS.Buffs;
using SOTS.Items.Planetarium.Furniture;
using SOTS.Items.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(ModConditions.secretsOfTheShadowsName)]
    [ExtendsFromMod(ModConditions.secretsOfTheShadowsName)]
    public static class SOTSBuffItems
    {
        public static NewBuffEffect[] SOTSEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<Assassination>()),
            new NewBuffEffect(ModContent.BuffType<Bluefire>()),
            new NewBuffEffect(ModContent.BuffType<Brittle>()),
            new NewBuffEffect(ModContent.BuffType<DoubleVision>()),
            new NewBuffEffect(ModContent.BuffType<Harmony>()),
            new NewBuffEffect(ModContent.BuffType<Nightmare>()),
            new NewBuffEffect(ModContent.BuffType<RippleBuff>()),
            new NewBuffEffect(ModContent.BuffType<Roughskin>()),
            new NewBuffEffect(ModContent.BuffType<SoulAccess>()),
            new NewBuffEffect(ModContent.BuffType<GoodVibes>()),
            new NewBuffEffect(ModContent.BuffType<Vigor>()),
            //stations
            new NewBuffEffect(ModContent.BuffType<CyberneticEnhancements>(), (int)Common.EffectTypes.Station)
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in SOTSEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<AssassinationPotion>(), ModContent.BuffType<Assassination>(), Common.AllEffects[ModContent.BuffType<Assassination>()], 30, "PermanentAssassination", "Permanent Assassination"),
                new NewBuffItem(ModContent.ItemType<BluefirePotion>(), ModContent.BuffType<Bluefire>(), Common.AllEffects[ModContent.BuffType<Bluefire>()], 30, "PermanentBluefire", "Permanent Bluefire"),
                new NewBuffItem(ModContent.ItemType<BrittlePotion>(), ModContent.BuffType<Brittle>(), Common.AllEffects[ModContent.BuffType<Brittle>()], 30, "PermanentBrittle", "Permanent Brittle"),
                new NewBuffItem(ModContent.ItemType<DoubleVisionPotion>(), ModContent.BuffType<DoubleVision>(), Common.AllEffects[ModContent.BuffType<DoubleVision>()], 30, "PermanentDoubleVision", "Permanent Double Vision"),
                new NewBuffItem(ModContent.ItemType<HarmonyPotion>(), ModContent.BuffType<Harmony>(), Common.AllEffects[ModContent.BuffType<Harmony>()], 30, "PermanentHarmony", "Permanent Harmony"),
                new NewBuffItem(ModContent.ItemType<NightmarePotion>(), ModContent.BuffType<Nightmare>(), Common.AllEffects[ModContent.BuffType<Nightmare>()], 30, "PermanentNightmare", "Permanent Nightmare"),
                new NewBuffItem(ModContent.ItemType<RipplePotion>(), ModContent.BuffType<RippleBuff>(), Common.AllEffects[ModContent.BuffType<RippleBuff>()], 30, "PermanentRipple", "Permanent Ripple"),
                new NewBuffItem(ModContent.ItemType<RoughskinPotion>(), ModContent.BuffType<Roughskin>(), Common.AllEffects[ModContent.BuffType<Roughskin>()], 30, "PermanentRoughskin", "Permanent Roughskin"),
                new NewBuffItem(ModContent.ItemType<SoulAccessPotion>(), ModContent.BuffType<SoulAccess>(), Common.AllEffects[ModContent.BuffType<SoulAccess>()], 30, "PermanentSoulAccess", "Permanent Soul Access"),
                new NewBuffItem(ModContent.ItemType<VibePotion>(), ModContent.BuffType<GoodVibes>(), Common.AllEffects[ModContent.BuffType<GoodVibes>()], 30, "PermanentVibe", "Permanent Vibe"),
                new NewBuffItem(ModContent.ItemType<VigorPotion>(), ModContent.BuffType<Vigor>(), Common.AllEffects[ModContent.BuffType<Vigor>()], 30, "PermanentVigor", "Permanent Vigor"),
                //stations
                new NewBuffItem(ModContent.ItemType<DigitalDisplay>(), ModContent.BuffType<CyberneticEnhancements>(), Common.AllEffects[ModContent.BuffType<CyberneticEnhancements>()], 3, "PermanentDigitalDisplay", "Permanent Digital Display")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentSecretsOfTheShadows = new()
            {
                { Common.AllEffects[ModContent.BuffType<Assassination>()], ModContent.BuffType<Assassination>() },
                { Common.AllEffects[ModContent.BuffType<Bluefire>()], ModContent.BuffType<Bluefire>() },
                { Common.AllEffects[ModContent.BuffType<Brittle>()], ModContent.BuffType<Brittle>() },
                { Common.AllEffects[ModContent.BuffType<DoubleVision>()], ModContent.BuffType<DoubleVision>() },
                { Common.AllEffects[ModContent.BuffType<Harmony>()], ModContent.BuffType<Harmony>() },
                { Common.AllEffects[ModContent.BuffType<Nightmare>()], ModContent.BuffType<Nightmare>() },
                { Common.AllEffects[ModContent.BuffType<RippleBuff>()], ModContent.BuffType<RippleBuff>() },
                { Common.AllEffects[ModContent.BuffType<Roughskin>()], ModContent.BuffType<Roughskin>() },
                { Common.AllEffects[ModContent.BuffType<SoulAccess>()], ModContent.BuffType<SoulAccess>() },
                { Common.AllEffects[ModContent.BuffType<GoodVibes>()], ModContent.BuffType<GoodVibes>() },
                { Common.AllEffects[ModContent.BuffType<Vigor>()], ModContent.BuffType<Vigor>() },
                { Common.AllEffects[ModContent.BuffType<CyberneticEnhancements>()], ModContent.BuffType<CyberneticEnhancements>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentSecretsOfTheShadows, "PermanentSecretsOfTheShadows", "Permanent Secrets of the Shadows", "PermanentSecretsOfTheShadows")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
