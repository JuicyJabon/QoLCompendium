namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class HomewardJourneyBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.HomewardJourney.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] HomewardJourneyEffects = [
            //arena
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "BushOfLifeBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LifeLanternBuff"), (int)Constants.EffectTypes.Arena),
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FlightBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FluorescentBerryBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HasteBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "ReanimationBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "YangPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "NerveFibreBuff")),
            //flasks
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_DivineFireBuff"), (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_ForceBreakBuff"), (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_PlagueBuff"), (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_SteelBuff"), (int)Constants.EffectTypes.Flask),
            //strange potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "AntiEncirclementBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "AttractBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "BraveBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FlappyBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "GreedBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HighwayBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HyperopiaBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "KiwiBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LeapBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LeftistBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "MermaidBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "NukeBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "ParasiteBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "RightistBuff"), (int)Constants.EffectTypes.StrangePotion),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "SignalBuff"), (int)Constants.EffectTypes.StrangePotion)];

            foreach (var newEffect in HomewardJourneyEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //arena
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "BushOfLife"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "BushOfLifeBuff")], 3, "PermanentBushOfLife"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "LifeLantern"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LifeLanternBuff")], 3, "PermanentLifeLantern"),
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FlightPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FlightBuff")], 30, "PermanentFlight"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FluorescentBerryCan"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FluorescentBerryBuff")], 30, "PermanentFluorescentBerry"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "HastePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HasteBuff")], 30, "PermanentHJHaste"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "ReanimationPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "ReanimationBuff")], 30, "PermanentReanimation"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "YinPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "NerveFibreBuff")], 30, "PermanentYin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "YangPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "YangPotionBuff")], 30, "PermanentYang"),
                //flasks
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "DivineFireFlask"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_DivineFireBuff")], 30, "PermanentFlaskOfDivineFire"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "ForceBreakFlask"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_ForceBreakBuff")], 30, "PermanentFlaskOfForceBreak"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "PlagueFlask"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_PlagueBuff")], 30, "PermanentFlaskOfPlague"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "SteelFlask"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_SteelBuff")], 30, "PermanentFlaskOfSteel"),
                //strange
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "AntiEncirclementPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "AntiEncirclementBuff")], 30, "PermanentAntiEncirclement"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "AttractPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "AttractBuff")], 30, "PermanentAttract"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "BravePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "BraveBuff")], 30, "PermanentBrave"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FlappyPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FlappyBuff")], 30, "PermanentFlappy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "GreedPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "GreedBuff")], 30, "PermanentGreed"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "HighwayPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HighwayBuff")], 30, "PermanentHighway"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "HyperopiaPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HyperopiaBuff")], 30, "PermanentHyperopia"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "KiwiPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "KiwiBuff")], 30, "PermanentKiwi"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "LeapPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LeapBuff")], 30, "PermanentLeap"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "LeftistPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LeftistBuff")], 30, "PermanentLeftist"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "MermaidPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "MermaidBuff")], 30, "PermanentMermaid"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "NukePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "NukeBuff")], 30, "PermanentNuke"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "ParasitePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "ParasiteBuff")], 30, "PermanentParasite"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "RightistPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "RightistBuff")], 30, "PermanentRightist"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "SignalPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "SignalBuff")], 30, "PermanentSignal")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentHomewardJourneyFarming =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FluorescentBerryBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "ReanimationBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "NerveFibreBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "YangPotionBuff")]
            ];
            List<int> PermanentHomewardJourneyFarmingIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFluorescentBerry"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentReanimation"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentYin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentYang")];

            List<BuffEffect> PermanentHomewardJourneyMovement =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FlightBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HasteBuff")]
            ];
            List<int> PermanentHomewardJourneyMovementIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlight"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHJHaste")];

            List<BuffEffect> PermanentHomewardJourneyArena =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "BushOfLifeBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LifeLanternBuff")]
            ];
            List<int> PermanentHomewardJourneyArenaIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBushOfLife"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLifeLantern")];

            List<BuffEffect> PermanentHomewardJourneyFlasks =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_DivineFireBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_ForceBreakBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_PlagueBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "Flask_SteelBuff")]
            ];
            List<int> PermanentHomewardJourneyFlasksIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfDivineFire"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfForceBreak"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfPlague"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfSteel")];

            List<BuffEffect> PermanentHomewardJourneyStrangePotions =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "AntiEncirclementBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "AttractBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "BraveBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "FlappyBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "GreedBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HighwayBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "HyperopiaBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "KiwiBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LeapBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "LeftistBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "MermaidBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "NukeBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "ParasiteBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "RightistBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.HomewardJourney.Mod, "SignalBuff")]
            ];
            List<int> PermanentHomewardJourneyStrangePotionsIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAntiEncirclement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAttract"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBrave"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlappy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGreed"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHighway"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHyperopia"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentKiwi"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLeap"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLeftist"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMermaid"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNuke"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentParasite"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRightist"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSignal")];

            List<BuffEffect> PermanentHomewardJourney = [];
            PermanentHomewardJourney.AddRange(PermanentHomewardJourneyFarming);
            PermanentHomewardJourney.AddRange(PermanentHomewardJourneyMovement);
            PermanentHomewardJourney.AddRange(PermanentHomewardJourneyArena);
            PermanentHomewardJourney.AddRange(PermanentHomewardJourneyFlasks);
            PermanentHomewardJourney.AddRange(PermanentHomewardJourneyStrangePotions);

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem("PermanentHomewardJourneyFarming", PermanentHomewardJourneyFarming, PermanentHomewardJourneyFarmingIngredients),
                new NewCombinedBuffItem("PermanentHomewardJourneyMovement", PermanentHomewardJourneyMovement, PermanentHomewardJourneyMovementIngredients),
                new NewCombinedBuffItem("PermanentHomewardJourneyArena", PermanentHomewardJourneyArena, PermanentHomewardJourneyArenaIngredients),
                new NewCombinedBuffItem("PermanentHomewardJourneyFlasks", PermanentHomewardJourneyFlasks, PermanentHomewardJourneyFlasksIngredients),
                new NewCombinedBuffItem("PermanentHomewardJourneyStrangePotions", PermanentHomewardJourneyStrangePotions, PermanentHomewardJourneyStrangePotionsIngredients)
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);

            List<int> PermanentHomewardJourneyIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyFarming"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyArena"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyFlasks")];

            NewCombinedBuffItem permanentHomewardJourneyItem = new("PermanentHomewardJourney", PermanentHomewardJourney, PermanentHomewardJourneyIngredients);
            CombinedBuffItem newPermanentHomewardJourney = new(permanentHomewardJourneyItem.itemName, permanentHomewardJourneyItem.textureName, permanentHomewardJourneyItem.effects, permanentHomewardJourneyItem.ingredients);
            QoLCompendium.Instance.AddContent(newPermanentHomewardJourney);
            Constants.AllCombinedBuffItems.Add(newPermanentHomewardJourney.Type);
        }
    }
}
