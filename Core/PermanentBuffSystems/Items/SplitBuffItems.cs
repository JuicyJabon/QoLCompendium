using Split.Content.Potions;
using Split.Content.Potions.Diligence;
using Split.Content.Potions.Gelid;
using Split.Content.Tiles.Misc.Keystone;
using Split.Content.Tiles.Misc.WarningSign;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class SplitBuffItems
    {
        public static NewBuffEffect[] SplitEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<AnxiousnessBuff>()),
            new NewBuffEffect(ModContent.BuffType<AttractionBuff>()),
            new NewBuffEffect(ModContent.BuffType<DiligenceBuff>()),
            new NewBuffEffect(ModContent.BuffType<GelidStarPower>()),
            new NewBuffEffect(ModContent.BuffType<PurityBuff>()),
            //stations
            new NewBuffEffect(ModContent.BuffType<StrategicAdvantage>(), (int)Constants.EffectTypes.Station),
            new NewBuffEffect(ModContent.BuffType<HouseOfEvil>(), (int)Constants.EffectTypes.Station)
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in SplitEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Constants.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<AnxiousnessPotion>(), ModContent.BuffType<AnxiousnessBuff>(), Constants.AllEffects[ModContent.BuffType<AnxiousnessBuff>()], 30, "PermanentAnxiety", "Permanent Anxiety"),
                new NewBuffItem(ModContent.ItemType<AttractionPotion>(), ModContent.BuffType<AttractionBuff>(), Constants.AllEffects[ModContent.BuffType<AttractionBuff>()], 30, "PermanentAttraction", "Permanent Attraction"),
                new NewBuffItem(ModContent.ItemType<DiligencePotion>(), ModContent.BuffType<DiligenceBuff>(), Constants.AllEffects[ModContent.BuffType<DiligenceBuff>()], 30, "PermanentDiligence", "Permanent Diligence"),
                new NewBuffItem(ModContent.ItemType<GelidManaPotion>(), ModContent.BuffType<GelidStarPower>(), Constants.AllEffects[ModContent.BuffType<GelidStarPower>()], 30, "PermanentGelidMana", "Permanent Gelid Mana"),
                new NewBuffItem(ModContent.ItemType<PurifyingPotion>(), ModContent.BuffType<PurityBuff>(), Constants.AllEffects[ModContent.BuffType<PurityBuff>()], 30, "PermanentPurity", "Permanent Purity"),
                //stations
                new NewBuffItem(ModContent.ItemType<Keystone>(), ModContent.BuffType<StrategicAdvantage>(), Constants.AllEffects[ModContent.BuffType<StrategicAdvantage>()], 3, "PermanentKeystone", "Permanent Keystone"),
                new NewBuffItem(ModContent.ItemType<WarningSign>(), ModContent.BuffType<HouseOfEvil>(), Constants.AllEffects[ModContent.BuffType<HouseOfEvil>()], 3, "PermanentWarningSign", "Permanent Warning Sign")
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
            Dictionary<BuffEffect, int> PermanentSplit = new()
            {
                { Constants.AllEffects[ModContent.BuffType<AnxiousnessBuff>()], ModContent.BuffType<AnxiousnessBuff>() },
                { Constants.AllEffects[ModContent.BuffType<AttractionBuff>()], ModContent.BuffType<AttractionBuff>() },
                { Constants.AllEffects[ModContent.BuffType<DiligenceBuff>()], ModContent.BuffType<DiligenceBuff>() },
                { Constants.AllEffects[ModContent.BuffType<GelidStarPower>()], ModContent.BuffType<GelidStarPower>() },
                { Constants.AllEffects[ModContent.BuffType<PurityBuff>()], ModContent.BuffType<PurityBuff>() },
                { Constants.AllEffects[ModContent.BuffType<HouseOfEvil>()], ModContent.BuffType<HouseOfEvil>() },
                { Constants.AllEffects[ModContent.BuffType<StrategicAdvantage>()], ModContent.BuffType<StrategicAdvantage>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentSplit, "PermanentSplit", "Permanent Split", "PermanentSplit")
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
