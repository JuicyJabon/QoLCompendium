using ContinentOfJourney.Buffs;
using ContinentOfJourney.Items;
using ContinentOfJourney.Items.Placables;
using ContinentOfJourney.Items.StrangePotions;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public static class HomewardJourneyBuffItems
    {
        public static NewBuffEffect[] HomewardJourneyEffects = [
            //arena
            new NewBuffEffect(ModContent.BuffType<BushOfLifeBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<LifeLanternBuff>(), (int)Common.EffectTypes.Arena),
            //potions
            new NewBuffEffect(ModContent.BuffType<FlightBuff>()),
            new NewBuffEffect(ModContent.BuffType<FluorescentBerryBuff>()),
            new NewBuffEffect(ModContent.BuffType<HasteBuff>()),
            new NewBuffEffect(ModContent.BuffType<ReanimationBuff>()),
            new NewBuffEffect(ModContent.BuffType<YangPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<NerveFibreBuff>()),
            //flasks
            new NewBuffEffect(ModContent.BuffType<Flask_DivineFireBuff>(), (int)Common.EffectTypes.Flask),
            new NewBuffEffect(ModContent.BuffType<Flask_ForceBreakBuff>(), (int)Common.EffectTypes.Flask),
            new NewBuffEffect(ModContent.BuffType<Flask_PlagueBuff>(), (int)Common.EffectTypes.Flask),
            new NewBuffEffect(ModContent.BuffType<Flask_SteelBuff>(), (int)Common.EffectTypes.Flask),
            //strange potions
            new NewBuffEffect(ModContent.BuffType<AntiEncirclementBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<AttractBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<BraveBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<FlappyBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<GreedBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<HighwayBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<HyperopiaBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<KiwiBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<LeapBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<LeftistBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<MermaidBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<NukeBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<ParasiteBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<RightistBuff>(), (int)Common.EffectTypes.StrangePotion),
            new NewBuffEffect(ModContent.BuffType<SignalBuff>(), (int)Common.EffectTypes.StrangePotion)
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in HomewardJourneyEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //arena
                new NewBuffItem(ModContent.ItemType<BushOfLife>(), ModContent.BuffType<BushOfLifeBuff>(), Common.AllEffects[ModContent.BuffType<BushOfLifeBuff>()], 3, "PermanentBushOfLife", "Permanent Bush of Life"),
                new NewBuffItem(ModContent.ItemType<LifeLantern>(), ModContent.BuffType<LifeLanternBuff>(), Common.AllEffects[ModContent.BuffType<LifeLanternBuff>()], 3, "PermanentLifeLantern", "Permanent Life Lantern"),
                //potions
                new NewBuffItem(ModContent.ItemType<FlightPotion>(), ModContent.BuffType<FlightBuff>(), Common.AllEffects[ModContent.BuffType<FlightBuff>()], 30, "PermanentFlight", "Permanent Flight"),
                new NewBuffItem(ModContent.ItemType<FluorescentBerryCan>(), ModContent.BuffType<FluorescentBerryBuff>(), Common.AllEffects[ModContent.BuffType<FluorescentBerryBuff>()], 30, "PermanentFluorescentBerry", "Permanent Fluorescent Berry"),
                new NewBuffItem(ModContent.ItemType<HastePotion>(), ModContent.BuffType<HasteBuff>(), Common.AllEffects[ModContent.BuffType<HasteBuff>()], 30, "PermanentHJHaste", "Permanent Haste"),
                new NewBuffItem(ModContent.ItemType<ReanimationPotion>(), ModContent.BuffType<ReanimationBuff>(), Common.AllEffects[ModContent.BuffType<ReanimationBuff>()], 30, "PermanentReanimation", "Permanent Reanimation"),
                new NewBuffItem(ModContent.ItemType<YinPotion>(), ModContent.BuffType<NerveFibreBuff>(), Common.AllEffects[ModContent.BuffType<NerveFibreBuff>()], 30, "PermanentYin", "Permanent Yin"),
                new NewBuffItem(ModContent.ItemType<YangPotion>(), ModContent.BuffType<YangPotionBuff>(), Common.AllEffects[ModContent.BuffType<YangPotionBuff>()], 30, "PermanentYang", "Permanent Yang"),
                //flasks
                new NewBuffItem(ModContent.ItemType<DivineFireFlask>(), ModContent.BuffType<Flask_DivineFireBuff>(), Common.AllEffects[ModContent.BuffType<Flask_DivineFireBuff>()], 30, "PermanentFlaskOfDivineFire", "Permanent Flask of Divine Fire"),
                new NewBuffItem(ModContent.ItemType<ForceBreakFlask>(), ModContent.BuffType<Flask_ForceBreakBuff>(), Common.AllEffects[ModContent.BuffType<Flask_ForceBreakBuff>()], 30, "PermanentFlaskOfForceBreak", "Permanent Flask of Force Break"),
                new NewBuffItem(ModContent.ItemType<PlagueFlask>(), ModContent.BuffType<Flask_PlagueBuff>(), Common.AllEffects[ModContent.BuffType<Flask_PlagueBuff>()], 30, "PermanentFlaskOfPlague", "Permanent Flask of Plague"),
                new NewBuffItem(ModContent.ItemType<SteelFlask>(), ModContent.BuffType<Flask_SteelBuff>(), Common.AllEffects[ModContent.BuffType<Flask_SteelBuff>()], 30, "PermanentFlaskOfSteel", "Permanent Flask of Steel"),
                //strange
                new NewBuffItem(ModContent.ItemType<AntiEncirclementPotion>(), ModContent.BuffType<AntiEncirclementBuff>(), Common.AllEffects[ModContent.BuffType<AntiEncirclementBuff>()], 30, "PermanentAntiEncirclement", "Permanent Anti Encirclement"),
                new NewBuffItem(ModContent.ItemType<AttractPotion>(), ModContent.BuffType<AttractBuff>(), Common.AllEffects[ModContent.BuffType<AttractBuff>()], 30, "PermanentAttract", "Permanent Attract"),
                new NewBuffItem(ModContent.ItemType<BravePotion>(), ModContent.BuffType<BraveBuff>(), Common.AllEffects[ModContent.BuffType<BraveBuff>()], 30, "PermanentBrave", "Permanent Brave"),
                new NewBuffItem(ModContent.ItemType<FlappyPotion>(), ModContent.BuffType<FlappyBuff>(), Common.AllEffects[ModContent.BuffType<FlappyBuff>()], 30, "PermanentFlappy", "Permanent Flappy"),
                new NewBuffItem(ModContent.ItemType<GreedPotion>(), ModContent.BuffType<GreedBuff>(), Common.AllEffects[ModContent.BuffType<GreedBuff>()], 30, "PermanentGreed", "Permanent Greed"),
                new NewBuffItem(ModContent.ItemType<HighwayPotion>(), ModContent.BuffType<HighwayBuff>(), Common.AllEffects[ModContent.BuffType<HighwayBuff>()], 30, "PermanentHighway", "Permanent Highway"),
                new NewBuffItem(ModContent.ItemType<HyperopiaPotion>(), ModContent.BuffType<HyperopiaBuff>(), Common.AllEffects[ModContent.BuffType<HyperopiaBuff>()], 30, "PermanentHyperopia", "Permanent Hyperopia"),
                new NewBuffItem(ModContent.ItemType<KiwiPotion>(), ModContent.BuffType<KiwiBuff>(), Common.AllEffects[ModContent.BuffType<KiwiBuff>()], 30, "PermanentKiwi", "Permanent Kiwi"),
                new NewBuffItem(ModContent.ItemType<LeapPotion>(), ModContent.BuffType<LeapBuff>(), Common.AllEffects[ModContent.BuffType<LeapBuff>()], 30, "PermanentLeap", "Permanent Leap"),
                new NewBuffItem(ModContent.ItemType<LeftistPotion>(), ModContent.BuffType<LeftistBuff>(), Common.AllEffects[ModContent.BuffType<LeftistBuff>()], 30, "PermanentLeftist", "Permanent Leftist"),
                new NewBuffItem(ModContent.ItemType<MermaidPotion>(), ModContent.BuffType<MermaidBuff>(), Common.AllEffects[ModContent.BuffType<MermaidBuff>()], 30, "PermanentMermaid", "Permanent Mermaid"),
                new NewBuffItem(ModContent.ItemType<NukePotion>(), ModContent.BuffType<NukeBuff>(), Common.AllEffects[ModContent.BuffType<NukeBuff>()], 30, "PermanentNuke", "Permanent Nuke"),
                new NewBuffItem(ModContent.ItemType<ParasitePotion>(), ModContent.BuffType<ParasiteBuff>(), Common.AllEffects[ModContent.BuffType<ParasiteBuff>()], 30, "PermanentParasite", "Permanent Parasite"),
                new NewBuffItem(ModContent.ItemType<RightistPotion>(), ModContent.BuffType<RightistBuff>(), Common.AllEffects[ModContent.BuffType<RightistBuff>()], 30, "PermanentRightist", "Permanent Rightist"),
                new NewBuffItem(ModContent.ItemType<SignalPotion>(), ModContent.BuffType<SignalBuff>(), Common.AllEffects[ModContent.BuffType<SignalBuff>()], 30, "PermanentSignal", "Permanent Signal")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentHomewardJourneyFarming = new()
            {
                { Common.AllEffects[ModContent.BuffType<FluorescentBerryBuff>()], ModContent.BuffType<FluorescentBerryBuff>() },
                { Common.AllEffects[ModContent.BuffType<ReanimationBuff>()], ModContent.BuffType<ReanimationBuff>() },
                { Common.AllEffects[ModContent.BuffType<NerveFibreBuff>()], ModContent.BuffType<NerveFibreBuff>() },
                { Common.AllEffects[ModContent.BuffType<YangPotionBuff>()], ModContent.BuffType<YangPotionBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentHomewardJourneyMovement = new()
            {
                { Common.AllEffects[ModContent.BuffType<FlightBuff>()], ModContent.BuffType<FlightBuff>() },
                { Common.AllEffects[ModContent.BuffType<HasteBuff>()], ModContent.BuffType<HasteBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentHomewardJourneyArena = new()
            {
                { Common.AllEffects[ModContent.BuffType<BushOfLifeBuff>()], ModContent.BuffType<BushOfLifeBuff>() },
                { Common.AllEffects[ModContent.BuffType<LifeLanternBuff>()], ModContent.BuffType<LifeLanternBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentHomewardJourneyFlasks = new()
            {
                { Common.AllEffects[ModContent.BuffType<Flask_DivineFireBuff>()], ModContent.BuffType<Flask_DivineFireBuff>() },
                { Common.AllEffects[ModContent.BuffType<Flask_ForceBreakBuff>()], ModContent.BuffType<Flask_ForceBreakBuff>() },
                { Common.AllEffects[ModContent.BuffType<Flask_PlagueBuff>()], ModContent.BuffType<Flask_PlagueBuff>() },
                { Common.AllEffects[ModContent.BuffType<Flask_SteelBuff>()], ModContent.BuffType<Flask_SteelBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentHomewardJourneyStrangePotions = new()
            {
                { Common.AllEffects[ModContent.BuffType<AntiEncirclementBuff>()], ModContent.BuffType<AntiEncirclementBuff>() },
                { Common.AllEffects[ModContent.BuffType<AttractBuff>()], ModContent.BuffType<AttractBuff>() },
                { Common.AllEffects[ModContent.BuffType<BraveBuff>()], ModContent.BuffType<BraveBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlappyBuff>()], ModContent.BuffType<FlappyBuff>() },
                { Common.AllEffects[ModContent.BuffType<GreedBuff>()], ModContent.BuffType<GreedBuff>() },
                { Common.AllEffects[ModContent.BuffType<HighwayBuff>()], ModContent.BuffType<HighwayBuff>() },
                { Common.AllEffects[ModContent.BuffType<HyperopiaBuff>()], ModContent.BuffType<HyperopiaBuff>() },
                { Common.AllEffects[ModContent.BuffType<KiwiBuff>()], ModContent.BuffType<KiwiBuff>() },
                { Common.AllEffects[ModContent.BuffType<LeapBuff>()], ModContent.BuffType<LeapBuff>() },
                { Common.AllEffects[ModContent.BuffType<LeftistBuff>()], ModContent.BuffType<LeftistBuff>() },
                { Common.AllEffects[ModContent.BuffType<MermaidBuff>()], ModContent.BuffType<MermaidBuff>() },
                { Common.AllEffects[ModContent.BuffType<NukeBuff>()], ModContent.BuffType<NukeBuff>() },
                { Common.AllEffects[ModContent.BuffType<ParasiteBuff>()], ModContent.BuffType<ParasiteBuff>() },
                { Common.AllEffects[ModContent.BuffType<RightistBuff>()], ModContent.BuffType<RightistBuff>() },
                { Common.AllEffects[ModContent.BuffType<SignalBuff>()], ModContent.BuffType<SignalBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentHomewardJourney = new()
            {
                { Common.AllEffects[ModContent.BuffType<FluorescentBerryBuff>()], ModContent.BuffType<FluorescentBerryBuff>() },
                { Common.AllEffects[ModContent.BuffType<ReanimationBuff>()], ModContent.BuffType<ReanimationBuff>() },
                { Common.AllEffects[ModContent.BuffType<NerveFibreBuff>()], ModContent.BuffType<NerveFibreBuff>() },
                { Common.AllEffects[ModContent.BuffType<YangPotionBuff>()], ModContent.BuffType<YangPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlightBuff>()], ModContent.BuffType<FlightBuff>() },
                { Common.AllEffects[ModContent.BuffType<HasteBuff>()], ModContent.BuffType<HasteBuff>() },
                { Common.AllEffects[ModContent.BuffType<BushOfLifeBuff>()], ModContent.BuffType<BushOfLifeBuff>() },
                { Common.AllEffects[ModContent.BuffType<LifeLanternBuff>()], ModContent.BuffType<LifeLanternBuff>() },
                { Common.AllEffects[ModContent.BuffType<Flask_DivineFireBuff>()], ModContent.BuffType<Flask_DivineFireBuff>() },
                { Common.AllEffects[ModContent.BuffType<Flask_ForceBreakBuff>()], ModContent.BuffType<Flask_ForceBreakBuff>() },
                { Common.AllEffects[ModContent.BuffType<Flask_PlagueBuff>()], ModContent.BuffType<Flask_PlagueBuff>() },
                { Common.AllEffects[ModContent.BuffType<Flask_SteelBuff>()], ModContent.BuffType<Flask_SteelBuff>() },
                { Common.AllEffects[ModContent.BuffType<AntiEncirclementBuff>()], ModContent.BuffType<AntiEncirclementBuff>() },
                { Common.AllEffects[ModContent.BuffType<AttractBuff>()], ModContent.BuffType<AttractBuff>() },
                { Common.AllEffects[ModContent.BuffType<BraveBuff>()], ModContent.BuffType<BraveBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlappyBuff>()], ModContent.BuffType<FlappyBuff>() },
                { Common.AllEffects[ModContent.BuffType<GreedBuff>()], ModContent.BuffType<GreedBuff>() },
                { Common.AllEffects[ModContent.BuffType<HighwayBuff>()], ModContent.BuffType<HighwayBuff>() },
                { Common.AllEffects[ModContent.BuffType<HyperopiaBuff>()], ModContent.BuffType<HyperopiaBuff>() },
                { Common.AllEffects[ModContent.BuffType<KiwiBuff>()], ModContent.BuffType<KiwiBuff>() },
                { Common.AllEffects[ModContent.BuffType<LeapBuff>()], ModContent.BuffType<LeapBuff>() },
                { Common.AllEffects[ModContent.BuffType<LeftistBuff>()], ModContent.BuffType<LeftistBuff>() },
                { Common.AllEffects[ModContent.BuffType<MermaidBuff>()], ModContent.BuffType<MermaidBuff>() },
                { Common.AllEffects[ModContent.BuffType<NukeBuff>()], ModContent.BuffType<NukeBuff>() },
                { Common.AllEffects[ModContent.BuffType<ParasiteBuff>()], ModContent.BuffType<ParasiteBuff>() },
                { Common.AllEffects[ModContent.BuffType<RightistBuff>()], ModContent.BuffType<RightistBuff>() },
                { Common.AllEffects[ModContent.BuffType<SignalBuff>()], ModContent.BuffType<SignalBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentHomewardJourneyFarming, "PermanentHomewardJourneyFarming", "Permanent Homeward Journey Farming", "PermanentHomewardJourneyFarming"),
                new NewCombinedBuffItem(PermanentHomewardJourneyMovement, "PermanentHomewardJourneyMovement", "Permanent Homeward Journey Movement", "PermanentHomewardJourneyMovement"),
                new NewCombinedBuffItem(PermanentHomewardJourneyArena, "PermanentHomewardJourneyArena", "Permanent Homeward Journey Arena", "PermanentHomewardJourneyArena"),
                new NewCombinedBuffItem(PermanentHomewardJourneyFlasks, "PermanentHomewardJourneyFlasks", "Permanent Homeward Journey Flasks", "PermanentHomewardJourneyFlasks"),
                new NewCombinedBuffItem(PermanentHomewardJourneyStrangePotions, "PermanentHomewardJourneyStrangePotions", "Permanent Homeward Journey Strange Potions", "PermanentHomewardJourneyStrangePotions"),
                new NewCombinedBuffItem(PermanentHomewardJourney, "PermanentHomewardJourney", "Permanent Homeward Journey", "PermanentHomewardJourney")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
