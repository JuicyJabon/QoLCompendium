namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class VanillaBuffItems
    {
        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] VanillaEffects = [
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
            new NewBuffEffect(BuffID.WeaponImbueVenom, (int)Constants.EffectTypes.Flask)];

            foreach (var newEffect in VanillaEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ItemID.AmmoReservationPotion, Constants.AllEffects[BuffID.AmmoReservation], 30, "PermanentAmmoReservation"),
                new NewBuffItem(ItemID.ArcheryPotion, Constants.AllEffects[BuffID.Archery], 30, "PermanentArchery"),
                new NewBuffItem(ItemID.BattlePotion, Constants.AllEffects[BuffID.Battle], 30, "PermanentBattle"),
                new NewBuffItem(ItemID.BiomeSightPotion, Constants.AllEffects[BuffID.BiomeSight], 30, "PermanentBiomeSight"),
                new NewBuffItem(ItemID.BuilderPotion, Constants.AllEffects[BuffID.Builder], 30, "PermanentBuilder"),
                new NewBuffItem(ItemID.CalmingPotion, Constants.AllEffects[BuffID.Calm], 30, "PermanentCalm"),
                new NewBuffItem(ItemID.CratePotion, Constants.AllEffects[BuffID.Crate], 30, "PermanentCrate"),
                new NewBuffItem(ItemID.TrapsightPotion, Constants.AllEffects[BuffID.Dangersense], 30, "PermanentDangersense"),
                new NewBuffItem(ItemID.EndurancePotion, Constants.AllEffects[BuffID.Endurance], 30, "PermanentEndurance"),
                new NewBuffItem(ItemID.GoldenDelight, Constants.AllEffects[BuffID.WellFed3], 30, "PermanentExquisitelyStuffed"),
                new NewBuffItem(ItemID.FeatherfallPotion, Constants.AllEffects[BuffID.Featherfall], 30, "PermanentFeatherfall"),
                new NewBuffItem(ItemID.FishingPotion, Constants.AllEffects[BuffID.Fishing], 30, "PermanentFishing"),
                new NewBuffItem(ItemID.FlipperPotion, Constants.AllEffects[BuffID.Flipper], 30, "PermanentFlipper"),
                new NewBuffItem(ItemID.GillsPotion, Constants.AllEffects[BuffID.Gills], 30, "PermanentGills"),
                new NewBuffItem(ItemID.GravitationPotion, Constants.AllEffects[BuffID.Gravitation], 30, "PermanentGravitation"),
                new NewBuffItem(ItemID.LuckPotionGreater, Constants.AllEffects[BuffID.Lucky], 30, "PermanentLucky"),
                new NewBuffItem(ItemID.HeartreachPotion, Constants.AllEffects[BuffID.Heartreach], 30, "PermanentHeartreach"),
                new NewBuffItem(ItemID.HunterPotion, Constants.AllEffects[BuffID.Hunter], 30, "PermanentHunter"),
                new NewBuffItem(ItemID.InfernoPotion, Constants.AllEffects[BuffID.Inferno], 30, "PermanentInferno"),
                new NewBuffItem(ItemID.InvisibilityPotion, Constants.AllEffects[BuffID.Invisibility], 30, "PermanentInvisibility"),
                new NewBuffItem(ItemID.IronskinPotion, Constants.AllEffects[BuffID.Ironskin], 30, "PermanentIronskin"),
                new NewBuffItem(ItemID.LifeforcePotion, Constants.AllEffects[BuffID.Lifeforce], 30, "PermanentLifeforce"),
                new NewBuffItem(ItemID.MagicPowerPotion, Constants.AllEffects[BuffID.MagicPower], 30, "PermanentMagicPower"),
                new NewBuffItem(ItemID.ManaRegenerationPotion, Constants.AllEffects[BuffID.ManaRegeneration], 30, "PermanentManaRegeneration"),
                new NewBuffItem(ItemID.MiningPotion, Constants.AllEffects[BuffID.Mining], 30, "PermanentMining"),
                new NewBuffItem(ItemID.NightOwlPotion, Constants.AllEffects[BuffID.NightOwl], 30, "PermanentNightOwl"),
                new NewBuffItem(ItemID.ObsidianSkinPotion, Constants.AllEffects[BuffID.ObsidianSkin], 30, "PermanentObsidianSkin"),
                new NewBuffItem(ItemID.LobsterTail, Constants.AllEffects[BuffID.WellFed2], 30, "PermanentPlentySatisfied"),
                new NewBuffItem(ItemID.RagePotion, Constants.AllEffects[BuffID.Rage], 30, "PermanentRage"),
                new NewBuffItem(ItemID.RegenerationPotion, Constants.AllEffects[BuffID.Regeneration], 30, "PermanentRegeneration"),
                new NewBuffItem(ItemID.ShinePotion, Constants.AllEffects[BuffID.Shine], 30, "PermanentShine"),
                new NewBuffItem(ItemID.SonarPotion, Constants.AllEffects[BuffID.Sonar], 30, "PermanentSonar"),
                new NewBuffItem(ItemID.SpelunkerPotion, Constants.AllEffects[BuffID.Spelunker], 30, "PermanentSpelunker"),
                new NewBuffItem(ItemID.SummoningPotion, Constants.AllEffects[BuffID.Summoning], 30, "PermanentSummoning"),
                new NewBuffItem(ItemID.SwiftnessPotion, Constants.AllEffects[BuffID.Swiftness], 30, "PermanentSwiftness"),
                new NewBuffItem(ItemID.ThornsPotion, Constants.AllEffects[BuffID.Thorns], 30, "PermanentThorns"),
                new NewBuffItem(ItemID.Sake, Constants.AllEffects[BuffID.Tipsy], 30, "PermanentTipsy"),
                new NewBuffItem(ItemID.TitanPotion, Constants.AllEffects[BuffID.Titan], 30, "PermanentTitan"),
                new NewBuffItem(ItemID.WarmthPotion, Constants.AllEffects[BuffID.Warmth], 30, "PermanentWarmth"),
                new NewBuffItem(ItemID.WaterWalkingPotion, Constants.AllEffects[BuffID.WaterWalking], 30, "PermanentWaterWalking"),
                new NewBuffItem(ItemID.WrathPotion, Constants.AllEffects[BuffID.Wrath], 30, "PermanentWrath"),
                new NewBuffItem(ItemID.Apple, Constants.AllEffects[BuffID.WellFed], 30, "PermanentWellFed"),
                //arena
                new NewBuffItem(ItemID.Campfire, Constants.AllEffects[BuffID.Campfire], 3, "PermanentCampfire"),
                new NewBuffItem(ItemID.CatBast, Constants.AllEffects[BuffID.CatBast], 3, "PermanentBastStatue"),
                new NewBuffItem(ItemID.HeartLantern, Constants.AllEffects[BuffID.HeartLamp], 3, "PermanentHeartLantern"),
                new NewBuffItem(ItemID.BottledHoney, Constants.AllEffects[BuffID.Honey], 30, "PermanentHoney"),
                new NewBuffItem(ItemID.PeaceCandle, Constants.AllEffects[BuffID.PeaceCandle], 3, "PermanentPeaceCandle"),
                 new NewBuffItem(ItemID.ShadowCandle, Constants.AllEffects[BuffID.ShadowCandle], 3, "PermanentShadowCandle"),
                new NewBuffItem(ItemID.StarinaBottle, Constants.AllEffects[BuffID.StarInBottle], 3, "PermanentStarInABottle"),
                new NewBuffItem(ItemID.Sunflower, Constants.AllEffects[BuffID.Sunflower], 3, "PermanentSunflower"),
                new NewBuffItem(ItemID.WaterCandle, Constants.AllEffects[BuffID.WaterCandle], 3, "PermanentWaterCandle"),
                //stations
                new NewBuffItem(ItemID.AmmoBox, Constants.AllEffects[BuffID.AmmoBox], 3, "PermanentAmmoBox"),
                new NewBuffItem(ItemID.BewitchingTable, Constants.AllEffects[BuffID.Bewitched], 3, "PermanentBewitchingTable"),
                new NewBuffItem(ItemID.CrystalBall, Constants.AllEffects[BuffID.Clairvoyance], 3, "PermanentCrystalBall"),
                new NewBuffItem(ItemID.SharpeningStation, Constants.AllEffects[BuffID.Sharpened], 3, "PermanentSharpeningStation"),
                new NewBuffItem(ItemID.SliceOfCake, Constants.AllEffects[BuffID.SugarRush], 3, "PermanentSliceOfCake"),
                new NewBuffItem(ItemID.WarTable, Constants.AllEffects[BuffID.WarTable], 3, "PermanentWarTable"),
                //flasks
                new NewBuffItem(ItemID.FlaskofParty, Constants.AllEffects[BuffID.WeaponImbueConfetti], 30, "PermanentFlaskofParty"),
                new NewBuffItem(ItemID.FlaskofCursedFlames, Constants.AllEffects[BuffID.WeaponImbueCursedFlames], 30, "PermanentFlaskofCursedFlames"),
                new NewBuffItem(ItemID.FlaskofFire, Constants.AllEffects[BuffID.WeaponImbueFire], 30, "PermanentFlaskofFire"),
                new NewBuffItem(ItemID.FlaskofGold, Constants.AllEffects[BuffID.WeaponImbueGold], 30, "PermanentFlaskofGold"),
                new NewBuffItem(ItemID.FlaskofIchor, Constants.AllEffects[BuffID.WeaponImbueIchor], 30, "PermanentFlaskofIchor"),
                new NewBuffItem(ItemID.FlaskofNanites, Constants.AllEffects[BuffID.WeaponImbueNanites], 30, "PermanentFlaskofNanites"),
                new NewBuffItem(ItemID.FlaskofPoison, Constants.AllEffects[BuffID.WeaponImbuePoison], 30, "PermanentFlaskofPoison"),
                new NewBuffItem(ItemID.FlaskofVenom, Constants.AllEffects[BuffID.WeaponImbueVenom], 30, "PermanentFlaskofVenom"),
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentAquatic =
            [
                Constants.AllEffects[BuffID.Flipper],
                Constants.AllEffects[BuffID.Gills],
                Constants.AllEffects[BuffID.WaterWalking]
            ];

            List<int> PermanentAquaticItems = 
                [Common.GetModItem(QoLCompendium.Instance, "PermanentFlipper"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentGills"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentWaterWalking")];

            List<BuffEffect> PermanentConstruction =
            [
                Constants.AllEffects[BuffID.Builder],
                Constants.AllEffects[BuffID.Calm],
                Constants.AllEffects[BuffID.Mining]
            ];

            List<int> PermanentConstructionItems = 
                [Common.GetModItem(QoLCompendium.Instance, "PermanentBuilder"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentCalm"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentMining")];

            List<BuffEffect> PermanentDamage =
            [
                Constants.AllEffects[BuffID.AmmoReservation],
                Constants.AllEffects[BuffID.Archery],
                Constants.AllEffects[BuffID.Battle],
                Constants.AllEffects[BuffID.Lucky],
                Constants.AllEffects[BuffID.MagicPower],
                Constants.AllEffects[BuffID.ManaRegeneration],
                Constants.AllEffects[BuffID.Summoning],
                Constants.AllEffects[BuffID.Tipsy],
                Constants.AllEffects[BuffID.Titan],
                Constants.AllEffects[BuffID.Rage],
                Constants.AllEffects[BuffID.Wrath]
            ];

            List<int> PermanentDamageItems =
                [Common.GetModItem(QoLCompendium.Instance, "PermanentAmmoReservation"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentArchery"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentBattle"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentLucky"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentMagicPower"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentManaRegeneration"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSummoning"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentTipsy"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentTitan"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentRage"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentWrath")];

            List <BuffEffect> PermanentDefense =
            [
                Constants.AllEffects[BuffID.Endurance],
                Constants.AllEffects[BuffID.WellFed3],
                Constants.AllEffects[BuffID.Heartreach],
                Constants.AllEffects[BuffID.Inferno],
                Constants.AllEffects[BuffID.Ironskin],
                Constants.AllEffects[BuffID.Lifeforce],
                Constants.AllEffects[BuffID.ObsidianSkin],
                Constants.AllEffects[BuffID.WellFed2],
                Constants.AllEffects[BuffID.Regeneration],
                Constants.AllEffects[BuffID.Thorns],
                Constants.AllEffects[BuffID.Warmth],
                Constants.AllEffects[BuffID.WellFed]
            ];

            List<int> PermanentDefenseItems = 
                [Common.GetModItem(QoLCompendium.Instance, "PermanentEndurance"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentExquisitelyStuffed"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentHeartreach"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentInferno"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentIronskin"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentLifeforce"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentObsidianSkin"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentPlentySatisfied"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentRegeneration"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentThorns"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentWarmth"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentWellFed")];

            List<BuffEffect> PermanentMovement =
            [
                Constants.AllEffects[BuffID.Featherfall],
                Constants.AllEffects[BuffID.Gravitation],
                Constants.AllEffects[BuffID.Swiftness]
            ];

            List<int> PermanentMovementItems =
                [Common.GetModItem(QoLCompendium.Instance, "PermanentFeatherfall"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentGravitation"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSwiftness")];

            List<BuffEffect> PermanentTrawler =
            [
                Constants.AllEffects[BuffID.Crate],
                Constants.AllEffects[BuffID.Fishing],
                Constants.AllEffects[BuffID.Sonar]
            ];

            List<int> PermanentTrawlerItems = 
                [Common.GetModItem(QoLCompendium.Instance, "PermanentCrate"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFishing"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSonar")];

            List<BuffEffect> PermanentVision =
            [
                Constants.AllEffects[BuffID.BiomeSight],
                Constants.AllEffects[BuffID.Dangersense],
                Constants.AllEffects[BuffID.Hunter],
                Constants.AllEffects[BuffID.Invisibility],
                Constants.AllEffects[BuffID.NightOwl],
                Constants.AllEffects[BuffID.Shine],
                Constants.AllEffects[BuffID.Spelunker]
            ];

            List<int> PermanentVisionItems =
                [Common.GetModItem(QoLCompendium.Instance, "PermanentBiomeSight"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentDangersense"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentHunter"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentInvisibility"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentNightOwl"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentShine"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSpelunker")];
            
            List<BuffEffect> PermanentArena =
            [
                Constants.AllEffects[BuffID.CatBast],
                Constants.AllEffects[BuffID.Campfire],
                Constants.AllEffects[BuffID.HeartLamp],
                Constants.AllEffects[BuffID.Honey],
                Constants.AllEffects[BuffID.PeaceCandle],
                Constants.AllEffects[BuffID.ShadowCandle],
                Constants.AllEffects[BuffID.StarInBottle],
                Constants.AllEffects[BuffID.Sunflower],
                Constants.AllEffects[BuffID.WaterCandle]
            ];

            List<int> PermanentArenaItems =
                [Common.GetModItem(QoLCompendium.Instance, "PermanentBastStatue"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentCampfire"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentHeartLantern"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentHoney"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentPeaceCandle"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentShadowCandle"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentStarInABottle"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSunflower"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentWaterCandle")];

            List<BuffEffect> PermanentStation =
            [
                Constants.AllEffects[BuffID.AmmoBox],
                Constants.AllEffects[BuffID.Bewitched],
                Constants.AllEffects[BuffID.Clairvoyance],
                Constants.AllEffects[BuffID.Sharpened],
                Constants.AllEffects[BuffID.SugarRush],
                Constants.AllEffects[BuffID.WarTable]
            ];

            List<int> PermanentStationItems = 
                [Common.GetModItem(QoLCompendium.Instance, "PermanentAmmoBox"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentBewitchingTable"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentCrystalBall"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSharpeningStation"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentSliceOfCake"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentWarTable")];

            List<BuffEffect> PermanentFlasks =
            [
                Constants.AllEffects[BuffID.WeaponImbueConfetti],
                Constants.AllEffects[BuffID.WeaponImbueCursedFlames],
                Constants.AllEffects[BuffID.WeaponImbueFire],
                Constants.AllEffects[BuffID.WeaponImbueGold],
                Constants.AllEffects[BuffID.WeaponImbueIchor],
                Constants.AllEffects[BuffID.WeaponImbueNanites],
                Constants.AllEffects[BuffID.WeaponImbuePoison],
                Constants.AllEffects[BuffID.WeaponImbueVenom]
            ];

            List<int> PermanentFlasksItems = 
                [Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofParty"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofCursedFlames"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofFire"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofGold"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofIchor"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofNanites"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofPoison"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofVenom")];

            List<BuffEffect> PermanentVanilla = [];
            PermanentVanilla.AddRange(PermanentAquatic);
            PermanentVanilla.AddRange(PermanentConstruction);
            PermanentVanilla.AddRange(PermanentDamage);
            PermanentVanilla.AddRange(PermanentDefense);
            PermanentVanilla.AddRange(PermanentMovement);
            PermanentVanilla.AddRange(PermanentTrawler);
            PermanentVanilla.AddRange(PermanentVision);
            PermanentVanilla.AddRange(PermanentArena);
            PermanentVanilla.AddRange(PermanentStation);
            PermanentVanilla.AddRange(PermanentFlasks);

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem("PermanentAquatic", PermanentAquatic, PermanentAquaticItems),
                new NewCombinedBuffItem("PermanentConstruction", PermanentConstruction, PermanentConstructionItems),
                new NewCombinedBuffItem("PermanentDamage", PermanentDamage, PermanentDamageItems),
                new NewCombinedBuffItem("PermanentDefense", PermanentDefense, PermanentDefenseItems),
                new NewCombinedBuffItem("PermanentMovement", PermanentMovement, PermanentMovementItems),
                new NewCombinedBuffItem("PermanentTrawler", PermanentTrawler, PermanentTrawlerItems),
                new NewCombinedBuffItem("PermanentVision", PermanentVision, PermanentVisionItems),
                new NewCombinedBuffItem("PermanentArena", PermanentArena, PermanentArenaItems),
                new NewCombinedBuffItem("PermanentStation", PermanentStation, PermanentStationItems),
                new NewCombinedBuffItem("PermanentFlasks", PermanentFlasks, PermanentFlasksItems)
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);

            List<int> PermanentVanillaItems = 
                [Common.GetModItem(QoLCompendium.Instance, "PermanentAquatic"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentConstruction"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentDamage"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentDefense"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentMovement"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentTrawler"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentVision"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentArena"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentStation"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlasks")];

            NewCombinedBuffItem permanentVanilla = new("PermanentVanilla", PermanentVanilla, PermanentVanillaItems);
            CombinedBuffItem newPermanentVanilla = new(permanentVanilla.itemName, permanentVanilla.textureName, permanentVanilla.effects, permanentVanilla.ingredients);
            QoLCompendium.Instance.AddContent(newPermanentVanilla);
            Constants.AllCombinedBuffItems.Add(newPermanentVanilla.Type);
        }
    }
}
