using ClickerClass.Buffs;
using ClickerClass.Items.Consumables;
using ClickerClass.Items.Placeable;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(ModConditions.clickerClassName)]
    [ExtendsFromMod(ModConditions.clickerClassName)]
    public static class ClickerClassBuffItems
    {
        public static NewBuffEffect[] ClickerClassEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<InfluenceBuff>()),
            //stations
            new NewBuffEffect(ModContent.BuffType<DesktopComputerBuff>(), (int)Common.EffectTypes.Station)
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in ClickerClassEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<InfluencePotion>(), ModContent.BuffType<InfluenceBuff>(), Common.AllEffects[ModContent.BuffType<InfluenceBuff>()], 30, "PermanentInfluence", "Permanent Influence"),
                //stations
                new NewBuffItem(ModContent.ItemType<DesktopComputer>(), ModContent.BuffType<DesktopComputerBuff>(), Common.AllEffects[ModContent.BuffType<DesktopComputerBuff>()], 3, "PermanentDesktopComputer", "Permanent Desktop Computer")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentClickerClass = new()
            {
                { Common.AllEffects[ModContent.BuffType<InfluenceBuff>()], ModContent.BuffType<InfluenceBuff>() },
                { Common.AllEffects[ModContent.BuffType<DesktopComputerBuff>()], ModContent.BuffType<DesktopComputerBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentClickerClass, "PermanentClickerClass", "Permanent Clicker Class", "PermanentClickerClass")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
