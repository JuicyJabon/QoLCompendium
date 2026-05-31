using QoLCompendium.Content.Items.Placeables.Pylons;
using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Content.Tiles.CraftingStations;

namespace QoLCompendium.Core.Changes.RecipeChanges
{
    public class RecipeAdditions : ModSystem
    {
        public override void AddRecipes()
        {
            //Aether Altar Recipe Creation
            if (!QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations)
            {
                for (int i = 0; i < ItemLoader.ItemCount; i++)
                {
                    if (ItemID.Sets.ShimmerTransformToItem[i] > ItemID.None)
                    {
                        Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, ItemID.Sets.ShimmerTransformToItem[i], 1, "Mods.QoLCompendium.ItemToggledConditions.CraftingStations");
                        r.AddIngredient(i);
                        r.AddTile(ModContent.TileType<AetherAltarTile>());
                        r.Register();
                    }
                }
            }

            //Permanent Buffs
            if (!QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.PermanentBuffs)
                CombinedBuffItemRecipes();

            if (QoLCompendium.mainConfig.FullyDisableRecipes)
                return;

            //Major Recipe Creation
            ConversionRecipes();
            CrateRecipes();
            BagRecipes();
            BannerRecipes();
            GrabBagRecipes();
            OtherRecipes();
            NewRecipes();
        }

