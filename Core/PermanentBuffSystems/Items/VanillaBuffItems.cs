namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class VanillaBuffItems
    {
        public static NewBuffEffect[] VanillaEffects = [
            //potions
            new NewBuffEffect(BuffID.Flipper),
            new NewBuffEffect(BuffID.Gills),
            new NewBuffEffect(BuffID.WaterWalking),
            new NewBuffEffect(BuffID.Builder),
            new NewBuffEffect(BuffID.Calm),
            new NewBuffEffect(BuffID.Mining),
            new NewBuffEffect(BuffID.AmmoReservation),
            new NewBuffEffect(BuffID.Archery),
            new NewBuffEffect(BuffID.Battle),
            new NewBuffEffect(BuffID.Lucky),
            new NewBuffEffect(BuffID.MagicPower),
            new NewBuffEffect(BuffID.ManaRegeneration),
            new NewBuffEffect(BuffID.Summoning),
            new NewBuffEffect(BuffID.Tipsy),
            new NewBuffEffect(BuffID.Titan),
            new NewBuffEffect(BuffID.Rage),
            new NewBuffEffect(BuffID.Wrath),
            new NewBuffEffect(BuffID.Endurance),
            new NewBuffEffect(BuffID.WellFed3),
            new NewBuffEffect(BuffID.Heartreach),
            new NewBuffEffect(BuffID.Inferno),
            new NewBuffEffect(BuffID.Ironskin),
            new NewBuffEffect(BuffID.Lifeforce),
            new NewBuffEffect(BuffID.ObsidianSkin),
            new NewBuffEffect(BuffID.Regeneration),
            new NewBuffEffect(BuffID.Thorns),
            new NewBuffEffect(BuffID.Warmth),
            new NewBuffEffect(BuffID.Featherfall),
            new NewBuffEffect(BuffID.Gravitation),
            new NewBuffEffect(BuffID.Swiftness),
            new NewBuffEffect(BuffID.Crate),
            new NewBuffEffect(BuffID.Fishing),
            new NewBuffEffect(BuffID.Sonar),
            new NewBuffEffect(BuffID.BiomeSight),
            new NewBuffEffect(BuffID.Dangersense),
            new NewBuffEffect(BuffID.Hunter),
            new NewBuffEffect(BuffID.Invisibility),
            new NewBuffEffect(BuffID.NightOwl),
            new NewBuffEffect(BuffID.WellFed2),
            new NewBuffEffect(BuffID.Shine),
            new NewBuffEffect(BuffID.Spelunker),
            new NewBuffEffect(BuffID.WellFed),
            //arena
            new NewBuffEffect(BuffID.CatBast, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.Campfire, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.HeartLamp, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.Honey, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.PeaceCandle, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.ShadowCandle, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.StarInBottle, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.Sunflower, (int)Common.EffectTypes.Arena),
            new NewBuffEffect(BuffID.WaterCandle, (int)Common.EffectTypes.Arena),
            //station
            new NewBuffEffect(BuffID.AmmoBox, (int)Common.EffectTypes.Station),
            new NewBuffEffect(BuffID.Bewitched, (int)Common.EffectTypes.Station),
            new NewBuffEffect(BuffID.Clairvoyance, (int)Common.EffectTypes.Station),
            new NewBuffEffect(BuffID.Sharpened, (int)Common.EffectTypes.Station),
            new NewBuffEffect(BuffID.SugarRush, (int)Common.EffectTypes.Station),
            new NewBuffEffect(BuffID.WarTable, (int)Common.EffectTypes.Station),
            //flasks
            new NewBuffEffect(BuffID.WeaponImbueConfetti, (int)Common.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueCursedFlames, (int)Common.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueFire, (int)Common.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueGold, (int)Common.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueIchor, (int)Common.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueNanites, (int)Common.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbuePoison, (int)Common.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueVenom, (int)Common.EffectTypes.Flask)
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in VanillaEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ItemID.AmmoReservationPotion, BuffID.AmmoReservation, Common.AllEffects[BuffID.AmmoReservation], 30, "PermanentAmmoReservation", "Permanent Ammo Reservation"),
                new NewBuffItem(ItemID.ArcheryPotion, BuffID.Archery, Common.AllEffects[BuffID.Archery], 30, "PermanentArchery", "Permanent Archery"),
                new NewBuffItem(ItemID.BattlePotion, BuffID.Battle, Common.AllEffects[BuffID.Battle], 30, "PermanentBattle", "Permanent Battle"),
                new NewBuffItem(ItemID.BiomeSightPotion, BuffID.BiomeSight, Common.AllEffects[BuffID.BiomeSight], 30, "PermanentBiomeSight", "Permanent Biome Sight"),
                new NewBuffItem(ItemID.BuilderPotion, BuffID.Builder, Common.AllEffects[BuffID.Builder], 30, "PermanentBuilder", "Permanent Builder"),
                new NewBuffItem(ItemID.CalmingPotion, BuffID.Calm, Common.AllEffects[BuffID.Calm], 30, "PermanentCalm", "Permanent Calm"),
                new NewBuffItem(ItemID.CratePotion, BuffID.Crate, Common.AllEffects[BuffID.Crate], 30, "PermanentCrate", "Permanent Crate"),
                new NewBuffItem(ItemID.TrapsightPotion, BuffID.Dangersense, Common.AllEffects[BuffID.Dangersense], 30, "PermanentDangersense", "Permanent Dangersense"),
                new NewBuffItem(ItemID.EndurancePotion, BuffID.Endurance, Common.AllEffects[BuffID.Endurance], 30, "PermanentEndurance", "Permanent Endurance"),
                new NewBuffItem(ItemID.GoldenDelight, BuffID.WellFed3, Common.AllEffects[BuffID.WellFed3], 30, "PermanentExquisitelyStuffed", "Permanent Exquisitely Stuffed"),
                new NewBuffItem(ItemID.FeatherfallPotion, BuffID.Featherfall, Common.AllEffects[BuffID.Featherfall], 30, "PermanentFeatherfall", "Permanent Featherfall"),
                new NewBuffItem(ItemID.FishingPotion, BuffID.Fishing, Common.AllEffects[BuffID.Fishing], 30, "PermanentFishing", "Permanent Fishing"),
                new NewBuffItem(ItemID.FlipperPotion, BuffID.Flipper, Common.AllEffects[BuffID.Flipper], 30, "PermanentFlipper", "Permanent Flipper"),
                new NewBuffItem(ItemID.GillsPotion, BuffID.Gills, Common.AllEffects[BuffID.Gills], 30, "PermanentGills", "Permanent Gills"),
                new NewBuffItem(ItemID.GravitationPotion, BuffID.Gravitation, Common.AllEffects[BuffID.Gravitation], 30, "PermanentGravitation", "Permanent Gravitation"),
                new NewBuffItem(ItemID.LuckPotionGreater, BuffID.Lucky, Common.AllEffects[BuffID.Lucky], 30, "PermanentLucky", "Permanent Lucky"),
                new NewBuffItem(ItemID.HeartreachPotion, BuffID.Heartreach, Common.AllEffects[BuffID.Heartreach], 30, "PermanentHeartreach", "Permanent Heartreach"),
                new NewBuffItem(ItemID.HunterPotion, BuffID.Hunter, Common.AllEffects[BuffID.Hunter], 30, "PermanentHunter", "Permanent Hunter"),
                new NewBuffItem(ItemID.InfernoPotion, BuffID.Inferno, Common.AllEffects[BuffID.Inferno], 30, "PermanentInferno", "Permanent Inferno"),
                new NewBuffItem(ItemID.InvisibilityPotion, BuffID.Invisibility, Common.AllEffects[BuffID.Invisibility], 30, "PermanentInvisibility", "Permanent Invisibility"),
                new NewBuffItem(ItemID.IronskinPotion, BuffID.Ironskin, Common.AllEffects[BuffID.Ironskin], 30, "PermanentIronskin", "Permanent Ironskin"),
                new NewBuffItem(ItemID.LifeforcePotion, BuffID.Lifeforce, Common.AllEffects[BuffID.Lifeforce], 30, "PermanentLifeforce", "Permanent Lifeforce"),
                new NewBuffItem(ItemID.MagicPowerPotion, BuffID.MagicPower, Common.AllEffects[BuffID.MagicPower], 30, "PermanentMagicPower", "Permanent Magic Power"),
                new NewBuffItem(ItemID.ManaRegenerationPotion, BuffID.ManaRegeneration, Common.AllEffects[BuffID.ManaRegeneration], 30, "PermanentManaRegeneration", "Permanent Mana Regeneration"),
                new NewBuffItem(ItemID.MiningPotion, BuffID.Mining, Common.AllEffects[BuffID.Mining], 30, "PermanentMining", "Permanent Mining"),
                new NewBuffItem(ItemID.NightOwlPotion, BuffID.NightOwl, Common.AllEffects[BuffID.NightOwl], 30, "PermanentNightOwl", "Permanent Night Owl"),
                new NewBuffItem(ItemID.ObsidianSkinPotion, BuffID.ObsidianSkin, Common.AllEffects[BuffID.ObsidianSkin], 30, "PermanentObsidianSkin", "Permanent Obsidian Skin"),
                new NewBuffItem(ItemID.LobsterTail, BuffID.WellFed2, Common.AllEffects[BuffID.WellFed2], 30, "PermanentPlentySatisfied", "Permanent Plenty Satisfied"),
                new NewBuffItem(ItemID.RagePotion, BuffID.Rage, Common.AllEffects[BuffID.Rage], 30, "PermanentRage", "Permanent Rage"),
                new NewBuffItem(ItemID.RegenerationPotion, BuffID.Regeneration, Common.AllEffects[BuffID.Regeneration], 30, "PermanentRegeneration", "Permanent Regeneration"),
                new NewBuffItem(ItemID.ShinePotion, BuffID.Shine, Common.AllEffects[BuffID.Shine], 30, "PermanentShine", "Permanent Shine"),
                new NewBuffItem(ItemID.SonarPotion, BuffID.Sonar, Common.AllEffects[BuffID.Sonar], 30, "PermanentSonar", "Permanent Sonar"),
                new NewBuffItem(ItemID.SpelunkerPotion, BuffID.Spelunker, Common.AllEffects[BuffID.Spelunker], 30, "PermanentSpelunker", "Permanent Spelunker"),
                new NewBuffItem(ItemID.SummoningPotion, BuffID.Summoning, Common.AllEffects[BuffID.Summoning], 30, "PermanentSummoning", "Permanent Summoning"),
                new NewBuffItem(ItemID.SwiftnessPotion, BuffID.Swiftness, Common.AllEffects[BuffID.Swiftness], 30, "PermanentSwiftness", "Permanent Swiftness"),
                new NewBuffItem(ItemID.ThornsPotion, BuffID.Thorns, Common.AllEffects[BuffID.Thorns], 30, "PermanentThorns", "Permanent Thorns"),
                new NewBuffItem(ItemID.Sake, BuffID.Tipsy, Common.AllEffects[BuffID.Tipsy], 30, "PermanentTipsy", "Permanent Tipsy"),
                new NewBuffItem(ItemID.TitanPotion, BuffID.Titan, Common.AllEffects[BuffID.Titan], 30, "PermanentTitan", "Permanent Titan"),
                new NewBuffItem(ItemID.WarmthPotion, BuffID.Warmth, Common.AllEffects[BuffID.Warmth], 30, "PermanentWarmth", "Permanent Warmth"),
                new NewBuffItem(ItemID.WaterWalkingPotion, BuffID.WaterWalking, Common.AllEffects[BuffID.WaterWalking], 30, "PermanentWaterWalking", "Permanent Water Walking"),
                new NewBuffItem(ItemID.WrathPotion, BuffID.Wrath, Common.AllEffects[BuffID.Wrath], 30, "PermanentWrath", "Permanent Wrath"),
                new NewBuffItem(ItemID.Apple, BuffID.WellFed, Common.AllEffects[BuffID.WellFed], 30, "PermanentWellFed", "Permanent Well Fed"),
                //arena
                new NewBuffItem(ItemID.Campfire, BuffID.Campfire, Common.AllEffects[BuffID.Campfire], 3, "PermanentCampfire", "Permanent Campfire"),
                new NewBuffItem(ItemID.CatBast, BuffID.CatBast, Common.AllEffects[BuffID.CatBast], 3, "PermanentBastStatue", "Permanent Bast Statue"),
                new NewBuffItem(ItemID.HeartLantern, BuffID.HeartLamp, Common.AllEffects[BuffID.HeartLamp], 3, "PermanentHeartLantern", "Permanent Heart Lantern"),
                new NewBuffItem(ItemID.BottledHoney, BuffID.Honey, Common.AllEffects[BuffID.Honey], 30, "PermanentHoney", "Permanent Honey"),
                new NewBuffItem(ItemID.PeaceCandle, BuffID.PeaceCandle, Common.AllEffects[BuffID.PeaceCandle], 3, "PermanentPeaceCandle", "Permanent Peace Candle"),
                 new NewBuffItem(ItemID.ShadowCandle, BuffID.ShadowCandle, Common.AllEffects[BuffID.ShadowCandle], 3, "PermanentShadowCandle", "Permanent Shadow Candle"),
                new NewBuffItem(ItemID.StarinaBottle, BuffID.StarInBottle, Common.AllEffects[BuffID.StarInBottle], 3, "PermanentStarInABottle", "Permanent Star in a Bottle"),
                new NewBuffItem(ItemID.Sunflower, BuffID.Sunflower, Common.AllEffects[BuffID.Sunflower], 3, "PermanentSunflower", "Permanent Sunflower"),
                new NewBuffItem(ItemID.WaterCandle, BuffID.WaterCandle, Common.AllEffects[BuffID.WaterCandle], 3, "PermanentWaterCandle", "Permanent Water Candle"),
                //stations
                new NewBuffItem(ItemID.AmmoBox, BuffID.AmmoBox, Common.AllEffects[BuffID.AmmoBox], 3, "PermanentAmmoBox", "Permanent Ammo Box"),
                new NewBuffItem(ItemID.BewitchingTable, BuffID.Bewitched, Common.AllEffects[BuffID.Bewitched], 3, "PermanentBewitchingTable", "Permanent Bewitching Table"),
                new NewBuffItem(ItemID.CrystalBall, BuffID.Clairvoyance, Common.AllEffects[BuffID.Clairvoyance], 3, "PermanentCrystalBall", "Permanent Crystal Ball"),
                new NewBuffItem(ItemID.SharpeningStation, BuffID.Sharpened, Common.AllEffects[BuffID.Sharpened], 3, "PermanentSharpeningStation", "Permanent Sharpening Station"),
                new NewBuffItem(ItemID.SliceOfCake, BuffID.SugarRush, Common.AllEffects[BuffID.SugarRush], 3, "PermanentSliceOfCake", "Permanent Slice of Cake"),
                new NewBuffItem(ItemID.WarTable, BuffID.WarTable, Common.AllEffects[BuffID.WarTable], 3, "PermanentWarTable", "Permanent War Table"),
                //flasks
                new NewBuffItem(ItemID.FlaskofParty, BuffID.WeaponImbueConfetti, Common.AllEffects[BuffID.WeaponImbueConfetti], 30, "PermanentFlaskofParty", "Permanent Flask of Party"),
                new NewBuffItem(ItemID.FlaskofCursedFlames, BuffID.WeaponImbueCursedFlames, Common.AllEffects[BuffID.WeaponImbueCursedFlames], 30, "PermanentFlaskofCursedFlames", "Permanent Flask of Cursed Flames"),
                new NewBuffItem(ItemID.FlaskofFire, BuffID.WeaponImbueFire, Common.AllEffects[BuffID.WeaponImbueFire], 30, "PermanentFlaskofFire", "Permanent Flask of Fire"),
                new NewBuffItem(ItemID.FlaskofGold, BuffID.WeaponImbueGold, Common.AllEffects[BuffID.WeaponImbueGold], 30, "PermanentFlaskofGold", "Permanent Flask of Gold"),
                new NewBuffItem(ItemID.FlaskofIchor, BuffID.WeaponImbueIchor, Common.AllEffects[BuffID.WeaponImbueIchor], 30, "PermanentFlaskofIchor", "Permanent Flask of Ichor"),
                new NewBuffItem(ItemID.FlaskofNanites, BuffID.WeaponImbueNanites, Common.AllEffects[BuffID.WeaponImbueNanites], 30, "PermanentFlaskofNanites", "Permanent Flask of Nanites"),
                new NewBuffItem(ItemID.FlaskofPoison, BuffID.WeaponImbuePoison, Common.AllEffects[BuffID.WeaponImbuePoison], 30, "PermanentFlaskofPoison", "Permanent Flask of Poison"),
                new NewBuffItem(ItemID.FlaskofVenom, BuffID.WeaponImbueVenom, Common.AllEffects[BuffID.WeaponImbueVenom], 30, "PermanentFlaskofVenom", "Permanent Flask of Venom"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentAquatic = new()
            {
                { Common.AllEffects[BuffID.Flipper], BuffID.Flipper },
                { Common.AllEffects[BuffID.Gills], BuffID.Gills },
                { Common.AllEffects[BuffID.WaterWalking], BuffID.WaterWalking }
            };

            Dictionary<BuffEffect, int> PermanentConstruction = new()
            {
                { Common.AllEffects[BuffID.Builder], BuffID.Builder },
                { Common.AllEffects[BuffID.Calm], BuffID.Calm },
                { Common.AllEffects[BuffID.Mining], BuffID.Mining }
            };

            Dictionary<BuffEffect, int> PermanentDamage = new()
            {
                { Common.AllEffects[BuffID.AmmoReservation], BuffID.AmmoReservation },
                { Common.AllEffects[BuffID.Archery], BuffID.Archery },
                { Common.AllEffects[BuffID.Battle], BuffID.Battle },
                { Common.AllEffects[BuffID.Lucky], BuffID.Lucky },
                { Common.AllEffects[BuffID.MagicPower], BuffID.MagicPower },
                { Common.AllEffects[BuffID.ManaRegeneration], BuffID.ManaRegeneration },
                { Common.AllEffects[BuffID.Summoning], BuffID.Summoning },
                { Common.AllEffects[BuffID.Tipsy], BuffID.Tipsy },
                { Common.AllEffects[BuffID.Titan], BuffID.Titan },
                { Common.AllEffects[BuffID.Rage], BuffID.Rage },
                { Common.AllEffects[BuffID.Wrath], BuffID.Wrath }
            };

            Dictionary<BuffEffect, int> PermanentDefense = new()
            {
                { Common.AllEffects[BuffID.Endurance], BuffID.Endurance },
                { Common.AllEffects[BuffID.WellFed3], BuffID.WellFed3 },
                { Common.AllEffects[BuffID.Heartreach], BuffID.Heartreach },
                { Common.AllEffects[BuffID.Inferno], BuffID.Inferno },
                { Common.AllEffects[BuffID.Ironskin], BuffID.Ironskin },
                { Common.AllEffects[BuffID.Lifeforce], BuffID.Lifeforce },
                { Common.AllEffects[BuffID.ObsidianSkin], BuffID.ObsidianSkin },
                { Common.AllEffects[BuffID.WellFed2], BuffID.WellFed2 },
                { Common.AllEffects[BuffID.Regeneration], BuffID.Regeneration },
                { Common.AllEffects[BuffID.Thorns], BuffID.Thorns },
                { Common.AllEffects[BuffID.Warmth], BuffID.Warmth },
                { Common.AllEffects[BuffID.WellFed], BuffID.WellFed }
            };

            Dictionary<BuffEffect, int> PermanentMovement = new()
            {
                { Common.AllEffects[BuffID.Featherfall], BuffID.Featherfall },
                { Common.AllEffects[BuffID.Gravitation], BuffID.Gravitation },
                { Common.AllEffects[BuffID.Swiftness], BuffID.Swiftness }
            };

            Dictionary<BuffEffect, int> PermanentTrawler = new()
            {
                { Common.AllEffects[BuffID.Crate], BuffID.Crate },
                { Common.AllEffects[BuffID.Fishing], BuffID.Fishing },
                { Common.AllEffects[BuffID.Sonar], BuffID.Sonar }
            };

            Dictionary<BuffEffect, int> PermanentVision = new()
            {
                { Common.AllEffects[BuffID.BiomeSight], BuffID.BiomeSight },
                { Common.AllEffects[BuffID.Dangersense], BuffID.Dangersense },
                { Common.AllEffects[BuffID.Hunter], BuffID.Hunter },
                { Common.AllEffects[BuffID.Invisibility], BuffID.Invisibility },
                { Common.AllEffects[BuffID.NightOwl], BuffID.NightOwl },
                { Common.AllEffects[BuffID.Shine], BuffID.Shine },
                { Common.AllEffects[BuffID.Spelunker], BuffID.Spelunker }
            };

            Dictionary<BuffEffect, int> PermanentArena = new()
            {
                { Common.AllEffects[BuffID.CatBast], BuffID.CatBast },
                { Common.AllEffects[BuffID.Campfire], BuffID.Campfire },
                { Common.AllEffects[BuffID.HeartLamp], BuffID.HeartLamp },
                { Common.AllEffects[BuffID.Honey], BuffID.Honey },
                { Common.AllEffects[BuffID.PeaceCandle], BuffID.PeaceCandle },
                { Common.AllEffects[BuffID.ShadowCandle], BuffID.ShadowCandle },
                { Common.AllEffects[BuffID.StarInBottle], BuffID.StarInBottle },
                { Common.AllEffects[BuffID.Sunflower], BuffID.Sunflower },
                { Common.AllEffects[BuffID.WaterCandle], BuffID.WaterCandle }
            };

            Dictionary<BuffEffect, int> PermanentStation = new()
            {
                { Common.AllEffects[BuffID.AmmoBox], BuffID.AmmoBox },
                { Common.AllEffects[BuffID.Bewitched], BuffID.Bewitched },
                { Common.AllEffects[BuffID.Clairvoyance], BuffID.Clairvoyance },
                { Common.AllEffects[BuffID.Sharpened], BuffID.Sharpened },
                { Common.AllEffects[BuffID.SugarRush], BuffID.SugarRush },
                { Common.AllEffects[BuffID.WarTable], BuffID.WarTable }
            };

            Dictionary<BuffEffect, int> PermanentFlasks = new()
            {
                { Common.AllEffects[BuffID.WeaponImbueConfetti], BuffID.WeaponImbueConfetti },
                { Common.AllEffects[BuffID.WeaponImbueCursedFlames], BuffID.WeaponImbueCursedFlames },
                { Common.AllEffects[BuffID.WeaponImbueFire], BuffID.WeaponImbueFire },
                { Common.AllEffects[BuffID.WeaponImbueGold], BuffID.WeaponImbueGold },
                { Common.AllEffects[BuffID.WeaponImbueIchor], BuffID.WeaponImbueIchor },
                { Common.AllEffects[BuffID.WeaponImbueNanites], BuffID.WeaponImbueNanites },
                { Common.AllEffects[BuffID.WeaponImbuePoison], BuffID.WeaponImbuePoison },
                { Common.AllEffects[BuffID.WeaponImbueVenom], BuffID.WeaponImbueVenom }
            };

            Dictionary<BuffEffect, int> PermanentVanilla = new()
            {
                { Common.AllEffects[BuffID.Flipper], BuffID.Flipper },
                { Common.AllEffects[BuffID.Gills], BuffID.Gills },
                { Common.AllEffects[BuffID.WaterWalking], BuffID.WaterWalking },
                { Common.AllEffects[BuffID.Builder], BuffID.Builder },
                { Common.AllEffects[BuffID.Calm], BuffID.Calm },
                { Common.AllEffects[BuffID.Mining], BuffID.Mining },
                { Common.AllEffects[BuffID.AmmoReservation], BuffID.AmmoReservation },
                { Common.AllEffects[BuffID.Archery], BuffID.Archery },
                { Common.AllEffects[BuffID.Battle], BuffID.Battle },
                { Common.AllEffects[BuffID.Lucky], BuffID.Lucky },
                { Common.AllEffects[BuffID.MagicPower], BuffID.MagicPower },
                { Common.AllEffects[BuffID.ManaRegeneration], BuffID.ManaRegeneration },
                { Common.AllEffects[BuffID.Summoning], BuffID.Summoning },
                { Common.AllEffects[BuffID.Tipsy], BuffID.Tipsy },
                { Common.AllEffects[BuffID.Titan], BuffID.Titan },
                { Common.AllEffects[BuffID.Rage], BuffID.Rage },
                { Common.AllEffects[BuffID.Wrath], BuffID.Wrath },
                { Common.AllEffects[BuffID.Endurance], BuffID.Endurance },
                { Common.AllEffects[BuffID.WellFed3], BuffID.WellFed3 },
                { Common.AllEffects[BuffID.Heartreach], BuffID.Heartreach },
                { Common.AllEffects[BuffID.Inferno], BuffID.Inferno },
                { Common.AllEffects[BuffID.Ironskin], BuffID.Ironskin },
                { Common.AllEffects[BuffID.Lifeforce], BuffID.Lifeforce },
                { Common.AllEffects[BuffID.ObsidianSkin], BuffID.ObsidianSkin },
                { Common.AllEffects[BuffID.Regeneration], BuffID.Regeneration },
                { Common.AllEffects[BuffID.Thorns], BuffID.Thorns },
                { Common.AllEffects[BuffID.Warmth], BuffID.Warmth },
                { Common.AllEffects[BuffID.Featherfall], BuffID.Featherfall },
                { Common.AllEffects[BuffID.Gravitation], BuffID.Gravitation },
                { Common.AllEffects[BuffID.Swiftness], BuffID.Swiftness },
                { Common.AllEffects[BuffID.Crate], BuffID.Crate },
                { Common.AllEffects[BuffID.Fishing], BuffID.Fishing },
                { Common.AllEffects[BuffID.Sonar], BuffID.Sonar },
                { Common.AllEffects[BuffID.BiomeSight], BuffID.BiomeSight },
                { Common.AllEffects[BuffID.Dangersense], BuffID.Dangersense },
                { Common.AllEffects[BuffID.Hunter], BuffID.Hunter },
                { Common.AllEffects[BuffID.Invisibility], BuffID.Invisibility },
                { Common.AllEffects[BuffID.NightOwl], BuffID.NightOwl },
                { Common.AllEffects[BuffID.Shine], BuffID.Shine },
                { Common.AllEffects[BuffID.Spelunker], BuffID.Spelunker },
                { Common.AllEffects[BuffID.CatBast], BuffID.CatBast },
                { Common.AllEffects[BuffID.Campfire], BuffID.Campfire },
                { Common.AllEffects[BuffID.HeartLamp], BuffID.HeartLamp },
                { Common.AllEffects[BuffID.Honey], BuffID.Honey },
                { Common.AllEffects[BuffID.PeaceCandle], BuffID.PeaceCandle },
                { Common.AllEffects[BuffID.ShadowCandle], BuffID.ShadowCandle },
                { Common.AllEffects[BuffID.StarInBottle], BuffID.StarInBottle },
                { Common.AllEffects[BuffID.Sunflower], BuffID.Sunflower },
                { Common.AllEffects[BuffID.WaterCandle], BuffID.WaterCandle },
                { Common.AllEffects[BuffID.AmmoBox], BuffID.AmmoBox },
                { Common.AllEffects[BuffID.Bewitched], BuffID.Bewitched },
                { Common.AllEffects[BuffID.Clairvoyance], BuffID.Clairvoyance },
                { Common.AllEffects[BuffID.Sharpened], BuffID.Sharpened },
                { Common.AllEffects[BuffID.SugarRush], BuffID.SugarRush },
                { Common.AllEffects[BuffID.WarTable], BuffID.WarTable },
                { Common.AllEffects[BuffID.WeaponImbueConfetti], BuffID.WeaponImbueConfetti },
                { Common.AllEffects[BuffID.WeaponImbueCursedFlames], BuffID.WeaponImbueCursedFlames },
                { Common.AllEffects[BuffID.WeaponImbueFire], BuffID.WeaponImbueFire },
                { Common.AllEffects[BuffID.WeaponImbueGold], BuffID.WeaponImbueGold },
                { Common.AllEffects[BuffID.WeaponImbueIchor], BuffID.WeaponImbueIchor },
                { Common.AllEffects[BuffID.WeaponImbueNanites], BuffID.WeaponImbueNanites },
                { Common.AllEffects[BuffID.WeaponImbuePoison], BuffID.WeaponImbuePoison },
                { Common.AllEffects[BuffID.WeaponImbueVenom], BuffID.WeaponImbueVenom }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentAquatic, "PermanentAquatic", "Permanent Aquatic", "PermanentAquatic"),
                new NewCombinedBuffItem(PermanentConstruction, "PermanentConstruction", "Permanent Construction", "PermanentConstruction"),
                new NewCombinedBuffItem(PermanentDamage, "PermanentDamage", "Permanent Damage", "PermanentDamage"),
                new NewCombinedBuffItem(PermanentDefense, "PermanentDefense", "Permanent Defense", "PermanentDefense"),
                new NewCombinedBuffItem(PermanentMovement, "PermanentMovement", "Permanent Movement", "PermanentMovement"),
                new NewCombinedBuffItem(PermanentTrawler, "PermanentTrawler", "Permanent Trawler", "PermanentTrawler"),
                new NewCombinedBuffItem(PermanentVision, "PermanentVision", "Permanent Vision", "PermanentVision"),
                new NewCombinedBuffItem(PermanentArena, "PermanentArena", "Permanent Arena", "PermanentArena"),
                new NewCombinedBuffItem(PermanentStation, "PermanentStation", "Permanent Station", "PermanentStation"),
                new NewCombinedBuffItem(PermanentFlasks, "PermanentFlasks", "Permanent Flasks", "PermanentFlasks"),
                new NewCombinedBuffItem(PermanentVanilla, "PermanentVanilla", "Permanent Vanilla", "PermanentVanilla")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
