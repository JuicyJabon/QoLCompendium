using CalamityEntropy.Content.Buffs;
using CalamityEntropy.Content.Items;
using CalamityLegacy.Content.Buffs;
using CalamityLegacy.Content.Items.Potions;
using CalamityMod.Buffs.Alcohol;
using CalamityMod.Buffs.Placeables;
using CalamityMod.Buffs.Potions;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using CalamityMod.Items.Placeables.Furniture;
using CalamityMod.Items.Potions;
using CalamityMod.Items.Potions.Alcohol;
using CatalystMod.Buffs.StatBuffs;
using CatalystMod.Items.Potions;
using Clamity.Content.Bosses.Clamitas.Crafted;
using Clamity.Content.Items.Potions.BuffPotions;
using Clamity.Content.Items.Potions.Food;
using DraedonExpansion.Content.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public static class CalamityBuffItems
    {
        public static NewBuffEffect[] CalamityEffects = [
            //Alcohols
            new NewBuffEffect(ModContent.BuffType<BloodyMaryBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<CaribbeanRumBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<CinnamonRollBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<EverclearBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<EvergreenGinBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<FireballBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<GrapeBeerBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<MargaritaBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<MoonshineBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<MoscowMuleBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<OldFashionedBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<PurpleHazeBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<RedWineBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<RumBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<ScrewdriverBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<StarBeamRyeBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<TequilaBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<TequilaSunriseBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<Trippy>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<VodkaBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<WhiskeyBuff>(), (int)Common.EffectTypes.Alcohol),
            new NewBuffEffect(ModContent.BuffType<WhiteWineBuff>(), (int)Common.EffectTypes.Alcohol),
            //arena
            new NewBuffEffect(ModContent.BuffType<ChaosCandleBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<CorruptionEffigyBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<CrimsonEffigyBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<EffigyOfDecayBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<PurpleCandleBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<YellowCandleBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<TranquilityCandleBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<PinkCandleBuff>(), (int)Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<BlueCandleBuff>(), (int)Common.EffectTypes.Arena),
            //potions
            new NewBuffEffect(ModContent.BuffType<AnechoicCoatingBuff>()),
            new NewBuffEffect(ModContent.BuffType<AstralInjectionBuff>()),
            new NewBuffEffect(ModContent.BuffType<BaguetteBuff>()),
            new NewBuffEffect(ModContent.BuffType<BloodfinBoost>()),
            new NewBuffEffect(ModContent.BuffType<BoundingBuff>()),
            new NewBuffEffect(ModContent.BuffType<CalciumBuff>()),
            new NewBuffEffect(ModContent.BuffType<CeaselessHunger>()),
            new NewBuffEffect(ModContent.BuffType<GravityNormalizerBuff>()),
            new NewBuffEffect(ModContent.BuffType<Omniscience>()),
            new NewBuffEffect(ModContent.BuffType<PhotosynthesisBuff>()),
            new NewBuffEffect(ModContent.BuffType<ShadowBuff>()),
            new NewBuffEffect(ModContent.BuffType<Soaring>()),
            new NewBuffEffect(ModContent.BuffType<SulphurskinBuff>()),
            new NewBuffEffect(ModContent.BuffType<Zen>()),
            new NewBuffEffect(ModContent.BuffType<Zerg>()),
            //flasks
            new NewBuffEffect(ModContent.BuffType<WeaponImbueBrimstone>(), (int)Common.EffectTypes.Flask),
            new NewBuffEffect(ModContent.BuffType<WeaponImbueCrumbling>(), (int)Common.EffectTypes.Flask),
            new NewBuffEffect(ModContent.BuffType<WeaponImbueHolyFlames>(), (int)Common.EffectTypes.Flask),
        ];

        public static void LoadTasks()
        {
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
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in CalamityEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<BloodyMary>(), ModContent.BuffType<BloodyMaryBuff>(), Common.AllEffects[ModContent.BuffType<BloodyMaryBuff>()], 30, "PermanentBloodyMary", "Permanent Bloody Mary"),
                new NewBuffItem(ModContent.ItemType<CaribbeanRum>(), ModContent.BuffType<CaribbeanRumBuff>(), Common.AllEffects[ModContent.BuffType<CaribbeanRumBuff>()], 30, "PermanentCaribbeanRum", "Permanent Caribbean Rum"),
                new NewBuffItem(ModContent.ItemType<CinnamonRoll>(), ModContent.BuffType<CinnamonRollBuff>(), Common.AllEffects[ModContent.BuffType<CinnamonRollBuff>()], 30, "PermanentCinnamonRoll", "Permanent Cinnamon Roll"),
                new NewBuffItem(ModContent.ItemType<Everclear>(), ModContent.BuffType<EverclearBuff>(), Common.AllEffects[ModContent.BuffType<EverclearBuff>()], 30, "PermanentEverclear", "Permanent Everclear"),
                new NewBuffItem(ModContent.ItemType<EvergreenGin>(), ModContent.BuffType<EvergreenGinBuff>(), Common.AllEffects[ModContent.BuffType<EvergreenGinBuff>()], 30, "PermanentEvergreenGin", "Permanent Evergreen Gin"),
                new NewBuffItem(ModContent.ItemType<Fireball>(), ModContent.BuffType<FireballBuff>(), Common.AllEffects[ModContent.BuffType<FireballBuff>()], 30, "PermanentFireball", "Permanent Fireball"),
                new NewBuffItem(ModContent.ItemType<GrapeBeer>(), ModContent.BuffType<GrapeBeerBuff>(), Common.AllEffects[ModContent.BuffType<GrapeBeerBuff>()], 30, "PermanentGrapeBeer", "Permanent Grape Beer"),
                new NewBuffItem(ModContent.ItemType<Margarita>(), ModContent.BuffType<MargaritaBuff>(), Common.AllEffects[ModContent.BuffType<MargaritaBuff>()], 30, "PermanentMargarita", "Permanent Margarita"),
                new NewBuffItem(ModContent.ItemType<Moonshine>(), ModContent.BuffType<MoonshineBuff>(), Common.AllEffects[ModContent.BuffType<MoonshineBuff>()], 30, "PermanentMoonshine", "Permanent Moonshine"),
                new NewBuffItem(ModContent.ItemType<MoscowMule>(), ModContent.BuffType<MoscowMuleBuff>(), Common.AllEffects[ModContent.BuffType<MoscowMuleBuff>()], 30, "PermanentMoscowMule", "Permanent Moscow Mule"),
                new NewBuffItem(ModContent.ItemType<OldFashioned>(), ModContent.BuffType<OldFashionedBuff>(), Common.AllEffects[ModContent.BuffType<OldFashionedBuff>()], 30, "PermanentOldFashioned", "Permanent Old Fashioned"),
                new NewBuffItem(ModContent.ItemType<PurpleHaze>(), ModContent.BuffType<PurpleHazeBuff>(), Common.AllEffects[ModContent.BuffType<PurpleHazeBuff>()], 30, "PermanentPurpleHaze", "Permanent Purple Haze"),
                new NewBuffItem(ModContent.ItemType<RedWine>(), ModContent.BuffType<RedWineBuff>(), Common.AllEffects[ModContent.BuffType<RedWineBuff>()], 30, "PermanentRedWine", "Permanent Red Wine"),
                new NewBuffItem(ModContent.ItemType<Rum>(), ModContent.BuffType<RumBuff>(), Common.AllEffects[ModContent.BuffType<RumBuff>()], 30, "PermanentRum", "Permanent Rum"),
                new NewBuffItem(ModContent.ItemType<Screwdriver>(), ModContent.BuffType<ScrewdriverBuff>(), Common.AllEffects[ModContent.BuffType<ScrewdriverBuff>()], 30, "PermanentScrewdriver", "Permanent Screwdriver"),
                new NewBuffItem(ModContent.ItemType<StarBeamRye>(), ModContent.BuffType<StarBeamRyeBuff>(), Common.AllEffects[ModContent.BuffType<StarBeamRyeBuff>()], 30, "PermanentStarBeamRye", "Permanent Star Beam Rye"),
                new NewBuffItem(ModContent.ItemType<Tequila>(), ModContent.BuffType<TequilaBuff>(), Common.AllEffects[ModContent.BuffType<TequilaBuff>()], 30, "PermanentTequila", "Permanent Tequila"),
                new NewBuffItem(ModContent.ItemType<TequilaSunrise>(), ModContent.BuffType<TequilaSunriseBuff>(), Common.AllEffects[ModContent.BuffType<TequilaSunriseBuff>()], 30, "PermanentTequilaSunrise", "Permanent Tequila Sunrise"),
                new NewBuffItem(ModContent.ItemType<OddMushroom>(), ModContent.BuffType<Trippy>(), Common.AllEffects[ModContent.BuffType<Trippy>()], 30, "PermanentTrippy", "Permanent Trippy"),
                new NewBuffItem(ModContent.ItemType<Vodka>(), ModContent.BuffType<VodkaBuff>(), Common.AllEffects[ModContent.BuffType<VodkaBuff>()], 30, "PermanentVodka", "Permanent Vodka"),
                new NewBuffItem(ModContent.ItemType<Whiskey>(), ModContent.BuffType<WhiskeyBuff>(), Common.AllEffects[ModContent.BuffType<WhiskeyBuff>()], 30, "PermanentWhiskey", "Permanent Whiskey"),
                new NewBuffItem(ModContent.ItemType<WhiteWine>(), ModContent.BuffType<WhiteWineBuff>(), Common.AllEffects[ModContent.BuffType<WhiteWineBuff>()], 30, "PermanentWhiteWine", "Permanent White Wine"),


                new NewBuffItem(ModContent.ItemType<ChaosCandle>(), ModContent.BuffType<ChaosCandleBuff>(), Common.AllEffects[ModContent.BuffType<ChaosCandleBuff>()], 3, "PermanentChaosCandle", "Permanent Chaos Candle"),
                new NewBuffItem(ModContent.ItemType<CorruptionEffigy>(), ModContent.BuffType<CorruptionEffigyBuff>(), Common.AllEffects[ModContent.BuffType<CorruptionEffigyBuff>()], 3, "PermanentCorruptionEffigy", "Permanent Corruption Effigy"),
                new NewBuffItem(ModContent.ItemType<CrimsonEffigy>(), ModContent.BuffType<CrimsonEffigyBuff>(), Common.AllEffects[ModContent.BuffType<CrimsonEffigyBuff>()], 3, "PermanentCrimsonEffigy", "Permanent Crimson Effigy"),
                new NewBuffItem(ModContent.ItemType<EffigyOfDecay>(), ModContent.BuffType<EffigyOfDecayBuff>(), Common.AllEffects[ModContent.BuffType<EffigyOfDecayBuff>()], 3, "PermanentEffigyOfDecay", "Permanent Effigy of Decay"),
                new NewBuffItem(ModContent.ItemType<ResilientCandle>(), ModContent.BuffType<PurpleCandleBuff>(), Common.AllEffects[ModContent.BuffType<PurpleCandleBuff>()], 3, "PermanentResilientCandle", "Permanent Resilient Candle"),
                new NewBuffItem(ModContent.ItemType<SpitefulCandle>(), ModContent.BuffType<YellowCandleBuff>(), Common.AllEffects[ModContent.BuffType<YellowCandleBuff>()], 3, "PermanentSpitefulCandle", "Permanent Spiteful Candle"),
                new NewBuffItem(ModContent.ItemType<TranquilityCandle>(), ModContent.BuffType<TranquilityCandleBuff>(), Common.AllEffects[ModContent.BuffType<TranquilityCandleBuff>()], 3, "PermanentTranquilityCandle", "Permanent Tranquility Candle"),
                new NewBuffItem(ModContent.ItemType<VigorousCandle>(), ModContent.BuffType<PinkCandleBuff>(), Common.AllEffects[ModContent.BuffType<PinkCandleBuff>()], 3, "PermanentVigorousCandle", "Permanent Vigorous Candle"),
                new NewBuffItem(ModContent.ItemType<WeightlessCandle>(), ModContent.BuffType<BlueCandleBuff>(), Common.AllEffects[ModContent.BuffType<BlueCandleBuff>()], 3, "PermanentWeightlessCandle", "Permanent Weightless Candle"),


                new NewBuffItem(ModContent.ItemType<AnechoicCoating>(), ModContent.BuffType<AnechoicCoatingBuff>(), Common.AllEffects[ModContent.BuffType<AnechoicCoatingBuff>()], 30, "PermanentAnechoicCoating", "Permanent Anechoic Coating"),
                new NewBuffItem(ModContent.ItemType<AstralInjection>(), ModContent.BuffType<AstralInjectionBuff>(), Common.AllEffects[ModContent.BuffType<AstralInjectionBuff>()], 30, "PermanentAstralInjection", "Permanent Astral Injection"),
                new NewBuffItem(ModContent.ItemType<Bloodfin>(), ModContent.BuffType<BloodfinBoost>(), Common.AllEffects[ModContent.BuffType<BloodfinBoost>()], 30, "PermanentBloodfin", "Permanent Bloodfin"),
                new NewBuffItem(ModContent.ItemType<BoundingPotion>(), ModContent.BuffType<BoundingBuff>(), Common.AllEffects[ModContent.BuffType<BoundingBuff>()], 30, "PermanentBounding", "Permanent Bounding"),
                new NewBuffItem(ModContent.ItemType<CalciumPotion>(), ModContent.BuffType<CalciumBuff>(), Common.AllEffects[ModContent.BuffType<CalciumBuff>()], 30, "PermanentCalcium", "Permanent Calcium"),
                new NewBuffItem(ModContent.ItemType<CeaselessHungerPotion>(), ModContent.BuffType<CeaselessHunger>(), Common.AllEffects[ModContent.BuffType<CeaselessHunger>()], 30, "PermanentCeaselessHunger", "Permanent Ceaseless Hunger"),
                new NewBuffItem(ModContent.ItemType<GravityNormalizerPotion>(), ModContent.BuffType<GravityNormalizerBuff>(), Common.AllEffects[ModContent.BuffType<GravityNormalizerBuff>()], 30, "PermanentGravityNormalizer", "Permanent Gravity Normalizer"),
                new NewBuffItem(ModContent.ItemType<PotionofOmniscience>(), ModContent.BuffType<Omniscience>(), Common.AllEffects[ModContent.BuffType<Omniscience>()], 30, "PermanentOmniscience", "Permanent Omniscience"),
                new NewBuffItem(ModContent.ItemType<PhotosynthesisPotion>(), ModContent.BuffType<PhotosynthesisBuff>(), Common.AllEffects[ModContent.BuffType<PhotosynthesisBuff>()], 30, "PermanentPhotosynthesis", "Permanent Photosynthesis"),
                new NewBuffItem(ModContent.ItemType<ShadowPotion>(), ModContent.BuffType<ShadowBuff>(), Common.AllEffects[ModContent.BuffType<ShadowBuff>()], 30, "PermanentShadow", "Permanent Shadow"),
                new NewBuffItem(ModContent.ItemType<SoaringPotion>(), ModContent.BuffType<Soaring>(), Common.AllEffects[ModContent.BuffType<Soaring>()], 30, "PermanentSoaring", "Permanent Soaring"),
                new NewBuffItem(ModContent.ItemType<SulphurskinPotion>(), ModContent.BuffType<SulphurskinBuff>(), Common.AllEffects[ModContent.BuffType<SulphurskinBuff>()], 30, "PermanentSulphurskin", "Permanent Sulphurskin"),
                new NewBuffItem(ModContent.ItemType<ZenPotion>(), ModContent.BuffType<Zen>(), Common.AllEffects[ModContent.BuffType<Zen>()], 30, "PermanentZen", "Permanent Zen"),
                new NewBuffItem(ModContent.ItemType<ZergPotion>(), ModContent.BuffType<Zerg>(), Common.AllEffects[ModContent.BuffType<Zerg>()], 30, "PermanentZerg", "Permanent Zerg"),


                new NewBuffItem(ModContent.ItemType<FlaskOfBrimstone>(), ModContent.BuffType<WeaponImbueBrimstone>(), Common.AllEffects[ModContent.BuffType<WeaponImbueBrimstone>()], 30, "PermanentFlaskOfBrimstone", "Permanent Flask of Brimstone"),
                new NewBuffItem(ModContent.ItemType<FlaskOfCrumbling>(), ModContent.BuffType<WeaponImbueCrumbling>(), Common.AllEffects[ModContent.BuffType<WeaponImbueCrumbling>()], 30, "PermanentFlaskOfCrumbling", "Permanent Flask of Crumbling"),
                new NewBuffItem(ModContent.ItemType<FlaskOfHolyFlames>(), ModContent.BuffType<WeaponImbueHolyFlames>(), Common.AllEffects[ModContent.BuffType<WeaponImbueHolyFlames>()], 30, "PermanentFlaskOfHolyFlames", "Permanent Flask of Holy Flames"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentCalamityAlcohols = new()
            {
                { Common.AllEffects[ModContent.BuffType<BloodyMaryBuff>()], ModContent.BuffType<BloodyMaryBuff>() },
                { Common.AllEffects[ModContent.BuffType<CaribbeanRumBuff>()], ModContent.BuffType<CaribbeanRumBuff>() },
                { Common.AllEffects[ModContent.BuffType<CinnamonRollBuff>()], ModContent.BuffType<CinnamonRollBuff>() },
                { Common.AllEffects[ModContent.BuffType<EverclearBuff>()], ModContent.BuffType<EverclearBuff>() },
                { Common.AllEffects[ModContent.BuffType<EvergreenGinBuff>()], ModContent.BuffType<EvergreenGinBuff>() },
                { Common.AllEffects[ModContent.BuffType<FireballBuff>()], ModContent.BuffType<FireballBuff>() },
                { Common.AllEffects[ModContent.BuffType<GrapeBeerBuff>()], ModContent.BuffType<GrapeBeerBuff>() },
                { Common.AllEffects[ModContent.BuffType<MargaritaBuff>()], ModContent.BuffType<MargaritaBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoonshineBuff>()], ModContent.BuffType<MoonshineBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoscowMuleBuff>()], ModContent.BuffType<MoscowMuleBuff>() },
                { Common.AllEffects[ModContent.BuffType<OldFashionedBuff>()], ModContent.BuffType<OldFashionedBuff>() },
                { Common.AllEffects[ModContent.BuffType<PurpleHazeBuff>()], ModContent.BuffType<PurpleHazeBuff>() },
                { Common.AllEffects[ModContent.BuffType<RedWineBuff>()], ModContent.BuffType<RedWineBuff>() },
                { Common.AllEffects[ModContent.BuffType<RumBuff>()], ModContent.BuffType<RumBuff>() },
                { Common.AllEffects[ModContent.BuffType<ScrewdriverBuff>()], ModContent.BuffType<ScrewdriverBuff>() },
                { Common.AllEffects[ModContent.BuffType<StarBeamRyeBuff>()], ModContent.BuffType<StarBeamRyeBuff>() },
                { Common.AllEffects[ModContent.BuffType<TequilaBuff>()], ModContent.BuffType<TequilaBuff>() },
                { Common.AllEffects[ModContent.BuffType<TequilaSunriseBuff>()], ModContent.BuffType<TequilaSunriseBuff>() },
                { Common.AllEffects[ModContent.BuffType<Trippy>()], ModContent.BuffType<Trippy>() },
                { Common.AllEffects[ModContent.BuffType<VodkaBuff>()], ModContent.BuffType<VodkaBuff>() },
                { Common.AllEffects[ModContent.BuffType<WhiskeyBuff>()], ModContent.BuffType<WhiskeyBuff>() },
                { Common.AllEffects[ModContent.BuffType<WhiteWineBuff>()], ModContent.BuffType<WhiteWineBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentCalamityAbyss = new()
            {
                { Common.AllEffects[ModContent.BuffType<AnechoicCoatingBuff>()], ModContent.BuffType<AnechoicCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<Omniscience>()], ModContent.BuffType<Omniscience>() },
                { Common.AllEffects[ModContent.BuffType<SulphurskinBuff>()], ModContent.BuffType<SulphurskinBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentCalamityDamage = new()
            {
                { Common.AllEffects[ModContent.BuffType<AstralInjectionBuff>()], ModContent.BuffType<AstralInjectionBuff>() },
                { Common.AllEffects[ModContent.BuffType<ShadowBuff>()], ModContent.BuffType<ShadowBuff>() }
            };

            if (CrossModSupport.Catalyst.Loaded)
            {
                PermanentCalamityDamage.Add(Common.AllEffects[CatalystBuffItems.AstracolaID], CatalystBuffItems.AstracolaID);
            }

            Dictionary<BuffEffect, int> PermanentCalamityDefense = new()
            {
                { Common.AllEffects[ModContent.BuffType<BaguetteBuff>()], ModContent.BuffType<BaguetteBuff>() },
                { Common.AllEffects[ModContent.BuffType<BloodfinBoost>()], ModContent.BuffType<BloodfinBoost>() },
                { Common.AllEffects[ModContent.BuffType<PhotosynthesisBuff>()], ModContent.BuffType<PhotosynthesisBuff>() },
            };

            Dictionary<BuffEffect, int> PermanentCalamityFarming = new()
            {
                { Common.AllEffects[ModContent.BuffType<CeaselessHunger>()], ModContent.BuffType<CeaselessHunger>() },
                { Common.AllEffects[ModContent.BuffType<Zen>()], ModContent.BuffType<Zen>() },
                { Common.AllEffects[ModContent.BuffType<Zerg>()], ModContent.BuffType<Zerg>() }
            };

            Dictionary<BuffEffect, int> PermanentCalamityMovement = new()
            {
                { Common.AllEffects[ModContent.BuffType<BoundingBuff>()], ModContent.BuffType<BoundingBuff>() },
                { Common.AllEffects[ModContent.BuffType<CalciumBuff>()], ModContent.BuffType<CalciumBuff>() },
                { Common.AllEffects[ModContent.BuffType<GravityNormalizerBuff>()], ModContent.BuffType<GravityNormalizerBuff>() },
                { Common.AllEffects[ModContent.BuffType<Soaring>()], ModContent.BuffType<Soaring>() }
            };

            Dictionary<BuffEffect, int> PermanentCalamityArena = new()
            {
                { Common.AllEffects[ModContent.BuffType<CorruptionEffigyBuff>()], ModContent.BuffType<CorruptionEffigyBuff>() },
                { Common.AllEffects[ModContent.BuffType<CrimsonEffigyBuff>()], ModContent.BuffType<CrimsonEffigyBuff>() },
                { Common.AllEffects[ModContent.BuffType<EffigyOfDecayBuff>()], ModContent.BuffType<EffigyOfDecayBuff>() },
                { Common.AllEffects[ModContent.BuffType<ChaosCandleBuff>()], ModContent.BuffType<ChaosCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<TranquilityCandleBuff>()], ModContent.BuffType<TranquilityCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<BlueCandleBuff>()], ModContent.BuffType<BlueCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<PinkCandleBuff>()], ModContent.BuffType<PinkCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<PurpleCandleBuff>()], ModContent.BuffType<PurpleCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<YellowCandleBuff>()], ModContent.BuffType<YellowCandleBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentCalamityFlasks = new()
            {
                { Common.AllEffects[ModContent.BuffType<WeaponImbueBrimstone>()], ModContent.BuffType<WeaponImbueBrimstone>() },
                { Common.AllEffects[ModContent.BuffType<WeaponImbueCrumbling>()], ModContent.BuffType<WeaponImbueCrumbling>() },
                { Common.AllEffects[ModContent.BuffType<WeaponImbueHolyFlames>()], ModContent.BuffType<WeaponImbueHolyFlames>() }
            };

            if (CrossModSupport.DraedonExpansion.Loaded)
            {
                PermanentCalamityFlasks.Add(Common.AllEffects[DraedonExpansionBuffItems.FlaskOfElectricityID], DraedonExpansionBuffItems.FlaskOfElectricityID);
            }

            Dictionary<BuffEffect, int> PermanentCalamity = new()
            {
                { Common.AllEffects[ModContent.BuffType<BloodyMaryBuff>()], ModContent.BuffType<BloodyMaryBuff>() },
                { Common.AllEffects[ModContent.BuffType<CaribbeanRumBuff>()], ModContent.BuffType<CaribbeanRumBuff>() },
                { Common.AllEffects[ModContent.BuffType<CinnamonRollBuff>()], ModContent.BuffType<CinnamonRollBuff>() },
                { Common.AllEffects[ModContent.BuffType<EverclearBuff>()], ModContent.BuffType<EverclearBuff>() },
                { Common.AllEffects[ModContent.BuffType<EvergreenGinBuff>()], ModContent.BuffType<EvergreenGinBuff>() },
                { Common.AllEffects[ModContent.BuffType<FireballBuff>()], ModContent.BuffType<FireballBuff>() },
                { Common.AllEffects[ModContent.BuffType<GrapeBeerBuff>()], ModContent.BuffType<GrapeBeerBuff>() },
                { Common.AllEffects[ModContent.BuffType<MargaritaBuff>()], ModContent.BuffType<MargaritaBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoonshineBuff>()], ModContent.BuffType<MoonshineBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoscowMuleBuff>()], ModContent.BuffType<MoscowMuleBuff>() },
                { Common.AllEffects[ModContent.BuffType<OldFashionedBuff>()], ModContent.BuffType<OldFashionedBuff>() },
                { Common.AllEffects[ModContent.BuffType<PurpleHazeBuff>()], ModContent.BuffType<PurpleHazeBuff>() },
                { Common.AllEffects[ModContent.BuffType<RedWineBuff>()], ModContent.BuffType<RedWineBuff>() },
                { Common.AllEffects[ModContent.BuffType<RumBuff>()], ModContent.BuffType<RumBuff>() },
                { Common.AllEffects[ModContent.BuffType<ScrewdriverBuff>()], ModContent.BuffType<ScrewdriverBuff>() },
                { Common.AllEffects[ModContent.BuffType<StarBeamRyeBuff>()], ModContent.BuffType<StarBeamRyeBuff>() },
                { Common.AllEffects[ModContent.BuffType<TequilaBuff>()], ModContent.BuffType<TequilaBuff>() },
                { Common.AllEffects[ModContent.BuffType<TequilaSunriseBuff>()], ModContent.BuffType<TequilaSunriseBuff>() },
                { Common.AllEffects[ModContent.BuffType<Trippy>()], ModContent.BuffType<Trippy>() },
                { Common.AllEffects[ModContent.BuffType<VodkaBuff>()], ModContent.BuffType<VodkaBuff>() },
                { Common.AllEffects[ModContent.BuffType<WhiskeyBuff>()], ModContent.BuffType<WhiskeyBuff>() },
                { Common.AllEffects[ModContent.BuffType<WhiteWineBuff>()], ModContent.BuffType<WhiteWineBuff>() },
                { Common.AllEffects[ModContent.BuffType<AnechoicCoatingBuff>()], ModContent.BuffType<AnechoicCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<Omniscience>()], ModContent.BuffType<Omniscience>() },
                { Common.AllEffects[ModContent.BuffType<SulphurskinBuff>()], ModContent.BuffType<SulphurskinBuff>() },
                { Common.AllEffects[ModContent.BuffType<AstralInjectionBuff>()], ModContent.BuffType<AstralInjectionBuff>() },
                { Common.AllEffects[ModContent.BuffType<ShadowBuff>()], ModContent.BuffType<ShadowBuff>() },
                { Common.AllEffects[ModContent.BuffType<BaguetteBuff>()], ModContent.BuffType<BaguetteBuff>() },
                { Common.AllEffects[ModContent.BuffType<BloodfinBoost>()], ModContent.BuffType<BloodfinBoost>() },
                { Common.AllEffects[ModContent.BuffType<PhotosynthesisBuff>()], ModContent.BuffType<PhotosynthesisBuff>() },
                { Common.AllEffects[ModContent.BuffType<CeaselessHunger>()], ModContent.BuffType<CeaselessHunger>() },
                { Common.AllEffects[ModContent.BuffType<Zen>()], ModContent.BuffType<Zen>() },
                { Common.AllEffects[ModContent.BuffType<Zerg>()], ModContent.BuffType<Zerg>() },
                { Common.AllEffects[ModContent.BuffType<BoundingBuff>()], ModContent.BuffType<BoundingBuff>() },
                { Common.AllEffects[ModContent.BuffType<CalciumBuff>()], ModContent.BuffType<CalciumBuff>() },
                { Common.AllEffects[ModContent.BuffType<GravityNormalizerBuff>()], ModContent.BuffType<GravityNormalizerBuff>() },
                { Common.AllEffects[ModContent.BuffType<Soaring>()], ModContent.BuffType<Soaring>() },
                { Common.AllEffects[ModContent.BuffType<CorruptionEffigyBuff>()], ModContent.BuffType<CorruptionEffigyBuff>() },
                { Common.AllEffects[ModContent.BuffType<CrimsonEffigyBuff>()], ModContent.BuffType<CrimsonEffigyBuff>() },
                { Common.AllEffects[ModContent.BuffType<EffigyOfDecayBuff>()], ModContent.BuffType<EffigyOfDecayBuff>() },
                { Common.AllEffects[ModContent.BuffType<ChaosCandleBuff>()], ModContent.BuffType<ChaosCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<TranquilityCandleBuff>()], ModContent.BuffType<TranquilityCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<BlueCandleBuff>()], ModContent.BuffType<BlueCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<PinkCandleBuff>()], ModContent.BuffType<PinkCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<PurpleCandleBuff>()], ModContent.BuffType<PurpleCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<YellowCandleBuff>()], ModContent.BuffType<YellowCandleBuff>() },
                { Common.AllEffects[ModContent.BuffType<WeaponImbueBrimstone>()], ModContent.BuffType<WeaponImbueBrimstone>() },
                { Common.AllEffects[ModContent.BuffType<WeaponImbueCrumbling>()], ModContent.BuffType<WeaponImbueCrumbling>() },
                { Common.AllEffects[ModContent.BuffType<WeaponImbueHolyFlames>()], ModContent.BuffType<WeaponImbueHolyFlames>() }
            };

            if (CrossModSupport.CalamityEntropy.Loaded)
            {
                PermanentCalamity.Add(Common.AllEffects[CalamityEntropyBuffItems.SoyMilkID], CalamityEntropyBuffItems.SoyMilkID);
                PermanentCalamity.Add(Common.AllEffects[CalamityEntropyBuffItems.YharimsStimulantsID], CalamityEntropyBuffItems.YharimsStimulantsID);
                PermanentCalamity.Add(Common.AllEffects[CalamityEntropyBuffItems.VoidCandleID], CalamityEntropyBuffItems.VoidCandleID);
            }

            if (CrossModSupport.CalamityRekindled.Loaded)
            {
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.BeetleJuiceID], CalamityRekindledBuffItems.BeetleJuiceID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.CadenceID], CalamityRekindledBuffItems.CadenceID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.DraconicElixirID], CalamityRekindledBuffItems.DraconicElixirID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.PenumbraID], CalamityRekindledBuffItems.PenumbraID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.ProfanedRageID], CalamityRekindledBuffItems.ProfanedRageID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.ProfanedWrathID], CalamityRekindledBuffItems.ProfanedWrathID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.RevivifyID], CalamityRekindledBuffItems.RevivifyID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.ShatteringID], CalamityRekindledBuffItems.ShatteringID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.TitanScaleID], CalamityRekindledBuffItems.TitanScaleID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.TriumphID], CalamityRekindledBuffItems.TriumphID);
                PermanentCalamity.Add(Common.AllEffects[CalamityRekindledBuffItems.YharimsStimulantsID], CalamityRekindledBuffItems.YharimsStimulantsID);
            }

            if (CrossModSupport.Catalyst.Loaded)
            {
                PermanentCalamity.Add(Common.AllEffects[CatalystBuffItems.AstracolaID], CatalystBuffItems.AstracolaID);
            }

            if (CrossModSupport.Clamity.Loaded)
            {
                PermanentCalamity.Add(Common.AllEffects[ClamityBuffItems.SupremeLuckID], ClamityBuffItems.SupremeLuckID);
                PermanentCalamity.Add(Common.AllEffects[ClamityBuffItems.TitanScaleID], ClamityBuffItems.TitanScaleID);
            }

            if (CrossModSupport.DraedonExpansion.Loaded)
            {
                PermanentCalamity.Add(Common.AllEffects[DraedonExpansionBuffItems.FlaskOfElectricityID], DraedonExpansionBuffItems.FlaskOfElectricityID);
            }

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentCalamityAlcohols, "PermanentCalamityAlcohols", "Permanent Calamity Alcohols", "PermanentCalamityAlcohols"),
                new NewCombinedBuffItem(PermanentCalamityAbyss, "PermanentCalamityAbyss", "Permanent Calamity Abyss", "PermanentCalamityAbyss"),
                new NewCombinedBuffItem(PermanentCalamityDamage, "PermanentCalamityDamage", "Permanent Calamity Damage", "PermanentCalamityDamage"),
                new NewCombinedBuffItem(PermanentCalamityDefense, "PermanentCalamityDefense", "Permanent Calamity Defense", "PermanentCalamityDefense"),
                new NewCombinedBuffItem(PermanentCalamityFarming, "PermanentCalamityFarming", "Permanent Calamity Farming", "PermanentCalamityFarming"),
                new NewCombinedBuffItem(PermanentCalamityMovement, "PermanentCalamityMovement", "Permanent Calamity Movement", "PermanentCalamityMovement"),
                new NewCombinedBuffItem(PermanentCalamityArena, "PermanentCalamityArena", "Permanent Calamity Arena", "PermanentCalamityArena"),
                new NewCombinedBuffItem(PermanentCalamityFlasks, "PermanentCalamityFlasks", "Permanent Calamity Flasks", "PermanentCalamityFlasks"),
                new NewCombinedBuffItem(PermanentCalamity, "PermanentCalamity", "Permanent Calamity", "PermanentCalamity"),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public static class CalamityEntropyBuffItems
    {
        public static NewBuffEffect[] CalamityEntropyEffects = [];

        public static int SoyMilkID = -1;
        public static int YharimsStimulantsID = -1;
        public static int VoidCandleID = -1;

        public static void LoadTasks()
        {
            SoyMilkID = ModContent.BuffType<SoyMilkBuff>();
            YharimsStimulantsID = ModContent.BuffType<CalamityEntropy.Content.Buffs.YharimPower>();
            VoidCandleID = ModContent.BuffType<VoidCandleBuff>();

            CalamityEntropyEffects = [
                //potions
                new NewBuffEffect(ModContent.BuffType<SoyMilkBuff>()),
                new NewBuffEffect(ModContent.BuffType<CalamityEntropy.Content.Buffs.YharimPower>()),
                new NewBuffEffect(ModContent.BuffType<VoidCandleBuff>(), (int)Common.EffectTypes.Arena)
            ];

            foreach (var newEffect in CalamityEntropyEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<SoyMilk>(), ModContent.BuffType<SoyMilkBuff>(), Common.AllEffects[ModContent.BuffType<SoyMilkBuff>()], 30, "PermanentSoyMilk", "Permanent Soy Milk"),
                new NewBuffItem(ModContent.ItemType<CalamityEntropy.Content.Items.YharimsStimulants>(), ModContent.BuffType<CalamityEntropy.Content.Buffs.YharimPower>(), Common.AllEffects[ModContent.BuffType<CalamityEntropy.Content.Buffs.YharimPower>()], 30, "PermanentYharimsStimulants", "Permanent Yharim's Stimulants"),
                new NewBuffItem(ModContent.ItemType<VoidCandle>(), ModContent.BuffType<VoidCandleBuff>(), Common.AllEffects[ModContent.BuffType<VoidCandleBuff>()], 3, "PermanentVoidCandle", "Permanent Void Candle")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }

            Dictionary<BuffEffect, int> PermanentCalamityEntropy = new()
            {
                { Common.AllEffects[ModContent.BuffType<SoyMilkBuff>()], ModContent.BuffType<SoyMilkBuff>() },
                { Common.AllEffects[ModContent.BuffType<CalamityEntropy.Content.Buffs.YharimPower>()], ModContent.BuffType<CalamityEntropy.Content.Buffs.YharimPower>() },
                { Common.AllEffects[ModContent.BuffType<VoidCandleBuff>()], ModContent.BuffType<VoidCandleBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentCalamityEntropy, "PermanentCalamityEntropy", "Permanent Calamity Entropy", "PermanentCalamityEntropy"),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.CalamityRekindled.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityRekindled.Name)]
    public static class CalamityRekindledBuffItems
    {
        public static NewBuffEffect[] CalamityRekindledEffects = [];

        public static int BeetleJuiceID = -1;
        public static int CadenceID = -1;
        public static int DraconicElixirID = -1;
        public static int PenumbraID = -1;
        public static int ProfanedRageID = -1;
        public static int ProfanedWrathID = -1;
        public static int RevivifyID = -1;
        public static int ShatteringID = -1;
        public static int TitanScaleID = -1;
        public static int TriumphID = -1;
        public static int YharimsStimulantsID = -1;

        public static void LoadTasks()
        {
            BeetleJuiceID = ModContent.BuffType<BeetleJuiceBuff>();
            CadenceID = ModContent.BuffType<Cadence>();
            DraconicElixirID = ModContent.BuffType<DraconicSurgeBuff>();
            PenumbraID = ModContent.BuffType<Penumbra>();
            ProfanedRageID = ModContent.BuffType<ProfanedRageBuff>();
            ProfanedWrathID = ModContent.BuffType<ProfanedWrathBuff>();
            RevivifyID = ModContent.BuffType<Revivify>();
            ShatteringID = ModContent.BuffType<ArmorShattering>();
            TitanScaleID = ModContent.BuffType<TitanScale>();
            TriumphID = ModContent.BuffType<TriumphBuff>();
            YharimsStimulantsID = ModContent.BuffType<CalamityLegacy.Content.Buffs.YharimPower>();

            CalamityRekindledEffects = [
                //potions
                new NewBuffEffect(ModContent.BuffType<BeetleJuiceBuff>()),
                new NewBuffEffect(ModContent.BuffType<Cadence>()),
                new NewBuffEffect(ModContent.BuffType<DraconicSurgeBuff>()),
                new NewBuffEffect(ModContent.BuffType<Penumbra>()),
                new NewBuffEffect(ModContent.BuffType<ProfanedRageBuff>()),
                new NewBuffEffect(ModContent.BuffType<ProfanedWrathBuff>()),
                new NewBuffEffect(ModContent.BuffType<Revivify>()),
                new NewBuffEffect(ModContent.BuffType<ArmorShattering>()),
                new NewBuffEffect(ModContent.BuffType<TitanScale>()),
                new NewBuffEffect(ModContent.BuffType<TriumphBuff>()),
                new NewBuffEffect(ModContent.BuffType<CalamityLegacy.Content.Buffs.YharimPower>())
            ];

            foreach (var newEffect in CalamityRekindledEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<BeetleJuice>(), ModContent.BuffType<BeetleJuiceBuff>(), Common.AllEffects[ModContent.BuffType<BeetleJuiceBuff>()], 30, "PermanentBeetleJuice", "Permanent Beetle Juice"),
                new NewBuffItem(ModContent.ItemType<CadencePotion>(), ModContent.BuffType<Cadence>(), Common.AllEffects[ModContent.BuffType<Cadence>()], 30, "PermanentCadence", "Permanent Cadence"),
                new NewBuffItem(ModContent.ItemType<DraconicElixir>(), ModContent.BuffType<DraconicSurgeBuff>(), Common.AllEffects[ModContent.BuffType<DraconicSurgeBuff>()], 30, "PermanentDraconicElixir", "Permanent Draconic Elixir"),
                new NewBuffItem(ModContent.ItemType<PenumbraPotion>(), ModContent.BuffType<Penumbra>(), Common.AllEffects[ModContent.BuffType<Penumbra>()], 30, "PermanentPenumbra", "Permanent Penumbra"),
                new NewBuffItem(ModContent.ItemType<ProfanedRagePotion>(), ModContent.BuffType<ProfanedRageBuff>(), Common.AllEffects[ModContent.BuffType<ProfanedRageBuff>()], 30, "PermanentProfanedRage", "Permanent Profaned Rage"),
                new NewBuffItem(ModContent.ItemType<ProfanedWrathPotion>(), ModContent.BuffType<ProfanedWrathBuff>(), Common.AllEffects[ModContent.BuffType<ProfanedWrathBuff>()], 30, "PermanentProfanedWrath", "Permanent Profaned Wrath"),
                new NewBuffItem(ModContent.ItemType<RevivifyPotion>(), ModContent.BuffType<Revivify>(), Common.AllEffects[ModContent.BuffType<Revivify>()], 30, "PermanentRevivify", "Permanent Revivify"),
                new NewBuffItem(ModContent.ItemType<ShatteringPotion>(), ModContent.BuffType<ArmorShattering>(), Common.AllEffects[ModContent.BuffType<ArmorShattering>()], 30, "PermanentShattering", "Permanent Shattering"),
                new NewBuffItem(ModContent.ItemType<CalamityLegacy.Content.Items.Potions.TitanScalePotion>(), ModContent.BuffType<TitanScale>(), Common.AllEffects[ModContent.BuffType<TitanScale>()], 30, "PermanentCRTitanScale", "Permanent Titan Scale"),
                new NewBuffItem(ModContent.ItemType<TriumphPotion>(), ModContent.BuffType<TriumphBuff>(), Common.AllEffects[ModContent.BuffType<TriumphBuff>()], 30, "PermanentTriumph", "Permanent Triumph"),
                new NewBuffItem(ModContent.ItemType<CalamityLegacy.Content.Items.Potions.YharimsStimulants>(), ModContent.BuffType<CalamityLegacy.Content.Buffs.YharimPower>(), Common.AllEffects[ModContent.BuffType<CalamityLegacy.Content.Buffs.YharimPower>()], 30, "PermanentCRYharimsStimulants", "Permanent Yharim's Stimulants"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }

            Dictionary<BuffEffect, int> PermanentCalamityRekindled = new()
            {
                { Common.AllEffects[ModContent.BuffType<BeetleJuiceBuff>()], ModContent.BuffType<BeetleJuiceBuff>() },
                { Common.AllEffects[ModContent.BuffType<Cadence>()], ModContent.BuffType<Cadence>() },
                { Common.AllEffects[ModContent.BuffType<DraconicSurgeBuff>()], ModContent.BuffType<DraconicSurgeBuff>() },
                { Common.AllEffects[ModContent.BuffType<Penumbra>()], ModContent.BuffType<Penumbra>() },
                { Common.AllEffects[ModContent.BuffType<ProfanedRageBuff>()], ModContent.BuffType<ProfanedRageBuff>() },
                { Common.AllEffects[ModContent.BuffType<ProfanedWrathBuff>()], ModContent.BuffType<ProfanedWrathBuff>() },
                { Common.AllEffects[ModContent.BuffType<Revivify>()], ModContent.BuffType<Revivify>() },
                { Common.AllEffects[ModContent.BuffType<ArmorShattering>()], ModContent.BuffType<ArmorShattering>() },
                { Common.AllEffects[ModContent.BuffType<TitanScale>()], ModContent.BuffType<TitanScale>() },
                { Common.AllEffects[ModContent.BuffType<TriumphBuff>()], ModContent.BuffType<TriumphBuff>() },
                { Common.AllEffects[ModContent.BuffType<CalamityLegacy.Content.Buffs.YharimPower>()], ModContent.BuffType<CalamityLegacy.Content.Buffs.YharimPower>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentCalamityRekindled, "PermanentCalamityRekindled", "Permanent Calamity Rekindled", "PermanentCalamityRekindled"),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.Catalyst.Name)]
    [ExtendsFromMod(CrossModSupport.Catalyst.Name)]
    public static class CatalystBuffItems
    {
        public static NewBuffEffect[] CatalystEffects = [];

        public static int AstracolaID = -1;

        public static void LoadTasks()
        {
            AstracolaID = ModContent.BuffType<AstralJellyBuff>();

            CatalystEffects = [
                //potions
                new NewBuffEffect(ModContent.BuffType<AstralJellyBuff>()),
            ];

            foreach (var newEffect in CatalystEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<Lean>(), ModContent.BuffType<AstralJellyBuff>(), Common.AllEffects[ModContent.BuffType<AstralJellyBuff>()], 30, "PermanentAstracola", "Permanent Astracola")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.Clamity.Name)]
    [ExtendsFromMod(CrossModSupport.Clamity.Name)]
    public static class ClamityBuffItems
    {
        public static NewBuffEffect[] ClamityEffects = [];

        public static int SupremeLuckID = -1;
        public static int TitanScaleID = -1;

        public static void LoadTasks()
        {
            SupremeLuckID = ModContent.BuffType<SupremeLucky>();
            TitanScaleID = ModContent.BuffType<TitanScalePotionBuff>();

            ClamityEffects = [
                //potions
                new NewBuffEffect(ModContent.BuffType<SupremeLucky>()),
                new NewBuffEffect(ModContent.BuffType<TitanScalePotionBuff>())
            ];

            foreach (var newEffect in ClamityEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<SupremeLuckPotion>(), ModContent.BuffType<SupremeLucky>(), Common.AllEffects[ModContent.BuffType<SupremeLucky>()], 30, "PermanentSupremeLuck", "Permanent Supreme Luck"),
                new NewBuffItem(ModContent.ItemType<Clamity.Content.Items.Potions.BuffPotions.TitanScalePotion>(), ModContent.BuffType<TitanScalePotionBuff>(), Common.AllEffects[ModContent.BuffType<TitanScalePotionBuff>()], 30, "PermanentTitanScale", "Permanent Titan Scale")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }

            Dictionary<BuffEffect, int> PermanentClamity = new()
            {
                { Common.AllEffects[ModContent.BuffType<SupremeLucky>()], ModContent.BuffType<SupremeLucky>() },
                { Common.AllEffects[ModContent.BuffType<TitanScalePotionBuff>()], ModContent.BuffType<TitanScalePotionBuff>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentClamity, "PermanentClamity", "Permanent Clamity", "PermanentClamity"),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.DraedonExpansion.Name)]
    [ExtendsFromMod(CrossModSupport.DraedonExpansion.Name)]
    public static class DraedonExpansionBuffItems
    {
        public static NewBuffEffect[] DraedonExpansionEffects = [];

        public static int FlaskOfElectricityID = -1;

        public static void LoadTasks()
        {
            FlaskOfElectricityID = ModContent.BuffType<FlaskOfElectricityBuff>();

            DraedonExpansionEffects = [
                //flasks
                new NewBuffEffect(ModContent.BuffType<FlaskOfElectricityBuff>(), (int)Common.EffectTypes.Flask),
            ];

            foreach (var newEffect in DraedonExpansionEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<FlaskOfElectricity>(), ModContent.BuffType<FlaskOfElectricityBuff>(), Common.AllEffects[ModContent.BuffType<FlaskOfElectricityBuff>()], 30, "PermanentFlaskOfElectricity", "Permanent Flask of Electricity")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
