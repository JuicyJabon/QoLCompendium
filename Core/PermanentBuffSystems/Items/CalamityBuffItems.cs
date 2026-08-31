namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class CalamityBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Calamity.Loaded)
                return;

            BaseItems();
            if (CrossModSupport.CalamityEntropy.Loaded)
                CalamityEntropyBuffItems.LoadTasks();
            if (CrossModSupport.CalamityRekindled.Loaded)
                CalamityRekindledBuffItems.LoadTasks();
            if (CrossModSupport.Catalyst.Loaded)
                CatalystBuffItems.LoadTasks();
            if (CrossModSupport.Clamity.Loaded)
                ClamityBuffItems.LoadTasks();
            if (CrossModSupport.DraedonExpansion.Loaded)
                DraedonExpansionBuffItems.LoadTasks();
            if (CrossModSupport.WrathOfTheGods.Loaded)
                WrathOfTheGodsBuffItems.LoadTasks();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] CalamityEffects = [
            //Alcohols
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "BaconOilBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "BloodyMaryBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "CaribbeanRumBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "CinnamonRollBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "EverclearBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "EvergreenGinBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "FireballBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "GrapeBeerBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "ManhattanBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "MargaritaBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "MoonshineBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "MoscowMuleBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "OldFashionedBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "PurpleHazeBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "RedWineBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "RumBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "ScrewdriverBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "StarBeamRyeBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "TequilaBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "TequilaSunriseBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "Trippy"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "VodkaBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "WhiskeyBuff"), (int)Constants.EffectTypes.Alcohol),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "WhiteWineBuff"), (int)Constants.EffectTypes.Alcohol),
            //arena
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "ChaosCandleBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "CorruptionEffigyBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "CrimsonEffigyBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "EffigyOfDecayBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "PurpleCandleBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "YellowCandleBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "TranquilityCandleBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "PinkCandleBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "BlueCandleBuff"), (int)Constants.EffectTypes.Arena),
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "AnechoicCoatingBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "AstralInjectionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "BaguetteBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "BloodfinBoost")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "BoundingBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "CalciumBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "CeaselessHunger")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "GravityNormalizerBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "Malnourished")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "Omniscience")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "PhotosynthesisBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "ShadowBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "Soaring")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "SulphurskinBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "Zen")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "Zerg")),
            //flasks
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueBrimstone"), (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueCrumbling"), (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueHolyFlames"), (int)Constants.EffectTypes.Flask),
        ];

            foreach (var newEffect in CalamityEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "BaconOil"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BaconOilBuff")], 30, "PermanentBaconOil"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "BloodyMary"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BloodyMaryBuff")], 30, "PermanentBloodyMary"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "CaribbeanRum"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CaribbeanRumBuff")], 30, "PermanentCaribbeanRum"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "CinnamonRoll"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CinnamonRollBuff")], 30, "PermanentCinnamonRoll"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Everclear"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "EverclearBuff")], 30, "PermanentEverclear"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "EvergreenGin"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "EvergreenGinBuff")], 30, "PermanentEvergreenGin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Fireball"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "FireballBuff")], 30, "PermanentFireball"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "GrapeBeer"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "GrapeBeerBuff")], 30, "PermanentGrapeBeer"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Manhattan"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ManhattanBuff")], 30, "PermanentManhattan"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Margarita"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "MargaritaBuff")], 30, "PermanentMargarita"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Moonshine"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "MoonshineBuff")], 30, "PermanentMoonshine"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "MoscowMule"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "MoscowMuleBuff")], 30, "PermanentMoscowMule"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "OldFashioned"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "OldFashionedBuff")], 30, "PermanentOldFashioned"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "PurpleHaze"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "PurpleHazeBuff")], 30, "PermanentPurpleHaze"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "RedWine"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "RedWineBuff")], 30, "PermanentRedWine"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Rum"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "RumBuff")], 30, "PermanentRum"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Screwdriver"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ScrewdriverBuff")], 30, "PermanentScrewdriver"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "StarBeamRye"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "StarBeamRyeBuff")], 30, "PermanentStarBeamRye"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Tequila"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "TequilaBuff")], 30, "PermanentTequila"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "TequilaSunrise"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "TequilaSunriseBuff")], 30, "PermanentTequilaSunrise"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "OddMushroom"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Trippy")], 30, "PermanentTrippy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Vodka"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "VodkaBuff")], 30, "PermanentVodka"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Whiskey"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WhiskeyBuff")], 30, "PermanentWhiskey"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "WhiteWine"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WhiteWineBuff")], 30, "PermanentWhiteWine"),


                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "ChaosCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ChaosCandleBuff")], 3, "PermanentChaosCandle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "CorruptionEffigy"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CorruptionEffigyBuff")], 3, "PermanentCorruptionEffigy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "CrimsonEffigy"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CrimsonEffigyBuff")], 3, "PermanentCrimsonEffigy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "EffigyOfDecay"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "EffigyOfDecayBuff")], 3, "PermanentEffigyOfDecay"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "ResilientCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "PurpleCandleBuff")], 3, "PermanentResilientCandle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "SpitefulCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "YellowCandleBuff")], 3, "PermanentSpitefulCandle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "TranquilityCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "TranquilityCandleBuff")], 3, "PermanentTranquilityCandle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "VigorousCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "PinkCandleBuff")], 3, "PermanentVigorousCandle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "WeightlessCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BlueCandleBuff")], 3, "PermanentWeightlessCandle"),


                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "AnechoicCoating"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "AnechoicCoatingBuff")], 30, "PermanentAnechoicCoating"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralInjection"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "AstralInjectionBuff")], 30, "PermanentAstralInjection"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Baguette"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BaguetteBuff")], 30, "PermanentBaguette"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "Bloodfin"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BloodfinBoost")], 30, "PermanentBloodfin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "BoundingPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BoundingBuff")], 30, "PermanentBounding"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "CalciumPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CalciumBuff")], 30, "PermanentCalcium"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "CeaselessHungerPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CeaselessHunger")], 30, "PermanentCeaselessHunger"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "GravityNormalizerPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "GravityNormalizerBuff")], 30, "PermanentGravityNormalizer"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "TheSandwich"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Malnourished")], 30, "PermanentMalnourished"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "PotionofOmniscience"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Omniscience")], 30, "PermanentOmniscience"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "PhotosynthesisPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "PhotosynthesisBuff")], 30, "PermanentPhotosynthesis"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "ShadowPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ShadowBuff")], 30, "PermanentShadow"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "SoaringPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Soaring")], 30, "PermanentSoaring"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurskinPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "SulphurskinBuff")], 30, "PermanentSulphurskin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "ZenPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Zen")], 30, "PermanentZen"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "ZergPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Zerg")], 30, "PermanentZerg"),


                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "FlaskOfBrimstone"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueBrimstone")], 30, "PermanentFlaskOfBrimstone"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "FlaskOfCrumbling"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueCrumbling")], 30, "PermanentFlaskOfCrumbling"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Calamity.Mod, "FlaskOfHolyFlames"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueHolyFlames")], 30, "PermanentFlaskOfHolyFlames"),
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentCalamityAlcohols =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BaconOilBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BloodyMaryBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CaribbeanRumBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CinnamonRollBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "EverclearBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "EvergreenGinBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "FireballBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "GrapeBeerBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ManhattanBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "MargaritaBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "MoonshineBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "MoscowMuleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "OldFashionedBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "PurpleHazeBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "RedWineBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "RumBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ScrewdriverBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "StarBeamRyeBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "TequilaBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "TequilaSunriseBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Trippy")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "VodkaBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WhiskeyBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WhiteWineBuff")]
            ];
            List<int> PermanentCalamityAlcoholsIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBaconOil"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBloodyMary"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCaribbeanRum"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCinnamonRoll"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEverclear"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEvergreenGin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFireball"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGrapeBeer"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentManhattan"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMargarita"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoonshine"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoscowMule"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentOldFashioned"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentPurpleHaze"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRedWine"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRum"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentScrewdriver"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentStarBeamRye"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTequila"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTequilaSunrise"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTrippy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVodka"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWhiskey"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWhiteWine")];

            List<BuffEffect> PermanentCalamityAbyss =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "AnechoicCoatingBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Omniscience")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "SulphurskinBuff")]
            ];
            List<int> PermanentCalamityAbyssIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAnechoicCoating"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentOmniscience"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSulphurskin")];

            List<BuffEffect> PermanentCalamityDamage =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "AstralInjectionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Malnourished")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ShadowBuff")]
            ];
            List<int> PermanentCalamityDamageIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAstralInjection"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMalnourished"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadow")];
            if (CrossModSupport.CalamityEntropy.Loaded)
            {
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "SoyMilkBuff")]);
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentSoyMilk"));
            }
            if (CrossModSupport.CalamityRekindled.Loaded)
            {
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "BeetleJuiceBuff")]);
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Penumbra")]);
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ProfanedRageBuff")]);
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ProfanedWrathBuff")]);
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ArmorShattering")]);
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentBeetleJuice"));
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentPenumbra"));
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "ProfanedRagePotion"));
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "ProfanedWrathBuff"));
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentShattering"));
            }
            if (CrossModSupport.Catalyst.Loaded)
            {
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.Catalyst.Mod, "AstralJellyBuff")]);
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentAstracola"));
            }
            if (CrossModSupport.Clamity.Loaded)
            {
                PermanentCalamityDamage.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.Clamity.Mod, "SupremeLucky")]);
                PermanentCalamityDamageIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentSupremeLuck"));
            }

            List<BuffEffect> PermanentCalamityDefense =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BaguetteBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BloodfinBoost")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CalciumBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "PhotosynthesisBuff")]
            ];
            List<int> PermanentCalamityDefenseIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBaguette"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBloodfin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalcium"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentPhotosynthesis")];
            if (CrossModSupport.CalamityEntropy.Loaded)
            {
                PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "YharimPower")]);
                PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentYharimsStimulants"));
            }
            if (CrossModSupport.CalamityRekindled.Loaded)
            {
                PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Cadence")]);
                PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "DraconicSurgeBuff")]);
                PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Revivify")]);
                PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "TriumphBuff")]);
                PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentCadence"));
                PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentDraconicElixir"));
                PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentRevivify"));
                PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentTriumph"));

                if (!CrossModSupport.Clamity.Loaded)
                {
                    PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "TitanScale")]);
                    PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentCRTitanScale"));
                }

                if (!CrossModSupport.CalamityEntropy.Loaded)
                {
                    PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "YharimPower")]);
                    PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentCRYharimsStimulants"));
                }
            }
            if (CrossModSupport.Clamity.Loaded)
            {
                PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.Clamity.Mod, "TitanScalePotionBuff")]);
                PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentTitanScale"));
            }
            if (CrossModSupport.WrathOfTheGods.Loaded)
            {
                PermanentCalamityDefense.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.WrathOfTheGods.Mod, "StarstrikinglySatiated")]);
                PermanentCalamityDefenseIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentStarstrikinglySatiated"));
            }

            List<BuffEffect> PermanentCalamityFarming =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CeaselessHunger")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Zen")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Zerg")]
            ];
            List<int> PermanentCalamityFarmingIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentZen"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentZerg"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCeaselessHunger")];

            List<BuffEffect> PermanentCalamityMovement =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BoundingBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "GravityNormalizerBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "Soaring")]
            ];
            List<int> PermanentCalamityMovementIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBounding"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGravityNormalizer"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoaring")];

            List<BuffEffect> PermanentCalamityArena =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CorruptionEffigyBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "CrimsonEffigyBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "EffigyOfDecayBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "ChaosCandleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "TranquilityCandleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "BlueCandleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "PinkCandleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "YellowCandleBuff")]
            ];
            List<int> PermanentCalamityArenaIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCorruptionEffigy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCrimsonEffigy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEffigyOfDecay"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentChaosCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTranquilityCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentResilientCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpitefulCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVigorousCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWeightlessCandle")];
            if (CrossModSupport.CalamityEntropy.Loaded)
            {
                PermanentCalamityArena.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "VoidCandleBuff")]);
                PermanentCalamityArenaIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentVoidCandle"));
            }

            List<BuffEffect> PermanentCalamityFlasks = new()
            {
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueBrimstone")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueCrumbling")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Calamity.Mod, "WeaponImbueHolyFlames")]
            };
            List<int> PermanentCalamityFlasksIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfBrimstone"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfCrumbling"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfHolyFlames")];
            if (CrossModSupport.DraedonExpansion.Loaded)
            {
                PermanentCalamityFlasks.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.DraedonExpansion.Mod, "FlaskOfElectricityBuff")]);
                PermanentCalamityFlasksIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfElectricity"));
            }

            List<BuffEffect> PermanentCalamity = [];
            PermanentCalamity.AddRange(PermanentCalamityAlcohols);
            PermanentCalamity.AddRange(PermanentCalamityAbyss);
            PermanentCalamity.AddRange(PermanentCalamityDamage);
            PermanentCalamity.AddRange(PermanentCalamityDefense);
            PermanentCalamity.AddRange(PermanentCalamityFarming);
            PermanentCalamity.AddRange(PermanentCalamityMovement);
            PermanentCalamity.AddRange(PermanentCalamityArena);
            PermanentCalamity.AddRange(PermanentCalamityFlasks);

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem("PermanentCalamityAlcohols", PermanentCalamityAlcohols, PermanentCalamityAlcoholsIngredients),
                new NewCombinedBuffItem("PermanentCalamityAbyss", PermanentCalamityAbyss, PermanentCalamityAbyssIngredients),
                new NewCombinedBuffItem("PermanentCalamityDamage", PermanentCalamityDamage, PermanentCalamityDamageIngredients),
                new NewCombinedBuffItem("PermanentCalamityDefense", PermanentCalamityDefense, PermanentCalamityDefenseIngredients),
                new NewCombinedBuffItem("PermanentCalamityFarming", PermanentCalamityFarming, PermanentCalamityFarmingIngredients),
                new NewCombinedBuffItem("PermanentCalamityMovement", PermanentCalamityMovement, PermanentCalamityMovementIngredients),
                new NewCombinedBuffItem("PermanentCalamityArena", PermanentCalamityArena, PermanentCalamityArenaIngredients),
                new NewCombinedBuffItem("PermanentCalamityFlasks", PermanentCalamityFlasks, PermanentCalamityFlasksIngredients)
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);

            List<int> PermanentCalamityIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityAlcohols"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityAbyss"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityFarming"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityArena"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityFlasks")];

            NewCombinedBuffItem permanentCalamityItem = new("PermanentCalamity", PermanentCalamity, PermanentCalamityIngredients);
            CombinedBuffItem newPermanentCalamity = new(permanentCalamityItem.itemName, permanentCalamityItem.textureName, permanentCalamityItem.effects, permanentCalamityItem.ingredients);
            QoLCompendium.Instance.AddContent(newPermanentCalamity);
            Constants.AllCombinedBuffItems.Add(newPermanentCalamity.Type);
        }
    }

    public static class CalamityEntropyBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.CalamityEntropy.Loaded)
                return;

            NewBuffEffect[] CalamityEntropyEffects = [
                //potions
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "SoyMilkBuff")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "YharimPower")),
                //arena
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "VoidCandleBuff"), (int)Constants.EffectTypes.Arena)
            ];

            foreach (var newEffect in CalamityEntropyEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "SoyMilk"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "SoyMilkBuff")], 30, "PermanentSoyMilk"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "YharimsStimulants"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "YharimPower")], 30, "PermanentYharimsStimulants"),
                //arena
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "VoidCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityEntropy.Mod, "VoidCandleBuff")], 3, "PermanentVoidCandle")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }

    public static class CalamityRekindledBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.CalamityRekindled.Loaded)
                return;

            NewBuffEffect[] CalamityRekindledEffects = [
                //potions
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "BeetleJuiceBuff")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Cadence")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "DraconicSurgeBuff")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Penumbra")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ProfanedRageBuff")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ProfanedWrathBuff")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Revivify")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ArmorShattering")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "TriumphBuff"))
            ];

            if (!CrossModSupport.Clamity.Loaded)
            {
                Array.Resize(ref CalamityRekindledEffects, CalamityRekindledEffects.Length + 1);
                CalamityRekindledEffects[^1] = new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "TitanScale"));
            }

            if (!CrossModSupport.CalamityEntropy.Loaded)
            {
                Array.Resize(ref CalamityRekindledEffects, CalamityRekindledEffects.Length + 1);
                CalamityRekindledEffects[^1] = new NewBuffEffect(Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "YharimPower"));
            }

            foreach (var newEffect in CalamityRekindledEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "BeetleJuice"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "BeetleJuiceBuff")], 30, "PermanentBeetleJuice"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "CadencePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Cadence")], 30, "PermanentCadence"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "DraconicElixir"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "DraconicSurgeBuff")], 30, "PermanentDraconicElixir"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "PenumbraPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Penumbra")], 30, "PermanentPenumbra"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "ProfanedRagePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ProfanedRageBuff")], 30, "PermanentProfanedRage"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "ProfanedWrathPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ProfanedWrathBuff")], 30, "PermanentProfanedWrath"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "RevivifyPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "Revivify")], 30, "PermanentRevivify"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "ShatteringPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "ArmorShattering")], 30, "PermanentShattering"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "TriumphPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "TriumphBuff")], 30, "PermanentTriumph")
            ];

            if (!CrossModSupport.Clamity.Loaded)
            {
                Array.Resize(ref BuffItems, BuffItems.Length + 1);
                BuffItems[^1] = new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "TitanScalePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "TitanScale")], 30, "PermanentCRTitanScale");
            }

            if (!CrossModSupport.CalamityEntropy.Loaded)
            {
                Array.Resize(ref BuffItems, BuffItems.Length + 1);
                BuffItems[^1] = new NewBuffItem(Common.GetModItem(CrossModSupport.CalamityRekindled.Mod, "YharimsStimulants"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.CalamityRekindled.Mod, "YharimPower")], 30, "PermanentCRYharimsStimulants");
            }

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }

    public static class CatalystBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Catalyst.Loaded)
                return;

            NewBuffEffect[] CatalystEffects = [new NewBuffEffect(Common.GetModBuff(CrossModSupport.Catalyst.Mod, "AstralJellyBuff"))];

            foreach (var newEffect in CatalystEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.Catalyst.Mod, "Lean"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Catalyst.Mod, "AstralJellyBuff")], 30, "PermanentAstracola")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }

    public static class ClamityBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Clamity.Loaded)
                return;

            NewBuffEffect[] ClamityEffects = [
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.Clamity.Mod, "SupremeLucky")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.Clamity.Mod, "TitanScalePotionBuff"))
                ];

            foreach (var newEffect in ClamityEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.Clamity.Mod, "SupremeLuckPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Clamity.Mod, "SupremeLucky")], 30, "PermanentSupremeLuck"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Clamity.Mod, "TitanScalePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Clamity.Mod, "TitanScalePotionBuff")], 30, "PermanentTitanScale")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }

    public static class DraedonExpansionBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.DraedonExpansion.Loaded)
                return;

            NewBuffEffect[] DraedonExpansionEffects = [new NewBuffEffect(Common.GetModBuff(CrossModSupport.DraedonExpansion.Mod, "FlaskOfElectricityBuff"), (int)Constants.EffectTypes.Flask)];

            foreach (var newEffect in DraedonExpansionEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.DraedonExpansion.Mod, "FlaskOfElectricity"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.DraedonExpansion.Mod, "FlaskOfElectricityBuff")], 30, "PermanentFlaskOfElectricity")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }

    public static class WrathOfTheGodsBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.WrathOfTheGods.Loaded)
                return;

            NewBuffEffect[] WrathOfTheGodsEffects = [new NewBuffEffect(Common.GetModBuff(CrossModSupport.WrathOfTheGods.Mod, "StarstrikinglySatiated"))];

            foreach (var newEffect in WrathOfTheGodsEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.WrathOfTheGods.Mod, "CinnamonRollyn"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.WrathOfTheGods.Mod, "StarstrikinglySatiated")], 30, "PermanentStarstrikinglySatiated")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }
}
