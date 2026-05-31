using QoLCompendium.Content.Items.Accessories.Construction;
using QoLCompendium.Content.Items.Accessories.Fishing;
using QoLCompendium.Content.Items.Accessories.Informational;
using QoLCompendium.Content.Items.Tools.Mirrors;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod.HomewardJourney;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod.SpiritClassic;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod.Thorium;
using QoLCompendium.Content.Items.Tools.Summons.Vanilla;
using QoLCompendium.Content.Items.Tools.Usables.CrossMod;
using System.Reflection;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core
{
    public static class Common
    {
        public static void UnloadTasks()
        {
            foreach (var hook in Constants.Detours)
                hook.Undo();
        }

        public static void PostSetupTasks()
        {
            HashSet<int> ModPowerUpItems =
            [
                GetModItem(CrossModSupport.Orchid.Mod, "Chip"),
                GetModItem(CrossModSupport.Orchid.Mod, "Guard"),
                GetModItem(CrossModSupport.Orchid.Mod, "Potency"),
                GetModItem(CrossModSupport.Terrorborn.Mod, "DarkEnergy"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationNote"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationNoteStatue"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationNoteNoble"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationNoteRhapsodist"),
                GetModItem(CrossModSupport.Thorium.Mod, "MeatSlab"),
                GetModItem(CrossModSupport.Thorium.Mod, "GreatFlesh"),
                GetModItem(CrossModSupport.Vitality.Mod, "BloodClot"),
                GetModItem(CrossModSupport.Vitality.Mod, "HoneydropProj2")
            ];
            ModPowerUpItems.RemoveWhere(x => x == ItemID.None);
            Constants.PowerUpItems.UnionWith(ModPowerUpItems);

            HashSet<int> ModBankItems =
            [
                ModContent.ItemType<BattalionLog>(),
                ModContent.ItemType<HarmInducer>(),
                ModContent.ItemType<HeadCounter>(),
                ModContent.ItemType<Kettlebell>(),
                ModContent.ItemType<LuckyDie>(),
                ModContent.ItemType<MetallicClover>(),
                ModContent.ItemType<PlateCracker>(),
                ModContent.ItemType<Regenerator>(),
                ModContent.ItemType<ReinforcedPanel>(),
                ModContent.ItemType<Replenisher>(),
                ModContent.ItemType<TrackingDevice>(),
                ModContent.ItemType<WingTimer>(),
                ModContent.ItemType<Fitbit>(),
                ModContent.ItemType<HeartbeatSensor>(),
                ModContent.ItemType<ToleranceDetector>(),
                ModContent.ItemType<VitalDisplay>(),
                ModContent.ItemType<IAH>(),
                ModContent.ItemType<MosaicMirror>(),
                ModContent.ItemType<SkullWatch>(),
                ModContent.ItemType<DeteriorationDisplay>(),
                ModContent.ItemType<MiningEmblem>(),
                ModContent.ItemType<ConstructionEmblem>(),
                ModContent.ItemType<CreationClubMembersPass>(),
                ModContent.ItemType<SonarDevice>(),
                ModContent.ItemType<AnglerRadar>(),
                ModContent.ItemType<DuplicationBobber>(),
                ModContent.ItemType<AnglersDream>(),
                ModContent.ItemType<SuperchargedSuperCell>(),
                GetModItem(CrossModSupport.AFKPets.Mod, "FishermansPride"),
                GetModItem(CrossModSupport.AFKPets.Mod, "LampyridaeHairpin"),
                GetModItem(CrossModSupport.AFKPets.Mod, "Piracy"),
                GetModItem(CrossModSupport.AFKPets.Mod, "PortableSonar"),
                GetModItem(CrossModSupport.AFKPets.Mod, "TheHandyman"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "AttendanceLog"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "BiomeCrystal"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "EngiRegistry"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "FortuneMirror"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "HitMarker"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "Magimeter"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "RSH"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "SafteyScanner"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "ScryingMirror"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "ThreatAnalyzer"),
                GetModItem(CrossModSupport.BlocksInfoAccessories.Mod, "WantedPoster"),
                GetModItem(CrossModSupport.Calamity.Mod, "AlluringBait"),
                GetModItem(CrossModSupport.Calamity.Mod, "EnchantedPearl"),
                GetModItem(CrossModSupport.Calamity.Mod, "SupremeBaitTackleBoxFishingStation"),
                GetModItem(CrossModSupport.Calamity.Mod, "AncientFossil"),
                GetModItem(CrossModSupport.Calamity.Mod, "ArchaicPowder"),
                GetModItem(CrossModSupport.Calamity.Mod, "OceanCrest"),
                GetModItem(CrossModSupport.Calamity.Mod, "SpelunkersAmulet"),
                GetModItem(CrossModSupport.Clamity.Mod, "TheSubcommunity"),
                GetModItem(CrossModSupport.ClickerClass.Mod, "ButtonMasher"),
                GetModItem(CrossModSupport.Depths.Mod, "LodeStone"),
                GetModItem(CrossModSupport.Depths.Mod, "MercuryMossFishingBobber"),
                GetModItem(CrossModSupport.Depths.Mod, "QuicksilverproofFishingHook"),
                GetModItem(CrossModSupport.Depths.Mod, "QuicksilverproofTackleBag"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "BoxofGizmos"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "GoblinVoodooDoll"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "NerveFibre"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "PrisonSearchlight"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "Squidfood"),
                GetModItem(CrossModSupport.LuiAFK.Mod, "FasterMining"),
                GetModItem(CrossModSupport.LuiAFK.Mod, "SuperToolTime"),
                GetModItem(CrossModSupport.LuiAFK.Mod, "ToolTime"),
                GetModItem(CrossModSupport.LuiAFKDLC.Mod, "ArchitectHeavyEquipment"),
                GetModItem(CrossModSupport.LuiAFKDLC.Mod, "EnchantedSupremeFishingBundle"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "ArmorDisplayer"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "FlightTimer"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "Journal"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "IronWatch"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "LeadWatch"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "LeprechaunSensor"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "MinionCounter"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "SentryCounter"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "SummonersTracker"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "SurvivalTracker"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "DuckieBobber"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "UltraGlowingBobber"),
                //Common.GetModItem(CrossModSupport.MooMoosUltimateYoyoRevamp.Mod, "HitDisplay"),
                //Common.GetModItem(CrossModSupport.MooMoosUltimateYoyoRevamp.Mod, "SpeedDisplay"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "AnomalyInterceptor"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "AnomalyLocator"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "ArchaeologistToolbelt"),
                //GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "ElectromagneticDeterrent"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "GoldenTrowel"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "InfiniteVoid"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "FisheyeGem"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "MetalBand"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "MimicRepellent"),
                GetModItem(CrossModSupport.SpiritReforged.Mod, "Ledger"),
                GetModItem(CrossModSupport.SpiritReforged.Mod, "MysticalCodex"),
                GetModItem(CrossModSupport.SpiritReforged.Mod, "ScryingLens"),
                GetModItem(CrossModSupport.SpiritReforged.Mod, "OganessonBobber"),
                GetModItem(CrossModSupport.SpiritReforged.Mod, "RadonBobber"),
                GetModItem(CrossModSupport.SpiritReforged.Mod, "PearlString"),
                GetModItem(CrossModSupport.Terrorborn.Mod, "AntlionClaw"),
                GetModItem(CrossModSupport.Thorium.Mod, "HeartRateMonitor"),
                GetModItem(CrossModSupport.Thorium.Mod, "HightechSonarDevice"),
                GetModItem(CrossModSupport.Thorium.Mod, "GlitteringChalice"),
                GetModItem(CrossModSupport.Thorium.Mod, "GreedyGoblet"),
                GetModItem(CrossModSupport.Thorium.Mod, "LuckyRabbitsFoot"),
                GetModItem(CrossModSupport.Thorium.Mod, "GuidetoOvercomingGrief"),
                GetModItem(CrossModSupport.Vitality.Mod, "ShimmerFishingHook")
            ];
            ModBankItems.RemoveWhere(x => x == ItemID.None);
            Constants.BankItems.UnionWith(ModBankItems);

            HashSet<int> TempModdedBossSummons =
            [
                //QoLC Vanilla
                ModContent.ItemType<CultistSummon>(),
                ModContent.ItemType<DukeFishronSummon>(),
                ModContent.ItemType<EmpressOfLightSummon>(),
                ModContent.ItemType<GolemSummon>(),
                ModContent.ItemType<PlanteraSummon>(),
                ModContent.ItemType<SkeletronSummon>(),
                ModContent.ItemType<WallOfFleshSummon>(),
                //QoLC Calamity
                ModContent.ItemType<CragmawMireSummon>(),
                ModContent.ItemType<EidolonWyrmSummon>(),
                ModContent.ItemType<GiantClamSummon>(),
                ModContent.ItemType<GiantSquidSummon>(),
                ModContent.ItemType<MaulerSummon>(),
                ModContent.ItemType<NuclearTerrorSummon>(),
                ModContent.ItemType<OldDukeSummon>(),
                ModContent.ItemType<PrimordialWyrmSummon>(),
                ModContent.ItemType<ReaperSharkSummon>(),
                //QoLC Homeward Journey
                ModContent.ItemType<LifebringerSummon>(),
                ModContent.ItemType<MaterealizerSummon>(),
                ModContent.ItemType<OverwatcherSummon>(),
                ModContent.ItemType<ScarabBeliefSummon>(),
                ModContent.ItemType<WorldsEndWhaleSummon>(),
                //QoLC Spirit Classic
                ModContent.ItemType<HauntedTomeSummon>(),
                ModContent.ItemType<OccultistSummon>(),
                //QoLC Thorium
                ModContent.ItemType<ForgottenOneSummon>(),
                //AFKPETS
                GetModItem(CrossModSupport.AFKPets.Mod, "AncientSand"),
                GetModItem(CrossModSupport.AFKPets.Mod, "BlackenedHeart"),
                GetModItem(CrossModSupport.AFKPets.Mod, "BrokenDelftPlate"),
                GetModItem(CrossModSupport.AFKPets.Mod, "CookingBook"),
                GetModItem(CrossModSupport.AFKPets.Mod, "CorruptedServer"),
                GetModItem(CrossModSupport.AFKPets.Mod, "DemonicAnalysis"),
                GetModItem(CrossModSupport.AFKPets.Mod, "DesertMirror"),
                GetModItem(CrossModSupport.AFKPets.Mod, "DuckWhistle"),
                GetModItem(CrossModSupport.AFKPets.Mod, "FallingSlimeReplica"),
                GetModItem(CrossModSupport.AFKPets.Mod, "FrozenSkull"),
                GetModItem(CrossModSupport.AFKPets.Mod, "GoldenKingSlimeIdol"),
                GetModItem(CrossModSupport.AFKPets.Mod, "GoldenSkull"),
                GetModItem(CrossModSupport.AFKPets.Mod, "HaniwaIdol"),
                GetModItem(CrossModSupport.AFKPets.Mod, "HolographicSlimeReplica"),
                GetModItem(CrossModSupport.AFKPets.Mod, "IceBossCrystal"),
                GetModItem(CrossModSupport.AFKPets.Mod, "MagicWand"),
                GetModItem(CrossModSupport.AFKPets.Mod, "NightmareFuel"),
                GetModItem(CrossModSupport.AFKPets.Mod, "PinkDiamond"),
                GetModItem(CrossModSupport.AFKPets.Mod, "PlantAshContainer"),
                GetModItem(CrossModSupport.AFKPets.Mod, "PreyTrackingChip"),
                GetModItem(CrossModSupport.AFKPets.Mod, "RoastChickenPlate"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SeveredClothierHead"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SeveredDryadHead"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SeveredHarpyHead"),
                GetModItem(CrossModSupport.AFKPets.Mod, "ShogunSlimesHelmet"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SlimeinaGlassCube"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SlimyWarBanner"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SoulofAgonyinaBottle"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SpineWormFood"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SpiritofFunPot"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SpiritualHeart"),
                GetModItem(CrossModSupport.AFKPets.Mod, "StoryBook"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SuspiciousLookingChest"),
                GetModItem(CrossModSupport.AFKPets.Mod, "SwissChocolate"),
                GetModItem(CrossModSupport.AFKPets.Mod, "TiedBunny"),
                GetModItem(CrossModSupport.AFKPets.Mod, "TinyMeatIdol"),
                GetModItem(CrossModSupport.AFKPets.Mod, "TradeDeal"),
                GetModItem(CrossModSupport.AFKPets.Mod, "UnstableRainbowCookie"),
                GetModItem(CrossModSupport.AFKPets.Mod, "UntoldBurial"),
                //Awful Garbage
                GetModItem(CrossModSupport.AwfulGarbage.Mod, "InsectOnAStick"),
                GetModItem(CrossModSupport.AwfulGarbage.Mod, "PileOfFakeBones"),
                //Blocks Core Boss
                GetModItem(CrossModSupport.BlocksCoreBoss.Mod, "ChargedOrb"),
                GetModItem(CrossModSupport.BlocksCoreBoss.Mod, "ChargedOrbCrim"),
                //Consolaria
                GetModItem(CrossModSupport.Consolaria.Mod, "SuspiciousLookingEgg"),
                GetModItem(CrossModSupport.Consolaria.Mod, "CursedStuffing"),
                GetModItem(CrossModSupport.Consolaria.Mod, "SuspiciousLookingSkull"),
                //Coralite
                GetModItem(CrossModSupport.Coralite.Mod, "RedBerry"),
                //Edorbis
                GetModItem(CrossModSupport.Edorbis.Mod, "BiomechanicalMatter"),
                GetModItem(CrossModSupport.Edorbis.Mod, "CursedSoul"),
                GetModItem(CrossModSupport.Edorbis.Mod, "KelviniteRadar"),
                GetModItem(CrossModSupport.Edorbis.Mod, "SlayerTrophy"),
                GetModItem(CrossModSupport.Edorbis.Mod, "ThePrettiestFlower"),
                GetModItem(CrossModSupport.Edorbis.Mod, "DyingEcosystem"),
                //Excelsior
                GetModItem(CrossModSupport.Excelsior.Mod, "ReflectiveIceShard"),
                GetModItem(CrossModSupport.Excelsior.Mod, "PlanetaryTrackingDevice"),
                //Exxo Avalon Origins
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "BloodyAmulet"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "InfestedCarcass"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "DesertHorn"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "OddFertilizer"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "MechanicalWasp"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "EctoplasmicBeacon"),
                //Gensokyo
                GetModItem(CrossModSupport.Gensokyo.Mod, "AliceMargatroidSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "CirnoSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "EternityLarvaSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "HinaKagiyamaSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "KaguyaHouraisanSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "LilyWhiteSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "MayumiJoutouguuSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "MedicineMelancholySpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "MinamitsuMurasaSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "NazrinSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "NitoriKawashiroSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "RumiaSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "SakuyaIzayoiSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "SeijaKijinSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "SeiranSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "SekibankiSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "TenshiHinanawiSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "ToyosatomimiNoMikoSpawner"),
                GetModItem(CrossModSupport.Gensokyo.Mod, "UtsuhoReiujiSpawner"),
                //Homeward Journey
                GetModItem(CrossModSupport.HomewardJourney.Mod, "PurpleFlareGun"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "BeeLarva"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "MaliciousPacket"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "CannedSoulofFlight"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "MetalSpine"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "SouthernPotting"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "SunlightCrown"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "UltimateTorch"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "UnstableGlobe"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "CapricornMedal"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "GeminiMedal"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "LibraMedal"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "ScorpioMedal"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "TaurusMedal"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "VirgoMedal"),
                //Martin's Order
                GetModItem(CrossModSupport.MartinsOrder.Mod, "AntRubble"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "FrigidEgg"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "SuspiciousLookingCloud"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "Catnip"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "CarnageSuspiciousRazor"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "VoidWorm"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "LuminiteSlimeCrown"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "LuminiteEye"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "JunglesLastTreasure"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "TeslaRemote"),
                //Medial Rift
                GetModItem(CrossModSupport.MedialRift.Mod, "RemoteOfTheMetalHeads"),
                //Metroid Mod
                GetModItem(CrossModSupport.Metroid.Mod, "GoldenTorizoSummon"),
                GetModItem(CrossModSupport.Metroid.Mod, "KraidSummon"),
                GetModItem(CrossModSupport.Metroid.Mod, "NightmareSummon"),
                GetModItem(CrossModSupport.Metroid.Mod, "OmegaPirateSummon"),
                GetModItem(CrossModSupport.Metroid.Mod, "PhantoonSummon"),
                GetModItem(CrossModSupport.Metroid.Mod, "SerrisSummon"),
                GetModItem(CrossModSupport.Metroid.Mod, "TorizoSummon"),
                //Ophioid
                GetModItem(CrossModSupport.Ophioid.Mod, "DeadFungusbug"),
                GetModItem(CrossModSupport.Ophioid.Mod, "InfestedCompost"),
                GetModItem(CrossModSupport.Ophioid.Mod, "LivingCarrion"),
                //Qwerty
                GetModItem(CrossModSupport.Qwerty.Mod, "AncientEmblem"),
                GetModItem(CrossModSupport.Qwerty.Mod, "B4Summon"),
                GetModItem(CrossModSupport.Qwerty.Mod, "BladeBossSummon"),
                GetModItem(CrossModSupport.Qwerty.Mod, "DinoEgg"),
                //Common.GetModItem(CrossModSupport.Qwerty.Mod, "FortressBossSummon"),
                //Common.GetModItem(CrossModSupport.Qwerty.Mod, "GodSealKeycard"),
                GetModItem(CrossModSupport.Qwerty.Mod, "HydraSummon"),
                GetModItem(CrossModSupport.Qwerty.Mod, "RitualInterupter"),
                GetModItem(CrossModSupport.Qwerty.Mod, "SummoningRune"),
                //Redemption
                GetModItem(CrossModSupport.Redemption.Mod, "EaglecrestSpelltome"),
                GetModItem(CrossModSupport.Redemption.Mod, "EggCrown"),
                //Secrets of the Shadows
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "ElectromagneticLure"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "SuspiciousLookingCandle"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "JarOfPeanuts"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "CatalystBomb"),
                //Shadows of Abaddon
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "PumpkinLantern"),
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "PrimordiaSummon"),
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "AbaddonSummon"),
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "SerpentSummon"),
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "SoranEmblem"),
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "HeirsAuthority"),
                //Spirit
                GetModItem(CrossModSupport.SpiritClassic.Mod, "GladeWreath"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "ReachBossSummon"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "JewelCrown"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "DuskCrown"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "CursedCloth"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "StoneSkin"),
                //Spooky
                GetModItem(CrossModSupport.Spooky.Mod, "Fertilizer"),
                GetModItem(CrossModSupport.Spooky.Mod, "RottenSeed"),
                //Storms Additions
                GetModItem(CrossModSupport.StormsAdditions.Mod, "AridBossSummon"),
                GetModItem(CrossModSupport.StormsAdditions.Mod, "MoonlingSummoner"),
                GetModItem(CrossModSupport.StormsAdditions.Mod, "StormBossSummoner"),
                GetModItem(CrossModSupport.StormsAdditions.Mod, "UltimateBossSummoner"),
                //Supernova
                GetModItem(CrossModSupport.Supernova.Mod, "BugOnAStick"),
                GetModItem(CrossModSupport.Supernova.Mod, "EerieCrystal"),
                //Thorium
                GetModItem(CrossModSupport.Thorium.Mod, "StormFlare"),
                GetModItem(CrossModSupport.Thorium.Mod, "JellyfishResonator"),
                GetModItem(CrossModSupport.Thorium.Mod, "UnstableCore"),
                GetModItem(CrossModSupport.Thorium.Mod, "AncientBlade"),
                GetModItem(CrossModSupport.Thorium.Mod, "StarCaller"),
                GetModItem(CrossModSupport.Thorium.Mod, "StriderTear"),
                GetModItem(CrossModSupport.Thorium.Mod, "VoidLens"),
                GetModItem(CrossModSupport.Thorium.Mod, "AromaticBulb"),
                GetModItem(CrossModSupport.Thorium.Mod, "AbyssalShadow2"),
                GetModItem(CrossModSupport.Thorium.Mod, "DoomSayersCoin"),
                GetModItem(CrossModSupport.Thorium.Mod, "FreshBrain"),
                GetModItem(CrossModSupport.Thorium.Mod, "RottingSpore"),
                GetModItem(CrossModSupport.Thorium.Mod, "IllusionaryGlass"),
                //Utric
                GetModItem(CrossModSupport.Uhtric.Mod, "RareGeode"),
                GetModItem(CrossModSupport.Uhtric.Mod, "SnowyCharcoal"),
                GetModItem(CrossModSupport.Uhtric.Mod, "CosmicLure"),
                //Ultranium
                GetModItem(CrossModSupport.Ultranium.Mod, "BloodMoonSummon"),
                GetModItem(CrossModSupport.Ultranium.Mod, "DreadBeacon"),
                GetModItem(CrossModSupport.Ultranium.Mod, "EtherealLantern"),
                GetModItem(CrossModSupport.Ultranium.Mod, "IceFood"),
                GetModItem(CrossModSupport.Ultranium.Mod, "MiniProbe"),
                //Universe of Swords
                GetModItem(CrossModSupport.UniverseOfSwords.Mod, "SwordBossSummon"),
                //Valhalla
                GetModItem(CrossModSupport.Valhalla.Mod, "HeavensSeal"),
                GetModItem(CrossModSupport.Valhalla.Mod, "HellishRadish"),
                //Vitality
                GetModItem(CrossModSupport.Vitality.Mod, "CloudCore"),
                GetModItem(CrossModSupport.Vitality.Mod, "AncientCrown"),
                GetModItem(CrossModSupport.Vitality.Mod, "MultigemCluster"),
                GetModItem(CrossModSupport.Vitality.Mod, "MoonlightLotusFlower"),
                GetModItem(CrossModSupport.Vitality.Mod, "Dreadcandle"),
                GetModItem(CrossModSupport.Vitality.Mod, "MeatyMushroom"),
                GetModItem(CrossModSupport.Vitality.Mod, "AnarchyCrystal"),
                GetModItem(CrossModSupport.Vitality.Mod, "TotemofChaos"),
                GetModItem(CrossModSupport.Vitality.Mod, "MartianRadio"),
                GetModItem(CrossModSupport.Vitality.Mod, "SpiritBox"),
                //Wayfair
                GetModItem(CrossModSupport.WAYFAIRContentPack.Mod, "MagicFertilizer"),
                //Zylon
                GetModItem(CrossModSupport.Zylon.Mod, "ForgottenFlame"),
                GetModItem(CrossModSupport.Zylon.Mod, "SlimyScepter")
            ];
            TempModdedBossSummons.RemoveWhere(x => x == ItemID.None);
            Constants.ModdedBossSummons.UnionWith(TempModdedBossSummons);

            HashSet<int> TempModdedEventSummons =
            [
                //Calamity
                GetModItem(CrossModSupport.Calamity.Mod, "CausticTear"),
                GetModItem(CrossModSupport.Calamity.Mod, "MartianDistressRemote"),
                //Consolaria
                GetModItem(CrossModSupport.Consolaria.Mod, "Wishbone"),
                //Enchanted Moons
                GetModItem(CrossModSupport.EnchantedMoons.Mod, "BlueMedallion"),
                GetModItem(CrossModSupport.EnchantedMoons.Mod, "CherryAmulet"),
                GetModItem(CrossModSupport.EnchantedMoons.Mod, "HarvestLantern"),
                GetModItem(CrossModSupport.EnchantedMoons.Mod, "MintRing"),
                //Everjade
                GetModItem(CrossModSupport.Everjade.Mod, "FestivalLantern"),
                //Exxo Avalon Origins
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "GoblinRetreatOrder"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "FalseTreasureMap"),               
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "MartianPeaceTreaty"),         
                //Martin's Order
                GetModItem(CrossModSupport.MartinsOrder.Mod, "BloodyNight"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "LucidDay"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "LucidFestival"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "LucidNight"),
                //Redemption
                GetModItem(CrossModSupport.Redemption.Mod, "FowlWarHorn"),
                //Shadows of Abaddon
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "SandstormMedallion"),
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "PigmanBanner"),
                //Spirit
                GetModItem(CrossModSupport.SpiritClassic.Mod, "BlackPearl"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "BlueMoonSpawn"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "DistressJellyItem"),
                GetModItem(CrossModSupport.SpiritClassic.Mod, "MartianTransmitter"),
            ];
            TempModdedEventSummons.RemoveWhere(x => x == ItemID.None);
            Constants.ModdedEventSummons.UnionWith(TempModdedEventSummons);

            HashSet<int> TempFargosBossSummons =
            [
                //Fargos Mutant
                //ABOMINATIONN NPC ITEMS
                GetModItem(CrossModSupport.Fargowiltas.Mod, "BatteredClub"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "BetsyEgg"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "FestiveOrnament"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "ForbiddenTome"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "HeadofMan"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "IceKingsRemains"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MartianMemoryStick"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "NaughtyList"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SpookyBranch"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SuspiciousLookingScythe"),
                //MUTANT NPC ITEMS
                GetModItem(CrossModSupport.Fargowiltas.Mod, "Abeemination2"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "AncientSeal"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "CelestialSigil2"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "CultistSummon"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "DeathBringerFairy"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "DeerThing2"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "FleshyDoll"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "GoreySpine"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "JellyCrystal"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "LihzahrdPowerCell2"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MechanicalAmalgam"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MechEye"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MechSkull"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MechWorm"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MutantVoodoo"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "PlanterasFruit"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "PrismaticPrimrose"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SlimyCrown"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SuspiciousEye"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SuspiciousSkull"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "TruffleWorm2"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "WormyFood"),
                //Fargos Souls
                //MUTANT NPC ITEMS
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "AbomsCurse"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "ChampionySigil"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "CoffinSummon"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "DevisCurse"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "FragilePixieLamp"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MechLure"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MutantsCurse"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "SquirrelCoatofArms"),
                //Fargos DLC
                //MUTANT NPC ITEMS
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "ABombInMyNation"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "AstrumCor"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "BirbPheromones"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "BlightedEye"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "BloodyWorm"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "ChunkyStardust"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "ClamPearl"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "CryingKey"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "DefiledCore"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "DefiledShard"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "DragonEgg"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "EyeofExtinction"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "FriedDoll"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "HiveTumor"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "LetterofKos"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "MaulerSkull"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "MedallionoftheDesert"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "MurkySludge"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "NoisyWhistle"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "NuclearChunk"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "OphiocordycipitaceaeSprout"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "PolterplasmicBeacon"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "PortableCodebreaker"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "RedStainedWormFood"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "RiftofKos"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "SeeFood"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "SirensPearl"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "SomeKindofSpaceWorm"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "SulphurBearTrap"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "WormFoodofKos"),
            ];
            TempFargosBossSummons.RemoveWhere(x => x == ItemID.None);
            Constants.FargosBossSummons.UnionWith(TempFargosBossSummons);

            HashSet<int> TempFargosEventSummons =
            [
                //Fargos Mutant
                //ABOMINATIONN NPC ITEMS
                GetModItem(CrossModSupport.Fargowiltas.Mod, "Anemometer"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "ForbiddenScarab"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MatsuriLantern"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "PartyInvite"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "PillarSummon"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "RunawayProbe"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SlimyBarometer"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SpentLantern"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "WeatherBalloon"),
            ];
            TempFargosEventSummons.RemoveWhere(x => x == ItemID.None);
            Constants.FargosEventSummons.UnionWith(TempFargosEventSummons);

            HashSet<int> TempFargosEnemySummons =
            [
                //Fargos Mutant
                //DEVIANTT NPC ITEMS
                GetModItem(CrossModSupport.Fargowiltas.Mod, "AmalgamatedSkull"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "AmalgamatedSpirit"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "AthenianIdol"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "AttractiveOre"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "BloodSushiPlatter"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "BloodUrchin"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "CloudSnack"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "ClownLicense"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "CoreoftheFrostCore"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "CorruptChest"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "CrimsonChest"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "DemonicPlushie"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "DilutedRainbowMatter"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "Eggplant"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "ForbiddenForbiddenFragment"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "GnomeHat"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "GoblinScrap"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "GoldenSlimeCrown"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "GrandCross"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "HallowChest"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "HeartChocolate"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "HemoclawCrab"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "HolyGrail"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "JungleChest"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "LeesHeadband"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MothLamp"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "MothronEgg"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "Pincushion"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "PinkSlimeCrown"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "PirateFlag"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "PlunderedBooty"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "RuneOrb"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "ShadowflameIcon"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SlimyLockBox"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SuspiciousLookingChest"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "SuspiciousLookingLure"),
                GetModItem(CrossModSupport.Fargowiltas.Mod, "WormSnack"),
                //Fargos Extras
                GetModItem(CrossModSupport.FargowiltasSoulsExtras.Mod, "PandorasBox"),
                //Fargos DLC
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "AbandonedRemote"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "ColossalTentacle"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "DeepseaProteinShake"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "PlaguedWalkieTalkie"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "QuakeIdol"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "StormIdol"),
                GetModItem(CrossModSupport.FargowiltasCrossmod.Mod, "WyrmTablet")
            ];
            TempFargosEnemySummons.RemoveWhere(x => x == ItemID.None);
            Constants.FargosEnemySummons.UnionWith(TempFargosEnemySummons);

            HashSet<int> ModPrefixes =
            [
                GetModPrefix(CrossModSupport.Calamity.Mod, "Flawless"),
                GetModPrefix(CrossModSupport.Calamity.Mod, "Silent"),
                GetModPrefix(CrossModSupport.Calamity.Mod, "Dauntless"),
                GetModPrefix(CrossModSupport.Calamity.Mod, "Invigorating"),
                GetModPrefix(CrossModSupport.CalamityEntropy.Mod, "Enchanted"),
                GetModPrefix(CrossModSupport.ClickerClass.Mod, "Elite"),
                GetModPrefix(CrossModSupport.ClickerClass.Mod, "ClickerRadius"),
                GetModPrefix(CrossModSupport.MartinsOrder.Mod, "StrikerPrefix"),
                GetModPrefix(CrossModSupport.Orchid.Mod, "EmpyreanPrefix"),
                GetModPrefix(CrossModSupport.Orchid.Mod, "EtherealPrefix"),
                GetModPrefix(CrossModSupport.Orchid.Mod, "BlockingPrefix"),
                GetModPrefix(CrossModSupport.Orchid.Mod, "BrewingPrefix"),
                GetModPrefix(CrossModSupport.Orchid.Mod, "LoadedPrefix"),
                GetModPrefix(CrossModSupport.Orchid.Mod, "SpiritualPrefix"),
                GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omnipotent"),
                GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omniscient"),
                GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Soulbound"),
                GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Omnipotent"),
                GetModPrefix(CrossModSupport.Thorium.Mod, "Fabled"),
                GetModPrefix(CrossModSupport.Thorium.Mod, "Engrossing"),
                GetModPrefix(CrossModSupport.Thorium.Mod, "Lucrative"),
                GetModPrefix(CrossModSupport.Vitality.Mod, "MalevolentPrefix"),
                GetModPrefix(CrossModSupport.Vitality.Mod, "RelentlessPrefix")
            ];
            ModPrefixes.RemoveWhere(x => x == -1);
            Constants.Prefixes.UnionWith(ModPrefixes);

            HashSet<int> ModPermanentUpgrades =
            [
                GetModItem(CrossModSupport.Calamity.Mod, "MushroomPlasmaRoot"),
                GetModItem(CrossModSupport.Calamity.Mod, "InfernalBlood"),
                GetModItem(CrossModSupport.Calamity.Mod, "RedLightningContainer"),
                GetModItem(CrossModSupport.Calamity.Mod, "ElectrolyteGelPack"),
                GetModItem(CrossModSupport.Calamity.Mod, "StarlightFuelCell"),
                GetModItem(CrossModSupport.Calamity.Mod, "Ectoheart"),
                GetModItem(CrossModSupport.Calamity.Mod, "CelestialOnion"),
                GetModItem(CrossModSupport.ClickerClass.Mod, "HeavenlyChip"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "EnergyCrystal"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "DeerSinew"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MutantsCreditCard"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MutantsDiscountCard"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "MutantsPact"),
                GetModItem(CrossModSupport.FargowiltasSouls.Mod, "RabiesVaccine"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "Americano"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "Latte"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "Mocha"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "Cappuccino"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "AirHandcanon"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "HotCase"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "GreatCrystal"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "WhimInABottle"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "SunsHeart"),
                GetModItem(CrossModSupport.HomewardJourney.Mod, "TheSwitch"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "FishOfPurity"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "FishOfSpirit"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "FishOfWrath"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "ShimmerFish"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "MerchantBag"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "FirstAidTreatments"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "MartiniteBless"),
                GetModItem(CrossModSupport.Redemption.Mod, "GalaxyHeart"),
                GetModItem(CrossModSupport.Redemption.Mod, "MedicKit"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "ScarletStar"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "VioletStar"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "SoulHeart"),
                GetModItem(CrossModSupport.Thorium.Mod, "AstralWave"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationGem")
            ];
            ModPermanentUpgrades.RemoveWhere(x => x == ItemID.None);
            Constants.PermanentUpgrades.UnionWith(ModPermanentUpgrades);

            HashSet<int> ModPermanentMultiUseUpgrades =
            [
                GetModItem(CrossModSupport.Calamity.Mod, "EnchantedStarfish"),
                GetModItem(CrossModSupport.ExxoAvalonOrigins.Mod, "StaminaCrystal"),
                GetModItem(CrossModSupport.Ragnarok.Mod, "InspirationEssence"),
                GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "VoidenAnkh"),
                GetModItem(CrossModSupport.Thorium.Mod, "CrystalWave"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationFragment"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationShard"),
                GetModItem(CrossModSupport.Thorium.Mod, "InspirationCrystalNew")
            ];
            ModPermanentMultiUseUpgrades.RemoveWhere(x => x == ItemID.None);
            Constants.PermanentMultiUseUpgrades.UnionWith(ModPermanentMultiUseUpgrades);

            HashSet<int> ModEmblems =
            [
                GetModItem(CrossModSupport.Calamity.Mod, "RogueEmblem"),
                GetModItem(CrossModSupport.ClickerClass.Mod, "ClickerEmblem"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "ThrowerEmblem"),
                GetModItem(CrossModSupport.MartinsOrder.Mod, "NeutralEmblem"),
                //Common.GetModItem(CrossModSupport.Orchid.Mod, "AlchemistEmblem"),
                GetModItem(CrossModSupport.Orchid.Mod, "GuardianEmblem"),
                GetModItem(CrossModSupport.Orchid.Mod, "ShamanEmblem"),
                GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NinjaEmblem"),
                GetModItem(CrossModSupport.Thorium.Mod, "BardEmblem"),
                GetModItem(CrossModSupport.Thorium.Mod, "ClericEmblem"),
                GetModItem(CrossModSupport.Thorium.Mod, "NinjaEmblem"),
            ];
            ModEmblems.RemoveWhere(x => x == ItemID.None);
            Constants.Emblems.UnionWith(ModEmblems);

            HashSet<int> ModHerbs =
            [
                GetModTile(CrossModSupport.Depths.Mod, "ShadowShrub"),
                GetModTile(CrossModSupport.Redemption.Mod, "NightshadeTile"),
                GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Welkinbell"),
                GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Illumifern"),
                GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Enduflora"),
                GetModTile(CrossModSupport.SpiritClassic.Mod, "Cloudstalk"),
                GetModTile(CrossModSupport.SpiritClassic.Mod, "SoulBloomTile"),
                GetModTile(CrossModSupport.SpiritReforged.Mod, "CloudstalkTile"),
                GetModTile(CrossModSupport.Thorium.Mod, "MarineKelp"),
                GetModTile(CrossModSupport.Thorium.Mod, "MarineKelp2")
            ];
            ModHerbs.RemoveWhere(x => x == -1);
            Constants.HerbTiles.UnionWith(ModHerbs);

            HashSet<int> ElementsAwokenBatteries =
            [
                GetModItem(CrossModSupport.ElementsAwoken.Mod, "AABattery"),
                GetModItem(CrossModSupport.ElementsAwoken.Mod, "BioBattery"),
                GetModItem(CrossModSupport.ElementsAwoken.Mod, "ChaoticEnergyCapacitor"),
                GetModItem(CrossModSupport.ElementsAwoken.Mod, "DemonicPowerBank"),
                GetModItem(CrossModSupport.ElementsAwoken.Mod, "HellstoneCapacitor"),
                GetModItem(CrossModSupport.ElementsAwoken.Mod, "LunarEnergyHarnesser"),
                GetModItem(CrossModSupport.ElementsAwoken.Mod, "WoodenAccumulator"),
            ];
            ElementsAwokenBatteries.RemoveWhere(x => x == -1);
            Constants.ElementsAwokenBatteryItems.UnionWith(ElementsAwokenBatteries);

            HashSet <DamageClass> TempVoidClasses =
            [
                GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidMelee"),
                GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidRanged"),
                GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidMagic"),
                GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidSummon"),
                GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidGeneric"),
                GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidSymphonic"),
                GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidRadiant"),
                GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidThrowing"),
                GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "VoidRogue")
            ];
            TempVoidClasses.RemoveWhere(x => x == DamageClass.Generic);
            Constants.VoidDamageClasses.UnionWith(TempVoidClasses);

            HashSet<int> ModIgnoredTiles =
            [
                GetModTile(CrossModSupport.Split.Mod, "BatPot"),
                GetModTile(CrossModSupport.Thorium.Mod, "IllumiteChunk"),
                GetModTile(CrossModSupport.Thorium.Mod, "LifeQuartz"),
                GetModTile(CrossModSupport.Thorium.Mod, "LodeStone"),
                GetModTile(CrossModSupport.Thorium.Mod, "SmoothCoal"),
                GetModTile(CrossModSupport.Thorium.Mod, "ThoriumOre"),
                GetModTile(CrossModSupport.Thorium.Mod, "ValadiumChunk"),
                GetModTile(CrossModSupport.Thorium.Mod, "Aquamarine"),
                GetModTile(CrossModSupport.Thorium.Mod, "Opal"),
            ];
            ModIgnoredTiles.RemoveWhere(x => x == -1);
            Constants.IgnoredTilesForExplosives.UnionWith(ModIgnoredTiles);

            HashSet<Mod> TempIgnoredModsForExplosives =
            [
                CrossModSupport.ConfectionRebaked.Mod,
                CrossModSupport.Depths.Mod,
                CrossModSupport.InfectedQualities.Mod,
                CrossModSupport.LargeHerbs.Mod,
                CrossModSupport.MartinsOrder.Mod,
                CrossModSupport.Orchid.Mod,
                CrossModSupport.Remnants.Mod
            ];
            TempIgnoredModsForExplosives.RemoveWhere(x => x == null);
            Constants.IgnoredModsForExplosives.UnionWith(TempIgnoredModsForExplosives);

            HashSet<int> ModFoodBuffs =
            [
                GetModBuff(CrossModSupport.WrathOfTheGods.Mod, "StarstrikinglySatiated")
            ];
            ModFoodBuffs.RemoveWhere(x => x == -1);
            Constants.FoodBuffs.UnionWith(ModFoodBuffs);

            for (int i = BuffID.Count; i < BuffLoader.BuffCount; i++)
            {
                if (BuffID.Sets.IsAFlaskBuff[BuffLoader.GetBuff(i).Type] && !Constants.FlaskBuffs.Contains(BuffLoader.GetBuff(i).Type))
                    Constants.FlaskBuffs.Add(BuffLoader.GetBuff(i).Type);
            }

            if (CrossModSupport.Thorium.Loaded)
            {
                HashSet<int> TempThoriumCoatings =
                [
                    GetModBuff(CrossModSupport.Thorium.Mod, "DeepFreezeCoatingBuff"),
                    GetModBuff(CrossModSupport.Thorium.Mod, "ExplosiveCoatingBuff"),
                    GetModBuff(CrossModSupport.Thorium.Mod, "GorgonCoatingBuff"),
                    GetModBuff(CrossModSupport.Thorium.Mod, "SporeCoatingBuff"),
                    GetModBuff(CrossModSupport.Thorium.Mod, "ToxicCoatingBuff"),
                ];
                TempThoriumCoatings.RemoveWhere(x => x == -1);
                Constants.ThoriumCoatings.UnionWith(TempThoriumCoatings);
            }
        }

        public static void Reset()
        {

        }

        public static Color ColorSwap(Color firstColor, Color secondColor, float seconds)
        {
            float num = (float)((Math.Sin(Math.PI * 2.0 / (double)seconds * Main.GlobalTimeWrappedHourly) + 1.0) * 0.5);
            return Color.Lerp(firstColor, secondColor, num);
        }

        public interface IRightClickOverrideWhenHeld
        {
            bool RightClickOverrideWhileHeld(ref Item heldItem, Item[] inv, int context, int slot, Player player, QoLCPlayer qPlayer);
        }

        public static int GetModItem(Mod mod, string itemName)
        {
            if (mod != null)
            {
                if (mod.TryFind(itemName, out ModItem currItem) && currItem != null)
                {
                    return currItem.Type;
                }
            }
            return ItemID.None;
        }

        public static int GetModProjectile(Mod mod, string projName)
        {
            if (mod != null)
            {
                if (mod.TryFind(projName, out ModProjectile currProj) && currProj != null)
                {
                    return currProj.Type;
                }
            }
            return ProjectileID.None;
        }

        public static int GetModNPC(Mod mod, string npcName)
        {
            if (mod != null)
            {
                if (mod.TryFind(npcName, out ModNPC currNPC) && currNPC != null)
                {
                    return currNPC.Type;
                }
            }
            return NPCID.None;
        }

        public static int GetModTile(Mod mod, string tileName)
        {
            if (mod != null)
            {
                if (mod.TryFind(tileName, out ModTile currTile) && currTile != null)
                {
                    return currTile.Type;
                }
            }
            return -1;
        }

        public static int GetModWall(Mod mod, string wallName)
        {
            if (mod != null)
            {
                if (mod.TryFind(wallName, out ModWall currWall) && currWall != null)
                {
                    return currWall.Type;
                }
            }
            return WallID.None;
        }

        public static int GetModBuff(Mod mod, string buffName)
        {
            if (mod != null)
            {
                if (mod.TryFind(buffName, out ModBuff currBuff) && currBuff != null)
                {
                    return currBuff.Type;
                }
            }
            return -1;
        }

        public static int GetModPrefix(Mod mod, string prefixName)
        {
            if (mod != null)
            {
                if (mod.TryFind(prefixName, out ModPrefix currPrefix) && currPrefix != null)
                {
                    return currPrefix.Type;
                }
            }
            return -1;
        }

        public static DamageClass GetModDamageClass(Mod mod, string className)
        {
            if (mod != null)
            {
                if (mod.TryFind(className, out DamageClass currClass) && currClass != null)
                {
                    return currClass;
                }
            }
            return DamageClass.Generic;
        }

        public static StatModifier GetBestClassDamage(this Player player)
        {
            StatModifier ret = StatModifier.Default;
            StatModifier classless = player.GetTotalDamage<GenericDamageClass>();

            ret.Base = classless.Base;
            ret *= classless.Multiplicative;
            ret.Flat = classless.Flat;

            float best = 1f;

            float melee = player.GetTotalDamage<MeleeDamageClass>().Additive;
            if (melee > best) best = melee;
            float ranged = player.GetTotalDamage<RangedDamageClass>().Additive;
            if (ranged > best) best = ranged;
            float magic = player.GetTotalDamage<MagicDamageClass>().Additive;
            if (magic > best) best = magic;
            float summon = player.GetTotalDamage<SummonDamageClass>().Additive;
            if (summon > best) best = summon;

            for (int i = 0; i < DamageClassLoader.DamageClassCount; i++)
            {
                float dClass = player.GetTotalDamage(DamageClassLoader.GetDamageClass(i)).Additive;
                if (dClass > best) best = dClass;
            }

            ret += best - 1f;
            return ret;
        }

        public static int GetBoolCount(bool[] arrayToCount)
        {
            int count = 0;
            for (int i = 0; i < arrayToCount.Length; i++)
            {
                if (arrayToCount[i])
                    count += 1;
            }
            return count;
        }

        public static Asset<Texture2D> GetAsset(string location, string filename, int fileNumber = -1)
        {
            if (fileNumber > -1)
                return ModContent.Request<Texture2D>("QoLCompendium/Assets/" + location + "/" + filename + fileNumber);
            else
                return ModContent.Request<Texture2D>("QoLCompendium/Assets/" + location + "/" + filename);
        }

        public static int GetFirstNonZeroValue(int[] values)
        {
            int firstID = 0;
            if (values[0] != 0)
            {
                firstID = values.First();
            }
            else
            {
                for (int i = 0; i < values.Length - 1; i++)
                {
                    if (values[i] != 0)
                    {
                        firstID = values[i];
                        break;
                    }
                }
            }
            return firstID;
        }

        public static int GetLastNonZeroValue(int[] values)
        {
            int lastID = 0;
            if (values.Last() != 0)
            {
                lastID = values.Last();
            }
            else
            {
                for (int i = values.Length - 1; i > 0; i--)
                {
                    if (values[i] != 0)
                    {
                        lastID = values[i];
                        break;
                    }
                }
            }
            return lastID;
        }

        public static int ToFrames(float seconds, int extraUpdates = 0)
        {
            return (int)(seconds * 60 * (extraUpdates + 1));
        }

        public static float ToSeconds(float frames, int extraUpdates = 0)
        {
            return frames / (60 * (extraUpdates + 1));
        }

        public static void AddAfter<T>(this List<T> list, T element, T item)
        {
            var idx = list.IndexOf(element);
            list.Insert(idx + 1, item);
        }

        public static string GetTooltipValue(string suffix, params object[] args)
        {
            return Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips." + suffix, args);
        }

        public static void AddLastTooltip(List<TooltipLine> tooltips, TooltipLine tooltip)
        {
            var last = tooltips.FindLast(t => t.Mod == "Terraria")!;
            tooltips.AddAfter(last, tooltip);
        }

        public static string GetFullNameById(int id, int subtype = -1)
        {
            ModTile modTile = TileLoader.GetTile(id);
            if (modTile != null)
            {
                return modTile.Mod.Name + ":" + modTile.Name + ((subtype >= 0) ? $":{subtype}" : "");
            }
            if (id < TileID.Count)
            {
                return "Terraria:" + TileID.Search.GetName(id) + ((subtype >= 0) ? $":{subtype}" : "");
            }
            return null;
        }

        public static void UpdateWhitelist(int typeId, string name, int style = -1, bool remove = false)
        {
            if (!remove)
            {
                if (!QoLCompendium.veinminerConfig.VeinMinerTileWhitelist.Contains(name))
                {
                    QoLCompendium.veinminerConfig.VeinMinerTileWhitelist.Add(name);
                    SaveConfig(QoLCompendium.veinminerConfig);
                }
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    if (KeybindPlayer.timeout <= 0)
                    {
                        KeybindPlayer.timeout = byte.MaxValue;
                    }
                    else
                    {
                        KeybindPlayer.timeout = 0;
                        QoLCompendium.veinminerConfig.VeinMinerTileWhitelist.Add(name);
                        SaveConfig(QoLCompendium.veinminerConfig);
                    }
                }
            }
            else
            {
                if (QoLCompendium.veinminerConfig.VeinMinerTileWhitelist.Contains(name))
                {
                    QoLCompendium.veinminerConfig.VeinMinerTileWhitelist.Remove(name);
                    SaveConfig(QoLCompendium.veinminerConfig);
                }
            }
        }

        public static bool TryAcceptChanges(int whoAmI, ref NetworkText message)
        {
            if (NetMessage.DoesPlayerSlotCountAsAHost(whoAmI))
                return true;

            message = NetworkText.FromKey(Language.GetTextValue("Mods.QoLCompendium.Messages.HostOnly"));
            return false;
        }

        public static void SaveConfig(ModConfig config)
        {
            MethodInfo saveMethodInfo = typeof(ConfigManager).GetMethod("Save", BindingFlags.Static | BindingFlags.NonPublic);
            if (saveMethodInfo is not null)
            {
                saveMethodInfo.Invoke(null, new object[1] { config });
                return;
            }
            throw new Exception("Config file could not be created or updated at:\n'{path}'");
        }
#pragma warning restore IDE0028, IDE0300
    }
}
