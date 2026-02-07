using VitalityMod.Buffs;
using VitalityMod.Items.MasterChef;
using VitalityMod.Items.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.Vitality.Name)]
    [ExtendsFromMod(CrossModSupport.Vitality.Name)]
    public static class VitalityBuffItems
    {
        public static NewBuffEffect[] VitalityEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<ArmorPiercingBuff>()),
            new NewBuffEffect(ModContent.BuffType<SpriteCranberryBuff>()),
            new NewBuffEffect(ModContent.BuffType<LeapingBuff>()),
            new NewBuffEffect(ModContent.BuffType<TranquillityBuff>()),
            new NewBuffEffect(ModContent.BuffType<TravelsenseBuff>()),
            new NewBuffEffect(ModContent.BuffType<WarriorBuff>())
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in VitalityEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<ArmorPiercingPotion>(), ModContent.BuffType<ArmorPiercingBuff>(), Common.AllEffects[ModContent.BuffType<ArmorPiercingBuff>()], 30, "PermanentArmorPiercing", "Permanent Armor Piercing"),
                new NewBuffItem(ModContent.ItemType<SpriteCranberry>(), ModContent.BuffType<SpriteCranberryBuff>(), Common.AllEffects[ModContent.BuffType<SpriteCranberryBuff>()], 30, "PermanentCranberrySoda", "Permanent Cranberry Soda"),
                new NewBuffItem(ModContent.ItemType<LeapingPotion>(), ModContent.BuffType<LeapingBuff>(), Common.AllEffects[ModContent.BuffType<LeapingBuff>()], 30, "PermanentLeaping", "Permanent Leaping"),
                new NewBuffItem(ModContent.ItemType<TranquillityPotion>(), ModContent.BuffType<TranquillityBuff>(), Common.AllEffects[ModContent.BuffType<TranquillityBuff>()], 30, "PermanentTranquility", "Permanent Tranquility"),
                new NewBuffItem(ModContent.ItemType<TravelsensePotion>(), ModContent.BuffType<TravelsenseBuff>(), Common.AllEffects[ModContent.BuffType<TravelsenseBuff>()], 30, "PermanentTravelsense", "Permanent Travelsense"),
                new NewBuffItem(ModContent.ItemType<WarriorPotion>(), ModContent.BuffType<WarriorBuff>(), Common.AllEffects[ModContent.BuffType<WarriorBuff>()], 30, "PermanentWarrior", "Permanent Warrior")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentVitality = new()
            {
                { Common.AllEffects[ModContent.BuffType<ArmorPiercingBuff>()], ModContent.BuffType<ArmorPiercingBuff>() },
                { Common.AllEffects[ModContent.BuffType<SpriteCranberryBuff>()], ModContent.BuffType<SpriteCranberryBuff>() },
                { Common.AllEffects[ModContent.BuffType<LeapingBuff>()], ModContent.BuffType<LeapingBuff>() },
                { Common.AllEffects[ModContent.BuffType<TranquillityBuff>()], ModContent.BuffType<TranquillityBuff>() },
                { Common.AllEffects[ModContent.BuffType<TravelsenseBuff>()], ModContent.BuffType<TravelsenseBuff>() },
                { Common.AllEffects[ModContent.BuffType<WarriorBuff>()], ModContent.BuffType<WarriorBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentVitality, "PermanentVitality", "Permanent Vitality", "PermanentVitality")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
