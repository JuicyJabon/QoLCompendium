using SpiritReforged.Content.Forest.Cloud.Items;
using SpiritReforged.Content.Forest.Misc;
using SpiritReforged.Content.Ocean.Items.KoiTotem;
using SpiritReforged.Content.Savanna.Items.Gar;
using SpiritReforged.Content.Snow;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.SpiritReforged.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritReforged.Name)]
    public static class SpiritReforgedBuffItems
    {
        public static NewBuffEffect[] SpiritReforgedEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff")),
            new NewBuffEffect(ModContent.BuffType<RemedyPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<FlightPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<DoubleJumpPotionBuff>()),
            //flasks
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff"), (int) Common.EffectTypes.Flask),
            //arena
            new NewBuffEffect(ModContent.BuffType<KoiTotemBuff>(), (int) Common.EffectTypes.Arena),
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in SpiritReforgedEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<QuenchPotion>(), Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff"), Common.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff")], 30, "PermanentQuenched", "Permanent Quenched"),
                new NewBuffItem(ModContent.ItemType<RemedyPotion>(), ModContent.BuffType<RemedyPotionBuff>(), Common.AllEffects[ModContent.BuffType<RemedyPotionBuff>()], 30, "PermanentRemedy", "Permanent Remedy"),
                new NewBuffItem(ModContent.ItemType<FlightPotion>(), ModContent.BuffType<FlightPotionBuff>(), Common.AllEffects[ModContent.BuffType<FlightPotionBuff>()], 30, "PermanentSRSoaring", "Permanent Soaring"),
                new NewBuffItem(ModContent.ItemType<DoubleJumpPotion>(), ModContent.BuffType<DoubleJumpPotionBuff>(), Common.AllEffects[ModContent.BuffType<DoubleJumpPotionBuff>()], 30, "PermanentSRZephyr", "Permanent Zephyr"),
                //flasks
                new NewBuffItem(ModContent.ItemType<FlaskOfFrost>(), Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff"), Common.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")], 30, "PermanentFlaskOfFrost", "Permanent Flask of Frost"),
                //arena
                new NewBuffItem(ModContent.ItemType<KoiTotem>(), ModContent.BuffType<KoiTotemBuff>(), Common.AllEffects[ModContent.BuffType<KoiTotemBuff>()], 3, "PermanentSRKoiTotem", "Permanent Koi Totem")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentSpiritReforged = new()
            {
                { Common.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff")], Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff") },
                { Common.AllEffects[ModContent.BuffType<RemedyPotionBuff>()], ModContent.BuffType<RemedyPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlightPotionBuff>()], ModContent.BuffType<FlightPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<DoubleJumpPotionBuff>()], ModContent.BuffType<DoubleJumpPotionBuff>() },
                { Common.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")], Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff") },
                { Common.AllEffects[ModContent.BuffType<KoiTotemBuff>()], ModContent.BuffType<KoiTotemBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentSpiritReforged, "PermanentSpiritReforged", "Permanent Spirit Reforged", "PermanentSpiritReforged"),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
