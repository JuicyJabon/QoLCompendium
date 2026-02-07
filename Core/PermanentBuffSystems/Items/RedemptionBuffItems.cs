using Redemption.Buffs;
using Redemption.Items.Placeable.Furniture.Misc;
using Redemption.Items.Usable.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.Redemption.Name)]
    [ExtendsFromMod(CrossModSupport.Redemption.Name)]
    public static class RedemptionBuffItems
    {
        public static NewBuffEffect[] RedemptionEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<CharismaPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<EvilJellyBuff>()),
            new NewBuffEffect(ModContent.BuffType<HydraCorrosionBuff>()),
            new NewBuffEffect(ModContent.BuffType<SkirmishBuff>()),
            new NewBuffEffect(ModContent.BuffType<VendettaPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<VigourousBuff>()),
            //arena
            new NewBuffEffect(ModContent.BuffType<MoonflareCandleBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<SoulboundBuff>(), (int)Common.EffectTypes.Arena),
            //stations
            new NewBuffEffect(ModContent.BuffType<EnergyStationBuff>(), (int)Common.EffectTypes.Station),
            //flasks
            new NewBuffEffect(ModContent.BuffType<BileFlaskBuff>(), (int) Common.EffectTypes.Flask),
            new NewBuffEffect(ModContent.BuffType<ExplosiveFlaskBuff>(), (int)Common.EffectTypes.Flask)
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in RedemptionEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<CharismaPotion>(), ModContent.BuffType<CharismaPotionBuff>(), Common.AllEffects[ModContent.BuffType<CharismaPotionBuff>()], 30, "PermanentCharisma", "Permanent Charisma"),
                new NewBuffItem(ModContent.ItemType<EvilJelly>(), ModContent.BuffType<EvilJellyBuff>(), Common.AllEffects[ModContent.BuffType<EvilJellyBuff>()], 30, "PermanentEvilJelly", "Permanent Evil Jelly"),
                new NewBuffItem(ModContent.ItemType<HydraCorrosionPotion>(), ModContent.BuffType<HydraCorrosionBuff>(), Common.AllEffects[ModContent.BuffType<HydraCorrosionBuff>()], 30, "PermanentHydricAcid", "Permanent Hydric Acid"),
                new NewBuffItem(ModContent.ItemType<SkirmishPotion>(), ModContent.BuffType<SkirmishBuff>(), Common.AllEffects[ModContent.BuffType<SkirmishBuff>()], 30, "PermanentSkirmish", "Permanent Skirmish"),
                new NewBuffItem(ModContent.ItemType<VendettaPotion>(), ModContent.BuffType<VendettaPotionBuff>(), Common.AllEffects[ModContent.BuffType<VendettaPotionBuff>()], 30, "PermanentVendetta", "Permanent Vendetta"),
                new NewBuffItem(ModContent.ItemType<VigourousPotion>(), ModContent.BuffType<VigourousBuff>(), Common.AllEffects[ModContent.BuffType<VigourousBuff>()], 30, "PermanentVigourous", "Permanent Vigourous"),
                //flasks
                new NewBuffItem(ModContent.ItemType<BileFlask>(), ModContent.BuffType<BileFlaskBuff>(), Common.AllEffects[ModContent.BuffType<BileFlaskBuff>()], 30, "PermanentFlaskOfBile", "Permanent Flask of Bile"),
                new NewBuffItem(ModContent.ItemType<NitroglycerineFlask>(), ModContent.BuffType<ExplosiveFlaskBuff>(), Common.AllEffects[ModContent.BuffType<ExplosiveFlaskBuff>()], 30, "PermanentFlaskOfNitroglycerine", "Permanent Flask of Nitroglycerine"),
                //arena
                new NewBuffItem(ModContent.ItemType<MoonflareCandle>(), ModContent.BuffType<MoonflareCandleBuff>(), Common.AllEffects[ModContent.BuffType<MoonflareCandleBuff>()], 3, "PermanentMoonflareCandle", "Permanent Moonflare Candle"),
                new NewBuffItem(ModContent.ItemType<SoulCandle>(), ModContent.BuffType<SoulboundBuff>(), Common.AllEffects[ModContent.BuffType<SoulboundBuff>()], 3, "PermanentSoulCandle", "Permanent Soul Candle"),
                //stations
                new NewBuffItem(ModContent.ItemType<EnergyStation>(), ModContent.BuffType<EnergyStationBuff>(), Common.AllEffects[ModContent.BuffType<EnergyStationBuff>()], 3, "PermanentEnergyStation", "Permanent Energy Station")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentRedemption = new()
            {
                { Common.AllEffects[ModContent.BuffType<CharismaPotionBuff>()], ModContent.BuffType<CharismaPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<EvilJellyBuff>()], ModContent.BuffType<EvilJellyBuff>() },
                { Common.AllEffects[ModContent.BuffType<HydraCorrosionBuff>()], ModContent.BuffType<HydraCorrosionBuff>() },
                { Common.AllEffects[ModContent.BuffType<SkirmishBuff>()], ModContent.BuffType<SkirmishBuff>() },
                { Common.AllEffects[ModContent.BuffType<VendettaPotionBuff>()], ModContent.BuffType<VendettaPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<VigourousBuff>()], ModContent.BuffType<VigourousBuff>() },
                { Common.AllEffects[ModContent.BuffType<BileFlaskBuff>()], ModContent.BuffType<BileFlaskBuff>() },
                { Common.AllEffects[ModContent.BuffType<ExplosiveFlaskBuff>()], ModContent.BuffType<ExplosiveFlaskBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoonflareCandleBuff>()], ModContent.BuffType<MoonflareCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<SoulboundBuff>()], ModContent.BuffType<SoulboundBuff>() },
                { Common.AllEffects[ModContent.BuffType<EnergyStationBuff>()], ModContent.BuffType<EnergyStationBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentRedemption, "PermanentRedemption", "Permanent Redemption", "PermanentRedemption")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
