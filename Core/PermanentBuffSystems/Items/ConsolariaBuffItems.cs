using Consolaria.Content.Buffs;
using Consolaria.Content.Items.Consumables;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(ModConditions.consolariaName)]
    [ExtendsFromMod(ModConditions.consolariaName)]
    public static class ConsolariaBuffItems
    {
        public static NewBuffEffect[] ConsolariaEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<Drunk>()),
        ];

        public static void LoadTasks()
        {
            BaseItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in ConsolariaEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<Wiesnbrau>(), ModContent.BuffType<Drunk>(), Common.AllEffects[ModContent.BuffType<Drunk>()], 30, "PermanentWiesnbrau", "Permanent Wiesnbrau")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
