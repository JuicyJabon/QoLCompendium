using MonoMod.RuntimeDetour;
using QoLCompendium.Content.Items.Accessories.Construction;
using QoLCompendium.Content.Items.Accessories.Fishing;
using QoLCompendium.Content.Items.Accessories.Informational;
using QoLCompendium.Content.Items.Tools.Mirrors;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod.HomewardJourney;
using QoLCompendium.Content.Items.Tools.Summons.CrossMod.Thorium;
using QoLCompendium.Content.Items.Tools.Summons.Vanilla;
using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Content.Tiles.Other;
using QoLCompendium.Core.Changes.ModChanges.ModItemChanges;
using QoLCompendium.Core.PermanentBuffSystems;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Events;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core
{
    public static class Common
    {
#pragma warning disable CA2211, IDE0028, IDE0300

        public static readonly BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;

        public static List<Hook> detours = [];

        #region Boss Summons
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
        #endregion

        #region Tiles & Walls
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

        public static readonly HashSet<int> SnowBiomeBlocks = [ItemID.SnowBlock, ItemID.SnowBrick, ItemID.IceBlock, ItemID.PinkIceBlock, ItemID.PurpleIceBlock, ItemID.RedIceBlock];

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

        public static readonly HashSet<int> GraveStones = [ItemID.Tombstone, ItemID.GraveMarker, ItemID.CrossGraveMarker, ItemID.Headstone, ItemID.Gravestone, ItemID.Obelisk, ItemID.RichGravestone1, ItemID.RichGravestone2, ItemID.RichGravestone3, ItemID.RichGravestone4, ItemID.RichGravestone5];

        public static HashSet<int> IgnoredTilesForExplosives = new()
        {
            ModContent.TileType<AsphaltPlatformTile>()
        };

        public static HashSet<Mod> IgnoredModsForExplosives = new();
        #endregion

        #region Potions & Upgrades
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

        public static HashSet<int> PermanentUpgrades = new()
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

        public static HashSet<int> PermanentMultiUseUpgrades = new()
        {
            ItemID.LifeCrystal,
            ItemID.ManaCrystal,
            ItemID.LifeFruit
        };

        public static HashSet<int> PowerUpItems = new()
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
        #endregion

        #region Items
        public static HashSet<int> Emblems = new()
        {
            ItemID.WarriorEmblem,
            ItemID.RangerEmblem,
            ItemID.SorcererEmblem,
            ItemID.SummonerEmblem
        };

        public static readonly HashSet<int> MobileStorages = new()
        {
            ProjectileID.FlyingPiggyBank,
            ProjectileID.VoidLens,
            ModContent.ProjectileType<FlyingSafeProjectile>(),
            ModContent.ProjectileType<EtherianConstructProjectile>()
        };

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
            ItemID.CordageGuide,
            ItemID.DontHurtCrittersBook,
            ItemID.DontHurtNatureBook,
            ItemID.DontHurtComboBook,
            ItemID.ShimmerCloak,
            ItemID.DontStarveShaderItem,
            ItemID.EncumberingStone,
            ItemID.PortableStool
        };

        public static HashSet<DamageClass> VoidDamageClasses = new();
        #endregion

        #region Coins
        public static readonly HashSet<int> CoinIDs = new() { ItemID.CopperCoin, ItemID.SilverCoin, ItemID.GoldCoin, ItemID.PlatinumCoin };
        public static int PlatinumMaxStack = 9999;
        public const ulong CopperValue = 1;
        public const ulong SilverValue = 100;
        public const ulong GoldValue = 100 * 100;
        public const ulong PlatinumValue = 100 * 100 * 100;
        #endregion

        #region Boss Drops & IDs
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

        public static bool[] DownedVanillaBosses = new bool[]
        {
            NPC.downedSlimeKing,
            NPC.downedBoss1,
            NPC.downedBoss2,
            NPC.downedQueenBee,
            NPC.downedBoss3,
            NPC.downedDeerclops,
            Main.hardMode,
            NPC.downedMechBoss1,
            NPC.downedMechBoss2,
            NPC.downedMechBoss3,
            NPC.downedPlantBoss,
            NPC.downedGolemBoss,
            NPC.downedEmpressOfLight,
            NPC.downedFishron,
            NPC.downedAncientCultist,
            NPC.downedMoonlord
        };
        
        public static readonly HashSet<int> LunarPillarIDs = new() { NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerStardust, NPCID.LunarTowerVortex };

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

        #region Critters & Friendlies
        public static readonly bool[] NormalBunnies = NPCID.Sets.Factory.CreateBoolSet(NPCID.Bunny, NPCID.GemBunnyTopaz, NPCID.GemBunnySapphire, NPCID.GemBunnyRuby, NPCID.GemBunnyEmerald, NPCID.GemBunnyDiamond, NPCID.GemBunnyAmethyst, NPCID.GemBunnyAmber, NPCID.ExplosiveBunny, NPCID.BunnySlimed, NPCID.BunnyXmas, NPCID.CorruptBunny, NPCID.CrimsonBunny, NPCID.PartyBunny);

        public static readonly bool[] NormalSquirrels = NPCID.Sets.Factory.CreateBoolSet(NPCID.Squirrel, NPCID.SquirrelRed, NPCID.GemSquirrelTopaz, NPCID.GemSquirrelSapphire, NPCID.GemSquirrelRuby, NPCID.GemSquirrelEmerald, NPCID.GemSquirrelDiamond, NPCID.GemSquirrelAmethyst, NPCID.GemSquirrelAmber);

        public static readonly bool[] NormalButterflies = NPCID.Sets.Factory.CreateBoolSet(NPCID.Butterfly, NPCID.HellButterfly, NPCID.EmpressButterfly);

        public static readonly bool[] NormalBirds = NPCID.Sets.Factory.CreateBoolSet(NPCID.Bird, NPCID.BirdBlue, NPCID.BirdRed);

        public static readonly HashSet<int> TownSlimeIDs = new(Enumerable.Range(678, 688 - 678)) { 670 };
        #endregion

        #region Banners
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
        #endregion

        #region Buffs

        public static Dictionary<int, BuffEffect> AllEffects = new();

        public enum EffectTypes
        {
            Potion,
            Candy,
            Repellent,
            Arena,
            Station,
            Flask,
            Coating,
            Alcohol,
            StrangePotion
        };

        #endregion

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

        public enum AlchemyHerbStyles
        {
            Daybloom,
            Moonglow,
            Blinkroot,
            Deathweed,
            Waterleaf,
            Fireblossom,
            Shiverthorn
        }

        public static void UnloadTasks()
        {
            foreach (var hook in detours)
                hook.Undo();
        }

        public static void PostSetupTasks()
        {
            HashSet<int> ModPowerUpItems = new()
            {
                GetModItem(ModConditions.orchidMod, "Chip"),
                GetModItem(ModConditions.orchidMod, "Guard"),
                GetModItem(ModConditions.orchidMod, "Potency"),
                GetModItem(ModConditions.thoriumMod, "InspirationNote"),
                GetModItem(ModConditions.thoriumMod, "InspirationNoteStatue"),
                GetModItem(ModConditions.thoriumMod, "InspirationNoteNoble"),
                GetModItem(ModConditions.thoriumMod, "InspirationNoteRhapsodist"),
                GetModItem(ModConditions.thoriumMod, "MeatSlab"),
                GetModItem(ModConditions.thoriumMod, "GreatFlesh"),
                GetModItem(ModConditions.vitalityMod, "BloodClot"),
            };
            PowerUpItems.UnionWith(ModPowerUpItems);

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
                ModContent.ItemType<DuplicationBobber>(),
                ModContent.ItemType<AnglersDream>(),
                GetModItem(ModConditions.aequusMod, "AnglerBroadcaster"),
                GetModItem(ModConditions.aequusMod, "Calendar"),
                GetModItem(ModConditions.aequusMod, "GeigerCounter"),
                GetModItem(ModConditions.aequusMod, "HoloLens"),
                GetModItem(ModConditions.aequusMod, "RichMansMonocle"),
                GetModItem(ModConditions.aequusMod, "DevilsTongue"),
                GetModItem(ModConditions.aequusMod, "NeonGenesis"),
                GetModItem(ModConditions.aequusMod, "RadonFishingBobber"),
                GetModItem(ModConditions.aequusMod, "Ramishroom"),
                GetModItem(ModConditions.aequusMod, "RegrowingBait"),
                GetModItem(ModConditions.aequusMod, "LavaproofMitten"),
                GetModItem(ModConditions.aequusMod, "BusinessCard"),
                GetModItem(ModConditions.aequusMod, "HaltingMachine"),
                GetModItem(ModConditions.aequusMod, "HaltingMagnet"),
                GetModItem(ModConditions.aequusMod, "HyperJet"),
                GetModItem(ModConditions.afkpetsMod, "FishermansPride"),
                GetModItem(ModConditions.afkpetsMod, "LampyridaeHairpin"),
                GetModItem(ModConditions.afkpetsMod, "Piracy"),
                GetModItem(ModConditions.afkpetsMod, "PortableSonar"),
                GetModItem(ModConditions.afkpetsMod, "TheHandyman"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "AttendanceLog"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "BiomeCrystal"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "EngiRegistry"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "FortuneMirror"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "HitMarker"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "Magimeter"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "RSH"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "SafteyScanner"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "ScryingMirror"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "ThreatAnalyzer"),
                GetModItem(ModConditions.blocksInfoAccessoriesMod, "WantedPoster"),
                GetModItem(ModConditions.calamityMod, "AlluringBait"),
                GetModItem(ModConditions.calamityMod, "EnchantedPearl"),
                GetModItem(ModConditions.calamityMod, "SupremeBaitTackleBoxFishingStation"),
                GetModItem(ModConditions.calamityMod, "AncientFossil"),
                GetModItem(ModConditions.calamityMod, "OceanCrest"),
                GetModItem(ModConditions.calamityMod, "SpelunkersAmulet"),
                GetModItem(ModConditions.clickerClassMod, "ButtonMasher"),
                GetModItem(ModConditions.depthsMod, "LodeStone"),
                GetModItem(ModConditions.depthsMod, "MercuryMossFishingBobber"),
                GetModItem(ModConditions.depthsMod, "QuicksilverproofFishingHook"),
                GetModItem(ModConditions.depthsMod, "QuicksilverproofTackleBag"),
                GetModItem(ModConditions.homewardJourneyMod, "GoblinVoodooDoll"),
                GetModItem(ModConditions.homewardJourneyMod, "NerveFibre"),
                GetModItem(ModConditions.homewardJourneyMod, "Squidfood"),
                GetModItem(ModConditions.luiAFKMod, "FasterMining"),
                GetModItem(ModConditions.luiAFKMod, "SuperToolTime"),
                GetModItem(ModConditions.luiAFKMod, "ToolTime"),
                GetModItem(ModConditions.luiAFKDLCMod, "ArchitectHeavyEquipment"),
                GetModItem(ModConditions.luiAFKDLCMod, "EnchantedSupremeFishingBundle"),
                GetModItem(ModConditions.martainsOrderMod, "ArmorDisplayer"),
                GetModItem(ModConditions.martainsOrderMod, "FlightTimer"),
                GetModItem(ModConditions.martainsOrderMod, "Journal"),
                GetModItem(ModConditions.martainsOrderMod, "IronWatch"),
                GetModItem(ModConditions.martainsOrderMod, "LeadWatch"),
                GetModItem(ModConditions.martainsOrderMod, "LeprechaunSensor"),
                GetModItem(ModConditions.martainsOrderMod, "MinionCounter"),
                GetModItem(ModConditions.martainsOrderMod, "SentryCounter"),
                GetModItem(ModConditions.martainsOrderMod, "SummonersTracker"),
                GetModItem(ModConditions.martainsOrderMod, "SurvivalTracker"),
                //Common.GetModItem(ModConditions.moomoosUltimateYoyoRevampMod, "HitDisplay"),
                //Common.GetModItem(ModConditions.moomoosUltimateYoyoRevampMod, "SpeedDisplay"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "AnomalyLocator"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "ArchaeologistToolbelt"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "ElectromagneticDeterrent"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "GoldenTrowel"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "InfiniteVoid"),
                GetModItem(ModConditions.spiritClassicMod, "FisheyeGem"),
                GetModItem(ModConditions.spiritClassicMod, "MetalBand"),
                GetModItem(ModConditions.spiritClassicMod, "MimicRepellent"),
                GetModItem(ModConditions.thoriumMod, "HeartRateMonitor"),
                GetModItem(ModConditions.thoriumMod, "HightechSonarDevice"),
                GetModItem(ModConditions.thoriumMod, "GlitteringChalice"),
                GetModItem(ModConditions.thoriumMod, "GreedyGoblet"),
                GetModItem(ModConditions.thoriumMod, "LuckyRabbitsFoot"),
                GetModItem(ModConditions.thoriumMod, "GuidetoOvercomingGrief"),
                GetModItem(ModConditions.vitalityMod, "ShimmerFishingHook")
            };
            BankItems.UnionWith(ModBankItems);

            HashSet<int> TempModdedBossAndEventSummons = new()
            {
                //QoLC Vanilla
                ModContent.ItemType<CultistSummon>(),
                ModContent.ItemType<DukeFishronSummon>(),
                ModContent.ItemType<EmpressOfLightSummon>(),
                ModContent.ItemType<PlanteraSummon>(),
                ModContent.ItemType<SkeletronSummon>(),
                ModContent.ItemType<WallOfFleshSummon>(),
                //QoLC Calamity
                ModContent.ItemType<CragmawMireSummon>(),
                ModContent.ItemType<EidolonWyrmSummon>(),
                ModContent.ItemType<GiantClamSummon>(),
                ModContent.ItemType<GiantSquidSummon>(),
                ModContent.ItemType<LeviathanAnahitaSummon>(),
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
                //QoLC Thorium
                ModContent.ItemType<ForgottenOneSummon>(),
                //Aequus
                GetModItem(ModConditions.aequusMod, "GalacticStarfruit"),
                //AFKPETS
                GetModItem(ModConditions.afkpetsMod, "AncientSand"),
                GetModItem(ModConditions.afkpetsMod, "BlackenedHeart"),
                GetModItem(ModConditions.afkpetsMod, "BrokenDelftPlate"),
                GetModItem(ModConditions.afkpetsMod, "CookingBook"),
                GetModItem(ModConditions.afkpetsMod, "CorruptedServer"),
                GetModItem(ModConditions.afkpetsMod, "DemonicAnalysis"),
                GetModItem(ModConditions.afkpetsMod, "DesertMirror"),
                GetModItem(ModConditions.afkpetsMod, "DuckWhistle"),
                GetModItem(ModConditions.afkpetsMod, "FallingSlimeReplica"),
                GetModItem(ModConditions.afkpetsMod, "FrozenSkull"),
                GetModItem(ModConditions.afkpetsMod, "GoldenKingSlimeIdol"),
                GetModItem(ModConditions.afkpetsMod, "GoldenSkull"),
                GetModItem(ModConditions.afkpetsMod, "HaniwaIdol"),
                GetModItem(ModConditions.afkpetsMod, "HolographicSlimeReplica"),
                GetModItem(ModConditions.afkpetsMod, "IceBossCrystal"),
                GetModItem(ModConditions.afkpetsMod, "MagicWand"),
                GetModItem(ModConditions.afkpetsMod, "NightmareFuel"),
                GetModItem(ModConditions.afkpetsMod, "PinkDiamond"),
                GetModItem(ModConditions.afkpetsMod, "PlantAshContainer"),
                GetModItem(ModConditions.afkpetsMod, "PreyTrackingChip"),
                GetModItem(ModConditions.afkpetsMod, "RoastChickenPlate"),
                GetModItem(ModConditions.afkpetsMod, "SeveredClothierHead"),
                GetModItem(ModConditions.afkpetsMod, "SeveredDryadHead"),
                GetModItem(ModConditions.afkpetsMod, "SeveredHarpyHead"),
                GetModItem(ModConditions.afkpetsMod, "ShogunSlimesHelmet"),
                GetModItem(ModConditions.afkpetsMod, "SlimeinaGlassCube"),
                GetModItem(ModConditions.afkpetsMod, "SlimyWarBanner"),
                GetModItem(ModConditions.afkpetsMod, "SoulofAgonyinaBottle"),
                GetModItem(ModConditions.afkpetsMod, "SpineWormFood"),
                GetModItem(ModConditions.afkpetsMod, "SpiritofFunPot"),
                GetModItem(ModConditions.afkpetsMod, "SpiritualHeart"),
                GetModItem(ModConditions.afkpetsMod, "StoryBook"),
                GetModItem(ModConditions.afkpetsMod, "SuspiciousLookingChest"),
                GetModItem(ModConditions.afkpetsMod, "SwissChocolate"),
                GetModItem(ModConditions.afkpetsMod, "TiedBunny"),
                GetModItem(ModConditions.afkpetsMod, "TinyMeatIdol"),
                GetModItem(ModConditions.afkpetsMod, "TradeDeal"),
                GetModItem(ModConditions.afkpetsMod, "UnstableRainbowCookie"),
                GetModItem(ModConditions.afkpetsMod, "UntoldBurial"),
                //Awful Garbage
                GetModItem(ModConditions.awfulGarbageMod, "InsectOnAStick"),
                GetModItem(ModConditions.awfulGarbageMod, "PileOfFakeBones"),
                //Blocks Core Boss
                GetModItem(ModConditions.blocksCoreBossMod, "ChargedOrb"),
                GetModItem(ModConditions.blocksCoreBossMod, "ChargedOrbCrim"),
                //Consolaria
                GetModItem(ModConditions.consolariaMod, "SuspiciousLookingEgg"),
                GetModItem(ModConditions.consolariaMod, "CursedStuffing"),
                GetModItem(ModConditions.consolariaMod, "SuspiciousLookingSkull"),
                GetModItem(ModConditions.consolariaMod, "Wishbone"),
                //Coralite
                GetModItem(ModConditions.coraliteMod, "RedBerry"),
                //Edorbis
                GetModItem(ModConditions.edorbisMod, "BiomechanicalMatter"),
                GetModItem(ModConditions.edorbisMod, "CursedSoul"),
                GetModItem(ModConditions.edorbisMod, "KelviniteRadar"),
                GetModItem(ModConditions.edorbisMod, "SlayerTrophy"),
                GetModItem(ModConditions.edorbisMod, "ThePrettiestFlower"),
                GetModItem(ModConditions.edorbisMod, "DyingEcosystem"),
                //Enchanted Moons
                GetModItem(ModConditions.enchantedMoonsMod, "BlueMedallion"),
                GetModItem(ModConditions.enchantedMoonsMod, "CherryAmulet"),
                GetModItem(ModConditions.enchantedMoonsMod, "HarvestLantern"),
                GetModItem(ModConditions.enchantedMoonsMod, "MintRing"),
                //Everjade
                GetModItem(ModConditions.everjadeMod, "FestivalLantern"),
                //Excelsior
                GetModItem(ModConditions.excelsiorMod, "ReflectiveIceShard"),
                GetModItem(ModConditions.excelsiorMod, "PlanetaryTrackingDevice"),
                //Exxo Avalon Origins
                GetModItem(ModConditions.exxoAvalonOriginsMod, "BloodyAmulet"),
                GetModItem(ModConditions.exxoAvalonOriginsMod, "InfestedCarcass"),
                GetModItem(ModConditions.exxoAvalonOriginsMod, "DesertHorn"),
                GetModItem(ModConditions.exxoAvalonOriginsMod, "GoblinRetreatOrder"),
                GetModItem(ModConditions.exxoAvalonOriginsMod, "FalseTreasureMap"),
                GetModItem(ModConditions.exxoAvalonOriginsMod, "OddFertilizer"),
                //Gensokyo
                GetModItem(ModConditions.gensokyoMod, "AliceMargatroidSpawner"),
                GetModItem(ModConditions.gensokyoMod, "CirnoSpawner"),
                GetModItem(ModConditions.gensokyoMod, "EternityLarvaSpawner"),
                GetModItem(ModConditions.gensokyoMod, "HinaKagiyamaSpawner"),
                GetModItem(ModConditions.gensokyoMod, "KaguyaHouraisanSpawner"),
                GetModItem(ModConditions.gensokyoMod, "LilyWhiteSpawner"),
                GetModItem(ModConditions.gensokyoMod, "MayumiJoutouguuSpawner"),
                GetModItem(ModConditions.gensokyoMod, "MedicineMelancholySpawner"),
                GetModItem(ModConditions.gensokyoMod, "MinamitsuMurasaSpawner"),
                GetModItem(ModConditions.gensokyoMod, "NazrinSpawner"),
                GetModItem(ModConditions.gensokyoMod, "NitoriKawashiroSpawner"),
                GetModItem(ModConditions.gensokyoMod, "RumiaSpawner"),
                GetModItem(ModConditions.gensokyoMod, "SakuyaIzayoiSpawner"),
                GetModItem(ModConditions.gensokyoMod, "SeijaKijinSpawner"),
                GetModItem(ModConditions.gensokyoMod, "SeiranSpawner"),
                GetModItem(ModConditions.gensokyoMod, "SekibankiSpawner"),
                GetModItem(ModConditions.gensokyoMod, "TenshiHinanawiSpawner"),
                GetModItem(ModConditions.gensokyoMod, "ToyosatomimiNoMikoSpawner"),
                GetModItem(ModConditions.gensokyoMod, "UtsuhoReiujiSpawner"),
                //Homeward Journey
                GetModItem(ModConditions.homewardJourneyMod, "PurpleFlareGun"),
                GetModItem(ModConditions.homewardJourneyMod, "BeeLarva"),
                GetModItem(ModConditions.homewardJourneyMod, "MaliciousPacket"),
                GetModItem(ModConditions.homewardJourneyMod, "CannedSoulofFlight"),
                GetModItem(ModConditions.homewardJourneyMod, "MetalSpine"),
                GetModItem(ModConditions.homewardJourneyMod, "SouthernPotting"),
                GetModItem(ModConditions.homewardJourneyMod, "SunlightCrown"),
                GetModItem(ModConditions.homewardJourneyMod, "UltimateTorch"),
                GetModItem(ModConditions.homewardJourneyMod, "UnstableGlobe"),
                GetModItem(ModConditions.homewardJourneyMod, "CapricornMedal"),
                GetModItem(ModConditions.homewardJourneyMod, "GeminiMedal"),
                GetModItem(ModConditions.homewardJourneyMod, "LibraMedal"),
                GetModItem(ModConditions.homewardJourneyMod, "ScorpioMedal"),
                GetModItem(ModConditions.homewardJourneyMod, "TaurusMedal"),
                GetModItem(ModConditions.homewardJourneyMod, "VirgoMedal"),
                //Martains Order
                GetModItem(ModConditions.martainsOrderMod, "AntRubble"),
                GetModItem(ModConditions.martainsOrderMod, "FrigidEgg"),
                GetModItem(ModConditions.martainsOrderMod, "SuspiciousLookingCloud"),
                GetModItem(ModConditions.martainsOrderMod, "Catnip"),
                GetModItem(ModConditions.martainsOrderMod, "CarnageSuspiciousRazor"),
                GetModItem(ModConditions.martainsOrderMod, "VoidWorm"),
                GetModItem(ModConditions.martainsOrderMod, "LuminiteSlimeCrown"),
                GetModItem(ModConditions.martainsOrderMod, "LuminiteEye"),
                GetModItem(ModConditions.martainsOrderMod, "JunglesLastTreasure"),
                GetModItem(ModConditions.martainsOrderMod, "TeslaRemote"),
                GetModItem(ModConditions.martainsOrderMod, "BloodyNight"),
                GetModItem(ModConditions.martainsOrderMod, "LucidDay"),
                GetModItem(ModConditions.martainsOrderMod, "LucidFestival"),
                GetModItem(ModConditions.martainsOrderMod, "LucidNight"),
                //Medial Rift
                GetModItem(ModConditions.medialRiftMod, "RemoteOfTheMetalHeads"),
                //Metroid Mod
                GetModItem(ModConditions.metroidMod, "GoldenTorizoSummon"),
                GetModItem(ModConditions.metroidMod, "KraidSummon"),
                GetModItem(ModConditions.metroidMod, "NightmareSummon"),
                GetModItem(ModConditions.metroidMod, "OmegaPirateSummon"),
                GetModItem(ModConditions.metroidMod, "PhantoonSummon"),
                GetModItem(ModConditions.metroidMod, "SerrisSummon"),
                GetModItem(ModConditions.metroidMod, "TorizoSummon"),
                //Ophioid
                GetModItem(ModConditions.ophioidMod, "DeadFungusbug"),
                GetModItem(ModConditions.ophioidMod, "InfestedCompost"),
                GetModItem(ModConditions.ophioidMod, "LivingCarrion"),
                //Qwerty
                GetModItem(ModConditions.qwertyMod, "AncientEmblem"),
                GetModItem(ModConditions.qwertyMod, "B4Summon"),
                GetModItem(ModConditions.qwertyMod, "BladeBossSummon"),
                GetModItem(ModConditions.qwertyMod, "DinoEgg"),
                //Common.GetModItem(ModConditions.qwertyMod, "FortressBossSummon"),
                //Common.GetModItem(ModConditions.qwertyMod, "GodSealKeycard"),
                GetModItem(ModConditions.qwertyMod, "HydraSummon"),
                GetModItem(ModConditions.qwertyMod, "RitualInterupter"),
                GetModItem(ModConditions.qwertyMod, "SummoningRune"),
                //Redemption
                GetModItem(ModConditions.redemptionMod, "EaglecrestSpelltome"),
                GetModItem(ModConditions.redemptionMod, "EggCrown"),
                GetModItem(ModConditions.redemptionMod, "FowlWarHorn"),
                //Secrets of the Shadows
                GetModItem(ModConditions.secretsOfTheShadowsMod, "ElectromagneticLure"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "SuspiciousLookingCandle"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "JarOfPeanuts"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "CatalystBomb"),
                //Shadows of Abaddon
                GetModItem(ModConditions.shadowsOfAbaddonMod, "PumpkinLantern"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "PrimordiaSummon"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "AbaddonSummon"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "SerpentSummon"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "SoranEmblem"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "HeirsAuthority"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "PigmanBanner"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "SandstormMedallion"),
                //Spirit
                GetModItem(ModConditions.spiritClassicMod, "DistressJellyItem"),
                GetModItem(ModConditions.spiritClassicMod, "GladeWreath"),
                GetModItem(ModConditions.spiritClassicMod, "ReachBossSummon"),
                GetModItem(ModConditions.spiritClassicMod, "JewelCrown"),
                GetModItem(ModConditions.spiritClassicMod, "BlackPearl"),
                GetModItem(ModConditions.spiritClassicMod, "BlueMoonSpawn"),
                GetModItem(ModConditions.spiritClassicMod, "DuskCrown"),
                GetModItem(ModConditions.spiritClassicMod, "CursedCloth"),
                GetModItem(ModConditions.spiritClassicMod, "StoneSkin"),
                GetModItem(ModConditions.spiritClassicMod, "MartianTransmitter"),
                //Spooky
                GetModItem(ModConditions.spookyMod, "Fertilizer"),
                GetModItem(ModConditions.spookyMod, "RottenSeed"),
                //Storms Additions
                GetModItem(ModConditions.stormsAdditionsMod, "AridBossSummon"),
                GetModItem(ModConditions.stormsAdditionsMod, "MoonlingSummoner"),
                GetModItem(ModConditions.stormsAdditionsMod, "StormBossSummoner"),
                GetModItem(ModConditions.stormsAdditionsMod, "UltimateBossSummoner"),
                //Supernova
                GetModItem(ModConditions.supernovaMod, "BugOnAStick"),
                GetModItem(ModConditions.supernovaMod, "EerieCrystal"),
                //Thorium
                GetModItem(ModConditions.thoriumMod, "StormFlare"),
                GetModItem(ModConditions.thoriumMod, "JellyfishResonator"),
                GetModItem(ModConditions.thoriumMod, "UnstableCore"),
                GetModItem(ModConditions.thoriumMod, "AncientBlade"),
                GetModItem(ModConditions.thoriumMod, "StarCaller"),
                GetModItem(ModConditions.thoriumMod, "StriderTear"),
                GetModItem(ModConditions.thoriumMod, "VoidLens"),
                GetModItem(ModConditions.thoriumMod, "AromaticBulb"),
                GetModItem(ModConditions.thoriumMod, "AbyssalShadow2"),
                GetModItem(ModConditions.thoriumMod, "DoomSayersCoin"),
                GetModItem(ModConditions.thoriumMod, "FreshBrain"),
                GetModItem(ModConditions.thoriumMod, "RottingSpore"),
                GetModItem(ModConditions.thoriumMod, "IllusionaryGlass"),
                //Utric
                GetModItem(ModConditions.uhtricMod, "RareGeode"),
                GetModItem(ModConditions.uhtricMod, "SnowyCharcoal"),
                GetModItem(ModConditions.uhtricMod, "CosmicLure"),
                //Universe of Swords
                GetModItem(ModConditions.universeOfSwordsMod, "SwordBossSummon"),
                //Valhalla
                GetModItem(ModConditions.valhallaMod, "HeavensSeal"),
                GetModItem(ModConditions.valhallaMod, "HellishRadish"),
                //Vitality
                GetModItem(ModConditions.vitalityMod, "CloudCore"),
                GetModItem(ModConditions.vitalityMod, "AncientCrown"),
                GetModItem(ModConditions.vitalityMod, "MultigemCluster"),
                GetModItem(ModConditions.vitalityMod, "MoonlightLotusFlower"),
                GetModItem(ModConditions.vitalityMod, "Dreadcandle"),
                GetModItem(ModConditions.vitalityMod, "MeatyMushroom"),
                GetModItem(ModConditions.vitalityMod, "AnarchyCrystal"),
                GetModItem(ModConditions.vitalityMod, "TotemofChaos"),
                GetModItem(ModConditions.vitalityMod, "MartianRadio"),
                GetModItem(ModConditions.vitalityMod, "SpiritBox"),
                //Wayfair
                GetModItem(ModConditions.wayfairContentMod, "MagicFertilizer"),
                //Zylon
                GetModItem(ModConditions.zylonMod, "ForgottenFlame"),
                GetModItem(ModConditions.zylonMod, "SlimyScepter")
            };
            ModdedBossAndEventSummons.UnionWith(TempModdedBossAndEventSummons);

            HashSet<int> TempFargosBossAndEventSummons = new()
            {
                //Fargos Mutant
                    //ABOMINATIONN NPC ITEMS
                GetModItem(ModConditions.fargosMutantMod, "Anemometer"),
                GetModItem(ModConditions.fargosMutantMod, "BatteredClub"),
                GetModItem(ModConditions.fargosMutantMod, "BetsyEgg"),
                GetModItem(ModConditions.fargosMutantMod, "FestiveOrnament"),
                GetModItem(ModConditions.fargosMutantMod, "ForbiddenScarab"),
                GetModItem(ModConditions.fargosMutantMod, "ForbiddenTome"),
                GetModItem(ModConditions.fargosMutantMod, "HeadofMan"),
                GetModItem(ModConditions.fargosMutantMod, "IceKingsRemains"),
                GetModItem(ModConditions.fargosMutantMod, "MartianMemoryStick"),
                GetModItem(ModConditions.fargosMutantMod, "MatsuriLantern"),
                GetModItem(ModConditions.fargosMutantMod, "NaughtyList"),
                GetModItem(ModConditions.fargosMutantMod, "PartyInvite"),
                GetModItem(ModConditions.fargosMutantMod, "PillarSummon"),
                GetModItem(ModConditions.fargosMutantMod, "RunawayProbe"),
                GetModItem(ModConditions.fargosMutantMod, "SlimyBarometer"),
                GetModItem(ModConditions.fargosMutantMod, "SpentLantern"),
                GetModItem(ModConditions.fargosMutantMod, "SpookyBranch"),
                GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingScythe"),
                GetModItem(ModConditions.fargosMutantMod, "WeatherBalloon"),
                    //DEVIANTT NPC ITEMS
                GetModItem(ModConditions.fargosMutantMod, "AmalgamatedSkull"),
                GetModItem(ModConditions.fargosMutantMod, "AmalgamatedSpirit"),
                GetModItem(ModConditions.fargosMutantMod, "AthenianIdol"),
                GetModItem(ModConditions.fargosMutantMod, "AttractiveOre"),
                GetModItem(ModConditions.fargosMutantMod, "BloodSushiPlatter"),
                GetModItem(ModConditions.fargosMutantMod, "BloodUrchin"),
                GetModItem(ModConditions.fargosMutantMod, "CloudSnack"),
                GetModItem(ModConditions.fargosMutantMod, "ClownLicense"),
                GetModItem(ModConditions.fargosMutantMod, "CoreoftheFrostCore"),
                GetModItem(ModConditions.fargosMutantMod, "CorruptChest"),
                GetModItem(ModConditions.fargosMutantMod, "CrimsonChest"),
                GetModItem(ModConditions.fargosMutantMod, "DemonicPlushie"),
                GetModItem(ModConditions.fargosMutantMod, "DilutedRainbowMatter"),
                GetModItem(ModConditions.fargosMutantMod, "Eggplant"),
                GetModItem(ModConditions.fargosMutantMod, "ForbiddenForbiddenFragment"),
                GetModItem(ModConditions.fargosMutantMod, "GnomeHat"),
                GetModItem(ModConditions.fargosMutantMod, "GoblinScrap"),
                GetModItem(ModConditions.fargosMutantMod, "GoldenSlimeCrown"),
                GetModItem(ModConditions.fargosMutantMod, "GrandCross"),
                GetModItem(ModConditions.fargosMutantMod, "HallowChest"),
                GetModItem(ModConditions.fargosMutantMod, "HeartChocolate"),
                GetModItem(ModConditions.fargosMutantMod, "HemoclawCrab"),
                GetModItem(ModConditions.fargosMutantMod, "HolyGrail"),
                GetModItem(ModConditions.fargosMutantMod, "JungleChest"),
                GetModItem(ModConditions.fargosMutantMod, "LeesHeadband"),
                GetModItem(ModConditions.fargosMutantMod, "MothLamp"),
                GetModItem(ModConditions.fargosMutantMod, "MothronEgg"),
                GetModItem(ModConditions.fargosMutantMod, "Pincushion"),
                GetModItem(ModConditions.fargosMutantMod, "PinkSlimeCrown"),
                GetModItem(ModConditions.fargosMutantMod, "PirateFlag"),
                GetModItem(ModConditions.fargosMutantMod, "PlunderedBooty"),
                GetModItem(ModConditions.fargosMutantMod, "RuneOrb"),
                GetModItem(ModConditions.fargosMutantMod, "ShadowflameIcon"),
                GetModItem(ModConditions.fargosMutantMod, "SlimyLockBox"),
                GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingChest"),
                GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingLure"),
                GetModItem(ModConditions.fargosMutantMod, "WormSnack"),
                    //MUTANT NPC ITEMS
                GetModItem(ModConditions.fargosMutantMod, "Abeemination2"),
                GetModItem(ModConditions.fargosMutantMod, "AncientSeal"),
                GetModItem(ModConditions.fargosMutantMod, "CelestialSigil2"),
                GetModItem(ModConditions.fargosMutantMod, "CultistSummon"),
                GetModItem(ModConditions.fargosMutantMod, "DeathBringerFairy"),
                GetModItem(ModConditions.fargosMutantMod, "DeerThing2"),
                GetModItem(ModConditions.fargosMutantMod, "FleshyDoll"),
                GetModItem(ModConditions.fargosMutantMod, "GoreySpine"),
                GetModItem(ModConditions.fargosMutantMod, "JellyCrystal"),
                GetModItem(ModConditions.fargosMutantMod, "LihzahrdPowerCell2"),
                GetModItem(ModConditions.fargosMutantMod, "MechanicalAmalgam"),
                GetModItem(ModConditions.fargosMutantMod, "MechEye"),
                GetModItem(ModConditions.fargosMutantMod, "MechSkull"),
                GetModItem(ModConditions.fargosMutantMod, "MechWorm"),
                GetModItem(ModConditions.fargosMutantMod, "MutantVoodoo"),
                GetModItem(ModConditions.fargosMutantMod, "PlanterasFruit"),
                GetModItem(ModConditions.fargosMutantMod, "PrismaticPrimrose"),
                GetModItem(ModConditions.fargosMutantMod, "SlimyCrown"),
                GetModItem(ModConditions.fargosMutantMod, "SuspiciousEye"),
                GetModItem(ModConditions.fargosMutantMod, "SuspiciousSkull"),
                GetModItem(ModConditions.fargosMutantMod, "TruffleWorm2"),
                GetModItem(ModConditions.fargosMutantMod, "WormyFood"),
                //Fargos Souls
                GetModItem(ModConditions.fargosSoulsMod, "AbomsCurse"),
                GetModItem(ModConditions.fargosSoulsMod, "ChampionySigil"),
                GetModItem(ModConditions.fargosSoulsMod, "CoffinSummon"),
                GetModItem(ModConditions.fargosSoulsMod, "DevisCurse"),
                GetModItem(ModConditions.fargosSoulsMod, "FragilePixieLamp"),
                GetModItem(ModConditions.fargosSoulsMod, "MechLure"),
                GetModItem(ModConditions.fargosSoulsMod, "MutantsCurse"),
                GetModItem(ModConditions.fargosSoulsMod, "SquirrelCoatofArms"),
                //Fargos DLC
                GetModItem(ModConditions.fargosSoulsDLCMod, "AbandonedRemote"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "ABombInMyNation"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "AstrumCor"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "BirbPheromones"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "BlightedEye"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "BloodyWorm"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "ChunkyStardust"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "ClamPearl"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "ColossalTentacle"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "CryingKey"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "DeepseaProteinShake"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "DefiledCore"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "DefiledShard"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "DragonEgg"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "EyeofExtinction"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "FriedDoll"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "HiveTumor"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "LetterofKos"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "MaulerSkull"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "MedallionoftheDesert"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "MurkySludge"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "NoisyWhistle"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "NuclearChunk"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "OphiocordycipitaceaeSprout"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "PlaguedWalkieTalkie"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "PolterplasmicBeacon"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "PortableCodebreaker"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "QuakeIdol"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "RedStainedWormFood"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "RiftofKos"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "SeeFood"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "SirensPearl"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "SomeKindofSpaceWorm"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "StormIdol"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "SulphurBearTrap"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "WormFoodofKos"),
                GetModItem(ModConditions.fargosSoulsDLCMod, "WyrmTablet"),
                //Fargos Extras
                GetModItem(ModConditions.fargosSoulsExtrasMod, "PandorasBox")
            };
            FargosBossAndEventSummons.UnionWith(TempFargosBossAndEventSummons);

            HashSet<int> ModPrefixes = new()
            {
                GetModPrefix(ModConditions.calamityMod, "Flawless"),
                GetModPrefix(ModConditions.calamityMod, "Silent"),
                GetModPrefix(ModConditions.calamityEntropyMod, "Enchanted"),
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
                GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Omnipotent"),
                GetModPrefix(ModConditions.thoriumMod, "Fabled"),
                GetModPrefix(ModConditions.thoriumMod, "Engrossing"),
                GetModPrefix(ModConditions.thoriumMod, "Lucrative"),
                GetModPrefix(ModConditions.vitalityMod, "MalevolentPrefix"),
                GetModPrefix(ModConditions.vitalityMod, "RelentlessPrefix")
            };
            Prefixes.UnionWith(ModPrefixes);

            HashSet<int> ModPermanentUpgrades = new()
            {
                GetModItem(ModConditions.aequusMod, "CosmicChest"),
                GetModItem(ModConditions.aequusMod, "TinkerersGuidebook"),
                GetModItem(ModConditions.aequusMod, "MoneyTrashcan"),
                GetModItem(ModConditions.aequusMod, "VictorsReward"),
                GetModItem(ModConditions.calamityMod, "MushroomPlasmaRoot"),
                GetModItem(ModConditions.calamityMod, "InfernalBlood"),
                GetModItem(ModConditions.calamityMod, "RedLightningContainer"),
                GetModItem(ModConditions.calamityMod, "ElectrolyteGelPack"),
                GetModItem(ModConditions.calamityMod, "StarlightFuelCell"),
                GetModItem(ModConditions.calamityMod, "Ectoheart"),
                GetModItem(ModConditions.calamityMod, "CelestialOnion"),
                GetModItem(ModConditions.clickerClassMod, "HeavenlyChip"),
                GetModItem(ModConditions.exxoAvalonOriginsMod, "EnergyCrystal"),
                GetModItem(ModConditions.fargosSoulsMod, "DeerSinew"),
                GetModItem(ModConditions.fargosSoulsMod, "MutantsCreditCard"),
                GetModItem(ModConditions.fargosSoulsMod, "MutantsDiscountCard"),
                GetModItem(ModConditions.fargosSoulsMod, "MutantsPact"),
                GetModItem(ModConditions.fargosSoulsMod, "RabiesVaccine"),
                GetModItem(ModConditions.homewardJourneyMod, "Americano"),
                GetModItem(ModConditions.homewardJourneyMod, "Latte"),
                GetModItem(ModConditions.homewardJourneyMod, "Mocha"),
                GetModItem(ModConditions.homewardJourneyMod, "Cappuccino"),
                GetModItem(ModConditions.homewardJourneyMod, "AirHandcanon"),
                GetModItem(ModConditions.homewardJourneyMod, "HotCase"),
                GetModItem(ModConditions.homewardJourneyMod, "GreatCrystal"),
                GetModItem(ModConditions.homewardJourneyMod, "WhimInABottle"),
                GetModItem(ModConditions.homewardJourneyMod, "SunsHeart"),
                GetModItem(ModConditions.homewardJourneyMod, "TheSwitch"),
                GetModItem(ModConditions.martainsOrderMod, "FishOfPurity"),
                GetModItem(ModConditions.martainsOrderMod, "FishOfSpirit"),
                GetModItem(ModConditions.martainsOrderMod, "FishOfWrath"),
                GetModItem(ModConditions.martainsOrderMod, "ShimmerFish"),
                GetModItem(ModConditions.martainsOrderMod, "MerchantBag"),
                GetModItem(ModConditions.martainsOrderMod, "FirstAidTreatments"),
                GetModItem(ModConditions.martainsOrderMod, "MartiniteBless"),
                GetModItem(ModConditions.redemptionMod, "GalaxyHeart"),
                GetModItem(ModConditions.redemptionMod, "MedicKit"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "ScarletStar"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "VioletStar"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "SoulHeart"),
                GetModItem(ModConditions.thoriumMod, "AstralWave"),
                GetModItem(ModConditions.thoriumMod, "InspirationGem")
            };
            PermanentUpgrades.UnionWith(ModPermanentUpgrades);

            HashSet<int> ModPermanentMultiUseUpgrades = new()
            {
                GetModItem(ModConditions.calamityMod, "EnchantedStarfish"),
                GetModItem(ModConditions.exxoAvalonOriginsMod, "StaminaCrystal"),
                GetModItem(ModConditions.ragnarokMod, "InspirationEssence"),
                GetModItem(ModConditions.secretsOfTheShadowsMod, "VoidenAnkh"),
                GetModItem(ModConditions.thoriumMod, "CrystalWave"),
                GetModItem(ModConditions.thoriumMod, "InspirationFragment"),
                GetModItem(ModConditions.thoriumMod, "InspirationShard"),
                GetModItem(ModConditions.thoriumMod, "InspirationCrystalNew")
            };
            PermanentMultiUseUpgrades.UnionWith(ModPermanentMultiUseUpgrades);

            HashSet<int> ModEmblems = new()
            {
                GetModItem(ModConditions.calamityMod, "RogueEmblem"),
                GetModItem(ModConditions.clickerClassMod, "ClickerEmblem"),
                GetModItem(ModConditions.martainsOrderMod, "ThrowerEmblem"),
                GetModItem(ModConditions.martainsOrderMod, "NeutralEmblem"),
                //Common.GetModItem(ModConditions.orchidMod, "AlchemistEmblem"),
                GetModItem(ModConditions.orchidMod, "GuardianEmblem"),
                GetModItem(ModConditions.orchidMod, "ShamanEmblem"),
                GetModItem(ModConditions.shadowsOfAbaddonMod, "NinjaEmblem"),
                GetModItem(ModConditions.thoriumMod, "BardEmblem"),
                GetModItem(ModConditions.thoriumMod, "ClericEmblem"),
                GetModItem(ModConditions.thoriumMod, "NinjaEmblem"),
            };
            Emblems.UnionWith(ModEmblems);

            HashSet<DamageClass> TempVoidClasses = new()
            {
                GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMelee"),
                GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidRanged"),
                GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMagic"),
                GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidSummon"),
                GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidGeneric"),
                GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic"),
                GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant"),
                GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing"),
                GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")
            };
            VoidDamageClasses.UnionWith(TempVoidClasses);

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
                GetModTile(ModConditions.thoriumMod, "ValadiumChunk"),
                GetModTile(ModConditions.thoriumMod, "Aquamarine"),
                GetModTile(ModConditions.thoriumMod, "Opal"),
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

            for (int i = BuffID.Count; i < BuffLoader.BuffCount; i++)
            {
                if (BuffID.Sets.IsAFlaskBuff[BuffLoader.GetBuff(i).Type] && !FlaskBuffs.Contains(BuffLoader.GetBuff(i).Type))
                    FlaskBuffs.Add(BuffLoader.GetBuff(i).Type);
            }

            if (ModConditions.thoriumLoaded)
            {
                HashSet<int> TempThoriumCoatings = new()
                {
                    GetModBuff(ModConditions.thoriumMod, "DeepFreezeCoatingBuff"),
                    GetModBuff(ModConditions.thoriumMod, "ExplosiveCoatingBuff"),
                    GetModBuff(ModConditions.thoriumMod, "GorgonCoatingBuff"),
                    GetModBuff(ModConditions.thoriumMod, "SporeCoatingBuff"),
                    GetModBuff(ModConditions.thoriumMod, "ToxicCoatingBuff"),
                };
                ThoriumCoatings.UnionWith(TempThoriumCoatings);
            }
        }

        public static void Reset()
        {

        }

        public static Condition ItemToggled(string displayText, Func<bool> toggle)
        {
            return new Condition(Language.GetTextValue(displayText), toggle);
        }

        public static Recipe GetItemRecipe(Func<bool> toggle, int itemType, int amount = 1, string displayText = "")
        {
            Recipe obj = Recipe.Create(itemType, amount);
            obj.AddCondition(ItemToggled(displayText, toggle));
            return obj;
        }

        public static Color ColorSwap(Color firstColor, Color secondColor, float seconds)
        {
            float num = (float)((Math.Sin(Math.PI * 2.0 / (double)seconds * Main.GlobalTimeWrappedHourly) + 1.0) * 0.5);
            return Color.Lerp(firstColor, secondColor, num);
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

        public static bool IsACoin(this Item item)
        {
            return item.type is >= 71 and <= 74;
        }

        public static bool IsATool(this Item item)
        {
            return item.pick > 0 || item.axe > 0 || item.hammer > 0 || item.fishingPole > 0 || ((item.createTile > -1 || item.createWall > -1) && item.damage > -1);
        }

        public static bool IsArmor(this Item item)
        {
            if (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1)
                return !item.vanity;
            return false;
        }

        public static bool IsAnEquippable(this Item item)
        {
            /* 
             * item.accessory
             * item.IsArmor()
             * item.vanity
             * (item.buffType != 0 && Main.vanityPet[item.buffType])
             * (item.buffType != 0 && Main.lightPet[item.buffType])
             * item.mountType > -1
             * (item.shoot != ProjectileID.None && Main.projHook[item.shoot])
            */
            if (item.accessory || item.IsArmor() || item.vanity || item.mountType > -1 || (item.buffType != 0 && Main.vanityPet[item.buffType]) || (item.buffType != 0 && Main.lightPet[item.buffType]) || (item.shoot != ProjectileID.None && Main.projHook[item.shoot]))
                return true;
            return false;
        }

        public static bool IsAWeapon(this Item item)
        {
            /*
             * item.DamageType != null
             * !item.IsAnEquippable()
             * !item.IsATool()
             * !item.IsCurrency
            */
            if (item.DamageType != null && !item.IsAnEquippable() && !item.IsATool() && !item.IsCurrency)
                return true;
            return false;
        }

        public static void ItemDisabledTooltip(Item item, List<TooltipLine> tooltips, bool configOn)
        {
            TooltipLine name = tooltips.Find(l => l.Name == "ItemName");
            if (!configOn)
            {
                name.Text += " " + Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ItemDisabled");
                name.OverrideColor = Color.Red;
            }

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

        public static string ModBuffAsset(Mod mod, int buffType)
        {
            if (mod != null && BuffLoader.GetBuff(buffType) != null)
                return BuffLoader.GetBuff(buffType).Texture;
            return "QoLCompendium/Assets/Items/PermanentBuff";
        }

        public static void VanillaBuffHandler(int buff, Player player)
        {
            if (player.HasBuff(buff))
                return;

            switch (buff)
            {
                case BuffID.AmmoBox:
                    player.ammoBox = true;
                    break;
                case BuffID.AmmoReservation:
                    player.ammoPotion = true;
                    break;
                case BuffID.Archery:
                    player.archery = true;
                    player.arrowDamage *= 1.1f;
                    break;
                case BuffID.Battle:
                    player.enemySpawns = true;
                    break;
                case BuffID.Bewitched:
                    player.maxMinions += 1;
                    break;
                case BuffID.BiomeSight:
                    player.biomeSight = true;
                    break;
                case BuffID.Builder:
                    player.tileSpeed += 0.25f;
                    player.wallSpeed += 0.25f;
                    player.blockRange++;
                    break;
                case BuffID.Calm:
                    player.calmed = true;
                    break;
                case BuffID.Campfire:
                    player.lifeRegen++;
                    break;
                case BuffID.CatBast:
                    player.statDefense += 5;
                    break;
                case BuffID.Clairvoyance:
                    player.GetDamage(DamageClass.Magic) += 0.05f;
                    player.GetCritChance(DamageClass.Magic) += 2f;
                    player.statManaMax2 += 20;
                    player.manaCost -= 0.02f;
                    break;
                case BuffID.Crate:
                    player.cratePotion = true;
                    break;
                case BuffID.Dangersense:
                    player.dangerSense = true;
                    break;
                case BuffID.Endurance:
                    player.endurance += 0.1f;
                    break;
                case BuffID.Featherfall:
                    player.slowFall = true;
                    break;
                case BuffID.Fishing:
                    player.fishingSkill += 15;
                    break;
                case BuffID.Flipper:
                    player.accFlipper = true;
                    break;
                case BuffID.Gills:
                    player.gills = true;
                    break;
                case BuffID.Gravitation:
                    player.gravControl = true;
                    break;
                case BuffID.Lucky:
                    player.luckPotion = 3;
                    break;
                case BuffID.HeartLamp:
                    player.lifeRegen += 2;
                    break;
                case BuffID.Heartreach:
                    player.lifeMagnet = true;
                    break;
                case BuffID.Honey:
                    player.lifeRegenTime += 2f;
                    player.lifeRegen += 2;
                    break;
                case BuffID.Hunter:
                    player.detectCreature = true;
                    break;
                case BuffID.Inferno:
                    player.inferno = true;
                    Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
                    int num2 = 323;
                    float num3 = 200f;
                    bool flag = player.infernoCounter % 60 == 0;
                    int damage = 20;
                    for (int k = 0; k < 200; k++)
                    {
                        NPC nPC = Main.npc[k];
                        if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num2] && player.CanNPCBeHitByPlayerOrPlayerProjectile(nPC) && Vector2.Distance(player.Center, nPC.Center) <= num3)
                        {
                            if (nPC.FindBuffIndex(num2) == -1)
                                nPC.AddBuff(num2, 120);

                            if (flag)
                                player.ApplyDamageToNPC(nPC, damage, 0f, 0, crit: false);
                        }
                    }
                    break;
                case BuffID.Invisibility:
                    player.invis = true;
                    break;
                case BuffID.Ironskin:
                    player.statDefense += 8;
                    break;
                case BuffID.Lifeforce:
                    player.lifeForce = true;
                    player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
                    break;
                case BuffID.MagicPower:
                    player.GetDamage(DamageClass.Magic) += 0.2f;
                    break;
                case BuffID.ManaRegeneration:
                    player.manaRegenBuff = true;
                    break;
                case BuffID.Mining:
                    player.pickSpeed -= 0.25f;
                    break;
                case BuffID.NightOwl:
                    player.nightVision = true;
                    break;
                case BuffID.ObsidianSkin:
                    player.lavaImmune = true;
                    player.fireWalk = true;
                    player.buffImmune[BuffID.OnFire] = true;
                    break;
                case BuffID.PeaceCandle:
                    player.ZonePeaceCandle = true;
                    if (Main.myPlayer == player.whoAmI)
                        Main.SceneMetrics.PeaceCandleCount = 0;
                    break;
                case BuffID.Rage:
                    player.GetCritChance(DamageClass.Generic) += 10f;
                    break;
                case BuffID.Regeneration:
                    player.lifeRegen += 4;
                    break;
                case BuffID.ShadowCandle:
                    player.ZoneShadowCandle = true;
                    if (Main.myPlayer == player.whoAmI)
                        Main.SceneMetrics.ShadowCandleCount = 0;
                    break;
                case BuffID.Sharpened:
                    player.GetArmorPenetration(DamageClass.Melee) += 12;
                    break;
                case BuffID.Shine:
                    Lighting.AddLight((int)(player.position.X + player.width / 2) / 16, (int)(player.position.Y + player.height / 2) / 16, 0.8f, 0.95f, 1f);
                    break;
                case BuffID.Sonar:
                    player.sonarPotion = true;
                    break;
                case BuffID.Spelunker:
                    player.findTreasure = true;
                    break;
                case BuffID.StarInBottle:
                    player.manaRegenDelayBonus += 0.5f;
                    player.manaRegenBonus += 10;
                    break;
                case BuffID.SugarRush:
                    player.pickSpeed -= 0.2f;
                    player.moveSpeed += 0.2f;
                    break;
                case BuffID.Summoning:
                    player.maxMinions += 1;
                    break;
                case BuffID.Sunflower:
                    player.moveSpeed += 0.1f;
                    player.moveSpeed *= 1.1f;
                    player.sunflower = true;
                    break;
                case BuffID.Swiftness:
                    player.moveSpeed += 0.25f;
                    break;
                case BuffID.Thorns:
                    player.thorns = 1f;
                    break;
                case BuffID.Tipsy:
                    if (player.HeldItem.DamageType == DamageClass.Melee)
                    {
                        player.tipsy = true;
                        player.statDefense -= 4;
                        player.GetCritChance(DamageClass.Melee) += 2f;
                        player.GetDamage(DamageClass.Melee) += 0.1f;
                        player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                    }
                    break;
                case BuffID.Titan:
                    player.kbBuff = true;
                    break;
                case BuffID.Warmth:
                    player.resistCold = true;
                    break;
                case BuffID.WarTable:
                    player.maxTurrets += 1;
                    break;
                case BuffID.WaterCandle:
                    player.ZoneWaterCandle = true;
                    if (Main.myPlayer == player.whoAmI)
                        Main.SceneMetrics.WaterCandleCount = 0;
                    break;
                case BuffID.WaterWalking:
                    player.waterWalk = true;
                    break;
                case BuffID.WeaponImbueConfetti:
                    player.meleeEnchant = 7;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueCursedFlames:
                    player.meleeEnchant = 2;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueFire:
                    player.meleeEnchant = 3;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueGold:
                    player.meleeEnchant = 4;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueIchor:
                    player.meleeEnchant = 5;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueNanites:
                    player.meleeEnchant = 6;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbuePoison:
                    player.meleeEnchant = 8;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueVenom:
                    player.meleeEnchant = 1;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WellFed3:
                    player.wellFed = true;
                    player.statDefense += 4;
                    player.GetCritChance(DamageClass.Generic) += 4f;
                    player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                    player.GetKnockback(DamageClass.Summon) += 1f;
                    player.moveSpeed += 0.4f;
                    player.pickSpeed -= 0.15f;
                    break;
                case BuffID.Wrath:
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                    break;
                default:
                    break;
            }
        }

        public static void CreateBagRecipe(int[] items, int bagID)
        {
            for (int i = 0; i < items.Length; i++)
            {
                CreateSimpleRecipe(bagID, items[i], TileID.WorkBenches, 1, 1, true, false, ItemToggled("Mods.QoLCompendium.ItemToggledConditions.BossBags", () => QoLCompendium.mainConfig.EasierRecipes));
            }
        }

        public static void CreateCrateRecipe(int result, int crateID, int crateHardmodeID, int crateCount, params Condition[] conditions)
        {
            Recipe recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void CreateCrateHardmodeRecipe(int result, int crateHardmodeID, int crateCount, params Condition[] conditions)
        {
            Recipe recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void CreateCrateWithKeyRecipe(int item, int crateID, int crateHardmodeID, int crateCount, int keyID, params Condition[] conditions)
        {
            Recipe recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, item, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateID, crateCount);
            recipe.AddIngredient(keyID);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, item, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
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
            CreateSimpleRecipe(item1, item2, station, 1, 1, false, false, ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions));

            //Item 2 -> Item 1
            CreateSimpleRecipe(item2, item1, station, 1, 1, false, false, ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions));
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
                        CreateSimpleRecipe(Item.BannerToItem(num), resultID, TileID.WorkBenches, 1, 1, true, false, ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
                }
            }
        }

        public static void CreateLoopingRecipe(int[] items, int tileType)
        {
            List<int> newItems = [];
            for (int j = 0; j < items.Length; j++)
            {
                if (items[j] != 0)
                    newItems.Add(items[j]);
            }

            int firstID = GetFirstNonZeroValue(newItems.ToArray());
            int lastID = GetLastNonZeroValue(newItems.ToArray());

            for (int i = 0; i < newItems.Count; i++)
            {
                if (i >= newItems.Count - 1)
                    CreateSimpleRecipe(lastID, firstID, tileType);
                else
                    CreateSimpleRecipe(newItems[i], newItems[i + 1], tileType);
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

        public static Asset<Texture2D> GetAsset(string location, string filename, int fileNumber = -1)
        {
            if (fileNumber > -1)
                return ModContent.Request<Texture2D>("QoLCompendium/Assets/" + location + "/" + filename + fileNumber);
            else
                return ModContent.Request<Texture2D>("QoLCompendium/Assets/" + location + "/" + filename);
        }

        public static void TransmuteItems(int[] items)
        {
            List<int> newItems = [];
            for (int j = 0; j < items.Length; j++)
            {
                if (items[j] != 0)
                    newItems.Add(items[j]);
            }

            int firstID = GetFirstNonZeroValue(newItems.ToArray());
            int lastID = GetLastNonZeroValue(newItems.ToArray());

            for (int i = 0; i < newItems.Count; i++)
            {
                if (i >= newItems.Count - 1)
                    ItemID.Sets.ShimmerTransformToItem[lastID] = firstID;
                else
                {
                    if (newItems[i] != ItemID.None && newItems[i + 1] != ItemID.None)
                    {
                        ItemID.Sets.ShimmerTransformToItem[newItems[i]] = newItems[i + 1];
                    }
                }
            }
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

        public static bool CheckToActivateGlintEffect(Item item)
        {
            if (Main.gameMenu || !Main.LocalPlayer.active)
                return false;

            if (QoLCompendium.mainConfig.ActiveBuffsHaveEnchantedEffects && !item.IsAir && Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeBuffItems.Contains(item.type))
                return true;
            else if (QoLCompendium.mainConfig.GoodPrefixesHaveEnchantedEffects && !item.IsAir && Prefixes.Contains(item.prefix))
                return true;
            else if (ModConditions.calamityEntropyLoaded && QoLCompendium.crossModConfig.CalamityEntropyArmorPrefixesHaveEnchantedEffects)
            {
                if (!item.IsAir && CalamityEntropyArmorGlint.ArmorHasEntropyPrefix(item))
                    return true;
            }
            
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

        public static List<Item> GetAllInventoryItemsList(Player player, string ignores = "", int estimatedCapacity = 80)
        {
            ignores = ignores.Replace("portable", "inv piggy safe forge void", StringComparison.Ordinal);
            var itemList = new List<Item>(estimatedCapacity);
            var items = GetAllInventoryItems(player);
            foreach ((string name, Item[] itemArray) in items)
            {
                if (ignores.Contains(name, StringComparison.Ordinal))
                    continue;
                itemList.AddRange(itemArray);
            }

            return itemList;
        }

        public static Dictionary<string, Item[]> GetAllInventoryItems(Player player)
        {
            var items = new Dictionary<string, Item[]>
            {
                {"inv", player.inventory},
                {"piggy", player.bank.item},
                {"safe", player.bank2.item},
                {"forge", player.bank3.item},
                {"void", player.bank4.item}
            };

            return items;
        }

        public static void SetDefaultsToPermanentBuff(Item item)
        {
            item.width = item.height = 16;
            item.consumable = false;
            item.maxStack = 1;
            item.SetShopValues(ItemRarityColor.StrongRed10, 0);
        }

        public static void CombinedPermanentBuffRecipe(int[] ingredients, int result)
        {
            Recipe r = GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, result, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            foreach (int ingredient in ingredients)
                r.AddIngredient(ingredient);
            r.AddTile(TileID.CookingPots);
            r.Register();
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

        public static void DisableEvents()
        {
            if (Main.invasionType != 0)
                Main.invasionType = 0;
            if (Main.pumpkinMoon)
                Main.pumpkinMoon = false;
            if (Main.snowMoon)
                Main.snowMoon = false;
            if (Main.eclipse)
                Main.eclipse = false;
            if (Main.bloodMoon)
                Main.bloodMoon = false;
            if (Main.WindyEnoughForKiteDrops)
            {
                Main.windSpeedTarget = 0f;
                Main.windSpeedCurrent = 0f;
            }
            if (Main.slimeRain)
            {
                Main.StopSlimeRain(true);
                Main.slimeWarningDelay = 1;
                Main.slimeWarningTime = 1;
            }
            if (BirthdayParty.PartyIsUp)
                BirthdayParty.CheckNight();
            if (DD2Event.Ongoing && Main.netMode != NetmodeID.MultiplayerClient)
                DD2Event.StopInvasion(false);
            if (Sandstorm.Happening)
            {
                Sandstorm.Happening = false;
                Sandstorm.TimeLeft = 0.0;
                Sandstorm.IntendedSeverity = 0f;
            }
            if (NPC.downedTowers && (NPC.LunarApocalypseIsUp || NPC.ShieldStrengthTowerNebula > 0 || NPC.ShieldStrengthTowerSolar > 0 || NPC.ShieldStrengthTowerStardust > 0 || NPC.ShieldStrengthTowerVortex > 0))
            {
                NPC.LunarApocalypseIsUp = false;
                NPC.ShieldStrengthTowerNebula = 0;
                NPC.ShieldStrengthTowerSolar = 0;
                NPC.ShieldStrengthTowerStardust = 0;
                NPC.ShieldStrengthTowerVortex = 0;
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].active && (Main.npc[i].type == NPCID.LunarTowerNebula || Main.npc[i].type == NPCID.LunarTowerSolar || Main.npc[i].type == NPCID.LunarTowerStardust || Main.npc[i].type == NPCID.LunarTowerVortex))
                    {
                        Main.npc[i].dontTakeDamage = false;
                        Main.npc[i].StrikeInstantKill();
                    }
                }
            }
            if (Main.IsItRaining || Main.IsItStorming)
            {
                Main.StopRain();
                Main.cloudAlpha = 0f;
                if (Main.netMode == NetmodeID.Server)
                    Main.SyncRain();
            }
        }

        public static bool IsABoss(this NPC npc)
        {
            if (npc == null || !npc.active)
                return false;

            if (npc.boss && npc.type != NPCID.MartianSaucerCore)
                return true;

            if (npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsTail)
                return true;

            return false;
        }

        public static bool IsTileWithinPlayerReach(Player player)
        {
            Item item = player.inventory[player.selectedItem];
            int extraItemRange = 0;
            int extraBlockRange = player.blockRange;
            if (!item.IsAir)
                extraItemRange = item.tileBoost;
            Vector2 playerRange = new(Player.tileRangeX + extraBlockRange + extraItemRange, Player.tileRangeY + extraBlockRange + extraItemRange);
            Vector2 playerPosX = new(player.position.X / 16f - playerRange.X, (player.position.X + player.width) / 16f + playerRange.X);
            Vector2 playerPosY = new(player.position.Y / 16f - playerRange.Y, (player.position.Y + player.height) / 16f + playerRange.Y);

            if (playerPosX.X <= Player.tileTargetX && playerPosX.Y >= Player.tileTargetX && playerPosY.X <= Player.tileTargetY && playerPosY.Y >= Player.tileTargetY)
                return true;
            return false;
        }

        public static int ToFrames(float seconds, int extraUpdates = 0)
        {
            return (int)(seconds * 60 * (extraUpdates + 1));
        }

        public static int ToPixels(float blocks)
        {
            return (int)(blocks * 16);
        }

        public static float ToSeconds(float frames, int extraUpdates = 0)
        {
            return frames / (60 * (extraUpdates + 1));
        }

        public static float ToBlocks(float pixels)
        {
            return pixels / 16;
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
