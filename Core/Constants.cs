using MonoMod.RuntimeDetour;
using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Content.Tiles.Other;
using QoLCompendium.Core.PermanentBuffSystems;
using System.Reflection;

namespace QoLCompendium.Core
{
    public static class Constants
    {
        public static readonly BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
        
        public static List<Hook> Detours = [];

        #region Boss Summons
        public static readonly HashSet<int> VanillaBossSummons = new()
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
            ItemID.LihzahrdPowerCell,
            ItemID.CelestialSigil
        };

        public static readonly HashSet<int> VanillaEventSummons = new()
        {
            ItemID.BloodMoonStarter,
            ItemID.GoblinBattleStandard,
            ItemID.DD2ElderCrystal,
            ItemID.PirateMap,
            ItemID.SolarTablet,
            ItemID.SnowGlobe,
            ItemID.PumpkinMoonMedallion,
            ItemID.NaughtyPresent
        };

        public static HashSet<int> ModdedBossSummons = new();

        public static HashSet<int> ModdedEventSummons = new();

        public static HashSet<int> FargosBossSummons = new();

        public static HashSet<int> FargosEventSummons = new();

        public static HashSet<int> FargosEnemySummons = new();
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

        public static readonly HashSet<int> SnowBiomeBlocks =
        [
            ItemID.SnowBlock,
            ItemID.SlushBlock,
            ItemID.IceBlock,
            ItemID.PinkIceBlock,
            ItemID.PurpleIceBlock,
            ItemID.RedIceBlock
        ];

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

        public static readonly HashSet<int> Gravestones =
        [
            ItemID.Tombstone,
            ItemID.GraveMarker,
            ItemID.CrossGraveMarker,
            ItemID.Headstone,
            ItemID.Gravestone,
            ItemID.Obelisk,
            ItemID.RichGravestone1,
            ItemID.RichGravestone2,
            ItemID.RichGravestone3,
            ItemID.RichGravestone4,
            ItemID.RichGravestone5
        ];

        public static HashSet<int> IgnoredTilesForExplosives = new()
        {
            ModContent.TileType<AsphaltPlatformTile>()
        };

        public static HashSet<Mod> IgnoredModsForExplosives = new();

        public static readonly HashSet<int> DungeonTiles = new()
        {
            TileID.BlueDungeonBrick,
            TileID.GreenDungeonBrick,
            TileID.PinkDungeonBrick
        };

        public static readonly HashSet<int> DungeonWalls = new()
        {
            WallID.BlueDungeonSlabUnsafe,
            WallID.BlueDungeonTileUnsafe,
            WallID.BlueDungeonUnsafe,
            WallID.GreenDungeonSlabUnsafe,
            WallID.GreenDungeonTileUnsafe,
            WallID.GreenDungeonUnsafe,
            WallID.PinkDungeonSlabUnsafe,
            WallID.PinkDungeonTileUnsafe,
            WallID.PinkDungeonUnsafe
        };

        public static readonly HashSet<int> HardmodeOres = new()
        {
             TileID.Cobalt,
             TileID.Palladium,
             TileID.Mythril,
             TileID.Orichalcum,
             TileID.Adamantite,
             TileID.Titanium
        };

        public static HashSet<int> HerbTiles = new()
        {
            TileID.MatureHerbs,
            TileID.BloomingHerbs
        };

        #region Place Styles
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
        #endregion

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

        public static HashSet<int> ElementsAwokenBatteryItems = [];

        public static readonly HashSet<int> CoinIDs = new() { ItemID.CopperCoin, ItemID.SilverCoin, ItemID.GoldCoin, ItemID.PlatinumCoin };
        public static int PlatinumMaxStack = Item.CommonMaxStack;
        public const ulong CopperValue = 1;
        public const ulong SilverValue = 100;
        public const ulong GoldValue = 100 * 100;
        public const ulong PlatinumValue = 100 * 100 * 100;
        #endregion

        #region Damage Types
        public static HashSet<DamageClass> VoidDamageClasses = new();
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

        #region Critters & NPCs
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

        #region Permanent Buffs

        public static HashSet<int> AllBuffItems = new();

        public static HashSet<int> AllCombinedBuffItems = new();

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

        public static HashSet<int> FoodBuffs = [BuffID.WellFed, BuffID.WellFed2, BuffID.WellFed3];

        #endregion

        #region Biomes
        public static readonly List<Condition> BiomeConditions =
        [
            Condition.InDungeon,
            Condition.InCorrupt,
            Condition.InMeteor,
            Condition.InJungle,
            Condition.InSnow,
            Condition.InCrimson,
            Condition.InTowerSolar,
            Condition.InTowerNebula,
            Condition.InTowerStardust,
            Condition.InDesert,
            Condition.InGlowshroom,
            Condition.InUndergroundDesert,
            Condition.InSkyHeight,
            Condition.InSpace,
            Condition.InOverworldHeight,
            Condition.InDirtLayerHeight,
            Condition.InRockLayerHeight,
            Condition.InUnderworldHeight,
            Condition.InUnderworld,
            Condition.InBeach,
            Condition.InRain,
            Condition.InSandstorm,
            Condition.InOldOneArmy,
            Condition.InGranite,
            Condition.InMarble,
            Condition.InHive,
            Condition.InGemCave,
            Condition.InLihzhardTemple,
            Condition.InGraveyard,
            Condition.InAether,
            Condition.InShoppingZoneForest,
            Condition.InEvilBiome,
            Condition.NotInEvilBiome,
            Condition.NotInHallow,
            Condition.NotInGraveyard,
            Condition.NotInUnderworld
        ];
        #endregion
    }
}
