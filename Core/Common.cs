using MonoMod.RuntimeDetour;
using QoLCompendium.Content.Items.Accessories.Construction;
using QoLCompendium.Content.Items.Accessories.Fishing;
using QoLCompendium.Content.Items.Accessories.InformationAccessories;
using QoLCompendium.Content.Items.Tools.Mirrors;
using QoLCompendium.Content.Items.Tools.Summons;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod;
using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Content.Tiles.Other;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core
{
    public static class Common
    {
#pragma warning disable CA2211, IDE0028, IDE0300

        public static readonly BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;

        public static List<Hook> detours = [];

        public static readonly HashSet<int> TownSlimeIDs = new(Enumerable.Range(678, 688 - 678)) { 670 };

        public static readonly HashSet<int> LunarPillarIDs = new() { NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerStardust, NPCID.LunarTowerVortex };

        public static readonly HashSet<int> CoinIDs = new() { ItemID.CopperCoin, ItemID.SilverCoin, ItemID.GoldCoin, ItemID.PlatinumCoin };

        public static readonly HashSet<int> RedPotionBuffs = new() {
            BuffID.ObsidianSkin,
            BuffID.Regeneration,
            BuffID.Swiftness,
            BuffID.Ironskin,
            BuffID.ManaRegeneration,
            BuffID.MagicPower,
            BuffID.Featherfall,
            BuffID.Spelunker,
            BuffID.Archery,
            BuffID.Heartreach,
            BuffID.Hunter,
            BuffID.Endurance,
            BuffID.Lifeforce,
            BuffID.Inferno,
            BuffID.Mining,
            BuffID.Rage,
            BuffID.Wrath,
            BuffID.Dangersense
        };

        public static int PlatinumMaxStack = 9999;
        public const ulong CopperValue = 1;
        public const ulong SilverValue = 100;
        public const ulong GoldValue = 100 * 100;
        public const ulong PlatinumValue = 100 * 100 * 100;

        public static readonly HashSet<int> PermanentUpgrades = new()
        {
            ItemID.AegisCrystal,
            ItemID.ArcaneCrystal,
            ItemID.AegisFruit,
            ItemID.Ambrosia,
            ItemID.GummyWorm,
            ItemID.GalaxyPearl,
            ItemID.PeddlersSatchel,
            ItemID.ArtisanLoaf,
            ItemID.CombatBook,
            ItemID.CombatBookVolumeTwo,
            ItemID.TorchGodsFavor,
            ItemID.MinecartPowerup
        };

        public static readonly int[] BossIDs = new int[]
        {
            NPCID.KingSlime,
            NPCID.EyeofCthulhu,
            NPCID.EaterofWorldsHead,
            NPCID.BrainofCthulhu,
            NPCID.QueenBee,
            NPCID.Deerclops,
            NPCID.SkeletronHead,
            NPCID.WallofFlesh,
            NPCID.QueenSlimeBoss,
            NPCID.Retinazer,
            NPCID.Spazmatism,
            NPCID.TheDestroyer,
            NPCID.SkeletronPrime,
            NPCID.Plantera,
            NPCID.Golem,
            NPCID.DukeFishron,
            NPCID.HallowBoss,
            NPCID.CultistBoss,
            NPCID.MoonLordCore,
        };

        public static readonly HashSet<int> VanillaBossAndEventSummons = new()
        {
            ItemID.SlimeCrown,
            ItemID.SuspiciousLookingEye,
            ItemID.WormFood,
            ItemID.BloodySpine,
            ItemID.Abeemination,
            ItemID.DeerThing,
            ItemID.QueenSlimeCrystal,
            ItemID.MechanicalWorm,
            ItemID.MechanicalEye,
            ItemID.MechanicalSkull,
            ItemID.MechdusaSummon,
            ItemID.CelestialSigil,
            ItemID.BloodMoonStarter,
            ItemID.GoblinBattleStandard,
            ItemID.PirateMap,
            ItemID.SolarTablet,
            ItemID.SnowGlobe,
            ItemID.PumpkinMoonMedallion,
            ItemID.NaughtyPresent
        };

        public static readonly HashSet<int> VanillaRightClickBossAndEventSummons = new()
        {
            ItemID.LihzahrdPowerCell,
            ItemID.DD2ElderCrystal
        };

        public static HashSet<int> ModdedBossAndEventSummons = new();

        public static HashSet<int> FargosBossAndEventSummons = new();

        public static readonly ushort[] EvilWallIDs = new ushort[]
        {
            WallID.CorruptGrassEcho,
            WallID.CorruptGrassUnsafe,
            WallID.CrimsonGrassEcho,
            WallID.CrimsonGrassUnsafe,
            WallID.HallowedGrassEcho,
            WallID.HallowedGrassUnsafe,
            WallID.EbonstoneEcho, 
            WallID.EbonstoneUnsafe,
            WallID.CrimstoneEcho,
            WallID.CrimstoneUnsafe,
            WallID.PearlstoneEcho,
            WallID.CorruptHardenedSandEcho,
            WallID.CorruptHardenedSand,
            WallID.CrimsonHardenedSandEcho,
            WallID.CrimsonHardenedSand,
            WallID.HallowHardenedSandEcho,
            WallID.HallowHardenedSand,
            WallID.CorruptSandstoneEcho,
            WallID.CorruptSandstone,
            WallID.CrimsonSandstoneEcho,
            WallID.CrimsonSandstone,
            WallID.HallowSandstoneEcho,
            WallID.HallowSandstone,
            WallID.Corruption1Echo,
            WallID.CorruptionUnsafe1,
            WallID.Corruption2Echo,
            WallID.CorruptionUnsafe2,
            WallID.Corruption3Echo,
            WallID.CorruptionUnsafe3,
            WallID.Corruption4Echo,
            WallID.CorruptionUnsafe4,
            WallID.Crimson1Echo,
            WallID.CrimsonUnsafe1,
            WallID.Crimson2Echo,
            WallID.CrimsonUnsafe2,
            WallID.Crimson3Echo,
            WallID.CrimsonUnsafe3,
            WallID.Crimson4Echo,
            WallID.CrimsonUnsafe4,
            WallID.Hallow1Echo,
            WallID.HallowUnsafe1,
            WallID.Hallow2Echo,
            WallID.HallowUnsafe2,
            WallID.Hallow3Echo,
            WallID.HallowUnsafe3,
            WallID.Hallow4Echo,
            WallID.HallowUnsafe4
        };

        public static readonly ushort[] PureWallIDs = new ushort[]
        {
            WallID.Grass,
            WallID.GrassUnsafe,
            WallID.Grass,
            WallID.GrassUnsafe,
            WallID.Grass,
            WallID.GrassUnsafe,
            WallID.Stone,
            WallID.Stone,
            WallID.Stone,
            WallID.Stone,
            WallID.Stone,
            WallID.HardenedSandEcho,
            WallID.HardenedSand,
            WallID.HardenedSandEcho,
            WallID.HardenedSand,
            WallID.HardenedSandEcho,
            WallID.HardenedSand,
            WallID.SandstoneEcho,
            WallID.Sandstone,
            WallID.SandstoneEcho,
            WallID.Sandstone,
            WallID.SandstoneEcho,
            WallID.Sandstone,
            WallID.Dirt1Echo,
            WallID.DirtUnsafe1,
            WallID.Dirt2Echo,
            WallID.DirtUnsafe2,
            WallID.Dirt3Echo,
            WallID.DirtUnsafe3,
            WallID.Dirt4Echo,
            WallID.DirtUnsafe4,
            WallID.Dirt1Echo,
            WallID.DirtUnsafe1,
            WallID.Dirt2Echo,
            WallID.DirtUnsafe2,
            WallID.Dirt3Echo,
            WallID.DirtUnsafe3,
            WallID.Dirt4Echo,
            WallID.DirtUnsafe4,
            WallID.Dirt1Echo,
            WallID.DirtUnsafe1,
            WallID.Dirt2Echo,
            WallID.DirtUnsafe2,
            WallID.Dirt3Echo,
            WallID.DirtUnsafe3,
            WallID.Dirt4Echo,
            WallID.DirtUnsafe4
        };

        public static readonly HashSet<int> FallingBlocks = new()
        {
            ProjectileID.SandBallFalling,
            ProjectileID.EbonsandBallFalling,
            ProjectileID.CrimsandBallFalling,
            ProjectileID.PearlSandBallFalling,
            ProjectileID.SiltBall,
            ProjectileID.SlushBall
        };

        public static readonly List<int> PowerUpItems = new()
        {
            ItemID.Heart,
            ItemID.CandyApple,
            ItemID.CandyCane,
            ItemID.Star,
            ItemID.SoulCake,
            ItemID.SugarPlum,
            ItemID.NebulaPickup1,
            ItemID.NebulaPickup2,
            ItemID.NebulaPickup3,
        };

        public static readonly int[] VanillaFountains = new int[]
        {
            ItemID.PureWaterFountain,
            ItemID.CorruptWaterFountain,
            ItemID.JungleWaterFountain,
            ItemID.HallowedWaterFountain,
            ItemID.IcyWaterFountain,
            ItemID.DesertWaterFountain,
            ItemID.OasisFountain,
            ItemID.CrimsonWaterFountain
        };

        public static readonly HashSet<int> MobileStorages = new()
        {
            ProjectileID.FlyingPiggyBank,
            ProjectileID.VoidLens,
            ModContent.ProjectileType<FlyingSafeProjectile>(),
            ModContent.ProjectileType<EtherianConstructProjectile>()
        };

        public static readonly bool[] NormalBunnies = NPCID.Sets.Factory.CreateBoolSet(NPCID.Bunny, NPCID.GemBunnyTopaz, NPCID.GemBunnySapphire, NPCID.GemBunnyRuby, NPCID.GemBunnyEmerald, NPCID.GemBunnyDiamond, NPCID.GemBunnyAmethyst, NPCID.GemBunnyAmber, NPCID.ExplosiveBunny, NPCID.BunnySlimed, NPCID.BunnyXmas, NPCID.CorruptBunny, NPCID.CrimsonBunny, NPCID.PartyBunny);
        
        public static readonly bool[] NormalSquirrels = NPCID.Sets.Factory.CreateBoolSet(NPCID.Squirrel, NPCID.SquirrelRed, NPCID.GemSquirrelTopaz, NPCID.GemSquirrelSapphire, NPCID.GemSquirrelRuby, NPCID.GemSquirrelEmerald, NPCID.GemSquirrelDiamond, NPCID.GemSquirrelAmethyst, NPCID.GemSquirrelAmber);
        
        public static readonly bool[] NormalButterflies = NPCID.Sets.Factory.CreateBoolSet(NPCID.Butterfly, NPCID.HellButterfly, NPCID.EmpressButterfly);
        
        public static readonly bool[] NormalBirds = NPCID.Sets.Factory.CreateBoolSet(NPCID.Bird, NPCID.BirdBlue, NPCID.BirdRed);

        public static HashSet<int> Prefixes = new()
        {
            PrefixID.Legendary,
            PrefixID.Legendary2,
            PrefixID.Godly,
            PrefixID.Light,
            PrefixID.Rapid,
            PrefixID.Demonic,
            PrefixID.Unreal,
            PrefixID.Mythical,
            PrefixID.Ruthless,
            PrefixID.Warding,
            PrefixID.Arcane,
            PrefixID.Lucky,
            PrefixID.Menacing,
            PrefixID.Quick2,
            PrefixID.Violent
        };

        public static HashSet<int> BankItems = new() 
        {
            ItemID.DiscountCard,
            ItemID.LuckyCoin,
            ItemID.GoldRing,
            ItemID.CoinRing,
            ItemID.GreedyRing,
            ItemID.MechanicalLens,
            ItemID.LaserRuler,
            ItemID.WireKite,
            ItemID.PDA,
            ItemID.CellPhone,
            ItemID.ShellphoneDummy,
            ItemID.Shellphone,
            ItemID.ShellphoneSpawn,
            ItemID.ShellphoneOcean,
            ItemID.ShellphoneHell,
            ItemID.GPS,
            ItemID.REK,
            ItemID.GoblinTech,
            ItemID.FishFinder,
            ItemID.CopperWatch,
            ItemID.TinWatch,
            ItemID.SilverWatch,
            ItemID.TungstenWatch,
            ItemID.GoldWatch,
            ItemID.PlatinumWatch,
            ItemID.DepthMeter,
            ItemID.Compass,
            ItemID.Radar,
            ItemID.LifeformAnalyzer,
            ItemID.TallyCounter,
            ItemID.MetalDetector,
            ItemID.Stopwatch,
            ItemID.DPSMeter,
            ItemID.FishermansGuide,
            ItemID.WeatherRadio,
            ItemID.Sextant,
            ItemID.AncientChisel,
            ItemID.Toolbelt,
            ItemID.Toolbox,
            ItemID.ExtendoGrip,
            ItemID.PortableCementMixer,
            ItemID.PaintSprayer,
            ItemID.BrickLayer,
            ItemID.ArchitectGizmoPack,
            ItemID.HandOfCreation,
            ItemID.ActuationAccessory,
            ItemID.HighTestFishingLine,
            ItemID.AnglerEarring,
            ItemID.TackleBox,
            ItemID.LavaFishingHook,
            ItemID.AnglerTackleBag,
            ItemID.LavaproofTackleBag,
            ItemID.FishingBobber,
            ItemID.FishingBobberGlowingStar,
            ItemID.FishingBobberGlowingLava,
            ItemID.FishingBobberGlowingKrypton,
            ItemID.FishingBobberGlowingXenon,
            ItemID.FishingBobberGlowingArgon,
            ItemID.FishingBobberGlowingViolet,
            ItemID.FishingBobberGlowingRainbow,
            ItemID.TreasureMagnet,
            ItemID.RoyalGel,
            ItemID.SpectreGoggles,
            ItemID.DontHurtCrittersBook,
            ItemID.DontHurtNatureBook,
            ItemID.DontHurtComboBook,
            ItemID.ShimmerCloak,
            ItemID.DontStarveShaderItem,
            ItemID.EncumberingStone
        };

        public static HashSet<int> IgnoredTilesForExplosives = new()
        {
            ModContent.TileType<AsphaltPlatformTile>()
        };

        public static HashSet<Mod> IgnoredModsForExplosives = new();

        public static HashSet<int> IgnoredPermanentBuffs = new()
        {
            BuffID.Tipsy,
            BuffID.WaterCandle,
            BuffID.ShadowCandle
        };

        public static HashSet<int> FlaskBuffs = new()
        {
            BuffID.WeaponImbueConfetti,
            BuffID.WeaponImbueCursedFlames,
            BuffID.WeaponImbueFire,
            BuffID.WeaponImbueGold,
            BuffID.WeaponImbueIchor,
            BuffID.WeaponImbueNanites,
            BuffID.WeaponImbuePoison,
            BuffID.WeaponImbueVenom
        };

        public static HashSet<int> ThoriumCoatings = new();

        #region Boss Drops
        public static readonly int[] kingSlimeDrops = { 
            ItemID.SlimySaddle,
            ItemID.NinjaHood,
            ItemID.NinjaShirt,
            ItemID.NinjaPants,
            ItemID.SlimeHook,
            ItemID.SlimeGun
        };

        public static readonly int[] eyeOfCthulhuDrops = { ItemID.Binoculars };

        public static readonly int[] eaterOfWorldsDrops = { ItemID.EatersBone };

        public static readonly int[] brainOfCthulhuDrops = { ItemID.BoneRattle };

        public static readonly int[] queenBeeDrops = {
            ItemID.BeeGun,
            ItemID.BeeKeeper,
            ItemID.BeesKnees,
            ItemID.HiveWand,
            ItemID.BeeHat,
            ItemID.BeeShirt,
            ItemID.BeePants,
            ItemID.HoneyComb,
            ItemID.Nectar,
            ItemID.HoneyedGoggles
        };

        public static readonly int[] deerclopsDrops = {
            ItemID.ChesterPetItem,
            ItemID.Eyebrella,
            ItemID.DontStarveShaderItem,
            ItemID.DizzyHat,
            ItemID.PewMaticHorn,
            ItemID.WeatherPain,
            ItemID.HoundiusShootius,
            ItemID.LucyTheAxe
        };

        public static readonly int[] skeletronDrops = {
            ItemID.SkeletronHand,
            ItemID.BookofSkulls,
            ItemID.ChippysCouch
        };

        public static readonly int[] wallOfFleshDrops = {
            ItemID.BreakerBlade,
            ItemID.ClockworkAssaultRifle,
            ItemID.LaserRifle,
            ItemID.FireWhip,
            ItemID.WarriorEmblem,
            ItemID.RangerEmblem,
            ItemID.SorcererEmblem,
            ItemID.SummonerEmblem
        };

        public static readonly int[] queenSlimeDrops = {
            ItemID.CrystalNinjaHelmet,
            ItemID.CrystalNinjaChestplate,
            ItemID.CrystalNinjaLeggings,
            ItemID.Smolstar,
            ItemID.QueenSlimeMountSaddle,
            ItemID.QueenSlimeHook
        };

        public static readonly int[] planteraDrops = {
            ItemID.GrenadeLauncher,
            ItemID.VenusMagnum,
            ItemID.NettleBurst,
            ItemID.LeafBlower,
            ItemID.FlowerPow,
            ItemID.WaspGun,
            ItemID.Seedler,
            ItemID.PygmyStaff,
            ItemID.ThornHook,
            ItemID.TheAxe,
            ItemID.Seedling
        };

        public static readonly int[] golemDrops = {
            ItemID.Picksaw,
            ItemID.Stynger,
            ItemID.PossessedHatchet,
            ItemID.SunStone,
            ItemID.EyeoftheGolem,
            ItemID.HeatRay,
            ItemID.StaffofEarth,
            ItemID.GolemFist
        };

        public static readonly int[] betsyDrops = {
            ItemID.BetsyWings,
            ItemID.DD2BetsyBow,
            ItemID.MonkStaffT3,
            ItemID.ApprenticeStaffT3,
            ItemID.DD2SquireBetsySword
        };

        public static readonly int[] dukeFishronDrops = {
            ItemID.FishronWings,
            ItemID.BubbleGun,
            ItemID.Flairon,
            ItemID.RazorbladeTyphoon,
            ItemID.TempestStaff,
            ItemID.Tsunami
        };

        public static readonly int[] empressOfLightDrops = {
            ItemID.FairyQueenMagicItem,
            ItemID.PiercingStarlight,
            ItemID.RainbowWhip,
            ItemID.FairyQueenRangedItem,
            ItemID.RainbowWings,
            ItemID.SparkleGuitar,
            ItemID.RainbowCursor
        };

        public static readonly int[] moonLordDrops = {
            ItemID.Meowmere,
            ItemID.Terrarian,
            ItemID.StarWrath,
            ItemID.SDMG,
            ItemID.Celeb2,
            ItemID.LastPrism,
            ItemID.LunarFlareBook,
            ItemID.RainbowCrystalStaff,
            ItemID.MoonlordTurretStaff,
            ItemID.MeowmereMinecart,
        };
        #endregion

        public static int AnyPirateBanner;

        public static int AnyArmoredBonesBanner;

        public static int AnySlimeBanner;

        public static int AnyBatBanner;

        public static int AnyHallowBanner;

        public static int AnyCorruptionBanner;

        public static int AnyCrimsonBanner;

        public static int AnyJungleBanner;

        public static int AnySnowBanner;

        public static int AnyDesertBanner;

        public static int AnyUnderworldBanner;

        public enum PlacedPlatformStyles
        {
            Wood,
            Ebonwood,
            RichMahogany,
            Pearlwood,
            Bone,
            Shadewood,
            BlueBrick,
            PinkBrick,
            GreenBrick,
            MetalShelf,
            BrassShelf,
            WoodShelf,
            DungeonShelf,
            Obsidian,
            Glass,
            Pumpkin,
            SpookyWood,
            PalmWood,
            Mushroom,
            BorealWood,
            Slime,
            Steampunk,
            Skyware,
            LivingWood,
            Honey,
            Cactus,
            Martian,
            Meteorite,
            Granite,
            Marble,
            Crystal,
            Golden,
            DynastyWood,
            Lihzahrd,
            Flesh,
            Frozen,
            Spider,
            Lesion,
            Solar,
            Vortex,
            Nebula,
            Stardust,
            Sandstone,
            Stone,
            Bamboo,
            Reef,
            Balloon,
            AshWood,
            Echo,
        }

        public enum PlacedTableStyles1
        {
            Wooden,
            Ebonwood,
            RichMahogany,
            Pearlwood,
            Bone,
            Flesh,
            LivingWood,
            Skyware,
            Shadewood,
            Lihzahrd,
            BlueDungeon,
            GreenDungeon,
            PinkDungeon,
            Obsidian,
            Gothic,
            Glass,
            Banquet,
            Bar,
            Golden,
            Honey,
            Steampunk,
            Pumpkin,
            Spooky,
            Pine,
            Frozen,
            Dynasty,
            PalmWood,
            Mushroom,
            BorealWood,
            Slime,
            Cactus,
            Martian,
            Meteorite,
            Granite,
            Marble
        }

        public enum PlacedTableStyles2
        {
            Crystal,
            Spider,
            Lesion,
            Solar,
            Vortex,
            Nebula,
            Stardust,
            Sandstone,
            Bamboo,
            Reef,
            Balloon,
            AshWood
        }

        public enum PlacedChairStyles
        {
            Wooden,
            Tiolet,
            Ebonwood,
            RichMahogany,
            Pearlwood,
            LivingWood,
            Cactus,
            Bone,
            Flesh,
            Mushroom,
            Skyware,
            Shadewood,
            Lihzahrd,
            BlueDungeon,
            GreenDungeon,
            PinkDungeon,
            Obsidian,
            Gothic,
            Glass,
            Golden,
            GoldenToilet,
            BarStool,
            Honey,
            Steampunk,
            Pumpkin,
            Spooky,
            Pine,
            Dynasty,
            Frozen,
            PalmWood,
            BorealWood,
            Slime,
            Martian,
            Meteorite,
            Granite,
            Marble,
            Crystal,
            Spider,
            Lesion,
            Solar,
            Vortex,
            Nebula,
            Stardust,
            Sandstone,
            Bamboo
        }

        public enum PlacedDoorStyles
        {
            Wooden,
            Ebonwood,
            RichMahogany,
            Pearlwood,
            Cactus,
            Flesh,
            Mushroom,
            LivingWood,
            Bone,
            Skyware,
            Shadewood,
            LockedLihzahrd,
            Lihzahrd,
            Dungeon,
            Lead,
            Iron,
            BlueDungeon,
            GreenDungeon,
            PinkDungeon,
            Obsidian,
            Glass,
            Golden,
            Honey,
            Steampunk,
            Pumpkin,
            Spooky,
            Pine,
            Frozen,
            Dynasty,
            PalmWood,
            BorealWood,
            Slime,
            Martian,
            Meteorite,
            Granite,
            Marble,
            Crystal,
            Spider,
            Lesion,
            Solar,
            Vortex,
            Nebula,
            Stardust,
            Sandstone,
            Stone,
            Bamboo
        }

        public enum PlacedTorchStyles
        {
            Torch,
            BlueTorch,
            RedTorch,
            GreenTorch,
            PurpleTorch,
            WhiteTorch,
            YellowTorch,
            DemonTorch,
            CursedTorch,
            IceTorch,
            OrangeTorch,
            IchorTorch,
            UltrabrightTorch,
            BoneTorch,
            RainbowTorch,
            PinkTorch,
            DesertTorch,
            CoralTorch,
            CorruptTorch,
            CrimsonTorch,
            HallowedTorch,
            JungleTorch,
            MushroomTorch,
            AetherTorch
        }

        public static void UnloadTasks()
        {
            foreach (var hook in detours)
                hook.Undo();
        }

        public static void PostSetupTasks()
        {
            HashSet<int> ModBankItems = new()
            {
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
                ModContent.ItemType<AnglersDream>(),
                Common.GetModItem(ModConditions.aequusMod, "AnglerBroadcaster"),
                Common.GetModItem(ModConditions.aequusMod, "Calendar"),
                Common.GetModItem(ModConditions.aequusMod, "GeigerCounter"),
                Common.GetModItem(ModConditions.aequusMod, "HoloLens"),
                Common.GetModItem(ModConditions.aequusMod, "RichMansMonocle"),
                Common.GetModItem(ModConditions.aequusMod, "DevilsTongue"),
                Common.GetModItem(ModConditions.aequusMod, "NeonGenesis"),
                Common.GetModItem(ModConditions.aequusMod, "RadonFishingBobber"),
                Common.GetModItem(ModConditions.aequusMod, "Ramishroom"),
                Common.GetModItem(ModConditions.aequusMod, "RegrowingBait"),
                Common.GetModItem(ModConditions.aequusMod, "LavaproofMitten"),
                Common.GetModItem(ModConditions.aequusMod, "BusinessCard"),
                Common.GetModItem(ModConditions.aequusMod, "HaltingMachine"),
                Common.GetModItem(ModConditions.aequusMod, "HaltingMagnet"),
                Common.GetModItem(ModConditions.aequusMod, "HyperJet"),
                Common.GetModItem(ModConditions.afkpetsMod, "FishermansPride"),
                Common.GetModItem(ModConditions.afkpetsMod, "LampyridaeHairpin"),
                Common.GetModItem(ModConditions.afkpetsMod, "Piracy"),
                Common.GetModItem(ModConditions.afkpetsMod, "PortableSonar"),
                Common.GetModItem(ModConditions.afkpetsMod, "TheHandyman"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "AttendanceLog"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "BiomeCrystal"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "EngiRegistry"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "FortuneMirror"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "HitMarker"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "Magimeter"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "RSH"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "SafteyScanner"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "ScryingMirror"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "ThreatAnalyzer"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "WantedPoster"),
                Common.GetModItem(ModConditions.calamityMod, "AlluringBait"),
                Common.GetModItem(ModConditions.calamityMod, "EnchantedPearl"),
                Common.GetModItem(ModConditions.calamityMod, "SupremeBaitTackleBoxFishingStation"),
                Common.GetModItem(ModConditions.calamityMod, "AncientFossil"),
                Common.GetModItem(ModConditions.calamityMod, "OceanCrest"),
                Common.GetModItem(ModConditions.calamityMod, "SpelunkersAmulet"),
                Common.GetModItem(ModConditions.clickerClassMod, "ButtonMasher"),
                Common.GetModItem(ModConditions.depthsMod, "LodeStone"),
                Common.GetModItem(ModConditions.depthsMod, "MercuryMossFishingBobber"),
                Common.GetModItem(ModConditions.depthsMod, "QuicksilverproofFishingHook"),
                Common.GetModItem(ModConditions.depthsMod, "QuicksilverproofTackleBag"),
                Common.GetModItem(ModConditions.luiAFKMod, "FasterMining"),
                Common.GetModItem(ModConditions.luiAFKMod, "SuperToolTime"),
                Common.GetModItem(ModConditions.luiAFKMod, "ToolTime"),
                Common.GetModItem(ModConditions.luiAFKDLCMod, "ArchitectHeavyEquipment"),
                Common.GetModItem(ModConditions.luiAFKDLCMod, "EnchantedSupremeFishingBundle"),
                Common.GetModItem(ModConditions.martainsOrderMod, "ArmorDisplayer"),
                Common.GetModItem(ModConditions.martainsOrderMod, "FlightTimer"),
                Common.GetModItem(ModConditions.martainsOrderMod, "Journal"),
                Common.GetModItem(ModConditions.martainsOrderMod, "IronWatch"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LeadWatch"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LeprechaunSensor"),
                Common.GetModItem(ModConditions.martainsOrderMod, "MinionCounter"),
                Common.GetModItem(ModConditions.martainsOrderMod, "SentryCounter"),
                Common.GetModItem(ModConditions.martainsOrderMod, "SummonersTracker"),
                Common.GetModItem(ModConditions.martainsOrderMod, "SurvivalTracker"),
                //Common.GetModItem(ModConditions.moomoosUltimateYoyoRevampMod, "HitDisplay"),
                //Common.GetModItem(ModConditions.moomoosUltimateYoyoRevampMod, "SpeedDisplay"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "AnomalyLocator"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "ArchaeologistToolbelt"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "ElectromagneticDeterrent"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "GoldenTrowel"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "InfiniteVoid"),
                Common.GetModItem(ModConditions.spiritMod, "FisheyeGem"),
                Common.GetModItem(ModConditions.spiritMod, "MetalBand"),
                Common.GetModItem(ModConditions.spiritMod, "MimicRepellent"),
                Common.GetModItem(ModConditions.thoriumMod, "HeartRateMonitor"),
                Common.GetModItem(ModConditions.thoriumMod, "HightechSonarDevice"),
                Common.GetModItem(ModConditions.thoriumMod, "GlitteringChalice"),
                Common.GetModItem(ModConditions.thoriumMod, "GreedyGoblet"),
                Common.GetModItem(ModConditions.thoriumMod, "LuckyRabbitsFoot")
            };
            BankItems.UnionWith(ModBankItems);

            HashSet<int> TempModdedBossAndEventSummons = new()
            {
                //QoLC
                ModContent.ItemType<CultistSummon>(),
                ModContent.ItemType<DukeFishronSummon>(),
                ModContent.ItemType<EmpressOfLightSummon>(),
                ModContent.ItemType<PlanteraSummon>(),
                ModContent.ItemType<SkeletronSummon>(),
                ModContent.ItemType<WallOfFleshSummon>(),
                ModContent.ItemType<ForgottenOneSummon>(),
                ModContent.ItemType<GiantClamSummon>(),
                ModContent.ItemType<LeviathanAnahitaSummon>(),
                ModContent.ItemType<OldDukeSummon>(),
                //Aequus
                Common.GetModItem(ModConditions.aequusMod, "GalacticStarfruit"),
                //AFKPETS
                Common.GetModItem(ModConditions.afkpetsMod, "AncientSand"),
                Common.GetModItem(ModConditions.afkpetsMod, "BlackenedHeart"),
                Common.GetModItem(ModConditions.afkpetsMod, "BrokenDelftPlate"),
                Common.GetModItem(ModConditions.afkpetsMod, "CookingBook"),
                Common.GetModItem(ModConditions.afkpetsMod, "CorruptedServer"),
                Common.GetModItem(ModConditions.afkpetsMod, "DemonicAnalysis"),
                Common.GetModItem(ModConditions.afkpetsMod, "DesertMirror"),
                Common.GetModItem(ModConditions.afkpetsMod, "DuckWhistle"),
                Common.GetModItem(ModConditions.afkpetsMod, "FallingSlimeReplica"),
                Common.GetModItem(ModConditions.afkpetsMod, "FrozenSkull"),
                Common.GetModItem(ModConditions.afkpetsMod, "GoldenKingSlimeIdol"),
                Common.GetModItem(ModConditions.afkpetsMod, "GoldenSkull"),
                Common.GetModItem(ModConditions.afkpetsMod, "HaniwaIdol"),
                Common.GetModItem(ModConditions.afkpetsMod, "HolographicSlimeReplica"),
                Common.GetModItem(ModConditions.afkpetsMod, "IceBossCrystal"),
                Common.GetModItem(ModConditions.afkpetsMod, "MagicWand"),
                Common.GetModItem(ModConditions.afkpetsMod, "NightmareFuel"),
                Common.GetModItem(ModConditions.afkpetsMod, "PinkDiamond"),
                Common.GetModItem(ModConditions.afkpetsMod, "PlantAshContainer"),
                Common.GetModItem(ModConditions.afkpetsMod, "PreyTrackingChip"),
                Common.GetModItem(ModConditions.afkpetsMod, "RoastChickenPlate"),
                Common.GetModItem(ModConditions.afkpetsMod, "SeveredClothierHead"),
                Common.GetModItem(ModConditions.afkpetsMod, "SeveredDryadHead"),
                Common.GetModItem(ModConditions.afkpetsMod, "SeveredHarpyHead"),
                Common.GetModItem(ModConditions.afkpetsMod, "ShogunSlimesHelmet"),
                Common.GetModItem(ModConditions.afkpetsMod, "SlimeinaGlassCube"),
                Common.GetModItem(ModConditions.afkpetsMod, "SlimyWarBanner"),
                Common.GetModItem(ModConditions.afkpetsMod, "SoulofAgonyinaBottle"),
                Common.GetModItem(ModConditions.afkpetsMod, "SpineWormFood"),
                Common.GetModItem(ModConditions.afkpetsMod, "SpiritofFunPot"),
                Common.GetModItem(ModConditions.afkpetsMod, "SpiritualHeart"),
                Common.GetModItem(ModConditions.afkpetsMod, "StoryBook"),
                Common.GetModItem(ModConditions.afkpetsMod, "SuspiciousLookingChest"),
                Common.GetModItem(ModConditions.afkpetsMod, "SwissChocolate"),
                Common.GetModItem(ModConditions.afkpetsMod, "TiedBunny"),
                Common.GetModItem(ModConditions.afkpetsMod, "TinyMeatIdol"),
                Common.GetModItem(ModConditions.afkpetsMod, "TradeDeal"),
                Common.GetModItem(ModConditions.afkpetsMod, "UnstableRainbowCookie"),
                Common.GetModItem(ModConditions.afkpetsMod, "UntoldBurial"),
                //Awful Garbage
                Common.GetModItem(ModConditions.awfulGarbageMod, "InsectOnAStick"),
                Common.GetModItem(ModConditions.awfulGarbageMod, "PileOfFakeBones"),
                //Blocks Core Boss
                Common.GetModItem(ModConditions.blocksCoreBossMod, "ChargedOrb"),
                Common.GetModItem(ModConditions.blocksCoreBossMod, "ChargedOrbCrim"),
                //Consolaria
                Common.GetModItem(ModConditions.consolariaMod, "SuspiciousLookingEgg"),
                Common.GetModItem(ModConditions.consolariaMod, "CursedStuffing"),
                Common.GetModItem(ModConditions.consolariaMod, "SuspiciousLookingSkull"),
                Common.GetModItem(ModConditions.consolariaMod, "Wishbone"),
                //Coralite
                Common.GetModItem(ModConditions.coraliteMod, "RedBerry"),
                //Edorbis
                Common.GetModItem(ModConditions.edorbisMod, "BiomechanicalMatter"),
                Common.GetModItem(ModConditions.edorbisMod, "CursedSoul"),
                Common.GetModItem(ModConditions.edorbisMod, "KelviniteRadar"),
                Common.GetModItem(ModConditions.edorbisMod, "SlayerTrophy"),
                Common.GetModItem(ModConditions.edorbisMod, "ThePrettiestFlower"),
                //Enchanted Moons
                Common.GetModItem(ModConditions.enchantedMoonsMod, "BlueMedallion"),
                Common.GetModItem(ModConditions.enchantedMoonsMod, "CherryAmulet"),
                Common.GetModItem(ModConditions.enchantedMoonsMod, "HarvestLantern"),
                Common.GetModItem(ModConditions.enchantedMoonsMod, "MintRing"),
                //Everjade
                Common.GetModItem(ModConditions.everjadeMod, "FestivalLantern"),
                //Excelsior
                Common.GetModItem(ModConditions.excelsiorMod, "ReflectiveIceShard"),
                Common.GetModItem(ModConditions.excelsiorMod, "PlanetaryTrackingDevice"),
                //Exxo Avalon Origins
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "BloodyAmulet"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "InfestedCarcass"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "DesertHorn"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "GoblinRetreatOrder"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "FalseTreasureMap"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "OddFertilizer"),
                //Gensokyo
                Common.GetModItem(ModConditions.gensokyoMod, "AliceMargatroidSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "CirnoSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "EternityLarvaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "HinaKagiyamaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "KaguyaHouraisanSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "LilyWhiteSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "MayumiJoutouguuSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "MedicineMelancholySpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "MinamitsuMurasaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "NazrinSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "NitoriKawashiroSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "RumiaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SakuyaIzayoiSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SeijaKijinSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SeiranSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SekibankiSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "TenshiHinanawiSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "ToyosatomimiNoMikoSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "UtsuhoReiujiSpawner"),
                //Homeward Journey
                Common.GetModItem(ModConditions.homewardJourneyMod, "CannedSoulofFlight"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "MetalSpine"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "SouthernPotting"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "SunlightCrown"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "UltimateTorch"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "UnstableGlobe"),
                //Martains Order
                Common.GetModItem(ModConditions.martainsOrderMod, "FrigidEgg"),
                Common.GetModItem(ModConditions.martainsOrderMod, "SuspiciousLookingCloud"),
                Common.GetModItem(ModConditions.martainsOrderMod, "Catnip"),
                Common.GetModItem(ModConditions.martainsOrderMod, "CarnageSuspiciousRazor"),
                Common.GetModItem(ModConditions.martainsOrderMod, "VoidWorm"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LuminiteSlimeCrown"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LuminiteEye"),
                Common.GetModItem(ModConditions.martainsOrderMod, "JunglesLastTreasure"),
                Common.GetModItem(ModConditions.martainsOrderMod, "TeslaRemote"),
                Common.GetModItem(ModConditions.martainsOrderMod, "BloodyNight"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LucidDay"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LucidFestival"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LucidNight"),
                //Medial Rift
                Common.GetModItem(ModConditions.medialRiftMod, "RemoteOfTheMetalHeads"),
                //Metroid Mod
                Common.GetModItem(ModConditions.metroidMod, "GoldenTorizoSummon"),
                Common.GetModItem(ModConditions.metroidMod, "KraidSummon"),
                Common.GetModItem(ModConditions.metroidMod, "NightmareSummon"),
                Common.GetModItem(ModConditions.metroidMod, "OmegaPirateSummon"),
                Common.GetModItem(ModConditions.metroidMod, "PhantoonSummon"),
                Common.GetModItem(ModConditions.metroidMod, "SerrisSummon"),
                Common.GetModItem(ModConditions.metroidMod, "TorizoSummon"),
                //Ophioid
                Common.GetModItem(ModConditions.ophioidMod, "DeadFungusbug"),
                Common.GetModItem(ModConditions.ophioidMod, "InfestedCompost"),
                Common.GetModItem(ModConditions.ophioidMod, "LivingCarrion"),
                //Qwerty
                Common.GetModItem(ModConditions.qwertyMod, "AncientEmblem"),
                Common.GetModItem(ModConditions.qwertyMod, "B4Summon"),
                Common.GetModItem(ModConditions.qwertyMod, "BladeBossSummon"),
                Common.GetModItem(ModConditions.qwertyMod, "DinoEgg"),
                //Common.GetModItem(ModConditions.qwertyMod, "FortressBossSummon"),
                //Common.GetModItem(ModConditions.qwertyMod, "GodSealKeycard"),
                Common.GetModItem(ModConditions.qwertyMod, "HydraSummon"),
                Common.GetModItem(ModConditions.qwertyMod, "RitualInterupter"),
                Common.GetModItem(ModConditions.qwertyMod, "SummoningRune"),
                //Redemption
                Common.GetModItem(ModConditions.redemptionMod, "EaglecrestSpelltome"),
                Common.GetModItem(ModConditions.redemptionMod, "EggCrown"),
                Common.GetModItem(ModConditions.redemptionMod, "FowlWarHorn"),
                //Secrets of the Shadows
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "ElectromagneticLure"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "SuspiciousLookingCandle"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "JarOfPeanuts"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "CatalystBomb"),
                //Shadows of Abaddon
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "PumpkinLantern"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "PrimordiaSummon"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "AbaddonSummon"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "SerpentSummon"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "SoranEmblem"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "HeirsAuthority"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "PigmanBanner"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "SandstormMedallion"),
                //Spirit
                Common.GetModItem(ModConditions.spiritMod, "DistressJellyItem"),
                Common.GetModItem(ModConditions.spiritMod, "GladeWreath"),
                Common.GetModItem(ModConditions.spiritMod, "ReachBossSummon"),
                Common.GetModItem(ModConditions.spiritMod, "JewelCrown"),
                Common.GetModItem(ModConditions.spiritMod, "BlackPearl"),
                Common.GetModItem(ModConditions.spiritMod, "BlueMoonSpawn"),
                Common.GetModItem(ModConditions.spiritMod, "DuskCrown"),
                Common.GetModItem(ModConditions.spiritMod, "CursedCloth"),
                Common.GetModItem(ModConditions.spiritMod, "StoneSkin"),
                Common.GetModItem(ModConditions.spiritMod, "MartianTransmitter"),
                //Spooky
                Common.GetModItem(ModConditions.spookyMod, "Fertilizer"),
                Common.GetModItem(ModConditions.spookyMod, "RottenSeed"),
                //Storms Additions
                Common.GetModItem(ModConditions.stormsAdditionsMod, "AridBossSummon"),
                Common.GetModItem(ModConditions.stormsAdditionsMod, "MoonlingSummoner"),
                Common.GetModItem(ModConditions.stormsAdditionsMod, "StormBossSummoner"),
                Common.GetModItem(ModConditions.stormsAdditionsMod, "UltimateBossSummoner"),
                //Supernova
                Common.GetModItem(ModConditions.supernovaMod, "BugOnAStick"),
                Common.GetModItem(ModConditions.supernovaMod, "EerieCrystal"),
                //Thorium
                Common.GetModItem(ModConditions.thoriumMod, "StormFlare"),
                Common.GetModItem(ModConditions.thoriumMod, "JellyfishResonator"),
                Common.GetModItem(ModConditions.thoriumMod, "UnstableCore"),
                Common.GetModItem(ModConditions.thoriumMod, "AncientBlade"),
                Common.GetModItem(ModConditions.thoriumMod, "StarCaller"),
                Common.GetModItem(ModConditions.thoriumMod, "StriderTear"),
                Common.GetModItem(ModConditions.thoriumMod, "VoidLens"),
                Common.GetModItem(ModConditions.thoriumMod, "AromaticBulb"),
                Common.GetModItem(ModConditions.thoriumMod, "AbyssalShadow2"),
                Common.GetModItem(ModConditions.thoriumMod, "DoomSayersCoin"),
                Common.GetModItem(ModConditions.thoriumMod, "FreshBrain"),
                Common.GetModItem(ModConditions.thoriumMod, "RottingSpore"),
                Common.GetModItem(ModConditions.thoriumMod, "IllusionaryGlass"),
                //Utric
                Common.GetModItem(ModConditions.uhtricMod, "RareGeode"),
                Common.GetModItem(ModConditions.uhtricMod, "SnowyCharcoal"),
                Common.GetModItem(ModConditions.uhtricMod, "CosmicLure"),
                //Universe of Swords
                Common.GetModItem(ModConditions.universeOfSwordsMod, "SwordBossSummon"),
                //Valhalla
                Common.GetModItem(ModConditions.valhallaMod, "HeavensSeal"),
                Common.GetModItem(ModConditions.valhallaMod, "HellishRadish"),
                //Vitality
                Common.GetModItem(ModConditions.vitalityMod, "CloudCore"),
                Common.GetModItem(ModConditions.vitalityMod, "AncientCrown"),
                Common.GetModItem(ModConditions.vitalityMod, "MultigemCluster"),
                Common.GetModItem(ModConditions.vitalityMod, "MoonlightLotusFlower"),
                Common.GetModItem(ModConditions.vitalityMod, "Dreadcandle"),
                Common.GetModItem(ModConditions.vitalityMod, "MeatyMushroom"),
                Common.GetModItem(ModConditions.vitalityMod, "AnarchyCrystal"),
                Common.GetModItem(ModConditions.vitalityMod, "TotemofChaos"),
                Common.GetModItem(ModConditions.vitalityMod, "MartianRadio"),
                Common.GetModItem(ModConditions.vitalityMod, "SpiritBox"),
                //Wayfair
                Common.GetModItem(ModConditions.wayfairContentMod, "MagicFertilizer"),
                //Zylon
                Common.GetModItem(ModConditions.zylonMod, "ForgottenFlame"),
                Common.GetModItem(ModConditions.zylonMod, "SlimyScepter")
            };
            ModdedBossAndEventSummons.UnionWith(TempModdedBossAndEventSummons);

            HashSet<int> TempFargosBossAndEventSummons = new()
            {
                //Fargos Mutant
                    //ABOMINATIONN NPC ITEMS
                Common.GetModItem(ModConditions.fargosMutantMod, "Anemometer"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BatteredClub"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BetsyEgg"),
                Common.GetModItem(ModConditions.fargosMutantMod, "FestiveOrnament"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ForbiddenScarab"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ForbiddenTome"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HeadofMan"),
                Common.GetModItem(ModConditions.fargosMutantMod, "IceKingsRemains"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MartianMemoryStick"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MatsuriLantern"),
                Common.GetModItem(ModConditions.fargosMutantMod, "NaughtyList"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PartyInvite"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PillarSummon"),
                Common.GetModItem(ModConditions.fargosMutantMod, "RunawayProbe"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SlimyBarometer"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SpentLantern"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SpookyBranch"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingScythe"),
                Common.GetModItem(ModConditions.fargosMutantMod, "WeatherBalloon"),
                    //DEVIANTT NPC ITEMS
                Common.GetModItem(ModConditions.fargosMutantMod, "AmalgamatedSkull"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AmalgamatedSpirit"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AthenianIdol"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AttractiveOre"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BloodSushiPlatter"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BloodUrchin"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CloudSnack"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ClownLicense"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CoreoftheFrostCore"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CorruptChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CrimsonChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DemonicPlushie"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DilutedRainbowMatter"),
                Common.GetModItem(ModConditions.fargosMutantMod, "Eggplant"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ForbiddenForbiddenFragment"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GnomeHat"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GoblinScrap"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GoldenSlimeCrown"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GrandCross"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HallowChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HeartChocolate"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HemoclawCrab"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HolyGrail"),
                Common.GetModItem(ModConditions.fargosMutantMod, "JungleChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "LeesHeadband"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MothLamp"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MothronEgg"),
                Common.GetModItem(ModConditions.fargosMutantMod, "Pincushion"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PinkSlimeCrown"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PirateFlag"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PlunderedBooty"),
                Common.GetModItem(ModConditions.fargosMutantMod, "RuneOrb"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ShadowflameIcon"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SlimyLockBox"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingLure"),
                Common.GetModItem(ModConditions.fargosMutantMod, "WormSnack"),
                    //MUTANT NPC ITEMS
                Common.GetModItem(ModConditions.fargosMutantMod, "Abeemination2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AncientSeal"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CelestialSigil2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CultistSummon"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DeathBringerFairy"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DeerThing2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "FleshyDoll"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GoreySpine"),
                Common.GetModItem(ModConditions.fargosMutantMod, "JellyCrystal"),
                Common.GetModItem(ModConditions.fargosMutantMod, "LihzahrdPowerCell2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechanicalAmalgam"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechEye"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechSkull"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechWorm"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MutantVoodoo"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PlanterasFruit"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PrismaticPrimrose"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SlimyCrown"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousEye"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousSkull"),
                Common.GetModItem(ModConditions.fargosMutantMod, "TruffleWorm2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "WormyFood"),
                //Fargos Souls
                Common.GetModItem(ModConditions.fargosSoulsMod, "AbomsCurse"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "ChampionySigil"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "CoffinSummon"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "DevisCurse"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "FragilePixieLamp"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "MechLure"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsCurse"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "SquirrelCoatofArms"),
                //Fargos DLC
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "AbandonedRemote"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ABombInMyNation"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "AstrumCor"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "BirbPheromones"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "BlightedEye"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "BloodyWorm"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ChunkyStardust"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ClamPearl"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ColossalTentacle"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "CryingKey"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DeepseaProteinShake"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DefiledCore"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DefiledShard"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DragonEgg"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "EyeofExtinction"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "FriedDoll"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "HiveTumor"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "LetterofKos"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "MaulerSkull"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "MedallionoftheDesert"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "MurkySludge"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "NoisyWhistle"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "NuclearChunk"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "OphiocordycipitaceaeSprout"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "PlaguedWalkieTalkie"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "PolterplasmicBeacon"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "PortableCodebreaker"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "QuakeIdol"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "RedStainedWormFood"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "RiftofKos"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SeeFood"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SirensPearl"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SomeKindofSpaceWorm"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "StormIdol"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SulphurBearTrap"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "WormFoodofKos"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "WyrmTablet"),
                //Fargos Extras
                Common.GetModItem(ModConditions.fargosSoulsExtrasMod, "PandorasBox")
            };
            FargosBossAndEventSummons.UnionWith(TempFargosBossAndEventSummons);

            HashSet<int> ModPrefixes = new()
            {
                GetModPrefix(ModConditions.calamityMod, "Flawless"),
                GetModPrefix(ModConditions.calamityMod, "Silent"),
                GetModPrefix(ModConditions.clickerClassMod, "Elite"),
                GetModPrefix(ModConditions.clickerClassMod, "ClickerRadius"),
                GetModPrefix(ModConditions.martainsOrderMod, "StrikerPrefix"),
                GetModPrefix(ModConditions.orchidMod, "EmpyreanPrefix"),
                GetModPrefix(ModConditions.orchidMod, "EtherealPrefix"),
                GetModPrefix(ModConditions.orchidMod, "BlockingPrefix"),
                GetModPrefix(ModConditions.orchidMod, "BrewingPrefix"),
                GetModPrefix(ModConditions.orchidMod, "LoadedPrefix"),
                GetModPrefix(ModConditions.orchidMod, "SpiritualPrefix"),
                GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omnipotent"),
                GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omniscient"),
                GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Soulbound"),
                GetModPrefix(ModConditions.thoriumMod, "Fabled"),
                GetModPrefix(ModConditions.thoriumMod, "Engrossing"),
                GetModPrefix(ModConditions.thoriumMod, "Lucrative"),
                GetModPrefix(ModConditions.vitalityMod, "MalevolentPrefix"),
                GetModPrefix(ModConditions.vitalityMod, "RelentlessPrefix")
            };
            Prefixes.UnionWith(ModPrefixes);

            HashSet<int> ModIgnoredTiles = new()
            {
                GetModTile(ModConditions.aequusMod, "Manacle"),
                GetModTile(ModConditions.aequusMod, "Mistral"),
                GetModTile(ModConditions.aequusMod, "Moonflower"),
                GetModTile(ModConditions.aequusMod, "Moray"),
                GetModTile(ModConditions.thoriumMod, "IllumiteChunk"),
                GetModTile(ModConditions.thoriumMod, "LifeQuartz"),
                GetModTile(ModConditions.thoriumMod, "LodeStone"),
                GetModTile(ModConditions.thoriumMod, "SmoothCoal"),
                GetModTile(ModConditions.thoriumMod, "ThoriumOre"),
                GetModTile(ModConditions.thoriumMod, "ValadiumChunk")
            };
            IgnoredTilesForExplosives.UnionWith(ModIgnoredTiles);

            HashSet<Mod> TempIgnoredModsForExplosives = new();
            if (ModConditions.confectionRebakedLoaded)
                TempIgnoredModsForExplosives.Add(ModConditions.confectionRebakedMod);
            if (ModConditions.depthsLoaded)
                TempIgnoredModsForExplosives.Add(ModConditions.depthsMod);
            if (ModConditions.infectedQualitiesLoaded)
                TempIgnoredModsForExplosives.Add(ModConditions.infectedQualitiesMod);
            if (ModConditions.martainsOrderLoaded)
                TempIgnoredModsForExplosives.Add(ModConditions.martainsOrderMod);
            if (ModConditions.orchidLoaded)
                TempIgnoredModsForExplosives.Add(ModConditions.orchidMod);
            if (ModConditions.remnantsLoaded)
                TempIgnoredModsForExplosives.Add(ModConditions.remnantsMod);
            IgnoredModsForExplosives.UnionWith(TempIgnoredModsForExplosives);

            HashSet<int> ModIgnoredPermanentBuffs = new()
            {
                Common.GetModBuff(ModConditions.calamityMod, "ChaosCandleBuff"),
                Common.GetModBuff(ModConditions.calamityMod, "CirrusBlueCandleBuff"),
                Common.GetModBuff(ModConditions.calamityMod, "CirrusPinkCandleBuff"),
                Common.GetModBuff(ModConditions.calamityMod, "CirrusPurpleCandleBuff"),
                Common.GetModBuff(ModConditions.calamityMod, "CirrusYellowCandleBuff"),
                Common.GetModBuff(ModConditions.calamityMod, "TranquilityCandleBuff"),
            };
            IgnoredPermanentBuffs.UnionWith(ModIgnoredPermanentBuffs);

            for (int i = BuffID.Count; i < BuffLoader.BuffCount; i++)
            {
                if (BuffID.Sets.IsAFlaskBuff[BuffLoader.GetBuff(i).Type] && !Common.FlaskBuffs.Contains(BuffLoader.GetBuff(i).Type))
                    Common.FlaskBuffs.Add(BuffLoader.GetBuff(i).Type);
            }

            if (ModConditions.thoriumLoaded)
            {
                HashSet<int> TempThoriumCoatings = new()
                {
                    Common.GetModBuff(ModConditions.thoriumMod, "DeepFreezeCoatingBuff"),
                    Common.GetModBuff(ModConditions.thoriumMod, "ExplosiveCoatingBuff"),
                    Common.GetModBuff(ModConditions.thoriumMod, "GorgonCoatingBuff"),
                    Common.GetModBuff(ModConditions.thoriumMod, "SporeCoatingBuff"),
                    Common.GetModBuff(ModConditions.thoriumMod, "ToxicCoatingBuff"),
                };
                ThoriumCoatings.UnionWith(TempThoriumCoatings);
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

        public static bool IsCoin(int type)
        {
            return type is >= 71 and <= 74;
        }

        public static ulong CalculateCoinValue(int type, uint stack)
        {
            return type switch
            {
                ItemID.CopperCoin => stack * CopperValue,
                ItemID.SilverCoin => stack * SilverValue,
                ItemID.GoldCoin => stack * GoldValue,
                ItemID.PlatinumCoin => stack * PlatinumValue,
                _ => 0,
            };
        }

        public static List<Item> ConvertCopperValueToCoins(ulong value)
        {
            (ulong plat, ulong plat_rem) = Math.DivRem(value, PlatinumValue);
            (ulong gold, ulong gold_rem) = Math.DivRem(plat_rem, GoldValue);
            (ulong silver, ulong copper) = Math.DivRem(gold_rem, SilverValue);

            var toReturn = new List<Item>();

            while (plat > 0)
            {
                toReturn.Add(new Item(ItemID.PlatinumCoin, Math.Min((int)plat, PlatinumMaxStack)));
                plat -= Math.Min(plat, (ulong)PlatinumMaxStack);
            }

            toReturn.Add(new Item(ItemID.GoldCoin, (int)gold));
            toReturn.Add(new Item(ItemID.SilverCoin, (int)silver));
            toReturn.Add(new Item(ItemID.CopperCoin, (int)copper));

            return toReturn;
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
            return DamageClass.Default;
        }

        public static string ModBuffAsset(Mod mod, int buffType)
        {
            if (mod != null && BuffLoader.GetBuff(buffType) != null)
                return BuffLoader.GetBuff(buffType).Texture;
            return "QoLCompendium/Assets/Items/PermanentBuff";
        }

        public static void CreateBagRecipe(int[] items, int bagID)
        {
            for (int i = 0; i < items.Length; i++)
            {
                CreateSimpleRecipe(bagID, items[i], TileID.WorkBenches, 1, 1, true, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.BossBags", () => QoLCompendium.mainConfig.BossBagRecipes));
            }
        }

        public static void CreateCrateRecipe(int result, int crateID, int crateHardmodeID, int crateCount, params Condition[] conditions)
        {
            Recipe recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainConfig.CrateRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainConfig.CrateRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void CreateCrateHardmodeRecipe(int result, int crateHardmodeID, int crateCount, params Condition[] conditions)
        {
            Recipe recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainConfig.CrateRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void CreateCrateWithKeyRecipe(int item, int crateID, int crateHardmodeID, int crateCount, int keyID, params Condition[] conditions)
        {
            Recipe recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainConfig.CrateRecipes, item, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateID, crateCount);
            recipe.AddIngredient(keyID);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainConfig.CrateRecipes, item, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            recipe.AddIngredient(keyID);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void ConversionRecipe(int item1, int item2, int station)
        {
            //Item 1 -> Item 2
            CreateSimpleRecipe(item1, item2, station, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions));

            //Item 2 -> Item 1
            CreateSimpleRecipe(item2, item1, station, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions));
        }

        public static void AddBannerGroupToItemRecipe(int recipeGroupID, int resultID, int resultAmount = 1, int groupAmount = 1, params Condition[] conditions)
        {
            CreateSimpleRecipe(recipeGroupID, resultID, TileID.WorkBenches, groupAmount, resultAmount, disableDecraft: true, usesRecipeGroup: true, conditions);
        }

        public static void AddBannerToItemRecipe(int bannerItemID, int resultID, int bannerAmount = 1, int resultAmount = 1, params Condition[] conditions)
        {
            CreateSimpleRecipe(bannerItemID, resultID, TileID.WorkBenches, bannerAmount, resultAmount, disableDecraft: true, usesRecipeGroup: false, conditions);
        }

        public static void AddBannerSetToItemRecipe(bool[] set, int resultID)
        {
            for (int i = 0; i < NPCID.Count; i++)
            {
                if (set[i])
                {
                    int num = Item.NPCtoBanner(i);
                    if (num > 0)
                        CreateSimpleRecipe(Item.BannerToItem(num), resultID, TileID.WorkBenches, 1, 1, true, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
                }
            }
        }

        public static void CreateSimpleRecipe(int ingredientID, int resultID, int tileID, int ingredientAmount = 1, int resultAmount = 1, bool disableDecraft = false, bool usesRecipeGroup = false, params Condition[] conditions)
        {
            Recipe recipe = Recipe.Create(resultID, resultAmount);
            if (usesRecipeGroup)
                recipe.AddRecipeGroup(ingredientID, ingredientAmount);
            else
                recipe.AddIngredient(ingredientID, ingredientAmount);
            recipe.AddTile(tileID);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            if (disableDecraft)
                recipe.DisableDecraft();
            recipe.Register();
        }

        public static void SpawnBoss(Player player, int bossType)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;
                int npc = NPC.NewNPC(NPC.GetBossSpawnSource(Main.myPlayer), (int)spawnPosition.X, (int)spawnPosition.Y, bossType);
                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: bossType);
                if (npc != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc);
            }
        }

        public static Asset<Texture2D> GetAsset(string location, string filename, int fileNumber = -1)
        {
            if (fileNumber > -1)
                return ModContent.Request<Texture2D>("QoLCompendium/Assets/" + location + "/" + filename + fileNumber);
            else
                return ModContent.Request<Texture2D>("QoLCompendium/Assets/" + location + "/" + filename);
        }

        public static void TransmuteItems(int[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (i >= items.Length - 1)
                    ItemID.Sets.ShimmerTransformToItem[items.Last()] = items.First();
                else
                    ItemID.Sets.ShimmerTransformToItem[items[i]] = items[i + 1];
            }
        }

        public static bool CheckToActivateGlintEffect(Item item)
        {
            if (Main.gameMenu || !Main.LocalPlayer.active)
                return false;

            if (QoLCompendium.mainConfig.ActiveBuffsHaveEnchantedEffects && !item.IsAir && Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeBuffItems.Contains(item.type))
                return true;
            else if (QoLCompendium.mainConfig.GoodPrefixesHaveEnchantedEffects && !item.IsAir && Prefixes.Contains(item.prefix))
                return true;

            return false;
        }

        public static int GetSlotItemIsIn(Item lookForThis, Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].type == lookForThis.type)
                    return i;
            }
            return -1;
        }

        public static void SetDefaultsToPermanentBuff(Item item)
        {
            item.width = item.height = 16;
            item.consumable = false;
            item.maxStack = 1;
            item.SetShopValues(ItemRarityColor.Blue1, 0);
        }

        public static void HandleFlaskBuffs(Player player)
        {
            foreach (int buff in FlaskBuffs)
                player.buffImmune[buff] = true;
        }

        public static void HandleCoatingBuffs(Player player)
        {
            foreach (int buff in ThoriumCoatings)
                player.buffImmune[buff] = true;
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


        public static Point16 PlayerCenterTile(Player player)
        {
            return new Point16((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f));
        }

        public static int PlayerCenterTileX(Player player)
        {
            return (int)(player.Center.X / 16f);
        }

        public static int PlayerCenterTileY(Player player)
        {
            return (int)(player.Center.Y / 16f);
        }

        public static bool InGameWorldLeft(int x)
        {
            return x > 39;
        }

        public static bool InGameWorldRight(int x)
        {
            return x < Main.maxTilesX - 39;
        }

        public static bool InGameWorldTop(int y)
        {
            return y > 39;
        }

        public static bool InGameWorldBottom(int y)
        {
            return y < Main.maxTilesY - 39;
        }

        public static bool InGameWorld(int x, int y)
        {
            return x > 39 && x < Main.maxTilesX - 39 && y > 39 && y < Main.maxTilesY - 39;
        }

        public static bool InWorldLeft(int x)
        {
            return x >= 0;
        }

        public static bool InWorldRight(int x)
        {
            return x < Main.maxTilesX;
        }

        public static bool InWorldTop(int y)
        {
            return y >= 0;
        }

        public static bool InWorldBottom(int y)
        {
            return y < Main.maxTilesY;
        }

        public static bool InWorld(int x, int y)
        {
            return x >= 0 && x < Main.maxTilesX && y >= 0 && y < Main.maxTilesY;
        }

        public static int CoordsX(int x)
        {
            return x * 2 - Main.maxTilesX;
        }

        public static int CoordsY(int y)
        {
            return y * 2 - (int)Main.worldSurface * 2;
        }

        public static string CoordsString(int x, int y)
        {
            x = x * 2 - Main.maxTilesX;
            y = y * 2 - (int)Main.worldSurface * 2;
            string text = x < 0 ? " west, " : " east, ";
            string text2 = y < 0 ? " surface." : " underground.";
            x = x < 0 ? x * -1 : x;
            y = y < 0 ? y * -1 : y;
            return x.ToString() + text + y.ToString() + text2;
        }

        public static void TileSafe(int x, int y)
        {
            if (x < 0 || y < 0 || x > Main.ActiveWorldFileData.WorldSizeX || y > Main.ActiveWorldFileData.WorldSizeY)
            {
                return;
            }
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y].ResetToType(0);
            }
        }

        public static bool TileNull(int x, int y)
        {
            return Main.tile[x, y] == null;
        }

        public static bool SolidTile(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return !TileNull(x, y) && tile.HasTile && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType] && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid && !tile.IsActuated;
        }

        public static bool SearchBelow(Player player, Func<int, int, bool> toSearch, int gap)
        {
            int centerX = PlayerCenterTileX(player);
            int centerY = PlayerCenterTileY(player);
            int num3 = 0;
            while (InGameWorldLeft(centerX - num3) || InGameWorldRight(centerX + num3))
            {
                int tempY = centerY;
                while (InGameWorldBottom(tempY))
                {
                    int nX = centerX - num3;
                    int pX = centerX + num3;
                    if (InGameWorldLeft(nX))
                    {
                        TileSafe(nX, tempY);
                        if (toSearch.Invoke(nX, tempY))
                        {
                            return true;
                        }
                    }
                    if (InGameWorldRight(pX))
                    {
                        TileSafe(pX, tempY);
                        if (toSearch.Invoke(pX, tempY))
                        {
                            return true;
                        }
                    }
                    tempY += gap;
                }
                num3 += gap;
            }
            return false;
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
                if (!QoLCompendium.mainConfig.VeinMinerTileWhitelist.Contains(name))
                {
                    QoLCompendium.mainConfig.VeinMinerTileWhitelist.Add(name);
                    SaveConfig(QoLCompendium.mainConfig);
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
                        QoLCompendium.mainConfig.VeinMinerTileWhitelist.Add(name);
                        SaveConfig(QoLCompendium.mainConfig);
                    }
                }
            }
            else
            {
                if (QoLCompendium.mainConfig.VeinMinerTileWhitelist.Contains(name))
                {
                    QoLCompendium.mainConfig.VeinMinerTileWhitelist.Remove(name);
                    SaveConfig(QoLCompendium.mainConfig);
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
