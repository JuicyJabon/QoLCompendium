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
            new NewBuffEffect(BuffID.CatBast, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.Campfire, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.HeartLamp, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.Honey, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.PeaceCandle, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.ShadowCandle, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.StarInBottle, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.Sunflower, (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(BuffID.WaterCandle, (int)Constants.EffectTypes.Arena),
            //station
            new NewBuffEffect(BuffID.AmmoBox, (int)Constants.EffectTypes.Station),
            new NewBuffEffect(BuffID.Bewitched, (int)Constants.EffectTypes.Station),
            new NewBuffEffect(BuffID.Clairvoyance, (int)Constants.EffectTypes.Station),
            new NewBuffEffect(BuffID.Sharpened, (int)Constants.EffectTypes.Station),
            new NewBuffEffect(BuffID.SugarRush, (int)Constants.EffectTypes.Station),
            new NewBuffEffect(BuffID.WarTable, (int)Constants.EffectTypes.Station),
            //flasks
            new NewBuffEffect(BuffID.WeaponImbueConfetti, (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueCursedFlames, (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueFire, (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueGold, (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueIchor, (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueNanites, (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbuePoison, (int)Constants.EffectTypes.Flask),
            new NewBuffEffect(BuffID.WeaponImbueVenom, (int)Constants.EffectTypes.Flask)
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
                Constants.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ItemID.AmmoReservationPotion, BuffID.AmmoReservation, Constants.AllEffects[BuffID.AmmoReservation], 30, "PermanentAmmoReservation", "Permanent Ammo Reservation"),
                new NewBuffItem(ItemID.ArcheryPotion, BuffID.Archery, Constants.AllEffects[BuffID.Archery], 30, "PermanentArchery", "Permanent Archery"),
                new NewBuffItem(ItemID.BattlePotion, BuffID.Battle, Constants.AllEffects[BuffID.Battle], 30, "PermanentBattle", "Permanent Battle"),
                new NewBuffItem(ItemID.BiomeSightPotion, BuffID.BiomeSight, Constants.AllEffects[BuffID.BiomeSight], 30, "PermanentBiomeSight", "Permanent Biome Sight"),
                new NewBuffItem(ItemID.BuilderPotion, BuffID.Builder, Constants.AllEffects[BuffID.Builder], 30, "PermanentBuilder", "Permanent Builder"),
                new NewBuffItem(ItemID.CalmingPotion, BuffID.Calm, Constants.AllEffects[BuffID.Calm], 30, "PermanentCalm", "Permanent Calm"),
                new NewBuffItem(ItemID.CratePotion, BuffID.Crate, Constants.AllEffects[BuffID.Crate], 30, "PermanentCrate", "Permanent Crate"),
                new NewBuffItem(ItemID.TrapsightPotion, BuffID.Dangersense, Constants.AllEffects[BuffID.Dangersense], 30, "PermanentDangersense", "Permanent Dangersense"),
                new NewBuffItem(ItemID.EndurancePotion, BuffID.Endurance, Constants.AllEffects[BuffID.Endurance], 30, "PermanentEndurance", "Permanent Endurance"),
                new NewBuffItem(ItemID.GoldenDelight, BuffID.WellFed3, Constants.AllEffects[BuffID.WellFed3], 30, "PermanentExquisitelyStuffed", "Permanent Exquisitely Stuffed"),
                new NewBuffItem(ItemID.FeatherfallPotion, BuffID.Featherfall, Constants.AllEffects[BuffID.Featherfall], 30, "PermanentFeatherfall", "Permanent Featherfall"),
                new NewBuffItem(ItemID.FishingPotion, BuffID.Fishing, Constants.AllEffects[BuffID.Fishing], 30, "PermanentFishing", "Permanent Fishing"),
                new NewBuffItem(ItemID.FlipperPotion, BuffID.Flipper, Constants.AllEffects[BuffID.Flipper], 30, "PermanentFlipper", "Permanent Flipper"),
                new NewBuffItem(ItemID.GillsPotion, BuffID.Gills, Constants.AllEffects[BuffID.Gills], 30, "PermanentGills", "Permanent Gills"),
                new NewBuffItem(ItemID.GravitationPotion, BuffID.Gravitation, Constants.AllEffects[BuffID.Gravitation], 30, "PermanentGravitation", "Permanent Gravitation"),
                new NewBuffItem(ItemID.LuckPotionGreater, BuffID.Lucky, Constants.AllEffects[BuffID.Lucky], 30, "PermanentLucky", "Permanent Lucky"),
                new NewBuffItem(ItemID.HeartreachPotion, BuffID.Heartreach, Constants.AllEffects[BuffID.Heartreach], 30, "PermanentHeartreach", "Permanent Heartreach"),
                new NewBuffItem(ItemID.HunterPotion, BuffID.Hunter, Constants.AllEffects[BuffID.Hunter], 30, "PermanentHunter", "Permanent Hunter"),
                new NewBuffItem(ItemID.InfernoPotion, BuffID.Inferno, Constants.AllEffects[BuffID.Inferno], 30, "PermanentInferno", "Permanent Inferno"),
                new NewBuffItem(ItemID.InvisibilityPotion, BuffID.Invisibility, Constants.AllEffects[BuffID.Invisibility], 30, "PermanentInvisibility", "Permanent Invisibility"),
                new NewBuffItem(ItemID.IronskinPotion, BuffID.Ironskin, Constants.AllEffects[BuffID.Ironskin], 30, "PermanentIronskin", "Permanent Ironskin"),
                new NewBuffItem(ItemID.LifeforcePotion, BuffID.Lifeforce, Constants.AllEffects[BuffID.Lifeforce], 30, "PermanentLifeforce", "Permanent Lifeforce"),
                new NewBuffItem(ItemID.MagicPowerPotion, BuffID.MagicPower, Constants.AllEffects[BuffID.MagicPower], 30, "PermanentMagicPower", "Permanent Magic Power"),
                new NewBuffItem(ItemID.ManaRegenerationPotion, BuffID.ManaRegeneration, Constants.AllEffects[BuffID.ManaRegeneration], 30, "PermanentManaRegeneration", "Permanent Mana Regeneration"),
                new NewBuffItem(ItemID.MiningPotion, BuffID.Mining, Constants.AllEffects[BuffID.Mining], 30, "PermanentMining", "Permanent Mining"),
                new NewBuffItem(ItemID.NightOwlPotion, BuffID.NightOwl, Constants.AllEffects[BuffID.NightOwl], 30, "PermanentNightOwl", "Permanent Night Owl"),
                new NewBuffItem(ItemID.ObsidianSkinPotion, BuffID.ObsidianSkin, Constants.AllEffects[BuffID.ObsidianSkin], 30, "PermanentObsidianSkin", "Permanent Obsidian Skin"),
                new NewBuffItem(ItemID.LobsterTail, BuffID.WellFed2, Constants.AllEffects[BuffID.WellFed2], 30, "PermanentPlentySatisfied", "Permanent Plenty Satisfied"),
                new NewBuffItem(ItemID.RagePotion, BuffID.Rage, Constants.AllEffects[BuffID.Rage], 30, "PermanentRage", "Permanent Rage"),
                new NewBuffItem(ItemID.RegenerationPotion, BuffID.Regeneration, Constants.AllEffects[BuffID.Regeneration], 30, "PermanentRegeneration", "Permanent Regeneration"),
                new NewBuffItem(ItemID.ShinePotion, BuffID.Shine, Constants.AllEffects[BuffID.Shine], 30, "PermanentShine", "Permanent Shine"),
                new NewBuffItem(ItemID.SonarPotion, BuffID.Sonar, Constants.AllEffects[BuffID.Sonar], 30, "PermanentSonar", "Permanent Sonar"),
                new NewBuffItem(ItemID.SpelunkerPotion, BuffID.Spelunker, Constants.AllEffects[BuffID.Spelunker], 30, "PermanentSpelunker", "Permanent Spelunker"),
                new NewBuffItem(ItemID.SummoningPotion, BuffID.Summoning, Constants.AllEffects[BuffID.Summoning], 30, "PermanentSummoning", "Permanent Summoning"),
                new NewBuffItem(ItemID.SwiftnessPotion, BuffID.Swiftness, Constants.AllEffects[BuffID.Swiftness], 30, "PermanentSwiftness", "Permanent Swiftness"),
                new NewBuffItem(ItemID.ThornsPotion, BuffID.Thorns, Constants.AllEffects[BuffID.Thorns], 30, "PermanentThorns", "Permanent Thorns"),
                new NewBuffItem(ItemID.Sake, BuffID.Tipsy, Constants.AllEffects[BuffID.Tipsy], 30, "PermanentTipsy", "Permanent Tipsy"),
                new NewBuffItem(ItemID.TitanPotion, BuffID.Titan, Constants.AllEffects[BuffID.Titan], 30, "PermanentTitan", "Permanent Titan"),
                new NewBuffItem(ItemID.WarmthPotion, BuffID.Warmth, Constants.AllEffects[BuffID.Warmth], 30, "PermanentWarmth", "Permanent Warmth"),
                new NewBuffItem(ItemID.WaterWalkingPotion, BuffID.WaterWalking, Constants.AllEffects[BuffID.WaterWalking], 30, "PermanentWaterWalking", "Permanent Water Walking"),
                new NewBuffItem(ItemID.WrathPotion, BuffID.Wrath, Constants.AllEffects[BuffID.Wrath], 30, "PermanentWrath", "Permanent Wrath"),
                new NewBuffItem(ItemID.Apple, BuffID.WellFed, Constants.AllEffects[BuffID.WellFed], 30, "PermanentWellFed", "Permanent Well Fed"),
                //arena
                new NewBuffItem(ItemID.Campfire, BuffID.Campfire, Constants.AllEffects[BuffID.Campfire], 3, "PermanentCampfire", "Permanent Campfire"),
                new NewBuffItem(ItemID.CatBast, BuffID.CatBast, Constants.AllEffects[BuffID.CatBast], 3, "PermanentBastStatue", "Permanent Bast Statue"),
                new NewBuffItem(ItemID.HeartLantern, BuffID.HeartLamp, Constants.AllEffects[BuffID.HeartLamp], 3, "PermanentHeartLantern", "Permanent Heart Lantern"),
                new NewBuffItem(ItemID.BottledHoney, BuffID.Honey, Constants.AllEffects[BuffID.Honey], 30, "PermanentHoney", "Permanent Honey"),
                new NewBuffItem(ItemID.PeaceCandle, BuffID.PeaceCandle, Constants.AllEffects[BuffID.PeaceCandle], 3, "PermanentPeaceCandle", "Permanent Peace Candle"),
                 new NewBuffItem(ItemID.ShadowCandle, BuffID.ShadowCandle, Constants.AllEffects[BuffID.ShadowCandle], 3, "PermanentShadowCandle", "Permanent Shadow Candle"),
                new NewBuffItem(ItemID.StarinaBottle, BuffID.StarInBottle, Constants.AllEffects[BuffID.StarInBottle], 3, "PermanentStarInABottle", "Permanent Star in a Bottle"),
                new NewBuffItem(ItemID.Sunflower, BuffID.Sunflower, Constants.AllEffects[BuffID.Sunflower], 3, "PermanentSunflower", "Permanent Sunflower"),
                new NewBuffItem(ItemID.WaterCandle, BuffID.WaterCandle, Constants.AllEffects[BuffID.WaterCandle], 3, "PermanentWaterCandle", "Permanent Water Candle"),
                //stations
                new NewBuffItem(ItemID.AmmoBox, BuffID.AmmoBox, Constants.AllEffects[BuffID.AmmoBox], 3, "PermanentAmmoBox", "Permanent Ammo Box"),
                new NewBuffItem(ItemID.BewitchingTable, BuffID.Bewitched, Constants.AllEffects[BuffID.Bewitched], 3, "PermanentBewitchingTable", "Permanent Bewitching Table"),
                new NewBuffItem(ItemID.CrystalBall, BuffID.Clairvoyance, Constants.AllEffects[BuffID.Clairvoyance], 3, "PermanentCrystalBall", "Permanent Crystal Ball"),
                new NewBuffItem(ItemID.SharpeningStation, BuffID.Sharpened, Constants.AllEffects[BuffID.Sharpened], 3, "PermanentSharpeningStation", "Permanent Sharpening Station"),
                new NewBuffItem(ItemID.SliceOfCake, BuffID.SugarRush, Constants.AllEffects[BuffID.SugarRush], 3, "PermanentSliceOfCake", "Permanent Slice of Cake"),
                new NewBuffItem(ItemID.WarTable, BuffID.WarTable, Constants.AllEffects[BuffID.WarTable], 3, "PermanentWarTable", "Permanent War Table"),
                //flasks
                new NewBuffItem(ItemID.FlaskofParty, BuffID.WeaponImbueConfetti, Constants.AllEffects[BuffID.WeaponImbueConfetti], 30, "PermanentFlaskofParty", "Permanent Flask of Party"),
                new NewBuffItem(ItemID.FlaskofCursedFlames, BuffID.WeaponImbueCursedFlames, Constants.AllEffects[BuffID.WeaponImbueCursedFlames], 30, "PermanentFlaskofCursedFlames", "Permanent Flask of Cursed Flames"),
                new NewBuffItem(ItemID.FlaskofFire, BuffID.WeaponImbueFire, Constants.AllEffects[BuffID.WeaponImbueFire], 30, "PermanentFlaskofFire", "Permanent Flask of Fire"),
                new NewBuffItem(ItemID.FlaskofGold, BuffID.WeaponImbueGold, Constants.AllEffects[BuffID.WeaponImbueGold], 30, "PermanentFlaskofGold", "Permanent Flask of Gold"),
                new NewBuffItem(ItemID.FlaskofIchor, BuffID.WeaponImbueIchor, Constants.AllEffects[BuffID.WeaponImbueIchor], 30, "PermanentFlaskofIchor", "Permanent Flask of Ichor"),
                new NewBuffItem(ItemID.FlaskofNanites, BuffID.WeaponImbueNanites, Constants.AllEffects[BuffID.WeaponImbueNanites], 30, "PermanentFlaskofNanites", "Permanent Flask of Nanites"),
                new NewBuffItem(ItemID.FlaskofPoison, BuffID.WeaponImbuePoison, Constants.AllEffects[BuffID.WeaponImbuePoison], 30, "PermanentFlaskofPoison", "Permanent Flask of Poison"),
                new NewBuffItem(ItemID.FlaskofVenom, BuffID.WeaponImbueVenom, Constants.AllEffects[BuffID.WeaponImbueVenom], 30, "PermanentFlaskofVenom", "Permanent Flask of Venom"),
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
            Dictionary<BuffEffect, int> PermanentAquatic = new()
            {
                { Constants.AllEffects[BuffID.Flipper], BuffID.Flipper },
                { Constants.AllEffects[BuffID.Gills], BuffID.Gills },
                { Constants.AllEffects[BuffID.WaterWalking], BuffID.WaterWalking }
            };

            Dictionary<BuffEffect, int> PermanentConstruction = new()
            {
                { Constants.AllEffects[BuffID.Builder], BuffID.Builder },
                { Constants.AllEffects[BuffID.Calm], BuffID.Calm },
                { Constants.AllEffects[BuffID.Mining], BuffID.Mining }
            };

            Dictionary<BuffEffect, int> PermanentDamage = new()
            {
                { Constants.AllEffects[BuffID.AmmoReservation], BuffID.AmmoReservation },
                { Constants.AllEffects[BuffID.Archery], BuffID.Archery },
                { Constants.AllEffects[BuffID.Battle], BuffID.Battle },
                { Constants.AllEffects[BuffID.Lucky], BuffID.Lucky },
                { Constants.AllEffects[BuffID.MagicPower], BuffID.MagicPower },
                { Constants.AllEffects[BuffID.ManaRegeneration], BuffID.ManaRegeneration },
                { Constants.AllEffects[BuffID.Summoning], BuffID.Summoning },
                { Constants.AllEffects[BuffID.Tipsy], BuffID.Tipsy },
                { Constants.AllEffects[BuffID.Titan], BuffID.Titan },
                { Constants.AllEffects[BuffID.Rage], BuffID.Rage },
                { Constants.AllEffects[BuffID.Wrath], BuffID.Wrath }
            };

            Dictionary<BuffEffect, int> PermanentDefense = new()
            {
                { Constants.AllEffects[BuffID.Endurance], BuffID.Endurance },
                { Constants.AllEffects[BuffID.WellFed3], BuffID.WellFed3 },
                { Constants.AllEffects[BuffID.Heartreach], BuffID.Heartreach },
                { Constants.AllEffects[BuffID.Inferno], BuffID.Inferno },
                { Constants.AllEffects[BuffID.Ironskin], BuffID.Ironskin },
                { Constants.AllEffects[BuffID.Lifeforce], BuffID.Lifeforce },
                { Constants.AllEffects[BuffID.ObsidianSkin], BuffID.ObsidianSkin },
                { Constants.AllEffects[BuffID.WellFed2], BuffID.WellFed2 },
                { Constants.AllEffects[BuffID.Regeneration], BuffID.Regeneration },
                { Constants.AllEffects[BuffID.Thorns], BuffID.Thorns },
                { Constants.AllEffects[BuffID.Warmth], BuffID.Warmth },
                { Constants.AllEffects[BuffID.WellFed], BuffID.WellFed }
            };

            Dictionary<BuffEffect, int> PermanentMovement = new()
            {
                { Constants.AllEffects[BuffID.Featherfall], BuffID.Featherfall },
                { Constants.AllEffects[BuffID.Gravitation], BuffID.Gravitation },
                { Constants.AllEffects[BuffID.Swiftness], BuffID.Swiftness }
            };

            Dictionary<BuffEffect, int> PermanentTrawler = new()
            {
                { Constants.AllEffects[BuffID.Crate], BuffID.Crate },
                { Constants.AllEffects[BuffID.Fishing], BuffID.Fishing },
                { Constants.AllEffects[BuffID.Sonar], BuffID.Sonar }
            };

            Dictionary<BuffEffect, int> PermanentVision = new()
            {
                { Constants.AllEffects[BuffID.BiomeSight], BuffID.BiomeSight },
                { Constants.AllEffects[BuffID.Dangersense], BuffID.Dangersense },
                { Constants.AllEffects[BuffID.Hunter], BuffID.Hunter },
                { Constants.AllEffects[BuffID.Invisibility], BuffID.Invisibility },
                { Constants.AllEffects[BuffID.NightOwl], BuffID.NightOwl },
                { Constants.AllEffects[BuffID.Shine], BuffID.Shine },
                { Constants.AllEffects[BuffID.Spelunker], BuffID.Spelunker }
            };

            Dictionary<BuffEffect, int> PermanentArena = new()
            {
                { Constants.AllEffects[BuffID.CatBast], BuffID.CatBast },
                { Constants.AllEffects[BuffID.Campfire], BuffID.Campfire },
                { Constants.AllEffects[BuffID.HeartLamp], BuffID.HeartLamp },
                { Constants.AllEffects[BuffID.Honey], BuffID.Honey },
                { Constants.AllEffects[BuffID.PeaceCandle], BuffID.PeaceCandle },
                { Constants.AllEffects[BuffID.ShadowCandle], BuffID.ShadowCandle },
                { Constants.AllEffects[BuffID.StarInBottle], BuffID.StarInBottle },
                { Constants.AllEffects[BuffID.Sunflower], BuffID.Sunflower },
                { Constants.AllEffects[BuffID.WaterCandle], BuffID.WaterCandle }
            };

            Dictionary<BuffEffect, int> PermanentStation = new()
            {
                { Constants.AllEffects[BuffID.AmmoBox], BuffID.AmmoBox },
                { Constants.AllEffects[BuffID.Bewitched], BuffID.Bewitched },
                { Constants.AllEffects[BuffID.Clairvoyance], BuffID.Clairvoyance },
                { Constants.AllEffects[BuffID.Sharpened], BuffID.Sharpened },
                { Constants.AllEffects[BuffID.SugarRush], BuffID.SugarRush },
                { Constants.AllEffects[BuffID.WarTable], BuffID.WarTable }
            };

            Dictionary<BuffEffect, int> PermanentFlasks = new()
            {
                { Constants.AllEffects[BuffID.WeaponImbueConfetti], BuffID.WeaponImbueConfetti },
                { Constants.AllEffects[BuffID.WeaponImbueCursedFlames], BuffID.WeaponImbueCursedFlames },
                { Constants.AllEffects[BuffID.WeaponImbueFire], BuffID.WeaponImbueFire },
                { Constants.AllEffects[BuffID.WeaponImbueGold], BuffID.WeaponImbueGold },
                { Constants.AllEffects[BuffID.WeaponImbueIchor], BuffID.WeaponImbueIchor },
                { Constants.AllEffects[BuffID.WeaponImbueNanites], BuffID.WeaponImbueNanites },
                { Constants.AllEffects[BuffID.WeaponImbuePoison], BuffID.WeaponImbuePoison },
                { Constants.AllEffects[BuffID.WeaponImbueVenom], BuffID.WeaponImbueVenom }
            };

            Dictionary<BuffEffect, int> PermanentVanilla = new()
            {
                { Constants.AllEffects[BuffID.Flipper], BuffID.Flipper },
                { Constants.AllEffects[BuffID.Gills], BuffID.Gills },
                { Constants.AllEffects[BuffID.WaterWalking], BuffID.WaterWalking },
                { Constants.AllEffects[BuffID.Builder], BuffID.Builder },
                { Constants.AllEffects[BuffID.Calm], BuffID.Calm },
                { Constants.AllEffects[BuffID.Mining], BuffID.Mining },
                { Constants.AllEffects[BuffID.AmmoReservation], BuffID.AmmoReservation },
                { Constants.AllEffects[BuffID.Archery], BuffID.Archery },
                { Constants.AllEffects[BuffID.Battle], BuffID.Battle },
                { Constants.AllEffects[BuffID.Lucky], BuffID.Lucky },
                { Constants.AllEffects[BuffID.MagicPower], BuffID.MagicPower },
                { Constants.AllEffects[BuffID.ManaRegeneration], BuffID.ManaRegeneration },
                { Constants.AllEffects[BuffID.Summoning], BuffID.Summoning },
                { Constants.AllEffects[BuffID.Tipsy], BuffID.Tipsy },
                { Constants.AllEffects[BuffID.Titan], BuffID.Titan },
                { Constants.AllEffects[BuffID.Rage], BuffID.Rage },
                { Constants.AllEffects[BuffID.Wrath], BuffID.Wrath },
                { Constants.AllEffects[BuffID.Endurance], BuffID.Endurance },
                { Constants.AllEffects[BuffID.WellFed3], BuffID.WellFed3 },
                { Constants.AllEffects[BuffID.Heartreach], BuffID.Heartreach },
                { Constants.AllEffects[BuffID.Inferno], BuffID.Inferno },
                { Constants.AllEffects[BuffID.Ironskin], BuffID.Ironskin },
                { Constants.AllEffects[BuffID.Lifeforce], BuffID.Lifeforce },
                { Constants.AllEffects[BuffID.ObsidianSkin], BuffID.ObsidianSkin },
                { Constants.AllEffects[BuffID.Regeneration], BuffID.Regeneration },
                { Constants.AllEffects[BuffID.Thorns], BuffID.Thorns },
                { Constants.AllEffects[BuffID.Warmth], BuffID.Warmth },
                { Constants.AllEffects[BuffID.Featherfall], BuffID.Featherfall },
                { Constants.AllEffects[BuffID.Gravitation], BuffID.Gravitation },
                { Constants.AllEffects[BuffID.Swiftness], BuffID.Swiftness },
                { Constants.AllEffects[BuffID.Crate], BuffID.Crate },
                { Constants.AllEffects[BuffID.Fishing], BuffID.Fishing },
                { Constants.AllEffects[BuffID.Sonar], BuffID.Sonar },
                { Constants.AllEffects[BuffID.BiomeSight], BuffID.BiomeSight },
                { Constants.AllEffects[BuffID.Dangersense], BuffID.Dangersense },
                { Constants.AllEffects[BuffID.Hunter], BuffID.Hunter },
                { Constants.AllEffects[BuffID.Invisibility], BuffID.Invisibility },
                { Constants.AllEffects[BuffID.NightOwl], BuffID.NightOwl },
                { Constants.AllEffects[BuffID.Shine], BuffID.Shine },
                { Constants.AllEffects[BuffID.Spelunker], BuffID.Spelunker },
                { Constants.AllEffects[BuffID.CatBast], BuffID.CatBast },
                { Constants.AllEffects[BuffID.Campfire], BuffID.Campfire },
                { Constants.AllEffects[BuffID.HeartLamp], BuffID.HeartLamp },
                { Constants.AllEffects[BuffID.Honey], BuffID.Honey },
                { Constants.AllEffects[BuffID.PeaceCandle], BuffID.PeaceCandle },
                { Constants.AllEffects[BuffID.ShadowCandle], BuffID.ShadowCandle },
                { Constants.AllEffects[BuffID.StarInBottle], BuffID.StarInBottle },
                { Constants.AllEffects[BuffID.Sunflower], BuffID.Sunflower },
                { Constants.AllEffects[BuffID.WaterCandle], BuffID.WaterCandle },
                { Constants.AllEffects[BuffID.AmmoBox], BuffID.AmmoBox },
                { Constants.AllEffects[BuffID.Bewitched], BuffID.Bewitched },
                { Constants.AllEffects[BuffID.Clairvoyance], BuffID.Clairvoyance },
                { Constants.AllEffects[BuffID.Sharpened], BuffID.Sharpened },
                { Constants.AllEffects[BuffID.SugarRush], BuffID.SugarRush },
                { Constants.AllEffects[BuffID.WarTable], BuffID.WarTable },
                { Constants.AllEffects[BuffID.WeaponImbueConfetti], BuffID.WeaponImbueConfetti },
                { Constants.AllEffects[BuffID.WeaponImbueCursedFlames], BuffID.WeaponImbueCursedFlames },
                { Constants.AllEffects[BuffID.WeaponImbueFire], BuffID.WeaponImbueFire },
                { Constants.AllEffects[BuffID.WeaponImbueGold], BuffID.WeaponImbueGold },
                { Constants.AllEffects[BuffID.WeaponImbueIchor], BuffID.WeaponImbueIchor },
                { Constants.AllEffects[BuffID.WeaponImbueNanites], BuffID.WeaponImbueNanites },
                { Constants.AllEffects[BuffID.WeaponImbuePoison], BuffID.WeaponImbuePoison },
                { Constants.AllEffects[BuffID.WeaponImbueVenom], BuffID.WeaponImbueVenom }
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
                Constants.AllCombinedBuffItems.Add(item.Type);
            }
        }
    }
}