        public static void CombinedBuffItemRecipes()
        {
            #region Vanilla
            //AQUATIC
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentFlipper"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentGills"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentWaterWalking")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentAquatic"));

            //CONSTRUCTION
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentBuilder"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentCalm"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentMining")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentConstruction"));

            //DAMAGE
            RecipeUtils.CombinedPermanentBuffRecipe(
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
                Common.GetModItem(QoLCompendium.Instance, "PermanentWrath")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentDamage"));

            //DEFENSE
            RecipeUtils.CombinedPermanentBuffRecipe(
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
                Common.GetModItem(QoLCompendium.Instance, "PermanentWellFed")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentDefense"));

            //MOVEMENT
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentFeatherfall"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentGravitation"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentSwiftness")],
                Common.GetModItem(QoLCompendium.Instance, "PermanentMovement"));

            //TRAWLER
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentCrate"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFishing"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentSonar")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentTrawler"));

            //VISION
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentBiomeSight"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentDangersense"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentHunter"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentInvisibility"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentNightOwl"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentShine"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentSpelunker")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentVision"));

            //ARENA
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentBastStatue"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentCampfire"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentHeartLantern"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentHoney"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentPeaceCandle"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentShadowCandle"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentStarInABottle"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentSunflower"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentWaterCandle")],
                Common.GetModItem(QoLCompendium.Instance, "PermanentArena"));

            //STATION
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentAmmoBox"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentBewitchingTable"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentCrystalBall"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentSharpeningStation"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentSliceOfCake"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentWarTable")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentStation"));

            //FLASKS
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofParty"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofCursedFlames"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofFire"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofGold"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofIchor"),
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofNanites"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofPoison"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskofVenom")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlasks"));

            //ALL
            RecipeUtils.CombinedPermanentBuffRecipe(
                [Common.GetModItem(QoLCompendium.Instance, "PermanentAquatic"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentConstruction"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentDamage"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentDefense"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentMovement"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentTrawler"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentVision"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentArena"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentStation"), 
                Common.GetModItem(QoLCompendium.Instance, "PermanentFlasks")], 
                Common.GetModItem(QoLCompendium.Instance, "PermanentVanilla"));
            #endregion

            #region Calamity
            if (CrossModSupport.Calamity.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
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
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWhiteWine")], 
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityAlcohols"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAnechoicCoating"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentOmniscience"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSulphurskin")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityAbyss"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAstralInjection"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadow")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDamage"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBaguette"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBloodfin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentPhotosynthesis")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDefense"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentZen"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentZerg"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCeaselessHunger")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityFarming"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBounding"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalcium"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGravityNormalizer"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoaring")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityMovement"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCorruptionEffigy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCrimsonEffigy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEffigyOfDecay"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentChaosCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTranquilityCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentResilientCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpitefulCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVigorousCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWeightlessCandle")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityArena"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfBrimstone"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfCrumbling"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfHolyFlames")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityFlasks"));

                //Entropy
                /*
                if (CrossModSupport.CalamityEntropy.Loaded)
                {
                    RecipeUtils.CombinedPermanentBuffRecipe([
                        Common.GetModItem(QoLCompendium.Instance, "PermanentSoyMilk"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentYharimsStimulants"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentVoidCandle")],
                        Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityEntropy"));
                }
                */

                //Rekindled
                /*
                if (CrossModSupport.CalamityRekindled.Loaded)
                {
                    RecipeUtils.CombinedPermanentBuffRecipe([
                        Common.GetModItem(QoLCompendium.Instance, "PermanentBeetleJuice"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentCadence"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentDraconicElixir"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentPenumbra"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentProfanedRage"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentProfanedWrath"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentRevivify"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentShattering"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentCRTitanScale"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentTriumph"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentCRYharimsStimulants")],
                        Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityRekindled"));
                }
                */

                //Clamity
                /*
                if (CrossModSupport.Clamity.Loaded)
                {
                    RecipeUtils.CombinedPermanentBuffRecipe([
                        Common.GetModItem(QoLCompendium.Instance, "PermanentSupremeLuck"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentTitanScale"),
                        Common.GetModItem(QoLCompendium.Instance, "PermanentExoBaguette")],
                        Common.GetModItem(QoLCompendium.Instance, "PermanentClamity"));
                }
                */

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityAlcohols"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityAbyss"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityFarming"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityArena"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityFlasks")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCalamity"));
            }
            #endregion

            #region Clicker Class
            if (CrossModSupport.ClickerClass.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentInfluence"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDesktopComputer")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentClickerClass"));
            }
            #endregion

            #region Homeward Journey
            if (CrossModSupport.HomewardJourney.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFluorescentBerry"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentReanimation"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentYin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentYang")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyFarming"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlight"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHJHaste")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyMovement"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBushOfLife"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLifeLantern")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyArena"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfDivineFire"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfForceBreak"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfPlague"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfSteel")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyFlasks"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
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
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSignal")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyStrangePotions"));

                //Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyStrangePotions")
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyFarming"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyArena"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourneyFlasks")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourney"));
            }
            #endregion

            #region Martin's Order
            if (CrossModSupport.MartinsOrder.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDefender"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEmpowerment"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEvocation"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHaste"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentPainter"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShooter"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpellCaster"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentStarreach"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSweeper"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThrower"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWhipper")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderDamage"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBlackHole"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBody"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCharging"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGourmetFlavor"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHealing"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRockskin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShielding"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoul")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderDefense"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentArcheology"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSporeFarm")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderStations"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderStations")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrder"));
            }
            #endregion

            #region Redemption
            if (CrossModSupport.Redemption.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCharisma"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEvilJelly"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHydricAcid"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSkirmish"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVendetta"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVigourous"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoonflareCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoulCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEnergyStation"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfBile"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfNitroglycerine")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRedemption"));
            }
            #endregion

            #region Secrets of the Shadows
            if (CrossModSupport.SecretsOfTheShadows.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAssassination"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBluefire"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBrittle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDoubleVision"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHarmony"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNightmare"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRipple"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRoughskin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoulAccess"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVibe"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVigor"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDigitalDisplay"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentElectromagneticDeterrent")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSecretsOfTheShadows"));
            }
            #endregion

            #region Shadows of Abaddon
            if (CrossModSupport.ShadowsOfAbaddon.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCommanding"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDawn"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDusk"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFrenziedAnimosity"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentH"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMilk"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoonlight"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNightmareFuel")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonDamage"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDraconiumSkin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEssenceOfFury"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlareElixir"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNumberOne"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSuppression"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLifeFruitLantern")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonDefense"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNinjaFocus"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRobustMuscle")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonRevenant"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHeavyFall"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSeriousSyrusianSyrup"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTowerSurmount"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWindResistance")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonMovement"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlariumFlurry"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHolyLight"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSerene"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShoalFishing")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonFarming"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonRevenant"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddonFarming")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddon"));
            }
            #endregion

            #region Spirit Classic
            if (CrossModSupport.SpiritClassic.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRunescribe"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoulguard"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpirit"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentStarburn"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentToxin")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicDamage"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMirrorCoat"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoonJelly"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentOliveBranch"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSporecoid"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSteadfast")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicDefense"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentJump"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritSoaring"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentZephyr")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicMovement"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCandy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentChocolateBar"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHealthCandy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLollipop"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentManaCandy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTaffy")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicCandies"));
                
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCoiledEnergizer"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentKoiTotem"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSunPot"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCouchPotato")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicArena"));

                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicCandies"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicArena")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassic"));
            }
            #endregion

            #region Spirit Reforged
            if (CrossModSupport.SpiritReforged.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentQuenched"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRemedy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSRSoaring"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSRZephyr"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSRKoiTotem"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfFrost")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritReforged"));
            }
            #endregion

            #region Split
            if (CrossModSupport.Split.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe(
                    [Common.GetModItem(QoLCompendium.Instance, "PermanentAnxiety"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAttraction"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDiligence"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGelidMana"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentPurity"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentKeystone"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWarningSign")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSplit"));
            }
            #endregion

            #region Thorium
            if (CrossModSupport.Thorium.Loaded)
            {
                //BARD
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentCreativity"), Common.GetModItem(QoLCompendium.Instance, "PermanentEarworm"), Common.GetModItem(QoLCompendium.Instance, "PermanentInspirationalReach")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumBard"));

                //HEALER
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentArcane"), Common.GetModItem(QoLCompendium.Instance, "PermanentGlowing"), Common.GetModItem(QoLCompendium.Instance, "PermanentHoly")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumHealer"));

                //THROWER
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentAssassin"), Common.GetModItem(QoLCompendium.Instance, "PermanentHydration")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumThrower"));

                //DAMAGE
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentArtillery"), Common.GetModItem(QoLCompendium.Instance, "PermanentBouncingFlames"), Common.GetModItem(QoLCompendium.Instance, "PermanentCactusFruit"), Common.GetModItem(QoLCompendium.Instance, "PermanentConflagration"), Common.GetModItem(QoLCompendium.Instance, "PermanentFrenzy"), Common.GetModItem(QoLCompendium.Instance, "PermanentWarmonger")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumDamage"));

                //MOVEMENT
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentAquaAffinity"), Common.GetModItem(QoLCompendium.Instance, "PermanentBloodRush"), Common.GetModItem(QoLCompendium.Instance, "PermanentKinetic")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumMovement"));

                //REPELLANT
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentBatRepellent"), Common.GetModItem(QoLCompendium.Instance, "PermanentFishRepellent"), Common.GetModItem(QoLCompendium.Instance, "PermanentInsectRepellent"), Common.GetModItem(QoLCompendium.Instance, "PermanentSkeletonRepellent"), Common.GetModItem(QoLCompendium.Instance, "PermanentZombieRepellent")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumRepellent"));

                //STATIONS
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentMistletoe"), Common.GetModItem(QoLCompendium.Instance, "PermanentAltar"), Common.GetModItem(QoLCompendium.Instance, "PermanentConductorsStand"), Common.GetModItem(QoLCompendium.Instance, "PermanentNinjaRack")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumStations"));

                //COATINGS
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentDeepFreezeCoating"), Common.GetModItem(QoLCompendium.Instance, "PermanentExplosiveCoating"), Common.GetModItem(QoLCompendium.Instance, "PermanentGorgonCoating"), Common.GetModItem(QoLCompendium.Instance, "PermanentSporeCoating"), Common.GetModItem(QoLCompendium.Instance, "PermanentToxicCoating")], Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumCoatings"));

                //ALL
                RecipeUtils.CombinedPermanentBuffRecipe([Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumBard"), Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumHealer"), Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumThrower"), Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumDamage"), Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumMovement"), Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumRepellent"), Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumStations"), Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumCoatings")], Common.GetModItem(QoLCompendium.Instance, "PermanentThorium"));
            }
            #endregion

            #region Vitality
            if (CrossModSupport.Vitality.Loaded)
            {
                RecipeUtils.CombinedPermanentBuffRecipe([
                    Common.GetModItem(QoLCompendium.Instance, "PermanentArmorPiercing"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCranberrySoda"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLeaping"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTranquility"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTravelsense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWarrior")],
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVitality"));
            }
            #endregion

            #region Everything
            Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Common.GetModItem(QoLCompendium.Instance, "PermanentEverything"), 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentVanilla"));
            if (CrossModSupport.Calamity.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamity"));
            if (CrossModSupport.ClickerClass.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentClickerClass"));
            if (CrossModSupport.HomewardJourney.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentHomewardJourney"));
            if (CrossModSupport.MartinsOrder.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrder"));
            if (CrossModSupport.Redemption.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentRedemption"));
            if (CrossModSupport.SecretsOfTheShadows.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentSecretsOfTheShadows"));
            if (CrossModSupport.ShadowsOfAbaddon.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentShadowsOfAbaddon"));
            if (CrossModSupport.SpiritClassic.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassic"));
            if (CrossModSupport.SpiritReforged.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritReforged"));
            if (CrossModSupport.Split.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentSplit"));
            if (CrossModSupport.Thorium.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentThorium"));
            if (CrossModSupport.Vitality.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentVitality"));
            if (CrossModSupport.Consolaria.Loaded)
                r.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentWiesnbrau"));
            r.AddTile(TileID.CookingPots);
            r.Register();
            #endregion
        }

        public static void ConversionRecipes()
        {
            //Conversion Recipe Creation
            //Ores
            RecipeUtils.ConversionRecipe(ItemID.CopperOre, ItemID.TinOre, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.IronOre, ItemID.LeadOre, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.SilverOre, ItemID.TungstenOre, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.GoldOre, ItemID.PlatinumOre, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.DemoniteOre, ItemID.CrimtaneOre, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CobaltOre, ItemID.PalladiumOre, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.MythrilOre, ItemID.OrichalcumOre, TileID.MythrilAnvil);
            RecipeUtils.ConversionRecipe(ItemID.AdamantiteOre, ItemID.TitaniumOre, TileID.MythrilAnvil);
            //Bars
            RecipeUtils.ConversionRecipe(ItemID.CopperBar, ItemID.TinBar, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.IronBar, ItemID.LeadBar, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.SilverBar, ItemID.TungstenBar, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.GoldBar, ItemID.PlatinumBar, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.DemoniteBar, ItemID.CrimtaneBar, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CobaltBar, ItemID.PalladiumBar, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.MythrilBar, ItemID.OrichalcumBar, TileID.MythrilAnvil);
            RecipeUtils.ConversionRecipe(ItemID.AdamantiteBar, ItemID.TitaniumBar, TileID.MythrilAnvil);
            //Materials
            RecipeUtils.ConversionRecipe(ItemID.RottenChunk, ItemID.Vertebrae, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.ShadowScale, ItemID.TissueSample, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CursedFlame, ItemID.Ichor, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.SoulofNight, ItemID.SoulofLight, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.VileMushroom, ItemID.ViciousMushroom, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.Ebonkoi, ItemID.Hemopiranha, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.Ebonkoi, ItemID.CrimsonTigerfish, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.DarkShard, ItemID.LightShard, TileID.Anvils);
            RecipeUtils.CreateSimpleRecipe(ItemID.SoulofFright, ItemID.SoulofMight, TileID.MythrilAnvil, 1, 1, false, false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions), Condition.DownedMechBossAll);
            RecipeUtils.CreateSimpleRecipe(ItemID.SoulofMight, ItemID.SoulofSight, TileID.MythrilAnvil, 1, 1, false, false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions), Condition.DownedMechBossAll);
            RecipeUtils.CreateSimpleRecipe(ItemID.SoulofSight, ItemID.SoulofFright, TileID.MythrilAnvil, 1, 1, false, false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions), Condition.DownedMechBossAll);
            //Blocks
            RecipeUtils.ConversionRecipe(ItemID.Ebonwood, ItemID.Shadewood, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.EbonstoneBlock, ItemID.CrimstoneBlock, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.EbonsandBlock, ItemID.CrimsandBlock, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CorruptSandstone, ItemID.CrimsonSandstone, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CorruptHardenedSand, ItemID.CrimsonHardenedSand, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.PurpleIceBlock, ItemID.RedIceBlock, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CorruptSeeds, ItemID.CrimsonSeeds, TileID.Anvils);
            //Tiles
            RecipeUtils.ConversionRecipe(ItemID.CorruptFishingCrate, ItemID.CrimsonFishingCrate, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrateHard, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.EaterofWorldsTrophy, ItemID.BrainofCthulhuTrophy, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.EaterofWorldsMasterTrophy, ItemID.BrainofCthulhuMasterTrophy, TileID.Anvils);
            //Weapons
            RecipeUtils.ConversionRecipe(ItemID.Terragrim, ItemID.Arkhalis, TileID.CrystalBall);
            RecipeUtils.ConversionRecipe(ItemID.DartRifle, ItemID.DartPistol, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.ClingerStaff, ItemID.SoulDrain, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.ChainGuillotines, ItemID.FetidBaghnakhs, TileID.Anvils);
            //Equipables
            RecipeUtils.ConversionRecipe(ItemID.PutridScent, ItemID.FleshKnuckles, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.WormScarf, ItemID.BrainOfConfusion, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.WormHook, ItemID.TendonHook, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.EatersBone, ItemID.BoneRattle, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.EaterOfWorldsPetItem, ItemID.BrainOfCthulhuPetItem, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.EaterMask, ItemID.BrainMask, TileID.Anvils);
            //Misc
            RecipeUtils.ConversionRecipe(ItemID.EaterOfWorldsBossBag, ItemID.BrainOfCthulhuBossBag, TileID.Anvils);
            RecipeUtils.ConversionRecipe(ItemID.CorruptionKey, ItemID.CrimsonKey, TileID.MythrilAnvil);

            #region Calamity
            if (CrossModSupport.Calamity.Loaded)
            {
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "FilthyGlove"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BloodstainedGlove"), TileID.DemonAltar);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "RottenBrain"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BloodyWormTooth"), TileID.DemonAltar);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "RottingEyeball"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BloodyVein"), TileID.DemonAltar);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "CorruptionEffigy"), Common.GetModItem(CrossModSupport.Calamity.Mod, "CrimsonEffigy"), TileID.DemonAltar);
            }
            #endregion

            #region Confection
            if (CrossModSupport.ConfectionRebaked.Loaded)
            {
                //RecipeUtils.Common.ConversionRecipe(RecipeUtils.Common.GetModItem(CrossModSupport.ConfectionRebaked.Mod, ""), RecipeUtils.Common.GetModItem(CrossModSupport.ConfectionRebaked.Mod, ""), TileID.Anvils);
            }
            #endregion

            #region Depths
            if (CrossModSupport.Depths.Loaded)
            {
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ShadowShrub"), ItemID.Fireblossom, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ShadowShrubSeeds"), ItemID.FireblossomSeeds, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ShadowShrubPlanterBox"), ItemID.FireBlossomPlanterBox, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "Quartz"), ItemID.Obsidian, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ArqueriteOre"), ItemID.Hellstone, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "QuartzCrate"), ItemID.LavaCrate, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ArqueriteCrate"), ItemID.LavaCrateHard, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ShadowFightingFish"), ItemID.FlarefinKoi, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "QuartzFeeder"), ItemID.Obsidifish, TileID.Anvils);

                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "LodeStone"), ItemID.TreasureMagnet, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "StoneRose"), ItemID.ObsidianRose, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "AmalgamAmulet"), ItemID.LavaCharm, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "CrystalSkull"), ItemID.ObsidianSkull, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "QuicksilverproofFishingHook"), ItemID.LavaFishingHook, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "QuicksilverproofTackleBag"), ItemID.LavaproofTackleBag, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "PalladiumShield"), ItemID.CobaltShield, TileID.Anvils);

                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "CrystalCrown"), Common.GetModItem(CrossModSupport.Depths.Mod, "CharredCrown"), TileID.Anvils);

                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "WhiteLightning"), ItemID.Flamelash, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "Skyfall"), ItemID.Cascade, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "BlueSphere"), ItemID.HelFire, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "SilverStar"), ItemID.Sunfury, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "NightFury"), ItemID.HellwingBow, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ShadowSphere"), ItemID.DemonScythe, TileID.Anvils);
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "Steelocanth"), ItemID.ObsidianSwordfish, TileID.Anvils);

                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.Depths.Mod, "ChasmeBag"), ItemID.WallOfFleshBossBag, TileID.Anvils);
            }
            #endregion

            #region Martin's Order
            if (CrossModSupport.MartinsOrder.Loaded)
            {
                RecipeUtils.ConversionRecipe(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "CorruptedHerb"), Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "CrimsonHerb"), TileID.Anvils);
                RecipeUtils.ConversionRecipe(ItemID.WormTooth, Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "BloodVein"), TileID.Anvils);
            }
            #endregion
        }

        public static void BagRecipes()
        {
            //Bag Recipe Creation
            RecipeUtils.CreateBagRecipe(Constants.kingSlimeDrops, ItemID.KingSlimeBossBag);
            RecipeUtils.CreateBagRecipe(Constants.eyeOfCthulhuDrops, ItemID.EyeOfCthulhuBossBag);
            RecipeUtils.CreateBagRecipe(Constants.eaterOfWorldsDrops, ItemID.EaterOfWorldsBossBag);
            RecipeUtils.CreateBagRecipe(Constants.brainOfCthulhuDrops, ItemID.BrainOfCthulhuBossBag);
            RecipeUtils.CreateBagRecipe(Constants.queenBeeDrops, ItemID.QueenBeeBossBag);
            RecipeUtils.CreateBagRecipe(Constants.deerclopsDrops, ItemID.DeerclopsBossBag);
            RecipeUtils.CreateBagRecipe(Constants.skeletronDrops, ItemID.SkeletronBossBag);
            RecipeUtils.CreateBagRecipe(Constants.wallOfFleshDrops, ItemID.WallOfFleshBossBag);
            RecipeUtils.CreateBagRecipe(Constants.queenSlimeDrops, ItemID.QueenSlimeBossBag);
            RecipeUtils.CreateBagRecipe(Constants.planteraDrops, ItemID.PlanteraBossBag);
            RecipeUtils.CreateBagRecipe(Constants.golemDrops, ItemID.GolemBossBag);
            RecipeUtils.CreateBagRecipe(Constants.betsyDrops, ItemID.BossBagBetsy);
            RecipeUtils.CreateBagRecipe(Constants.dukeFishronDrops, ItemID.FishronBossBag);
            RecipeUtils.CreateBagRecipe(Constants.empressOfLightDrops, ItemID.FairyQueenBossBag);
            RecipeUtils.CreateBagRecipe(Constants.moonLordDrops, ItemID.MoonLordBossBag);
        }

        public static void CrateRecipes()
        {
            //Crate Recipe Creation
            #region Vanilla
            //Wooden Crate
            RecipeUtils.CreateCrateRecipe(ItemID.SailfishBoots, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.TsunamiInABottle, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Aglet, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.PortableStool, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.ClimbingClaws, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.CordageGuide, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Radar, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateHardmodeRecipe(ItemID.Anchor, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Extractinator, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LivingLoom, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            //Wooden Chest Loot
            RecipeUtils.CreateCrateRecipe(ItemID.Spear, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Blowpipe, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.WoodenBoomerang, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Umbrella, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.WandofSparking, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1, Condition.NotRemixWorld, Condition.NotZenithWorld);
            RecipeUtils.CreateCrateRecipe(ItemID.LivingWoodWand, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LeafWand, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.BabyBirdStaff, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SunflowerMinecart, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LadybugMinecart, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);

            //Iron Crate
            RecipeUtils.CreateCrateRecipe(ItemID.FalconBlade, ItemID.IronCrate, ItemID.IronCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.TartarSauce, ItemID.IronCrate, ItemID.IronCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.GingerBeard, ItemID.IronCrate, ItemID.IronCrateHard, 1);

            //Golden Crate
            RecipeUtils.CreateCrateRecipe(ItemID.HardySaddle, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.EnchantedSword, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateHardmodeRecipe(ItemID.Sundial, ItemID.GoldenCrateHard, 1);
            //Golden Chest Loot
            RecipeUtils.CreateCrateRecipe(ItemID.BandofRegeneration, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.MagicMirror, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.CloudinaBottle, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.HermesBoots, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Mace, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.ShoeSpikes, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.FlareGun, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);

            //Jungle Crate
            RecipeUtils.CreateCrateRecipe(ItemID.FlowerBoots, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.AnkletoftheWind, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Boomstick, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.FeralClaws, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.StaffofRegrowth, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.FiberglassFishingPole, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Seaweed, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.HoneyDispenser, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            //Ivy Chest Loot
            RecipeUtils.CreateCrateRecipe(ItemID.LivingMahoganyWand, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LivingMahoganyLeafWand, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.BeeMinecart, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);

            //Sky Crate
            RecipeUtils.CreateCrateRecipe(ItemID.Starfury, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LuckyHorseshoe, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.ShinyRedBalloon, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.CelestialMagnet, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.CreativeWings, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SkyMill, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);

            //Frozen Crate
            RecipeUtils.CreateCrateRecipe(ItemID.IceBoomerang, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.IceBlade, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.IceSkates, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SnowballCannon, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1, Condition.NotRemixWorld, Condition.NotZenithWorld);
            RecipeUtils.CreateCrateRecipe(ItemID.BlizzardinaBottle, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.FlurryBoots, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.IceMachine, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);

            //Oasis Crate
            RecipeUtils.CreateCrateRecipe(ItemID.AncientChisel, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.ScarabFishingRod, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SandBoots, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.ThunderSpear, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.ThunderStaff, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.MysticCoilSnake, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.MagicConch, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SandstorminaBottle, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.PharaohsMask, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.PharaohsRobe, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.CatBast, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);

            //Corrupt Crate
            RecipeUtils.CreateCrateRecipe(ItemID.BallOHurt, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.BandofStarpower, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Musket, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.ShadowOrb, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Vilethorn, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            //Other
            RecipeUtils.CreateCrateRecipe(ItemID.PurpleClubberfish, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            RecipeUtils.CreateCrateHardmodeRecipe(ItemID.Toxikarp, ItemID.CorruptFishingCrateHard, 1);

            //Crimson Crate
            RecipeUtils.CreateCrateRecipe(ItemID.TheUndertaker, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.TheRottedFork, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.CrimsonRod, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.PanicNecklace, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.CrimsonHeart, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            //Other
            RecipeUtils.CreateCrateHardmodeRecipe(ItemID.Bladetongue, ItemID.CrimsonFishingCrateHard, 1);

            //Hallow
            //Other
            RecipeUtils.CreateCrateHardmodeRecipe(ItemID.CrystalSerpent, ItemID.HallowedFishingCrateHard, 1);

            //Ocean Crate
            RecipeUtils.CreateCrateRecipe(ItemID.BreathingReed, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.FloatingTube, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Trident, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Flipper, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.WaterWalkingBoots, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SharkBait, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SandcastleBucket, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            //Other
            RecipeUtils.CreateCrateRecipe(ItemID.ReaverShark, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SawtoothShark, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.Swordfish, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);

            //Obsidian Crate
            RecipeUtils.CreateCrateRecipe(ItemID.LavaCharm, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.FlameWakerBoots, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.SuperheatedBlood, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LavaFishbowl, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LavaFishingHook, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.OrnateShadowKey, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.HellCake, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.HellMinecart, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.DemonConch, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.BottomlessLavaBucket, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateRecipe(ItemID.LavaAbsorbantSponge, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateHardmodeRecipe(ItemID.ObsidianSwordfish, ItemID.LavaCrateHard, 1);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.DarkLance, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Sunfury, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.FlowerofFire, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey, Condition.NotRemixWorld, Condition.NotZenithWorld);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Flamelash, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.HellwingBow, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.TreasureMagnet, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);

            //Dungeon Crate Normal
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey, Condition.NotRemixWorld, Condition.NotZenithWorld);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.BlueMoon, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.AlchemyTable, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            RecipeUtils.CreateCrateWithKeyRecipe(ItemID.BoneWelder, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            //Dungeon Crate Lockpick
            if (!QoLCompendium.itemConfig.DisableModdedItems)
            {
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>(), Condition.NotRemixWorld, Condition.NotZenithWorld);
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.BlueMoon, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.AlchemyTable, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
                RecipeUtils.CreateCrateWithKeyRecipe(ItemID.BoneWelder, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            }
            #endregion

            #region Modded
            /*
            #region Calamity
            if (CrossModSupport.Calamity.Loaded)
            {
                //Astral Crates
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstrophageItem"), Common.GetModItem(CrossModSupport.Calamity.Mod, "MonolithCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "PolarisParrotfish"), Common.GetModItem(CrossModSupport.Calamity.Mod, "MonolithCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "GacruxianMollusk"), Common.GetModItem(CrossModSupport.Calamity.Mod, "MonolithCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "UrsaSergeant"), Common.GetModItem(CrossModSupport.Calamity.Mod, "MonolithCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralScythe"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "TitanArm"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "StellarCannon"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralachneaStaff"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "HivePod"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "StellarKnife"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AbandonedSlimeStaff"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "GloriousEnd"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                //RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "StarbusterCore"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                //RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "HadarianWings"), Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);

                //Brimstone Crag Crates
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AshenStalactite"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SlagCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "BladecrestOathsword"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SlagCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "DragoonDrizzlefish"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SlagCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SlurperPole"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SlagCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"), 1);
                //Post-ML
                //RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "GuidelightofOblivion"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"), 1, ModConditions.DownedProvidence);
                //RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "LiliesOfFinality"), Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"), 1, ModConditions.DownedYharon);

                //Sulphurous Sea Crates
                //RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AbyssalAmulet"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AlluringBait"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "BrokenWaterFilter"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "EffigyOfDecay"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "RustyBeaconPrototype"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "RustyMedallion"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(ItemID.ReaverShark, Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(ItemID.SawtoothShark, Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(ItemID.Swordfish, Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "CausticCroakerStaff"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain1);
                //Post Slime God
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "BallOFugu"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "Archerfish"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "BlackAnurian"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "HerringStaff"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "Lionfish"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AnechoicPlating"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "DepthCharm"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "IronBoots"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "StrangeOrb"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "TorrentialTear"), Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                //Hardmode, Post Acid Rain
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "OrthoceraShell"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousGrabber"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "FlakToxicannon"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "BelchingSaxophone"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SlitheringEels"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SkyfinBombers"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SpentFuelContainer"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedCragmawMire);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "NuclearFuelRod"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedCragmawMire);
                //Post-ML
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphuricAcidCannon"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedMauler);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "GammaHeart"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedNuclearTerror);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "PhosphorescentGauntlet"), Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"), 1, ModConditions.DownedNuclearTerror);

                //Sunken Sea Crates
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "RustedJingleBell"), Common.GetModItem(CrossModSupport.Calamity.Mod, "EutrophicCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1);
                //Post Desert Scourge
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SparklingEmpress"), Common.GetModItem(CrossModSupport.Calamity.Mod, "EutrophicCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedDesertScourge);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "VoltaicJelly"), Common.GetModItem(CrossModSupport.Calamity.Mod, "EutrophicCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedDesertScourge);
                //Post Clam
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "GiantPearl"), Common.GetModItem(CrossModSupport.Calamity.Mod, "EutrophicCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedGiantClam);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "AmidiasSpark"), Common.GetModItem(CrossModSupport.Calamity.Mod, "EutrophicCrate"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedGiantClam);
                //Hardmode
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "Serpentine"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "SerpentsBite"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1);
                //Hardmode Clam
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "Poseidon"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedGiantClam);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "ClamCrusher"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedGiantClam);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "ClamorRifle"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedGiantClam);
                RecipeUtils.CreateCrateHardmodeRecipe(Common.GetModItem(CrossModSupport.Calamity.Mod, "ShellfishStaff"), Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"), 1, ModConditions.DownedGiantClam);
            }
            #endregion
            */

            #region Spirit
            if (CrossModSupport.SpiritClassic.Loaded)
            {
                //Briar Crates
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachBrooch"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachCrate"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BriarCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachBoomerang"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachCrate"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BriarCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ThornHook"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachCrate"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BriarCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachChestMagic"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachCrate"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BriarCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "LivingElderbarkWand"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachCrate"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BriarCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ThornyRod"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachCrate"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BriarCrate"), 1);
            }
            #endregion

            #region Thorium
            if (CrossModSupport.Thorium.Loaded)
            {
                //Aquatic Depths Crates
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "MagicConch"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AquaticDepthsCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "AnglerBowl"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AquaticDepthsCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "RainStone"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AquaticDepthsCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "SteelDrum"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AquaticDepthsCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "SeaTurtlesBulwark"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AquaticDepthsCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);

                //Scarlet Crates
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "MixTape"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "LootRang"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "MagmaCharm"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "SpringSteps"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "DeepStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "MagmaLocket"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "SpringHook"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(ItemID.LavaCharm, Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "MoltenScale"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScarletCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SinisterCrate"), 1);

                //Strange Crates
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "HightechSonarDevice"), Common.GetModItem(CrossModSupport.Thorium.Mod, "StrangeCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "WondrousCrate"), 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "DrownedDoubloon"), Common.GetModItem(CrossModSupport.Thorium.Mod, "StrangeCrate"), Common.GetModItem(CrossModSupport.Thorium.Mod, "WondrousCrate"), 1);

                //Vanilla Crate Drops
                RecipeUtils.CreateCrateWithKeyRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "EternalNight"), ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
                RecipeUtils.CreateCrateWithKeyRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "LightsLament"), ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
                RecipeUtils.CreateCrateWithKeyRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "Nocturne"), ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
                RecipeUtils.CreateCrateWithKeyRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "IncandescentAlacrity"), ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "FrozenTiara"), ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "ForestOcarina"), ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "TheDigester"), ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "FanLetter2"), ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "FanLetter"), ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "DarkHeart"), ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "DarkHeart"), ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "LightningClaves"), ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "BubbleMagnet"), ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "Flute"), ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "RecoveryWand"), ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "EnchantedPickaxe"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "EnchantedCane"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "EnchantedStaff"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
                RecipeUtils.CreateCrateRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "FishHat"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            }
            #endregion
            #endregion
        }

        public static void BannerRecipes()
        {
            //Banner Recipe Creation
            #region Biomes
            #region Forest
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Underground/Caverns
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.JellyfishBanner, ItemID.JellyfishNecklace, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GreenJellyfishBanner, ItemID.JellyfishNecklace, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonArcherBanner, ItemID.MagicQuiver, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.TitanGlove, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.PhilosophersStone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.CrossNecklace, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.StarCloak, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ToxicSludgeBanner, ItemID.Bezoar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.AdhesiveBandage, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ArmoredSkeletonBanner, ItemID.ArmorPolish, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.TrifoldMap, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GreenJellyfishBanner, ItemID.Megaphone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.PocketMirror, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.MotherSlimeBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BatBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.NypmhBanner, ItemID.MetalDetector, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.NightVisionHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemID.NightVisionHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorLeggings, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorBreastplate, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.AncientIronHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.AncientGoldHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RockGolemBanner, ItemID.RockGolemHead, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.RobotHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.PotatoChips, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.PotatoChips, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.PotatoChips, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.MilkCarton, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SpiderBanner, ItemID.FriedEgg, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.FriedEgg, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Pizza, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.Pizza, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemID.Spaghetti, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.Spaghetti, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.Steak, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyBatBanner, ItemID.BatBat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BatBanner, ItemID.ChainKnife, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.NotRemixWorld);
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Rally, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Rally, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Rally, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.BoneSword, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.BonePickaxe, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.FlowerofFrost, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.Frostbrand, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.IceBow, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.MagicDagger, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Gladius, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonArcherBanner, ItemID.Marrow, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ArmoredSkeletonBanner, ItemID.BeamSword, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.MedusaHead, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.ChainKnife, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode, Condition.NotRemixWorld);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.PoisonStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.DualHook, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.ToySled, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            RecipeUtils.AddBannerToItemRecipe(ItemID.WormBanner, ItemID.WhoopieCushion, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            #endregion

            #region Underworld
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.FireImpBanner, ItemID.ObsidianRose, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.HellbatBanner, ItemID.MagmaStone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.LavaBatBanner, ItemID.MagmaStone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.Hotdog, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.Hotdog, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Furniture
            //Materials
            RecipeUtils.AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.FireFeather, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.DemonBanner, ItemID.DemonScythe, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyUnderworldBanner, ItemID.Cascade, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedSkeletron);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyUnderworldBanner, ItemID.HelFire, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.UnholyTrident, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Misc Equips
            //Misc
            #endregion

            #region Sky
            //Accessories
            //Armor/Vanity
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.ChickenNugget, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            RecipeUtils.AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.GiantHarpyFeather, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Snow
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.FrozenTurtleShell, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.Compass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.VikingHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.VikingHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoCoat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoHood, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.IceSlimeBanner, ItemID.IceCream, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.IceCream, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SpikedIceSlimeBanner, ItemID.IceCream, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.Milkshake, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.Milkshake, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.Bacon, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            RecipeUtils.AddBannerToItemRecipe(ItemID.IceGolemBanner, ItemID.IceFeather, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.SnowballLauncher, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnySnowBanner, ItemID.Amarok, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.IceSickle, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.FrostStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.HamBat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            RecipeUtils.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.PigronMinecart, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.WolfBanner, ItemID.WolfMountItem, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnySnowBanner, ItemID.FrozenKey, 1, 5, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Desert
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.FastClock, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.DesertDjinnBanner, ItemID.DjinnsCurse, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.MoonMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.SunMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.AntlionBanner, ItemID.BananaSplit, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.BananaSplit, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.FlyingAntlionBanner, ItemID.BananaSplit, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.TumbleweedBanner, ItemID.Nachos, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RavagerScorpionBanner, ItemID.FriedEgg, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.Nachos, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.AntlionClaw, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            RecipeUtils.AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, ItemID.AncientHorn, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyDesertBanner, ItemID.DungeonDesertKey, 1, 5, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Ocean
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.DivingHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.JellyfishNecklace, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.ShrimpPoBoy, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrabBanner, ItemID.ShrimpPoBoy, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Jungle
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.Bezoar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.MossHornetBanner, ItemID.Bezoar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.JungleBatBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltLeggings, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltBreastplate, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.RobotHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.CoffeeCup, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SnatcherBanner, ItemID.CoffeeCup, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.CoffeeCup, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantFlyingFoxBanner, ItemID.Grapes, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DerplingBanner, ItemID.Grapes, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            RecipeUtils.AddBannerToItemRecipe(ItemID.MossHornetBanner, ItemID.TatteredBeeWing, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MothBanner, ItemID.ButterflyDust, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.Uzi, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyJungleBanner, ItemID.Yelets, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Misc Equips
            //Misc
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyJungleBanner, ItemID.JungleKey, 1, 5, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Temple
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            RecipeUtils.AddBannerToItemRecipe(ItemID.LihzahrdBanner, ItemID.LizardEgg, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            //Misc
            #endregion

            #region Glowing Mushroom
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.DepthMeter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.Shroomerang, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Corruption
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.CursedHammerBanner, ItemID.Nazar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Blindfold, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Megaphone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.CorruptSlimeBanner, ItemID.Blindfold, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.CorruptorBanner, ItemID.Vitamins, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowGreaves, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowScalemail, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CorruptBunnyBanner, ItemID.BunnyHood, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.Burger, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SandsharkCorruptBanner, ItemID.Nachos, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyCorruptionBanner, ItemID.MeatGrinder, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.TentacleSpike, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyCorruptionBanner, ItemID.CorruptionKey, 1, 5, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Crimson
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimsonAxeBanner, ItemID.Nazar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.Blindfold, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.Megaphone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimslimeBanner, ItemID.Blindfold, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.FloatyGrossBanner, ItemID.Vitamins, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimsonBunnyBanner, ItemID.BunnyHood, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.Burger, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SandsharkCrimsonBanner, ItemID.Nachos, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyCrimsonBanner, ItemID.MeatGrinder, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodCrawlerBanner, ItemID.TentacleSpike, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.TentacleSpike, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.FaceMonsterBanner, ItemID.TentacleSpike, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyCrimsonBanner, ItemID.CrimsonKey, 1, 5, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Hallow
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.EnchantedSwordBanner, ItemID.Nazar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.TrifoldMap, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.Megaphone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.FastClock, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.SandsharkHallowedBanner, ItemID.Nachos, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.ApplePie, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.IlluminantBatBanner, ItemID.ApplePie, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.IlluminantSlimeBanner, ItemID.ApplePie, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GastropodBanner, ItemID.ChocolateChipCookie, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            RecipeUtils.AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.BlessedApple, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            RecipeUtils.AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.RodofDiscord, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.UnicornonaStick, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyHallowBanner, ItemID.HallowedKey, 1, 5, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Dungeon
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.BlackBelt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.Tabi, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.RifleScope, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PaladinBanner, ItemID.PaladinsShield, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.Nazar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.Nazar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RustyArmoredBonesBanner, ItemID.AdhesiveBandage, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BlueArmoredBonesBanner, ItemID.ArmorPolish, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.TallyCounter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.TallyCounter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.TallyCounter, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.AncientNecroHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.AncientNecroHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.SWATHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.CreamSoda, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.CoffeeCup, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.CreamSoda, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.BBQRibs, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.BBQRibs, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.BBQRibs, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Furniture
            //Materials
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyArmoredBonesBanner, ItemID.BoneFeather, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Weapons
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyArmoredBonesBanner, ItemID.Keybrand, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyArmoredBonesBanner, ItemID.Kraken, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyArmoredBonesBanner, ItemID.MaceWhip, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyArmoredBonesBanner, ItemID.MagnetSphere, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.ShadowJoustingLance, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DiablolistBanner, ItemID.InfernoFork, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PaladinBanner, ItemID.PaladinsHammer, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.NecromancerBanner, ItemID.ShadowbeamStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.RaggedCasterBanner, ItemID.SpectreStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.RocketLauncher, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.SniperRifle, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.TacticalShotgun, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Misc Equips
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyArmoredBonesBanner, ItemID.WispinaBottle, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Misc
            RecipeUtils.AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.BoneWand, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            #endregion
            #endregion

            #region Events
            #region Day
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Night
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieBanner, ItemID.Shackle, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.Shackle, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.Shackle, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.MoonCharm, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.AdhesiveBandage, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.WraithBanner, ItemID.FastClock, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieBanner, ItemID.ZombieArm, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Rain
            //Accessories
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.UmbrellaSlimeBanner, ItemID.UmbrellaHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainCoat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.FlyingFishBanner, ItemID.Fries, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.AngryNimbusBanner, ItemID.NimbusRod, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            //Misc
            RecipeUtils.AddBannerToItemRecipe(ItemID.FlyingFishBanner, ItemID.CarbonGuitar, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            #endregion

            #region Wind
            //Accessories
            //Armor/Vanity
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            RecipeUtils.AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.KiteBoneSerpent, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.KiteBunny, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CorruptBunnyBanner, ItemID.KiteBunnyCorrupt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.CrimsonBunnyBanner, ItemID.KiteBunnyCrimson, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.GoldfishBanner, ItemID.KiteGoldfish, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.JellyfishBanner, ItemID.KiteJellyfishBlue, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.KiteManEater, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.KiteJellyfishPink, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.RedSlimeBanner, ItemID.KiteRed, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.KiteShark, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.SlimeBanner, ItemID.KiteBlue, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.YellowSlimeBanner, ItemID.KiteYellow, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.KiteAngryTrapper, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.KitePigron, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.KiteSandShark, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.KiteUnicorn, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.WanderingEyeBanner, ItemID.KiteWanderingEye, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.WorldFeederBanner, ItemID.KiteWorldFeeder, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.WyvernBanner, ItemID.KiteWyvern, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Blood Moon
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.SharkToothNecklace, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.SharkToothNecklace, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ClownBanner, ItemID.TrifoldMap, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.BloodRainBow, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.VampireFrogStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodRainBow, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.VampireFrogStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.KOCannon, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ClownBanner, ItemID.KOCannon, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GoblinSharkBanner, ItemID.SharpTears, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.GoblinSharkBanner, ItemID.BloodHamaxe, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodEelBanner, ItemID.DripplerFlail, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodEelBanner, ItemID.BloodHamaxe, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodNautilusBanner, ItemID.SanguineStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            //Misc
            RecipeUtils.AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.MoneyTrough, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.BloodFishingRod, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodFishingRod, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.AddBannerToItemRecipe(ItemID.BloodNautilusBanner, ItemID.BloodMoonMonolith, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Goblins
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.GoblinArcherBanner, ItemID.Harpoon, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Frost Legion
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Pirates
            //Accessories
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.DiscountCard, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.GoldRing, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.LuckyCoin, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            //Armor/Vanity
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.SailorPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.SailorShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.SailorHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.EyePatch, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.BuccaneerPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.BuccaneerShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.BuccaneerBandana, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            //Food
            //Furniture
            //Materials
            //Weapons
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.Cutlass, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerGroupToItemRecipe(Constants.AnyPirateBanner, ItemID.PirateStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemID.CoinGun, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            //Misc Equips
            //Misc
            #endregion

            #region Eclipse
            //Accessories
            RecipeUtils.AddBannerToItemRecipe(ItemID.CreatureFromTheDeepBanner, ItemID.NeptunesShell, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            RecipeUtils.AddBannerToItemRecipe(ItemID.VampireBanner, ItemID.MoonStone, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.MothronWings, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherApron, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.DrManFlyLabCoat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.DrManFlyMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Food
            RecipeUtils.AddBannerToItemRecipe(ItemID.ThePossessedBanner, ItemID.Steak, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Furniture
            //Materials
            RecipeUtils.AddBannerToItemRecipe(ItemID.VampireBanner, ItemID.BrokenBatWing, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.BrokenHeroSword, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Weapons
            RecipeUtils.AddBannerToItemRecipe(ItemID.ReaperBanner, ItemID.DeathSickle, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAll);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButchersChainsaw, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DeadlySphereBanner, ItemID.DeadlySphereStaff, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.ToxicFlask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.TheEyeOfCthulhu, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.NailheadBanner, ItemID.NailGun, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.PsychoBanner, ItemID.PsychoKnife, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Misc Equips
            RecipeUtils.AddBannerToItemRecipe(ItemID.EyezorBanner, ItemID.EyeSpring, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Misc
            #endregion

            #region Pumpkin Moon
            //Accessories
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.HeadlessHorsemanBanner, ItemID.JackOLanternMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Frost Moon
            //Accessories
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfHat, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Martian Madness
            //Accessories
            //Armor/Vanity
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumePants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumeShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumeMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumePants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumeShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumeMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumePants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumeShirt, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumeMask, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformTorso, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformTorso, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformPants, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformTorso, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformHelmet, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            RecipeUtils.AddBannerToItemRecipe(ItemID.MartianScutlixGunnerBanner, ItemID.BrainScrambler, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMartians);
            RecipeUtils.AddBannerToItemRecipe(ItemID.ScutlixBanner, ItemID.BrainScrambler, 1, 1, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMartians);
            //Misc
            #endregion

            #region Lunar Pillars
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion
            #endregion
        }

        public static void GrabBagRecipes()
        {
            //Goodie Bag Recipes
            RecipeUtils.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.UnluckyYarn, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.BatHook, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.RottenEgg, TileID.WorkBenches, 1, 50, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));

            //Present Recipes
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.SnowGlobe, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.DogWhistle, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.RedRyder, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneSword, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.CnadyCanePickaxe, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneHook, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.FruitcakeChakram, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.HandWarmer, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.Toolbox, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            RecipeUtils.CreateSimpleRecipe(ItemID.Present, ItemID.StarAnise, TileID.WorkBenches, 1, 50, disableDecraft: true, usesRecipeGroup: false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
        }

        public static void OtherRecipes()
        {
            #region Biome Keys
            #region Vanilla
            RecipeUtils.CreateSimpleRecipe(ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            RecipeUtils.CreateSimpleRecipe(ItemID.CrimsonKey, ItemID.VampireKnives, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            RecipeUtils.CreateSimpleRecipe(ItemID.DungeonDesertKey, ItemID.StormTigerStaff, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            RecipeUtils.CreateSimpleRecipe(ItemID.FrozenKey, ItemID.StaffoftheFrostHydra, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            RecipeUtils.CreateSimpleRecipe(ItemID.HallowedKey, ItemID.RainbowGun, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            RecipeUtils.CreateSimpleRecipe(ItemID.JungleKey, ItemID.PiranhaGun, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            #endregion

            #region Modded
            #region Spooky
            if (CrossModSupport.Spooky.Loaded)
            {
                RecipeUtils.CreateSimpleRecipe(Common.GetModItem(CrossModSupport.Spooky.Mod, "SpookyBiomeKey"), Common.GetModItem(CrossModSupport.Spooky.Mod, "ElGourdo"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                RecipeUtils.CreateSimpleRecipe(Common.GetModItem(CrossModSupport.Spooky.Mod, "CemeteryKey"), Common.GetModItem(CrossModSupport.Spooky.Mod, "DiscoSkull"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                RecipeUtils.CreateSimpleRecipe(Common.GetModItem(CrossModSupport.Spooky.Mod, "SpiderKey"), Common.GetModItem(CrossModSupport.Spooky.Mod, "VenomHarpoon"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                RecipeUtils.CreateSimpleRecipe(Common.GetModItem(CrossModSupport.Spooky.Mod, "SpookyHellKey"), Common.GetModItem(CrossModSupport.Spooky.Mod, "BrainJar"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            }
            #endregion

            #region Thorium
            if (CrossModSupport.Thorium.Loaded)
            {
                RecipeUtils.CreateSimpleRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "AquaticDepthsBiomeKey"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Fishbone"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                RecipeUtils.CreateSimpleRecipe(ItemID.DungeonDesertKey, Common.GetModItem(CrossModSupport.Thorium.Mod, "PharaohsSlab"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                RecipeUtils.CreateSimpleRecipe(Common.GetModItem(CrossModSupport.Thorium.Mod, "UnderworldBiomeKey"), Common.GetModItem(CrossModSupport.Thorium.Mod, "PhoenixStaff"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            }
            #endregion

            #region Vitality
            if (CrossModSupport.Vitality.Loaded)
            {
                RecipeUtils.CreateSimpleRecipe(Common.GetModItem(CrossModSupport.Vitality.Mod, "GlowingMossKey"), Common.GetModItem(CrossModSupport.Vitality.Mod, "GlowingMothShiv"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            }
            #endregion
            #endregion
            #endregion
        }

        public static void NewRecipes()
        {
            #region Prime Rework / Confection Fix
            if (CrossModSupport.ConfectionRebaked.Loaded && CrossModSupport.MechBossRework.Loaded)
            {
                Recipe deathsRaze = Recipe.Create(Common.GetModItem(CrossModSupport.ConfectionRebaked.Mod, "DeathsRaze"), 1);
                deathsRaze.AddIngredient(ItemID.BloodButcherer);
                deathsRaze.AddIngredient(ItemID.Muramasa);
                deathsRaze.AddIngredient(ItemID.BladeofGrass);
                deathsRaze.AddIngredient(ItemID.FieryGreatsword);
                deathsRaze.AddTile(TileID.DemonAltar);
                deathsRaze.Register();

                if (CrossModSupport.Depths.Loaded)
                {
                    Recipe deathsRaze2 = Recipe.Create(Common.GetModItem(CrossModSupport.ConfectionRebaked.Mod, "DeathsRaze"), 1);
                    deathsRaze2.AddIngredient(ItemID.BloodButcherer);
                    deathsRaze2.AddIngredient(ItemID.Muramasa);
                    deathsRaze2.AddIngredient(ItemID.BladeofGrass);
                    deathsRaze2.AddIngredient(Common.GetModItem(CrossModSupport.Depths.Mod, "Terminex"));
                    deathsRaze2.AddTile(TileID.DemonAltar);
                    deathsRaze2.Register();
                }
            }
            #endregion

            #region Calamity Effigy Recipes
            if (CrossModSupport.Calamity.Loaded && QoLCompendium.crossModConfig.CalamityEffigyRecipes)
            {
                Recipe crimsonEffigy = Recipe.Create(Common.GetModItem(CrossModSupport.Calamity.Mod, "CrimsonEffigy"), 1);
                crimsonEffigy.AddIngredient(ItemID.Vertebrae, 10);
                crimsonEffigy.AddIngredient(ItemID.CrimtaneBar, 6);
                crimsonEffigy.AddTile(TileID.DemonAltar);
                crimsonEffigy.Register();

                Recipe corruptionEffigy = Recipe.Create(Common.GetModItem(CrossModSupport.Calamity.Mod, "CorruptionEffigy"), 1);
                corruptionEffigy.AddIngredient(ItemID.RottenChunk, 10);
                corruptionEffigy.AddIngredient(ItemID.DemoniteBar, 6);
                corruptionEffigy.AddTile(TileID.DemonAltar);
                corruptionEffigy.Register();

                Recipe decayEffigy = Recipe.Create(Common.GetModItem(CrossModSupport.Calamity.Mod, "EffigyOfDecay"), 1);
                decayEffigy.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "Acidwood"), 10);
                decayEffigy.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphuricScale"), 6);
                decayEffigy.AddTile(TileID.DemonAltar);
                decayEffigy.Register();
            }
            #endregion

            #region Calamity Entropy Yharim's Stimulants
            if (CrossModSupport.Calamity.Loaded && CrossModSupport.CalamityEntropy.Loaded)
            {
                Recipe yharimsStimulants = Recipe.Create(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "YharimsStimulants"), 1);
                yharimsStimulants.AddRecipeGroup("QoLCompendium:WellFed");
                yharimsStimulants.AddIngredient(ItemID.EndurancePotion);
                yharimsStimulants.AddIngredient(ItemID.IronskinPotion);
                yharimsStimulants.AddIngredient(ItemID.SwiftnessPotion);
                yharimsStimulants.AddIngredient(ItemID.TitanPotion);
                yharimsStimulants.AddTile(TileID.AlchemyTable);
                yharimsStimulants.Register();

                Recipe yharimsStimulantsBO = Recipe.Create(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "YharimsStimulants"), 1);
                yharimsStimulantsBO.AddIngredient(ItemID.BottledWater);
                yharimsStimulantsBO.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "BloodOrb"), 50);
                yharimsStimulantsBO.AddTile(TileID.AlchemyTable);
                yharimsStimulantsBO.Register();
            }
            #endregion

            #region Parity
            //Mobile Storage
            if (!QoLCompendium.itemConfig.DisableModdedItems)
                RecipeUtils.CreateSimpleRecipe(ItemID.PiggyBank, ItemID.MoneyTrough, TileID.Anvils, 1, 1, false, false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.MobileStorages", () => QoLCompendium.itemConfig.MobileStorages));
            #endregion

            #region Config Specific
            //Golden Delight With Golden Carp
            RecipeUtils.CreateSimpleRecipe(ItemID.GoldenCarp, ItemID.GoldenDelight, TileID.CookingPots, 1, 1, false, false, RecipeUtils.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.RecipeEnabled", () => QoLCompendium.mainConfig.GoldenCarpDelight));

            //Easier Universal Pylon
            Recipe universalPylon = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.EasierUniversalPylon, ItemID.TeleportationPylonVictory, 1, "Mods.QoLCompendium.ItemToggledConditions.Pylons");
            universalPylon.AddIngredient(ItemID.TeleportationPylonUnderground);
            universalPylon.AddIngredient(ItemID.TeleportationPylonDesert);
            universalPylon.AddIngredient(ItemID.TeleportationPylonPurity);
            universalPylon.AddIngredient(ItemID.TeleportationPylonHallow);
            universalPylon.AddIngredient(ItemID.TeleportationPylonJungle);
            universalPylon.AddIngredient(ItemID.TeleportationPylonMushroom);
            universalPylon.AddIngredient(ItemID.TeleportationPylonOcean);
            universalPylon.AddIngredient(ItemID.TeleportationPylonSnow);
            if (!QoLCompendium.itemConfig.DisableModdedItems)
            {
                universalPylon.AddIngredient(ModContent.ItemType<AetherPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<CorruptionPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<CrimsonPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<DungeonPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<SkyPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<TemplePylon>());
                universalPylon.AddIngredient(ModContent.ItemType<HellPylon>());
            }
            universalPylon.AddTile(TileID.Anvils);
            universalPylon.Register();
            #endregion

            /*
            #region Obsidian Furniture
            Recipe obsidianWorkBench = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianWorkBench, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianWorkBench.AddIngredient(ItemID.ObsidianBrick, 10);
            obsidianWorkBench.Register();

            Recipe obsidianChandelier = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianChandelier, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianChandelier.AddIngredient(ItemID.ObsidianBrick, 4);
            obsidianChandelier.AddIngredient(ItemID.Torch, 4);
            obsidianChandelier.AddIngredient(ItemID.Chain);
            obsidianChandelier.AddTile(TileID.Anvils);
            obsidianChandelier.Register();

            Recipe obsidianClock = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianClock, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianClock.AddIngredient(ItemID.ObsidianBrick, 10);
            obsidianClock.AddIngredient(ItemID.Glass, 6);
            obsidianClock.AddRecipeGroup(RecipeGroupID.IronBar, 3);
            obsidianClock.AddTile(TileID.Sawmill);
            obsidianClock.Register();

            Recipe obsidianBathtub = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianBathtub, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianBathtub.AddIngredient(ItemID.ObsidianBrick, 14);
            obsidianBathtub.AddTile(TileID.Sawmill);
            obsidianBathtub.Register();

            Recipe obsidianBed = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianBed, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianBed.AddIngredient(ItemID.ObsidianBrick, 15);
            obsidianBed.AddIngredient(ItemID.Silk, 5);
            obsidianBed.AddTile(TileID.Sawmill);
            obsidianBed.Register();

            Recipe obsidianDresser = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianDresser, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianDresser.AddIngredient(ItemID.ObsidianBrick, 16);
            obsidianDresser.AddTile(TileID.Sawmill);
            obsidianDresser.Register();

            Recipe obsidianBookcase = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianBookcase, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianBookcase.AddIngredient(ItemID.ObsidianBrick, 20);
            obsidianBookcase.AddIngredient(ItemID.Book, 10);
            obsidianBookcase.AddTile(TileID.Sawmill);
            obsidianBookcase.Register();

            Recipe obsidianPiano = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianPiano, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianPiano.AddIngredient(ItemID.ObsidianBrick, 15);
            obsidianPiano.AddIngredient(ItemID.Bone, 4);
            obsidianPiano.AddIngredient(ItemID.Book);
            obsidianPiano.AddTile(TileID.Sawmill);
            obsidianPiano.Register();

            Recipe obsidianSofa = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianSofa, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianSofa.AddIngredient(ItemID.ObsidianBrick, 5);
            obsidianSofa.AddIngredient(ItemID.Silk, 2);
            obsidianSofa.AddTile(TileID.Sawmill);
            obsidianSofa.Register();

            Recipe obsidianDoor = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianDoor, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianDoor.AddIngredient(ItemID.ObsidianBrick, 6);
            obsidianDoor.AddTile(TileID.WorkBenches);
            obsidianDoor.Register();

            Recipe obsidianCandle = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianCandle, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianCandle.AddIngredient(ItemID.ObsidianBrick, 4);
            obsidianCandle.AddIngredient(ItemID.Torch);
            obsidianCandle.AddTile(TileID.WorkBenches);
            obsidianCandle.Register();

            Recipe obsidianChair = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianChair, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianChair.AddIngredient(ItemID.ObsidianBrick, 4);
            obsidianChair.AddTile(TileID.WorkBenches);
            obsidianChair.Register();

            Recipe obsidianLamp = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianLamp, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianLamp.AddIngredient(ItemID.ObsidianBrick, 3);
            obsidianLamp.AddIngredient(ItemID.Torch);
            obsidianLamp.AddTile(TileID.WorkBenches);
            obsidianLamp.Register();

            Recipe obsidianLantern = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianLantern, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianLantern.AddIngredient(ItemID.ObsidianBrick, 6);
            obsidianLantern.AddIngredient(ItemID.Torch);
            obsidianLantern.AddTile(TileID.WorkBenches);
            obsidianLantern.Register();

            Recipe obsidianTable = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianTable, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianTable.AddIngredient(ItemID.ObsidianBrick, 8);
            obsidianTable.AddTile(TileID.WorkBenches);
            obsidianTable.Register();

            Recipe obsidianCandelabra = RecipeUtils.GetItemRecipe(() => QoLCompendium.mainConfig.FurnitureRecipes, ItemID.ObsidianCandelabra, 1, "Mods.QoLCompendium.ItemToggledConditions.FurnitureRecipes");
            obsidianCandelabra.AddIngredient(ItemID.ObsidianBrick, 5);
            obsidianCandelabra.AddIngredient(ItemID.Torch, 3);
            obsidianCandelabra.AddTile(TileID.WorkBenches);
            obsidianCandelabra.Register();
            #endregion
            */
        }
    }
}